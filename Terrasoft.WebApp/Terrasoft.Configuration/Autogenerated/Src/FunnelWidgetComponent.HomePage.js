 define("FunnelWidgetComponent", ["BaseWidgetComponent"], function() {
	/**
	 * Component for rendering funnel widget component.
	 */
	Ext.define("Terrasoft.controls.FunnelWidgetComponent", {
		extend: "Terrasoft.controls.BaseWidgetComponent",
		alternateClassName: "Terrasoft.FunnelWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-funnel-widget-wrapper">',
			'<crt-funnel-widget-component id="{id}" is-design-time="true" data-qa="funnel-widget">',
			'</crt-funnel-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return Terrasoft.FunnelWidgetComponent;

});
