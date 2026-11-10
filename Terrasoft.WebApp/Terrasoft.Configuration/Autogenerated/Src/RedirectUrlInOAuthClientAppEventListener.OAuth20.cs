namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.OAuth20;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.OperationLog;
	using Terrasoft.OAuthIntegration.DTO;
	using Terrasoft.OAuthIntegration.Exception;
	using Terrasoft.Core.Entities.Events;

	#region Class: RedirectUrlInOAuthClientAppEventListener

	[EntityEventListener(SchemaName = "RedirectUrlInOAuthClientApp")]
	public class RedirectUrlInOAuthClientAppEventListener : BaseOAuthApiCaller
	{

		#region Constructors: Public

		public RedirectUrlInOAuthClientAppEventListener(UserConnection userConnection) : base(
			new Dictionary<Type, string>() {
				{ typeof(ApiServerException), "LocalizableStrings.ClientApplicationHandlingErrorMessage.Value" },
				{ typeof(ApiServerConnectivityException), "LocalizableStrings.ConnectionErrorMessage.Value" }
			}) {
			_systemUserConnection = userConnection.AppConnection.SystemUserConnection as SystemUserConnection;
			
		}

		#endregion

		#region Fields: Private

		private readonly SystemUserConnection _systemUserConnection;

		#endregion

		#region Methods: Private

		private static Entity GetOAuthClientApp(Entity entity) {
			var oAuthClientAppId = entity.GetTypedColumnValue<Guid>("OAuthClientAppId");
			var userConnection = entity.UserConnection;
			EntitySchemaManager entitySchemaManager = userConnection.EntitySchemaManager;
			Entity oAuthClientApp = entitySchemaManager.GetEntityByName("OAuthClientApp", userConnection);
			if (oAuthClientAppId.IsEmpty() || !oAuthClientApp.FetchFromDB(oAuthClientAppId)) {
				return null;
			}
			return oAuthClientApp;
		}

		private void LogOperations(Entity entity, Queue<KeyValuePair<OperationResult, string>>  operations) {
			if (_systemUserConnection == null) {
				return;
			}
			if (operations == null || operations.Count == 0) {
				return;
			}
			var clientAppName = entity.GetTypedColumnValue<string>("Name");
			while (operations.Count > 0) {
				KeyValuePair<OperationResult, string> operation = operations.Dequeue();
				OperationResult operationResult = operation.Key;
				string redirectUrl = operation.Value;
				OperationLogger.Instance.LogOAuthClientAppRedirectUrlChanged(_systemUserConnection, clientAppName,
					redirectUrl, operationResult);	
			}
		}

		private void CheckUserPermissions(object sender) {
			CheckCanManageSolution(sender);
			CheckCanManageOAuth(sender);
		}

		private void UpdateIdentityValues(Entity entity, EntityBeforeEventArgs e, string redirectUrl = null) {
			Entity oauthClientApp = GetOAuthClientApp(entity);
			if (oauthClientApp != null && OAuthClientAppInstallStatusHelper.IsNotInstalled(oauthClientApp)) {
				// Not installed: redirect URIs are prepared locally; the client is not registered in the
				// Identity Service yet, so no sync is performed until Install (ENG-78572).
				return;
			}
			var operations = new Queue<KeyValuePair<OperationResult, string>>();
			ClientAppInfoRequest clientAppRequest = GetClientAppInfoFromEntity(oauthClientApp);
			var redirectUrlList = clientAppRequest.RedirectUris.ToList();
			if (redirectUrl != null) {
				var oldValue = entity.GetColumnOldValue("RedirectUrl");
				if (oldValue != null && (string)oldValue != redirectUrl) {
					string oldRedirectUrl = (string)oldValue;
					redirectUrlList.RemoveAll(url => url == oldRedirectUrl);
					operations.Enqueue(new KeyValuePair<OperationResult, string>(OperationResult.Delete,
						oldRedirectUrl));
				}
				if (!redirectUrlList.Contains(redirectUrl)) {
					redirectUrlList.Add(redirectUrl);
					operations.Enqueue(new KeyValuePair<OperationResult, string>(OperationResult.Add, redirectUrl));
				}
				
			} else {
				redirectUrl = entity.GetTypedColumnValue<string>("RedirectUrl");
				redirectUrlList.RemoveAll(url => url == redirectUrl);
				operations.Enqueue(new KeyValuePair<OperationResult, string>(OperationResult.Delete, redirectUrl));
			}
			clientAppRequest.RedirectUris = redirectUrlList;
			ExecuteApiCall(() => IdentityServiceWrapper.UpdateClient(clientAppRequest), entity.UserConnection, e);
			LogOperations(oauthClientApp, operations);
		}

		#endregion

		#region Methods: Protected

		protected override void ThrowException(string errorMessage) {
			throw new Exception(errorMessage);
		}

		#endregion

		#region Methods: Public

		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			CheckUserPermissions(sender);
			base.OnSaving(sender, e);
			var entity = (Entity)sender;
			var redirectUrl = entity.GetTypedColumnValue<string>("RedirectUrl");
			ValidateRedirectUrl(redirectUrl, entity.UserConnection);
			UpdateIdentityValues(entity, e, redirectUrl);
		}

		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckUserPermissions(sender);
			base.OnDeleting(sender, e);
			var entity = (Entity)sender;
			UpdateIdentityValues(entity, e);
		}

		#endregion

	}

	#endregion

}

