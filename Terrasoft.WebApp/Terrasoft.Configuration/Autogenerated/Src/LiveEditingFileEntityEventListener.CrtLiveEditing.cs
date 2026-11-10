namespace Terrasoft.Configuration.LiveEditing
{
	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.AsyncOperations.Interfaces;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;

	#region Class: LiveEditingFileEntityEventListener

	/// <inheritdoc />
	[EntityEventListener(IsGlobal = true)]
	public class LiveEditingFileEntityEventListener : BaseEntityEventListener {
		#region Properties: Private

		private static readonly string _sysFileSchemaName = "SysFile";

		#endregion

		#region Properties: Protected

		private ILog _log;
		protected ILog Log {
			get
			{
				return _log ?? (_log = LogManager.GetLogger("LiveEditing"));
			}
		}

		#endregion

		#region Methods: Private

		private static bool IsLiveEditingEnabled(UserConnection userConnection) {
			return userConnection.GetIsFeatureEnabled("LiveEditingForCurrentUser") &&
				userConnection.GetIsFeatureEnabled("LiveEditing") &&
				!userConnection.GetIsFeatureEnabled("DisableLiveEditingFile");
		}

		private static bool IsLiveEditingEnabledForSchema(string schemaName, UserConnection userConnection) {
			var schema = userConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			return schema != null ? schema.UseLiveEditing : false;
		}

		private static string GetFileEntityRecordSchemaName(Entity entity) {
			if (entity.SchemaName.Equals(_sysFileSchemaName)) {
				return entity.GetTypedColumnValue<string>("RecordSchemaName");
			}
			return entity.SchemaName.EndsWith("File") ? entity.SchemaName.Remove(entity.SchemaName.Length - "File".Length) : entity.SchemaName;
		}

		private void ProcessFileLiveEditingEvent(Entity entity, EventArgs eventArgs, LiveEditingEventType eventType) {
			try {
				var userConnection = entity.UserConnection;
				if (ShouldNotify(entity, userConnection)) {
					var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
						new ConstructorArgument("userConnection", entity.UserConnection));
					var operationArgs = GetOperationArgs(entity, eventArgs, eventType);
					asyncExecutor.ExecuteAsync<EntityEventsNotifyAsyncOperation>(operationArgs);
				}
			} catch (Exception ex) {
				Log.ErrorFormat("LiveEditingFileEntityEventListener: Could not notify about {0} entity {1}, id = {2}",
					ex, eventType, entity.SchemaName, entity.PrimaryColumnValue);
			}
		}

		private bool IsFileOrSubclass(Entity entity) {
			return entity.Schema.GetIsAncestorOf("File");
		}

		#endregion

		#region Methods: Protected

		protected bool ShouldNotify(Entity entity, UserConnection userConnection)	{
			var fileEntityRecordSchemaName = GetFileEntityRecordSchemaName(entity);
			return !entity.SkipLiveEditing && IsLiveEditingEnabledForSchema(fileEntityRecordSchemaName, userConnection);
		}

		protected NotifyEntityEventAsyncOperationArgs GetOperationArgs(Entity entity, EventArgs eventArgs, LiveEditingEventType eventType) {
			return entity.SchemaName.Equals(_sysFileSchemaName) ?
				new NotifyEntityEventAsyncOperationArgs(entity, eventArgs, eventType, new List<string>() { "RecordId" }) :
				new NotifyEntityEventAsyncOperationArgs(entity, eventArgs, eventType);
		}

		#endregion

		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			Entity entity = (Entity)sender;
			if (!IsLiveEditingEnabled(entity.UserConnection) || !IsFileOrSubclass(entity)) {
				return;
			}
			ProcessFileLiveEditingEvent(entity, e, LiveEditingEventType.Inserted);
		}

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			Entity entity = (Entity)sender;
			if (!IsLiveEditingEnabled(entity.UserConnection) || !IsFileOrSubclass(entity)) {
				return;
			}
			ProcessFileLiveEditingEvent((Entity)sender, e, LiveEditingEventType.Updated);
		}

		#endregion
	}


	#endregion

} 
