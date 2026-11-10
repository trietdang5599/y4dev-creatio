Ext.define("Terrasoft.controls.ProcessDiagramComponent", {
	extend: "Terrasoft.BaseDiagramComponent",
	alternateClassName: "Terrasoft.ProcessDiagramComponent",

	/**
	 * Adapter class name.
	 * @protected
	 * @virtual
	 * @type {String}
	 */
	adapterClassName: "Terrasoft.DiagramDataAdapter",

	/**
	 * Directs diagram component to allow process importing.
	 * @type {Boolean}
	 */
	canImport: true,

	/**
	 * @inheritDoc Terrasoft.controls.Container#tpl
	 * @override
	 */
	tpl: [
		"<div id=\"diagram-{id}\" class=\"{wrapClassName}\">",
		"<ts-process-diagram readonly=\"{readOnly}\" straightconnection=\"{straightConnection}\"  dir=\"{direction}\" canimport=\"{canImport}\">",
		"</ts-process-diagram>",
		"</div>"
	],

	/**
	 * @inheritdoc Terrasoft.controls.Component#getBindConfig
	 * @override
	 */
	getBindConfig: function() {
		const bindConfig = this.callParent(arguments);
		const diagramBindConfig = {
			importData: {
				changeMethod: "onImportDataChanged"
			},
			suggestions: {
				changeMethod: "onSuggestionsChanged"
			},
			suggestionsTriggered: {
				changeMethod: "onSuggestionsTriggered"
			}
		};
		return Ext.apply(diagramBindConfig, bindConfig);
	},

	/**
	 * @inheritDoc Terrasoft.Component#getTplData
	 * @override
	 */
	getTplData: function() {
		const tplData = this.callParent(arguments);
		tplData.canImport = this.canImport;
		return tplData;
	},

	/**
	 * @protected
	 */
	subscribeEvents: function() {
		this.callParent();
		this.addEvents(
			/**
			 * @event importError
			 * Fired when import fails.
			 */
			"importError",
			/***
			 * @event diagramImportStart
			 * Fired when diagram import occurs.
			 */
			"diagramImportStart",
			/***
			 * @event itemSuggestionsClick
			 * Fired when click on item suggestions.
			 */
			"itemSuggestionsClick"
		);
	},

	/**
	 * Handler for change importData.
	 * @param {Object} value imported data value.
	 */
	onImportDataChanged: function(value) {
		if (value) {
			this.mixins.customEvent.publish("bpmnFileImported", value);
		}
	},

	/**
	 * Handler for new items suggestions generated.
	 * @param {Object} value generated suggestions.
	 * @public
	 */
	onSuggestionsChanged: function(value) {
		if (value) {
			const customEvent = this.mixins.customEvent;
			customEvent.publish("elementSuggestionsReceived", value);
		}
	},

	/**
	 * Handler for item suggestions generation triggered.
	 * @param {Object} value info about item.
	 * @public
	 */
	onSuggestionsTriggered: function(value) {
		if (!value) {
			return;
		}
		const customEvent = this.mixins.customEvent;
		customEvent.publish("elementSuggestionsTriggered", value);
	},

	/**
	 * @inheritDoc Terrasoft.BaseDiagramComponent#init
	 * @override
	 */
	init: function() {
		require(["process-designer-component"], function(){});
		this.callParent(arguments);
	},

	/**
	 * @inheritDoc Terrasoft.BaseDiagramComponent#subscribeCustomEvents
	 * @override
	 */
	subscribeCustomEvents: function() {
		this.callParent(arguments);
		const customEvent = this.mixins.customEvent;
		customEvent.subscribe("diagramElementValidateUpdatingType").subscribe(({id, config}) => {
			this.fireEvent("itemValidateUpdatingType", this, id, () => {
				customEvent.publish("elementUpdateType", {id, config});
				this.mixins.customEvent.publish("setIsElementValid", {id, isValid: true});
			});
		});
		customEvent.subscribe("diagramElementTypeUpdated").subscribe((element) => {
			this.fireEvent("itemTypeUpdated", this, element, (name) => {
				customEvent.publish("updateElementName", {id: element.id, name});
			});
		});
		customEvent.subscribe("diagramUrlUpdated").subscribe((url) => {
			this.fireEvent("updateStudioFreeDiagramUrl", this, url);
		});
		customEvent.subscribe("getCanCopy").subscribe((elements) => {
			const canCopy = this.fireEvent("canCopy", elements);
			customEvent.publish("setCanCopy", canCopy);
		});
		customEvent.subscribe("diagramImportError").subscribe(() => {
			this.fireEvent("importError", this);
		});
		customEvent.subscribe("diagramImportStart").subscribe(() => {
			this.fireEvent("diagramImportStart", this);
		});
		customEvent.subscribe("itemSuggestionsClick").subscribe((elementName) => {
			this.fireEvent("itemSuggestionsClick", elementName);
		});
	}
});

