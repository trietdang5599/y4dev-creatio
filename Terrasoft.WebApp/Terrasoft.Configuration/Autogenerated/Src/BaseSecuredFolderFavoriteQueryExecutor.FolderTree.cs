namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: BaseSecuredFolderFavoriteQueryExecutor

	/// <summary>
	/// Base class for secured folders.
	/// </summary>
	public abstract class BaseSecuredFolderFavoriteQueryExecutor : IEntityQueryExecutor
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private ITreeAccessRightsAuditor _treeAccessRightsAuditor;

		#endregion

		#region Properties: Private

		private ITreeAccessRightsAuditor TreeAccessRightsAuditor =>
			_treeAccessRightsAuditor ?? (_treeAccessRightsAuditor = ClassFactory.Get<ITreeAccessRightsAuditor>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Properties: Protected

		/// <summary>
		/// User connection.
		/// </summary>
		protected UserConnection UserConnection => _userConnection;

		/// <summary>
		/// Folder favorite entity schema name.
		/// </summary>
		protected abstract string FolderFavoriteEntitySchemaName { get; }

		/// <summary>
		/// Folder favorite column name.
		/// </summary>
		protected abstract string FolderFavoriteColumnName { get; }

		/// <summary>
		/// Folder records schema name.
		/// </summary>
		protected virtual string FolderSchemaName { get; set; }

		#endregion

		#region Constructor

		public BaseSecuredFolderFavoriteQueryExecutor(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private EntityCollection GetFolderFavoriteWithRights(EntitySchemaQuery esq) {
			var favoriteEntityCollection = GetFolderFavorite(esq);
			if (!favoriteEntityCollection.Any()) {
				return favoriteEntityCollection;
			}
			return GetFavoriteItemsWithRights(favoriteEntityCollection, esq.AdminUnitRoleSources);
		}

		private EntityCollection GetFavoriteItemsWithRights(EntityCollection collection, AdminUnitRoleSources adminUnitRoleSources) {
			var result = new EntityCollection(UserConnection, FolderFavoriteEntitySchemaName);
			var folderFavoriteColumnDbName = GetFolderFavoriteColumnDbName();
			var recordIds = collection.Select(entity => entity.GetTypedColumnValue<Guid>(folderFavoriteColumnDbName)).ToList();
			var recordWithRightsIds = TreeAccessRightsAuditor.CheckTreeAccessRights(GetAccessRightsParams(recordIds, FolderSchemaName, adminUnitRoleSources, "Parent"));
			var favoriteWithRights = collection.Where(e => recordWithRightsIds.Contains(e.GetTypedColumnValue<Guid>(folderFavoriteColumnDbName))).ToList() ;
			favoriteWithRights.ForEach(entity => result.Add(entity));
			return result;
		}

		private AccessRightsParams GetAccessRightsParams(List<Guid> records, string schemaName, AdminUnitRoleSources adminUnitRoleSources, string hierarchicalColumnName) {
			return new AccessRightsParams {
				RecordIds = records,
				SchemaName = schemaName,
				AdminUnitRoleSources = adminUnitRoleSources,
				HierarchicalColumnName = hierarchicalColumnName
			};
		}

		private string GetFolderFavoriteColumnDbName() {
			var schema = UserConnection.EntitySchemaManager.FindInstanceByName(FolderFavoriteEntitySchemaName);
			var parentColumn = schema.FindSchemaColumnByPath(FolderFavoriteColumnName);
			return parentColumn.ColumnValueName;
		}

		private EntityCollection GetFolderFavorite(EntitySchemaQuery esq) {
			var favoriteEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, FolderFavoriteEntitySchemaName);
			favoriteEsq.AdminUnitRoleSources = esq.AdminUnitRoleSources;
			AddColumnsFromCopiedEsq(favoriteEsq, esq);
			AddFiltersFromCopiedEsq(favoriteEsq, esq);
			return favoriteEsq.GetEntityCollection(_userConnection);
		}

		private void AddColumnsFromCopiedEsq(EntitySchemaQuery createdEsq, EntitySchemaQuery copiedEsq) {
			createdEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			createdEsq.AddColumn(FolderFavoriteColumnName);
			copiedEsq.Columns.ToList().ForEach(column => {
				if (!createdEsq.Columns.ExistsByPath(column.Path)) {
					createdEsq.Columns.Add(column);
				}
			});
		}

		#endregion

		#region Methods: Protected Abstract

		/// <summary>
		/// Add filters to created esq from copied esq.
		/// </summary>
		/// <param name="createdEsq">Created esq.</param>
		/// <param name="copiedEsq">Created esq.</param>
		protected abstract void AddFiltersFromCopiedEsq(EntitySchemaQuery createdEsq, EntitySchemaQuery copiedEsq);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns folder favorites by esq filters.
		/// </summary>
		/// <param name="esq">EntitySchemaQuery with filters.</param>
		/// <returns>Filtered folder tree favorites based on rights.</returns>
		public EntityCollection GetEntityCollection(EntitySchemaQuery esq) {
			return GetFolderFavoriteWithRights(esq);
		}

		#endregion
	}

	#endregion

}

