define("AgeActualizationModalTimeEditModuleSchema", ["ProcessModuleUtilities"], function(ProcessModuleUtilities) {
	return {
		methods: {

			//region Methods: Public

			/**
			 * @inheritDoc Terrasoft.BaseModalTimeEditModuleSchema#initSelectedTimeValue
			 * @overridden
			 */
			initSelectedTimeValue: function() {
				Terrasoft.SysSettings.querySysSettingsItem("AutomaticAgeActualizationTime",
					this.initSelectedTimeValueCallback, this);
			},

			/**
			 * @inheritDoc Terrasoft.BaseModalTimeEditModuleSchema#saveSelectedTimeValue
			 * @overridden
			 */
			saveSelectedTimeValue: function() {
				Terrasoft.SysSettings.postSysSettingsValue("AutomaticAgeActualizationTime", this.$SelectedTimeValue,
					this.saveSelectedTimeValueCallback, this);
			},

			/**
			 * @inheritDoc Terrasoft.BaseModalTimeEditModuleSchema#saveSelectedTimeValueCallback
			 * @overridden
			 */
			saveSelectedTimeValueCallback: function() {
				this.callParent(arguments);
				ProcessModuleUtilities.executeProcess({
					"sysProcessName": "ContactAgeActualizationJobRestartProcess"
				});
			}

			//endregion

		}
	};
});