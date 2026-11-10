Ext.define("Terrasoft.Designers.ProcessSchemaDesignerViewModelNew", {
	extend: "Terrasoft.Designers.ProcessSchemaDesignerViewModel",
	alternateClassName: "Terrasoft.ProcessSchemaDesignerViewModelNew",

	mixins: {
		customEvent: "Terrasoft.mixins.CustomEventDomMixin",
		diagramTypeResolver: "Terrasoft.diagram.ProcessDiagramTypeResolver"
	},

	//region Fields: Private

	/**
	 * @private
	 */
	_cachedSuggestionsMap: null,

	/**
	 * @private
	 */
	_defaultSuggestionsLoadingTimeout: 2000,

	/**
	 * @private
	 */
	 _suggestionsPopupShowDelay: 100,

	//endregion

	// region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.Designers.BaseProcessSchemaDesignerViewModel#urlHashPrefix
	 * @override
	 */
	urlHashPrefix: "process",

	/**
	 * Service task elements groups.
	 * @protected
	 */
	serviceTaskGroups: [Terrasoft.FlowElementGroup.ServiceTask, Terrasoft.FlowElementGroup.Subprocess],

	/**
	 * User task elements groups.
	 * @protected
	 */
	userTaskGroups: [Terrasoft.FlowElementGroup.UserTask],

	//endregion

	// region Methods: Private

	/**
	 * @private
	 */
	_getImageUrl: function(imageName) {
		if (!imageName) {
			return null;
		}
		const config = {
			source: Terrasoft.ImageSources.RESOURCE_MANAGER,
			params: {
				resourceManagerName: "Terrasoft.Nui",
				resourceItemName: "ProcessSchemaDesigner." + imageName
			}
		};
		return Terrasoft.ImageUrlBuilder.getUrl(config);
	},

	/**
	 * @private
	 */
	_addUnsupportedElements: function(items) {
		let count =	Terrasoft.ProcessDiagramUnsupportedTypes.length;
		while (count--) {
			const element = this.getUnsupportedElementConfig(Terrasoft.ProcessDiagramUnsupportedTypes[count]);
			const type = element.type;
			items[type] = {
				caption: type,
				isUnsupported: true,
				showInReplaceMenu: false,
				userTaskType: element.transformToType || type,
				width: element.width,
				height: element.height,
				largeImage: this._getImageUrl(element.largeImage),
				smallImage: "",
				menuOrder: null,
				replaceGroupId: null,
				type: type
			};

		}
		return items;
	},

	/**
	 * @private
	 */
	_setEventSubProcessStartEvent: function(customDiagramElements) {
		const signalType = this.getEventSubProcessStartSignalElementSchema();
		const startSignal = this.toDiagramType(signalType);
		const eventSubProcess = this.toDiagramType(Terrasoft.ProcessEventSubprocessSchema);
		const eventSubProcessConfig = customDiagramElements[eventSubProcess];
		if (eventSubProcessConfig) {
			eventSubProcessConfig.startEvent = startSignal;
		}
	},

	/**
	 * @protected
	 */
	getElementSchemaManagerItems: function() {
		return this.elementSchemaManager.getItems().getItems();
	},

	/**
	 * @protected
	 */
	getCustomDiagramElements: function() {
		const schemaManagerItems = this.getElementSchemaManagerItems();
		const excludedMenuItems = this.getExcludedMenuItems();
		const elements = schemaManagerItems.reduce((items, managerItem) => {
			const item = managerItem.instance;
			const type = this.toDiagramType(item);
			if (!type) {
				return items;
			}
			const name = this.toDiagramTypeName(item);
			const largeImage = item.getImageConfig(item.largeImageName);
			const smallImage = item.getImageConfig(item.smallImageName);
			const titleImage = item.getImageConfig(item.titleImageName);
			const caption = (item.caption && item.caption.toString()) || item.defaultCaption || "";
			if (items[name]) {
				console.warn(`Duplicates element "${name}" found`);
			}
			const itemOrderArray = Terrasoft.process.constants.PROCESS_DIAGRAM_REPLACE_MENU_ORDER;
			const showInReplaceMenu = !item.isDeprecated && !Terrasoft.contains(excludedMenuItems, item.name);
			items[name] = {
				caption,
				type,
				width: item.width,
				height: item.height,
				showInReplaceMenu: showInReplaceMenu,
				menuOrder: itemOrderArray.findIndex((x) => x === item.name),
				largeImage: largeImage && Terrasoft.ImageUrlBuilder.getUrl(largeImage),
				smallImage: smallImage && Terrasoft.ImageUrlBuilder.getUrl(smallImage),
				propertiesImage: titleImage && Terrasoft.ImageUrlBuilder.getUrl(titleImage),
				userTaskType: name,
				replaceGroupId: this.getElementReplaceGroupId(item)
			};
			return items;
		}, {});
		this._setEventSubProcessStartEvent(elements);
		this._addUnsupportedElements(elements);
		return elements;
	},

	/**
	 * @protected
	 */
	getEventSubProcessStartSignalElementSchema: function() {
		return Terrasoft.ProcessStartSignalNonInterruptingSchema;
	},

	/**
	 * @protected
	 */
	getElementReplaceGroupId: function(item) {
		switch (true) {
			case this.serviceTaskGroups.includes(item.group):
				return Terrasoft.FlowElementGroup.ServiceTask;
			case this.userTaskGroups.includes(item.group):
				return Terrasoft.FlowElementGroup.UserTask;
			default:
				return null;
		}
	},

	/**
	 * @protected
	 */
	getCustomDiagramReplaceMenuGroups: function() {
		const group = Terrasoft.FlowElementGroup;
		return {
			[group.ServiceTask]: {
				id: group.ServiceTask,
				imageUrl: this._getImageUrl("ElementReplaceGroup.ServiceActionsImage.svg"),
				label: Terrasoft.Resources.ProcessSchemaDesigner.ElementsToolbarGroup.ServiceTask
			},
			[group.UserTask]: {
				id: group.UserTask,
				imageUrl: this._getImageUrl("ElementReplaceGroup.UserTask.svg"),
				label: Terrasoft.Resources.ProcessSchemaDesigner.ElementsToolbarGroup.UserTask
			}
		};
	},

	/**
	 * @protected
	 */
	getPaletteUserTask: function() {
		const userTask = Terrasoft.FlowElementGroup.UserTask;
		const menuItems = Terrasoft.flatten(this.userTaskGroups.map((group) => this.getMenuItemsByGroup(group)));
		const element = {
			type: "userTask",
			title: Terrasoft.Resources.ProcessSchemaDesigner.ElementsToolbarGroup[userTask],
			imageUrl: "TaskPalette.svg",
			menu: menuItems
		};
		this.addUserTaskType(element, "ActivityUserTask");
		return element;
	},

	/**
	 * @protected
	 */
	getPaletteServiceTask: function() {
		const menuItems = Terrasoft.flatten(this.serviceTaskGroups.map((group) => this.getMenuItemsByGroup(group)));
		const element = {
			type: "serviceTask",
			title: Terrasoft.Resources.ProcessSchemaDesigner.ElementsToolbarGroup[Terrasoft.FlowElementGroup.ServiceTask],
			imageUrl: "SmartTaskPalette.svg",
			menu: menuItems
		};
		this.addUserTaskType(element, "ReadDataUserTask");
		return element;
	},

	/**
	 * @protected
	 */
	getElementToolsUserTask: function() {
		const element = {
			type: "userTask",
			title: Terrasoft.Resources.ProcessSchemaDesigner.ElementsToolbarGroup[Terrasoft.FlowElementGroup.UserTask],
			image: "icon_tools_task.svg"
		};
		this.addUserTaskType(element, "ActivityUserTask");
		return element;
	},

	/**
	 * @protected
	 */
	getElementToolsServiceTask: function() {
		const element = {
			type: "serviceTask",
			title: Terrasoft.Resources.ProcessSchemaDesigner.ElementsToolbarGroup[Terrasoft.FlowElementGroup.ServiceTask],
			image: "SmartTaskTool.svg"
		};
		this.addUserTaskType(element, "ReadDataUserTask");
		return element;
	},

	/**
	 * @protected
	 */
	addUserTaskType: function(element, name) {
		const items = this.elementSchemaManager.getItems().getItems();
		const userTask = items.find((x) => x.instance.name === name);
		if (userTask) {
			element.userTaskType = this.toDiagramTypeName(userTask.instance);
		}
	},

	/**
	 * Returns an array of items to exclude from menu.
	 * @protected
	 */
	getExcludedMenuItems: function() {
		return [
			"ReportFileProcessingUserTask",
			"ProcessFileProcessingUserTask"
		];
	},

	/**
	 * @protected
	 */
	getMenuItemsByGroup: function(group) {
		const items = this.elementSchemaManager.getItems().getItems();
		const excludedMenuItems = this.getExcludedMenuItems();
		return items.map((x) => x.instance)
			.filter((x) => x.group === group)
			.filter((x) => !x.isDeprecated)
			.filter((x) => !Terrasoft.contains(excludedMenuItems, x.name))
			.map((x) => this.toDiagramTypeName(x))
			.sort((item1, item2) => this.getMenuItemOrder(item1) - this.getMenuItemOrder(item2));
	},

	/**
	 * @protected
	 */
	getMenuItemOrder: function(itemName) {
		const itemsOrder = this.paletteItemMenuOrder();
		const maxIndex = itemsOrder.length;
		let index = itemsOrder.indexOf(itemName);
		if (index < 0) {
			index = maxIndex + 1;
		}
		return index;
	},

	/**
	 * @protected
	 */
	paletteItemMenuOrder: function() {
		return [
			"activityUserTask",
			"userQuestionUserTask",
			"openEditPageUserTask",
			"autoGeneratedPageUserTask",
			"preconfiguredPageUserTask",
			"emailUserTask",
			"readDataUserTask",
			"addDataUserTask",
			"changeDataUserTask",
			"deleteDataUserTask",
			"formulaTask",
			"changeAdminRightsUserTask",
			"objectFileProcessingUserTask",
			"webService",
			"executeIntentUserTask",
			"mLDataPredictionUserTask",
			"sendEmailUserTask",
			"scriptTask",
			"linkEntityToProcessUserTask",
			"userTask",
			"emailTemplateUserTask",
			"searchDuplicatesUserTask"
		];
	},

	/**
	 * @protected
	 */
	getCustomPaletteElements: function() {
		const userTask = this.getPaletteUserTask();
		const serviceTask = this.getPaletteServiceTask();
		const paletteElements = {
			...(userTask ? {userTask} : {}),
			...(serviceTask ? {serviceTask} : {}),
			startEvent: {
				type: "startEvent",
				imageUrl: "StartEventPalette.svg",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.StartEventCaption
			},
			intermediateThrowEventSignal: {
				type: "intermediateThrowEventSignal",
				imageUrl: "IntermediateEventPalette.svg",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.IntermediateThrowSignalCaption
			},
			endEvent: {
				type: "endEvent",
				imageUrl: "EndEventPalette.svg",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.TerminateEventCaption
			},
			exclusiveGateway: {
				type: "exclusiveGateway",
				imageUrl: "GatewayPalette.svg",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.ExclusiveGatewayCaption
			}
		};
		Object.values(paletteElements).forEach((element) => {
			element.imageUrl = this._getImageUrl(element.imageUrl);
		});
		return paletteElements;
	},

	/**
	 * @protected
	 */
	getCustomElementToolsConfig: function() {
		const userTask = this.getElementToolsUserTask();
		const serviceTask = this.getElementToolsServiceTask();
		const addItems = [
			...[userTask],
			...[serviceTask],
			{
				image: "icon_tools_gateway.svg",
				type: "exclusiveGateway",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.ExclusiveGatewayCaption
			},
			{
				image: "icon_tools_intermediate_event.svg",
				type: "intermediateThrowEventSignal",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.IntermediateThrowSignalCaption
			},
			{
				image: "icon_tools_end_event.svg",
				type: "endEvent",
				title: Terrasoft.Resources.ProcessSchemaDesigner.Elements.TerminateEventCaption
			}
		].filter((x) => x);
		addItems.forEach((item) => {
			item.image = this._getImageUrl(item.image);
		});
		const tools = {
			connect: {
				imageUrl: this._getImageUrl("ElementTools.ArrowToolsImage.svg"),
				title: Terrasoft.Resources.ProcessSchemaDesigner.ElementTools.ConnectHint
			},
			setup: {
				imageUrl: this._getImageUrl("ElementTools.SetupToolsImage.svg"),
				title: Terrasoft.Resources.ProcessSchemaDesigner.ElementTools.ChangeTypeHint
			},
			delete: {
				imageUrl: this._getImageUrl("ElementTools.DeleteToolsImage.svg"),
				title: Terrasoft.Resources.ProcessSchemaDesigner.ElementTools.RemoveHint
			},
			suggestions: {
				enabled: Boolean(this.get("SuggestionsEnabled")),
				enabledAutoOpenPopup: Boolean(this.get("AutoOpenSuggestionsPopup")),
				imageUrl: this._getImageUrl("ElementTools.AISuggestionToolsImage.svg"),
				title: Terrasoft.Resources.ProcessSchemaDesigner.ElementTools.AISuggestionHint,
				loadingTimeout: this.get("SuggestionsLoadingTimeout") + this._suggestionsPopupShowDelay
			}
		};
		return {addItems, tools};
	},

	/**
	 * @protected
	 */
	getCustomLocalizableStrings: function() {
		return {
			elementTools: {
				copySuffixCaption: Terrasoft.Resources.SchemaDesigner.CopySuffixCaption
			},
			fitToView: Terrasoft.Resources.ProcessSchemaDesigner.FitToView,
			resetView: Terrasoft.Resources.ProcessSchemaDesigner.ResetView,
			zoomIn: Terrasoft.Resources.ProcessSchemaDesigner.ZoomIn,
			zoomOut: Terrasoft.Resources.ProcessSchemaDesigner.ZoomOut,
			miniMapOpen: Terrasoft.Resources.ProcessSchemaDesigner.MiniMapOpen,
			miniMapClose: Terrasoft.Resources.ProcessSchemaDesigner.MiniMapClose,
			arrow: Terrasoft.Resources.ProcessSchemaDesigner.ArrowHint,
			lasso: Terrasoft.Resources.ProcessSchemaDesigner.LassoHint,
			space: Terrasoft.Resources.ProcessSchemaDesigner.SpaceToolHint,
			suggestions: {
				popupTitle: Terrasoft.Resources.ProcessSchemaDesigner.Suggestions.PopupTitle,
				popupSubtitle: Terrasoft.Resources.ProcessSchemaDesigner.Suggestions.PopupSubtitle
			}
		};
	},

	/**
	 * @protected
	 */
	getCustomImages: function () {
		return {
			spinnerImage: this._getImageUrl("SuggestionsSpinner.svg")
		};
	},

	/**
	 * @protected
	 */
	getDiagramConfig: function() {
		const customDiagramElements = this.getCustomDiagramElements();
		const customDiagramReplaceMenuGroups = this.getCustomDiagramReplaceMenuGroups();
		const customPaletteElements = this.getCustomPaletteElements();
		const customElementToolsConfig = this.getCustomElementToolsConfig();
		const customLocalizableStrings = this.getCustomLocalizableStrings();
		const customMarkers = this.getCustomMarkers();
		const config = {
			customDiagramElements,
			customDiagramReplaceMenuGroups,
			customPaletteElements,
			customElementToolsConfig,
			customLocalizableStrings,
			customMarkers
		};
		if (this.getIsSuggestionsEnabled()) {
			config.customImages = this.getCustomImages();
		}
		return config;
	},

	/**
	 * @protected
	 */
	getCustomMarkers: function() {
		return {
			Collapsed: {
				smallImage: this._getImageUrl("CollapsedSmall.svg")
			},
			SequenceMultiInstance: {
				smallImage: this._getImageUrl("SequenceMultiInstanceSmall.svg")
			},
			ParallelMultiInstance: {
				smallImage: this._getImageUrl("ParallelMultiInstanceSmall.svg")
			}
		};
	},

	/**
	 * @protected
	 */
	onItemChanged: function(changes, item) {
		this.callParent(arguments);
		if (changes.hasOwnProperty("markers")) {
			this.fireEvent("itemMarkersChanged", {uId: item.uId, markers: changes.markers});
		}
	},

	/***
	 * @private
	 */
	_getDefaultLane(items) {
		const lanes = items.filterByPath("typeName", "Terrasoft.Core.Process.ProcessSchemaLane");
		return lanes.getCount() === 1 ? lanes.getByIndex(0) : null;
	},

	/***
	 * @private
	 */
	_getContainerName: function(parentId) {
		const items = this.get("Items");
		const defaultLane = this._getDefaultLane(items);
		const container = parentId === "root1"
			? defaultLane
			: items.findByPath("uId", parentId) || defaultLane;
		return container && container.name;
	},

	/**
	 * @private
	 */
	_validateRemove: function(itemNameList) {
		return new Promise((done) => {
			const schema = this.get("Schema");
			Terrasoft.chain(
				(next) => Terrasoft.ProcessSchemaDesignerUtilities
					.validateAllLazyPropertiesAreLoaded(schema, next, this),
				(next, areLoaded) => (areLoaded ? next() : done(false)),
				(next) => Terrasoft.ProcessSchemaDesignerUtilities
					.validateElementRemoval(schema, itemNameList, next, this),
				(next, canRemove) => done(canRemove),
				this
			);
		});
	},

	/**
	 * @private
	 */
	_setItemParent: function(parentId, item) {
		const containerName = this._getContainerName(parentId);
		const schema = this.get("Schema");
		const itemContainer = schema.findItemByName(containerName);
		if (itemContainer) {
			item.containerUId = itemContainer.uId;
			item.parent = itemContainer.name;
		}
	},
	/**
	 * @private
	 */
	_isUnsupportedElement: function(type) {
		return Terrasoft.ProcessDiagramUnsupportedTypes.indexOf(type) > -1;
	},
	/**
	 * @private
	 */
	_createElement: function(element) {
		const managerItemUId = this.getFlowElementSchemaManagerItemByTypeName(element.type).uId;
		const item = this.elementSchemaManager.createInstance(managerItemUId);
		item.uId = element.id;
		item.caption = new Terrasoft.LocalizableString("");
		if (this._isUnsupportedElement(element.type)) {
			item.unsupportedType = element.type;
		}
		this._setItemParent(element.parent, item);
		if (element.size) {
			item.size = element.size;
		}
		item.position = {
			X: element.position.rx || element.position.X,
			Y: element.position.ry || element.position.Y
		};
		item.isValidateExecuted = false;
		item.defaultParamValues = element.defaultParamValues;
		item.source = element.source;
		this.onGenerateItemNameAndCaption(item);
		if (element.caption) {
			item.caption = new Terrasoft.LocalizableString(element.caption);
		}
		return item;
	},

	/**
	 * @private
	 */
	_createLabel: function(labelConfig) {
		const schema = this.get("Schema");
		const parentUId = labelConfig.parentUId;
		const parent = schema.findItemByUId(parentUId);
		const name = parent.name + "_label";
		const label = new Terrasoft.ProcessLabelSchema({
			uId: labelConfig.id,
			parentUId,
			name: name
		});
		this.onGenerateItemNameAndCaption(label);
		return label;
	},

	/**
	 * @private
	 */
	_findChildElements(element) {
		const items = this.get("Items");
		const result = [];
		const children = items.filterByPath("containerUId", element.uId).getItems();
		result.push(...children);
		children.forEach((item) => {
			result.push(...this._findChildElements(item));
		});
		return result;
	},

	/**
	 * @private
	 */
	_getElementNameList: function(ids) {
		const items = this.get("Items");
		const elements = [];
		ids.forEach((id) => {
			const element = items.findByPath("uId", id);
			if (element) {
				elements.push(element, ...this._findChildElements(element));
			}
		});
		return elements.map((item) => item.name);
	},

	/**
	 * @private
	 */
	_findItemByUId: function(itemUId) {
		const items = this.get("Items");
		return items.findByPath("uId", itemUId);
	},

	/**
	 * @private
	 */
	_internalCreateFlow: function(connection) {
		if (!connection) {
			return;
		}
		const items = this.get("Items");
		const sourceItemUId = connection.source;
		const sourceElement = this._findItemByUId(sourceItemUId);
		const targetItemUId = connection.target;
		const targetElement = this._findItemByUId(targetItemUId);
		const sequenceFlow = Ext.create(this.getClassName(connection), {
			uId: connection.id,
			name: connection.type,
			sourceNode: sourceElement.name,
			sourceRefUId: sourceItemUId,
			sourceSequenceFlowPointLocalPosition: "0;0",
			targetNode: targetElement.name,
			targetRefUId: targetItemUId,
			targetSequenceFlowPointLocalPosition: "0;0",
			showPropertiesWindowOnAdding: true,
			isValidateExecuted: false
		});
		if (connection.sourceSequenceFlowPointLocalPosition) {
			sequenceFlow.sourceSequenceFlowPointLocalPosition = connection.sourceSequenceFlowPointLocalPosition;
		}
		if (connection.sourceSequenceFlowPointLocalPosition) {
			sequenceFlow.targetSequenceFlowPointLocalPosition = connection.targetSequenceFlowPointLocalPosition;
		}
		if (sequenceFlow.flowType === Terrasoft.ProcessSchemaEditSequenceFlowType.CONDITIONAL) {
			sequenceFlow.isValid = false;
		}
		if (connection.polylinePointPositions) {
			sequenceFlow.polylinePointPositions = connection.polylinePointPositions;
		}
		sequenceFlow.name = sequenceFlow.connectionUserHandleName;
		if (connection.portPositions) {
			this.setPortPosition(connection, sequenceFlow);
		}
		if (this.onGenerateItemNameAndCaption(sequenceFlow) !== false) {
			let index = 1;
			const defName = sequenceFlow.name;
			let name = defName + index;
			while (items.contains(name)) {
				index++;
				name = defName + index;
			}
			sequenceFlow.name = name;
		}
		if (connection.caption) {
			sequenceFlow.caption = new Terrasoft.LocalizableString(connection.caption);
		}
		return sequenceFlow;
	},

	/**
	 * @private
	 */
	_loadButtonPropertiesPageByName(name) {
		if (name) {
			this.loadPropertiesPage(name);
		} else {
			this.loadSchemaPropertiesPage();
		}
	},

	/**
	 * @private
	 */
	_clearImportData() {
		this.set("ImportData", null);
	},

	/**
	 * @private
	 */
	_getCoreProcessSchemaName: function(type) {
		switch (true) {
			case Terrasoft.ProcessDiagramUnsupportedTerminateEventTypes.includes(type):
				return "Terrasoft.Core.Process.ProcessSchemaUnsupportedTerminateEvent";
			case Terrasoft.ProcessBoundaryEventTypes.includes(type):
				return "Terrasoft.Core.Process.ProcessSchemaBoundaryEvent";
			default:
				return "Terrasoft.Core.Process.ProcessSchemaUnsupportedElement";
		}
	},

	/**
	 * @private
	 */
	_setMLSequenceElementsCountForPredictionSettings: function() {
		const sequenceElementsCountForPrediction = Terrasoft.SysSettings.getCachedSysSetting("MLSequenceElementsCountForPrediction");
		this.set("SequenceElementsCountForPrediction", sequenceElementsCountForPrediction);
	},

	/**
	 * @private
	 */
	_getSequence: function(elementUId) {
		const schema = this.get("Schema");
		const flowElements = schema.getFlowElements();
		const currentElement = flowElements.findByFn((el) => el.uId === elementUId);
		let elementsStack = [];
		this._addSequenceElement(currentElement, elementsStack, flowElements);
		const sequenceElementsCountForPrediction = this.get("SequenceElementsCountForPrediction");
		if (sequenceElementsCountForPrediction && sequenceElementsCountForPrediction > 0) {
			elementsStack = elementsStack.slice(0, sequenceElementsCountForPrediction);
		}
		return elementsStack.reverse();
	},

	/**
	 * @private
	 */
	_serializeParametersForSuggestionsRequest: function(element) {
		const result = [];
		if (!element.parameters) {
			return result;
		}
		Terrasoft.each(element.parameters, (item) => {
			result.push({
				sourceValue: {
					value: Ext.isObject(item.sourceValue.value)
						? JSON.stringify(item.sourceValue.value)
						: item.sourceValue.value,
					source: item.sourceValue.source
				},
				name: item.name,
				referenceSchemaUId: item.referenceSchemaUId || undefined
			});
		});
		if (element.entity) {
			result.push({
				sourceValue: {
					value: element.entity
				},
				name: "EntitySchemaUId"
			});
		}
		return result;
	},

	/**
	 * @private
	 */
	_serializeSequenceForSuggestionsRequest: function(sequence) {
		return sequence.map((element) => {
			return {
				elementId: element.uId,
				typeName: element.typeName,
				schemaName: element.schema && element.schema.name,
				serializedParameters: JSON.stringify(this._getParametersForSuggestionsRequest(element))
			};
		});
	},

	/**
	 * @private
	 */
	_addSequenceElement: function(currentElement, elementsStack, flowElements) {
		if (elementsStack.some(el => el.elementId === currentElement.uId)) {
			return;
		}
		elementsStack.push(currentElement);
		if (currentElement.group === "StartEvent") {
			return;
		}
		const connector = flowElements.findByFn((el) => el.targetRefUId === currentElement.uId);
		if (!connector) {
			return;
		}
		const nextElement = flowElements.findByFn((el) => el.uId === connector.sourceRefUId);
		this._addSequenceElement(nextElement, elementsStack, flowElements);
	},

	/**
	 * @private
	 */
	_setSuggestionsRequestState: function(cacheKey, state) {
		this._cachedSuggestionsMap.set(cacheKey, {
			state: state
		});
	},

	/**
	 * @private
	 */
	_setSuggestionsRequestResultToCache: function(cacheKey, suggestions) {
		this._cachedSuggestionsMap.set(cacheKey, {
			suggestions: suggestions,
			state: Terrasoft.ProcessSuggestionsRequestStatus.Success
		});
	},

	/**
	 * @private
	 */
	_getIsSuggestionsRequestInState: function(cacheKey, state) {
		const cachedSuggestions = this._cachedSuggestionsMap.get(cacheKey);
		return cachedSuggestions.state === state;
	},

	/**
	 * @private
	 */
	_isActiveSuggestionsRequest: function(cacheKey) {
		return this._getIsSuggestionsRequestInState(cacheKey, Terrasoft.ProcessSuggestionsRequestStatus.Active);
	},

	/**
	 * @private
	 */
	_isTimedOutSuggestionsRequest: function(cacheKey) {
		return this._getIsSuggestionsRequestInState(cacheKey, Terrasoft.ProcessSuggestionsRequestStatus.Timeout);
	},

	/**
	 * @private
	 */
	_getSuggestionsFromCacheOrDefaultStorage: function(itemUId, cacheKey, callback) {
		const cachedSuggestions = this._cachedSuggestionsMap.get(cacheKey);
		const suggestions = cachedSuggestions.state === Terrasoft.ProcessSuggestionsRequestStatus.Success
			? cachedSuggestions.suggestions
			: this.get("DefaultSuggestions");
		callback.call(this, itemUId, suggestions);
	},

	/**
	 * @private
	 */
	_getSuggestionsCacheKey: function(sequence, lastItemPredictionParams) {
		const sequenceInDiagramTypes = this._convertDiagramItemsToSuggestionValues(sequence);
		if (lastItemPredictionParams && sequenceInDiagramTypes.length > 0) {
			sequenceInDiagramTypes[sequenceInDiagramTypes.length - 1].parameters = lastItemPredictionParams;
		}
		return JSON.stringify(sequenceInDiagramTypes);
	},

	/**
	 * @private
	 */
	_onUpdateSuggestions: function (eventConfig) {
		if (!eventConfig) {
			return;
		}
		const itemUId = this._getItemUIdForGenerateSuggestions(eventConfig.elementName);
		this.set("Suggestions", {
			elementId: itemUId,
			suggestions: []
		});
		this.set("SuggestionsTriggered", { elementId: itemUId, uniquestamp: Date.now() });
		this._processSuggestions(eventConfig.elementName, eventConfig.predictionParams);
	},

	/**
	 * Updates suggestions on new element initialized that was suggested to user.
	 * @protected
	 * @override
	 */
	updateSuggestionsForSuggestedItem: function(item) {
		this.callParent(arguments);
		const defaultParamValues = item.defaultParamValues;
		if (item.source === "suggestions" && defaultParamValues && defaultParamValues["referenceSchemaUId"]) {
			this._onUpdateSuggestions({
				elementName: item.name,
				predictionParams: {
					entitySchemaUId: defaultParamValues["referenceSchemaUId"]
				}
			});
		}
	},

	/**
	 * @private
	 */
	_getSuggestionsRequestConfig: function(sequence, predictionParams) {
		return {
			url: Terrasoft.workspaceBaseUrl + "/rest/MLProcessPredictionService/PredictNextElement",
			headers: {
				"Accept": "application/json",
				"Content-Type": "application/json"
			},
			method: "POST",
			jsonData: JSON.stringify({
				elements: sequence,
				predictionParams: predictionParams
			})
		};
	},

	/**
	 * @private
	 */
	_onSuggestionsItemsRequestEnd: function(itemUId, cacheKey, callback, request, success, result) {
		let responseData;
		try {
			responseData = JSON.parse(result.responseText);
			if (responseData.resultType === Terrasoft.ProcessSuggestionsResultTypes.ServiceNotConfigured) {
				this.warning("ML service is not configured to predict next process elements. Read " + 
					"https://academy.creatio.com/docs/user/setup_and_administration/on-site_deployment" +
					"/machine_learning_service");
				this.set("SuggestionsEnabled", false);
			}
			if (!success || responseData.errorMessage 
					|| responseData.resultType !== Terrasoft.ProcessSuggestionsResultTypes.Success) {
				throw Error(responseData.errorMessage || "Unknown error");
			}
		} catch (e) {
			this._setSuggestionsRequestState(cacheKey, Terrasoft.ProcessSuggestionsRequestStatus.Error);
			callback.call(this, itemUId, this.get("DefaultSuggestions"));
			return;
		}
		const predictions = responseData.predictions;
		this._setSuggestionsRequestResultToCache(cacheKey, predictions);
		callback.call(this, itemUId, predictions);
	},

	/**
	 * @private
	 */
	_onSuggestionsRetrieveTimeoutPassed: function(cacheKey, itemUId, callback) {
		if (!this._isActiveSuggestionsRequest(cacheKey)) {
			return;
		}
		this._setSuggestionsRequestState(cacheKey, Terrasoft.ProcessSuggestionsRequestStatus.Timeout);
		callback.call(this, itemUId, this.get("DefaultSuggestions"));
	},

	/**
	 * @private
	 */
	_generateSuggestionsForItem: function(itemUId, predictionParams, onSuccessCallback) {
		const itemSequence = this._getSequence(itemUId);
		if (itemSequence.length < 1) {
			return;
		}
		const cacheKey = this._getSuggestionsCacheKey(itemSequence, predictionParams);
		if (!this._needSendRequestForGenerateSuggestions(cacheKey)) {
			if (this._isActiveSuggestionsRequest(cacheKey)) {
				return;
			}
			this._getSuggestionsFromCacheOrDefaultStorage(itemUId, cacheKey, onSuccessCallback);
			return;
		}
		this._setSuggestionsRequestState(cacheKey, Terrasoft.ProcessSuggestionsRequestStatus.Active);
		const serializedSequence = this._serializeSequenceForSuggestionsRequest(itemSequence);
		Terrasoft.AjaxProvider.request({
			...this._getSuggestionsRequestConfig(serializedSequence, predictionParams),
			callback: this._onSuggestionsItemsRequestEnd.bind(this, itemUId, cacheKey, onSuccessCallback),
			scope: this
		});
		setTimeout(this._onSuggestionsRetrieveTimeoutPassed.bind(this, cacheKey, itemUId, onSuccessCallback),
			this.get("SuggestionsLoadingTimeout"));
	},

	/**
	 * @private
	 */
	_needSendRequestForGenerateSuggestions(cachedSequence) {
		const cachedSuggestions = this._cachedSuggestionsMap.get(cachedSequence);
		return !cachedSuggestions ||
			cachedSuggestions.state === Terrasoft.ProcessSuggestionsRequestStatus.Error;
	},

	/**
	 * @private
	 */
	_getItemUIdForGenerateSuggestions: function(name) {
		const item = this.get("Items").findByFn((i) => i.name === name);
		if (!item) {
			return;
		}
		if (item.typeName === "Terrasoft.Core.Process.ProcessSchemaSequenceFlow" ||
			item.typeName === "Terrasoft.Core.Process.ProcessSchemaTerminateEvent") {
			return;
		}
		return item.uId;
	},

	/**
	 * @private
	 */
	_processSuggestions: function(name, predictionParams) {
		if (!name || !this.getIsSuggestionsEnabled()) {
			return;
		}
		const itemUId = this._getItemUIdForGenerateSuggestions(name);
		if (!itemUId) {
			return;
		}
		if (this.get("SuggestionsEnabled")) {
			this._generateSuggestionsForItem(itemUId, predictionParams, this._onItemSuggestionsGenerated);
		} else {
			this._onItemSuggestionsGenerated(itemUId, this.get("DefaultSuggestions"));
		}
	},

	/**
	 * @private
	 */
	_convertDiagramItemsToSuggestionValues: function(items) {
		if (!items) {
			return;
		}
		const convertedItems = [];
		for (const item of items) {
			let diagramType;
			try {
				const schemaName = item.schemaName ?? (item.schema && item.schema.name);
				if (schemaName) {
					diagramType = Terrasoft.toLowerCamelCase(schemaName);
				} else {
					const instance = Terrasoft.ProcessFlowElementSchemaManager.getItemByType(item.typeName).instance;
					diagramType = this.toDiagramTypeName(instance); 
				}
			} catch (e) {
				const message = e.message || e.toString();
				console.warn("Element type conversion failed: " + message);
				continue;
			}
			const convertedItem = {
				type: diagramType,
				parameters: {}
			}
			if (item.entitySchemaUId) {
				convertedItem.parameters.entitySchemaUId = item.entitySchemaUId;
				convertedItem.parameters.entitySchemaCaption = item.entitySchemaCaption;
			} else if (item.parameters) {
				convertedItem.parameters = this._getParametersForSuggestionsRequest(item);
			}
			convertedItems.push(convertedItem);
		}
		return convertedItems;
	},

	/**
	 * @private
	 */
	_getParametersForSuggestionsRequest: function(item) {
		const serializedParameters = this._serializeParametersForSuggestionsRequest(item);
		return this._filterParametersForSuggestionsRequest(serializedParameters);
	},

	/**
	 * @private
	 */
	_filterParametersForSuggestionsRequest: function(parameters) {
		return parameters.filter((parameter) => {
			return !parameter.name.includes('Filter');
		});
	},

	/**
	 * @private
	 */
	_onItemSuggestionsGenerated: function(itemUId, result) {
		const convertedPredictions = this._convertDiagramItemsToSuggestionValues(result);
		const suggestions = {
			elementId: itemUId,
			suggestions: convertedPredictions
		};
		this.set("Suggestions", suggestions);
	},

	/**
	 * @private
	 */
	_setDefaultSuggestionsSettings: function() {
		const suggestionsInSettings = Terrasoft.SysSettings.getCachedSysSetting("MLProcessDefaultSuggestions");
		if (suggestionsInSettings) {
			const suggestions = suggestionsInSettings.split(";").map((s) => {
				const [type, userTask] = s.split(":");
				return {
					typeName: type,
					schemaName: userTask
				};
			});
			this.set("DefaultSuggestions", suggestions);
		}
		const timeout = Terrasoft.SysSettings.cachedSettings.MLSuggestionsLoadingTimeout * 1000
			|| this._defaultSuggestionsLoadingTimeout;
		this.set("SuggestionsLoadingTimeout", timeout);
	},

	/**
	 * Get is current diagram has enabled automatic opening of the popup with suggestions for elements.
	 * @private
	 */
	_getIsAutoOpenSuggestionsPopupEnabled: function() {
		return Terrasoft.SysSettings.getCachedSysSetting("MLProcessAutoOpenSuggestionsPopup");
	},

	// endregion

	// region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.BaseProcessSchemaDesignerViewModel#onSandboxInitialized
	 * @override
	 */
	onSandboxInitialized: function() {
		this.callParent(arguments);
		if (!this.getIsSuggestionsEnabled()) {
			return;
		}
		this.sandbox.registerMessages({
			"UpdateSuggestions": {
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE,
				mode: Terrasoft.MessageMode.PTP
			},
			"GetElementEntityConfigForSuggestions": {
				direction: Terrasoft.MessageDirectionType.PUBLISH,
				mode: Terrasoft.MessageMode.PTP
			}
		});
		this.sandbox.subscribe("UpdateSuggestions", this._onUpdateSuggestions, this);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onPolylinePointPositionsChanged
	 * @override
	 */
	onPolylinePointPositionsChanged: function(connectors) {
		this.callParent(arguments);
		Terrasoft.each(connectors, function(connector) {
			if (connector.portPositions) {
				const sequenceFlow = this.getItemByName(connector.name);
				this.setPortPosition(connector, sequenceFlow);
			}
		}, this);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onConnectorsNodesChange
	 * @override
	 */
	onConnectorsNodesChange: function(connectors) {
		Terrasoft.each(connectors, function(connector) {
			const sequenceFlow = this.getItemByName(connector.name);
			if (connector.source) {
				sequenceFlow.setSourceRef(connector.source);
			}
			if (connector.target) {
				sequenceFlow.setTargetRef(connector.target);
			}
		}, this);
		this.clearSearchResult();
	},

	/**
	 * Returns element manager item for specified diagram element type.
	 * @protected
	 * @param {String} typeName Diagram element type name.
	 * @returns {Terrasoft.ProcessFlowElementSchemaManagerItem} Element schema manager item.
	 */
	getFlowElementSchemaManagerItemByTypeName: function(typeName) {
		const items = this.elementSchemaManager.getItems().getItems();
		let item = items.find(function(schema) {
			const instance = schema.instance;
			const type = this.toDiagramType(instance);
			if (!type) {
				return false;
			}
			const name = type === "userTask" ? instance.name : type;
			return Terrasoft.toLowerCamelCase(name) === typeName;
		}, this);
		if (!item) {
			item = this.elementSchemaManager.getItemByType(this._getCoreProcessSchemaName(typeName));
		}
		return item;
	},

	/**
	 * Returns schema element class name for diagram item.
	 * @protected
	 * @param {Object} diagramItem Diagram element config.
	 * @returns {String} Schema element class name.
	 */
	getClassName: function(diagramItem) {
		return (_.invert(Terrasoft.ProcessDiagramTypesEnum))[diagramItem.type];
	},

	/**
	 * Returns new flow based on connector config.
	 * @protected
	 * @param {Object} connection Connection config to create.
	 * @returns {Terrasoft.ProcessSequenceFlowSchema} New flow.
	 */
	createFlow: function(connection) {
		return this._internalCreateFlow(connection);
	},

	/**
	 * Applies sequence flow ports positions.
	 * @protected
	 * @param {Object} connector Connection config to create.
	 * @param {Object} sequenceFlow Connection instance.
	 */
	setPortPosition(connector, sequenceFlow) {
		const sourcePoint = connector.portPositions.source;
		const targetPoint = connector.portPositions.target;
		sequenceFlow.setSourcePortPositionByPoints(sourcePoint);
		sequenceFlow.setTargetPortPositionByPoints(targetPoint);
		sequenceFlow.endPoint = targetPoint.position;
		sequenceFlow.startPoint = sourcePoint.position;
	},

	/**
	 * Get is current diagram has enabled suggestions for elements.
	 * @protected
	 */
	getIsSuggestionsEnabled: function() {
		return !Terrasoft.Features.getIsEnabled("DisableProcessAISuggestions");
	},

	// endregion

	// region Methods: Public

	/**
	 * @inheritdoc Terrasoft.model.BaseViewModel#constructor
	 * @override
	 */
	constructor: function() {
		this._cachedSuggestionsMap = new Map();
		this.callParent(arguments);
		this.addEvents(
			/**
			 * @event click
			 * Triggers when a click on element.
			 */
			"click",
			/**
			 * @event itemCenterViewBox
			 * Triggers when item center on view box.
			 */
			"itemCenterViewBox",
			/**
			 * @event itemMarkersChanged
			 * Triggers when changed item markers.
			 */
			"itemMarkersChanged"
		);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#init
	 * @override
	 */
	init: function() {
		this.callParent(arguments);
		const suggestionsEnabled = this.getIsSuggestionsEnabled();
		this.set("SuggestionsEnabled", suggestionsEnabled);
		if (suggestionsEnabled) {
			this._setDefaultSuggestionsSettings();
			this._setMLSequenceElementsCountForPredictionSettings();
			const autoOpenSuggestionsPopup = this._getIsAutoOpenSuggestionsPopupEnabled();
			this.set("AutoOpenSuggestionsPopup", autoOpenSuggestionsPopup);
		}
		this.set("DiagramConfig", this.getDiagramConfig());
	},

	/**
	 * @inheritdoc Terrasoft.BaseModel#getModelColumns
	 * @override
	 */
	getModelColumns: function() {
		const columns = this.callParent(arguments);
		columns.DiagramConfig = {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
		};
		columns.ImportData = {
			type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
			dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
		};
		return columns;
	},

	/**
	 * Handler for selected import file upload.
	 * @param {files} files Uploaded files.
	 */
	onBpmnFileSelected: function(files) {
		const file = files[0];
		const reader = new FileReader();
		reader.readAsText(file);
		reader.onload = function() {
			this.onDiagramImportStart();
			this.set("ImportData", reader.result);
			this._clearImportData();
		}.bind(this);
	},

	/**
	 * Handler for connector item created.
	 * @param {Object} connector New connector config.
	 */
	onConnectorCreate: function(connector) {
		if (!connector) {
			return;
		}
		const sequenceFlow = this.createFlow(connector);
		const items = this.get("Items");
		items.add(sequenceFlow.name, sequenceFlow);
		this.fireEvent("itemCaptionChanged", sequenceFlow);
		this.loadPropertiesPage(sequenceFlow.name);
		this.clearSearchResult();
	},

	/**
	 * Handler for connection type change.
	 * @param {Object} connection type change config.
	 */
	onConnectorChangingType: function({connections, next}) {
		const schema = this.get("Schema");
		Terrasoft.each(connections, (connection) => {
			const oldConnection = schema.findItemByName(connection.name);
			const canRemove = this._validateRemove([oldConnection.name]);
			if (!canRemove) {
				return false;
			}
			const items = this.get("Items");
			const newConnectionConfig = {
				id: oldConnection.uId,
				type: connection.type,
				source: oldConnection.sourceRefUId,
				target: oldConnection.targetRefUId,
				polylinePointPositions: oldConnection.polylinePointPositions,
				sourceSequenceFlowPointLocalPosition: oldConnection.sourceSequenceFlowPointLocalPosition,
				targetSequenceFlowPointLocalPosition: oldConnection.targetSequenceFlowPointLocalPosition
			};
			const newConnection = this.createFlow(newConnectionConfig);
			const caption = oldConnection.caption;
			newConnection.caption = caption;
			items.replace(oldConnection, newConnection, newConnection.name);
			next({id: oldConnection.uId, name: newConnection.name, caption: caption.getValue()});
			const selectedConnection = this.$SelectedItemName === oldConnection.name
				? newConnection.name
				: this.$SelectedItemName;
			this.onItemSelected(selectedConnection);
		});
	},

	/**
	 * Handler for create item.
	 * @param {Object} itemConfig New item config.
	 */
	onItemCreate: function(itemConfig) {
		if (!itemConfig) {
			return;
		}
		let item;
		if (itemConfig.nodeType === Terrasoft.diagram.UserHandlesConstraint.Label) {
			item = this._createLabel(itemConfig);
		} else {
			item = this._createElement(itemConfig);
		}
		this.$Items.add(item.name, item);
		if (item.parent) {
			const parent = this.$Items.findByPath("name", item.parent);
			if (parent.typeName === "Terrasoft.Core.Process.ProcessSchemaEventSubProcess" &&
				item.typeName === "Terrasoft.Core.Process.ProcessSchemaStartSignalEvent") {
				this.onDiagramClick({element: {name: parent.name}});
			}
		}
	},

	/**
	 * @override
	 */
	onItemsRemoved: function({ids}) {
		if (ids.length === 0) {
			return;
		}
		const itemNameList = this._getElementNameList(ids);
		const schema = this.get("Schema");
		const items = this.get("Items");
		itemNameList.forEach((name) => {
			const item = schema.findItemByName(name);
			items.remove(item);
		});
	},

	/**
	 * @override
	 */
	onItemsRemoving: async function({ids, next, cancel}) {
		if (ids.length === 0) {
			return;
		}
		const itemNameList = this._getElementNameList(ids);
		const canRemove = await this._validateRemove(itemNameList);
		if (!canRemove) {
			cancel();
			return;
		}
		next();
	},

	/**
	 * Event handler validate updating item type.
	 * @protected
	 * @param {String} id Diagram element.
	 * @param {Function} next Callback function.
	 */
	onItemValidateUpdatingType: async function(id, next) {
		const schema = this.get("Schema");
		const item = schema.findItemByUId(id);
		const canRemove = await this._validateRemove([item.name]);
		if (!canRemove) {
			return;
		}
		next();
	},

	/**
	 * Event handler item type updated.
	 * @protected
	 * @param {Object} element Diagram element.
	 * @param {Function} next Callback function.
	 */
	onItemTypeUpdated: function(element, next) {
		const schema = this.get("Schema");
		const item = schema.findItemByUId(element.id);
		const items = this.get("Items");
		const newItem = this._createElement({
			id: element.id,
			position: item.position,
			type: element.userTaskType,
			size: {
				width: element.width,
				height: element.height
			},
			parent: item.containerUId
		});
		newItem.caption = item.caption;
		const name = newItem.name;
		items.replace(item, newItem, name);
		this.onItemSelected(name);
		next(name);
	},

	/**
	 * Event handler for item selected.
	 * @param {String} [name] Item name.
	 */
	onItemSelected: function(name) {
		this.$SelectedItemName = name;
		this._loadButtonPropertiesPageByName(name);
	},

	/**
	 * Event handler for click on item suggestions.
	 * @param {String} [name] Item name.
	 */
	onItemSuggestionsClick: function(name) {
		const config = this.sandbox.publish("GetElementEntityConfigForSuggestions");
		if (config && config.elementName === name && config.predictionParams) {
			this._processSuggestions(name, config.predictionParams);
		} else {
			this._processSuggestions(name);
		}
	},

	/**
	 * Event handler of open properties page.
	 * @param {String} [name] Item name.
	 */
	onOpenPropertyPage: function(name) {
		if (this.get("IsShowPropertyPage")) {
			return;
		}
		this.set("IsShowPropertyPage", true);
		this._loadButtonPropertiesPageByName(name);
	},

	/**
	 * @inheritdoc Terrasoft.ProcessSchemaDesignerViewModel#onItemsContainerChanged
	 * @override
	 */
	onItemsContainerChanged: function(element) {
		const itemName = element.itemName;
		const containerName = this._getContainerName(element.parent);
		const schema = this.get("Schema");
		schema.changeItemContainer(itemName, containerName);
		this.clearSearchResult();
	},

	/**
	 * Returns item copy to provide paste action.
	 * @protected
	 * @param {Terrasoft.BaseProcessSchemaElement} sourceItem Source item for copy.
	 * @param {Object} element Pasted diagram element.
	 * @returns {Terrasoft.BaseProcessSchemaElement} Item copy.
	 */
	createItemCopy: function(sourceItem, element) {
		const item = this.mixins.ProcessSchemaDesignerCopyMixin.createItemCopy.call(this, sourceItem);
		item.uId = element.id;
		this._setItemParent(element.parentId, item);
		item.caption = new Terrasoft.LocalizableString(element.caption);
		item.position = {
			X: element.position.x,
			Y: element.position.y
		};
		return item;
	},

	/**
	 * @override
	 */
	pasteElement: function(element) {
		const sourceItem = this.$Items.findByFn((el) => el.uId === element.sourceId);
		const item = this.createItemCopy(sourceItem, element);
		this.$Items.add(item.name, item);
		this.cloneParameters(item, sourceItem);
	},

	/**
	 * @override
	 */
	clearElementPropertyPage: function(item) {
		if (this.$SelectedItemName === item.name) {
			this.callParent(arguments);
		}
	},

	/**
	 * Event handler of can copy elements.
	 * @param {Array} elements Copying elements.
	 */
	onUpdateStudioFreeDiagramUrl: function(url) {
		const schema = this.get("Schema");
		schema.setPropertyValue("studioFreeProcessUrl", url);
	},

	/**
	 * Event handler of can copy elements.
	 * @param {Array} elements Copying elements.
	 */
	onCanCopy: function(elements) {
		const schema = this.get("Schema");
		return elements.every((item) => {
			const element = schema.findItemByUId(item.id);
			const hasLazyParameters = element && element.hasLazyParameters;
			const hasAllLazyParametersLoaded = hasLazyParameters && element.getAllLazyParametersAreLoaded();
			return !hasLazyParameters || hasAllLazyParametersLoaded;
		});
	},

	/**
	 * Event handler of import error.
	 */
	onImportError() {
		this.showInformationDialog(Terrasoft.Resources.ProcessSchemaDesigner.Messages.ProcessImportError);
	},

	/***
	 * Handler for BPMN file import, to clear existing process schema parameter mappings.
	 */
	onDiagramImportStart() {
		this.onHidePropertyPage();
		this.$Schema.clearSchemaMappings();
		this.setVisiblePropertyPage(true);
	}

	// endregion

});

