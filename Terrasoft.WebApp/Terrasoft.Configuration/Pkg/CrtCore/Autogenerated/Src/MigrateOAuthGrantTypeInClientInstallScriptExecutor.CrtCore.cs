namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using global::Common.Logging;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;

	#region Class: MigrateOAuthGrantTypeInClientInstallScriptExecutor

	public class MigrateOAuthGrantTypeInClientInstallScriptExecutor : IInstallScriptExecutor
	{

		#region Struct: LegacyClientGrantPair

		private struct LegacyClientGrantPair
		{
			public Guid ClientAppId;
			public Guid GrantTypeId;
		}

		#endregion

		#region Constants: Private

		private const string GrantTypeInClientSchemaName = "OAuthGrantTypeInClient";
		private const string OAuthClientAppSchemaName = "OAuthClientApp";

		#endregion

		#region Fields: Private

		private static readonly Guid SupervisorId = new Guid("410006e1-ca4e-4502-a9ec-e54d922d2c00");
		private static readonly ILog _log = LogManager.GetLogger("OAuth20");

		#endregion

		#region Methods: Private

		private static List<LegacyClientGrantPair> GetLegacyPairsMissingRelations(UserConnection userConnection) {
			var select = new Select(userConnection)
				.Column("client", "Id")
				.Column("client", "GrantTypeId")
				.From(OAuthClientAppSchemaName).As("client")
				.LeftOuterJoin(GrantTypeInClientSchemaName).As("relation")
					.On("relation", "OAuthClientAppId").IsEqual("client", "Id")
					.And("relation", "OAuthGrantTypeId").IsEqual("client", "GrantTypeId")
				.Where("client", "GrantTypeId").Not().IsNull()
				.And("relation", "Id").IsNull() as Select;
			var pairs = new List<LegacyClientGrantPair>();
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						pairs.Add(new LegacyClientGrantPair {
							ClientAppId = reader.GetGuid(0),
							GrantTypeId = reader.GetGuid(1)
						});
					}
				}
			}
			return pairs;
		}

		private static void InsertRelation(UserConnection userConnection, Guid clientAppId, Guid grantTypeId) {
			DateTime nowUtc = DateTime.UtcNow;
			new Insert(userConnection)
				.Into(GrantTypeInClientSchemaName)
				.Set("Id", Column.Parameter(Guid.NewGuid()))
				.Set("CreatedOn", Column.Parameter(nowUtc))
				.Set("CreatedById", Column.Parameter(SupervisorId))
				.Set("ModifiedOn", Column.Parameter(nowUtc))
				.Set("ModifiedById", Column.Parameter(SupervisorId))
				.Set("OAuthClientAppId", Column.Parameter(clientAppId))
				.Set("OAuthGrantTypeId", Column.Parameter(grantTypeId))
				.Execute();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Back-fills <c>OAuthGrantTypeInClient</c> with one relation row per legacy
		/// <c>OAuthClientApp.GrantTypeId</c> value that does not already have a matching
		/// relation. Replaces the prior dialect-specific SQL scripts.
		/// </summary>
		public void Execute(UserConnection userConnection) {
			if (userConnection.EntitySchemaManager.FindInstanceByName(GrantTypeInClientSchemaName) == null) {
				_log.Info("MigrateOAuthGrantTypeInClient: OAuthGrantTypeInClient schema not present; skipping back-fill.");
				return;
			}
			List<LegacyClientGrantPair> pairs = GetLegacyPairsMissingRelations(userConnection);
			int migrated = 0;
			foreach (LegacyClientGrantPair pair in pairs) {
				InsertRelation(userConnection, pair.ClientAppId, pair.GrantTypeId);
				migrated++;
			}
			_log.Info($"MigrateOAuthGrantTypeInClient: created {migrated} relation row(s) from legacy GrantTypeId.");
		}

		#endregion

	}

	#endregion

}
