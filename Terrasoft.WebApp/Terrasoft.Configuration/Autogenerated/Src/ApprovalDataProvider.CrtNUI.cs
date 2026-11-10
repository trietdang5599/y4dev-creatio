namespace Terrasoft.Configuration {
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Nui.ServiceModel.DataContract;
	using Terrasoft.Nui.ServiceModel.Extensions;
	using EntityCollection = Terrasoft.Core.Entities.EntityCollection;
	using EntitySchema = Terrasoft.Core.Entities.EntitySchema;

	#region Class: ApprovalDataProvider

	[DefaultBinding(typeof(IApprovalDataProvider))]
	public class ApprovalDataProvider : IApprovalDataProvider
	{

		#region Constructors: Public

		public ApprovalDataProvider(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private void ApplyColumns(Dictionary<string, string> columnNameMap, EntitySchemaQuery esq) {
			columnNameMap[esq.AddColumn("Id").Name] = "Id";
			columnNameMap[esq.AddColumn("VisaOwner").Name] = "VisaOwner";
			columnNameMap[esq.AddColumn("VisaOwner.Contact").Name] = "VisaOwnerContact";
			columnNameMap[esq.AddColumn("SetBy").Name] = "SetBy";
			columnNameMap[esq.AddColumn("Status").Name] = "Status";
			columnNameMap[esq.AddColumn("Comment").Name] = "Comment";
			columnNameMap[esq.AddColumn("Objective").Name] = "Objective";
		}

		private EntitySchemaQuery CreateApprovalsEsq(string parentSchemaName, Guid parentRecordId, 
				out Dictionary<string, string> columnNameMap) {
			HistoryParameters historyParams = GetHistoryParameters(parentSchemaName);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, historyParams.Schema.Name);
			columnNameMap = new Dictionary<string, string>();
			ApplyColumns(columnNameMap, esq);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, historyParams.MasterColumnName, parentRecordId));
			return esq;
		}

		private HistoryParameters GetHistoryParameters(string parentSchemaName) {
			var result = new HistoryParameters();
			EntitySchema schema = null;
			string masterColumnName = "";
			GetSysModuleSelect(parentSchemaName).ExecuteReader(reader => {
				Guid schemaUId = reader.GetColumnValue<Guid>("VisaSchemaUId");
				schema = UserConnection.EntitySchemaManager.GetInstanceByUId(schemaUId);
				Guid masterColumnUId = reader.GetColumnValue<Guid>("MasterColumnUId");
				Core.Entities.EntitySchemaColumn masterColumn = schema.Columns.GetByUId(masterColumnUId);
				masterColumnName = masterColumn.Name;
			});
			if (schema == null) {
				schema = UserConnection.EntitySchemaManager.FindInstanceByName("SysApproval");
				masterColumnName = "EntityId";
			}
			result.Schema = schema;
			result.MasterColumnName = masterColumnName;
			return result;
		}

		private Select GetSysModuleSelect(string schemaName) {
			var select =
				new Select(UserConnection)
					.Column("SysModuleVisa", "VisaSchemaUId").As("VisaSchemaUId")
					.Column("SysModuleVisa", "MasterColumnUId").As("MasterColumnUId")
				.From("SysModule")
					.InnerJoin("SysModuleVisa").On("SysModuleVisa", "Id")
						.IsEqual("SysModule", "SysModuleVisaId")
				.Where("SysModule", "Code")
					.IsEqual(Column.Parameter(schemaName)) as Select;
			return select;
		}

		private SelectQueryResponse PrepareSelectQueryResponse(EntitySchemaQuery esq, Dictionary<string, string> columnNameMap) {
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			var convertedEntities = QueryExtension.GetEntityCollection(collection, columnNameMap);
			Dictionary<string, object> config = QueryExtension.GetColumnConfig(esq, columnNameMap);
			SelectQueryResponse response = new SelectQueryResponse {
				Rows = convertedEntities,
				RowsAffected = convertedEntities.Count,
				RowConfig = config
			};
			return response;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IApprovalDataProvider.GetActiveApprovals(string, Guid)"/> 
		public SelectQueryResponse GetActiveApprovals(string parentSchemaName, Guid parentRecordId) {
			EntitySchemaQuery esq = CreateApprovalsEsq(parentSchemaName, parentRecordId, out Dictionary<string, string> columnNameMap);
			columnNameMap[esq.AddColumn("SetDate").Name] = "SetDate";
			var createdOnColumn = esq.AddColumn("CreatedOn");
			createdOnColumn.OrderByAsc();
			columnNameMap[createdOnColumn.Name] = "CreatedOn";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsCanceled", false));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Status", ApprovalConstants.Waiting));
			var userFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			userFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "VisaOwner", UserConnection.CurrentUser.Id));
			userFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysAdminUnitInRole:SysAdminUnitRoleId:VisaOwner].SysAdminUnit", UserConnection.CurrentUser.Id));
			esq.Filters.Add(userFilterGroup);
			return PrepareSelectQueryResponse(esq, columnNameMap);
		}

		/// <inheritdoc cref="IApprovalDataProvider.GetApprovalHistory(string, Guid)"/> 
		public SelectQueryResponse GetApprovalHistory(string parentSchemaName, Guid parentRecordId) {
			EntitySchemaQuery esq = CreateApprovalsEsq(parentSchemaName, parentRecordId, out Dictionary<string, string> columnNameMap);
			var setDateColumn = esq.AddColumn("SetDate");
			setDateColumn.OrderByAsc();
			columnNameMap[setDateColumn.Name] = "SetDate";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsCanceled", false));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", ApprovalConstants.Canceled));
			return PrepareSelectQueryResponse(esq, columnNameMap);
		}

		/// <inheritdoc cref="IApprovalDataProvider.GetApprovalSchemaName(string)"/> 
		public ApprovalSchemaConfig GetApprovalSchemaName(string schemaName) {
			var parameters = GetHistoryParameters(schemaName);
			return new ApprovalSchemaConfig {
				EntityName = parameters.Schema.Name,
				MasterColumnName = parameters.MasterColumnName
			};
		}

		/// <inheritdoc cref="IApprovalDataProvider.GetFirstActiveApproval(string, Guid)"/> 
		public SelectQueryResponse GetFirstActiveApproval(string parentSchemaName, Guid parentRecordId) {
			EntitySchemaQuery esq = CreateApprovalsEsq(parentSchemaName, parentRecordId, out Dictionary<string, string> columnNameMap);
			columnNameMap[esq.AddColumn("SetDate").Name] = "SetDate";
			var createdOnColumn = esq.AddColumn("CreatedOn");
			createdOnColumn.OrderByAsc();
			esq.RowCount = 1;
			columnNameMap[createdOnColumn.Name] = "CreatedOn";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsCanceled", false));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Status", ApprovalConstants.Waiting));
			var userFilterGroup = new EntitySchemaQueryFilterCollection(esq, LogicalOperationStrict.Or);
			userFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "VisaOwner", UserConnection.CurrentUser.Id));
			userFilterGroup.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysAdminUnitInRole:SysAdminUnitRoleId:VisaOwner].SysAdminUnit", UserConnection.CurrentUser.Id));
			esq.Filters.Add(userFilterGroup);
			return PrepareSelectQueryResponse(esq, columnNameMap);
		}

		/// <inheritdoc cref="IApprovalDataProvider.GetApprovalsMetricsForEntity(string, Guid)"/> 
		public SelectQueryResponse GetApprovalsMetricsForEntity(string parentSchemaName, Guid parentRecordId) {
			HistoryParameters historyParams = GetHistoryParameters(parentSchemaName);
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, historyParams.Schema.Name);
			var columnNameMap = new Dictionary<string, string>();
			var countColumn = esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Count, "Id"));
			var statusColumn = esq.AddColumn("Status");
			columnNameMap[countColumn.Name] = "Count";
			columnNameMap[statusColumn.Name] = "Status";
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, historyParams.MasterColumnName, parentRecordId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.NotEqual, "Status", ApprovalConstants.Canceled));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "IsCanceled", false));
			return PrepareSelectQueryResponse(esq, columnNameMap);
		}

		#endregion

	}

	#endregion

}
