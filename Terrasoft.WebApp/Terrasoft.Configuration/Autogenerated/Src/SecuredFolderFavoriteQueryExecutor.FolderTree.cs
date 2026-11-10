namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: SecuredFolderFavoriteQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "SecuredFolderFavoriteQueryExecutor")]
	public class SecuredFolderFavoriteQueryExecutor : BaseSecuredFolderFavoriteQueryExecutor
	{

		#region Fields: Private

		private readonly string _folderEntitySchemaNameColumnName = "FolderEntitySchemaName";

		#endregion

		#region Properties: Protected

		/// <inheritdoc />
		protected override string FolderFavoriteEntitySchemaName => "FolderFavorite";

		/// <inheritdoc />
		protected override string FolderFavoriteColumnName => "FolderId";

		/// <inheritdoc />
		protected override string FolderSchemaName { get; set; }

		#endregion

		#region Constructor: Public

		public SecuredFolderFavoriteQueryExecutor(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Methods: Private

		private EntitySchemaQueryFilterCollection GetPreparedCopiedEsqFilters(EntitySchemaQuery copiedEsq) {
			var entitySchemaNames = new List<string>();
			FindAndRemoveFiltersByPath(copiedEsq.Filters, _folderEntitySchemaNameColumnName, entitySchemaNames);
			CheckAndSetFolderSchemaName(entitySchemaNames);
			return copiedEsq.Filters;
		}

		private void FindAndRemoveFiltersByPath(EntitySchemaQueryFilterCollection collection, string name, List<string> result) {
			for (int i = collection.Count - 1; i >= 0; i--) {
				var item = collection[i];
				if (item is EntitySchemaQueryFilter filter && filter.LeftExpression.Path == name) {
					result.Add(filter.RightExpressions.First().ParameterValue as string);
					collection.Remove(item);
				}
				else if (item is EntitySchemaQueryFilterCollection subCollection) {
					FindAndRemoveFiltersByPath(subCollection, name, result);
				}
			};
		}

		private void CheckAndSetFolderSchemaName(List<string> entitySchemaNames) {
			if (!entitySchemaNames.Any()) {
				ThrowFilterEmptyError();
			}
			if (entitySchemaNames.Count > 1) {
				ThrowFilterMoreOneEntitySchemaError();
			}
			FolderSchemaName = entitySchemaNames.First();
		}

		private void ThrowFilterEmptyError() {
			var errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
									"SecuredFolderFavoriteQueryExecutor", "LocalizableStrings.FolderEntitySchemaNameFilterEmpty.Value");
			throw new Exception(errorMessage);
		}

		private void ThrowFilterMoreOneEntitySchemaError() {
			var errorMessage = new LocalizableString(UserConnection.Workspace.ResourceStorage,
								"SecuredFolderFavoriteQueryExecutor", "LocalizableStrings.FolderEntitySchemaNameFilterMoreOne.Value");
			throw new Exception(errorMessage);
		}

		private void AddExistFilterByFolderEntitySchemaName(EntitySchemaQuery createdEsq) {
			createdEsq.Filters.Add(createdEsq.CreateExistsFilter($"[{FolderSchemaName}:Id:FolderId].Id"));
		}

		#endregion

		#region Methods: Protected

		protected override void AddFiltersFromCopiedEsq(EntitySchemaQuery createdEsq, EntitySchemaQuery copiedEsq) {
			if (!copiedEsq.Filters.Any()) {
				ThrowFilterEmptyError();
			}
			var copiedFilters = GetPreparedCopiedEsqFilters(copiedEsq);
			createdEsq.Filters.Add(copiedFilters);
			AddExistFilterByFolderEntitySchemaName(createdEsq);
		}

		#endregion
	}

	#endregion

}
