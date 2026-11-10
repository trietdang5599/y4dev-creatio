using Terrasoft.Core.Entities;
using Terrasoft.Core.Entities.Events;

namespace Terrasoft.Configuration
{
  
	[EntityEventListener(SchemaName = "SysEntityRightByAdminOperation")]
	internal class SysEntityRightByAdminOperationEventListener : BaseEntityEventListener
	{

		#region Methods: Private

        private void ClearCache(Entity entity) => entity.UserConnection.DBSecurityEngine.ClearEntityRightsProvidedByAdminOperationsCache();
      
		#endregion
      
		#region Methods: Public

		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			ClearCache((Entity)sender);
		}

       public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			ClearCache((Entity)sender);
		}

		#endregion

	}
  
}
