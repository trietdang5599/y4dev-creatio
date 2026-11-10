namespace Terrasoft.Configuration
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using System.Web.SessionState;
	using Terrasoft.Core.Factories;
	using Terrasoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class TimezoneService : BaseService, IReadOnlySessionState
	{
		private TimezoneHelper GetTimezoneHelper() {
			IContactTimezone contactTimezone = ClassFactory.Get<ContactTimezone>(
				new ConstructorArgument("userConnection", UserConnection));
			return new TimezoneHelper(UserConnection, contactTimezone);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetContactCurrentTime(string contactId) {
			TimezoneHelper timezoneHelper = GetTimezoneHelper();
			return timezoneHelper.GetContactCurrentTime(new Guid(contactId));
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetAdjustmentRule(string timezoneCode) {
			TimezoneHelper timezoneHelper = GetTimezoneHelper();
			return timezoneHelper.GetAdjustmentRule(timezoneCode);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped,
		ResponseFormat = WebMessageFormat.Json)]
		public string GetAdjustmentRuleById(Guid timezoneId) {
			TimezoneHelper timezoneHelper = GetTimezoneHelper();
			return timezoneHelper.GetAdjustmentRule(timezoneId);
		}

	}
}

