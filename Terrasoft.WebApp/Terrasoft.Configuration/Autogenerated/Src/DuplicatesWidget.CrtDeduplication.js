define("DuplicatesWidget", ["mf!DuplicatesWidgetComponent", "css-ltr!DuplicatesWidgetComponentStyles"], function() {
	/**
	 * Component for rendering duplicates widget
	 */
	Ext.define("Terrasoft.control.DuplicatesWidget", {
		extend: "Terrasoft.controls.Component",
		alternateClassName: "Terrasoft.DuplicatesWidget",
		snapshotId: null,
		domAttributes: [],
		entitySchemaName: null,
		entityId: null,
		isLoading: false,
		duplicates: [],
		styles: {},
		parentComponent: Ext.emptyString,

		/**
		 * @inheritDoc Terrasoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<crt-duplicates-widget-component id=\\"{id}-wrap\\"' +
			'entity-schema-name = \"{entitySchemaName}\"  entity-id = \"{entityId}\">' +
			'</crt-duplicates-widget-component>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc Terrasoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"widgetClick",
			);
		},

		/**
		 * @inheritDoc Terrasoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const el = this.wrapEl;
			if (el) {
				el.on("widgetClick", this.onWidgetClick, this);
			}
		},

		/**
		 * @inheritDoc Terrasoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const el = this.wrapEl;
			if (el) {
				el.un("widgetClick", this.onWidgetClick, this);
			}
		},

		/**
		 * Handles widget click event
		 * @param {Object} event Event data.
		 */
		onWidgetClick: function(event) {
			const data = event && event.browserEvent && event.browserEvent.detail || {};
			this.fireEvent("widgetClick", data);
		},

		/**
		 * @inheritDoc Terrasoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
			};
		},

		/**
		 *  Sets the attribute to tpl.
		 */
		setAttribute: function(name, value) {
			if (this.rendered) {
				this.wrapEl.dom.setAttribute(name, value);
			}
		},
		
		/**
		 *  Sets the property to the element.
		 */
		setProperty: function(name, value) {
			if (this.rendered) {
				this.wrapEl.dom[name] = value;
			}
		},
		
		/**
		 * @inheritDoc Terrasoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			const duplicatesTplData = {
				entitySchemaName: this.entitySchemaName,
				entityId: this.entityId,
				isLoading: this.isLoading
			};
			Ext.apply(tplData, duplicatesTplData);
			return tplData;
		},

		/**
		 * @inheritDoc Terrasoft.Component#render
		 * @override
		 */
		render: function() {
			this.callParent(arguments);
			if (this.wrapEl && this.wrapEl.dom) {
				this.wrapEl.dom.duplicates = this.duplicates;
				this.wrapEl.dom.isLoading = this.isLoading;
			}
		},

		/**
		 * @inheritDoc Terrasoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const duplicatesBindConfig = {
				entitySchemaName: {
					changeMethod: "setEntitySchemaName"
				},
				entityId: {
					changeMethod: "setEntityId"
				},
				duplicates: {
					changeMethod: "setDuplicates"
				},
				isLoading: {
					changeMethod: "setIsLoading"
				},
			};
			Ext.apply(duplicatesBindConfig, bindConfig);
			return duplicatesBindConfig;
		},

		/**
		 * Sets current entity schema name.
		 * @param {String} entitySchemaName The current entity schema name.
		 */
		setEntitySchemaName: function(entitySchemaName) {
			if (this.entitySchemaName === entitySchemaName) {
				return;
			}
			this.entitySchemaName = entitySchemaName;
			this.setAttribute("entitySchemaName", this.entitySchemaName);
		},

		/**
		 * Sets current loading state.
		 * @param {Boolean} isLoading The current loading state.
		 */
		setIsLoading: function(isLoading) {
			if (this.isLoading === isLoading) {
				return;
			}
			this.isLoading = isLoading;
			this.setProperty("isLoading", this.isLoading);
		},

		/**
		 * Sets current entity identifier.
		 * @param {String} entityId The current entity identifier.
		 */
		setEntityId: function(entityId) {
			if (this.entityId === entityId) {
				return;
			}
			this.entityId = entityId;
			this.setAttribute("entityId", this.entityId);
		},

		/**
		 * Sets duplicates collection.
		 * @param {String} duplicates The duplicates entities.
		 */
		setDuplicates: function(duplicates) {
			if (this.duplicates === duplicates) {
				return;
			}
			this.duplicates = duplicates;
			this.setProperty("duplicates", this.duplicates);
		},
	});

	return Terrasoft.DuplicatesWidget;

});
