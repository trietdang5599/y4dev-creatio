namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Configuration.RightsService;
	using Terrasoft.Core;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;

	#region Interface: IAdminUnitEventListenerHelper

	public interface IAdminUnitEventListenerHelper
	{

		#region Methods: Public

		/// <summary>
		/// Set RecordRight for SysAdminUnit entity.
		/// </summary>
		/// <param name="adminUnit"><see cref="Entity"/> instance.</param>
		void SetRecordRightForAdminUnit(Entity adminUnit);

		/// <summary>
		/// Set ContactId for SysAdminUnit entity.
		/// </summary>
		/// <param name="adminUnit"><see cref="Entity"/> instance.</param>
		void SetAdminUnitContactId(Entity adminUnit);

		#endregion

	}

	#endregion

	#region Class: AdminUnitEventListenerHelper

	/// <summary>
	/// Helper for 'SysAdminUnit' entity events.
	/// </summary>
	[DefaultBinding(typeof(IAdminUnitEventListenerHelper))]
	public class AdminUnitEventListenerHelper : IAdminUnitEventListenerHelper
	{

		#region Properties: Public

		public RightsHelper RightsHelper;

		#endregion

		#region Methods: Private

		private Guid CreateNewContact(UserConnection userConnection, string contactName) {
			EntitySchema contactSchema = userConnection.EntitySchemaManager.GetInstanceByName("Contact");
			Entity contact = contactSchema.CreateEntity(userConnection);
			var contactId = Guid.NewGuid();
			contact.SetDefColumnValues();
			contact.SetColumnValue("Id", contactId);
			contact.SetColumnValue("Name", contactName);
			contact.Save(false);
			return contactId;
		}

		private bool ContainsColumnValues(Entity adminUnit, IEnumerable<string> values) {
			var columnValueNames = adminUnit.GetColumnValueNames();
			return values.All(value => columnValueNames.Contains(value));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Set ContactId for SysAdminUnit entity.
		/// </summary>
		/// <param name="adminUnit"><see cref="Entity"/> instance.</param>
		public void SetAdminUnitContactId(Entity adminUnit) {
			if (ContainsColumnValues(adminUnit, new [] { "ContactId", "Name" })) {
				if (adminUnit.GetTypedColumnValue<Guid>("ContactId").IsNotEmpty()) {
					return;
				}
				var contactName = adminUnit.GetTypedColumnValue<string>("Name");
				var contactId = CreateNewContact(adminUnit.UserConnection, contactName);
				adminUnit.SetColumnValue("ContactId", contactId);
			}
		}

		/// <summary>
		/// Set RecordRight for SysAdminUnit entity.
		/// </summary>
		/// <param name="adminUnit"><see cref="Entity"/> instance.</param>
		public void SetRecordRightForAdminUnit(Entity adminUnit) {
			if (ContainsColumnValues(adminUnit, new[] { "ContactId", "ConnectionType" }) &&
				adminUnit.GetTypedColumnValue<Guid>("ContactId") != Guid.Empty &&
				adminUnit.GetTypedColumnValue<bool>("ConnectionType")) {
				RightsHelper = RightsHelper ?? new RightsHelper(adminUnit.UserConnection);
				RightsHelper.SetRecordRight(adminUnit.GetTypedColumnValue<Guid>("Id"), "Contact",
					adminUnit.GetTypedColumnValue<string>("ContactId"), 0, 2);
				RightsHelper.SetRecordRight(adminUnit.GetTypedColumnValue<Guid>("Id"), "Contact",
					adminUnit.GetTypedColumnValue<string>("ContactId"), 1, 2);
			}
		}

		#endregion

	}

	#endregion

}

