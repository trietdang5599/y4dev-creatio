namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Common;

	#region Class: ConnectedOAuthClientAppQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "ConnectedOAuthClientAppQueryExecutor")]
	public class ConnectedOAuthClientAppQueryExecutor : IEntityQueryExecutor
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly Dictionary<string, object> _preFilters = new Dictionary<string, object>();
		private readonly Dictionary<string, object> _postFilters = new Dictionary<string, object>();
		private readonly HashSet<string> _preFilterNames = new HashSet<string>();
		private readonly HashSet<string> _postFilterNames = new HashSet<string>();

		#endregion

		#region Constructors: Public

		public ConnectedOAuthClientAppQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void ParseFilters(EntitySchemaQueryFilterCollection filters) {
			_preFilterNames.Add("Id");
			_preFilterNames.Add("SysUserId");
			_preFilterNames.Add("ClientId");
			_preFilterNames.Add("Name");
			_postFilterNames.Add("Active");
			foreach (IEntitySchemaQueryFilterItem entitySchemaQueryFilterItem in filters) {
				IEnumerable<EntitySchemaQueryFilter> filterInstances = entitySchemaQueryFilterItem.GetFilterInstances();
				foreach (EntitySchemaQueryFilter filter in filterInstances) {
					if (filter.LeftExpression.ExpressionType == EntitySchemaQueryExpressionType.SchemaColumn 
						&& filter.RightExpressions[0].ExpressionType == EntitySchemaQueryExpressionType.Parameter) {
						object value = filter.RightExpressions.First().ParameterValue;
						var filterName = filter.LeftExpression.Path;
						if (_preFilterNames.Contains(filterName)) {
							if (!_preFilters.ContainsKey(filterName)) {
								_preFilters.Add(filterName, value);
							}
						} else if (_postFilterNames.Contains(filterName)) {
							if (!_postFilters.ContainsKey(filterName)) {
								_postFilters.Add(filterName, value);
							}
						}
					}
				}
			}
		}

		private void ApplyPreFilters(Select query) {
			if (_preFilters.Count == 0) {
				return;
			}
			if (_preFilters.ContainsKey("Id")) {
				query.And("ClientApp", "Id").IsEqual(Column.Parameter(_preFilters["Id"]));
			}
			if (_preFilters.ContainsKey("ClientId")) {
				query.And("ClientApp", "ClientId").IsEqual(Column.Parameter(_preFilters["ClientId"]));
			}
			if (_preFilters.ContainsKey("Name")) {
				query.And("ClientApp", "Name").IsEqual(Column.Parameter(_preFilters["Name"]));
			}
		}
		
		private Select GetConnectedAppSelectQuery(Guid currentUserId) {
			var innerSelect = new Select(_userConnection)
				.Column("SysAdminUnitInRole", "SysAdminUnitRoleId")
				.From("SysAdminUnitInRole").As("SysAdminUnitInRole")
				.Where("SysAdminUnitInRole", "SysAdminUnitId").IsEqual(Column.Parameter(currentUserId)) as Select;
			var selectQuery =
				new Select(_userConnection).Distinct()
					.Column("ClientApp", "Id")
					.Column("SharedAccess", "AccessSharedOn")
					.Column("SharedAccess", "Active").As("Active")
					.Column("ClientApp", "CreatedOn")
					.Column("ClientApp", "CreatedById")
					.Column("ClientApp", "ModifiedOn")
					.Column("ClientApp", "ModifiedById")
					.Column("ClientApp", "ApplicationUrl")
					.Column("ClientApp", "ClientId")
					.Column("ClientApp", "Description")
					.Column("ClientApp", "LogoId")
					.Column("ClientApp", "Name")
				.From("OAuthClientApp").As("ClientApp")
				.InnerJoin("OAuthAppAllowedUser").As("AllowedUsers")
					.On("AllowedUsers", "OAuthClientAppId").IsEqual("ClientApp", "Id")
				.LeftOuterJoin("UserOAuthSharedAccess").As("SharedAccess")
					.On("SharedAccess", "OAuthClientAppId").IsEqual("ClientApp", "Id")
					.And("SharedAccess", "SysUserId").IsEqual(Column.Parameter(currentUserId))
				.Where("AllowedUsers", "SysUserId").In(innerSelect) as Select;
			ApplyPreFilters(selectQuery);
			return selectQuery;
		}
		private Entity CreateEntityFromReader(EntitySchemaQuery esq, IDataReader reader, Guid currentUserId) {
			var active = reader.GetColumnValue<bool>("Active");
			if (_postFilters.ContainsKey("Active") && (bool)_postFilters["Active"] != active) {
				return null;
			}
			var entity = esq.RootSchema.CreateEntity(_userConnection);
			entity.LoadColumnValue("Id", reader.GetColumnValue<Guid>("Id"));
			entity.LoadColumnValue("CreatedOn", reader.GetColumnValue<DateTime>("CreatedOn"));
			entity.LoadColumnValue("CreatedBy", reader.GetColumnValue<Guid>("CreatedById"));
			entity.LoadColumnValue("ModifiedBy", reader.GetColumnValue<Guid>("ModifiedById"));
			entity.LoadColumnValue("ModifiedOn", reader.GetColumnValue<DateTime>("ModifiedOn"));
			DateTime accessSharedOn = reader.GetColumnValue<DateTime>("AccessSharedOn");
			bool isAccessShared = accessSharedOn != DateTime.MinValue;
			entity.LoadColumnValue("AccessSharedOn", accessSharedOn);
			entity.LoadColumnValue("AccessShared", isAccessShared);
			entity.LoadColumnValue("Active", active);
			entity.LoadColumnValue("ApplicationUrl", reader.GetColumnValue<string>("ApplicationUrl"));
			entity.LoadColumnValue("ClientId", reader.GetColumnValue<string>("ClientId"));
			entity.LoadColumnValue("Description", reader.GetColumnValue<string>("Description"));
			entity.LoadColumnValue("LogoId", reader.GetColumnValue<Guid>("LogoId"));
			entity.LoadColumnValue("SysUserId", currentUserId);
			entity.LoadColumnValue("Name", reader.GetColumnValue<string>("Name"));
			return entity;
		}

		#endregion

		#region Methods: Public

		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			var currentUserId = _userConnection.CurrentUser.Id;
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName("ConnectedOAuthClientApp");
			var resultCollection = new EntityCollection(_userConnection, schema);
			ParseFilters(esq.Filters);
			if (_preFilters.ContainsKey("SysUserId") && (Guid)_preFilters["SysUserId"]  != currentUserId) {
				return resultCollection;
			}
			Select selectQuery = GetConnectedAppSelectQuery(currentUserId)
				.OffsetFetch(esq.SkipRowCount, esq.RowCount);
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Entity entity = CreateEntityFromReader(esq, reader, currentUserId);
						if (entity == null) {
							continue;
						}
						resultCollection.Add(entity);
					}
				}
			}
			return resultCollection;
		}

		#endregion

	}

	#endregion

}

