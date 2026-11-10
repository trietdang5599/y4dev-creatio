namespace Terrasoft.Configuration.OAuth20
{
	using System;
	using Quartz.Collection;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.SystemSettings.Notification;
	using Terrasoft.Core.SystemSettings.Objects;
	using Terrasoft.OAuthIntegration.HealthCheck;

	#region Class: OAuthSysSettingsListener

	[DefaultBinding(typeof(ISysSettingsListener), Name = "OAuthSysSettingsListener")]
	public class OAuthSysSettingsListener : ISysSettingsListener
	{

		#region Fields: Private

		private readonly HashSet<string> _oauthSysSettings = new HashSet<string> {
			"OAuth20IdentityServerClientSecret", "OAuth20IdentityServerClientId", "OAuth20IdentityServerUrl"
		};

		private readonly Lazy<OAuthConfigService> _service = new Lazy<OAuthConfigService>(() => new OAuthConfigService());

		#endregion

		#region Methods: Private

		private static bool NeedRegisterOAuthResource(OAuthHealthCheckStatus status) {
			return status.HasProblem && status.IsSystemSettingsFilledIn
				&& status.IsIdentityServiceAvailable && status.IsAccessTokenRetrievableForSystemActions 
				&& !status.IsDefaultResourceRegistered;
		}

		private static bool GetNeedCreateDefaultResource() {
			var healthCheckService = ClassFactory.Get<IOAuthHealthCheckService>();
			OAuthHealthCheckStatus status = healthCheckService.GetHealthStatus();
			return NeedRegisterOAuthResource(status);
		}

		private void ClearOAuthDefaultResourceCache() {
			_service.Value.RemoveDefaultResourceNameFromCache();
			ClassFactory.Get<Terrasoft.OAuthIntegration.IIdentityServiceInfoProvider>().InvalidateVersionCache();
		}

		private void CreateDefaultResource() {
			_service.Value.AddDefaultResource();
		}

		#endregion

		#region Methods: Public

		public void OnSysSettingsChanged(UserConnection userConnection, ISysSettings sysSettings) {
		}

		public void OnSysSettingsRightsChanged(UserConnection userConnection, ISysSettings sysSettings,
			ISysSettingsRights sysSettingsRights) {
		}

		public void OnSysSettingsValueChanged(UserConnection userConnection, ISysSettings sysSettings,
			Guid sysAdminUnitId, object sysSettingsValue) {
			if (!_oauthSysSettings.Contains(sysSettings.Code)) {
			  return;
			}
			ClearOAuthDefaultResourceCache();
			if (!GetNeedCreateDefaultResource()) {
				return;
			}
			CreateDefaultResource();
		}

		#endregion

	}

	#endregion

}


