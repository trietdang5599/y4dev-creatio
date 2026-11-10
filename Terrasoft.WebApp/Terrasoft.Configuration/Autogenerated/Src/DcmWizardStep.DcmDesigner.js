define("DcmWizardStep", ["terrasoft", "ext-base", "WizardStep", "DcmUtilities"], function(Terrasoft, Ext) {
	/**
	 * @class Terrasoft.configuration.DcmWizardStep
	 * DCM wizard step view model.
	 */
	Ext.define("Terrasoft.configuration.DcmWizardStep", {
		extend: "Terrasoft.WizardStep",
		alternateClassName: "Terrasoft.DcmWizardStep",

		/**
		 * @inheritdoc WizardStep#initCanUseStep
		 * @overridden
		 */
		initCanUseStep: function(callback, scope) {
			Terrasoft.DcmUtilities.checkCanManageDcmRights(function(allow) {
				this.set(this.canUseStepPropertyName, allow);
				Ext.callback(callback, scope);
			}, this);
		}

	});

	return Terrasoft.DcmWizardStep;
});
