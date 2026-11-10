namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Collections.Generic;
    using System.Data;
    using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
    using Terrasoft.Core.DB;
    using Terrasoft.Core.Entities;
	
	#region Interface: IOperatorSessionRepository

	/// <summary>
	/// Interface for working with operator session.
	/// </summary>
	public interface IOperatorSessionRepository
	{
		/// <summary>
		/// Loads <paramref name="chatOperator"/> fields from database.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		void LoadOperatorState(ChatOperator chatOperator);

		/// <summary>
		/// Gets operators states by operator identifiers.
		/// </summary>
		/// <param name="operatorIds">List of operator identifiers.</param>
		/// <returns>Dictionary of operator states keyed by operator identifier.</returns>
		Dictionary<Guid, OperatorState> GetOperatorsStates(List<Guid> operatorIds);

		/// <summary>
		/// Returns all active operators list.
		/// </summary>
		/// <returns><see cref="ChatOperator"/> list.</returns>
		List<ChatOperator> GetAllActiveOperators();

		/// <summary>
		/// Get the current operator state id.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns>Current operator state.</returns>
		OperatorState GetOperatorState(Guid operatorId);

		/// <summary>
		/// Creating an active operator session.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="stateId">Operator state identifier.</param>
		void CreateOperatorSession(Guid operatorId, Guid stateId = default);

		/// <summary>
		/// Updates operator last activity date.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		void UpdateLastActivityDate(Guid operatorId);
	}

	#endregion

	#region Class: OperatorSessionRepository

	/// <summary>
	/// Repository for working with operator session.
	/// </summary>
	public class OperatorSessionRepository : IOperatorSessionRepository
	{

		#region Constants: Private

		/// <summary>
		/// Operator session schema name.
		/// </summary>
		private const string _operatorSessionSchemaName = "OperatorSession";

		#endregion

		#region Fields: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private readonly UserConnection _userConnection;

		/// <summary>
		/// <see cref="ChatOperatorCache"/> instance.
		/// </summary>
		private readonly ChatOperatorCache _chatOperatorCache;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="OperatorSessionRepository"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		public OperatorSessionRepository(UserConnection userConnection) : this(userConnection, new ChatOperatorCache(userConnection)) {
		}

		/// <summary>
		/// Initializes new instance of <see cref="OperatorSessionRepository"/>.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="cache">Operators cache instance.</param>
		public OperatorSessionRepository(UserConnection userConnection, ChatOperatorCache cache) {
			_userConnection = userConnection;
			_chatOperatorCache = cache;
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns query for the operation session object schema.
		/// </summary>
		/// <returns>Instance of <see cref="EntitySchemaQuery"/></returns>
		private EntitySchemaQuery CreateOperatorSessionEsq() {
			var esq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, _operatorSessionSchemaName);
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn("SessionStartDate").OrderDirection = OrderDirection.Descending;
			return esq;
		}

		/// <summary>
		/// Add filter by operator and unfinished session.
		/// </summary>
		/// <param name="esq">Instance of <see cref="EntitySchemaQuery"/></param>
		/// <param name="operatorId">Operator identifier.</param>
		private void FilterSessionByOperator(EntitySchemaQuery esq, Guid operatorId) {
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysUser", operatorId));
			esq.Filters.Add(esq.CreateIsNullFilter("SessionEndDate"));
		}

		/// <summary>
		/// Add new session for operator.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="stateId">Operator state identifier.</param>
		private void CreateNewOperatorSession(Guid operatorId, Guid stateId) {
			var operatorSessionSchema = _userConnection.EntitySchemaManager.GetInstanceByName(_operatorSessionSchemaName);
			Entity operatorSessionEntity = operatorSessionSchema.CreateEntity(_userConnection);
			operatorSessionEntity.SetDefColumnValues();
			operatorSessionEntity.SetColumnValue("SysUserId", operatorId);
			operatorSessionEntity.SetColumnValue("OperatorStateId", stateId);
			operatorSessionEntity.SetColumnValue("SessionStartDate", _userConnection.CurrentUser.GetCurrentDateTime());
			operatorSessionEntity.Save();
		}

		/// <summary>
		/// Set the end date of the operator's session.
		/// </summary>
		/// <param name="sessions"><see cref="EntityCollection"/> sessions collection.</param>
		private void CompleteSessions(EntityCollection sessions) {
			sessions.ForEach(session => {
				var sessionEnded = _userConnection.CurrentUser.GetCurrentDateTime();
				var sessionStarted = session.GetTypedColumnValue<DateTime>("SessionStartDate");
				session.SetColumnValue("SessionEndDate", sessionEnded);
				if (sessionStarted != DateTime.MinValue) {
					var duration = (int)sessionEnded.Subtract(sessionStarted).TotalMinutes;
					session.SetColumnValue("Duration", duration);
				}
				session.Save(false);
			});
		}

		/// <summary>
		/// Get incomplete sessions.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns><see cref="EntityCollection"/> sessions collection.</returns>
		private EntityCollection GetIncompleteSessionsByOperator(Guid operatorId) {
			var esq = CreateOperatorSessionEsq();
			esq.AddColumn("OperatorState.Code").Name = "StateCode";
			esq.AddAllSchemaColumns();
			FilterSessionByOperator(esq, operatorId);
			return esq.GetEntityCollection(_userConnection);
		}

		/// <summary>
		/// Updates operator state in operatooors cache.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="stateId">Operator state identifier.</param>
		/// <returns>Action result.</returns>
		private bool UpdateOperatorInCache(Guid operatorId, Guid stateId) {
			ChatOperator chatOperator = _chatOperatorCache.GetOperator(operatorId);
			if (chatOperator == null) {
				return false;
			}
			chatOperator.State = GetState(stateId);
			_chatOperatorCache.UpdateOperatorInCache(chatOperator);
			return true;
		}

		/// <summary>
		/// Loads <see cref="OperatorState"/> from storage.
		/// </summary>
		/// <param name="stateId">Operator state identifier.</param>
		/// <returns><see cref="OperatorState"/> instance.</returns>
		private OperatorState GetState(Guid stateId) {
			var entitySchema = _userConnection.EntitySchemaManager.GetInstanceByName("OperatorState");
			var entity = entitySchema.CreateEntity(_userConnection);
			if (entity.FetchFromDB(stateId)) {
				return new OperatorState {
					Id = stateId,
					Code = entity.GetTypedColumnValue<string>("Code"),
					OperatorAvailable = entity.GetTypedColumnValue<bool>("OperatorAvailable")
				};
			}
			return new OperatorState {
				Id = OmnichannelMessagingConsts.OperatorState.Inactive.Id,
				Code = OmnichannelMessagingConsts.OperatorState.Inactive.Code,
				OperatorAvailable = OmnichannelMessagingConsts.OperatorState.Inactive.OperatorAvailable
			};
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Loads <paramref name="chatOperator"/> fields from database.
		/// </summary>
		/// <param name="chatOperator"><see cref="ChatOperator"/> instance.</param>
		public void LoadOperatorState(ChatOperator chatOperator) {
			var incompleteSessions = GetIncompleteSessionsByOperator(chatOperator.UserId);
			var lastSession = incompleteSessions.FirstOrDefault();
			chatOperator.State = lastSession != null
				? GetState(lastSession.GetTypedColumnValue<Guid>("OperatorStateId"))
				: new OperatorState {
					Id = OmnichannelMessagingConsts.OperatorState.Inactive.Id,
					Code = OmnichannelMessagingConsts.OperatorState.Inactive.Code,
					OperatorAvailable = OmnichannelMessagingConsts.OperatorState.Inactive.OperatorAvailable
				};
		}

		public Dictionary<Guid, OperatorState> GetOperatorsStates(List<Guid> operatorIds) {
			Select operatorsSelect = new Select(_userConnection)
				.Column("OS", "SysUserId")
                .Column("OS", "OperatorStateId")
				.Column("OST","Code")
                .Column("OST","OperatorAvailable")
				.From("OperatorSession", "OS")
				.InnerJoin("OperatorState").As("OST")
					.On("OS", "OperatorStateId").IsEqual("OST", "Id")
				.Where("OS", "SessionEndDate").IsNull()	
                .And("OS", "SysUserId").In(Column.Parameters(operatorIds)) as Select;
			var operatorsStates = new Dictionary<Guid, OperatorState>();
			using (DBExecutor executor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = operatorsSelect.ExecuteReader(executor)) {
					while (reader.Read()) {
						var operatorId = reader.GetColumnValue<Guid>("SysUserId");
						if (!operatorsStates.ContainsKey(operatorId)) {
							operatorsStates[operatorId] = new OperatorState {
								Id = reader.GetColumnValue<Guid>("OperatorStateId"),
								Code = reader.GetColumnValue<string>("Code"),
								OperatorAvailable = reader.GetColumnValue<bool>("OperatorAvailable")
							};
						}
					}
				} 
			}

			var operatorsWithoutOpenSessions = operatorIds.Except(operatorsStates.Keys);
			operatorsWithoutOpenSessions.ForEach(operatorId => {
				operatorsStates[operatorId] = new OperatorState {
					Id = OmnichannelMessagingConsts.OperatorState.Inactive.Id,
					Code = OmnichannelMessagingConsts.OperatorState.Inactive.Code,
					OperatorAvailable = OmnichannelMessagingConsts.OperatorState.Inactive.OperatorAvailable
				};
			});
            return operatorsStates;
        }
        /// <summary>
        /// Returns all active operators list.
        /// </summary>
        /// <returns><see cref="ChatOperator"/> list.</returns>
        public List<ChatOperator> GetAllActiveOperators() {
			var operatorsCache = _chatOperatorCache.GetOperatorsCache();
			return operatorsCache.Where(o => o.Active).ToList();
		}

		/// <summary>
		/// Get the current operator state id.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <returns>Current operator state.</returns>
		public OperatorState GetOperatorState(Guid operatorId) {
			var chatOperator = _chatOperatorCache.GetOperator(operatorId);
			 return chatOperator?.State ?? new OperatorState {
				Id = OmnichannelMessagingConsts.OperatorState.Inactive.Id,
				Code = OmnichannelMessagingConsts.OperatorState.Inactive.Code,
				OperatorAvailable = OmnichannelMessagingConsts.OperatorState.Inactive.OperatorAvailable
			};
		}

		/// <summary>
		/// Creating an active operator session.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		/// <param name="stateId">Operator state identifier.</param>
		public void CreateOperatorSession(Guid operatorId, Guid stateId = default) {
			if (stateId == Guid.Empty) {
				stateId = OmnichannelMessagingConsts.OperatorState.Active.Id;
			}
			if (!UpdateOperatorInCache(operatorId, stateId)) {
				return;
			}
			var incompleteSessions = GetIncompleteSessionsByOperator(operatorId);
			var lastSession = incompleteSessions.FirstOrDefault();
			if (lastSession != null && lastSession.GetTypedColumnValue<Guid>("OperatorStateId") == stateId) {
				incompleteSessions.RemoveFirst();
				CompleteSessions(incompleteSessions);
			} else {
				CompleteSessions(incompleteSessions);
				CreateNewOperatorSession(operatorId, stateId);
			}
		}

		/// <summary>
		/// Updates operator last activity date.
		/// </summary>
		/// <param name="operatorId">Operator identifier.</param>
		public void UpdateLastActivityDate(Guid operatorId) {
			var incompleteSessions = GetIncompleteSessionsByOperator(operatorId);
			incompleteSessions
				.Where(s => s.GetTypedColumnValue<Guid>("OperatorStateId") == OmnichannelMessagingConsts.OperatorState.Active.Id)
				.ForEach(session => {
					session.SetColumnValue("LastActivityDate", _userConnection.CurrentUser.GetCurrentDateTime());
					session.Save(false);
				});
		}

		#endregion

	}

	#endregion

}
