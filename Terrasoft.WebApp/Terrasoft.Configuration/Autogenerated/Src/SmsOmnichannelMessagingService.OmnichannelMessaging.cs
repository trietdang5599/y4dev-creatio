namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using OmnichannelProviders.Domain.Entities;
	using Terrasoft.Web.Common.ServiceRouting;

	#region Class: SmsRegistrationResponse

	[DataContract]
	public class SmsRegistrationResponse : BaseTwilioRegistrationResponse
	{
	}

	#endregion

	#region Class: SmsRegistrationRequest

	[DataContract]
	public class SmsRegistrationRequest : BaseTwilioRegistrationRequest
	{
	}

	#endregion

	#region Class: SmsOmnichannelMessagingService

	/// <summary>
	/// Service for sending and receiving messages from SMS api.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	[DefaultServiceRoute]
	public class SmsOmnichannelMessagingService : BaseTwilioOmnichannelMessagingService<SmsRegistrationRequest, SmsRegistrationResponse>
	{
		#region Properties: Protected

		protected override ChannelType ChannelType {
			get {
				return ChannelType.SmsTwilio;
			}
		}

		protected override string ChannelDisplayName {
			get {
				return "SMS";
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Registers SMS channel in Creatio.
		/// </summary>
		/// <param name="request">SMS registration data.</param>
		/// <returns>Registration response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public SmsRegistrationResponse RegisterChannel(SmsRegistrationRequest request) {
			return RegisterChannelInternal(request);
		}

		/// <summary>
		/// Validates SMS registration data.
		/// </summary>
		/// <param name="request">SMS registration data.</param>
		/// <returns>Registration response.</returns>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare,
		  ResponseFormat = WebMessageFormat.Json)]
		public SmsRegistrationResponse Validate(SmsRegistrationRequest request) {
			return ValidateInternal(request);
		}

		/// <summary>
		/// Removes SMS channel.
		/// </summary>
		/// <param name="smsId">Identifier of SMS.</param>
		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest,
		  ResponseFormat = WebMessageFormat.Json)]
		public void RemoveChannel(string smsId) {
			RemoveChannelInternal(smsId);
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

