 namespace Terrasoft.Configuration
{
	using Terrasoft.Core.Entities.Events;

	#region Class: PortalConfigurationSectionCacheHashInvalidationEventListener

	/// <summary>
	/// Invalidates configuration section cache hash on SysModuleEntityInPortal entities change.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysModuleEntityInPortal")]
	public class PortalConfigurationSectionCacheHashInvalidationEventListener
		: ConfigurationSectionCacheHashInvalidationEventListener
	{
	}

	#endregion

}
