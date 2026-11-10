define("BusinessRuleVisibleItemActionWebComponent", ["page-wizard-component"], function() {
	Ext.define("Terrasoft.controls.BusinessRuleVisibleItemActionWebComponent", {
		extend: "Terrasoft.controls.Component",
		alternateClassName: "Terrasoft.BusinessRuleVisibleItemActionWebComponent",
		actionId: null,

		/**
		 * @inheritDoc Terrasoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{wrapStyle}" class="{wrapClass}">',
			'<ts-business-rule-visible-item-action id="{id}" style="{actionStyle}" class="{actionClass}" action-id="{businessRuleActionId}">',
			'</ts-business-rule-visible-item-action>',
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
				actionEl: "#" + this.id
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
			this.addEvents(
				"clear",
				"actionChanged"
			);
		},

		/**
		 * @inheritDoc Terrasoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const actionEl = this.actionEl;
			if (actionEl) {
				actionEl.on("clearRule", this.onClear, this);
				actionEl.on("ruleActionChanged", this.onRuleActionChanged, this);
			}
		},

		/**
		 * @inheritDoc Terrasoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const actionEl = this.actionEl;
			if (actionEl) {
				actionEl.un("clearRule", this.onClear, this);
				actionEl.un("ruleActionChanged", this.onRuleActionChanged, this);
			}
		},

		/**
		 * @inheritDoc Terrasoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			const actionTplData = {
				businessRuleActionId: this.actionId
			};
			Ext.apply(tplData, actionTplData);
			return tplData;
		},

		/**
		 * @inheritDoc Terrasoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const actionBindConfig = {
				actionId: {
					changeMethod: "setBusinessActionId"
				}
			};
			Ext.apply(actionBindConfig, bindConfig);
			return actionBindConfig;
		},

		setBusinessActionId: function(actionId) {
			this.actionId = actionId;
			if (this.rendered) {
				this.actionEl.dom.setAttribute("action-id", actionId);
			}
		},

		onClear: function(event) {
			this.fireEvent("clear", event);
		},

		onRuleActionChanged: function(event) {
			this.fireEvent("actionChanged", event.browserEvent.detail);
		},
	});

	return Terrasoft.BusinessRuleVisibleItemActionWebComponent;
});
