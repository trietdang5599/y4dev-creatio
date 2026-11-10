namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Newtonsoft.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Process;
	using Terrasoft.Mail.Sender;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Core.Entities;


	#region Interface: IMacrosProvider

	public interface IEmailUserTaskMacrosProvider
	{

		#region Properties: Public

		UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Public

		void ReplaceMacroses(EmailMessage message);

		#endregion

	}

	#endregion

	#region Interface: IEmailUserTaskMessageProvider

	public interface IEmailUserTaskMessageProvider
	{

		#region Properties: Public

		EmailTemplateUserTask EmailUserTask { get; }

		IEmailUserTaskMacrosProvider MacrosProvider { get; set; }

		#endregion

		#region Methods: Public

		EmailMessage GetEmailMessage();

		#endregion

	}

	#endregion

	#region Interface: IEmailUserTaskSender

	public interface IEmailUserTaskSender
	{

		#region Properties: Public

		UserConnection UserConnection { get; set; }

		/// <summary>
		/// Flag, indicates that user interaction is required to send email.
		/// </summary>
		bool NeedUserInteraction { get; }

		#endregion

		#region Methods: Public

		bool Execute(IEmailUserTaskMessageProvider messageProvider, ProcessExecutingContext context);

		bool CompleteExecuting(EmailTemplateUserTask userTask, Func<object[], bool> callBase,
			params object[] parameters);

		void CancelExecuting(EmailTemplateUserTask userTask, Action<object[]> callBase, params object[] parameters);

		string GetExecutionData(EmailTemplateUserTask userTask);

		/// <summary>
		/// Returns instance that implements the <see cref="IProcessNotifier"/> interface.
		/// </summary>
		/// <param name="baseProcessNotifier">Delegate to get base process notifier.</param>
		/// <returns></returns>
		[Obsolete("7.18.2 | Method is not in use and will be removed in upcoming builds")]
		IProcessNotifier GetProcessNotifier(Func<IProcessNotifier> baseProcessNotifier);

		#endregion

	}

	#endregion

	#region Class: BaseProcessEmailMessageProvider

	public abstract class BaseProcessEmailMessageProvider : IEmailUserTaskMessageProvider
	{

		#region Constructors: Protected

		protected BaseProcessEmailMessageProvider(EmailTemplateUserTask userTask) {
			EmailUserTask = userTask;
		}

		#endregion

		#region Properties: Public

		public EmailTemplateUserTask EmailUserTask { get; private set; }

		public IEmailUserTaskMacrosProvider MacrosProvider { get; set; }

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection => EmailUserTask.UserConnection;

		#endregion

		#region Methods: Private

		protected virtual EntitySchemaQuery GetSenderEsq() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "MailboxSyncSettings") {
				UseAdminRights = false
			};
			esq.AddColumn("SenderEmailAddress");
			IEntitySchemaQueryFilterItem primaryFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"Id", EmailUserTask.Sender);
			esq.Filters.Add(primaryFilter);
			return esq;
		}

		private string GetSenderName() {
			string result = string.Empty;
			EntitySchemaQuery mailboxTableEsq = GetSenderEsq();
			Entity entity = mailboxTableEsq.GetEntityCollection(UserConnection).SingleOrDefault();
			if (entity != null) {
				result = entity.GetTypedColumnValue<string>("SenderEmailAddress");
			}
			return result;
		}

		private string GetDefaultEmailSubject() {
			string subject = string.Empty;
			if (EmailUserTask.Owner.Schema is ProcessSchema processSchema) {
				LocalizableString schemaElementCaption = processSchema
					.GetBaseElementByUId(EmailUserTask.SchemaElementUId).Caption;
				if (!LocalizableString.IsNullOrEmpty(schemaElementCaption)) {
					subject = schemaElementCaption;
				}
			}
			if (string.IsNullOrEmpty(subject)) {
				string resourceItemName = "LocalizableStrings.DefaultEmailSubject.Value";
				subject = new LocalizableString(UserConnection.ResourceStorage, "EmailTemplateUserTaskMessageProvider",
					resourceItemName);
			}
			return subject;
		}

		#endregion

		#region Methods: Protected

		protected abstract string GetEmailBody();

		protected string GetEmailSubject() {
			var subject = string.Empty;
			if (!LocalizableString.IsNullOrEmpty(EmailUserTask.Subject)) {
				subject = EmailUserTask.Subject;
			}
			return subject;
		}

		protected virtual (string Body, string Subject) GetEmailContent() {
			return (GetEmailBody(), GetEmailSubject());
		}

		private List<EmailMessageHeader> ParseCustomEmailHeaders(string headers) {
			if (headers.IsNullOrWhiteSpace()) {
				return new List<EmailMessageHeader>();
			}
			try {
				var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(headers);
				if (dict == null) {
					return new List<EmailMessageHeader>();
				}
				return dict
					.Where(kvp => kvp.Key.IsNotNullOrWhiteSpace() && kvp.Value.IsNotNullOrWhiteSpace())
					.Select(kvp => new EmailMessageHeader {
						Name = kvp.Key.Trim(),
						Value = kvp.Value.Trim()
					})
					.ToList();
			} catch (JsonException ex) {
				throw new FormatException($"CustomEmailHeaders contains invalid JSON: {ex.Message}", ex);
			}
		}

		protected EmailMessage CreateEmailMessage() {
			(string Body, string Subject) emailContent = GetEmailContent();
			string sender = GetSenderName();
			string subject = string.IsNullOrEmpty(emailContent.Subject)
				? GetDefaultEmailSubject()
				: emailContent.Subject;
			string body = emailContent.Body;
			var emailPriority = (EmailPriority)EmailUserTask.Importance;
			List<string> recipients = EmailUserTask.GetRecipientList();
			List<string> ccRecipients = EmailUserTask.GetCopyRecipientList();
			List<string> bccRecipients = EmailUserTask.GetBlindCopyRecipientList();
			var message = new EmailMessage {
				From = sender,
				To = recipients,
				Priority = emailPriority,
				Cc = ccRecipients,
				Bcc = bccRecipients,
				Subject = subject,
				Body = body,
				IsHtmlBody = true
			};
			if (UserConnection.GetIsFeatureEnabled("UseProcessEmailAttachments")) {
				message.Attachments = EmailUserTask.GetEmailAttachments();
			}
			if (EmailUserTask.CustomEmailHeaders.IsNotNullOrEmpty()) {
				message.HeaderProperties.AddRange(ParseCustomEmailHeaders(EmailUserTask.CustomEmailHeaders));
			}
			return message;
		}

		#endregion

		#region Methods: Public

		public EmailMessage GetEmailMessage() {
			EmailMessage message = CreateEmailMessage();
			MacrosProvider?.ReplaceMacroses(message);
			return message;
		}

		#endregion

	}

	#endregion

}

