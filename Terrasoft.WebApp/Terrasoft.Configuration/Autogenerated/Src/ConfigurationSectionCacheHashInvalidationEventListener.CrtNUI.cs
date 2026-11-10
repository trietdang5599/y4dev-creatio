namespace Terrasoft.Configuration
{
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: ConfigurationSectionCacheHashInvalidationEventListener

	/// <summary>
	/// Invalidates configuration section cache hash on SysModule* entities change.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysModule")]
	[EntityEventListener(SchemaName = "SysModuleEdit")]
	[EntityEventListener(SchemaName = "SysModuleEntity")]
	[EntityEventListener(SchemaName = "SysModuleVisa")]
	[EntityEventListener(SchemaName = "SysModuleInWorkplace")]
	public class ConfigurationSectionCacheHashInvalidationEventListener : BaseEntityEventListener
	{

		private readonly IConfigurationCacheHashUpdater _cacheHashUpdater = new ConfigurationCacheHashUpdater();

		#region Methods: Public

		/// <inheritdoc cref="BaseEntityEventListener.OnUpdated"/>
		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			_cacheHashUpdater.UpdateCacheHash();
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnDeleted"/>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			_cacheHashUpdater.UpdateCacheHash();
		}

		/// <inheritdoc cref="BaseEntityEventListener.OnInserted"/>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			_cacheHashUpdater.UpdateCacheHash();
		}

		#endregion
	}

	#endregion

}
