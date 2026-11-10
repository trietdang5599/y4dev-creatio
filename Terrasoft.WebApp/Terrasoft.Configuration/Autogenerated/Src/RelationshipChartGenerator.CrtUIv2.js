define("RelationshipChartGenerator", ["ViewGeneratorV2", "RelationshipChart"], function() {
	/**
	 * @class Terrasoft.configuration.RelationshipChartGenerator
	 * Class.
	 */
	Ext.define("Terrasoft.configuration.RelationshipChartGenerator", {
		alternateClassName: "Terrasoft.RelationshipChartGenerator",
		extend: "Terrasoft.ViewGenerator",

		Ext: null,
		sandbox: null,
		Terrasoft: null,

		/**
		 * Generates config for RelationshipChart control.
		 * @param {Object} config Configuration for generator.
		 * @param {Object} config.items Charts nodes.
		 * @param {Object} config.nodeRemove Node Removal Handler.
		 * @return {Object} Configuration.
		 */
		generateChart: function(config) {
			var chartConfig = {
				className: config.className || "Terrasoft.RelationshipChart",
				items: config.items
			};
			var serviceProperties = ["generator"];
			var configWithoutServiceProperties = this.getConfigWithoutServiceProperties(config, serviceProperties);
			Ext.apply(chartConfig, configWithoutServiceProperties);
			return chartConfig;
		}
	});

	return Ext.create("Terrasoft.RelationshipChartGenerator");
});
