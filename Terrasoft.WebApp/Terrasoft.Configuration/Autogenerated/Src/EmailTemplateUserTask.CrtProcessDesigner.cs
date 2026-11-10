namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Core.Process;
	using Terrasoft.Common;
	using Terrasoft.Configuration;
	using Terrasoft.Configuration.ProcessDesigner;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.File;
	using Terrasoft.File.Abstractions;
	using Terrasoft.Mail.Sender;

	#region Class: EmailTemplateUserTask

	/// <summary>
	/// Partial class of EmailTemplateUserTask, that implement user task runtime behaviour.
	/// </summary>
	public partial class EmailTemplateUserTask : IUserTaskActivityInfo
	{

		#region Fields: Private

		private IEmailUserTaskMessageProvider _messageProvider;

		#endregion

		#region Properties: Protected

		protected override bool NeedUserInteraction => EmailSender.NeedUserInteraction;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Returns true if process is interpretable.
		/// </summary>
		public bool CanUseFlowEngine => UseFlowEngineMode;

		private MacrosExtendedProperties _macrosExtendedProperties;
		public MacrosExtendedProperties MacrosExtendedProperties {
			get => _macrosExtendedProperties ?? (_macrosExtendedProperties = new MacrosExtendedProperties());
			set => _macrosExtendedProperties = value;
		}

		private IEmailUserTaskSender _emailSender;

		/// <summary>
		/// Email sender.
		/// </summary>
		public IEmailUserTaskSender EmailSender {
			get => _emailSender ?? (_emailSender = EmailUserTaskSenderFactory.GetEmailSender(this));
			set => _emailSender = value;
		}

		/// <inheritdoc />
		Guid IUserTaskActivityInfo.CurrentActivityId => ActivityId;

		#endregion

		#region Methods: Private

		private EmailAttachment GetEmailAttachment(string name, byte[] data) {
			return new EmailAttachment {
				Id = Guid.NewGuid(),
				Name = name,
				Data = data,
				IsContent = false
			};
		}

		private EmailAttachment GetEmailAttachment(EntityFileLocator locator) {
			IFileFactory fileFactory = UserConnection.GetFileFactory().WithRightsDisabled();
			IFile file = fileFactory.Get(locator);
			return new EmailAttachment {
				Id = Guid.NewGuid(),
				IsContent = false,
				File = file
			};
		}

		private EmailAttachment ReadEmailAttachment(EntityFileLocator locator) {
			if (GlobalAppSettings.FeatureUseFileStorageInProcessUserTasks) {
				return GetEmailAttachment(locator);
			}
			const string fileNameColumnName = "Name";
			const string fileDataColumnName = "Data";
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByName(locator.EntitySchemaName);
			Entity entity = entitySchema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			entity.PrimaryColumnValue = locator.RecordId;
			bool isFetched = entity.FetchFromDB(new[] { fileNameColumnName, fileDataColumnName }, false);
			if (!isFetched) {
				return null;
			}
			string name = entity.GetTypedColumnValue<string>(fileNameColumnName);
			byte[] data = entity.GetBytesValue(fileDataColumnName);
			return GetEmailAttachment(name, data);
		}

		private void FillEmailAttachments(List<EmailAttachment> emailAttachments, string parentParameterName,
				ICompositeObjectList<ICompositeObject> compositeObjectList) {
			foreach (ICompositeObject compositeObject in compositeObjectList) {
				if (!compositeObject.TryGetValue(parentParameterName + "FileLocator",
						out EntityFileLocator fileLocator)) {
					continue;
				}
				EmailAttachment attachment = ReadEmailAttachment(fileLocator);
				if (attachment != null) {
					emailAttachments.Add(attachment);
				}
			}
		}

		private void SaveEmailAttachment(Entity activity, string entitySchemaName, EmailAttachment attachment) {
			IFileFactory fileFactory = UserConnection.GetFileFactory().WithRightsDisabled();
			var targetLocator = new EntityFileLocator(entitySchemaName, attachment.Id);
			IFile targetFile = fileFactory.Create(targetLocator);
			targetFile.SetAttribute("ActivityId", activity.PrimaryColumnValue);
			targetFile.Name = attachment.Name;
			IFile sourceFile = attachment.File;
			sourceFile.Copy(targetFile);
		}

		private void SaveEmailAttachment(Entity activity, EntitySchema entitySchema, EmailAttachment attachment) {
			Entity entity = entitySchema.CreateEntity(UserConnection);
			entity.UseAdminRights = false;
			entity.SetDefColumnValues();
			entity.SetColumnValue("Name", attachment.Name);
			int size = attachment.Data?.Length ?? 0;
			entity.SetColumnValue("Size", size);
			entity.SetColumnValue("TypeId", WebApp.FileConsts.FileTypeUId);
			entity.SetColumnValue("ActivityId", activity.PrimaryColumnValue);
			entity.SetBytesValue("Data", attachment.Data);
			entity.Save();
		}

		private string GetActivityTitle() => ProcessUserTaskUtilities.GetActivityTitle(this, Subject, ActivityId);

		#endregion

		#region Methods: Protected

		[Obsolete("8.3.1 | This method is deprecated, use " +
			"ProcessUserTaskExtensions.GetFilteredOwnParametersList instead.")]
		protected virtual List<ProcessSchemaParameter> GetFilteredParametersList(string parameterNamePrefix) {
			return this.GetFilteredOwnParametersList(parameterNamePrefix);
		}

		protected virtual List<string> GetEmailAddresses(string parameterNamePrefix) {
			var emailAddresses = new List<string>();
			List<ProcessSchemaParameter> parameters = this.GetFilteredOwnParametersList(parameterNamePrefix);
			foreach (ProcessSchemaParameter parameter in parameters) {
				object propertyValue = GetParameterValue(parameter);
				List<string> parameterAddresses = EmailTemplateUserTaskUtilities
					.GetParameterEmailAddresses(UserConnection, propertyValue, parameter);
				emailAddresses.AddRange(parameterAddresses);
			}
			return emailAddresses;
		}

		protected override bool InternalExecute(ProcessExecutingContext context) {
			IEmailUserTaskMessageProvider messageProvider = GetMessageProvider();
			return EmailSender.Execute(messageProvider, context);
		}

		protected IEmailUserTaskMessageProvider GetMessageProvider() {
			if (_messageProvider == null) {
				_messageProvider = EmailUserTaskMessageProviderFactory.GetEmailMessageProvider(this);
				_messageProvider.MacrosProvider = CreateMacrosProvider();
			}
			return _messageProvider;
		}

		protected virtual IEmailUserTaskMacrosProvider CreateMacrosProvider() {
			return EmailUserTaskMacrosHelperFactory.GetMacrosHelper(this, UserConnection);
		}

		/// <inheritdoc />
		protected override void WriteExecutionData(IProcessExecutionDataWriter dataWriter) {
			base.WriteExecutionData(dataWriter);
			dataWriter.Write("nextProcElUId", "nextProcElUIdValue");
			dataWriter.Write("entitySchemaName", "Activity");
			dataWriter.Write("recommendation", GetActivityTitle());
			string informationOnStep = LocalizableString.IsNullOrEmpty(InformationOnStep)
				? GetParameterValue("InformationOnStep")?.ToString() ?? string.Empty
				: InformationOnStep.Value;
			dataWriter.Write("informationOnStep", informationOnStep);
			dataWriter.Write("pageTypeId", ActivityConsts.EmailTypeUId);
			dataWriter.Write("activityRecordId", ActivityId);
			dataWriter.Write("executionContext", ExecutionContext);
			string allowedActivityResults = ProcessUserTaskUtilities.GetAllowedActivityResults(UserConnection,
				ActivityId);
			dataWriter.Write("allowedResults", allowedActivityResults);
		}

		#endregion

		#region Methods: Internal

		internal void AddEmailAttachments(Entity activity, IList<EmailAttachment> emailAttachments) {
			if (!UserConnection.GetIsFeatureEnabled("UseProcessEmailAttachments") ||
				emailAttachments.IsNullOrEmpty()) {
				return;
			}
			activity.Save();
			EntitySchemaManager entitySchemaManager = UserConnection.EntitySchemaManager;
			EntitySchema entitySchema = entitySchemaManager.GetInstanceByName("ActivityFile");
			foreach (EmailAttachment emailAttachment in emailAttachments) {
				if (GlobalAppSettings.FeatureUseFileStorageInProcessUserTasks) {
					SaveEmailAttachment(activity, entitySchema.Name, emailAttachment);
				} else {
					SaveEmailAttachment(activity, entitySchema, emailAttachment);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override bool CompleteExecuting(params object[] parameters) {
			if (!UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")) {
				return EmailSender.CompleteExecuting(this, base.CompleteExecuting, parameters);
			}
			var activity = parameters[0] as Activity;
			if (activity == null) {
				return false;
			}
			this.SynchronizeCompletedUserTaskActivity(new UserTaskActivitySyncOptions {
				Activity = activity
			});
			return base.CompleteExecuting(parameters);
		}

		/// <inheritdoc />
		public override void CancelExecuting(params object[] parameters) {
			if (ActivityId.IsNotEmpty()) {
				UserConnection.IProcessEngine.RemoveActivityProcessListener(ActivityId, UId,
					ActivityConsts.CanceledStatusUId);
			}
			base.CancelExecuting();
		}

		public override string GetExecutionData() {
			return UserConnection.GetIsFeatureEnabled("UseProcessPerformerAssignment")
				? base.GetExecutionData()
				: EmailSender.GetExecutionData(this);
		}

		/// <summary>
		/// Returns data of the process element notification event.
		/// </summary>
		/// <returns>Instance of the <see cref="ProcessElementNotification"/> type.</returns>
		public override ProcessElementNotification GetNotificationData() {
			ProcessElementNotification notification = base.GetNotificationData();
			ProcessUserTaskUtilities.AssignNotificationData(notification, Subject, StartIn, StartInPeriod);
			return notification;
		}

		public virtual List<string> GetRecipientList() {
			return GetEmailAddresses("Recipient");
		}

		public virtual List<string> GetCopyRecipientList() {
			return GetEmailAddresses("CopyRecipient");
		}

		public virtual List<string> GetBlindCopyRecipientList() {
			return GetEmailAddresses("BlindCopyRecipient");
		}

		public virtual List<EmailAttachment> GetEmailAttachments() {
			var emailAttachments = new List<EmailAttachment>();
			List<ProcessSchemaParameter> parameters = this.GetFilteredOwnParametersList("Attachments");
			foreach (ProcessSchemaParameter parameter in parameters) {
				var parameterValueList = (ICompositeObjectList<ICompositeObject>)GetParameterValue(parameter);
				FillEmailAttachments(emailAttachments, parameter.Name, parameterValueList);
			}
			return emailAttachments;
		}

		public void ExecuteAfterActivitySaveScript(Entity activity) {
			AfterActivitySaveScriptExecute(activity);
		}

		public virtual Entity CreateActivityEntity(EmailMessage message) => CreateActivityEntity(message, true);

		public virtual Entity CreateActivityEntity(EmailMessage message, bool createListener) {
			Subject = message.Subject;
			if (ActivityCategory.IsEmpty()) {
				ActivityCategory = ActivityConsts.EmailActivityCategoryId;
			}
			var remindOffset = new ProcessDateOffset(RemindBefore,
				(ProcessDurationPeriod)RemindBeforePeriod);
			var info = new UserTaskActivityInfo {
				Title = Subject,
				TypeId = ActivityConsts.EmailTypeUId,
				StartOffset = new ProcessDateOffset(StartIn, (ProcessDurationPeriod)StartInPeriod),
				Duration = new ProcessDateOffset(Duration, (ProcessDurationPeriod)DurationPeriod),
				RemindOffset = remindOffset,
				ColumnValues = new Dictionary<string, object> {
					{ "Recepient", message.To.ConcatIfNotEmpty(";") },
					{ "CopyRecepient", message.Cc.ConcatIfNotEmpty(";") },
					{ "BlindCopyRecepient", message.Bcc.ConcatIfNotEmpty(";") },
					{ "Body", message.Body },
					{ "IsHtmlBody", true },
					{ "Sender", message.From },
					{ "MessageTypeId", ActivityConsts.OutgoingEmailTypeId }
				},
				IsSetProcessListener = createListener
			};
			if (!message.HeaderProperties.IsNullOrEmpty()) {
				info.ColumnValues["HeaderProperties"] =
					string.Join("\r\n", message.HeaderProperties.Select(h => $"{h.Name}={h.Value}"));
			}
			Entity activity = this.CreateUserTaskActivity(info);
			IsActivityCompleted = false;
			ActivityId = activity.PrimaryColumnValue;
			AddEmailAttachments(activity, message.Attachments);
			ExecuteAfterActivitySaveScript(activity);
			UserConnection.IProcessEngine.LinkProcessToEntity(Owner, activity.Schema.UId,
				activity.PrimaryColumnValue);
			return activity;
		}

		#endregion

	}

	#endregion

	#region Class: EmailTemplateUserTaskSchemaExtension

	/// <inheritdoc />
	public class EmailTemplateUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		/// <inheritdoc />
		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection, ProcessSchemaUserTask schemaUserTask) {
			var result = new Dictionary<Guid, string>();
			Select select =
				new Select(userConnection).Distinct()
						.Column("ActivityResult", "Id")
						.Column("ActivityResult", "Name")
						.From("ActivityResult")
						.Join(JoinType.Inner, "ActivityCategoryResultEntry")
						.On("ActivityResult", "Id").IsEqual("ActivityCategoryResultEntry", "ActivityResultId")
						.Join(JoinType.Inner, "ActivityCategory")
						.On("ActivityCategoryResultEntry", "ActivityCategoryId").IsEqual("ActivityCategory", "Id")
						.Join(JoinType.Inner, "ActivityType")
						.On("ActivityCategory", "ActivityTypeId").IsEqual("ActivityType", "Id")
						.Where("ActivityType", "Code").IsEqual(Column.Parameter("Email"))
					as Select;
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						result.Add(userConnection.DBTypeConverter.DBValueToGuid(dataReader[0]), dataReader.GetString(1));
					}
				}
			}
			return result;
		}

		/// <inheritdoc />
		public override void SynchronizeDynamicParameters(UserConnection userConnection, ProcessUserTaskSchema target) {
			base.SynchronizeDynamicParameters(userConnection, target);
			ProcessUserTaskUtilities.SynchronizeActivityConnectionParameters(userConnection, target);
		}

		/// <inheritdoc />
		public override void AnalyzePackageDependencies(ProcessSchemaUserTask schemaElement,
				IProcessSchemaPackageDependencyReporter dependencyReporter) {
			base.AnalyzePackageDependencies(schemaElement, dependencyReporter);
			AnalyzeActivityColumnDependencies(schemaElement, dependencyReporter);
			ProcessSchemaParameter sendTypeParameter = schemaElement.Parameters.GetByName("SendEmailType");
			if (!SendEmailType.Manual.ToString("D").Equals(sendTypeParameter.SourceValue.Value,
					StringComparison.OrdinalIgnoreCase)) {
				return;
			}
			AnalyzeEntityColumnDependencies(schemaElement, dependencyReporter, "Activity");
		}

		#endregion

	}

	#endregion

}
