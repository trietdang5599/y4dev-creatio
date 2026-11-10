namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: ITreeAccessRightsAuditor

	/// <summary>
	/// Tree access rights auditor interface.
	/// </summary>
	public interface ITreeAccessRightsAuditor
	{
		/// <summary>
		/// Checks access rights for records in a specified tree.
		/// </summary>
		/// <param name="rightsParams">Access rights params.</param>
		/// <returns>Returns recordId with rights.</returns>
		List<Guid> CheckTreeAccessRights(AccessRightsParams rightsParams);
	}

	#endregion

	/// <summary>
	/// Tree access rights auditor.
	/// </summary>
	[DefaultBinding(typeof(ITreeAccessRightsAuditor), Name = nameof(TreeAccessRightsAuditor))]
	public class TreeAccessRightsAuditor : ITreeAccessRightsAuditor
	{
		#region Fields: Private

		private int _chunkSize = 500;

		#endregion

		#region Properties: Private

		/// <summary>
		/// Instance of <see cref="UserConnection"/>.
		/// </summary>
		private UserConnection UserConnection { get; set; }

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="TreeAccessRightsAuditor"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public TreeAccessRightsAuditor(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private List<Guid> CheckTreeNodesAccessRights(AccessRightsParams rightsParams) {
			var result = new List<Guid>();
			var parts = rightsParams.RecordIds.SplitOnChunks(_chunkSize);
			parts.ForEach(part => {
				var treeSelectQuery = GetTreeSelectQuery(rightsParams.SchemaName, rightsParams.HierarchicalColumnName, rightsParams.AdminUnitRoleSources);
				var parentColumnName = GetParentColumnName(rightsParams.SchemaName, rightsParams.HierarchicalColumnName);
				var primaryColumnName = GetPrimaryColumnName(rightsParams.SchemaName);
				var hierarchicalOptions = CreateTreeHierarchicalSelectOptions(rightsParams, primaryColumnName, parentColumnName);
				treeSelectQuery.HierarchicalOptions = hierarchicalOptions;
				var treeItems = GetTreeItems(treeSelectQuery, primaryColumnName, parentColumnName);
				result.AddRange(GetTreeNodesWithRights(rightsParams.RecordIds, treeItems));
			});
			return result;
		}

		private Select GetTreeSelectQuery(string schemaName, string hierarchicalColumnName, AdminUnitRoleSources adminUnitRoleSources) {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			esq.AdminUnitRoleSources = adminUnitRoleSources;
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.AddColumn(hierarchicalColumnName);
			return esq.GetSelectQuery(UserConnection);
		}

		private string GetParentColumnName(string schemaName, string hierarchicalColumnName) {
			var schema = UserConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			var parentColumn = schema.FindSchemaColumnByPath(hierarchicalColumnName);
			return parentColumn.ColumnValueName;
		}

		private string GetPrimaryColumnName(string schemaName) {
			EntitySchema schema = UserConnection.EntitySchemaManager.FindInstanceByName(schemaName);
			return schema.PrimaryColumn.Name;
		}

		private Dictionary<Guid, Guid> GetTreeItems(Select treeSelect, string primaryColumnName, string parentColumnName) {
			var treeItemsDictionary = new Dictionary<Guid, Guid>();
			treeSelect.ExecuteReader(reader => {
				var treeNodeKeyValuePair = new KeyValuePair<Guid, Guid> (
					reader.GetColumnValue<Guid>(primaryColumnName), reader.GetColumnValue<Guid>(parentColumnName));
				treeItemsDictionary.AddIfNotExists(treeNodeKeyValuePair);
			});
			return treeItemsDictionary;
		}

		private List<Guid> GetTreeNodesWithRights(List<Guid> recordIds, Dictionary<Guid, Guid> treeItems) {
			return recordIds.AsParallel().Where(recordId => HasTreeRootParent(recordId, treeItems)).ToList();
		}

		private bool HasTreeRootParent(Guid? currentId, Dictionary<Guid, Guid> treeItems) {
			if (!treeItems.TryGetValue(currentId.Value, out Guid parentId)) {
				return false;
			}
			if (parentId.Equals(Guid.Empty)) {
				return true;
			}
			return HasTreeRootParent(parentId, treeItems);
		}

		private HierarchicalSelectOptions CreateTreeHierarchicalSelectOptions(AccessRightsParams rightsParams, string primaryColumnName, string parentColumnName) {
			var options =  new HierarchicalSelectOptions() {
				RootSourceAlias = rightsParams.SchemaName,
				PrimaryColumnName = primaryColumnName,
				ParentColumnName = parentColumnName,
				SelectType = HierarchicalSelectType.Parents
			};
			QueryCondition startingCondition = options.StartingPrimaryColumnCondition;
			startingCondition.LeftExpression = new QueryColumnExpression(primaryColumnName);
			startingCondition.ConditionType = QueryConditionType.In;
			startingCondition.RightExpressions.AddExpressionsRange(Column.Parameters(rightsParams.RecordIds));
			return options;
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public List<Guid> CheckTreeAccessRights(AccessRightsParams rightsParams) {
			rightsParams.RecordIds.CheckArgumentNullOrEmpty(nameof(rightsParams.RecordIds));
			rightsParams.SchemaName.CheckArgumentNullOrEmpty(nameof(rightsParams.SchemaName));
			rightsParams.HierarchicalColumnName.CheckArgumentNullOrEmpty(nameof(rightsParams.HierarchicalColumnName));
			return CheckTreeNodesAccessRights(rightsParams);
		}

		#endregion
	}

	#region Class: AccessRightsParams

	/// <summary>
	/// Class access rights params.
	/// </summary>
	public class AccessRightsParams
	{
		#region Properties: Public

		/// <summary>
		/// Records Ids.
		/// </summary>
		public List<Guid> RecordIds { get; set; }

		/// <summary>
		/// Schema name.
		/// </summary>
		public string SchemaName { get; set; }

		/// <summary>
		/// Hierarchical column name.
		/// </summary>
		public string HierarchicalColumnName { get; set; }

		/// <summary>
		/// Admin unit role sources.
		/// </summary>
		public AdminUnitRoleSources AdminUnitRoleSources { get; set; }

		#endregion
	}

	#endregion
}
