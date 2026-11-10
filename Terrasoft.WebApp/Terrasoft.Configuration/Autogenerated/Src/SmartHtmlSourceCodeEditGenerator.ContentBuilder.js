define("SmartHtmlSourceCodeEditGenerator", ["ViewGeneratorV2", "SourceCodeEditGenerator",
		"SmartHtmlSourceCodeEdit"], function() {
	/**
	 * @class Terrasoft.configuration.SourceCodeEditGenerator
	 * Custom view generator for SourceCodeEditor control. Extends Terrasoft.ViewGenerator.
	 */
	Ext.define("Terrasoft.configuration.SmartHtmlSourceCodeEditGenerator", {
		extend: "Terrasoft.SourceCodeEditGenerator",
		alternateClassName: "Terrasoft.SmartHtmlSourceCodeEditGenerator",

		/**
		 * Class name of SourceCodeEdit control.
		 * @type {String}
		 */
		sourceCodeEditClassName: "Terrasoft.SmartHtmlSourceCodeEdit"
	});

	return Ext.create("Terrasoft.SmartHtmlSourceCodeEditGenerator");
});
