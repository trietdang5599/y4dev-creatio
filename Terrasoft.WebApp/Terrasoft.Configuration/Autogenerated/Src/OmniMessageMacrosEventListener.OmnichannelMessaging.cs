namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: OmniChatEventListener

	/// <summary>
	/// Class provides OmniMessageMacros entity events handling.
	/// </summary>
	[EntityEventListener(SchemaName = "OmniMessageMacros")]
	public class OmniMessageMacrosEventListener : BaseEntityEventListener
	{

		#region Methods: Public

		/// <summary>
		/// Handles entity Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			new OmnichannelMessageMacrosStore(((Entity)sender).UserConnection).ClearCache();
		}

		#endregion

	}

	#endregion

}
