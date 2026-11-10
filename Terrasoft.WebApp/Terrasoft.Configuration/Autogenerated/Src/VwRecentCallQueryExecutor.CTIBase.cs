namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core.DB;
	using System.Data;
	using Terrasoft.Core.Configuration;

	#region Class: VwRecentCallQueryExecutor
	/// <summary>
	/// Implementation <see cref="IEntityQueryExecutor"/> for 'VwRecentCall' entity.
	/// </summary>
	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "VwRecentCallQueryExecutor")]
	public class VwRecentCallQueryExecutor : IEntityQueryExecutor
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public VwRecentCallQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool CheckUserHasCalls() {
			var select = new Select(_userConnection)
				.Top(1)
					.Column("Id")
				.From("Call")
				.Where("CreatedById").IsEqual(Column.Parameter(_userConnection.CurrentUser.ContactId)) as Select;
			return select.ExecuteScalar<Guid>() != Guid.Empty;
		}

		private HashSet<Guid> GetRecentCallIds(int rowNumber) {
			var result = new HashSet<Guid>();
			result.UnionWith(GetRecentCallIds(rowNumber, GetResentCallsByContactsSelect()));
			result.UnionWith(GetRecentCallIds(rowNumber, GetResentCallsByAccountsSelect()));
			result.UnionWith(GetRecentCallIds(rowNumber, GetResentCallsByNumbersSelect()));
			return result;
		}

		private HashSet<Guid> GetRecentCallIds(int rowNumber, Select subSelect) {
			var result = new HashSet<Guid>();
			var select = GetTopResentCallsSelect(rowNumber, subSelect);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader dataReader = select.ExecuteReader(dbExecutor)) {
					while (dataReader.Read()) {
						result.Add(dataReader.GetColumnValue<Guid>("Id"));
					}
				}
			}
			return result;
		}

		private Select GetTopResentCallsSelect(int rowNumber, Select subSelect) {
			var select = new Select(_userConnection)
				.Top(rowNumber)
					.Column("Id")
					.Column("CreatedOn")
					.Column("Number")
				.From(subSelect).As("SubSelect")
				.Where("Number").IsEqual(Column.Const(1))
				.OrderByDesc("CreatedOn") as Select;
			return select;
		}

		private Select GetResentCallsByContactsSelect() {
			var select =
				new Select(_userConnection)
					.Column("Id")
					.Column("CreatedOn")
					.Column(new WindowQueryFunction(
						new RowNumberQueryFunction(),
						new QueryColumnExpression("ContactId"),
						new QueryColumnExpression("CreatedOn"),
						OrderDirection.Descending)).As("Number")
				.From("Call")
				.Where("ContactId").Not().IsNull()
				.And("CreatedById").IsEqual(Column.Parameter(_userConnection.CurrentUser.ContactId)) as Select;
			return select;
		}

		private Select GetResentCallsByAccountsSelect() {
			var select =
				new Select(_userConnection)
					.Column("Id")
					.Column("CreatedOn")
					.Column(new WindowQueryFunction(
						new RowNumberQueryFunction(),
						new QueryColumnExpression("AccountId"),
						new QueryColumnExpression("CreatedOn"),
						OrderDirection.Descending)).As("Number")
				.From("Call")
				.Where("ContactId").IsNull()
				.And("AccountId").Not().IsNull()
				.And("CreatedById").IsEqual(Column.Parameter(_userConnection.CurrentUser.ContactId)) as Select;
			return select;
		}

		private Select GetResentCallsByNumbersSelect() {
			var queryCase = new QueryCase();
			var queryCondition = new QueryCondition(QueryConditionType.Equal) {
				LeftExpression = new QueryColumnExpression("DirectionId")
			};
			queryCondition.RightExpressions.Add(new QueryParameter(new Guid("53F71B5F-7E17-4CF5-BF14-6A59212DB422")));
			queryCase.AddWhenItem(queryCondition, "CalledId");
			queryCase.ElseExpression = new QueryColumnExpression("CallerId");
			var select =
				new Select(_userConnection)
					.Column("Id")
					.Column("CreatedOn")
					.Column(new WindowQueryFunction(
						new RowNumberQueryFunction(),
						new QueryColumnExpression(queryCase),
						new QueryColumnExpression("CreatedOn"),
						OrderDirection.Descending)).As("Number")
				.From("Call")
				.Where("ContactId").IsNull()
				.And("AccountId").IsNull()
				.And("CreatedById").IsEqual(Column.Parameter(_userConnection.CurrentUser.ContactId)) as Select;
			return select;
		}

		private EntitySchemaQuery GetCallsEsq(EntitySchemaQuery recentCallsEsq) {
			var ids = GetRecentCallIds(recentCallsEsq.RowCount);
			var callsEsq = new EntitySchemaQuery(_userConnection.EntitySchemaManager, "Call");
			callsEsq.RowCount = recentCallsEsq.RowCount;
			callsEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			callsEsq.Filters.Add(callsEsq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", ids.Select(id => (object)id).ToArray()));
			recentCallsEsq.Columns.ForEach(c => {
				if (c.Path.StartsWith("Call.")) {
					callsEsq.AddColumn(c.Path.Replace("Call.", string.Empty));
				}
			});
			callsEsq.AddColumn("CreatedOn").OrderDirection = OrderDirection.Descending;
			return callsEsq;
		}

		private Entity ConvertCallToRecentCall(Entity call, EntitySchema recentCallSchema,
				EntitySchemaQueryColumnCollection callsEsqColumns, EntitySchemaQueryColumnCollection recentCallsEsqColumns) {
			var recentCall = recentCallSchema.CreateEntity(_userConnection);
			foreach (var recentCallEsqColumn in recentCallsEsqColumns) {
				var callEsqColumnPath = recentCallEsqColumn.Path.StartsWith("Call.")
					? recentCallEsqColumn.Path.Replace("Call.", string.Empty)
					: recentCallEsqColumn.Path;
				var callEsqColumn = callsEsqColumns.First(c => c.Path == callEsqColumnPath);
				var callColumn = call.Schema.Columns.GetByName(callEsqColumn.Name);
				var recentCallColumn = recentCallSchema.Columns.GetByName(recentCallEsqColumn.Name);
				var value = call.GetColumnValue(callColumn.ColumnValueName);
				if (callColumn.IsLookupType) {
					var displayValue = call.GetColumnValue(callColumn.DisplayColumnValueName) as string;
					recentCall.SetColumnBothValues(recentCallColumn, value, displayValue);
				} else {
					recentCall.SetColumnValue(recentCallColumn, value);
				}
			}
			recentCall.StoringState = StoringObjectState.NotChanged;
			return recentCall;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns VwRecentCall entity collection.
		/// </summary>
		/// <param name="esq"><see cref="EntitySchemaQuery"/> instance.</param>
		/// <returns>VwRecentCall entity collection.</returns>
		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			var result = new EntityCollection(_userConnection, "VwRecentCall");
			if (!CheckUserHasCalls()) {
				return result;
			}
			var callsEsq = GetCallsEsq(esq);
			var calls = callsEsq.GetEntityCollection(_userConnection);
			var recentCallSchema = esq.GetSchema();
			calls.ForEach(call => result.Add(ConvertCallToRecentCall(call, recentCallSchema, callsEsq.Columns, esq.Columns)));
			return result;
		}

		#endregion

	}

	#endregion

}

