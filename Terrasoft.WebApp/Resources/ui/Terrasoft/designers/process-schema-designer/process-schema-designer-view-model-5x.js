/**
 * The model class of the process designer 5X.
 */
Ext.define("Terrasoft.Designers.ProcessSchemaDesignerViewModel5X", {
	extend: "Terrasoft.BaseViewModel",
	alternateClassName: "Terrasoft.ProcessSchemaDesignerViewModel5X",

	columns: {
		/**
		 * A collection of chart elements.
		 */
		Items: {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.COLLECTION
		},

		/**
		 * The identifier of the process, which is edited in the designer.
		 */
		SchemaUId: {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.GUID
		},

		/**
		 * The scheme of the process.
		 */
		Schema: {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
		},

		/**
		 * The scheme manager.
		 */
		SchemaManager: {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
		}
	},

	/**
	 * Identifier of the designer instance.
	 * @type {String}
	 */
	id: null,

	/**
	 * Sandbox in which the designer is executed.
	 * @private
	 * @type {Object}
	 */
	sandbox: null,

	/**
	 * The container identifier for loading the module for editing the properties of the process element.
	 * @private
	 * @type {String}
	 */
	propertiesContainerId: null,

	appendMode: false,

	newElement: null,

	newElementManagerItemUId: null,

	/**
	 * @override
	 * @inheritdoc Terrasoft.BaseViewModel#constructor
	 */
	constructor: function() {
		this.callParent(arguments);
		const items = Ext.create("Terrasoft.Collection");
		this.set("Items", items);
		this.addEvents(
			/**
			 * @event initialized
			 * Event to complete the initialization of the view model.
			 * @param {Terrasoft.ProcessSchemaDesignerViewModel} this view model.
			 */
			"initialized",
			/**
			 * @event itemschanged
			 * Event of changing the collection of process elements.
			 * @param {Object} args Parameters for changing the collection of items.
			 * @param {String} args.action Type of change add / remove
			 * @param {Object} args.item Added / Deleted item.
			 */
			"itemschanged",
			/**
			 * @event itemChanged
			 * Event of changing the properties of the process item.
			 * @param {Object} item The element whose property has changed.
			 * @param {Object} changes The object of the changes.
			 */
			"itemChanged",
			/**
			 * @event itemSelected
			 * Event to change the selection of a process item.
			 * @param {String} itemName The name of the selected item.
			 */
			"itemSelected"
		);
	},

	/**
	 * Performs the initialization of the view model, loads an instance of the process schema.
	 */
	init: function() {
		Ext.EventManager.addListener(window, "message", this.onMessageReceived, this);
		this.sendMessage({
			message: "GetMetaData"
		});
	},

	onMessageReceived: function(event) {
		const browserEvent = event.browserEvent;
		if (browserEvent.origin !== this.getLocationOrigin()) {
			return;
		}
		const response = Terrasoft.decode(browserEvent.data);
		switch (response.message) {
			case "ReadMetaData":
				this.loadProcessSchema(response);
				break;
			case "SetProperties":
				this.setItemProperties(response);
				break;
			case "RemoveItems":
				this.removeItems(response);
				break;
			case "SetExpectingAddElementState":
				this.setExpectingAddElementState(response);
				break;
			case "SetFocusedElementByName":
				this.setFocusedElementByName(response);
				break;
			case "SetSelectionMode":
				this.setSelectionMode(response);
				break;
		}
	},

	loadProcessSchema: function(response) {
		const metaData = response.metaData;
		const schema = Terrasoft.SchemaDesignerUtilities.createInstanceByMetaData({
			metaData: metaData,
			schemaClassName: "Terrasoft.EmbeddedProcessSchema5x",
			resources: response.resources
		});
		this.onSchemaLoaded(schema);
	},

	setItemProperties: function(response) {
		const schema = this.get("Schema");
		const itemUId = response.itemUId;
		const item = (itemUId === schema.uId) ? schema : schema.findItemByUId(itemUId);
		if (!item) {
			return;
		}
		const itemProperties = Terrasoft.decode(response.propertiesData);
		Terrasoft.each(itemProperties, function(propertyValue, propertyName) {
			propertyName = Terrasoft.toLowerCamelCase(propertyName);
			if (item[propertyName] instanceof Terrasoft.LocalizableString) {
				propertyValue.values.forEach(function(cultureData) {
					if (cultureData.hasValue === true) {
						item.setLocalizableStringPropertyValue(propertyName, cultureData.value, cultureData.name);
					}
				}, this);
			} else {
				item.setPropertyValue(propertyName, propertyValue);
				if ((propertyName === "position") && (typeof propertyValue === "string")) {
					item.position = item.parsePoint(item.position);
				}
			}
		}, this);
	},

	removeItems: function(response) {
		const schema = this.get("Schema");
		const items = this.get("Items");
		const itemsForRemove = Terrasoft.decode(response.itemsUId);
		Terrasoft.each(itemsForRemove, function(itemData) {
			const item = schema.findItemByUId(itemData.Id);
			if (item == null) {
				return;
			}
			if (items.indexOf(item) >= 0) {
				item.removeByDesignerEvent = true;
				items.remove(item);
			} else {
				schema.remove(item.name);
			}
		}, this);
	},

	setExpectingAddElementState: function(response) {
		this.removeNewElement();
		this.appendMode = true;
		this.newElementManagerItemUId = response.newElementManagerItemUId;
	},

	setSelectionMode: function() {
		this.removeNewElement();
	},

	removeNewElement: function() {
		this.appendMode = false;
		if (this.newElement) {
			const items = this.get("Items");
			this.newElement.removeByDesignerEvent = true;
			items.remove(this.newElement);
			this.postDiagramRemoveItem(this.newElement, true);
			this.newElement = null;
		}
	},

	setFocusedElementByName: function(response) {
		const itemName = response.itemName;
		this.fireEvent("itemSelected", itemName);
	},

	/**
	 * Adding a process schema and all of its parents to the container collection in the order from parent to subordinate
	 * @param {Terrasoft.ProcessSchema} schema The scheme of the process.
	 * @param {Terrasoft.Collection} collection A collection of elements.
	 * @param {Terrasoft.ProcessBaseElementSchema} container The container to add.
	 * @private
	 */
	addContainer: function(schema, collection, container) {
		if (collection.find(container.name)) {
			return;
		}
		const parent = container.parent;
		if (parent) {
			const parentContainer = schema.flowElements.find(parent);
			if (parentContainer) {
				this.addContainer(schema, collection, parentContainer);
			}
		}
		const index = this.findIndexOfContainerOverItem(container, collection);
		if (index) {
			collection.insert(index, container.name, container);
		} else {
			collection.add(container.name, container);
			container.on("changed", this.onItemChanged, this);
		}
	},

	/**
	 * Returns the index in the container collection that is above the item
	 * @param {Terrasoft.manager.ProcessFlowElementSchema} item Schema item
	 * @param {Terrasoft.Collection} collection The schema item collection
	 * @return {integer}
	 */
	findIndexOfContainerOverItem: function(item, collection) {
		let findIndex;
		collection.each(function(flowElement, index) {
			if (flowElement.isContainer && item.uId !== flowElement.uId && item.parent === flowElement.parent &&
				(item.position.X + item.width / 2) > flowElement.position.X &&
				(item.position.Y + item.height / 2) > flowElement.position.Y &&
				(item.position.X + item.width / 2) < (flowElement.position.X + flowElement.width) &&
				(item.position.Y + item.height / 2) < (flowElement.position.Y + flowElement.height)) {
				findIndex = index;
				return false;
			}
		}, this);
		return findIndex;
	},

	/**
	 * Processor of the process load event. Fills the Items collection with process elements.
	 * @param {Terrasoft.ProcessSchema} schema The scheme of the process.
	 * @private
	 */
	onSchemaLoaded: function(schema) {
		const items = this.get("Items");
		const collection = Ext.create("Terrasoft.Collection");
		schema.lanes.each(function(lane) {
			collection.add(lane.name, lane);
		}, this);
		schema.flowElements.each(function(flowElement) {
			if (flowElement.isContainer === true) {
				this.addContainer(schema, collection, flowElement);
			}
		}, this);
		schema.flowElements.each(function(flowElement) {
			if (flowElement.isContainer === true) {
				return;
			}
			if (schema.flowElementsParameters) {
				const flowElementParameters = schema.flowElementsParameters[flowElement.uId];
				if (flowElementParameters) {
					const parameters = flowElement.parameters = {};
					Terrasoft.each(flowElementParameters, function(parameter) {
						parameters[parameter.name] = parameter;
					}, this);
					flowElement.parameters = parameters;
				}
			}
			if (flowElement.nodeType !== Terrasoft.diagram.UserHandlesConstraint.Connector) {
				const index = this.findIndexOfContainerOverItem(flowElement, collection);
				const item = index
					? collection.insert(index, flowElement.name, flowElement)
					: collection.add(flowElement.name, flowElement);
				item.on("changed", this.onItemChanged, this);
			}
		}, this);
		schema.flowElements.each(function(flowElement) {
			if (flowElement.nodeType === Terrasoft.diagram.UserHandlesConstraint.Connector) {
				const item = collection.add(flowElement.name, flowElement);
				item.on("changed", this.onItemChanged, this);
			}
		}, this);
		this.set("Schema", schema);
		items.loadAll(collection);
		items.on("remove", this.onItemRemove, this);
		items.on("add", this.onItemAdd, this, {
			priority: 900
		});
		this.fireEvent("initialized", this);
		this.sendMessage({
			message: "Initialized"
		});
	},

	/**
	 * The event handler for adding a new item to the Items collection. Adds an element to the schema.
	 * @param {Terrasoft.manager.ProcessBaseElementSchema} item The item to add.
	 */
	onItemAdd: function(item) {
		const schema = this.get("Schema");
		schema.add(item);
		this.fireEvent("itemschanged", {
			action: "add",
			item: item
		});
		this.postElementAdded(item);
		item.on("changed", this.onItemChanged, this);
	},

	/**
	 * The event handler for removing an item from the Items collection. Removes an element from the schema.
	 * @param {Terrasoft.manager.ProcessBaseElementSchema} item The deleted item.
	 * @private
	 */
	onItemRemove: function(item) {
		const schema = this.get("Schema");
		if (item.removeByDesignerEvent !== true) {
			this.postDiagramRemoveItem(item, true);
		}
		schema.remove(item.name);
		this.fireEvent("itemschanged", {
			action: "remove",
			item: item
		});
		item.un("changed", this.onItemChanged, this);
	},

	/**
	 * Change SequenceFlow connections. If targetNode is empty (targetRefUId is empty guid), shows sequence flow element
	 * properties page, if panel is visible.
	 * @param {Object[]} connectors Sequence flow diagram config array.
	 */
	onConnectorsNodesChange: function(connectors) {
		Terrasoft.each(connectors, function(connector) {
			const sequenceFlow = this.getItemByName(connector.name);
			const targetItem = this.getItemByName(connector.targetNode);
			const sourceItem = this.getItemByName(connector.sourceNode);
			sequenceFlow.targetRefUId = targetItem.uId;
			sequenceFlow.targetSequenceFlowPointLocalPosition = connector.targetPort;
			sequenceFlow.sourceRefUId = sourceItem.uId;
			sequenceFlow.sourceSequenceFlowPointLocalPosition = connector.sourcePort;
			this.postSequenceChanges([sequenceFlow]);
			this.postSelectingChanged(sequenceFlow.uId);
		}, this);
	},

	/**
	 * Sending information to the server about the changes in the communications of the control flow.
	 */
	postSequenceChanges: function(sequenceFlows) {
		const itemUIds = [];
		const propertiesData = [];
		Terrasoft.each(sequenceFlows, function(sequenceFlow) {
			const postObject = {
				targetRefUId: sequenceFlow.targetRefUId,
				sourceRefUId: sequenceFlow.sourceRefUId
			};
			if (sequenceFlow.sourceSequenceFlowPointLocalPosition) {
				postObject.sourceSequenceFlowPointLocalPosition =
					sequenceFlow.getSerializablePortName(sequenceFlow.sourceSequenceFlowPointLocalPosition);
			}
			if (sequenceFlow.targetSequenceFlowPointLocalPosition) {
				postObject.targetSequenceFlowPointLocalPosition =
					sequenceFlow.getSerializablePortName(sequenceFlow.targetSequenceFlowPointLocalPosition);
			}
			itemUIds.push(sequenceFlow.uId);
			propertiesData.push(postObject);
		});
		this.postDiagramItemsPropertiesChanged(itemUIds, propertiesData);
	},

	/**
	 * The event handler for changing the positions of chart elements. Changes the process diagram.
	 * @param {Array} itemsConfig An array of element configurations.
	 * @param {String} itemsConfig.itemName The name of the diagram element.
	 * @param {Object} itemsConfig.position New item position.
	 * @param {Number} itemsConfig.position.x The x-axis coordinate.
	 * @param {Number} itemsConfig.position.y The y-axis coordinate.
	 */
	onItemsPositionChanged: function(itemsConfig) {
		const schema = this.get("Schema");
		const itemUIds = [];
		const propertiesData = [];
		itemsConfig.forEach(function(config) {
			const itemName = config.itemName;
			schema.changeItemPosition(itemName, config.position);
			const position = Math.floor(config.position.x) + ";" + Math.floor(config.position.y);
			const item = this.getItemByName(itemName);
			itemUIds.push(item.uId);
			propertiesData.push({
				Position: position
			});
		}, this);
		this.postDiagramItemsPropertiesChanged(itemUIds, propertiesData);
	},

	/**
	 * The event handler for the container of the chart elements. Changes the process diagram.
	 * @param {Array} itemsConfig An array of item configurations.
	 * @param {String} itemsConfig.itemName The name of the chart element.
	 * @param {String} itemsConfig.containerName Container name.
	 */
	onItemsContainerChanged: function(itemsConfig) {
		const schema = this.get("Schema");
		const itemUIds = [];
		const propertiesData = [];
		itemsConfig.forEach(function(config) {
			const itemName = config.itemName;
			const containerName = config.containerName;
			schema.changeItemContainer(itemName, containerName);
			const item = this.getItemByName(itemName);
			const container = this.getItemByName(containerName);
			itemUIds.push(item.uId);
			propertiesData.push({
				ContainerUId: container.uId
			});
		}, this);
		this.postDiagramItemsPropertiesChanged(itemUIds, propertiesData);
		if (itemUIds.length === 1) {
			this.postSelectingChanged(itemUIds[0]);
		}
	},

	/**
	 * Modifies the breakpoints of the process elements.
	 * @param {Object[]} connectorsData Information about the changed streams.
	 * Contains the name of the stream and a new array of breakpoints.
	 */
	onPolylinePointPositionsChanged: function(connectorsData) {
		const schema = this.get("Schema");
		const itemsUId = [];
		const itemsPostData = [];
		connectorsData.forEach(function(itemData) {
			const itemName = itemData.name;
			const polylinePointPositions = itemData.polylinePointPositions;
			const item = this.getItemByName(itemName);
			schema.changeSequenceFlowPolylinePointPositions(itemName, polylinePointPositions);
			const postData = {};
			polylinePointPositions.forEach(function(item, index) {
				postData["Item" + index] = Math.floor(item.x) + ";" + Math.floor(item.y);
			});
			itemsUId.push(item.uId);
			itemsPostData.push({
				polylinePointPositions: postData
			});
		}, this);
		this.postDiagramItemsPropertiesChanged(itemsUId, itemsPostData);
	},

	/**
	 * The event handler for the resizing event of the chart element. Changes the process diagram.
	 * @param {Object} args Event parameter
	 * @param {String} args.itemName The name of the diagram element.
	 * @param {Object} args.size New element sizes.
	 * @param {Number} args.size.width The width of the element.
	 * @param {Number} args.size.height The height of the element.
	 */
	onElementSizeChanged: function(args) {
		const schema = this.get("Schema");
		const itemName = args.itemName;
		schema.changeItemSize(itemName, args.size);
		const item = this.getItemByName(itemName);
		const size = Math.floor(args.size.width) + ";" + Math.floor(args.size.height);
		this.postDiagramItemsPropertiesChanged([item.uId], [{
			Size: size
		}]);
	},

	/**
	 * Send a message to the server about changing the properties of the elements.
	 * @param {Array} itemUIds An array of UId elements whose properties are changing.
	 * @param {Array} propertiesData An array of JSON strings of variable element properties.
	 */
	postDiagramItemsPropertiesChanged: function(itemUIds, propertiesData) {
		this.sendMessage({
			message: "DiagramItemsPropertiesChanged",
			itemUIds: itemUIds,
			propertiesData: propertiesData
		});
	},

	/**
	 * The handler of the event changing the position of the gist of the chart. Changes the process diagram.
	 * @param {Object} args Event parameter.
	 * @param {String} args.itemName The name of the diagram element.
	 * @param {Object} args.position The new position of the element.
	 * @param {Number} args.position.x The x-axis coordinate.
	 * @param {Number} args.position.y The y-axis coordinate.
	 */
	onLinePositionChanged: function(args) {
		const schema = this.get("Schema");
		schema.changeLinePosition(args.itemName, args.position);
	},

	/**
	 * Sets the unique name and title to the process element.
	 * @param {Object} item
	 */
	onGenerateItemNameAndCaption: function(item) {
		const schema = this.get("Schema");
		const items = this.get("Items");
		let index = 1;
		const defName = item.name;
		let key = defName + index;
		const inheritedElements = this.get("Schema").inheritedElements;
		const isEmbedded = schema.isEmbedded;
		while (this.containsCaseInsensitive(items, key, isEmbedded) ||
		this.containsCaseInsensitive(inheritedElements, key, isEmbedded)) {
			index++;
			key = defName + index;
		}
		item.name = key;
		if (isEmbedded) {
			item.name += "_" + Terrasoft.formatGUID(item.uId, "N");
		}
		const cultureValues = item.caption.cultureValues;
		Terrasoft.each(cultureValues, function(value, culture) {
			if (value) {
				cultureValues[culture] = value + " " + index;
			}
		});
		return false;
	},

	/**
	 * Checks for the presence of an element by key regardless of the case.
	 * @param {Terrasoft.Collection} collection A collection of items.
	 * @param {String} searchKey The item's key.
	 * @returns {Boolean}
	 */
	containsCaseInsensitive: function(collection, searchKey, isEmbedded) {
		const searchKeyInLowerCase = searchKey.toLowerCase();
		return collection.getKeys().some(function(key) {
			if (isEmbedded) {
				return key.toLowerCase().indexOf(searchKeyInLowerCase) > -1;
			} else {
				return key.toLowerCase() === searchKey.toLowerCase();
			}
		});
	},

	/**
	 * Returns the process schema element by its name.
	 * @param {String} name Element name.
	 * @return {Object}
	 */
	getItemByName: function(name) {
		const schema = this.get("Schema");
		if (schema.name === name) {
			return schema;
		}
		const items = this.get("Items");
		return items.get(name);
	},

	/**
	 * The click event handler for the diagram. If the properties panel is open,
	 * the properties edit module is loaded into it.
	 * @param {Object} e The event parameter.
	 */
	onDiagramClick: function(e) {
		const element = e.element;
		if (element && element.type !== "pseudoGroup") {
			const name = element.name;
			if (name) {
				const item = this.getItemByName(name);
				if (item) {
					this.postSelectingChanged(item.uId);
				}
			}
		}
	},

	/**
	 * Send a message to the server about the selection of the item.
	 * @param {String} itemUId uId of the selected item.
	 */
	postSelectingChanged: function(itemUId) {
		this.sendMessage({
			message: "SelectingChanged",
			itemUId: itemUId
		});
	},

	/**
	 * Double click event handler for the diagram. Opens the properties panel, and loads
	 * the properties edit module into it.
	 * @param {Object} e The event parameter.
	 */
	onDiagramDoubleClick: function(e) {
		if (e.evt.type !== "doubletap") {
			return;
		}
		const element = e.element;
		if (element) {
			this.postElementDoubleClick(element);
		}
	},

	/**
	 * The handler for changing a collection item.
	 * @param {Object} changes The change object.
	 * @param {Terrasoft.EntitySchemaManagerItem} item A collection item.
	 */
	onItemChanged: function(changes, item) {
		this.fireEvent("itemChanged", item, changes);
	},

	/**
	 * Sending a message to the server about adding a new element to the diagram.
	 * @param {Object} element Added element
	 */
	postElementAdded: function(element) {
		const jsonData = element.getUIJsonData();
		const jsonStringData = Terrasoft.encode(jsonData);
		this.sendMessage({
			message: "ElementAdded",
			managerItemUId: element.managerItemUId,
			jsonStringData: jsonStringData
		});
	},

	/**
	 * Send a double-click event message to the chart element.
	 * @param {Object} element The element on which the action is performed.
	 */
	postElementDoubleClick: function(element) {
		const name = element.name;
		const item = this.getItemByName(name);
		this.sendMessage({
			message: "ElementDoubleClick",
			itemUId: item.uId
		});
	},

	/**
	 * Sending a message to the server about deleting the item.
	 * @param {Object} element The element on which the action is performed.
	 * @param {Boolean} silentRemoveMode Delete without confirmation.
	 */
	postDiagramRemoveItem: function(element, silentRemoveMode) {
		const collection = Ext.create("Terrasoft.Collection");
		collection.add(element.name, element);
		this.postDiagramRemoveItems(collection, silentRemoveMode);
	},

	/**
	 * Sending a message to the server about deleting the item.
	 * @param {Terrasoft.Collection} collection A collection of elements.
	 * @param {Boolean} silentRemoveMode Uninstall without confirmation.
	 */
	postDiagramRemoveItems: function(collection, silentRemoveMode) {
		const itemUIds = [];
		collection.each(function(item) {
			itemUIds.push(item.uId);
		});
		this.sendMessage({
			message: "DiagramRemoveItems",
			itemUIds: itemUIds,
			silentRemoveMode: silentRemoveMode
		});
	},

	/**
	 * Event handler removed items of diagram.
	 * @protected
	 * @param {Object} args Event object.
	 * @param {Array} args.itemNameList Array of items.
	 */
	onItemsRemoving: function(args) {
		const itemName = args.itemNameList[0];
		const item = this.getItemByName(itemName);
		this.postDiagramRemoveItem(item);
		return false;
	},

	onDestroy: function() {
		const items = this.get("Items");
		items.destroy();
		const schema = this.get("Schema");
		if (schema) {
			schema.destroy();
		}
		this.callParent(arguments);
	},

	/**
	 * The event handler for inserting an element into the sequence flow.
	 * @param {String} itemName The name of the element that is inserted.
	 * @param {ej.Diagram.Node} connector The selected sequence flow.
	 */
	onInsertNodeInConnector: function(itemName, connector) {
		const items = this.get("Items");
		const flowElement = items.get(itemName);
		const sequenceFlow = items.get(connector.name);
		const newSequenceFlow = sequenceFlow.insertFlowElement(flowElement);
		connector.targetPort = sequenceFlow.targetSequenceFlowPointLocalPosition;
		this.onGenerateItemNameAndCaption(newSequenceFlow);
		items.add(newSequenceFlow.name, newSequenceFlow);
		this.postSequenceChanges([newSequenceFlow, sequenceFlow]);
		this.postElementDoubleClick(newSequenceFlow);
		this.postSelectingChanged(flowElement.uId);
		return false;
	},

	/**
	 * Returns the location.origin property. Checks for the presence of a property for IE.
	 */
	getLocationOrigin: function() {
		let origin = window.location.origin;
		if (!origin) { // IE fix
			origin = window.location.protocol + "//" + window.location.hostname +
				(window.location.port ? ":" + window.location.port : "");
		}
		return origin;
	},

	/**
	 * A message to the server for changing information about the process.
	 * @param {Object} requestJson Object of information with changes.
	 */
	sendMessage: function(requestJson) {
		const schemaUId = this.get("SchemaUId");
		requestJson.schemaUId = schemaUId;
		const message = Terrasoft.encode(requestJson);
		const locationOrigin = this.getLocationOrigin();
		const parent = window.parent;
		parent.postMessage(message, locationOrigin);
	}
});

Ext.define("Terrasoft.manager.EmbeddedProcessSchema5x", {
	extend: "Terrasoft.ProcessSchema",
	alternateClassName: "Terrasoft.EmbeddedProcessSchema5x",

	/**
	 * @private
	 */
	convertedMethodsSchemaUIdList: null,

	/**
	 * @private
	 */
	userDefinedCode: null
});
