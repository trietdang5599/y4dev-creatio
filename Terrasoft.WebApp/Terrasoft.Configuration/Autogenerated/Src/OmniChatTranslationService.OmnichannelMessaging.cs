namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using global::Common.Logging;
	using Terrasoft.Configuration.Omnichannel.Translating;
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Configuration.Translating;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	#region Class: OmniChatTranslationService

	/// <summary>
	/// Provides a service for translating omnichannel chats. 
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class OmniChatTranslationService : BaseService
	{

		#region Fields: Private

		private readonly OmnichannelChatProvider _chatProvider;
		private readonly TranslateProviderFactory _translateFactory;
		private readonly ITranslatedChatCache _translatedChatCache;

		#endregion

		#region Properties: Private

		private ILog _log;
		protected ILog Log {
			get	{
				return _log ?? (_log = LogManager.GetLogger("TranslationService"));
			}
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="OmniChatTranslationService"/> class.
		/// Resolves chat provider and translation provider factory using the current <see cref="UserConnection"/>.
		/// Uses distributed cache for storing large translation data.
		/// </summary>
		public OmniChatTranslationService() {
			_chatProvider = ClassFactory.Get<OmnichannelChatProvider>(
					new ConstructorArgument("userConnection", UserConnection));
			_translateFactory = new TranslateProviderFactory(UserConnection);
			_translatedChatCache = new TranslatedChatCache();
		}

		#endregion

		#region Methods: Private

		private string GetUserLanguageCode() {
			LanguageRegistry.TryGetShortByCultureId(UserConnection.CurrentUser.SysCultureId, out string shortCode);
			return shortCode;
		}

		private void UpdateChatTranslationSettings(Guid chatId, bool NeedsTranslation, Guid languageId, Guid targetLangId) {
			new Update(UserConnection, "OmniChat")
				.Set("NeedsTranslation", Column.Parameter(NeedsTranslation))
				.Set("LanguageId", Column.Parameter(languageId))
				.Set("TranslatedLangId", Column.Parameter(targetLangId))
				.Where("Id").IsEqual(Column.Parameter(chatId))
				.Execute();
		}
		private void CheckChatEditRights(Guid chatId) {
			var rightsHelper = new RightsHelper(UserConnection);
			if (!rightsHelper.GetCanEditSchemaRecordRight("OmniChat", chatId)) {
				throw new WebFaultException<string>("You do not have rights to access this chat.", System.Net.HttpStatusCode.Forbidden);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Translates all messages of the specified chat from the source language to the target language.
		/// </summary>
		/// <param name="chatId">The identifier of the chat whose messages should be translated.</param>
		/// <param name="targetLanguage">
		/// Target language code. Accepts values like "en" or "en-US". The value is normalized to the short form ("en").
		/// </param>
		/// <param name="sourceLanguage">
		/// Source language code. Accepts values like "uk" or "uk-UA". The value is normalized to the short form ("uk").
		/// </param>
		/// <returns>
		/// The original collection of <see cref="ChatMessage"/> with the <c>Text</c> fields replaced by their translations.
		/// </returns>
		/// <remarks>
		/// Assumes that <c>provider.TranslateMultiple</c> returns a non-null sequence with the same number of items
		/// and in the same order as the input collection. If the provider is not available, there are no messages,
		/// or languages match after normalization, the method returns messages unchanged.
		/// Results are cached using distributed caching with a key format of chatId_targetLanguage for improved performance with large datasets.
		/// </remarks>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		ResponseFormat = WebMessageFormat.Json)]
		public IEnumerable<ChatMessage> TranslateChat(Guid chatId, string targetLanguage, string sourceLanguage) {
			CheckChatEditRights(chatId);
			var messages = _chatProvider.GetChatMessages(chatId)?.ToList() ?? new List<ChatMessage>();
			var cachedTranslation = _translatedChatCache.GetTranslatedChat(chatId, targetLanguage);
			if (cachedTranslation != null) {
				Log.Debug($"Returning cached translation for chatId={chatId}, targetLanguage={targetLanguage}");
				return ChatMessageTranslationMapper.ApplyTranslations(messages, cachedTranslation);
			}
			var provider = _translateFactory.Get();
			if (provider == null || messages.Count == 0) {
				return messages;
			}		
			LanguageRegistry.TryGetIdByCode(sourceLanguage, out Guid langId);
			targetLanguage = string.IsNullOrEmpty(targetLanguage) ? GetUserLanguageCode() : LanguageRegistry.NormalizeLanguageCode(targetLanguage);
			sourceLanguage = LanguageRegistry.NormalizeLanguageCode(sourceLanguage);	
			if (string.Equals(targetLanguage, sourceLanguage, StringComparison.OrdinalIgnoreCase)) {
				return messages;
			}
			var incomingMessages = messages.Where(m => m?.Direction == OmnichannelProviders.Domain.Entities.MessageDirection.Incoming && !string.IsNullOrEmpty(m.Text)).ToList();
			var contents = incomingMessages.Select(m => m.Text).ToList();
			var translated = provider.TranslateMultiple(contents, targetLanguage, sourceLanguage).ToList();	
			Log.Debug($"Translating chat with chatId={chatId} from {sourceLanguage} to {targetLanguage}, messageCount={incomingMessages.Count}");	
			for (int i = 0; i < incomingMessages.Count; i++) {
				incomingMessages[i].OriginalText = incomingMessages[i].Text;
				incomingMessages[i].Text = translated[i];
			}
			LanguageRegistry.TryGetIdByCode(targetLanguage, out Guid targetLangId);
			UpdateChatTranslationSettings(chatId, true, langId, targetLangId);
			_translatedChatCache.SetTranslatedChat(chatId, targetLanguage, messages);
			return messages;
		}

		#endregion

	}

	#endregion

}
