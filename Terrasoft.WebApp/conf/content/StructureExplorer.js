Terrasoft.configuration.Structures["StructureExplorer"] = {innerHierarchyStack: ["StructureExplorer"]};
define("StructureExplorer", ["StructureExplorerResources", "StructureExplorerComponent"], function(resources) {
	Ext.define("Terrasoft.control.StructureExplorer", {
		extend: "Terrasoft.controls.Component",
		alternateClassName: "Terrasoft.StructureExplorer",

		mixins: {
			customEvent: "Terrasoft.mixins.CustomEventDomMixin",
		},

		setStructureExplorerLocalization: "getStructureExplorerTranslation",

		/**
		 * Structure explorer configuration.
		 * @type {Object}
		 * @param {Guid} config.entitySchemaUId;
		 * @param {Guid} [config.displayId];
		 * @param {Terrasoft.DataValueType} [config.dataValueType];
		 * @param {Boolean} [config.onlyLookups];
		 * @param {Boolean} [config.firstColumnsOnly];
		 * @param {Boolean} [config.enableBlobDataValueType];
		 * @param {string[]} [config.allowedReferenceSchemas];
		 * @param {Terrasoft.DataValueType[]} [config.excludedDataValueTypes];
		 * @param {Number} [config.usageType];
		 * @param {string[]} [config.allowedItems];
		 * @param {string[]} [config.excludedItems];
		 * @param {string[]} [config.selectedMetaPaths];
		 */
		config: null,

		/**
		 * @inheritDoc Terrasoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id=\"{id}-wrap\">',
			'<ts-structure-explorer-proxy id=\"{id}\"',
			' config = \"{config}\">',
			'</ts-structure-explorer-proxy>',
			'</div>'
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		_subscribeCustomEvents: function() {
			this.mixins.customEvent.init();
			this._publishStructureExplorerLocalization();
		},

		_publishStructureExplorerLocalization: function () {
			this.mixins.customEvent.publish(this.setStructureExplorerLocalization, {
				'StructureExplorerDialog.NoData': resources.localizableStrings.StructureExplorerNoDataCaption,
				'StructureExplorerDialog.Title': resources.localizableStrings.StructureExplorerTitle,
				'StructureExplorerDialog.CancelButtonCaption': resources.localizableStrings.StructureExplorerCancelButtonCaption,
				'StructureExplorerDialog.SelectButtonCaption': resources.localizableStrings.StructureExplorerSelectButtonCaption,
				'StructureExplorerDialog.FieldsTabCaption': resources.localizableStrings.StructureExplorerFieldsTabCaption,
				'StructureExplorerDialog.RelatedObjectsTabCaption': resources.localizableStrings.StructureExplorerRelatedObjectsTabCaption,
				'StructureExplorerDialog.SearchPlaceHolder': resources.localizableStrings.StructureExplorerSearchPlaceHolder,
				'StructureExplorerDialog.SearchClearIconTitle': resources.localizableStrings.StructureExplorerSearchClearIconTitle,
			});
		},

		/**
		 * @inheritDoc Terrasoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.addEvents(
				"selected"
			);
			this._subscribeCustomEvents();
		},

		/**
		 * @inheritDoc Terrasoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			Ext.apply(tplData, {
				config: this.config
			});
			return tplData;
		},

		/**
		 * @inheritDoc Terrasoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
			const el = this.structureExplorerEl;
			if (el) {
				el.on("selected", this.handleSelected, this);
			}
		},

		/**
		 * @inheritDoc Terrasoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
			const el = this.structureExplorerEl;
			if (el) {
				el.un("selected", this.handleSelected, this);
			}
		},

		/**
		 * Handles selected.
		 * @param {Object} event selected.
		 */
		handleSelected: function(event) {
			const selected = event.browserEvent.detail;
			this.fireEvent("selected", selected);
			this.destroy();
		},

		/**
		 * @inheritDoc Terrasoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const config = {
				config: {
					changeMethod: "setConfig"
				}
			};
			Ext.apply(config, bindConfig);
			return config;
		},

		/**
		 * Sets configuration.
		 * @param {string} config Configuration.
		 */
		setConfig: function(config) {
			if (this.config === config || Ext.isEmpty(config)) {
				return;
			}
			this.config = Terrasoft.encodeHtml(Terrasoft.encode(config));
			this._setAttribute("config", this.config);
		},

		/**
		 * @inheritDoc Terrasoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				structureExplorerEl: "#" + this.id
			};
		},

		/**
		 * @private
		 */
		_setAttribute: function(name, value) {
			if (this.rendered) {
				this.structureExplorerEl.dom.setAttribute(name, value);
			}
		}
	});

	return Terrasoft.StructureExplorer;

});


