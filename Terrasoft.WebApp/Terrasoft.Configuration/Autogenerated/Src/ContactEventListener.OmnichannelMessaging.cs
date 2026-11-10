namespace Terrasoft.Configuration
{
	using System;
	using Terrasoft.Configuration.Omnichannel.Messaging;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: ContactEventListener

	/// <summary>
	/// Listener for 'Contact' entity events.
	/// </summary>
	/// <seealso cref="BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "Contact")]
	public class ContactEventListener : BaseEntityEventListener
	{

		#region Methods: Public

		/// <summary>
		/// Handles entity Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			Entity contact = (Entity)sender;
			var id = contact.GetTypedColumnValue<Guid>("Id");
			OmnichannelContactIdentifier.RemoveIdentityFromCache(id, contact.UserConnection);
		}

		#endregion

	}

	#endregion

}

