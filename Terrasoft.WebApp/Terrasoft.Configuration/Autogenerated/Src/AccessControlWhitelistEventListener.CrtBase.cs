namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Core.ClientCache;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	/// <summary>
	/// Listener for 'AccessControlWhitelist' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />

	[EntityEventListener(SchemaName = "AccessControlWhitelist")]
	public class AccessControlWhitelistEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void ResetCache(object sender) {
			((Entity)sender).UserConnection.ApplicationCache.Remove(ACLService.CacheKey);
			var clientCacheStore = ClassFactory.Get<IClientCacheStore>();
			clientCacheStore.SetHashValue(AccessControlWhitelistConstants.WhiteListCacheHashKey, Guid.NewGuid().ToString("N"));
		}

		#endregion

		#region Methods: Public

		/// <summary>Handles entity Inserted event. Clear cache of AccessControlWhitelist.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			ResetCache(sender);
		}

		/// <summary>Handles entity Saved event. Clear cache of AccessControlWhitelist.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			ResetCache(sender);
		}
	  
		/// <summary>Handles entity Deleted event. Clear cache of AccessControlWhitelist.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ResetCache(sender);
		}

		#endregion

	}

} 

