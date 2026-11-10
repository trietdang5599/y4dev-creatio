namespace Terrasoft.Configuration
{
	using System;
	using System.Text.RegularExpressions;
	using Terrasoft.Core;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.SystemSettings.Notification;
	using Terrasoft.Core.SystemSettings.Objects;

	#region Class: ConfigurationSectionCacheHashInvalidationSysSettingsListener

	[DefaultBinding(typeof(ISysSettingsListener), Name = "ConfigurationSectionCacheHashInvalidationSysSettingsListener")]
	public class ConfigurationSectionCacheHashInvalidationSysSettingsListener : ISysSettingsListener
	{

		#region Fields: Private

		private static readonly Regex _hasMiniPageAddModeSettingCodeRegex =
			new Regex(@"Has\w+MiniPageAddMode", RegexOptions.Compiled);

		#endregion

		#region Methods: Private

		private static void UpdateCacheHashIfNeeded(ISysSettings sysSettings) {
			if (!_hasMiniPageAddModeSettingCodeRegex.IsMatch(sysSettings.Code)) {
				return;
			}
			var hashUpdater = ClassFactory.Get<IConfigurationCacheHashUpdater>();
			hashUpdater.UpdateCacheHash();
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
			UpdateCacheHashIfNeeded(sysSettings);
		}

		#endregion

	}

	#endregion

}

