define("WebServiceWizardWebComponent", ["web-service-proxy-component"], function() {
	Ext.define("Terrasoft.controls.WebServiceWizardWebComponent", {
		extend: "Terrasoft.controls.Component",
		alternateClassName: "Terrasoft.WebServiceWizardWebComponent",

		/**
		 * @inheritDoc Terrasoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{wrapStyle}" class="{wrapClass}">',
				'<ts-web-service-proxy id="{id}">',
				'</ts-web-service-proxy>',
			'</div>'
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc Terrasoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				webserviceProxyEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc Terrasoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.subscribeEvents();
		},

		/**
		 * @protected
		 * @virtual
		 */
		subscribeEvents: function() {
			// this.addEvents();
		},

		/**
		 * @inheritDoc Terrasoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc Terrasoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc Terrasoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			this.selectors = this.getSelectors();
			const tplData = this.callParent(arguments);
			tplData.wrapStyle = {
				display: "none"
			};
			return tplData;
		},

		/**
		 * @inheritDoc Terrasoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			return this.callParent(arguments);
		}
	});

	return Terrasoft.WebServiceWizardWebComponent;
});
