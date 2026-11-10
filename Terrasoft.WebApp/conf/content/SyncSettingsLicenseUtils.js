Terrasoft.configuration.Structures["SyncSettingsLicenseUtils"] = {innerHierarchyStack: ["SyncSettingsLicenseUtils"]};
 define("SyncSettingsLicenseUtils", ["ServiceHelper"], function(ServiceHelper) {
	Ext.define("Terrasoft.utilities.SyncSettingsLicenseUtils", {
		alternateClassName: "Terrasoft.utilities.SyncSettingsLicenseUtils",

		/**
		* Flag is user has calendar sync license.
		*/
		isCalendarSyncLicensed: true,

		// region Methods: Protected

		/**
		* @protected
		* @return {Object}.
		*/
		 getLicOperationCodes: function() {
			return {
				"licOperationCodes": ["CanUseCalendarSynchronization"]
			};
		},

		/**
		 * @protected
		 * @param sFunction} callback.
		 * @param {Object} scope.
		 */
		callLicenseService: function(config, callback, scope) {
			ServiceHelper.callCoreService({
				serviceName: "LicenseService",
				methodName: config.methodName,
				data: config.data
			}, callback	 , this);
		},

		/**
		 * @protected
		 * @param {Function} callback.
		 * @param {Object} scope.
		 */
		initUserLicOperationsRights: function(callback, scope) {
			const licOperationCodes = this.getLicOperationCodes();
			const config = {
				methodName: "GetExplicitLicOperationStatuses",
				data: licOperationCodes
			};
			this.callLicenseService(config, function(result) {
				if (result.GetExplicitLicOperationStatusesResult && result.GetExplicitLicOperationStatusesResult.success) {
					this.isCalendarSyncLicensed = result.GetExplicitLicOperationStatusesResult.licOperationStatuses[0].Value;
				}
				Ext.callback(callback, scope);
			}, this);
		},

		//endregion

	});

	return Ext.create("Terrasoft.utilities.SyncSettingsLicenseUtils");
});


