namespace Terrasoft.Core.Process.Configuration
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Process;

	#region Class: GetIsProcessLinkedToEntityUserTask

	/// <exclude/>
	public partial class GetIsProcessLinkedToEntityUserTask
	{

		#region Methods: Protected

		protected override bool InternalExecute(ProcessExecutingContext context) {
			var schema = UserConnection.EntitySchemaManager.FindItemByUId(EntitySchemaId);
			var schemaUId = (schema != null) ? schema.UId : ((Select)
				new Select(UserConnection).Column("UId").From("SysSchema").Where("Id").IsEqual(Column.Parameter(EntitySchemaId)))
				.ExecuteScalar<Guid>();
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysProcessLog");
			esq.UseAdminRights = false;
			esq.AddColumn(esq.RootSchema.PrimaryColumn.Name);
			esq.RowCount = 1;
			var filters = new EntitySchemaQueryFilterCollection(esq);
			var entitySchemaFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[SysProcessEntity:SysProcess].EntitySchemaUId", schemaUId);
			filters.Add(entitySchemaFilter);
			var entityFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[SysProcessEntity:SysProcess].EntityId", RecordId);
			filters.Add(entityFilter);
			var processFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
				"[SysSchema:Id:SysSchema].UId", Owner.SchemaUId);
			filters.Add(processFilter);
			if (ProcessStatusId != Guid.Empty) {
				var processStatusFilter = esq.CreateFilterWithParameters(FilterComparisonType.Equal,
					"Status", ProcessStatusId);
				filters.Add(processStatusFilter);
			}
			filters.LogicalOperation = LogicalOperationStrict.And;
			esq.Filters.Add(filters);
			var rows = esq.GetEntityCollection(UserConnection);
			Result = rows.Count > 0;
			return true;
		}

		#endregion

		#region Methods: Public

		public override string GetExecutionData() {
			return string.Empty;
		}

		#endregion

	}

	#endregion

	#region Class: GetIsProcessLinkedToEntityUserTaskSchemaExtension

	/// <exclude/>
	public class GetIsProcessLinkedToEntityUserTaskSchemaExtension : ProcessUserTaskSchemaExtension
	{

		#region Methods: Public

		public override Dictionary<Guid, string> GetResultParameterAllValues(UserConnection userConnection, ProcessSchemaUserTask schemaUserTask) {
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "SysProcessStatus");
			esq.AddAllSchemaColumns();
			EntityCollection rows = esq.GetEntityCollection(userConnection);
			var resultParameterAllValues = new Dictionary<Guid, string>();
			foreach (var row in rows) {
				resultParameterAllValues[row.PrimaryColumnValue] = row.PrimaryDisplayColumnValue;
			}
			return resultParameterAllValues;
		}

		#endregion

	}

	#endregion

}

