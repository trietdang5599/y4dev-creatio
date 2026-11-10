define("ChartProviderFactory", ["ChartjsProvider"], function() {
	Ext.define("Terrasoft.configuration.ChartProviderFactory", {
		extend: "Terrasoft.BaseObject",
		alternateClassName: "Terrasoft.ChartProviderFactory",
		
		
		// region Methods: Private
		
		/**
		 * @private
		 * @param {String} providerName
		 * @param {Object} config
		 * @return {Object} Created provider.
		 */
		_createProvider: function(providerName, config) {
			return Ext.create(providerName, {config: config});
		},
		
		// endregion
		
		// region Methods: Protected

		/**
		 * Create chartjs provider.
		 * @param {Object} config Provider configuration.
		 * @returns {Object} chartjs provider instance.
		 */
		createChartJsProvider: function(config) {
			return this._createProvider("Terrasoft.ChartjsProvider", config);
		},
		
		// endregion
		
		// region Methods: Public
		
		/**
		 * Create chart provider by chart config.
		 * @param {Object} config
		 * @return {Object} Created provider.
		 */
		createProvider: function(config) {
			return this.createChartJsProvider(config);
		}
		
		// endregion
		
	});
	
	return {};
});
