namespace Terrasoft.Configuration
{
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: SecFolderTreeFavoriteQueryExecutor

	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "SecFolderTreeFavoriteQueryExecutor")]
	public class SecFolderTreeFavoriteQueryExecutor: BaseSecuredFolderFavoriteQueryExecutor
	{
		#region Properties: Protected

		/// <inheritdoc />
		protected override string FolderFavoriteEntitySchemaName => "FolderTreeFavorite";

		/// <inheritdoc />
		protected override string FolderFavoriteColumnName => "FolderTree";

		/// <inheritdoc />
		protected override string FolderSchemaName { get; set; } = "FolderTree";

		#endregion

		#region Methods: Protected

		/// <inheritdoc />
		protected override void AddFiltersFromCopiedEsq(EntitySchemaQuery createdEsq, EntitySchemaQuery copiedEsq) {
			if (!copiedEsq.Filters.Any()) {
				return;
			}
			createdEsq.Filters.Add(copiedEsq.Filters);
		}

		#endregion

		#region Constructor: Public

		public SecFolderTreeFavoriteQueryExecutor(UserConnection userConnection) : base(userConnection) {
		}

		#endregion


	}

	#endregion

}
