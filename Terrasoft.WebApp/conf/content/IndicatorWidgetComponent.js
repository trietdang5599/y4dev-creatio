Terrasoft.configuration.Structures["IndicatorWidgetComponent"] = {innerHierarchyStack: ["IndicatorWidgetComponent"]};
   define("IndicatorWidgetComponent", ["BaseWidgetComponent"], function() {
	/**
	 * Component for rendering indicator widget component.
	 */
	Ext.define("Terrasoft.controls.IndicatorWidgetComponent", {
		extend: "Terrasoft.controls.BaseWidgetComponent",
		alternateClassName: "Terrasoft.IndicatorWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-indicator-widget-wrapper">',
			'<crt-indicator-widget-component id="{id}" is-design-time=true class="indicator-widget" data-qa="indicator-widget">',
			'</crt-indicator-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return Terrasoft.IndicatorWidgetComponent;

});

