namespace Terrasoft.Configuration.SSP
{
	using System;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	/// <summary>
	/// Entity event listener to prevent deleting or modifying system external user.
	/// </summary>
	[EntityEventListener(SchemaName = "SysAdminUnit")]
	[EntityEventListener(SchemaName = "VwSysAdminUnit")]
	public class SSPSysAdminUnitEntityEventListener : BaseEntityEventListener
	{

		#region Fields: private

		private string _sysPortalConnectionUserName = "SysPortalConnection";

		#endregion

		#region Methods: private

		private bool IsSysPortalConnectionUser(Entity entity) {
			if (!entity.IsColumnValueLoaded("Name")) {
				var loadValuesEntity = entity.Schema.CreateEntity(entity.UserConnection);
				loadValuesEntity.FetchFromDB("Id", entity.PrimaryColumnValue, new[] { "Id", "Name" });
				entity.SetColumnValue("Name", loadValuesEntity.GetColumnValue("Name"));
			}
			return entity.GetTypedColumnValue<string>("Name") == _sysPortalConnectionUserName || 
				entity.GetTypedOldColumnValue<string>("Name") == _sysPortalConnectionUserName;
		}

		private void CheckSysPortalConnectionUser(Entity user) {
			if (IsSysPortalConnectionUser(user)) {
				var lczMessageTemplate = new LocalizableString(user.UserConnection.Workspace.ResourceStorage,
					"SSPSysAdminUnitEntityEventListener", "LocalizableStrings.SysPortalConnectionUserChangeException.Value");
				var lczMessage = string.Format(lczMessageTemplate, _sysPortalConnectionUserName);
				throw new Exception(lczMessage);
			}
		}

		#endregion

		#region Methods: public

		/// <inheritdoc/>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var user = (Entity)sender;
			CheckSysPortalConnectionUser(user);
			base.OnDeleting(sender, e);
		}

		/// <inheritdoc/>
		public override void OnSaving(object sender, EntityBeforeEventArgs e) {
			var user = (Entity)sender;
			CheckSysPortalConnectionUser(user);
			base.OnSaving(sender, e);
		}

		#endregion

	}
}
