Terrasoft.configuration.Structures["SyncSettingsErrorsMixin"] = {innerHierarchyStack: ["SyncSettingsErrorsMixin"]};
define("SyncSettingsErrorsMixin", ["RightUtilities"],
	function(RightUtilities) {
		/**
		 * @class Terrasoft.configuration.mixins.SyncSettingsErrorsMixin
		 * Activity dates mixin.
		 */
		Ext.define("Terrasoft.configuration.mixins.SyncSettingsErrorsMixin", {
			alternateClassName: "Terrasoft.SyncSettingsErrorsMixin",

			//region Methods: Public

			/**
			 * Initializes can manage mail servers list flag.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			initCanManageMailServers: function(callback, scope) {
				RightUtilities.checkCanExecuteOperation({
					"operation": "CanManageMailServers"
				}, function(permission) {
					this.$CanManageMailServers = permission;
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Returns default value of the date time columns config.
			 * @return {Object} Default value of the date time columns config.
			 */
			setErrorsFilters: function(settingsEsq) {
				const userFilters = settingsEsq.createFilterGroup();
				userFilters.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
				userFilters.add("userMailboxFilter", settingsEsq.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL, "SysAdminUnit",
					this.Terrasoft.SysValue.CURRENT_USER.value));
				userFilters.add("IsSharedFilter", settingsEsq.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL, "IsShared", true));
				const errorsFilters = settingsEsq.createFilterGroup();
				errorsFilters.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
				errorsFilters.add("ErrorNotNull", settingsEsq.createColumnIsNotNullFilter("ErrorCode"));
				if (this.getIsFeatureDisabled('DisableMailboxSyncWarnings') && this.$CanManageMailServers) {
					errorsFilters.add("WarningNotNull", settingsEsq.createColumnIsNotNullFilter("WarningCode"));
				}
				settingsEsq.filters.add("UserFilters", userFilters);
				settingsEsq.filters.add("ErrorsFilters", errorsFilters);
			}

			//endregion

		});
	});


