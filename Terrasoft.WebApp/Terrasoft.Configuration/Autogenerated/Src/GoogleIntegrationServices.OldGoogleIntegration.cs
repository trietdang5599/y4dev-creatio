namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Web.Http.Abstractions;
	using ErrorInfo = Terrasoft.Core.ServiceModelContract.ErrorInfo;

	#region Class: GoogleIntegrationService

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class GoogleIntegrationService
	{

		#region Delegates: Private

		private delegate void ExecuteIntegrationMethod(object value);

		#endregion

		#region Properties: Public

		public virtual UserConnection UserConnection {
			get {
				return (UserConnection)HttpContext.Current.Session["UserConnection"];
			}
		}

		public string EntitySchemaName {
			get;
			set;
		}

		public virtual GoogleIntegrationHelper IntegrationHelper {
			get {
				return ClassFactory.Get<GoogleIntegrationHelper>(new ConstructorArgument("userConnection", UserConnection),
					new ConstructorArgument("entitySchemaName", EntitySchemaName));
			}
		}
		
		#endregion

		#region Methods: Private

		private GoogleIntegrationResponse ExecuteIntegrationOperation(ExecuteIntegrationMethod integrationMethod, object value = null) {
			try {
				integrationMethod(value);
				return new GoogleIntegrationResponse {
					Success = true
				};
			} catch (Exception e) {
				return new GoogleIntegrationResponse {
					Exception = e
				};
			}
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "StartGoogleIntegration", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[return: MessageParameter(Name = "IntegrationResponse")]
		public GoogleIntegrationResponse StartGoogleIntegration(string entitySchemaName) {
			EntitySchemaName = entitySchemaName;
			return ExecuteIntegrationOperation(param => {
				IntegrationHelper.StartGoogleIntegration();
			});
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "UpdateGoogleSocialAccount", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public GoogleIntegrationResponse UpdateGoogleSocialAccount(Guid socialAccountId) {
			return ExecuteIntegrationOperation(param => {
				var value = Guid.Parse(param.ToString());
				if (value.IsNotEmpty()) {
					IntegrationHelper.UpdatePreviousGoogleSocialAccount(value);
				}
			}, socialAccountId);
		}

		#endregion

	}

	#endregion

	#region Class: GoogleIntegrationResponse

	[DataContract]
	public class GoogleIntegrationResponse : ConfigurationServiceResponse
	{

		#region Methods: Public

		public override ErrorInfo SetErrorInfo(Exception e) {
			var errorInfo = base.SetErrorInfo(e);
			var exc = e as GoogleIntegrationException;
			errorInfo.ErrorCode = exc.ExceptionCode.ToString();
			return errorInfo;
		}

		public override ResponseStatus SetResponseStatus(Exception e) {
			var responseStatus = base.SetResponseStatus(e);
			var exc = e as GoogleIntegrationException;
			if (exc.MailboxId != null) {
				responseStatus.Meta = new Dictionary<string, string> {
					{ "MailboxId", exc.MailboxId.ToString() }
				};
			}
			return responseStatus;
		}

		#endregion

	}

	#endregion

}
