namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using EmailContract.Commands;
	using EmailContract.DTO;
	using global::Common.Logging;
	using IntegrationApi.Interfaces;
	using Terrasoft.Common;
	using Terrasoft.Core.Factories;
	using Terrasoft.EmailDomain.Interfaces;
	using Terrasoft.MailboxDomain.EventProcessing;
	using Terrasoft.Web.Common;

	#region Class: ExchangeListenerService

	/// <summary>
	/// Class provides web service endpoint for exchange listener service requests processing.
	/// </summary>
	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class ExchangeListenerService : BaseService
	{

		#region Fields: Private

		/// <summary>
		/// <see cref="ILog"/> instance.
		/// </summary>
		private static readonly ILog _log = LogManager.GetLogger("EmailListener");

		#endregion

		#region Methods: Private
		
		/// <summary>
		/// Creates display string for <paramref name="events"/>.
		/// </summary>
		/// <param name="events">Exchange events identificators collection.</param>
		/// <returns>Display string for <paramref name="events"/>.</returns>
		private string GetReadableEventsList(string[] events) {
			return $"[{string.Join(",", events)}]";
		}

		
		/// <summary>
		/// Creates display string for <paramref name="emails"/>.
		/// </summary>
		/// <param name="emails">Emails DTO collection.</param>
		/// <returns>Display string for <paramref name="emails"/>.</returns>
		private string GetReadableEmailsList(IEnumerable<Email> emails) {
			return $"[{string.Join(",", emails.Select(e => GetEmailDisplayValue(e)))}]";
		}

		/// <summary>
		/// Creates display string for <paramref name="email"/>.
		/// </summary>
		/// <param name="email">Email DTO.</param>
		/// <returns>Display string for <paramref name="email"/>.</returns>
		private string GetEmailDisplayValue(Email email) {
			return email == null
				? string.Empty
				: $"{email.Subject}, SendDate timestamp {email.SendDateTimeStamp}, From {email.Sender}, id {email.MessageId}";
		}

		private void ProcessLoadEmailCommand(LoadEmailCommand emailsData) {
			if (emailsData.Emails.IsNullOrEmpty()) {
				_log.Warn($"ProcessFullEmail for = {emailsData.SubscriptionInfo.Id} stopped - no emails passed");
				return;
			}
			_log.Info($"ProcessFullEmail id = {emailsData.SubscriptionInfo.Id}," +
				$" username= {emailsData.SubscriptionInfo.SysAdminUnit}, emails = {GetReadableEmailsList(emailsData.Emails)}");
			var emailEventsProcessor = ClassFactory.Get<IEmailEventsProcessor>();
			emailEventsProcessor.ProcessLoadEmailCommand(emailsData);
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void NewEmail(ExchangeEmailEvent newEvent) {
			_log.InfoFormat("NewEmail itemId length = {0}, timestamp = {1}, id = {2}, username= {3}, eventIds = {4}",
				newEvent.UniqueIds.Length, newEvent.EventTimeStamp, newEvent.Id, newEvent.SysAdminUnitName,
				GetReadableEventsList(newEvent.UniqueIds));
			var processor = ClassFactory.Get<IExchangeEventsProcessor>();
			processor.ProcessNewEmail(newEvent);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ProcessBinarySerializedEmail(Stream fileContent) {
			_log.Warn($"{nameof(ProcessBinarySerializedEmail)} has been closed since 8.0.6 due to vulnerability issue. " +
				$"Mail synchronisation might not work. " +
				$"Please make sure if feature 'DoNotUseBinaryData' is enabled and EL is updated (1.0.9+)");
			return;
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ProcessFullEmail(LoadEmailCommand emailsData) {
			ProcessLoadEmailCommand(emailsData);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void ProcessMailboxState(MailboxState mailboxState) {
			var logMessage = string.Concat($"ProcessMailboxState mailbox = {mailboxState.SenderEmailAddress}, ",
				$"avaliable = {mailboxState.Avaliable}, ",
				$"exception = {mailboxState.ExceptionClassName}, ",
				$"message = {mailboxState.ExceptionMessage}, ",
				$"context = {mailboxState.Context}");
			if (mailboxState.Avaliable) {
				_log.Info(logMessage);
			} else {
				_log.Error(logMessage);
			};
			var connectionEventsProcessor = ClassFactory.Get<IMailboxStateEventsProcessor>();
			connectionEventsProcessor.ProcessMailboxState(mailboxState);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Bare,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void RefreshToken(MailboxInfo mailboxInfo) {
			var mailboxEventsProcessor = ClassFactory.Get<IMailboxEventsProcessor>();
			mailboxEventsProcessor.ProcessRefreshAccessToken(mailboxInfo);
		}

		#endregion

	}

	#endregion
	
}

