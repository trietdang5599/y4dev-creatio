namespace Terrasoft.Configuration.Omnichannel.Messaging
{
	using System.Linq;
	using Core.Entities;
	using Core.Entities.Events;

	#region Class: OmniChatSysAdminUnitEventListener

	[EntityEventListener(SchemaName = "SysAdminUnit")]
	public class OmniChatSysAdminUnitEventListener : BaseEntityEventListener
	{

		#region Methods: Public

		public override void OnUpdated(object sender, EntityAfterEventArgs e) {
			base.OnUpdated(sender, e);
			if (e.ModifiedColumnValues.Any(x => x.Name == "SysCultureId")) {
				var entity = (Entity)sender;
				new OmnichannelMessageMacrosStore(entity.UserConnection).ClearCache();
			}
		}

		#endregion

	}

	#endregion

}

