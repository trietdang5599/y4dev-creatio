namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using OmnichannelProviders.Domain.Entities;
	using OmnichannelProviders.MessageConverters;
	using OmnichannelProviders.WhatsAppProvider.Domain.Entities;
	using Terrasoft.Common;
	using Terrasoft.Web.Common;
	using Terrasoft.Web.Common.ServiceRouting;
	using Terrasoft.Web.Http.Abstractions;

	#region Class: WhatsAppRegistrationResponse

	[DataContract]
	public class WhatsAppRegistrationResponse : BaseTwilioRegistrationResponse
	{
	}

	#endregion

	#region Class: WhatsAppRegistrationRequest

	[DataContract]
	public class WhatsAppRegistrationRequest : BaseTwilioRegistrationRequest
	{
	}

	#endregion

	#region Class: WhatsAppOmnichannelMessagingService

	/// <summary>
	/// Service for sending and receiving messages from whatsapp api.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class WhatsAppOmnichannelMessagingService : BaseTwilioOmnichannelMessagingService<WhatsAppRegistrationRequest, WhatsAppRegistrationResponse>
	{

		#region Properties: Protected

		protected override ChannelType ChannelType {
			get {
				return ChannelType.WhatsApp;
			}
		}

		protected override string ChannelDisplayName {
			get {
				return "WhatsApp";
			}
		}

		#endregion

		#region Methods: Protected

		protected override string FormatPhoneNumber(string phoneNumber) {
			return $"whatsapp:{phoneNumber}";
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Registers whatsapp channel in Creatio.
		/// </summary>
		/// <param name="request">Whatsapp registration data.</param>
		/// <returns>Registration response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public WhatsAppRegistrationResponse RegisterChannel(WhatsAppRegistrationRequest request) {
			return RegisterChannelInternal(request);
		}

		/// <summary>
		/// Validates whatsapp registration data.
		/// </summary>
		/// <param name="request">Whatsapp registration data.</param>
		/// <returns>Registration response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public WhatsAppRegistrationResponse Validate(WhatsAppRegistrationRequest request) {
			return ValidateInternal(request);
		}

		/// <summary>
		/// Removes WhatsApp channel.
		/// </summary>
		/// <param name="whatsAppId">Identifier of WhatsApp.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public void RemoveChannel(string whatsAppId) {
			RemoveChannelInternal(whatsAppId);
		}

		/// <summary>
		/// Receives messages from integration api.
		/// </summary>
		/// <param name="message">WhatsApp form message.</param>
		/// <param name="whatsAppId">Identifier of whatsAppId channel.</param>
		[OperationContract]
		[WebInvoke(UriTemplate = "receive/{whatsAppId}", Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public void ReceiveMessage(WhatsAppIncomingMessage message, string whatsAppId) {
			try {
				SessionHelper.SpecifyWebOperationIdentity(HttpContext.Current, AppConnection.SystemUserConnection.CurrentUser);
				MessagingMessage messagingMessage = new MessagingMessage(WhatsAppIncomingMessageConverter.Convert(message));
				GetChannelAndQueueBySettingsId(Guid.Parse(whatsAppId), messagingMessage);
				if (messagingMessage.ChannelId.IsNotNullOrEmpty()) {
					InternalReceive(messagingMessage);
				}
			} catch (Exception e) {
				Log.ErrorFormat("Error while receiving the message in WhatsApp channel, channelId: {0}. Error info: {1}, StackTrace {2}",
					whatsAppId, e.Message, e.StackTrace);
			}
		}

		[OperationContract]
		[WebInvoke(UriTemplate = "ping", Method = "GET", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public string Ping() {
			return "Pong";
		}

		/// <summary>
		/// Updates message status from Twilio webhook.
		/// </summary>
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "updateMessageStatus", RequestFormat = WebMessageFormat.Json,
			BodyStyle = WebMessageBodyStyle.Bare)]
		public new void UpdateMessageStatus() {
			base.UpdateMessageStatus();
		}

		#endregion

	}

	#endregion

}

