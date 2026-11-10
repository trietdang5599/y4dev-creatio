 namespace Terrasoft.Configuration.UIRedirectBlacklistEventListener
{
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: UIRedirectBlacklistEventListener

	/// <summary>
	/// Listener for 'UIRedirectBlacklist' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "UIRedirectBlacklist")]
	public class UIRedirectBlacklistEventListener : BaseEntityEventListener
	{

		private void CheckCanManageSolution(object sender) {
			var entity = (Entity)sender;
			var userConnection = entity.UserConnection;
			userConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageSolution");
		}

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
		}

		/// <summary>
		/// Handles entity Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnUpdating(sender, e);
		}

		/// <summary>
		/// Handles entity Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			CheckCanManageSolution(sender);
			base.OnDeleting(sender, e);
		}

		#endregion

	}

	#endregion

}

