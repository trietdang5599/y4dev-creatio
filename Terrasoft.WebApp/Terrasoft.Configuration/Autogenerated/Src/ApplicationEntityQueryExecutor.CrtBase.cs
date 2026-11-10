 namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Applications.Abstractions;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Class: ApplicationEntityQueryExecutor

	/// <summary>
	/// Query executor for entity schemas of application.
	/// </summary>
	[DefaultBinding(typeof(IEntityQueryExecutor), Name = "ApplicationEntityQueryExecutor")]
	public class ApplicationEntityQueryExecutor : BaseApplicationSchemaQueryExecutor<EntitySchema>
	{

		#region Constructors: Public

		public ApplicationEntityQueryExecutor(UserConnection userConnection, IAppManager appManager)
			: base(userConnection, appManager) {
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override string ResultEntitySchemaName => "ApplicationEntity";

		/// <summary>
		/// <inheritdoc />
		/// </summary>
		protected override SchemaManager<EntitySchema> GetSchemaManager() => UserConnection.EntitySchemaManager;

		#endregion

	}

	#endregion

}

