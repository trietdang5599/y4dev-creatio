define("ActualizationUtilities", ["terrasoft", "ActualizationUtilitiesResources"],
	function(Terrasoft, resources) {
		var actualizationUtilitiesClass = Ext.define("Terrasoft.configuration.mixins.ActualizationUtilities", {

				alternateClassName: "Terrasoft.ActualizationUtilities",

				/**
				 * ######## ######, ########### ############ ############### #####.
				 * @private
				 */
				onActualizeAdminUnitInRole: function() {
					this.showBodyMask();
					var config = {
						serviceName: "AdministrationService",
						methodName: "ActualizeAdminUnitInRole",
						timeout: 600000
					};
					this.callService(config, function(response) {
						this.hideBodyMask();
						if (response && response.ActualizeAdminUnitInRoleResult) {
							this.showInformationDialog(resources.localizableStrings.ActualizeSuccessMessage);
						} else {
							this.showInformationDialog(resources.localizableStrings.ActualizeFailedMessage);
						}
					}, this);
				},

				/**
				 * ########## ###### "############### ####".
				 * @protected
				 * @return {Terrasoft.BaseViewModel} ########## ######.
				 */
				getActualizeAdminUnitInRoleButton: function() {
					return this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.ActualizeOrgStructureButtonCaption"},
						"Click": {"bindTo": "onActualizeAdminUnitInRole"},
						"Visible": {"bindTo": "CanManageUsers"}
					});
				},

				/**
				 * ######## ###### ## #######.
				 * @protected
				 * @param {Object} callback ####### ######### ######.
				 * @param {Object} scope ######## ##########.
				 */
				initCustomUserProfileData: function(callback, scope) {
					var profileKey = this.getCustomProfileKey();
					this.Terrasoft.require(["profile!" + profileKey], function(profile) {
						this.set("UserCustomProfile", profile);
						if (this.Ext.isFunction(callback)) {
							callback.call(scope, arguments);
						}
					}, this);
				},

				/**
				 * ######## #### #######.
				 * @protected
				 * @return {String} ########## #### #######.
				 */
				getCustomProfileKey: function() {
					return "SysAdminUnitSectionCustomData";
				}
			});
		return Ext.create(actualizationUtilitiesClass);
	});
