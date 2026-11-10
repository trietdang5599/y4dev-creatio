namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading;
	using global::Common.Logging;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Common;

	#region Class: DeleteLinkedSysFileEntityEventListener
	/// <summary>
	/// Listener for 'BaseEntity' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener"/>
    [EntityEventListener(SchemaName = "BaseEntity")]
	public class DeleteLinkedSysFileEntityEventListener : BaseEntityEventListener
	{

		#region Constants: Private

		private const int QueryBatchSize = 250;
		private const string FileSchemaName = "SysFile";

		#endregion
		
        #region Fields: Private

        private static readonly ILog _log = LogManager.GetLogger(typeof(DeleteLinkedSysFileEntityEventListener));

        #endregion

        #region Methods: Private
		private IEnumerable<Guid> GetLinkedFiles(UserConnection userConnection, string entitySchemaName, Guid entityId) {
			var select = new Select(userConnection)
				.Column("Id")
				.From(FileSchemaName)
				.Where("RecordSchemaName").IsEqual(Column.Parameter(entitySchemaName))
				.And("RecordId").IsEqual(Column.Parameter(entityId))
			as Select;
			select.SpecifyNoLockHints();
			return select.ExecuteEnumerable(f => f.GetColumnValue<Guid>("Id")).ToList();
		} 
        private void MarkToDeleteEntityFiles(UserConnection userConnection,
				string entitySchemaName, Entity entity) {
			var entityId = entity.PrimaryColumnValue;
			_log.Debug($"Mark for deleting {entitySchemaName} files with Id={entityId}.");
			var currentDateTime = userConnection.CurrentUser.GetCurrentDateTime().ToUniversalTime();
			var updatedRecords = 0;
			var count = 0;
			var fileList = GetLinkedFiles(userConnection, entitySchemaName, entityId);
            var totalCount = fileList.Count();
			while (count < totalCount) {
				var batch = fileList.Skip(count).Take(QueryBatchSize);
				var update = new Update(userConnection, FileSchemaName)
					.Set("ToDelete", Column.Parameter(true))
					.Set("ModifiedOn", Column.Parameter(currentDateTime))
					.Where("Id").In(Column.Parameters(batch)) as Update;
				update.WithHints(new RowLockHint());
				updatedRecords += update.Execute();
				count += QueryBatchSize;
				Thread.Sleep(50);
			}
			_log.Debug($"{updatedRecords} files marked for deletion.");
		}

		#endregion

        #region Methods: Public

        /// <summary>
        /// Handles entity Deleted event.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">The <see cref="EntityAfterEventArgs"/> instance containing the event data.</param>
        public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			if (userConnection.GetIsFeatureEnabled("DisableDeleteLinkedFiles")) {
				return;
			}
			try {
				string entitySchemaName = entity.SchemaName;
				MarkToDeleteEntityFiles(userConnection, entitySchemaName, entity);
			} catch (Exception ex) {
				_log.Error($"There was an error while deleting entity files. {ex}");
			}
		}

		#endregion
	}

	#endregion

}
