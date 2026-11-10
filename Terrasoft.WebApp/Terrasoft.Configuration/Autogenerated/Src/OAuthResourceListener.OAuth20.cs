namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Generic;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.OAuthIntegration.DTO;
	using Terrasoft.OAuthIntegration.Exception;

	#region Class: OAuthResourceListener

	[EntityEventListener(SchemaName = "OAuthResource")]
	public class OAuthResourceListener : BaseOAuthApiCaller
	{

		#region Constructors: Public

		public OAuthResourceListener() : base(new Dictionary<Type, string>() {
			{ typeof(ApiServerException), "LocalizableStrings.ResourceRegisteringErrorMessage.Value" },
			{ typeof(ApiServerConnectivityException), "LocalizableStrings.ConnectionErrorMessage.Value" }
		}) {}

		#endregion

		#region Methods: Private

		private ApiResourceInfo GetApiResourceFromEntity(Entity entity, Dictionary<string, string> properties = null) {
			var resourceName = entity.GetTypedColumnValue<string>("Name");
			var resourceDisplayName = entity.GetTypedColumnValue<string>("DisplayName");
			var apiResource = new ApiResourceInfo {
				Name = resourceName,
				DisplayName = resourceDisplayName,
				Properties = properties
			};
			return apiResource;
		}

		#endregion

		#region Methods: Protected

		protected override void ThrowException(string errorMsg) => throw new OAuthResourceException(errorMsg);

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
			var properties = new Dictionary<string, string> {
				{ "Type", "ApplicationAccess" }
			};
			ApiResourceInfo apiResource = GetApiResourceFromEntity(entity, properties);
			ExecuteApiCall(() => apiResource = IdentityServiceWrapper.AddResource(apiResource, true), entity.UserConnection, e);
			entity.SetColumnValue("ApiSecret", apiResource.ApiSecret);
		}

		/// <summary>
		/// Handles entity Saving event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		/// <exception cref="SystemOperationRestrictedException">Current user session is created using external access.
		/// </exception>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnSaving(sender, e);
		}

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		/// <exception cref="InvalidOperationException">Deleting an OAuth resource is not permitted.
		/// </exception>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var entity = (Entity)sender;
			var resourceStorage = entity.UserConnection.ResourceStorage;
			string message = new LocalizableString(resourceStorage, "OAuthResourceListener", "ResourceDeletingErrorMessage");
			throw new InvalidOperationException(message);
		}

		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnUpdating(sender, e);
			var entity = (Entity)sender;
			ApiResourceInfo apiResource = GetApiResourceFromEntity(entity);
			var secret = entity.GetTypedColumnValue<string>("ApiSecret");
			if (secret.IsNotNullOrEmpty()) {
				var secrets = new[] { secret };
				ExecuteApiCall(() => IdentityServiceWrapper.UpdateResource(apiResource, secrets), entity.UserConnection, e);
				return;
			}
			ExecuteApiCall(() => IdentityServiceWrapper.UpdateResource(apiResource), entity.UserConnection, e);
		}

		#endregion

	}

	#endregion

}

