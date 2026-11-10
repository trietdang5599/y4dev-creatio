  define("FullPipelineWidgetComponent", ["FunnelWidgetComponent"], function() {
	/**
	 * Component for rendering full pipeline widget component.
	 */
	Ext.define("Terrasoft.controls.FullPipelineWidgetComponent", {
		extend: "Terrasoft.controls.FunnelWidgetComponent",
		alternateClassName: "Terrasoft.FullPipelineWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-full-pipeline-widget-wrapper">',
			'<crt-full-pipeline-widget-component id="{id}" class="full-pipeline-widget" data-qa="full-pipeline-widget">',
			'</crt-full-pipeline-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return Terrasoft.FullPipelineWidgetComponent;

});
