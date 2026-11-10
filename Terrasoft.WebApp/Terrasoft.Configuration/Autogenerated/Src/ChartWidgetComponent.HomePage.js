  define("ChartWidgetComponent", ["BaseWidgetComponent"], function() {
	/**
	 * Component for rendering chart widget component.
	 */
	Ext.define("Terrasoft.controls.ChartWidgetComponent", {
		extend: "Terrasoft.controls.BaseWidgetComponent",
		alternateClassName: "Terrasoft.ChartWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-chart-widget-wrapper">',
			'<crt-chart-widget-component id="{id}" is-design-time=true class="chart-widget" data-qa="chart-widget">',
			'</crt-chart-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return Terrasoft.ChartWidgetComponent;

});
