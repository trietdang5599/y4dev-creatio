namespace Terrasoft.Configuration.LiveEditing
{
	using System;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.AsyncOperations.Interfaces;
	using Terrasoft.Core.Entities.AsyncOperations;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using System.Linq;
	using System.Collections.Immutable;
	using System.Collections.Generic;

	#region Class: NotifyEntityEventAsyncOperationArgs

	public class NotifyEntityEventAsyncOperationArgs : EntityEventAsyncOperationArgs
	{
		public NotifyEntityEventAsyncOperationArgs(Entity entity, EventArgs eventArgs, LiveEditingEventType eventType, List<string> additionalConnectedColumns = null)
			: base(entity, eventArgs) {
			EventType = eventType;
			PrimaryColumnValue = entity.PrimaryColumnValue;
			PrimaryColumnName = entity.Schema.PrimaryColumn.Name;
			ModifiedById = entity.GetTypedColumnValue<Guid>("ModifiedById");
			ModifiedOn = entity.GetTypedColumnValue<DateTime>("ModifiedOn");
			var entityAfterEventArgs = eventArgs as EntityAfterEventArgs;
			if (entityAfterEventArgs != null) {
				ColumnNames = (entityAfterEventArgs.ModifiedColumnValues?.Select(columnValue => columnValue.Column.Name)
					?? new List<string>()).ToImmutableList();
			};
			var connectedLiveEditingColumns = entity.GetChangedColumnValues()
				.Where(c => c.Column.IsLookupType && c.Column.ReferenceSchema.UseLiveEditing && c.Value != default)
				.ToDictionary(c => c.Name, c => c.Value);
			AddAditionalConnectedColumns(entity, additionalConnectedColumns, connectedLiveEditingColumns);
			if (connectedLiveEditingColumns.Any() && entity.UserConnection.CurrentUser.ConnectionType != UserType.SSP) {
				ConnectedLiveSchemaColumns = connectedLiveEditingColumns.ToImmutableDictionary();
			}
		}

		private static void AddAditionalConnectedColumns(Entity entity, List<string> additionalConnectedColumns, Dictionary<string, object> connectedLiveEditingColumns) {
			if (additionalConnectedColumns != null) {
				foreach (var additionalConnectedColumn in additionalConnectedColumns) {
					if (entity.Schema.Columns.FindByName(additionalConnectedColumn) is EntitySchemaColumn column) {
						connectedLiveEditingColumns[column.Name] = entity.GetTypedColumnValue<object>(column.Name);
					}
				}
			}
		}

		/// <summary>
		/// Type of event.
		/// </summary>
		public LiveEditingEventType EventType {
			get;
		}

		/// <summary>
		/// Entity primary column name.
		/// </summary>
		public string PrimaryColumnName {
			get; set;
		}

		/// <summary>
		/// Entity primary column value.
		/// </summary>
		public Guid PrimaryColumnValue {
			get; set;
		}

		/// <summary>
		/// Id of user who made action.
		/// </summary>
		public Guid ModifiedById {
			get; set;
		}

		/// <summary>
		/// Timestamp of triggered event.
		/// </summary>
		public DateTime ModifiedOn {
			get; set;
		}

		/// <summary>
		/// List of column names affected by operation.
		/// </summary>
		public ImmutableList<string> ColumnNames {
			get; set;
		}

		/// <summary>
		/// List of connected live schema column values.
		/// </summary>
		public ImmutableDictionary<string, object> ConnectedLiveSchemaColumns {
			get; set;
		}
	}

	#endregion

	#region Class: EntityEventsNotifyAsyncOperation
	/// <inheritdoc />
	public class EntityEventsNotifyAsyncOperation : IEntityEventAsyncOperation {

		#region Methods: Public

		/// <inheritdoc />
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs args) {
			EntityEventsWebsocketNotifierAsync.Instance.NotifyCurrentUser(userConnection, (NotifyEntityEventAsyncOperationArgs)args);
		}

		#endregion

	}

	#endregion

	#region Class: LiveEditingBaseEntityEventListener

	/// <inheritdoc />
	[EntityEventListener(SchemaName = "BaseEntity")]
	public class LiveEditingBaseEntityEventListener : BaseEntityEventListener
	{

		#region Properties: Private

		private Guid _activityEmailType = new Guid("E2831DEC-CFC0-DF11-B00F-001D60E938C6");

		#endregion

		#region Properties: Protected

		private ILog _log;
		protected ILog Log {
			get	{
				return _log ?? (_log = LogManager.GetLogger("LiveEditing"));
			}
		}

		#endregion

		#region Methods: Private

		private bool NeedNotify(Entity entity, UserConnection userConnection) {
			return userConnection.GetIsFeatureEnabled("LiveEditingForCurrentUser") && entity.Schema.UseLiveEditing && !entity.SkipLiveEditing;
		}

		private bool IsNeedToSkip(Entity entity, LiveEditingEventType eventType) {
			return IsNeedToSkipEmailUpdate(entity, eventType);
		}

		private bool IsNeedToSkipEmailUpdate(Entity entity, LiveEditingEventType eventType) {
			return eventType == LiveEditingEventType.Updated && entity.SchemaName == "Activity"
				&& entity.GetTypedColumnValue<Guid>("TypeId") == _activityEmailType
				&& entity.UserConnection.GetIsFeatureEnabled("LiveEditingSkipEmail");
		}

		private void NotifyAsynchronously(Entity entity, EventArgs eventArgs, LiveEditingEventType eventType) {
			try {
				var userConnection = entity.UserConnection;
				if (!userConnection.GetIsFeatureEnabled("LiveEditing")) {
					return;
				}
				if (NeedNotify(entity, userConnection) && !IsNeedToSkip(entity, eventType)) {
					var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
						new ConstructorArgument("userConnection", entity.UserConnection));
					var operationArgs = new NotifyEntityEventAsyncOperationArgs(entity, eventArgs, eventType);
					asyncExecutor.ExecuteAsync<EntityEventsNotifyAsyncOperation>(operationArgs);
				}
			}
			catch (Exception ex) {
				Log.ErrorFormat("Could not notify about {0} entity {1}, id = {2}",
					ex, eventType, entity.SchemaName, entity.PrimaryColumnValue);
			}
		}

		#endregion

		#region Methods: Public

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			NotifyAsynchronously((Entity)sender, e, LiveEditingEventType.Updated);
		}

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			NotifyAsynchronously((Entity)sender, e, LiveEditingEventType.Inserted);
		}

		#endregion
	}

	#endregion

}
