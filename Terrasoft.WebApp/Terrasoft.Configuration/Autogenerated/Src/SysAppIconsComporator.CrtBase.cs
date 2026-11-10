  namespace Terrasoft.Configuration
{
	using System;
	using System.Linq;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: ISysAppIconsComporator

	/// <summary>
	/// Interface for application icons comporator.
	/// Provides methods to find equivalent data.
	/// </summary>
	public interface ISysAppIconsComporator
	{

		/// <summary>
		/// Returns related application icon id by sys image id.
		/// </summary>
		/// <param name="sysImageId">Sys image id.</param>
		Guid GetRelatedIconBySysImage(Guid sysImageId);

	}


	#endregion

	#region Class: SysAppIconsComporator

	/// <inheritdoc />
	[DefaultBinding(typeof(ISysAppIconsComporator))]
	public class SysAppIconsComporator: ISysAppIconsComporator
	{

		#region Constants: Private

		private const string oracleDbName = "OracleExecutor";
		private const string oracleDbManagedName = "OracleManagedExecutor";

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection"><see cref="UserConnection"/> instance.</param>
		public SysAppIconsComporator(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// <see cref="UserConnection"/> instance.
		/// </summary>
		private UserConnection UserConnection { get; set; }

		#endregion

		#region Methods: Private

		private Guid GetRelatedIcon(Guid sysImageId) {
			if (IsOracleServer()) {
				return FindRelatedAppIconImageOracle(sysImageId);
			}
			return FindRelatedAppIconImage(sysImageId);
		}

		private bool IsOracleServer() {
			return (UserConnection.DBExecutorType.Name == oracleDbName ||
				UserConnection.DBExecutorType.Name == oracleDbManagedName);
		}

		private Guid FindRelatedAppIconImageOracle(Guid sysImageId) {
			var dataValueTypeManager = (DataValueTypeManager)UserConnection.AppManagerProvider.GetManager("DataValueTypeManager");
			var sp = new StoredProcedure(UserConnection, "tsp_GetSysAppIconIdBySysImage");
			sp.WithParameter("SysImageId", sysImageId);
			sp.WithOutputParameter("SysAppIconId", dataValueTypeManager.GetInstanceByName("Guid"));
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				sp.Execute(dbExecutor);
				var sysAppIconParameter = sp.Parameters.FindByName("SysAppIconId")?.Value as string;
				if (!string.IsNullOrEmpty(sysAppIconParameter)) {
					var paramId = new Guid(sysAppIconParameter);
					return paramId;
				}
			}
			return Guid.Empty;
		}

		private Guid FindRelatedAppIconImage(Guid sysImageId) {
			var esq = GetSysAppIconsSchemaQuery();
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "[SysImage:Data:Data].Id", sysImageId));
			var entityCollection = esq.GetEntityCollection(UserConnection);
			var entity = entityCollection.FirstOrDefault();
			return entity != null ? entity.PrimaryColumnValue : Guid.Empty;
		}

		private EntitySchemaQuery GetSysAppIconsSchemaQuery() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "SysAppIcons") {
				RowCount = 1
			};
			esq.PrimaryQueryColumn.IsAlwaysSelect = true;
			return esq;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public Guid GetRelatedIconBySysImage(Guid sysImageId) {
			return sysImageId.Equals(Guid.Empty) ? sysImageId : GetRelatedIcon(sysImageId);
		}

		#endregion

	}

	#endregion

}

