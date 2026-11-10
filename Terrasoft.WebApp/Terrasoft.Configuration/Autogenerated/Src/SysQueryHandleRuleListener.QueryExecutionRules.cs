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

	#region Class: SysQueryHandleRuleListener

	/// <summary>
	/// Controls the flow of creating and modifying SysQueryHandleRule.
	/// </summary>
	/// <seealso cref="Terrasoft.Core.Entities.Events.BaseEntityEventListener" />
	[EntityEventListener(SchemaName = "SysQueryHandleRule")]
	public class SysQueryHandleRuleListener : BaseEntityEventListener
	{

		#region Methods: Private
		
		private int _minRowCountLowerValue = 1000; 
		
		#endregion
		
		#region Methods: Private

		private void ClearQueryRuleApplierCache(UserConnection userConnection) {
			var ruleApplier = ClassFactory.Get<IQueryRuleApplier>();
			ruleApplier.Clear();
		}

		private bool GetIsActiveRuleDuplicated(SysQueryHandleRule sysQueryHandleRule) {
			bool isActive = sysQueryHandleRule.GetTypedColumnValue<bool>("IsActive");
			if (!isActive) {
				return false;
			}
			EntitySchema sysQueryHandleRuleSchema = sysQueryHandleRule.Schema;
			Entity sysQueryHandleRuleFromDb = sysQueryHandleRuleSchema.CreateEntity(sysQueryHandleRule.UserConnection);
			sysQueryHandleRuleFromDb.UseAdminRights = false;			
			var conditions = new Dictionary<string, object> {
				{ "IsActive", true },
				{ "MinRowCount", sysQueryHandleRule.GetTypedColumnValue<int>("MinRowCount") },
				{ "SysQueryDetector", sysQueryHandleRule.GetTypedColumnValue<Guid>("SysQueryDetectorId") },
				{ "IsSystem", sysQueryHandleRule.GetTypedColumnValue<bool>("IsSystem")}
			};
			Guid sysSchemaId = sysQueryHandleRule.GetTypedColumnValue<Guid>("SysSchemaId");
			if (sysSchemaId != Guid.Empty) {
				conditions.Add("SysSchema", sysSchemaId);
			} else {
				conditions.Add("SysSchema", null);
			}
			if (sysQueryHandleRuleFromDb.FetchFromDB(conditions, false) &&
					sysQueryHandleRuleFromDb.PrimaryColumnValue != sysQueryHandleRule.PrimaryColumnValue) {
				return true;
			}
			return false;
		}

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
		
		private void CheckIsActiveRuleDuplicated(UserConnection userConnection, SysQueryHandleRule sysQueryHandleRule) {
			if (GetIsActiveRuleDuplicated(sysQueryHandleRule)) {
				var errorMessage = new LocalizableString(userConnection.ResourceStorage, "SysQueryHandleRuleListener",
					"LocalizableStrings.CreateActiveDuplicatedRulesIsProhibited.Value").ToString();
				throw new SecurityException(errorMessage);
			}
		}
		
		private void CheckMinRowCount(UserConnection userConnection, int minRowCount) {
			if (minRowCount < _minRowCountLowerValue) {
				var errorMessage = string.Format(new LocalizableString(userConnection.ResourceStorage, "SysQueryHandleRuleListener",
					"LocalizableStrings.CreateRuleWithMinRowCountLessThanMinValueProhibited.Value"), _minRowCountLowerValue);
				throw new SecurityException(errorMessage);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles SysQueryHandleRule Saved event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityAfterEventArgs" /> instance containing the
		/// event data.</param>
		public override void OnInserting(object sender, EntityBeforeEventArgs e) {			
			var sysQueryHandleRule = (SysQueryHandleRule)sender;
			UserConnection userConnection = sysQueryHandleRule.UserConnection;
			CheckInsertAdminOperationRight(userConnection);
			bool isSystemRuleInserting = sysQueryHandleRule.GetTypedColumnValue<bool>("IsSystem");
			if (isSystemRuleInserting) {
				var errorMessage = new LocalizableString(userConnection.ResourceStorage, "SysQueryHandleRuleListener",
					"LocalizableStrings.CreateSystemRuleIsProhibitedMessage.Value").ToString();
				throw new SecurityException(errorMessage);
			}
			CheckMinRowCount(userConnection, sysQueryHandleRule.GetTypedColumnValue<int>("MinRowCount"));
			CheckIsActiveRuleDuplicated(userConnection, sysQueryHandleRule);
			base.OnInserting(sender, e);
			ClearQueryRuleApplierCache(userConnection);
		}

		/// <summary>
		/// Handles SysQueryHandleRule Updating event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnUpdating(object sender, EntityBeforeEventArgs e) {
			var sysQueryHandleRule = (SysQueryHandleRule)sender;
			UserConnection userConnection = sysQueryHandleRule.UserConnection;
			CheckUpdateAdminOperationRight(userConnection);
			var changedColumns = sysQueryHandleRule.GetChangedColumnValues();
			bool isSystemValueChanged = changedColumns.Any(x => x.Name == "IsSystem");
			bool isSystemRuleUpdating = sysQueryHandleRule.GetTypedColumnValue<bool>("IsSystem");
			var areProhibitedColumnsChanged = changedColumns.Where(x => x.Name != "LogStackTrace").Count() > 0;
			if (isSystemValueChanged || (isSystemRuleUpdating && areProhibitedColumnsChanged)) {
				var errorMessage = new LocalizableString(userConnection.ResourceStorage, "SysQueryHandleRuleListener",
					"LocalizableStrings.EditSystemRuleIsProhibited.Value").ToString();
				throw new SecurityException(errorMessage);
			}
			bool isMinRowCountChanged = changedColumns.Any(x => x.Name == "MinRowCount");
			if (isMinRowCountChanged) {
				CheckMinRowCount(userConnection, sysQueryHandleRule.GetTypedColumnValue<int>("MinRowCount"));
			}
			CheckIsActiveRuleDuplicated(userConnection, sysQueryHandleRule);
			base.OnUpdating(sender, e);
			ClearQueryRuleApplierCache(sysQueryHandleRule.UserConnection);
		}

		/// <summary>
		/// Handles SysQueryHandleRule Deleting event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">
		/// The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs"/> instance containing the
		/// event data.
		/// </param>
		public override void OnDeleting(object sender, EntityBeforeEventArgs e) {
			var sysQueryHandleRule = (SysQueryHandleRule)sender;
			UserConnection userConnection = sysQueryHandleRule.UserConnection;
			CheckDeleteAdminOperationRight(userConnection);
			if (sysQueryHandleRule.GetTypedColumnValue<bool>("IsSystem")) {
				var errorMessage = new LocalizableString(userConnection.ResourceStorage, "SysQueryHandleRuleListener",
					"LocalizableStrings.DeleteSystemRuleIsProhibitedMessage.Value").ToString();
				throw new SecurityException(errorMessage);
			}
			base.OnDeleting(sender, e);
			ClearQueryRuleApplierCache(sysQueryHandleRule.UserConnection);
		}
		
		/// <summary>
		/// Handles SysQueryHandleRule Deleted event.
		/// </summary>
		/// <param name="sender">Event sender.</param>
		/// <param name="e">The <see cref="T:Terrasoft.Core.Entities.EntityBeforeEventArgs" /> instance containing
		/// the event data.</param>
		public override void OnDeleted(object sender, EntityAfterEventArgs e){
			base.OnDeleted(sender, e);
			var sysQueryHandleRule = (SysQueryHandleRule)sender;
			ClearQueryRuleApplierCache(sysQueryHandleRule.UserConnection);
		}

		#endregion

	}

	#endregion

}

