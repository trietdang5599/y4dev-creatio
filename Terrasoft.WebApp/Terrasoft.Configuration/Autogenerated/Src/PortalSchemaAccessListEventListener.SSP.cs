namespace Terrasoft.Configuration
{
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Store;

	#region Class: PortalSchemaAccessListEventListener

	/// <summary>
	/// Listener for 'PortalSchemaAccessList' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "PortalSchemaAccessList")]
	[EntityEventListener(SchemaName = "PortalColumnAccessList")]
	public class PortalSchemaAccessListEventListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void ClearCachedAllowedColumns(UserConnection userConnection) {
			userConnection.ApplicationCache.WithLocalCaching()
				.SetOrRemoveValue(RightsHelper.AllowedSspColumnsCacheKey, null);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			Entity portalSchema = (Entity)sender;
			SSPSecurityEngine.ClearCachedAllowedColumns(portalSchema.UserConnection);
			ClearCachedAllowedColumns(portalSchema.UserConnection);
		}

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			Entity portalSchema = (Entity)sender;
			SSPSecurityEngine.ClearCachedAllowedColumns(portalSchema.UserConnection);
			ClearCachedAllowedColumns(portalSchema.UserConnection);
		}

		#endregion

	}

	#endregion

}

