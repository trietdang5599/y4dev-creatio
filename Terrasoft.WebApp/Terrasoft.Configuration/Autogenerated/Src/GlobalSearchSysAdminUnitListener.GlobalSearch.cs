namespace Terrasoft.Configuration.GlobalSearch
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Terrasoft.Common;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;

	#region Class:GlobalSearchSysAdminUnitListener

	/// <summary>
	/// Listener for 'VwSysAdminUnit' and 'SysAdminUnit' entity events.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysAdminUnit")]
	[EntityEventListener(SchemaName = "VwSysAdminUnit")]
	public class GlobalSearchSysAdminUnitListener : BaseEntityEventListener
	{
		#region Fields: Private

		private IEnumerable<string> _changeTrackedColumns = new[] { "Active", "ConnectionType" };

		#endregion

		#region Methods: Private

		private void UpdateRelatedContact(Entity entity) {
			var contactId = entity.IsColumnValueLoaded("ContactId") 
				? entity.GetTypedColumnValue<Guid>("ContactId") 
				: Guid.Empty;
			if (contactId.IsEmpty()) {
				return;
			}
			var uc = entity.UserConnection;
			var schema = uc.EntitySchemaManager.FindInstanceByName("Contact");
			var contactEntity = schema.CreateEntity(uc);
			if (contactEntity.FetchFromDB(contactId, false) ) {
				contactEntity.SetColumnValue("ModifiedOn", DateTime.UtcNow);
				contactEntity.Save(false);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>Handles entity Saved event. Updates user contact to start indexing.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			if (e.ModifiedColumnValues.Any(value => _changeTrackedColumns.Contains(value.Name))) {
				UpdateRelatedContact((Entity)sender);
			}
		}


		/// <summary>Handles entity Deleted event. Updates user contact to start indexing.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e) {
			base.OnDeleted(sender, e);
			UpdateRelatedContact((Entity)sender);
		}

		#endregion

	}

	#endregion

}
