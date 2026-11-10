 namespace Terrasoft.Configuration
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.IO;
	using System.Linq;
	using System.Text;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using Terrasoft.Common;
	using Terrasoft.Common.Json;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
    using Terrasoft.Mail.Sender;
#if !NETSTANDARD2_0 // TODO #CRM-44434
    using Terrasoft.UI.WebControls.Controls;
	using Terrasoft.UI.WebControls.Utilities.Json.Converters;
#else
	using Terrasoft.Mail;
#endif
		
	#region Class: EmailTemplateExecutor

	public class EmailTemplateExecutor
	{

		#region Constructors: Public

		public EmailTemplateExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		public EmailTemplateExecutor(Guid emailTemplateId, Guid activeRowPrimaryColumnValue, UserConnection userConnection)
			: this(userConnection) {
			EmailTemplateEntity = EmailTemplateUtility.GetFormattedEmailTemplateEntity(emailTemplateId, activeRowPrimaryColumnValue, UserConnection);
			_emailTemplateId = emailTemplateId;
			_saveAsActivity = EmailTemplateEntity.GetTypedColumnValue<bool>("SaveAsActivity");
			_sendIndividualEmail = EmailTemplateEntity.GetTypedColumnValue<Guid>("SendIndividualEmailId") == individualEmailGuid;
			_userConnection = UserConnection;
			RecordId = activeRowPrimaryColumnValue;
			ObjectName = EmailTemplateEntity.GetTypedColumnValue<string>("Object_Name");
		}

		#endregion

		#region Properties: Private

		private static readonly Guid individualEmailGuid = new Guid("E75AC3FE-BE9B-4A01-87DB-C7DFFD354F8C");
		private int _currentIndex = 0;

		private Guid _emailTemplateId;
		private Guid EmailTemplateId {
			get {
				return _emailTemplateId;
			}
		}

		private Guid RecordId {
			get;
			set;
		}

		private string ObjectName {
			get;
			set;
		}

		private Entity EmailTemplateEntity {
			get;
			set;
		}

		private Dictionary<string, Guid> _emailRecipients;
		private Dictionary<string, Guid> EmailRecipients {
			get {
				if (_emailRecipients == null) {
					bool haveEmptyRecipient = false;
					_emailRecipients = EmailTemplateUtility.GetRecipientsList(
						Json.Deserialize<string>(System.Text.Encoding.UTF8.GetString(EmailTemplateEntity.GetBytesValue("Recipient"))),
						RecordId,
						ObjectName,
						UserConnection,
						out haveEmptyRecipient);
					if (haveEmptyRecipient)
						_haveEmptyRecipient = haveEmptyRecipient;
				}
				return _emailRecipients;
			}
		}

		private string _recipient;
		private string Recipient {
			get {
				if (string.IsNullOrEmpty(_recipient)) {
					_recipient = EmailRecipients.Keys.Aggregate("", (current, i) => current + i);
				}
				return _recipient;
			}
		}

		private string _copyRecipient;
		private string CopyRecipient {
			get {
				if (string.IsNullOrEmpty(_copyRecipient)) {
					bool haveEmptyRecipient = false;
					_copyRecipient = (EmailTemplateUtility.GetRecipientsList(
						Json.Deserialize<string>(System.Text.Encoding.UTF8.GetString(EmailTemplateEntity.GetBytesValue("CopyRecipient"))),
						RecordId,
						ObjectName,
						UserConnection,
						out haveEmptyRecipient)).Keys.Aggregate("", (current, i) => current + i);
				}
				return _copyRecipient;
			}
		}

		private string _blindCopyRecipient;
		private string BlindCopyRecipient {
			get {
				if (string.IsNullOrEmpty(_blindCopyRecipient)) {
					bool haveEmptyRecipient = false;
					_blindCopyRecipient = (EmailTemplateUtility.GetRecipientsList(
						Json.Deserialize<string>(System.Text.Encoding.UTF8.GetString(EmailTemplateEntity.GetBytesValue("BlindCopyRecipient"))),
						RecordId,
						ObjectName,
						UserConnection,
						out haveEmptyRecipient)).Keys.Aggregate("", (current, i) => current + i);
				}
				return _blindCopyRecipient;
			}
		}

		private string _sendFromAddress;
		private string SendFromAddress {
			get {
				return _sendFromAddress;
			}
		}

		private UserConnection _userConnection;
		private UserConnection UserConnection {
			get {
				return _userConnection;
			}
		}

		#endregion

		#region Properties: Public

		private bool _saveAsActivity;
		public bool SaveAsActivity {
			get {
				return _saveAsActivity;
			}
		}

		private bool _sendIndividualEmail;
		public bool SendIndividualEmail {
			get {
				return _sendIndividualEmail;
			}
		}

		private bool _haveEmptyRecipient;
		public bool HaveEmptyRecipient {
			get {
				if (!_haveEmptyRecipient) {
					int temp = EmailRecipients.Count;
				}
				return _haveEmptyRecipient;
			}
		}

		public bool IsEmptyList {
			get {
				return EmailRecipients.Count == 0;
			}
		}

		private int _emailsWasSended;
		public int EmailsWasSended {
			get {
				return _emailsWasSended;
			}
		}

		#endregion

		#region Methods: Private

		private void SetDefValues(Entity activity) {
			var parentEntityId = RecordId;
			var parentEntitySchemaName = ObjectName;
			var defValues = new Dictionary<string, object>();
			if (parentEntityId != Guid.Empty && !string.IsNullOrEmpty(parentEntitySchemaName)) {
				var entitySchemaManager = UserConnection.EntitySchemaManager;
				var parentSchema = entitySchemaManager.GetInstanceByName(parentEntitySchemaName);
				var detailAsscSchemaName = "SysModuleDetailParentAssc";
				var detailEntitySchemaQuery = new EntitySchemaQuery(entitySchemaManager, detailAsscSchemaName);
				var parentColumnMetaPathColumn = detailEntitySchemaQuery.AddColumn("ParentColumnMetaPath");
				var columnMetaPathColumn = detailEntitySchemaQuery.AddColumn("ColumnMetaPath");
				string detailParentIdColumnName = "SysModuleDetail.SysModule.SysModuleEntity.SysEntitySchemaUId";
				string detailIdColumnName = "SysModuleDetail.SysModuleGrid.SysModuleEntity.SysEntitySchemaUId";
				detailEntitySchemaQuery.Filters.Add(detailEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				detailParentIdColumnName, parentSchema.UId));
				detailEntitySchemaQuery.Filters.Add(detailEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				detailIdColumnName, activity.Schema.UId));
				detailEntitySchemaQuery.Filters.Add(detailEntitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
				"SysParentAssociationType.Code", "DefValue"));
				var defValuesCollection = detailEntitySchemaQuery.GetEntityCollection(UserConnection);
				if (defValuesCollection.Count > 0) {
					string columnMetaPath = string.Empty;
					string parentColumnMetaPath = string.Empty;
					EntitySchemaQuery entitySchemaQuery = new EntitySchemaQuery(parentSchema);
					var entityCollectionColumns = new Dictionary<string, string>();
					foreach (var defValue in defValuesCollection) {
						columnMetaPath = defValue.GetTypedColumnValue<string>(columnMetaPathColumn.Name);
						if (!string.IsNullOrEmpty(columnMetaPath)) {
							var columnInActivity = activity.Schema.FindSchemaColumnByPath(columnMetaPath);
							if (columnInActivity == null) {
								columnInActivity = activity.Schema.FindSchemaColumnByMetaPath(columnMetaPath);
							}
							columnMetaPath = columnInActivity.ColumnValueName;
						}
						parentColumnMetaPath = defValue.GetTypedColumnValue<string>(parentColumnMetaPathColumn.Name);
						string parentColumnPath = parentColumnMetaPath;
						if (!string.IsNullOrEmpty(parentColumnPath)) {
							if (parentSchema.FindSchemaColumnByPath(parentColumnPath) == null) {
								parentColumnPath = parentSchema.GetSchemaColumnPathByMetaPath(parentColumnMetaPath);
							}
						}
						EntitySchemaQueryColumn parentColumn = entitySchemaQuery.AddColumn(parentColumnPath);
						entityCollectionColumns.Add(columnMetaPath, parentColumn.Name);
					}
					entitySchemaQuery.Filters.Add(entitySchemaQuery.CreateFilterWithParameters(FilterComparisonType.Equal,
					parentSchema.PrimaryColumn.Name, parentEntityId));
					EntityCollection entityCollection = entitySchemaQuery.GetEntityCollection(UserConnection);
					foreach (var column in entityCollectionColumns) {
						var columnValueName = entitySchemaQuery.GetSchema().Columns.GetByName(column.Value).ColumnValueName;
						defValues.Add(column.Key, entityCollection[0].GetColumnValue(columnValueName));
					}
				}
			}
			foreach (var value in defValues) {
				activity.SetColumnValue(value.Key, value.Value);
			}
		}

		private IEmailSender GetEmailSender() {
			var emailClientFactory = ClassFactory.Get<EmailClientFactory>(new ConstructorArgument("userConnection", UserConnection));
			var emailSender = ClassFactory.Get<IEmailSender>(new ConstructorArgument("emailClientFactory", emailClientFactory),
				new ConstructorArgument("userConnection", UserConnection));
			return emailSender;
		}

		private IEmailSender GetActivityEmailSender() {
			ConstructorArgument userConnectionArg = new ConstructorArgument("userConnection", UserConnection);
			IEmailClientFactory emailClientFactory = ClassFactory.Get<EmailClientFactory>(userConnectionArg);
			var activityEmailSender = new ActivityEmailSender(emailClientFactory, UserConnection);
			return activityEmailSender;
		}

		private EmailMessage GetEmailMessage(List<string> recipients) {
			var subject = EmailTemplateEntity.GetTypedColumnValue<string>("Subject");
			string body = EmailTemplateEntity.GetTypedColumnValue<string>("Body");
			bool isHtmlBody = EmailTemplateEntity.GetTypedColumnValue<bool>("IsHtmlBody");
			var priorityId = EmailTemplateEntity.GetTypedColumnValue<Guid>("PriorityId");
			var attachments = EmailTemplateUtility.GetEmailTemplateAttachments(UserConnection, EmailTemplateId);
			return new EmailMessage {
				From = SendFromAddress,
				To = recipients,
				Subject = subject,
				Body = body,
				Priority = EmailPriorityConverter.GetEmailPriority(priorityId),
				IsHtmlBody = isHtmlBody,
				Attachments = attachments,
			};
		}

		private EmailMessage GetEmailMessageWithMacros(string mailingContact, List<string> recipients = null) {
			var macrosBytes = EmailTemplateEntity.GetBytesValue("Macros");
			var macrosList = Json.Deserialize<List<DictionaryEntry>>(Encoding.UTF8.GetString(macrosBytes));
			var contactId = EmailRecipients[mailingContact];
			var emailMessage = GetEmailMessage(recipients);
			emailMessage.Body = EmailTemplateUtility.ReplaceRecipientMacrosText(emailMessage.Body, contactId, macrosList, UserConnection);
			emailMessage.Subject = EmailTemplateUtility.ReplaceRecipientMacrosText(emailMessage.Subject, contactId, macrosList, UserConnection);
			return emailMessage;
		}

		private List<string> GetRecipients(string mailingContact) {
			string recepient = (mailingContact.Split(new Char[] { '<', '>' }))[1];
			return new List<string>() { recepient };
		}

		#endregion

		#region Methods: Public

		public Guid CreateActivity() {
			string subject = EmailTemplateEntity.GetTypedColumnValue<string>("Subject");
			string body = EmailTemplateEntity.GetTypedColumnValue<string>("Body");
			bool isHtmlBody = EmailTemplateEntity.GetTypedColumnValue<bool>("IsHtmlBody");
			Guid priority = EmailTemplateEntity.GetTypedColumnValue<Guid>("PriorityId");
			var macrosBytes = EmailTemplateEntity.GetBytesValue("Macros");
			var macrosList = Json.Deserialize<List<DictionaryEntry>>(System.Text.Encoding.UTF8.GetString(macrosBytes));
			if (SendIndividualEmail) {
				var activity = new Terrasoft.Configuration.Activity(UserConnection);
				activity.SetDefColumnValues();
				SetDefValues(activity);
				activity.TypeId = Terrasoft.Configuration.ActivityConsts.EmailTypeUId;
				activity.Recepient = (EmailRecipients.Keys.ToArray())[_currentIndex];
				activity.CopyRecepient = CopyRecipient;
				activity.BlindCopyRecepient = BlindCopyRecipient;
				Guid contactId = (EmailRecipients.Values.ToArray())[_currentIndex];
				activity.Title = EmailTemplateUtility.ReplaceRecipientMacrosText(subject, contactId, macrosList, UserConnection);
				activity.Body = EmailTemplateUtility.ReplaceRecipientMacrosText(body, contactId, macrosList, UserConnection);
				activity.IsHtmlBody = isHtmlBody;
				activity.PriorityId = priority;
				activity.StartDate = UserConnection.CurrentUser.GetCurrentDateTime();
				activity.DueDate = UserConnection.CurrentUser.GetCurrentDateTime();
				activity.OwnerId = UserConnection.CurrentUser.ContactId;
				activity.AuthorId = UserConnection.CurrentUser.ContactId;
				activity.StatusId = Terrasoft.Configuration.ActivityConsts.NewStatusUId;
				if (contactId != Guid.Empty) {
					activity.ContactId = contactId;
				}
				activity.Save();
				_currentIndex++;
				return activity.PrimaryColumnValue;
			} else {
				_currentIndex = EmailRecipients.Count;
				var activity = new Terrasoft.Configuration.Activity(UserConnection);
				activity.SetDefColumnValues();
				SetDefValues(activity);
				activity.TypeId = Terrasoft.Configuration.ActivityConsts.EmailTypeUId;
				activity.Recepient = Recipient;
				activity.CopyRecepient = CopyRecipient;
				activity.BlindCopyRecepient = BlindCopyRecipient;
				activity.Title = subject;
				activity.Body = body;
				activity.IsHtmlBody = isHtmlBody;
				activity.PriorityId = priority;
				activity.StartDate = UserConnection.CurrentUser.GetCurrentDateTime();
				activity.DueDate = UserConnection.CurrentUser.GetCurrentDateTime();
				activity.OwnerId = UserConnection.CurrentUser.ContactId;
				activity.AuthorId = UserConnection.CurrentUser.ContactId;
				activity.StatusId = Terrasoft.Configuration.ActivityConsts.NewStatusUId;
				//commented 24.12.2012 after discuss with Taras Siversky
				/*if (!string.IsNullOrEmpty(RelationColumnName)) {
					activity.SetColumnValue(RelationColumnName, RecordId);
				}*/
				activity.Save();
				return activity.PrimaryColumnValue;
			}
		}

		public bool HasNextActivity() {
			return _currentIndex < EmailRecipients.Count;
		}

		public bool TryCreateSender() {
			var mailboxCollection = new EmailCollectMailboxCollection(UserConnection, UserConnection.CurrentUser.ContactId).Collect();
			if (mailboxCollection.Count == 0)
				return false;
			var mailboxEntityIEnum = mailboxCollection.Where(mailbox => mailbox.GetTypedColumnValue<bool>("IsDefault") == true);
			if (mailboxEntityIEnum.Count() == 0)
				return false;
			var mailboxEntity = mailboxEntityIEnum.First();
			var email = mailboxEntity.GetTypedColumnValue<string>("UserName");
			var user = UserConnection.CurrentUser.ContactName;
#if NETFRAMEWORK && OldUI // TODO #CRM-44355
			_sendFromAddress = Terrasoft.UI.WebControls.Utilities.ControlUtilities.HtmlDecode(string.Format("{0} <{1}>", user, email));
#endif
			return true;
		}

		public void SendEmail() {
			if (string.IsNullOrEmpty(SendFromAddress) && !TryCreateSender()) {
				return;
			}
			var mailingCollection = EmailRecipients.Keys.ToList();
			_emailsWasSended = 0;
			var emailSender = !UserConnection.GetIsFeatureEnabled("OldEmailIntegration")
					&& !UserConnection.GetIsFeatureEnabled("OldEmailSend")
				? GetActivityEmailSender()
				: GetEmailSender();
			if (SendIndividualEmail) {
				foreach (var mailingContact in mailingCollection) {
					var recipients = GetRecipients(mailingContact);
					try {
						var emailMessage = GetEmailMessageWithMacros(mailingContact, recipients);
						emailSender.Send(emailMessage, true);
						_emailsWasSended++;
					} catch { }
				}
			} else {
				try {
					var recipients = mailingCollection.Select(mail => mail.Split(new Char[] { '<', '>' })[1]).ToList();
					var emailMessage = GetEmailMessage(recipients);
					emailSender.Send(emailMessage, true);
					_emailsWasSended++;
				} catch { }
			}
		}

		#endregion

	}

	#endregion

}
