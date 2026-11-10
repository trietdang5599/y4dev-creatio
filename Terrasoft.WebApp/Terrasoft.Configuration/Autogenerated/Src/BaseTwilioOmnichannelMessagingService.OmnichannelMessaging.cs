namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelMessaging.Domain.Entities;
	using OmnichannelMessaging.WhatsApp;
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using Terrasoft.Common;
	using Terrasoft.Core.ServiceModelContract;
	using Terrasoft.Web.Common;

	#region Class: BaseTwilioRegistrationRequest

	[DataContract]
	public class BaseTwilioRegistrationRequest
	{
		#region Properties: Public

		[DataMember(Name = "token")]
		public string Token {
			get; set;
		}

		[DataMember(Name = "appId")]
		public string AppId {
			get; set;
		}

		[DataMember(Name = "integrationPhoneNumber")]
		public string IntegrationPhoneNumber {
			get; set;
		}

		[DataMember(Name = "channelPhoneNumber")]
		public string ChannelPhoneNumber {
			get; set;
		}

		#endregion
	}

	#endregion

	#region Class: BaseTwilioRegistrationResponse

	[DataContract]
	public class BaseTwilioRegistrationResponse : ConfigurationServiceResponse
	{
		#region Properties: Public

		/// <summary>
		/// Identifier of settings repository
		/// </summary>
		[DataMember]
		public string SettingsId {
			get; set;
		}

		/// <summary>
		/// Is channel valid.
		/// </summary>
		[DataMember]
		public bool IsConnectionSuccess {
			get; set;
		}

		#endregion
	}

	#endregion

	#region Class: BaseTwilioOmnichannelMessagingService

	/// <summary>
	/// Base service for Twilio-based messaging channels (WhatsApp, SMS).
	/// </summary>
	public abstract class BaseTwilioOmnichannelMessagingService<TRequest, TResponse> : OmnichannelMessagingService
		where TRequest : BaseTwilioRegistrationRequest
		where TResponse : BaseTwilioRegistrationResponse, new()
	{

		#region Properties: Protected

		protected override string MessageReceiverUrl {
			get {
				return "/ServiceModel/WhatsAppOmnichannelMessagingService.svc/receive/";
			}
		}

		protected override string MessageRouterUrl {
			get {
				return "/api/whatsapp/messenger/";
			}
		}

		protected abstract ChannelType ChannelType {
			get;
		}

		protected abstract string ChannelDisplayName {
			get;
		}

		#endregion

		#region Methods: Protected

		protected virtual string FormatPhoneNumber(string phoneNumber) {
			return phoneNumber;
		}

		protected TResponse RegisterChannelInternal(TRequest request) {
			try {
				Log.Info($"Registering {ChannelDisplayName} channel");
				Log.Info("Registering in Account Service");
				if (!RegisterAccountIfNotExists()) {
					var accountServiceSetupMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
						"OmnichannelMessagingService", "LocalizableStrings.ProblemWithAccountServiceSetup.Value");
					return new TResponse {
						Success = false,
						IsConnectionSuccess = false,
						ErrorInfo = new ErrorInfo {
							ErrorCode = "AccountServiceError",
							Message = accountServiceSetupMessage
						}
					};
				}
				var additionalParameters = new Dictionary<string, object>();
				additionalParameters.Add("appId", request.AppId);
				var registrationData = new MessengerRegistrationData {
					Messenger = ChannelType.ToString(),
					MessengerId = FormatPhoneNumber(request.ChannelPhoneNumber),
					Token = request.Token,
					MessageReceiverUrl = GetMessageReceiverUrl(),
					MessageRouterUrl = GetMessageRouterUrl("channel/register"),
					AdditionalParameters = additionalParameters,
					IdentityToken = GetIdentityToken()
				};
				Log.Info("Registering channel in system");
				var registerResult = MessageManager.Register(registrationData);
				return new TResponse {
					SettingsId = registerResult.SettingsId
				};
			} catch (Exception ex) {
				Log.Error($"Error while registering {ChannelDisplayName} channel:\n{ex.Message}\n{ex.StackTrace}");
				return new TResponse {
					IsConnectionSuccess = false
				};
			}
		}

		protected TResponse ValidateInternal(TRequest request) {
			try {
				var sender = new WhatsAppMessageSender(UserConnection);
				var result = sender.Validate(
					new MessagingMessage {
						Sender = FormatPhoneNumber(request.ChannelPhoneNumber),
						Recipient = FormatPhoneNumber(request.ChannelPhoneNumber),
						Message = new LocalizableString(UserConnection.Workspace.ResourceStorage,
							"WhatsAppOmnichannelMessagingService", "LocalizableStrings.WhatsAppValidationTestMessage.Value")
					},
					new WhatsAppSettings {
						AppId = request.AppId,
						Token = request.Token
					});
				return new TResponse {
					IsConnectionSuccess = true
				};
			} catch (Exception ex) {
				return new TResponse {
					IsConnectionSuccess = false,
					Exception = ex
				};
			}
		}

		protected void RemoveChannelInternal(string channelId) {
			var deletionData = new MessengerDeletionData {
				ChannelId = channelId,
				MessageRouterUrl = GetMessageRouterUrl("channel/remove"),
				Messenger = ChannelType.ToString(),
				IdentityToken = GetIdentityToken()
			};
			Log.Info($"{ChannelDisplayName} channel with Id '{deletionData.ChannelId}' is trying to remove");
			MessageManager.RemoveChannel(deletionData);
			Log.Info($"{ChannelDisplayName} channel with Id '{deletionData.ChannelId}' was removed");
		}

		#endregion

		#region Methods: Public

		public void UpdateMessageStatus() {
			var handler = new TwilioMessageStatusHandler(UserConnection);
			var chatOperatorNotifier = new ChatOperatorNotifier(UserConnection);
			var httpContext = HttpContextAccessor.GetInstance();
			var messageIdParam = httpContext.Request.QueryString["messageId"];
			var messageStatus = httpContext.Request.Form["MessageStatus"];
			var errorMessage = httpContext.Request.Form["ErrorMessage"] ?? string.Empty;
			if (Guid.TryParse(messageIdParam, out var messageId)) {
				var statusResponseById = handler.HandleStatusUpdate(messageId,
					messageStatus,
					errorMessage);
				chatOperatorNotifier.MessageDeliveryStatusChangedNotify(UserConnection.CurrentUser.Id, messageId,
					statusResponseById.Status, statusResponseById.DeliveryError);
				return;
			}
			var statusResponseBySid = handler.HandleStatusUpdate(
				httpContext.Request.Form["MessageSid"],
				messageStatus,
				httpContext.Request.Form["ErrorMessage"] ?? httpContext.Request.Form["Reason"] ?? string.Empty);
			var sidMessageId = Guid.TryParse(httpContext.Request.Form["MessageSid"], out var parsedSidMessageId)
				? parsedSidMessageId
				: Guid.Empty;
			chatOperatorNotifier.MessageDeliveryStatusChangedNotify(UserConnection.CurrentUser.Id,
                statusResponseBySid.MessageId, statusResponseBySid.Status, statusResponseBySid.DeliveryError);
		}

		#endregion

	}

	#endregion

}

