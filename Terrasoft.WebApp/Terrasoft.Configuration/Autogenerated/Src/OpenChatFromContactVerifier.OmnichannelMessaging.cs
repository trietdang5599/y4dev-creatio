namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelMessaging;
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.ServiceModelContract;

	#region Class: OpenChatFromContactVerifier
	/// <summary>
	/// Contact data verifier for chat opening.
	/// </summary>
	public class OpenChatFromContactVerifier
	{

		#region Fields: Private	

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public OpenChatFromContactVerifier(UserConnection userConnection) {
			MessengerAllowedDelays = new Dictionary<Guid, int>();
			MessengerAllowedDelays.Add(OmnichannelMessagingConsts.FacebookProvider, 24);
			MessengerAllowedDelays.Add(OmnichannelMessagingConsts.WhatsappProvider, 24);
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// <see cref="ILog"/> implementation instance.
		/// </summary>
		private ILog _detailsLogger;
		private ILog DetailsLogger => _detailsLogger ?? (_detailsLogger = LogManager.GetLogger("OmnichannelDetails"));

		#endregion

		#region Properties: Protected

		private MessageManager _messageManager;
		/// <summary>
		/// Class which save and send messages <see cref="MessageManager"/> class.
		/// </summary>
		protected MessageManager MessageManager {
			get {
				return _messageManager = _messageManager ?? new MessageManager(_userConnection);
			}
		}

		#endregion

		#region Properties: Public

		public Dictionary<Guid, int> MessengerAllowedDelays { get; set; }

		#endregion

		#region Methods: Private

		private (Guid ChatId, Guid ChannelId, Guid ChatStatusId, Guid ChatOperatorId) ExecuteLastChatSelect(Select omnichatSelect) {
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = omnichatSelect.ExecuteReader(dbExecutor)) {
					if (dataReader.Read()) {
						return (dataReader.GetColumnValue<Guid>("ChatId"), dataReader.GetColumnValue<Guid>("ChannelId"),
							dataReader.GetColumnValue<Guid>("ChatStatusId"), dataReader.GetColumnValue<Guid>("ChatOperator"));
					}
				}
			}
			return default;
		}

		private Select BuildLastChatSelectBase(Guid contactId) {
			return new Select(_userConnection).Top(1)
				.Column("OC", "Id").As("ChatId")
				.Column("C", "Id").As("ChannelId")
				.Column("OC", "StatusId").As("ChatStatusId")
				.Column("OC", "OperatorId").As("ChatOperator")
				.Column("OC", "CreatedOn").As("CreatedOn")
				.From("OmniChat").As("OC")
				.InnerJoin("Channel").As("C").On("C", "Id").IsEqual("OC", "ChannelId")
				.Where("OC", "ContactId").IsEqual(Column.Parameter(contactId))
				.And("C", "IsActive").IsEqual(Column.Parameter(true))
				.OrderBy(OrderDirectionStrict.Descending, "CreatedOn") as Select;
		}

		private (Guid ChatId, Guid ChannelId, Guid ChatStatusId, Guid ChatOperatorId) GetLastChatIdByProvider(Guid contactId, Guid providerId) {
			var omnichatSelect = BuildLastChatSelectBase(contactId)
				.InnerJoin("ChannelProvider").As("CP").On("C", "ProviderId").IsEqual(Column.Parameter(providerId)) as Select;
			return ExecuteLastChatSelect(omnichatSelect);
		}

		private (Guid ChatId, Guid ChannelId, Guid ChatStatusId, Guid ChatOperatorId) GetLastChatIdByChannel(Guid contactId, Guid channelId) {
			var omnichatSelect = BuildLastChatSelectBase(contactId)
				.And("C", "Id").IsEqual(Column.Parameter(channelId)) as Select;
			return ExecuteLastChatSelect(omnichatSelect);
		}

		private List<string> GetChannelIdentities(Guid contactId, Guid channelId) {
			List<string> channelIdentities = new List<string>();
			var identitiesSelect = new Select(_userConnection)
				.Column("ChannelIdentity")
				.Column("AlternateChannelIdentity")
				.From("ContactIdentity")
				.Where("ContactId").IsEqual(Column.Parameter(contactId))
				.And("ChannelId")
				.IsEqual(Column.Parameter(channelId)) as Select;
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = identitiesSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						string channelIdentity = reader.GetColumnValue<string>("ChannelIdentity");
						if (channelIdentity.IsNotNullOrEmpty()) {
							channelIdentities.Add(channelIdentity);
						}
						string alternateChannelIdentity = reader.GetColumnValue<string>("AlternateChannelIdentity");
						if (alternateChannelIdentity.IsNotNullOrEmpty()) {
							channelIdentities.Add(alternateChannelIdentity);
						}
					}
				}
			}
			return channelIdentities.Distinct().ToList();
		}

		private long TryGetLastIncomingMessageTimestamp(List<string> channelIdentities) {
			long lastMessageTimestamp = 0;
			if (!channelIdentities.IsEmpty()) {
				for (int i = 0; i < channelIdentities.Count && lastMessageTimestamp == 0; i++) {
					DetailsLogger.Info($"Trying to find last incoming message by channel identity {channelIdentities[i]}");
					lastMessageTimestamp = MessageManager.GetLastSenderMessageTimestamp(channelIdentities[i]);
				}
			}
			return lastMessageTimestamp;
		}

		private long GetLastMessageTimestamp(Guid contactId, Guid channelId) {
			var channelIdentities = GetChannelIdentities(contactId, channelId);
			var lastIncomingMessage = MessageManager.GetMessagesBySender(channelIdentities, channelId, 20, 0)
				.Where(m => m.MessageDirection == OmnichannelProviders.Domain.Entities.MessageDirection.Incoming)
				.OrderByDescending(m => m.Timestamp).FirstOrDefault();
			if (lastIncomingMessage == null) {
				DetailsLogger.Info($"Last incoming message not found for contact id {contactId} and channel id {channelId}");
			}
			return lastIncomingMessage?.Timestamp ?? TryGetLastIncomingMessageTimestamp(channelIdentities);
		}

		private GetLastChatResponse SetError(string errorMessage, string errorCode = null) {
			return new GetLastChatResponse() {
				Success = false,
				ErrorInfo = new ErrorInfo() {
					Message = errorMessage,
					ErrorCode = errorCode
				}
			};
		}

		private bool CheckChatStatusSettings(Guid chatStatusId, Guid chatOperatorId) {
			return chatStatusId == OmnichannelMessagingConsts.CompletedChatStatus ||
				chatStatusId == OmnichannelMessagingConsts.CompletedByBotChatStatus ||
				chatStatusId == OmnichannelMessagingConsts.HandedOverToAgent ||
				chatOperatorId == _userConnection.CurrentUser.Id;
		}

		private bool IsNeedToCheckLastMessageTime(Guid providerId, out int allowedDelay) {
			return MessengerAllowedDelays.TryGetValue(providerId, out allowedDelay);
		}

		private bool CheckAllowedDelay(long lastMessageTimestamp, int allowedDelay) {
			return lastMessageTimestamp < new DateTimeOffset(DateTime.UtcNow.AddHours(-allowedDelay)).ToUnixTimeMilliseconds();
		}

		private GetLastChatResponse CheckReasonAndFindErrorByProvider(Guid providerId) {
			EntitySchemaQuery esq = GetChannelQueryByProvider(providerId);
			var channelCollection = esq.GetEntityCollection(_userConnection);
			return CheckReasonAndFindError(channelCollection);
		}

		private GetLastChatResponse CheckReasonAndFindErrorByChannel(Guid channelId) {
			EntitySchemaQuery esq = GetChannelQueryByChannel(channelId);
			var channelCollection = esq.GetEntityCollection(_userConnection);
			return CheckReasonAndFindError(channelCollection);
		}

		private string GetLocalizableMessage(string localizableStringName) {
			return new LocalizableString(_userConnection.Workspace.ResourceStorage, "OpenChatFromContactVerifier",
				$"LocalizableStrings.{localizableStringName}.Value").ToString();
		}

		private GetLastChatResponse CheckReasonAndFindError(EntityCollection channelCollection) {
			if (channelCollection.IsEmpty()) {
				return SetError(GetLocalizableMessage("ChannelNotExist"));
			}
			if (channelCollection.Where(item => item.GetTypedColumnValue<bool>("IsActive")).IsEmpty()) {
				return SetError(GetLocalizableMessage("ChannelIsNotActive"));
			}
			return SetError(GetLocalizableMessage("ChannelIdentityNoExist"));
		}

		private EntitySchemaQuery GetChannelQueryByProvider(Guid providerId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Channel") {
				UseAdminRights = false
			};
			esq.AddColumn("IsActive");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Provider", providerId));
			return esq;
		}

		private EntitySchemaQuery GetChannelQueryByChannel(Guid channelId) {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Channel") {
				UseAdminRights = false
			};
			esq.AddColumn("IsActive");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Id", channelId));
			return esq;
		}

		private Guid GetChannelProviderId(Guid channelId) {
			return (new Select(_userConnection).Top(1)
				.Column("ProviderId")
				.From("Channel")
				.Where("Id").IsEqual(Column.Parameter(channelId)) as Select).ExecuteScalar<Guid>();
		}

		private GetLastChatResponse CheckContactDataAndGetChatIdInternal(Guid contactId, Guid providerId,
				(Guid ChatId, Guid ChannelId, Guid ChatStatusId, Guid ChatOperatorId) chat,
				Func<GetLastChatResponse> getNoChatResponse) {
			if (chat.ChatId == default) {
				return getNoChatResponse();
			}
			if (!CheckChatStatusSettings(chat.ChatStatusId, chat.ChatOperatorId)) {
				return SetError(new LocalizableString(_userConnection.Workspace.ResourceStorage,
					"OpenChatFromContactVerifier", "LocalizableStrings.ActiveChatExists.Value").ToString(), "ActiveChatExists");
			}
			var lastMessageTimestamp = GetLastMessageTimestamp(contactId, chat.ChannelId);
			if (lastMessageTimestamp == default) {
				return SetError(new LocalizableString(_userConnection.Workspace.ResourceStorage,
					"OpenChatFromContactVerifier", "LocalizableStrings.NoConversation.Value").ToString(), "NoConversation");
			}
			if (IsNeedToCheckLastMessageTime(providerId, out int allowedDelay)
					&& CheckAllowedDelay(lastMessageTimestamp, allowedDelay)) {
				return SetError(new LocalizableString(_userConnection.Workspace.ResourceStorage,
					"OpenChatFromContactVerifier", "LocalizableStrings.AllowedPeriodExpired.Value").ToString(), "AllowedPeriodExpired");
			}
			return new GetLastChatResponse() {
				LastChatId = chat.ChatId,
				IsLastChatCompleted = chat.ChatStatusId == OmnichannelMessagingConsts.CompletedChatStatus ||
					chat.ChatStatusId == OmnichannelMessagingConsts.CompletedByBotChatStatus ||
					chat.ChatStatusId == OmnichannelMessagingConsts.HandedOverToAgent,
				LastChatOperatorId = chat.ChatOperatorId,
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns last chat identifier.
		/// </summary>
		/// <param name="contactId">Identifier of contact.</param>
		/// <param name="providerId">Identifier of provider.</param>
		/// <returns>Last chat identifier</returns>
		public GetLastChatResponse CheckContactDataAndGetChatId(Guid contactId, Guid providerId) {
			var chat = GetLastChatIdByProvider(contactId, providerId);
			return CheckContactDataAndGetChatIdInternal(contactId, providerId, chat,
				() => CheckReasonAndFindErrorByProvider(providerId));
		}

		/// <summary>
		/// Returns last chat identifier.
		/// </summary>
		/// <param name="contactId">Identifier of contact.</param>
		/// <param name="channelId">Identifier of channel.</param>
		/// <returns>Last chat identifier</returns>
		public GetLastChatResponse CheckContactDataAndGetChatIdByChannel(Guid contactId, Guid channelId) {
			var chat = GetLastChatIdByChannel(contactId, channelId);
			var providerId = GetChannelProviderId(channelId);
			return CheckContactDataAndGetChatIdInternal(contactId, providerId, chat,
				() => CheckReasonAndFindErrorByChannel(channelId));
		}

		#endregion

	}

	#endregion

}

