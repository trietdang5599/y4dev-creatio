namespace Terrasoft.Configuration
{
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using CoreSysSettings = Terrasoft.Core.Configuration.SysSettings;
	using CoreSysSettingsRights = Terrasoft.Core.Configuration.SysSettingsRights;

	#region Class: SysSettingsRightsEventListener

	/// <summary>
	/// Class provides events handling for system settings rights.
	/// </summary>
	[EntityEventListener(SchemaName = "SysSettingsRights")]
	public class SysSettingsRightsEventListener : BaseSysSettingsEventListener<CoreSysSettingsRights>
	{

		#region Methods: Protected

		protected override CoreSysSettingsRights CreateCoreEntity(UserConnection userConnection) {
			return new CoreSysSettingsRights(userConnection);
		}

		protected override void ActualizeCoreEntity(UserConnection userConnection, 
				CoreSysSettingsRights coreEntity, EntityChangeType entityChangeType) {
			CoreSysSettings.ActualizeRights(userConnection, coreEntity, entityChangeType);
		}

		#endregion

	}

	#endregion

}
 
