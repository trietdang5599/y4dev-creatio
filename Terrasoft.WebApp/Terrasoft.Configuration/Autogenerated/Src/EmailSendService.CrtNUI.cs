namespace Terrasoft.Configuration.EmailSendService
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Mail.Sender;
	using Terrasoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class EmailSendService : BaseService
	{

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "Send", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public List<SendResult> Send(string ActivityId) {
			string SendEmailStatus = "InProgress";
			bool hasFollowingProcessElement = false;
			string errorMessage = string.Empty;
			try {
				var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
				var activityEmailSender = UserConnection.GetIsFeatureEnabled("SecureEstimation") 
					? new SecureActivityEmailSenderBase(emailClientFactory, UserConnection)
					: new ActivityEmailSenderBase(emailClientFactory, UserConnection);
				Entity activityEntity = activityEmailSender.Send(Guid.Parse(ActivityId));
				hasFollowingProcessElement = (bool)activityEntity.Process.GetPropertyValue("NextProcessElementReady");
				SendEmailStatus = "Sended";
			} catch (Exception e) {
				SendEmailStatus = e is EmailException eEx ? eEx.EmailSendStatus : "ErrorOnSend";
				string exceptionClassName = e.GetType().ToString();
				string exceptionMessage = e.Message;
				var helper = ClassFactory.Get<SynchronizationErrorHelper>(new ConstructorArgument("userConnection", UserConnection));
				Entity message = helper.GetExceptionMessage(exceptionClassName, exceptionMessage);
				if (message != null) {
					EntitySchema activitySchema = UserConnection.EntitySchemaManager.GetInstanceByName("Activity");
					var activity = (Activity)activitySchema.CreateEntity(UserConnection);
					if (activity.FetchFromDB(Guid.Parse(ActivityId))) {
						var sender = activity.Sender;
						var senderEmailAddress = sender.Trim(';').ExtractEmailAddress();
						errorMessage = string.Format(message.GetTypedColumnValue<string>("UserMessage"), senderEmailAddress);
					}
				}
				if (e is FileLoadException fle) {
					errorMessage += fle.Message;
				}
			}
			var sendStatusESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "EmailSendStatus");
			sendStatusESQ.PrimaryQueryColumn.IsAlwaysSelect = true;
			sendStatusESQ.AddColumn("Name");
			sendStatusESQ.AddColumn("Code");
			sendStatusESQ.Filters.Add(sendStatusESQ.CreateFilterWithParameters(
					FilterComparisonType.Equal, 
					"Code", 
					SendEmailStatus
				));
			var sendStatusEntityCollection = sendStatusESQ.GetEntityCollection(UserConnection);
			var sendResultList = new List<SendResult>();
			if (sendStatusEntityCollection.Count > 0) {
				var item = sendStatusEntityCollection[0];
				sendResultList.Add(new SendResult() {
					DisplayValue = item.PrimaryDisplayColumnValue,
					Value = item.PrimaryColumnValue.ToString(),
					Code = item.GetTypedColumnValue<string>("Code"),
					HasFollowingProcessElement = hasFollowingProcessElement,
					ErrorMessage = errorMessage
				});
			} 
			return sendResultList;
		}
		
	}

	public class SendResult
	{

		#region Properties: Public

		public string DisplayValue {
			get;
			set;
		}

		public string Value {
			get;
			set;
		}

		public string Code {
			get;
			set;
		}

		public bool HasFollowingProcessElement {
			get;
			set;
		}

		/// <summary>
		/// Sending email error message.
		/// </summary>
		public string ErrorMessage {
			get;
			set;
		}

		#endregion

	}
}

