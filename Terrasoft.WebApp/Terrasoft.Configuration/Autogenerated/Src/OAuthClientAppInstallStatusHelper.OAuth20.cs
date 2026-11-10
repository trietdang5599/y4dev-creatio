namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using Creatio.FeatureToggling;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;

	#region Class: OAuthClientAppInstallStatusHelper

	/// <summary>
	/// Shared helpers for the OAuthClientApp install lifecycle (ENG-78572): the feature toggle, the
	/// <c>OAuthClientAppStatus</c> record ids, and "is this client not installed" checks. Used by
	/// <c>OAuthClientAppListener</c> and the sibling listeners (grant type / resource / redirect) so that
	/// none of them contacts the Identity Service while a client is in the <c>Not installed</c> state.
	/// </summary>
	public static class OAuthClientAppInstallStatusHelper
	{

		#region Constants: Public

		/// <summary>Feature toggle that gates the install/not-installed lifecycle (F1).</summary>
		public const string FeatureCode = "OAuthClientAppInstallStatus";

		/// <summary>
		/// Feature toggle (F2) that, on top of <see cref="FeatureCode"/>, allows creating integrations
		/// directly in the Not installed state. Has no effect unless <see cref="FeatureCode"/> is on.
		/// </summary>
		public const string AllowCreateNotInstalledFeatureCode = "OAuthClientAppAllowCreateNotInstalled";

		/// <summary>Non-stored boolean column requesting a pre-generated ClientId (never persisted as true).</summary>
		public const string GenerateClientIdColumnName = "GenerateClientId";

		/// <summary>Id of the <c>OAuthClientAppStatus</c> record "Installed".</summary>
		public static readonly Guid InstalledStatusId = new Guid("87f2cf13-71e7-4f69-8dd8-19d3c4d2cd69");

		/// <summary>Id of the <c>OAuthClientAppStatus</c> record "Not installed".</summary>
		public static readonly Guid NotInstalledStatusId = new Guid("273670c2-d2ef-4c6a-b0f4-44b43e08bab7");

		#endregion

		#region Methods: Public

		/// <summary>Whether the install lifecycle feature (F1) is enabled.</summary>
		public static bool IsFeatureEnabled() {
			return Features.GetIsEnabled(FeatureCode);
		}

		/// <summary>
		/// Whether integrations may be created in the Not installed state: requires BOTH the install
		/// lifecycle feature (F1) and the create-not-installed feature (F2). F2 alone has no effect.
		/// </summary>
		public static bool IsCreateNotInstalledEnabled() {
			return IsFeatureEnabled() && Features.GetIsEnabled(AllowCreateNotInstalledFeatureCode);
		}

		/// <summary>Reads the <c>StatusId</c> of an OAuthClientApp entity (Guid.Empty if the column is absent).</summary>
		public static Guid GetStatusId(Entity clientApp) {
			return clientApp.Schema.Columns.FindByName("Status") == null
				? Guid.Empty
				: clientApp.GetTypedColumnValue<Guid>("StatusId");
		}

		/// <summary>True when the feature is on and the given OAuthClientApp entity is "Not installed".</summary>
		public static bool IsNotInstalled(Entity clientApp) {
			return IsFeatureEnabled() && GetStatusId(clientApp) == NotInstalledStatusId;
		}

		/// <summary>
		/// True when the feature is on and the referenced OAuthClientApp is "Not installed". For sibling
		/// listeners (grant type / resource / redirect) that hold only the client id. Returns false when the
		/// client cannot be resolved, so normal synchronization proceeds for installed/legacy clients.
		/// </summary>
		public static bool IsClientNotInstalled(UserConnection userConnection, Guid clientAppId) {
			if (!IsFeatureEnabled() || clientAppId.IsEmpty()) {
				return false;
			}
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, "OAuthClientApp");
			if (esq.RootSchema.Columns.FindByName("Status") == null) {
				return false;
			}
			EntitySchemaQueryColumn statusColumn = esq.AddColumn("Status");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", clientAppId));
			EntityCollection rows = esq.GetEntityCollection(userConnection);
			return rows.Count > 0 && rows[0].GetTypedColumnValue<Guid>(statusColumn.Name) == NotInstalledStatusId;
		}

		#endregion

	}

	#endregion

}

