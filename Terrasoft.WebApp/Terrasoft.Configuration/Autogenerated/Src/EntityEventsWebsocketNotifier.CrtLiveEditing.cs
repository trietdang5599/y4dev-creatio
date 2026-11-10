namespace Terrasoft.Configuration.LiveEditing {
	using global::Common.Logging;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Timers;
	using Newtonsoft.Json;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using System.Collections.Concurrent;

	#region Class: EntityEventsWebsocketNotifier

	[Obsolete("Use EntityEventsWebsocketNotifierAsync instead.")]
	public class EntityEventsWebsocketNotifier
	{

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public EntityEventsWebsocketNotifier(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		/// <summary>
		/// Notifies current user about changes at entity.
		/// </summary>
		/// <param name="entity">Base live editing entity.</param>
		/// <param name="entityEventArguments">Entite event arguments.</param>
		/// <param name="eventType">Type of entity event.</param>
		[Obsolete("Use EntityEventsWebsocketNotifierAsync instead.")]
		public void NotifyCurrentUser(Entity entity, EntityAfterEventArgs entityEventArguments, LiveEditingEventType eventType) {
			var args = new NotifyEntityEventAsyncOperationArgs(entity, entityEventArguments, eventType);
			EntityEventsWebsocketNotifierAsync.Instance.NotifyCurrentUser(_userConnection, args);
		}

		#endregion
	}

	#endregion

	#region Class: EntityEventsWebsocketNotifierAsync

	public sealed class EntityEventsWebsocketNotifierAsync
	{

		#region Interface: IEventWorker

		private interface IEventWorker {
			void SendEvent(EntityLiveEditingEventData data, UserConnection userConnection);
		}

		#endregion

		#region Class: UpdateEventWorker

		private class UpdateEventWorker : IEventWorker {

			#region Class: TimerData

			private class TimerData {
				public EntityLiveEditingEventData Data;
				public bool IsChanged = false;
				public UserConnection UserConnection;
			}

			#endregion

			#region Fields: Private

			private static readonly ConcurrentDictionary<Guid, TimerData> _queue = new ConcurrentDictionary<Guid, TimerData>();

			#endregion

			#region Methods: Private

			private void AddConnectedLiveSchemaColumns(EntityLiveEditingEventData data, Dictionary<string, object> connectedLiveSchemaColumns) {
				if (connectedLiveSchemaColumns != null) {
					if (data.ConnectedLiveSchemaColumns == null) {
						data.ConnectedLiveSchemaColumns = new Dictionary<string, object>();
					}
					data.ConnectedLiveSchemaColumns.AddRangeIfNotExists(data.ConnectedLiveSchemaColumns);
				}
			}

			private void TimerHandler(object sender, ElapsedEventArgs e, TimerData timerData, Guid entityRecordId) {
				var timer = (Timer)sender;
				var eventData = timerData.Data;
				if (timerData.IsChanged) {
					timerData.IsChanged = false;
				} else {
					if (eventData != null) {
						MsgChannelUtilities.PostMessage(timerData.UserConnection, _websocketSenderName, JsonConvert.SerializeObject(eventData));
						timerData.Data = null;
					} else {
						timer.Stop();
						_queue.TryRemove(entityRecordId, out _);
						timerData.UserConnection = null;
						_log.DebugFormat("Update Timer was stopped for id = {0}. Items count in queue = {1}", entityRecordId, _queue.Count);
						timer.Dispose();
					}
				}
			}

			#endregion

			#region Methods: Public

			public void SendEvent(EntityLiveEditingEventData data, UserConnection userConnection) {
				Guid entityRecordId = data.PrimaryColumnValue;
				if (_queue.TryGetValue(entityRecordId, out var storedData)) {
					if (storedData.Data == null) {
						storedData.Data = data;
					} else {
						storedData.Data.ColumnNames.AddRangeIfNotExists(data.ColumnNames);
						AddConnectedLiveSchemaColumns(storedData.Data, data.ConnectedLiveSchemaColumns);
					}
					storedData.IsChanged = true;
					_log.DebugFormat("Columns [{0}] was changed for {1} with id = {2}",
						string.Join(",", data.ColumnNames), data.EntitySchemaName, entityRecordId);
				} else {
					var timerData = new TimerData {
						UserConnection = userConnection
					};
					Timer timer = new Timer(_timerInterval);
					timer.Elapsed += (sender, e) => TimerHandler(sender, e, timerData, entityRecordId);
					timer.Start();
					_queue.TryAdd(entityRecordId, timerData);
					_log.DebugFormat("Update Timer was started for {0} with id = {1}", data.EntitySchemaName, entityRecordId);
					MsgChannelUtilities.PostMessage(userConnection, _websocketSenderName, JsonConvert.SerializeObject(data));
				}
			}

			#endregion

		}

		#endregion

		#region Class: InsertEventWorker

		private class InsertEventWorker : IEventWorker {

			#region Class: TimerData

			private class TimerData {
				public Queue<EntityLiveEditingEventData> RecordQueue = new Queue<EntityLiveEditingEventData>();
				public UserConnection UserConnection;
			}

			#endregion

			#region Fields: Private

			private static readonly ConcurrentDictionary<string, TimerData> _queue = new ConcurrentDictionary<string, TimerData>();

			#endregion

			#region Constructors: Public

			public InsertEventWorker() {
			}

			#endregion

			#region Methods: Private

			private void TimerHandler(object sender, ElapsedEventArgs e, TimerData timerData, string queueKey) {
				var timer = (Timer)sender;
				if (timerData.RecordQueue.Any()) {
					MsgChannelUtilities.PostMessage(timerData.UserConnection, _websocketSenderName,
						JsonConvert.SerializeObject(timerData.RecordQueue.Dequeue()));
				} else {
						timer.Stop();
						_queue.TryRemove(queueKey, out _);
						timerData.UserConnection = null;
						_log.DebugFormat("Insert Timer was stopped for id = {0}. Items count in queue = {1}", queueKey, _queue.Count);
						timer.Dispose();
				}
			}


			#endregion

			#region Methods: Public

			public void SendEvent(EntityLiveEditingEventData data, UserConnection userConnection) {
				var queueKey = data.EntitySchemaName + userConnection.CurrentUser.ContactId;
				if (_queue.TryGetValue(queueKey, out var storedData)) {
					storedData.RecordQueue.Enqueue(data);
					_log.DebugFormat("Record was added for {0} with id = {1}", data.EntitySchemaName, data.PrimaryColumnValue);
				} else {
					var timerData = new TimerData {
						UserConnection = userConnection
					};
					Timer timer = new Timer(_timerInterval);
					timer.Elapsed += (sender, e) => TimerHandler(sender, e, timerData, queueKey);
					timer.Start();
					_queue.TryAdd(queueKey, timerData);
					_log.DebugFormat("Insert Timer was started for {0} with id = {1}", data.EntitySchemaName, data.PrimaryColumnValue);
					MsgChannelUtilities.PostMessage(userConnection, _websocketSenderName, JsonConvert.SerializeObject(data));
				}
			}

			#endregion

		}

		#endregion

		#region Constants: Private

		private const string _websocketSenderName = "LiveEditingNotifier";
		private static readonly uint _timerInterval = 1000;

		#endregion

		#region Fields: Private

		private static EntityEventsWebsocketNotifierAsync _instance = null;
		private static readonly object _lockObject = new object();
		private static ILog _log = LogManager.GetLogger("LiveEditing");
		private readonly Dictionary<LiveEditingEventType, IEventWorker> _liveUpdateWorkers = 
			new Dictionary<LiveEditingEventType, IEventWorker>();

		#endregion

		#region Properties: Public

		public static EntityEventsWebsocketNotifierAsync Instance {
			get {
				if (_instance == null) {
					lock (_lockObject) {
						if (_instance == null) {
							_instance = new EntityEventsWebsocketNotifierAsync();
						}
					}
				}
				return _instance;
			}
		}

		#endregion

		#region Constructors: Private

		private EntityEventsWebsocketNotifierAsync() {
			_liveUpdateWorkers.Add(LiveEditingEventType.Updated, new UpdateEventWorker());
			_liveUpdateWorkers.Add(LiveEditingEventType.Inserted, new InsertEventWorker());
		}

		#endregion

		#region Methods: Private

		private EntityLiveEditingEventData GetEventData(NotifyEntityEventAsyncOperationArgs operationArgs, LiveEditingEventType eventType) {
			switch (eventType) {
				case LiveEditingEventType.Inserted:
					return GetInsertedEventData(operationArgs);
				case LiveEditingEventType.Updated:
					return GetUpdatedEventData(operationArgs);
				case LiveEditingEventType.Deleted:
					throw new NotImplementedException();
				default:
					throw new NotImplementedException();
			}

		}

		private T GetBaseEventData<T>(NotifyEntityEventAsyncOperationArgs args, LiveEditingEventType eventType) where T : EntityLiveEditingEventData, new() {
			T eventData = new T();
			eventData.EventType = eventType;
			eventData.EntitySchemaName = args.EntitySchemaName;
			eventData.PrimaryColumnValue = args.PrimaryColumnValue;
			eventData.PrimaryColumnName = args.PrimaryColumnName;
			eventData.ModifiedById = args.ModifiedById;
			eventData.ModifiedOn = args.ModifiedOn;
			eventData.ConnectedLiveSchemaColumns = args.ConnectedLiveSchemaColumns?.ToDictionary(k => k.Key, v => v.Value);
			return eventData;
		}

		private EntityLiveEditingEventData GetUpdatedEventData(NotifyEntityEventAsyncOperationArgs args) {
			EntityLiveEditingEventData eventData = GetBaseEventData<EntityLiveEditingEventData>(args, LiveEditingEventType.Updated);
			eventData.ColumnNames = args.ColumnNames.ToList();
			return eventData;
		}

		private EntityLiveEditingEventData GetInsertedEventData(NotifyEntityEventAsyncOperationArgs args) {
			return GetBaseEventData<EntityLiveEditingEventData>(args, LiveEditingEventType.Inserted);
		}			

		#endregion

		#region Methods: Public

		/// <summary>
		/// Notifies current user about changes at entity.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="operationArgs">Entity event arguments.</param>
		public void NotifyCurrentUser(UserConnection userConnection, NotifyEntityEventAsyncOperationArgs operationArgs) {
			EntityLiveEditingEventData eventData = GetEventData(operationArgs, operationArgs.EventType);
			_liveUpdateWorkers[operationArgs.EventType].SendEvent(eventData, userConnection);
		}

		#endregion

	}

	#endregion
}
