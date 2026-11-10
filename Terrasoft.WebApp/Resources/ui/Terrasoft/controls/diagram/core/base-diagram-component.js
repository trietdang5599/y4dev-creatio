/**
 * Abstract base class of diagram component. Can be used only with external component from studio free.
 */
Ext.define("Terrasoft.controls.BaseDiagramComponent", {
	extend: "Terrasoft.BaseDiagram",
	alternateClassName: "Terrasoft.BaseDiagramComponent",
	mixins: {
		customEvent: "Terrasoft.mixins.CustomEventDomMixin"
	},

	/**
	 * The symptom of the "read-only" mode of the process diagram component.
	 * @type {Boolean}
	 */
	readOnly: false,

	/**
	 * The symptom of the straight connection mode of the process diagram component.
	 * @type {Boolean}
	 */
	straightConnection: false,

	/**
	 * The diagram text direction. Values 'ltr' | 'rtl' | 'inherit'. 'inherit' by default/
	 * @type {Terrasoft.TextDirection}
	 */
	direction: Terrasoft.TextDirection.INHERIT,

	/**
	 * @type {String}
	 */
	overflow: "hidden",

	/**
	 * Adapter class name.
	 * @protected
	 * @virtual
	 * @type {String}
	 */
	adapterClassName: Terrasoft.emptyFn,

	/**
	 * Diagram changes parser class name.
	 * @protected
	 * @virtual
	 * @type {String}
	 */
	parserClassName: "Terrasoft.DiagramChangesParser",

	/**
	 * Diagram changes parser instance.
	 * @private
	 * @type {Object}
	 */
	_parser: null,

	/**
	 * Diagram component config.
	 * @type {Object}
	 */
	diagramConfig: null,

	/**
	 * @inheritdoc Terrasoft.controls.Container#tpl
	 */
	tpl: [],

	/**
	 * @inheritdoc
	 * @overridden
	 */
	constructor: function() {
		if (Terrasoft.getIsRtlMode()) {
			this.direction = Terrasoft.TextDirection.RTL;
		}
		this.callParent(arguments);
	},

	/**
	 * @inheritdoc Terrasoft.BaseDiagram#init
	 * @override
	 */
	init: function() {
		this.callParent(arguments);
		this.mixins.customEvent.init.call(this);
		this._createDiagramChangesParser();
		this.subscribeEvents();
		this.subscribeCustomEvents();
	},

	/**
	 * @private
	 */
	_createDiagramChangesParser: function() {
		this._parser = Ext.create(this.parserClassName);
	},

	/**
	 * @protected
	 * @virtual
	 */
	subscribeEvents: function() {
		this.addEvents(
			/**
			 * @event itemsContainerChanged
			 * Event of changing the parent container of the chart elements.
			 * @param {Object} args The parameter of the event.
			 * @param {String} args.itemName The name of the chart element.
			 * @param {String} args.containerName The name of the new element container.
			 */
			"itemsContainerChanged",

			/**
			 * @event itemsPositionChanged
			 * Event of changing positions in chart elements.
			 * @param {Object} args The parameter of the event.
			 * @param {String} args.items Array of the configuration of the chart element.
			 */
			"itemsPositionChanged",

			/**
			 * @event linePositionChanged
			 * Event of changing the position of the lane.
			 * @param {Object} args The parameter of the event.
			 * @param {String} args.itemName The name of the chart element.
			 * @param {Object} args.position The new position of the element.
			 * @param {Number} args.position.x The x-axis coordinate.
			 * @param {Number} args.position.y The y-axis coordinate.
			 */
			"linePositionChanged",

			/**
			 * @event sizeChanged
			 * Event of resizing a chart element.
			 * @param {Object} args The parameter of the event.
			 * @param {String} args.itemName The name of the chart element.
			 * @param {Object} args.size New element sizes.
			 * @param {Number} args.size.width The width of the element.
			 * @param {Number} args.size.height The height of the element.
			 */
			"sizeChanged",

			/**
			 * @event generateItemNameAndCaption
			 * Event for generating a unique name and title for the chart element.
			 * @param {Object} args The parameter of the event.
			 * @param {Terrasoft.ProcessBaseElementSchema} args.item The chart element.
			 */
			"generateItemNameAndCaption",

			/**
			 * @event polylinePointPositionsChanged
			 * The event of changing the break points of the connector.
			 * @param {Object} args The parameter of the event.
			 * @param {String} args.name The name of the connector.
			 * @param {ej.Diagram.Point[]} args.polylinePointPositions An array of new breakpoints.
			 */
			"polylinePointPositionsChanged",

			/**
			 * @event insertNodeInConnector
			 * Event of inserting an element into the control flow.
			 * @param {Object} args The parameter of the event.
			 * @param {Object} args.node The item to insert.
			 * @param {Object} args.connector Selected sequence flow.
			 */
			"insertNodeInConnector",

			/**
			 * @event itemsRemoving
			 * Fires when an items are about to remove on diagram.
			 * @param {Object} args Event arguments.
			 * @param {String} args.itemNameList Array of items.
			 */
			"itemsRemoving",

			/**
			 * @event itemsRemoved
			 * Fires when an items are removed on diagram.
			 * @param {Object} args Event arguments.
			 * @param {String} args.itemNameList Array of items.
			 */
			"itemsRemoved",

			/**
			 * @event connectorCreate
			 * Event of connecting two items on diagram.
			 * @param {Object} args The parameter of the event.
			 * @param {Object} args.connector New connector.
			 */
			"connectorCreate",

			/**
			 * @event connectorUpdatingType
			 * Event of connection type changed.
			 * @param {Object} args The parameter of the event.
			 */
			"connectorUpdatingType",

			/**
			 * @event itemSelected
			 * Event of select item on diagram/
			 * @param {Object} args The parameter of the event.
			 * @param {Object} args.name Item name.
			 */
			"itemSelected",

			/**
			 * @event openPropertyPage
			 * Event of open properties page by element on diagram.
			 * @param {Object} args The parameter of the event.
			 * @param {String} args.name The name of clicked element.
			 */
			"openPropertyPage",

			/**
			 * @event diagramItemCreated
			 * Fires when an items are created on diagram.
			 * @param {Object} args Event arguments.
			 */
			"diagramItemCreated",
			/**
			 * @event pasteElement
			 * Fires when pasted copy element.
			 * @param {Object} args Event arguments.
			 */
			"pasteElement",
			/**
			 * @event itemValidateUpdatingType
			 * Fires when an updating type item validate.
			 * @param {String} id Item id.
			 * @param {Function} callback Callback function that will be called if Item valid.
			 */
			"itemValidateUpdatingType",
			/**
			 * @event itemTypeUpdated
			 * Fires when an item updated type.
			 * @param {Object} element Updated element.
			 * @param {Function} callback Callback function that will be called after replacing old item.
			 */
			"itemTypeUpdated",
			/**
			 * @event canCopy
			 * Fires before copy element.
			 */
			"canCopy",
			/**
			 * @event updateStudioFreeDiagramUrl
			 * Fires if update studio free diagram url .
			 */
			"updateStudioFreeDiagramUrl"
		);
	},

	/**
	 * @protected
	 * @virtual
	 */
	subscribeCustomEvents: function() {
		const customEvent = this.mixins.customEvent;
		customEvent.subscribe.call(this, "diagramElementRemoving").subscribe((ids) => {
			const next = () => {
				customEvent.publish.call(this, "elementRemoved", ids);
			};
			const cancel = () => {
				customEvent.publish.call(this, "removeCancelled", ids);
			};
			this.fireEvent("itemsRemoving", this, {ids, next, cancel});
		});
		customEvent.subscribe.call(this, "diagramChanged").subscribe((dChanges) => {
			if (!Ext.isArray(dChanges)) {
				return;
			}
			this._applyDiagramChanges(dChanges);
		});
		customEvent.subscribe.call(this, "diagramElementClick").subscribe((element) => {
			this.fireEvent("itemSelected", this._getElementName(element));
		});
		customEvent.subscribe.call(this, "diagramElementDoubleClick").subscribe((elementName) => {
			this.fireEvent("openPropertyPage", elementName);
		});
		customEvent.subscribe.call(this, "pasteDiagramElement").subscribe((element) => {
			this.fireEvent("pasteElement", {element});
			this.updateItemName(element.id);
		});
	},

	/**
	 * Allow load external changes in diagram data.
	 * @protected
	 * @returns {boolean}
	 */
	allowExternalChanges: function() {
		return true;
	},

	/**
	 * @inheritDoc Terrasoft.Component#getTplData
	 * @override
	 */
	getTplData: function() {
		const tplData = this.callParent(arguments);
		tplData.readOnly = this.readOnly;
		tplData.straightConnection = this.straightConnection;
		return tplData;
	},

	/**
	 * @inheritdoc Terrasoft.controls.Component#getBindConfig
	 * @override
	 */
	getBindConfig: function() {
		const bindConfig = this.callParent(arguments);
		const diagramBindConfig = {
			diagramConfig: {
				changeMethod: "onChangeDiagramConfig"
			}
		};
		return Ext.apply(diagramBindConfig, bindConfig);
	},

	/**
	 * @private
	 */
	_initDiagramConfig: async function() {
		await new Promise((next) => {
			const customEvent = this.mixins.customEvent;
			customEvent.subscribe.call(this, "getDiagramConfig").subscribe(() => {
				const config = this.diagramConfig;
				customEvent.publish.call(this, "setDiagramConfig", config);
				next();
			});
		});
	},

	/**
	 * @private
	 */
	_findItemByUId: function(uId) {
		return this.items.findByPath("uId", uId);
	},

	/**
	 * @private
	 */
	_getElementName: function(element) {
		element = element || {};
		let name = element.itemName || element.name;
		if (!name && element.id) {
			const item = this._findItemByUId(element.id);
			name = item.name;
		}
		return name;
	},


	/**
	 * @private
	 */
	_applyDiagramChanges: function(changes) {
		const schemaChanges = this._parser.getChangesForSchema(changes, this.items);
		Terrasoft.each(schemaChanges, (value, key) => {
			switch (key) {
				case "update":
					this._applyUpdateChanges(value);
					break;
				case "remove":
					this._applyRemoveChanges(value);
					break;
				case "add":
					this._applyAddChanges(value);
					break;
				default:
			}
		});
	},

	/**
	 * @private
	 */
	_applyAddChanges: function(updateChanges) {
		Terrasoft.each(updateChanges, (value, key) => {
			switch (key) {
				case "connections":
					this._addConnections(value);
					break;
				case "elements":
					this._addElements(value);
					break;
				case "labels":
					this._addLabels(value);
					break;
				default:
			}
		});
	},

	/**
	 * @private
	 */
	_addConnections: function(connections) {
		if (connections.length > 0) {
			Terrasoft.each(connections, (connection) => {
				this.fireEvent("connectorCreate", connection.itemValue);
				this.updateItemName(connection.itemValue.id);
			});
		}
	},

	/**
	 * @private
	 */
	_addElements: function(elements) {
		if (elements.length > 0) {
			Terrasoft.each(elements, (element) => {
				this.fireEvent("diagramItemCreated", element.itemValue);
				this.updateItemName(element.itemValue.id);
			});
		}
	},

	/**
	 * @private
	 */
	_addLabels: function(labels) {
		labels.forEach((label) => this.fireEvent("diagramItemCreated", label.itemValue));
	},

	/**
	 * @private
	 */
	_applyUpdateChanges: function(updateChanges) {
		Terrasoft.each(updateChanges, (value, key) => {
			switch (key) {
				case "connections":
					this._updateConnections(value);
					break;
				case "elements":
					this._updateElements(value);
					break;
				case "labels":
					this._updateLabels(value);
					break;
				default:
			}
		});
	},

	/**
	 * @private
	 */
	_applyRemoveChanges: function(updateChanges) {
		Terrasoft.each(updateChanges, (value, key) => {
			switch (key) {
				case "connections":
					value.forEach((connection) => this._deleteConnection(connection));
					break;
				case "elements":
				case "labels":
					this._deleteElements(value);
					break;
				default:
			}
		});
	},

	/**
	 * @private
	 */
	_deleteElements: function(elements) {
		this.fireEvent("itemsRemoved", {ids: elements.map((e) => e.itemValue.id)});
	},

	/**
	 * @private
	 */
	_deleteConnection: function(connection) {
		if (connection && connection.name) {
			this.items.removeByKey(connection.name);
		}
	},

	/**
	 * @private
	 */
	_getPolylinePositionsChanges: function(changedConnectors) {
		if (changedConnectors.length > 0) {
			return changedConnectors.filter((connector) => connector.hasOwnProperty("polylinePointPositions"));
		}
	},

	/**
	 * @private
	 */
	_getConnectorValueChanges: function(changedConnectors) {
		if (changedConnectors.length > 0) {
			const connectors = Terrasoft.deepClone(changedConnectors);
			return connectors
				.filter((connector) => connector.hasOwnProperty("itemValue"))
				.map((connector) => {
					delete connector.itemValue.type;
					return connector.itemValue;
				});
		}
	},

	/**
	 * @private
	 */
	_getConnectorTypeChanges: function(changedConnectors) {
		if (changedConnectors.length > 0) {
			return changedConnectors
				.filter((connector) => connector.hasOwnProperty("itemValue")
					&& connector.itemValue.hasOwnProperty("type"))
				.map((connector) => ({name: connector.name, type: connector.itemValue.type}));
		}
	},

	/**
	 * @private
	 */
	_updateConnections: function(changedConnectors) {
		if (changedConnectors.length > 0) {
			let updateConnectors;
			updateConnectors = this._getPolylinePositionsChanges(changedConnectors);
			if (updateConnectors.length > 0) {
				this.fireEvent("polylinePointPositionsChanged", updateConnectors);
			}
			updateConnectors = this._getConnectorValueChanges(changedConnectors);
			if (updateConnectors.length > 0) {
				this.fireEvent("connectorsNodesChange", updateConnectors);
			}
			updateConnectors = this._getConnectorTypeChanges(changedConnectors);
			if (updateConnectors.length > 0) {
				const next = ({id, name, caption}) => {
					const customEvent = this.mixins.customEvent;
					customEvent.publish.call(this, "updateElementName", {id, name});
					customEvent.publish.call(this, "setIsElementValid", {id, isValid: true});
					customEvent.publish.call(this, "elementCaptionChanged", {id, caption});
				};
				this.fireEvent("connectorUpdatingType", {connections: updateConnectors, next});
			}
			this._updateConnectionCaptions(changedConnectors);
		}
	},


	/**
	 * @private
	 */
	_updateConnectionCaptions: function(changedConnectors) {
		changedConnectors.forEach((connection) => {
			const itemValue = connection.itemValue;
			if (itemValue && itemValue.hasOwnProperty("caption")) {
				const event = {
					element: {name: itemValue.name},
					value: itemValue.caption
				};
				this.fireEvent("textChange", event);
			}
		});
	},

	/**
	 * @private
	 */
	_updateItemsPosition: function(items) {
		const itemsToChange = items.filter((element) => element.hasOwnProperty("position"));
		if (!Ext.isEmpty(itemsToChange)) {
			this.fireEvent("itemsPositionChanged", itemsToChange);
		}
	},

	/**
	 * @private
	 */
	_updateElements: function(elements) {
		if (elements) {
			elements = Array.isArray(elements) ? elements : [elements];
			this._updateItemsPosition(elements);
			elements.forEach((element) => {
				if (element.hasOwnProperty("size")) {
					this.fireEvent("sizeChanged", element);
				}
				if (element.hasOwnProperty("parent")) {
					this.fireEvent("itemsContainerChanged", element);
				}
				if (element.hasOwnProperty("caption")) {
					const event = {
						element: {name: element.itemName},
						value: element.caption
					};
					this.fireEvent("textChange", event);
				}
			});
		}
	},

	/**
	 * @private
	 */
	_updateLabels: function(labels) {
		if (labels) {
			this._updateItemsPosition(labels);
		}
	},

	/**
	 * @inheritDoc Terrasoft.BaseDiagram#onCollectionDataLoaded
	 * @override
	 */
	onCollectionDataLoaded: function(items, newItems) {
		items = newItems || items;
		if (items && !items.isEmpty()) {
			const customEvent = this.mixins.customEvent;
			customEvent.subscribe.call(this, "diagramInitialized", this.allowExternalChanges()).subscribe(function() {
				this.renderItems(newItems);
			}.bind(this));
		}
	},

	/**
	 * @protected
	 */
	renderItems: function(items) {
		const data = this.getDiagramData(items);
		const customEvent = this.mixins.customEvent;
		customEvent.publish.call(this, "diagramDataLoaded", data);
	},

	/**
	 * Sets element validation state.
	 * @param {String} id Element id.
	 * @param {Boolean} isValid Validation stage.
	 */
	setIsElementValid: function(id, isValid) {
		this.mixins.customEvent.publish.call(this, "setIsElementValid", {id, isValid});
	},

	/**
	 * Selects item by name.
	 * @param {String} itemName Item name.
	 */
	selectItem: function(itemName) {
		const item = this.items.findByPath("name", itemName);
		if (item) {
			this.mixins.customEvent.publish.call(this, "elementSelected", {id: item.uId});
		}
	},

	/**
	 * Center item on view box.
	 * @param {String} itemName Item name.
	 */
	itemCenterViewBox: function(itemName) {
		const item = this.items.findByPath("name", itemName);
		if (item) {
			this.mixins.customEvent.publish.call(this, "elementCenterViewBox", {id: item.uId});
		}
	},

	/**
	 * Clears items selection.
	 */
	clearSelection: function() {
		this.mixins.customEvent.publish.call(this, "elementSelected", {});
	},

	/**
	 * Initialize diagram component.
	 */
	initDiagram: async function() {
		await this._initDiagramConfig();
	},

	/**
	 * @protected
	 */
	getDiagramDataAdapter: function() {
		return Ext.create(this.adapterClassName);
	},

	/**
	 * @protected
	 */
	getDiagramData: function(items) {
		const adapter = this.getDiagramDataAdapter();
		const data = adapter.getDiagramData(items);
		return data;
	},

	/**
	 * @protected
	 */
	updateItemName: function(itemId) {
		const customEvent = this.mixins.customEvent;
		const managerItem = this._findItemByUId(itemId);
		if (managerItem) {
			customEvent.publish.call(this, "updateElementName", {id: managerItem.uId, name: managerItem.name});
		}
	},

	/**
	 * Handler for change diagramConfig.
	 * @param {Object} value New config value.
	 */
	onChangeDiagramConfig: function(value) {
		this.diagramConfig = value;
	},

	/**
	 * @inheritDoc Terrasoft.AbstractContainer#onDestroy
	 * @override
	 */
	onDestroy: function() {
		this.mixins.customEvent.destroy.call(this);
		this.callParent(arguments);
	},

	/**
	 * Sets process element label caption.
	 * @param {String} nodeName Process element name.
	 * @param {String} caption Process element caption.
	 */
	setNodeCaption: function(nodeName, caption) {
		const node = this.items.find(nodeName);
		if (node) {
			const customEvent = this.mixins.customEvent;
			customEvent.publish.call(this, "elementCaptionChanged", {
				id: node.uId,
				caption: caption
			});
		}
	},

	/**
	 * Updates element markers on diagram.
	 * @protected
	 * @param {String} itemId Identifier of item.
	 * @param {Object} markers Markers.
	 */
	updateElementMarkers: function(itemId, markers) {
		const customEvent = this.mixins.customEvent;
		const managerItem = this._findItemByUId(itemId);
		if (managerItem) {
			customEvent.publish.call(this, "updateElementMarkers", {id: managerItem.uId, markers});
		}
	}

});
