namespace Terrasoft.Configuration
{
	using System;

	#region Class: VwSysAdminUnit_CrtBaseEventsProcess

	public partial class VwSysAdminUnit_CrtBaseEventsProcess<TEntity>
	{

		#region Methods: Public

		public virtual bool GetIsAdminUnitNotUser() {
			var currentTypeId = Entity.GetTypedColumnValue<Guid>("SysAdminUnitTypeId");
			return (currentTypeId != UserTypeId) && (currentTypeId != SSPUserTypeId);
		}

		public virtual bool ValidateCanChangeRecord() {
			if (Entity.Id != UserConnection.CurrentUser.Id) {
				UserConnection.DBSecurityEngine.CheckCanExecuteOperation("CanManageAdministration");
			}
			return true;
		}

		public override void CheckCanManageLookups() {
		}

		#endregion

	}

	#endregion

}
