Terrasoft.configuration.Structures["SchemaAccessControllerMixin"] = {innerHierarchyStack: ["SchemaAccessControllerMixin"]};
define("SchemaAccessControllerMixin", ["ConfigurationConstants"], function (ConfigurationConstants) {
	/**
	 * @class Terrasoft.configuration.mixins.SchemaAccessControllerMixin
	 */
	Ext.define("Terrasoft.configuration.mixins.SchemaAccessControllerMixin", {
		alternateClassName: "Terrasoft.SchemaAccessControllerMixin",

		/**
		 * Returns list of allowed default pages.
		 * @returns List pages.
		 */
		getDefaultAllowedPages: function () {
			return ["MultiDeleteResultPageV2"];
		},

		/**
		 * Redirect if has no access.
		 * @param {String} modulePropertyName Name of module property.
		 * @param {String} hashTemplate Template of hash.
		 * @return {Boolean} true - if successfully redirected.
		 */
		redirectIfDenied: function (modulePropertyName, hashTemplate) {
			if (this.getDefaultAllowedPages().indexOf(this.name) !== -1) {
				return false;
			}
			const module = Object.values(Terrasoft.configuration.ModuleStructure || {})
				.filter(structure => structure?.entitySchemaName === this.entitySchemaName && !structure.section8X)[0];
			const schemas = [];
			if (module) {
				if (Ext.isArray(module.pages)) {
					module.pages.map(function (page) {
						schemas.push(page.cardSchema);
					});
				}
				if (module[modulePropertyName]) {
					schemas.push(module[modulePropertyName]);
				}
			}
			let hash = "";
			if (schemas.length === 0) {
				hash = ConfigurationConstants.DefaultPortalHomeModule;
			}
			if (!hash && schemas.indexOf(this.name) === -1) {
				hash = hashTemplate.replace(modulePropertyName, schemas[0]);
			}
			if (this.isNotEmpty(hash)) {
				console.warn('Restricted section for ' + this.entitySchemaName);
				this.sandbox.publish("ReplaceHistoryState", { hash: hash });
				return true;
			}
			return false;
		}
	});
});


