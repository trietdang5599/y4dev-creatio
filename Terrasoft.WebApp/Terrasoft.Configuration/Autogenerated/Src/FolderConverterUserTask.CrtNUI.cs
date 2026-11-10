namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Linq;
	using Terrasoft.Configuration;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Process;

	#region Class: FolderConverterUserTask

	/// <exclude/>
	public partial class FolderConverterUserTask
	{

		#region Properties: Private
		
		private Guid EntitySchemaUId => UserConnection.EntitySchemaManager.FindInstanceByName(EntitySchemaName).UId;
		
		#endregion

		#region Methods: Private

		private string GetNotificationMessage() {
			var newFolderName = GetEntityFolderName(NewFolderId);
			var sectionName = GetEntitySectionCaption();
			return string.Format(NotificationMessageLocalized, ProcessedEntriesAmount, newFolderName, sectionName);
		}

		private string GetEntitySectionCaption() {
			var sysModuleESQ = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysModule");
			sysModuleESQ.AddColumn("Caption");
			IEntitySchemaQueryFilterItem sysAdminFolderFilter = sysModuleESQ.CreateFilterWithParameters(
				FilterComparisonType.Equal,
				"SysModuleEntity.SysEntitySchemaUId",
				EntitySchemaUId);
			sysModuleESQ.Filters.Add(sysAdminFolderFilter);
			sysModuleESQ.RowCount = 1;
			EntityCollection sysModuleCollection = sysModuleESQ.GetEntityCollection(UserConnection); 
			string caption = sysModuleCollection.FirstOrDefault()?.GetTypedColumnValue<string>("Caption") ?? string.Empty;
			return caption;
		}

		private string GetEntityFolderName(Guid folderId) {
			var folderQuery = new Select(UserConnection).Top(1)
				.Column("Name")
				.From($"{EntitySchemaName}Folder")
				.Where("Id")
				.IsEqual(Column.Parameter(folderId)) as Select;
			var folderName = folderQuery?.ExecuteScalar<string>();
			return folderName;
			
		}

		private void SendNotificationMessage() {
			var loaderSchema = UserConnection.SourceCodeSchemaManager.FindInstanceByName("FolderConverter");
			var config = new RemindingConfig(EntitySchemaUId) {  
				AuthorId = UserConnection.CurrentUser.ContactId,
				ContactId = UserConnection.CurrentUser.ContactId,
				LoaderId = loaderSchema.UId,
				RemindTime = DateTime.UtcNow,
				Description = GetNotificationMessage(),
			};
			var remindingUtilities = ClassFactory.Get<RemindingUtilities>();
			remindingUtilities.CreateReminding(UserConnection, config);
		}

		#endregion

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			FolderConverter folderConverter = ClassFactory.Get<FolderConverter>(
					new ConstructorArgument("userConnection", UserConnection));
			ProcessedEntriesAmount =
			folderConverter.ConvertToStaticFolder(NewFolderId, ParentFolderId, EntitySchemaName);
			SendNotificationMessage();
			return true;
		}

		#endregion

		#region Methods: Public

		public override bool CompleteExecuting(params object[] parameters) {
			return base.CompleteExecuting(parameters);
		}

		public override void CancelExecuting(params object[] parameters) {
			base.CancelExecuting(parameters);
		}

		public override string GetExecutionData() {
			return string.Empty;
		}

		public override ProcessElementNotification GetNotificationData() {
			return base.GetNotificationData();
		}

		#endregion

	}

	#endregion

}

