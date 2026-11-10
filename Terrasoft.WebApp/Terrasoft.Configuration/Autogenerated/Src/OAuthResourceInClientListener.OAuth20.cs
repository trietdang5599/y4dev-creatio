namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.OAuthIntegration.DTO;
	using Terrasoft.OAuthIntegration.Exception;

	#region Class: OAuthResourceInClientListener

	[EntityEventListener(SchemaName = "OAuthResourceInClient")]
	public class OAuthResourceInClientListener : BaseOAuthApiCaller
	{

		#region Constructors: Public

		public OAuthResourceInClientListener() : base(new Dictionary<Type, string>() {
			{ typeof(ApiServerException), "LocalizableStrings.OAuthResourceInClientErrorMessage.Value" },
			{ typeof(ApiServerConnectivityException), "LocalizableStrings.ConnectionErrorMessage.Value" }
		}) {}

		#endregion

		#region Methods: Private

		private string GetResourceName(Guid resourceId, string resourceSchema, string searchColumn, UserConnection userConnection) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var esq = new EntitySchemaQuery(userConnection.EntitySchemaManager, resourceSchema);
			EntitySchemaQueryColumn colId = esq.AddColumn(searchColumn);
			IEntitySchemaQueryFilterItem resourceNameFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Id", resourceId);
			esq.Filters.Add(resourceNameFilter);
			EntityCollection entityCollection = esq.GetEntityCollection(userConnection);
			var resourceName = entityCollection[0].GetTypedColumnValue<string>(colId.Name);
			BaseOAuthApiCaller.LogPerformance("OAuthResourceInClientListener.GetResourceName", stopwatch,
				$"schema='{resourceSchema}' resourceId='{resourceId}'.");
			return resourceName;
		}

		private string GetResourceNameByResourceId(Guid resourceId, UserConnection userConnection) {
			string resourceName = GetResourceName(resourceId, "OAuthResource", "Name", userConnection);
			return resourceName;
		}

		private string GetClientIdByClientAppId(Guid clientAppId, UserConnection userConnection) {
			string resourceName = GetResourceName(clientAppId, "OAuthClientApp", "ClientId", userConnection);
			return resourceName;
		}

		private GrantAccessInfo GetGrantAccessInfoFromEntity(Entity entity) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var clientAppId = entity.GetTypedColumnValue<Guid>("OAuthClientId");
			var resourceId = entity.GetTypedColumnValue<Guid>("OAuthResourceId");
			string resourceName = GetResourceNameByResourceId(resourceId, entity.UserConnection);
			string clientId = GetClientIdByClientAppId(clientAppId, entity.UserConnection);
			BaseOAuthApiCaller.LogPerformance("OAuthResourceInClientListener.GetGrantAccessInfoFromEntity", stopwatch,
				$"clientAppId='{clientAppId}' resourceId='{resourceId}'.");
			return new GrantAccessInfo {
				ClientId = clientId,
				ResourceName = resourceName
			};
		}

		#endregion

		#region Methods: Protected

		protected override void ThrowException(string errorMessage) => throw new OAuthResourceInClientException(errorMessage);

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnInserting(sender, e);
			var entity = (Entity)sender;
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			var clientAppId = entity.GetTypedColumnValue<Guid>("OAuthClientId");
			var resourceId = entity.GetTypedColumnValue<Guid>("OAuthResourceId");
			if (OAuthClientAppInstallStatusHelper.IsClientNotInstalled(entity.UserConnection, clientAppId)) {
				// Not installed: the client is not registered in the Identity Service yet (ENG-78572) — skip.
				return;
			}
			// Identity's /clients/addregistrar replaces AllowedScopes with the standard OIDC set
			// and ignores the resource scopes from the request, so we must always call
			// GrantAccess to actually attach the default OAuthResource to the new client.
			GrantAccessInfo grantAccessInfo = GetGrantAccessInfoFromEntity(entity);
			ExecuteApiCall(() => IdentityServiceWrapper.GrantAccess(grantAccessInfo), entity.UserConnection, e);
			BaseOAuthApiCaller.LogPerformance("OAuthResourceInClientListener.OnInserting", stopwatch,
				$"clientAppId='{clientAppId}' resourceId='{resourceId}'.");
		}

		/// <summary>
		/// Handles entity remove event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			if (OAuthClientAppInstallStatusHelper.IsClientNotInstalled(entity.UserConnection,
					entity.GetTypedColumnValue<Guid>("OAuthClientId"))) {
				// Not installed: no Identity Service client to revoke scopes from (ENG-78572) — skip.
				return;
			}
			GrantAccessInfo grantAccessInfo = GetGrantAccessInfoFromEntity(entity);
			ExecuteApiCall(() => IdentityServiceWrapper.DeleteClientScopes(new ClientScopesRequest {
				ClientId = grantAccessInfo.ClientId,
				AllowedScopes = new List<string> { grantAccessInfo.ResourceName }
			}), entity.UserConnection, e);
		}

		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnUpdating(sender, e);
		}

		#endregion
	}

	#endregion

}

