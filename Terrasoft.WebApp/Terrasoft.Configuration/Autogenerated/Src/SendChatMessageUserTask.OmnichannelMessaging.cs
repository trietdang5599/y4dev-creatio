namespace Terrasoft.Core.Process.Configuration
{
	using global::Common.Logging;
	using OmnichannelMessaging;
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;
	using ChannelType = OmnichannelProviders.Domain.Entities.ChannelType;
	using MessageDirection = OmnichannelProviders.Domain.Entities.MessageDirection;
	using OmnichannelProviders.Domain.Entities;

	#region Enum: ChatMessageType

	/// <summary>
	/// Defines the type of chat message to send.
	/// </summary>
	public enum ChatMessageType
	{
		/// <summary>
		/// Message from template.
		/// </summary>
		Template = 0,

		/// <summary>
		/// Custom message.
		/// </summary>
		Custom = 1
	}

	#endregion

	#region Enum: ChatMessageSendStatus

	/// <summary>
	/// Defines the status of a chat message send operation.
	/// </summary>
	public enum ChatMessageSendStatus
	{
		/// <summary>
		/// Message was sent successfully.
		/// </summary>
		Sent,

		/// <summary>
		/// An error occurred while sending the message.
		/// </summary>
		Error
	}

	#endregion

	#region Class: ChatMessageSendResult

	/// <summary>
	/// Represents the result of a chat message send operation.
	/// </summary>
	public class ChatMessageSendResult
	{
		/// <summary>
		/// Gets or sets the send status.
		/// </summary>
		public ChatMessageSendStatus Status { get; set; }

		/// <summary>
		/// Gets or sets the status details (error code and description when applicable).
		/// </summary>
		public string StatusDetails { get; set; }

		/// <summary>
		/// Creates a successful result.
		/// </summary>
		public static ChatMessageSendResult Success() {
			return new ChatMessageSendResult {
				Status = ChatMessageSendStatus.Sent,
				StatusDetails = string.Empty
			};
		}

		/// <summary>
		/// Creates an error result from an exception.
		/// </summary>
		/// <param name="ex">The exception that caused the error.</param>
		public static ChatMessageSendResult FromError(Exception ex) {
			return new ChatMessageSendResult {
				Status = ChatMessageSendStatus.Error,
				StatusDetails = ex.Message
			};
		}
	}

	#endregion

	#region Class: ChatMessageSendHelper

	/// <summary>
	/// Helper class that encapsulates chat message sending logic.
	/// </summary>
	public class ChatMessageSendHelper
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly ILog _logger;
		private readonly MessageManager _messageManager;

		#endregion

		#region Constructors: Public

		public ChatMessageSendHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_logger = LogManager.GetLogger("OmnichannelSendMessageUserTask");
			_messageManager = new MessageManager(userConnection);
		}

		#endregion

		#region Methods: Private

		private string GetMessageText(Guid chatId, ChatMessageType messageType, string message, Guid templateId) {
			if (messageType == ChatMessageType.Custom) {
				return message;
			}
			if (messageType == ChatMessageType.Template) {
				return GetMessageFromTemplate(chatId, templateId);
			}
			throw new InvalidOperationException($"Unsupported MessageType: {messageType}");
		}

		private string GetMessageFromTemplate(Guid chatId, Guid templateId) {
			if (chatId == Guid.Empty) {
				throw new ArgumentException("ChatId cannot be empty when processing template", nameof(chatId));
			}
			if (templateId == Guid.Empty) {
				throw new ArgumentException("TemplateId cannot be empty", nameof(templateId));
			}
			try {
				var macrosHelper = new Terrasoft.Configuration.GlobalMacrosHelper();
				macrosHelper.UserConnection = _userConnection;
				var macrosHelperService = new Terrasoft.Configuration.MacrosHelperService(
					macrosHelper, _userConnection);
				var request = new Terrasoft.Configuration.MacrosHelperServiceRequest {
					EntityId = chatId,
					EntityName = "OmniChat",
					TemplateId = templateId
				};
				var response = macrosHelperService.GetMultiLanguageTextTemplate(request);
				if (!response.Success) {
					throw new InvalidOperationException(
						$"Failed to process template {templateId} for chat {chatId}");
				}
				if (string.IsNullOrWhiteSpace(response.TextTemplate)) {
					throw new InvalidOperationException(
						$"Template {templateId} returned empty text for chat {chatId}");
				}
				return response.TextTemplate;
			} catch (Exception ex) {
				_logger.Error($"Error getting message from template {templateId} for chat {chatId}", ex);
				throw;
			}
		}

		private Entity CreateNewChat(Guid contactId, Entity channel, string chatPreview = null) {
			EntitySchema chatSchema = _userConnection.EntitySchemaManager.GetInstanceByName("OmniChat");
			Entity chat = chatSchema.CreateEntity(_userConnection);
			Guid newChatId = Guid.NewGuid();
			Guid channelId = channel.GetTypedColumnValue<Guid>("Id");
			chat.SetDefColumnValues();
			chat.SetColumnValue("Id", newChatId);
			chat.SetColumnValue("ContactId", contactId);
			chat.SetColumnValue("ChannelId", channelId);
			chat.SetColumnValue("StatusId", OmnichannelMessagingConsts.CompletedChatStatus);
			chat.SetColumnValue("OperatorId", _userConnection.CurrentUser.Id);
			chat.SetColumnValue("UnprocessedMsgCount", 0);
			Guid queueId = channel.GetTypedColumnValue<Guid>("ChatQueue_Id");
			if (queueId != Guid.Empty) {
				chat.SetColumnValue("QueueId", queueId);
			}
			if (!string.IsNullOrEmpty(chatPreview)) {
				chat.SetColumnValue("ChatPreview", chatPreview);
			}
			chat.Save(false);
			_logger.Info($"Created new chat with Id={newChatId} in closed state for contact {contactId} and channel {channelId}");
			return chat;
		}

		private void UpdateChatPreview(Entity chat, string messageText) {
			chat.SetColumnValue("ChatPreview", messageText);
			chat.Save(false);
			_logger.Info($"Updated ChatPreview for chat {chat.GetTypedColumnValue<Guid>("Id")}");
		}

		private Entity GetChannel(Guid channelId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Channel");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("Source");
			esq.AddColumn("ChatQueue.Id");
			esq.AddColumn("IsActive");
			esq.AddColumn("Provider.Code");
			esq.AddColumn("Provider.Id");
			Entity channel = esq.GetEntity(_userConnection, channelId);
			if (channel == null) {
				throw new InvalidOperationException($"Channel with Id={channelId} not found.");
			}
			if (!channel.GetTypedColumnValue<bool>("IsActive")) {
				throw new InvalidOperationException($"Channel with Id={channelId} is not active.");
			}
			return channel;
		}

		/// <summary>
		/// Validates pre-send conditions using <see cref="OpenChatFromContactVerifier"/>.
		/// Checks channel existence, channel active status, contact identity,
		/// messaging window (24-hour limit for Facebook/WhatsApp), and conversation history.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <param name="providerId">Channel provider identifier.</param>
		private void ValidatePreSendConditions(Guid contactId, Guid providerId) {
			var verifier = new OpenChatFromContactVerifier(_userConnection);
			var response = verifier.CheckContactDataAndGetChatId(contactId, providerId);
			if (!response.Success) {
				string errorMessage = response.ErrorInfo?.Message ?? "Pre-send validation failed.";
				throw new InvalidOperationException(errorMessage);
			}
		}

		private MessagingMessage GetMessage(Guid chatId, Entity channel, Guid contactId, string message) {
			Guid channelId = channel.GetTypedColumnValue<Guid>("Id");
			string source = channel.GetTypedColumnValue<string>("Source");
			int providerCode = channel.GetTypedColumnValue<int>("Provider_Code");
			ChannelType channelType = GetChannelTypeByProviderCode(providerCode);
			if (channelType == ChannelType.WhatsApp) {
				source = $"whatsapp:{source}";
			}
			string recipient = GetRecipientFromContactIdentity(contactId, channelId, channelType);
			if (string.IsNullOrEmpty(recipient)) {
				throw new InvalidOperationException(
					$"Failed to get recipient for contact {contactId} and channel {channelId}. " +
					"ContactIdentity record may not exist.");
			}
			var messagingMessage = new MessagingMessage {
				Id = Guid.NewGuid(),
				ChatId = chatId.ToString(),
				ContactId = contactId,
				ChannelId = channelId.ToString(),
				Message = message,
				Recipient = recipient,
				Sender = source,
				Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
				MessageDirection = MessageDirection.Outcoming,
				Source = channelType,
				MessageType = OmnichannelProviders.Domain.Entities.MessageType.Text,
				Status = MessageDeliveryStatus.Sent
			};
			return messagingMessage;
		}

		private string GetRecipientFromContactIdentity(Guid contactId, Guid channelId, ChannelType channelType) {
			string recipient = FindRecipientFromDb(contactId, channelId);
			if (!string.IsNullOrEmpty(recipient)) {
				return recipient;
			}
			recipient = GenerateRecipientIdentity(contactId, channelId, channelType);
			if (!string.IsNullOrEmpty(recipient)) {
				return recipient;
			}
			_logger.Info($"No ChannelIdentity found for ContactId={contactId} and ChannelId={channelId}");
			return recipient;
		}

		private string FindRecipientFromDb(Guid contactId, Guid channelId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "ContactIdentity");
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			var alternateChannelIdentityColumn = esq.AddColumn("AlternateChannelIdentity");
			var channelIdentityColumn = esq.AddColumn("ChannelIdentity");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Contact", contactId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Channel", channelId));
			var collection = esq.GetEntityCollection(_userConnection);
			if (collection.Count > 0) {
				string channelIdentity = collection[0].GetTypedColumnValue<string>(channelIdentityColumn.Name);
				if (!string.IsNullOrEmpty(channelIdentity)) {
					return channelIdentity;
				}
				return collection[0].GetTypedColumnValue<string>(alternateChannelIdentityColumn.Name);
			}
			return null;
		}

		private string GenerateRecipientIdentity(Guid contactId, Guid channelId, ChannelType channelType) {
			try {
				IGenerateContactIdentity generator = ClassFactory.Get<IGenerateContactIdentity>(
					channelType.ToString(),
					new ConstructorArgument("userConnection", _userConnection));
				if (generator != null) {
					string channelIdentity;
					if (generator.TryGetOrCreateIdentity(channelId, contactId, out channelIdentity)) {
						_logger.Info($"ContactIdentity retrieved using generator for ContactId={contactId}, ChannelId={channelId}, Type={channelType}");
						return channelIdentity;
					}
					_logger.Warn($"Generator failed to get/create identity for ContactId={contactId}, ChannelId={channelId}, Type={channelType}");
				}
			} catch (Exception ex) {
				_logger.Debug($"No IGenerateContactIdentity implementation for Type={channelType}: {ex.Message}");
			}
			return null;
		}

		private ChannelType GetChannelTypeByProviderCode(int providerCode) {
			if (Enum.IsDefined(typeof(ChannelType), providerCode)) {
				return (ChannelType)providerCode;
			}
			_logger.Warn($"Unknown provider code: {providerCode}. Returning default channel type.");
			return default(ChannelType);
		}

		/// <summary>
		/// Applies additional column values to an existing chat entity and saves the changes.
		/// Used to populate link columns (e.g. CaseId, AccountId) before template macro resolution.
		/// </summary>
		/// <param name="chat">The chat entity to update.</param>
		/// <param name="columnValues">Dictionary of column meta-path → resolved value pairs.</param>
		private void ApplyChatColumnValues(Entity chat, IDictionary<string, object> columnValues) {
			EntitySchema chatSchema = chat.Schema;
			foreach (KeyValuePair<string, object> columnItem in columnValues) {
				EntitySchemaColumn column = chatSchema.GetSchemaColumnByMetaPath(columnItem.Key);
				if (column == null) {
					_logger.Warn($"Column with meta path '{columnItem.Key}' not found in OmniChat schema. Skipping.");
					continue;
				}
				chat.SetColumnValue(column, columnItem.Value);
			}
			chat.Save(false);
			_logger.Info($"Applied {columnValues.Count} column value mapping(s) to chat {chat.GetTypedColumnValue<Guid>("Id")}");
		}

		private string ConvertHtmlToPlain(string message) {
			if (string.IsNullOrEmpty(message)) {
				return message;
			}
			return StringUtilities.ConvertHtmlToPlainText(message).Replace(' ', ' ');
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates a new chat, resolves the message text, sends the message, and updates the chat preview.
		/// </summary>
		/// <param name="contactId">Contact identifier.</param>
		/// <param name="channelId">Channel identifier.</param>
		/// <param name="messageType">Message type (Template or Custom).</param>
		/// <param name="messageText">Custom message text (used when <paramref name="messageType"/> is Custom).</param>
		/// <param name="templateId">Template identifier (used when <paramref name="messageType"/> is Template).</param>
		/// <param name="columnValues">Optional dictionary of extra OmniChat column values to set before macro resolution.</param>
		/// <returns>A <see cref="ChatMessageSendResult"/> containing the send status and details.</returns>
		public ChatMessageSendResult SendMessage(Guid contactId, Guid channelId, ChatMessageType messageType,
				string messageText, Guid templateId,
				IDictionary<string, object> columnValues = null) {
			try {
				_logger.Info($"Validating and creating a new chat for contact {contactId} and channel {channelId}.");
				Entity channel = GetChannel(channelId);
				Guid providerId = channel.GetTypedColumnValue<Guid>("Provider_Id");
				ValidatePreSendConditions(contactId, providerId);
				string customPreview = messageType == ChatMessageType.Custom ? messageText : null;
				Entity chat = CreateNewChat(contactId, channel, customPreview);
				if (columnValues != null && columnValues.Count > 0) {
					ApplyChatColumnValues(chat, columnValues);
				}
				Guid chatId = chat.GetTypedColumnValue<Guid>("Id");
				string resolvedText = GetMessageText(chatId, messageType, messageText, templateId);
				resolvedText = ConvertHtmlToPlain(resolvedText);
				MessagingMessage message = GetMessage(chatId, channel, contactId, resolvedText);
				string result = _messageManager.Send(message, message.ChannelName);
				if (messageType == ChatMessageType.Template) {
					UpdateChatPreview(chat, resolvedText);
				}
				if (!string.IsNullOrEmpty(result) && result.Contains("error")) {
					_logger.Error($"Failed to send message: {result}");
					return new ChatMessageSendResult {
						Status = ChatMessageSendStatus.Error,
						StatusDetails = result
					};
				}
				return ChatMessageSendResult.Success();
			} catch (Exception ex) {
				_logger.Error($"Error sending chat message for contact {contactId} " +
					$"and channel {channelId}", ex);
				return ChatMessageSendResult.FromError(ex);
			}
		}

		#endregion

	}

	#endregion

	#region Class: SendChatMessageUserTask

	/// <summary>
	/// User task for sending chat messages from business processes.
	/// </summary>
	public partial class SendChatMessageUserTask : ProcessUserTask
	{

		#region Methods: Private

		private void ValidateInputParameters() {
			if (Channel == Guid.Empty) {
				throw new ArgumentException("Channel parameter is required.");
			}
			if (Contact == Guid.Empty) {
				throw new ArgumentException("Contact parameter is required.");
			}
			if (!Enum.IsDefined(typeof(ChatMessageType), MessageType)) {
				throw new ArgumentException($"Invalid MessageType value: {MessageType}. Valid values are 0 (Template) or 1 (Custom).");
			}
			var msgType = (ChatMessageType)MessageType;
			if (msgType == ChatMessageType.Custom && string.IsNullOrWhiteSpace(Message)) {
				throw new ArgumentException("Message parameter is required for Custom message type.");
			}
			if (msgType == ChatMessageType.Template && Template == Guid.Empty) {
				throw new ArgumentException("Template parameter is required for Template message type.");
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes the user task.
		/// </summary>
		/// <param name="context">Process executing context.</param>
		/// <returns>True if execution was successful.</returns>
		protected override bool InternalExecute(ProcessExecutingContext context) {
			var logger = LogManager.GetLogger("OmnichannelSendMessageUserTask");
			try {
				ValidateInputParameters();
				var helper = new ChatMessageSendHelper(UserConnection);
				IDictionary<string, object> columnValues = RecordColumnValues?.Values;
				ChatMessageSendResult result = helper.SendMessage(
					Contact, Channel, (ChatMessageType)MessageType, Message, Template, columnValues);
				SendStatus = result.Status.ToString();
				SendStatusDetails = result.StatusDetails ?? string.Empty;
				if (result.Status == ChatMessageSendStatus.Error) {
					logger.Error($"SendChatMessageUserTask completed with error: {result.StatusDetails}");
					if (!IgnoreErrors) {
						throw new InvalidOperationException(result.StatusDetails);
					}
				}
				return true;
			} catch (Exception ex) {
				logger.Error($"SendChatMessageUserTask execution failed: {ex.Message}", ex);
				SendStatus = ChatMessageSendStatus.Error.ToString();
				SendStatusDetails = ex.Message;
				if (!IgnoreErrors) {
					throw;
				}
				return true;
			}
		}

		#endregion

	}

	#endregion

}
