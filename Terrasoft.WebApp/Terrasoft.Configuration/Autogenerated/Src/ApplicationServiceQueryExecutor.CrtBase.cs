namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Services;

	#region Class: ApplicationServiceQueryExecutor

	/// <summary>
	/// Query executor for service schemas of application.
	/// </summary>
	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "ApplicationServiceQueryExecutor")]
	public class ApplicationServiceQueryExecutor : BaseApplicationSchemaQueryExecutor<Terrasoft.Services.ServiceSchema>
	{

		#region Constructors: Public

		public ApplicationServiceQueryExecutor(UserConnection userConnection, IAppManager appManager)
			: base(userConnection, appManager) {
		}

		#endregion

		#region Properties: Protected

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override string ResultEntitySchemaName => "ApplicationService";

		#endregion

		#region Methods: Protected

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override SchemaManager<Terrasoft.Services.ServiceSchema> GetSchemaManager() =>
			(ServiceSchemaManager)UserConnection.GetSchemaManager("ServiceSchemaManager");

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override void MapAdditionalColumns(Entity entity,
				ISchemaManagerItem<Terrasoft.Services.ServiceSchema> schemaManagerItem) {
			entity.SetColumnValue("Type", schemaManagerItem.Instance.Type);
			entity.SetColumnValue("BaseUri", schemaManagerItem.Instance.BaseUri);
		}

		#endregion

	}

	#endregion

}

