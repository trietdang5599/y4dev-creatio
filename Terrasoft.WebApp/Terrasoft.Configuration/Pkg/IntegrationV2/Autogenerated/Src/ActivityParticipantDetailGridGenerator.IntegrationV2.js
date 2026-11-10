define("ActivityParticipantDetailGridGenerator", ["ViewGeneratorV2", "ConfigurationEnumsV2"], function() {

	/**
	 * Mini Page controls generator class.
	 */
	Ext.define("Terrasoft.configuration.ActivityParticipantDetailGridGenerator", {
		extend: "Terrasoft.configuration.ViewGenerator",
		alternateClassName: "Terrasoft.ActivityParticipantDetailGridGenerator",

		generateGrid: function(config) {
			if (Terrasoft.Features.getIsEnabled("ShowInvitationState")) {
				config.className = "Terrasoft.ControlGrid";
				config.controlColumnName = "Participant";
				config.applyControlConfig = {"bindTo": "getParticipantControlConfig"};
			}
			return this.callParent(arguments);
		}

	});

	return Ext.create("Terrasoft.ActivityParticipantDetailGridGenerator");
});
 