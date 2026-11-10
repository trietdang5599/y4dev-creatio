namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using System.Collections.Concurrent;
	using System.Collections.Generic;
	using System.Diagnostics;
	using global::Common.Logging;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.OAuthIntegration;
	using Terrasoft.OAuthIntegration.Exception;

	#region Class: OAuthGrantTypeInClientEventListener

	[EntityEventListener(SchemaName = "OAuthGrantTypeInClient")]
	public class OAuthGrantTypeInClientEventListener : BaseOAuthApiCaller
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("OAuth20");
		private static readonly ConcurrentDictionary<Guid, Guid> _clientAppIdsByRelationId =
			new ConcurrentDictionary<Guid, Guid>();

		#endregion

		#region Constructors: Public

		public OAuthGrantTypeInClientEventListener() : base(new Dictionary<Type, string>() {
			{ typeof(ApiServerException), "LocalizableStrings.ClientApplicationHandlingErrorMessage.Value" },
			{ typeof(ApiServerConnectivityException), "LocalizableStrings.ConnectionErrorMessage.Value" }
		}) {}

		#endregion

		#region Methods: Private

		private static Guid GetOAuthClientAppId(Entity entity) {
			Guid clientAppId = Guid.Empty;
			try {
				clientAppId = entity.GetTypedColumnValue<Guid>("OAuthClientAppId");
			} catch (ItemNotFoundException) {
				// Deleted entities may no longer expose lookup column values in after-delete events.
			}
			if (clientAppId.IsEmpty()) {
				_clientAppIdsByRelationId.TryGetValue(entity.PrimaryColumnValue, out clientAppId);
			}
			return clientAppId;
		}

		private static Entity GetOAuthClientApp(Entity entity) {
			Guid clientAppId = GetOAuthClientAppId(entity);
			if (clientAppId.IsEmpty()) {
				return null;
			}
			Entity clientApp = entity.UserConnection.EntitySchemaManager.GetEntityByName("OAuthClientApp",
				entity.UserConnection);
			return clientApp.FetchFromDB(clientAppId) ? clientApp : null;
		}

		private static void RememberOAuthClientAppId(Entity entity) {
			Guid clientAppId = GetOAuthClientAppId(entity);
			if (!clientAppId.IsEmpty()) {
				_clientAppIdsByRelationId[entity.PrimaryColumnValue] = clientAppId;
			}
		}

		private static void ForgetOAuthClientAppId(Entity entity) {
			_clientAppIdsByRelationId.TryRemove(entity.PrimaryColumnValue, out _);
		}

		private void SynchronizeClient(Entity entity) {
			Stopwatch stopwatch = IsPerfLoggingEnabled ? Stopwatch.StartNew() : null;
			Guid clientAppId = GetOAuthClientAppId(entity);
			if (BaseOAuthApiCaller.TryTakePendingGrantTypeSyncSkip(clientAppId)) {
				BaseOAuthApiCaller.LogPerformance("OAuthGrantTypeInClientEventListener.SynchronizeClient.SkipUpdateClient",
					stopwatch, $"clientAppId='{clientAppId}'.");
				return;
			}
			Entity clientApp = GetOAuthClientApp(entity);
			if (clientApp == null) {
				BaseOAuthApiCaller.LogPerformance("OAuthGrantTypeInClientEventListener.SynchronizeClient.ClientNotFound",
					stopwatch, $"clientAppId='{clientAppId}'.");
				return;
			}
			if (OAuthClientAppInstallStatusHelper.IsNotInstalled(clientApp)) {
				// Not installed: the client is not registered in the Identity Service yet (ENG-78572).
				// Allow grant types to be prepared locally without triggering an Identity sync.
				BaseOAuthApiCaller.LogPerformance("OAuthGrantTypeInClientEventListener.SynchronizeClient.SkipNotInstalled",
					stopwatch, $"clientAppId='{clientAppId}'.");
				return;
			}
			try {
				IdentityServiceWrapper.UpdateClient(GetClientAppInfoFromEntity(clientApp));
				BaseOAuthApiCaller.LogPerformance("OAuthGrantTypeInClientEventListener.SynchronizeClient",
					stopwatch, $"clientAppId='{clientAppId}'.");
			} catch (Exception ex) {
				_log.Error($"Error occurred during OAuth grant type synchronization: {ex}");
				throw;
			}
		}

		#endregion

		#region Methods: Protected

		protected override void ThrowException(string errorMessage) {
			throw new Exception(errorMessage);
		}

		#endregion

		#region Methods: Public

		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			OAuthClientGrantTypeHelper.InvalidateClientCache(GetOAuthClientAppId(entity));
			SynchronizeClient(entity);
		}

		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			base.OnDeleting(sender, e);
			RememberOAuthClientAppId((Entity)sender);
		}

		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			OAuthClientGrantTypeHelper.InvalidateClientCache(GetOAuthClientAppId(entity));
			try {
				SynchronizeClient(entity);
			} finally {
				ForgetOAuthClientAppId(entity);
			}
		}

		#endregion

	}

	#endregion

}

