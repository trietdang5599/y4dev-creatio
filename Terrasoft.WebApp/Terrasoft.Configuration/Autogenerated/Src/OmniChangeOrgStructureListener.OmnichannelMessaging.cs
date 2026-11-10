namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: OmniChangeOrgStructureListener

	/// <summary>
	/// Listener for organizational structure changes to clear omnichannel caches.
	/// </summary>
	[EntityEventListener(SchemaName = "SysUserInRole")]
	[EntityEventListener(SchemaName = "SysFuncRoleInOrgRole")]
	public class OmniChangeOrgStructureListener : BaseEntityEventListener
	{

		#region Methods: Private

		private static void ClearCache(Entity entity) {
			try {
				var userConnection = entity.UserConnection;
				var chatOperatorCache = new ChatOperatorCache(userConnection);
				chatOperatorCache.ClearCache();
				var chatOperatorTransferStore = new ChatOperatorTransferStore(userConnection);
				chatOperatorTransferStore.ClearCache();
			} catch (Exception) {
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			var entity = (Entity)sender;
			ClearCache(entity);
		}

		/// <inheritdoc />
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			var entity = (Entity)sender;
			ClearCache(entity);
		}

		#endregion

	}

	#endregion

}
