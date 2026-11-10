Terrasoft.configuration.Structures["AngularPageUtilitiesMixin"] = {innerHierarchyStack: ["AngularPageUtilitiesMixin"]};
define("AngularPageUtilitiesMixin", [], function() {
	/**
	 * @class Terrasoft.configuration.mixins.AngularPageUtilitiesMixin
	 * Angular utilities mixin.
	 */
	Ext.define("Terrasoft.configuration.mixins.AngularPageUtilitiesMixin", {
		alternateClassName: "Terrasoft.AngularPageUtilitiesMixin",

		/**
		 * Return is angular page.
		 * @param {string} schemaType
		 * @return {Boolean} schema is angular.
		 */
		isAngularPage: function(schemaType) {
			return schemaType &&
				Number(schemaType) === Terrasoft.SchemaType.ANGULAR_SCHEMA;
		},

		/**
		 * Return is exist angular schemas in pages.
		 * @param {Array<Object>} pages
		 * @return {Boolean} any angular pages.
		 */
		getHasAngularPage: function(pages) {
			return pages.some(o => this.isAngularPage(o.schemaType));
		},

		/**
		 * Set cardSchema for all angular pages.
		 * @param {Array<Object>} pages.
		 * @param {string} schemaName.
		 * @return {Array<Object>} initialized pages.
		 */
		initCardSchemaForAngularPages: function(pages, schemaName) {
			const pagesToProcess = Terrasoft.deepClone(pages) || {};
			const angularPages = pagesToProcess.filter(page => this.isAngularPage(page.schemaType));
			Terrasoft.each(angularPages, function(page) {
				page.cardSchema = schemaName
			});
			return pagesToProcess;
		}
	});
});