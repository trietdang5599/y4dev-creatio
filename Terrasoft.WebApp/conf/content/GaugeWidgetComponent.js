Terrasoft.configuration.Structures["GaugeWidgetComponent"] = {innerHierarchyStack: ["GaugeWidgetComponent"]};
    define("GaugeWidgetComponent", ["BaseWidgetComponent"], function() {
	/**
	 * Component for rendering indicator widget component.
	 */
	Ext.define("Terrasoft.controls.GaugeWidgetComponent", {
		extend: "Terrasoft.controls.BaseWidgetComponent",
		alternateClassName: "Terrasoft.GaugeWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-gauge-widget-wrapper">',
			'<crt-gauge-widget-component id="{id}" is-design-time=true class="gauge-widget" data-qa="gauge-widget">',
			'</crt-gauge-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return Terrasoft.GaugeWidgetComponent;

});


