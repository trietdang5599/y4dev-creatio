namespace Terrasoft.Configuration
{
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class: SysAdminUnitEventListener

	/// <summary>
	/// Listener for 'SysAdminUnit' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysAdminUnit")]
	public class SysAdminUnitEventListener : BaseEntityEventListener
	{

		#region Properties: Public

		public IAdminUnitEventListenerHelper AdminUnitEventListenerHelper;

		#endregion

		#region Methods: Private

		private static bool IsUserType(Entity adminUnit) {
			if (adminUnit.GetIsColumnValueLoaded("SysAdminUnitTypeValue") &&
					adminUnit.GetTypedColumnValue<int>("SysAdminUnitTypeValue") == BaseConsts.UserSysAdminUnitTypeValue) {
				return true;
			}
			return false;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles entity Inserted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserted(object sender, EntityAfterEventArgs e) {
			base.OnInserted(sender, e);
			Entity adminUnit = (Entity)sender;
			AdminUnitEventListenerHelper = AdminUnitEventListenerHelper ?? new AdminUnitEventListenerHelper();
			AdminUnitEventListenerHelper.SetRecordRightForAdminUnit(adminUnit);
		}

		/// <summary>
		/// Handles entity Saving event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			base.OnSaving(sender, e);
			Entity adminUnit = (Entity)sender;
			if (!IsUserType(adminUnit)) {
				return;
			}
			AdminUnitEventListenerHelper = AdminUnitEventListenerHelper ?? new AdminUnitEventListenerHelper();
			AdminUnitEventListenerHelper.SetAdminUnitContactId(adminUnit);
		}

		#endregion

	}

	#endregion

}

