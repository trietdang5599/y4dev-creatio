namespace Terrasoft.Configuration.QueryExecutionRules
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Entities.Events;
	using Terrasoft.Core.Factories;
	using Terrasoft.Core.QueryExecutionRules;

	#region Class: SysQueryActionListener

	/// <summary>
	/// Controls the flow of creating and modifying SysQueryAction.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysQueryAction")]
	public class SysQueryActionListener : BaseEntityEventListener
	{

		#region Methods: Private

		private void CheckAdminOperationRights(UserConnection userConnection) {
			var dbSecurityEngine = userConnection.DBSecurityEngine;
			if (!dbSecurityEngine.GetCanExecuteOperation("CanManageSolution")) {
				dbSecurityEngine.CheckCanExecuteOperation("CanManageQueryRules");
			}				
		}

		private void CheckInsertAdminOperationRight(UserConnection userConnection) {
			var dbSecurityEngine = userConnection.DBSecurityEngine;
			if (!dbSecurityEngine.GetCanExecuteOperation("CanInsertEverything")) {
				CheckAdminOperationRights(userConnection);
			}
		}

		private void CheckUpdateAdminOperationRight(UserConnection userConnection) {
			var dbSecurityEngine = userConnection.DBSecurityEngine;
			if (!dbSecurityEngine.GetCanExecuteOperation("CanUpdateEverything")) {
				CheckAdminOperationRights(userConnection);
			}
		}

		private void CheckDeleteAdminOperationRight(UserConnection userConnection) {
			var dbSecurityEngine = userConnection.DBSecurityEngine;
			if (!dbSecurityEngine.GetCanExecuteOperation("CanDeleteEverything")) {
				CheckAdminOperationRights(userConnection);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles SysQueryAction Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {			
			var SysQueryAction = (SysQueryAction)sender;
			UserConnection userConnection = SysQueryAction.UserConnection;
			CheckInsertAdminOperationRight(userConnection);			
		}

		/// <summary>
		/// Handles SysQueryAction Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			var SysQueryAction = (SysQueryAction)sender;
			UserConnection userConnection = SysQueryAction.UserConnection;
			CheckUpdateAdminOperationRight(userConnection);			
		}

		/// <summary>
		/// Handles SysQueryAction Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">
		/// The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs"/> instance containing the
		/// event data.
		/// </param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var SysQueryAction = (SysQueryAction)sender;
			UserConnection userConnection = SysQueryAction.UserConnection;
			CheckDeleteAdminOperationRight(userConnection);			
		}

		#endregion

	}

	#endregion

}

