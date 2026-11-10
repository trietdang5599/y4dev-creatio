namespace Creatio.Copilot
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Responses;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion.Requests;
	using Terrasoft.Configuration.GenAI;
	using Terrasoft.Enrichment.Interfaces.ChatCompletion;
	using System.Collections.Generic;
	using System.Linq;
	using Creatio.FeatureToggling;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core.Applications.GenAI;
	using System.Security;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions;

	internal abstract class BaseCopilotExecutor
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("Copilot");
		private readonly IGenAICompletionServiceProxy _completionService;
		private readonly ILlmModelResolver _llmModelResolver;
		private readonly ICopilotContextBuilder _contextBuilder;
		private readonly ICopilotRequestLogger _requestLogger;
		private readonly ICopilotHyperlinkUtils _hyperlinkUtils;
		private readonly IToolFilterResolver _toolFilterResolver;
		private readonly IImageValidator _imageValidator;
		private readonly ImageBase64Extractor _imageBase64Extractor;

		#endregion

		#region Fields: Protected

		protected readonly UserConnection _userConnection;
		protected readonly IIntentPromptBuilder _intentPromptBuilder;
		protected readonly ICopilotIntentsStorage _intentsStorage;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseCopilotExecutor"/>
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="completionService">GenAI Completion service.</param>
		/// <param name="llmModelResolver">An instance of <see cref="ILlmModelResolver"/></param>
		/// <param name="contextBuilder">Copilot context builder.</param>
		/// <param name="requestLogger">Copilot request logger.</param>
		/// <param name="hyperlinkUtils">An instance of <see cref="ICopilotHyperlinkUtils"/>
		/// used for handling hyperlink-related utilities.</param>
		/// <param name="intentPromptBuilder">An instance of <see cref="IIntentPromptBuilder"/></param>
		/// <param name="intentsStorage"></param>
		/// <param name="toolFilterResolver">An instance of <see cref="IToolFilterResolver"/></param>
		protected BaseCopilotExecutor(UserConnection userConnection, IGenAICompletionServiceProxy completionService,
				ILlmModelResolver llmModelResolver, ICopilotContextBuilder contextBuilder,
				ICopilotRequestLogger requestLogger, ICopilotHyperlinkUtils hyperlinkUtils,
				IIntentPromptBuilder intentPromptBuilder, ICopilotIntentsStorage intentsStorage,
				IToolFilterResolver toolFilterResolver)
			: this(userConnection, completionService, llmModelResolver, contextBuilder, requestLogger, hyperlinkUtils,
				intentPromptBuilder, intentsStorage, toolFilterResolver, CreateDefaultImageValidator(),
				CreateDefaultImageBase64Extractor()) { }

		/// <param name="imageValidator">Image validator.</param>
		/// <param name="imageBase64Extractor">Image base64 extractor.</param>
		protected BaseCopilotExecutor(UserConnection userConnection, IGenAICompletionServiceProxy completionService,
				ILlmModelResolver llmModelResolver, ICopilotContextBuilder contextBuilder,
				ICopilotRequestLogger requestLogger, ICopilotHyperlinkUtils hyperlinkUtils,
				IIntentPromptBuilder intentPromptBuilder, ICopilotIntentsStorage intentsStorage,
				IToolFilterResolver toolFilterResolver, IImageValidator imageValidator,
				ImageBase64Extractor imageBase64Extractor) {
			_userConnection = userConnection;
			_completionService = completionService;
			_llmModelResolver = llmModelResolver;
			_contextBuilder = contextBuilder;
			_requestLogger = requestLogger;
			_hyperlinkUtils = hyperlinkUtils;
			_toolFilterResolver = toolFilterResolver;
			_intentPromptBuilder = intentPromptBuilder;
			_intentsStorage = intentsStorage;
			_imageValidator = imageValidator ?? throw new ArgumentNullOrEmptyException(nameof(imageValidator));
			_imageBase64Extractor = imageBase64Extractor ??
				throw new ArgumentNullOrEmptyException(nameof(imageBase64Extractor));
		}

		#endregion

		#region Methods: Private

		private static IImageValidator CreateDefaultImageValidator() {
			return new ImageValidator();
		}

		private static ImageBase64Extractor CreateDefaultImageBase64Extractor() {
			return new ImageBase64Extractor(CreateDefaultImageValidator());
		}

		private ChatCompletionRequest ApplyLlmModelToRequest(ChatCompletionRequest completionRequest,
				CopilotSession session) {
			if (Features.GetIsDisabled<Terrasoft.Configuration.GenAI.GenAIFeatures.MultiLlmSupport>()) {
				return completionRequest;
			}
			var intentId = session.CurrentIntentId ?? session.RootIntentId;
			LlmModelReference modelReference = _llmModelResolver.ResolveForIntent(intentId);
			string llmModelCode = modelReference?.Code;
			if (!string.IsNullOrEmpty(llmModelCode)) {
				completionRequest.Model = llmModelCode;
			}
			return completionRequest;
		}

		private static IEnumerable<ChatChoiceResponse> GetResponsesWithMessage(
				ChatCompletionResponse completionResponse) {
			return completionResponse.Choices.Where(response => response.Message.Content.IsNotNullOrEmpty());
		}

		private static IList<ChatMessageContentPart> CreateMultipartUserMessageContent(ChatMessage userMessage) {
			if (userMessage?.Contents.IsNotNullOrEmpty() == true) {
				return userMessage.Contents.ToList();
			}
			var contents = new List<ChatMessageContentPart>();
			if (userMessage?.Content.IsNotNullOrEmpty() == true) {
				contents.Add(new ChatMessageContentPart {
					Type = CompletionStatics.MessageContent.Text,
					Text = userMessage.Content
				});
			}
			return contents;
		}

		private static string GetDocumentKey(ICreatioAIDocument document) {
			return $"{document?.FileSchemaName}:{document?.FileId}";
		}

		private static Guid? GetDocumentMessageId(ICreatioAIDocument document) {
			return (document as CreatioAIDocument)?.MessageId;
		}

		private string TryBuildImageDataUrl(CopilotSession session, ICreatioAIDocument document) {
			if (document == null || document.FileId == Guid.Empty ||
				string.IsNullOrWhiteSpace(document.FileSchemaName) ||
				!_imageValidator.IsSupportedImage(document.FileName)) {
				return null;
			}
			string documentKey = GetDocumentKey(document);
			if (session?.TryGetCachedImageDataUrl(documentKey, out string cachedDataUrl) == true) {
				return cachedDataUrl;
			}
			try {
				IFileFactory fileFactory = _userConnection.GetFileFactory().WithRightsDisabled();
				IFile file = fileFactory.Get(new EntityFileLocator(document.FileSchemaName, document.FileId));
				string dataUrl = _imageBase64Extractor.ExtractText(file);
				session?.CacheImageDataUrl(documentKey, dataUrl);
				return dataUrl;
			} catch (Exception e) {
				_log.Warn($"Failed to read image '{document.FileName}' for copilot completion request.", e);
				return null;
			}
		}

		private ChatMessage CreateCompletionApiMessage(CopilotMessage message, CopilotSession session,
				IReadOnlyDictionary<Guid, ICreatioAIDocument[]> documentsByMessageId) {
			ChatMessage completionMessage = message.ToCompletionApiMessage();
			if (message == null ||
				!string.Equals(message.Role, CopilotMessageRole.User, StringComparison.OrdinalIgnoreCase) ||
				documentsByMessageId == null) {
				return completionMessage;
			}
			Guid? messageId = message.Id == Guid.Empty ? (Guid?)null : message.Id;
			if (!messageId.HasValue) {
				return completionMessage;
			}
			if (!documentsByMessageId.TryGetValue(messageId.Value, out ICreatioAIDocument[] messageDocuments) ||
				messageDocuments.Length == 0) {
				return completionMessage;
			}
			var multipartContents = CreateMultipartUserMessageContent(completionMessage);
			int existingImagesCount = multipartContents.Count(contentPart => string.Equals(contentPart?.Type,
				CompletionStatics.MessageContent.ImageUrl, StringComparison.OrdinalIgnoreCase));
			foreach (ICreatioAIDocument document in messageDocuments) {
				string dataUrl = TryBuildImageDataUrl(session, document);
				if (string.IsNullOrWhiteSpace(dataUrl)) {
					continue;
				}
				multipartContents.Add(new ChatMessageContentPart {
					Type = CompletionStatics.MessageContent.ImageUrl,
					ImageUrl = new ChatMessageImageUrl {
						Url = dataUrl,
						Detail = CompletionStatics.ImageDetail.High
					}
				});
			}
			if (multipartContents.Count == existingImagesCount) {
				return completionMessage;
			}
			completionMessage.Content = null;
			completionMessage.Contents = multipartContents;
			return completionMessage;
		}

		private void BindPendingImagesToUserMessage(CopilotSession session, CopilotMessage userMessage) {
			if (session?.Documents.IsNullOrEmpty() == true || userMessage?.Id == Guid.Empty) {
				return;
			}
			ICreatioAIDocument[] pendingImageDocuments = session.Documents
				.Where(document => document != null && !document.IntentId.HasValue &&
					!GetDocumentMessageId(document).HasValue && _imageValidator.IsSupportedImage(document.FileName))
				.GroupBy(GetDocumentKey).Select(group => group.First()).ToArray();
			if (pendingImageDocuments.Length == 0) {
				return;
			}
			foreach (CreatioAIDocument document in pendingImageDocuments.OfType<CreatioAIDocument>()) {
				document.MessageId = userMessage.Id;
			}
			Guid[] fileIds = pendingImageDocuments.Select(document => document.FileId).ToArray();
			new Update(_userConnection, "CreatioAISessionFile").Set("MessageId", Column.Parameter(userMessage.Id))
				.Where("Id").In(Column.Parameters(fileIds)).Execute();
		}

		#endregion

		#region Methods: Protected

		protected async Task<(DateTime? start, DateTime? end, ChatCompletionResponse response)>
			ProcessCompletionRequest(ChatCompletionRequest request, bool sync = true,
				CancellationToken token = default) {
			DateTime? start = DateTime.Now;
			ChatCompletionResponse response;
			if (sync) {
				response = _completionService.ChatCompletion(request);
			} else {
				response = await _completionService.ChatCompletionAsync(request, token).ConfigureAwait(false);
			}
			DateTime? end = DateTime.Now;
			return (start, end, response);
		}

		protected ChatCompletionRequest CreateCompletionRequest(CopilotSession session,
				CopilotToolContext copilotToolContext, CopilotContext copilotContext = null) {
			List<ChatMessage> messages = CreateCompletionMessages(session, copilotToolContext, copilotContext);
			var completionRequest = new ChatCompletionRequest {
				Messages = messages,
				Tools = copilotToolContext?.Tools ?? Array.Empty<ToolDefinition>(),
				Temperature = null,
				MaxOutputTokens = session.MaxOutputTokens
			};
			return ApplyLlmModelToRequest(completionRequest, session);
		}

		protected void BindPendingImagesToUserMessage(CopilotSession session, Guid userMessageId) {
			if (userMessageId == Guid.Empty) {
				return;
			}
			CopilotMessage userMessage = session?.Messages.LastOrDefault(message =>
				message.Id == userMessageId && string.Equals(message.Role, CopilotMessageRole.User,
					StringComparison.OrdinalIgnoreCase));
			if (userMessage == null) {
				return;
			}
			BindPendingImagesToUserMessage(session, userMessage);
		}

		protected List<ChatMessage> CreateCompletionMessagesWithBoundImages(IEnumerable<CopilotMessage> copilotMessages,
				CopilotSession session) {
			ICreatioAIDocument[] documents = session?.Documents?.ToArray() ?? Array.Empty<ICreatioAIDocument>();
			Dictionary<Guid, ICreatioAIDocument[]> documentsByMessageId = documents
				.Where(document => document != null && GetDocumentMessageId(document).HasValue)
				.GroupBy(document => GetDocumentMessageId(document).Value)
				.ToDictionary(group => group.Key, group => group.GroupBy(GetDocumentKey)
				.Select(itemGroup => itemGroup.First()).ToArray());
			return (copilotMessages ?? Enumerable.Empty<CopilotMessage>()).Select(message =>
				CreateCompletionApiMessage(message, session, documentsByMessageId)).ToList();
		}

		protected static List<CopilotMessage> GetAssistantMessagesWithoutToolCalls(
				ChatCompletionResponse completionResponse) {
			List<CopilotMessage> assistantMessages = GetResponsesWithMessage(completionResponse)
				.Select(response => new CopilotMessage(response.Message, skipToolCalls: true)).ToList();
			return assistantMessages;
		}

		protected static (string errorMessage, string errorCode) GetErrorInfo(Exception e) {
			if (e is GenAIException genAiException) {
				return (genAiException.RawError, genAiException.ErrorCode);
			}
			if (e is SecurityException) {
				return (e.Message, CopilotServiceErrorCode.InsufficientPermissions);
			}
			return (e.Message, CopilotServiceErrorCode.UnknownError);
		}

		protected Guid SaveRequestInfo(DateTime? start, DateTime? end, UsageResponse usage, string error,
				bool isFailed) {
			start = start ?? DateTime.Now;
			end = end ?? DateTime.Now;
			var duration = (long)(end - start).Value.TotalMilliseconds;
			var requestInfo = new CopilotRequestInfo {
				StartDate = start.Value,
				Error = error,
				TotalActions = usage?.TotalActions ?? 0,
				TotalTokens = usage?.TotalTokens ?? 0,
				PromptTokens = usage?.PromptTokens ?? 0,
				CompletionTokens = usage?.CompletionTokens,
				Duration = duration,
				IsFailed = isFailed
			};
			return _requestLogger.SaveCopilotRequest(requestInfo);
		}

		protected IEnumerable<CopilotIntentSchema> FilterSystemIntents(CopilotSession session,
				IEnumerable<CopilotIntentSchema> systemIntents) {
			IEnumerable<CopilotIntentSchema> intents = systemIntents ?? Enumerable.Empty<CopilotIntentSchema>();
			if (session?.FilterDescriptors == null || !session.FilterDescriptors.Any()) {
				return intents;
			}
			if (Features.GetIsDisabled("GenAIFeatures.EnableIntentFiltering")) {
				return intents;
			}
			IEnumerable<IAIToolFilter> filters = _toolFilterResolver?.Resolve(session.FilterDescriptors) ??
				Enumerable.Empty<IAIToolFilter>();
			return intents.Where(intent => {
				var context = new AIIntentFilterContext(intent);
				return filters.All(filter => filter?.ShouldIncludeIntent(context) != false);
			});
		}

		protected void AdjustSessionSystemIntentPromptUsingSystemIntents(CopilotSession copilotSession) {
			AdjustSessionSystemIntentPrompt(copilotSession,
				() => FilterSystemIntents(copilotSession, _intentsStorage.SystemIntents));
		}

		protected void AdjustSessionSystemIntentPrompt(CopilotSession copilotSession,
				Func<IEnumerable<CopilotIntentSchema>> getSystemIntents) {
			var intentId = copilotSession.RootIntentId;
			if (intentId.IsNullOrEmpty()) {
				return;
			}
			if (copilotSession.Messages.Any(copilotMessage => copilotMessage.IsFromSystemIntent)) {
				return;
			}
			string baseApplicationUrl = _hyperlinkUtils.GetBaseApplicationUrl();
			var parameters = new Dictionary<string, object> {
				{ "BaseAppUrl", baseApplicationUrl }
			};
			var systemIntents = getSystemIntents();
			if (Features.GetIsDisabled<Terrasoft.Configuration.GenAI.GenAIFeatures
					.SplitSystemIntentsIntoSeparateMessages>()) {
				var separator = Environment.NewLine + Environment.NewLine;
				var prompt = systemIntents.Select(intent =>
					_intentPromptBuilder.GenerateIntentPrompt(intent, parameters)).ConcatIfNotEmpty(separator);
				var message = CopilotMessage.FromSystem(prompt);
				message.IsFromSystemIntent = true;
				copilotSession.AddMessage(message);
				return;
			}
			foreach (var systemIntent in systemIntents) {
				var prompt = $"# {systemIntent.IntentDescription}" + Environment.NewLine +
					_intentPromptBuilder.GenerateIntentPrompt(systemIntent, parameters);
				var message = CopilotMessage.FromSystem(prompt);
				message.IsFromSystemIntent = true;
				copilotSession.AddMessage(message);
			}
		}

		protected void AddContextCompletionMessage(CopilotContext copilotContext, List<ChatMessage> messages) {
			if (copilotContext == null || copilotContext.Parts.Count == 0) {
				return;
			}
			string contextContent = _contextBuilder.BuildMessageContent(copilotContext);
			if (contextContent.IsNullOrEmpty()) {
				return;
			}
			var contextMessage = CopilotMessage.FromSystem(contextContent);
			var completionMessage = contextMessage.ToCompletionApiMessage();
			var lastUserMessageIndex = messages.FindLastIndex(m => m.Role == CopilotMessageRole.User);
			messages.Insert(lastUserMessageIndex == -1 ? 0 : lastUserMessageIndex, completionMessage);
		}

		protected CopilotIntentSchema GetCurrentIntent(CopilotSession session) {
			if (session.CurrentIntentId.IsNullOrEmpty()) {
				return null;
			}
			return _intentsStorage.FindSchemaByUId(session.CurrentIntentId.Value);
		}

		protected abstract List<ChatMessage> CreateCompletionMessages(CopilotSession session,
			CopilotToolContext copilotToolContext, CopilotContext copilotContext);

		#endregion

	}
}

