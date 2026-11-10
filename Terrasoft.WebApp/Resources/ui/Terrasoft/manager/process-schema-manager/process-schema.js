/**
 */
Ext.define("Terrasoft.manager.ProcessSchema", {
	extend: "Terrasoft.manager.BaseProcessSchema",
	alternateClassName: "Terrasoft.ProcessSchema",

	// region Properties: Protected

	/**
	 * Name of the manager for accessing process elements.
	 * @protected
	 * @type {String}
	 */
	elementSchemaManagerName: "ProcessFlowElementSchemaManager",

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#contractName
	 * @override
	 */
	contractName: "ContractProcessSchema",

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#managerName
	 * @override
	 */
	managerName: "ProcessSchemaManager",

	/**
	 * Schema methods.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	methods: null,

	/**
	 * Default link color.
	 * @protected
	 * @type {String}
	 */
	sequenceFlowStrokeDefColor: "FFBBBBBB",

	/**
	 * The default fill color.
	 * @protected
	 * @type {String}
	 */
	taskFillDefColor: "FFFFFFFF",

	/**
	 * The usings collection is used for compatibility with the old designer.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	usings: null,

	/**
	 *Associations.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	associations: null,

	/**
	 * The metadata of the process created in the fast designer.
	 * @protected
	 * @type {String}
	 */
	quickModelData: null,

	/**
	 * The schema ID in which the element was created.
	 * @protected
	 * @type {String}
	 */
	createdInSchemaUId: null,

	/**
	 * The schema ID in which the element was changed.
	 * @protected
	 * @type {String}
	 */
	modifiedInSchemaUId: null,

	/**
	 * The identifier of the package in which the item was created.
	 * @protected
	 * @type {String}
	 */
	createdInPackageId: null,

	/**
	 * Group.
	 * @protected
	 * @type {Terrasoft.ObjectCollection}
	 */
	group: null,

	/**
	 * Object unique Id.
	 * @protected
	 * @type {String}
	 */
	entitySchemaUId: null,

	/**
	 * Flag of the state of the chart display.
	 * @protected
	 * @type {Boolean}
	 */
	isExpanded: false,

	/**
	 * A flag whether the scheme was created in the new designer.
	 * @protected
	 * @type {Boolean}
	 */
	isCreatedInSvg: false,

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#typeName
	 * @override
	 */
	typeName: "Terrasoft.Core.Process.ProcessSchema",

	/**
	 * Mode of using the process.
	 * @protected
	 * @type {Terrasoft.ProcessSchemaUsageType}
	 */
	usageType: Terrasoft.ProcessSchemaUsageType.ADVANCED,

	/**
	 * Unique Id for the parameters page.
	 * @protected
	 * @type {String}
	 */
	parametersEditPageSchemaUId: null,

	/**
	 * Tag.
	 * @protected
	 * @type {String}
	 */
	tag: null,

	/**
	 * Localized strings.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	localizableStrings: null,

	/**
	 * Pools.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	laneSets: null,

	/**
	 * Tracks.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	lanes: null,

	/**
	 * Artifacts.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	artifacts: null,

	/**
	 * The execution context.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	executionContexts: null,

	/**
	 * Coordinates for broken threads.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	polylinePointPositions: null,

	/**
	 * Parameters of process elements.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	flowElementsParameters: null,

	/**
	 * A flag of the process created by the master.
	 * @protected
	 * @type {Boolean}
	 */
	isQuickModel: false,

	/**
	 * A flag of the built-in object process.
	 * @protected
	 * @type {Boolean}
	 */
	isEmbedded: false,

	/**
	 * Culture name.
	 * @protected
	 * @type {String}
	 */
	cultureName: null,

	/**
	 * A flag of the interpreted process.
	 * @protected
	 * @type {Boolean}
	 */
	isInterpretable: false,

	/**
	 * Elements of inherited processes.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	inheritedElements: null,

	/**
	 * A flag of compulsory compilation of a process schema.
	 * @protected
	 * @type {Boolean}
	 */
	useForceCompile: false,

	/**
	 * Source of process methods designed by user.
	 * @protected
	 * @type {String}
	 */
	methodsBody: "",

	/**
	 * Source of compiled process methods designed by user.
	 * @protected
	 * @type {String}
	 */
	compiledMethodsBody: "",

	/**
	 * List of process properties that require compilation.
	 * @protected
	 * @type {Terrasoft.Collection}
	 */
	validatorInfo: null,

	/**
	 * Validator message.
	 * @protected
	 * @type {String}
	 */
	validatorMessage: "",

	/**
	 * The name of the image resource manager.
	 * @protected
	 * @type {String}
	 */
	resourceManagerName: "Terrasoft.Nui",

	/**
	 * The name of the image resource in the header of the property page.
	 * @protected
	 * @type {String}
	 */
	titleImageName: "process_title.svg",

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#typeCaption
	 * @override
	 */
	typeCaption: Terrasoft.Resources.ProcessSchemaDesigner.TypeCaption,

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#color
	 * @override
	 */
	color: "#00AEEF",

	/**
	 * Process schema changed items. Uses to check for compilation.
	 * @type {Object}
	 */
	changedItems: null,

	/**
	 * The labels collection.
	 * @protected
	 * @type {Terrasoft.Collection | String}
	 */
	labels: null,

	// endregion

	// region Constructors: Public

	/**
	 * @inheritdoc Terrasoft.manager.BaseObject#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		this.changedItems = {};
		this.inheritedElements = Ext.create("Terrasoft.Collection");
		this.initMappings();
		this.initLaneSets();
		this.initFlowElements();
		this._initLabels();
		this.initUsings();
		this.synchronizeDynamicParameters();
	},

	// endregion

	// region Methods: Private

	/**
	 * Initialize process pools.
	 * @private
	 */
	initLaneSets: function() {
		const laneSetsMetaData = this.laneSets || [];
		const laneSets = this.laneSets = Ext.create("Terrasoft.Collection");
		const lanes = this.lanes = Ext.create("Terrasoft.Collection");
		laneSetsMetaData.forEach(function(laneSetMetaData) {
			if (laneSetMetaData.createdInSchemaUId !== this.uId) {
				this.inheritedElements.add(laneSetMetaData.name, laneSetMetaData);
				return;
			}
			const laneSet = this.createItemInstance(laneSetMetaData);
			laneSets.add(laneSet.name, laneSet);
			laneSet.lanes.each(function(lane) {
				lane.parentSchema = this;
				lanes.add(lane.name, lane);
			}, this);
		}, this);
	},

	/**
	 * Initialize flow elements.
	 * @private
	 */
	initFlowElements: function() {
		const flowElementsMetaData = this.flowElements || [];
		const flowElements = this.flowElements = Ext.create("Terrasoft.Collection");
		flowElementsMetaData.forEach(function(flowElementMetaData) {
			if (flowElementMetaData.createdInSchemaUId !== this.uId) {
				this.addInheritedElements(flowElementMetaData);
				return;
			}
			flowElementMetaData = Terrasoft.deepClone(flowElementMetaData);
			flowElementMetaData.parentSchema = this;
			const flowElement = this.createItemInstance(flowElementMetaData);
			const parent = this._findParent(flowElement, flowElementsMetaData);
			flowElement.parent = parent ? parent.name : null;
			flowElements.add(flowElement.name, flowElement);
		}, this);
	},

	/**
	 * @private
	 */
	_findParent: function(element, metaItems) {
		return this.findItemLane(element)
			|| (this._isBoundaryElementInRoot(element)
				? this.findItemByUId(element.attachedToElementUId)
					|| this._findItemInMetaItems(element.attachedToElementUId, metaItems)
				: null);
	},

	/**
	 * @private
	 */
	_findItemInMetaItems: function(uId, metaItems) {
		const filterFunction = function(item) {
			return item.uId === uId;
		};
		let result = metaItems.filter(filterFunction);
		return result[0];
	},

	/**
	 * @private
	 */
	_initLabels: function() {
		const labelsMetaData = this.labels ? this.labels : [];
		const labels = this.labels = Ext.create("Terrasoft.Collection");
		labelsMetaData.forEach((labelMetaData) => {
			if (labelMetaData.createdInSchemaUId !== this.uId) {
				this.addInheritedElements(labelMetaData, "labels");
				return;
			}
			labelMetaData = Terrasoft.deepClone(labelMetaData);
			const label = this.createLabel(labelMetaData);
			labels.add(label.name, label);
		});
	},

	/**
	 * Returns new instance of process label.
	 * @protected
	 * @param {Object} config Label metadata.
	 * @returns {Terrasoft.ProcessLabelSchema}
	 */
	createLabel: function(config) {
		return new Terrasoft.ProcessLabelSchema(config);
	},

	/**
	 * Initializes collection of using.
	 * @private
	 */
	initUsings: function() {
		const usingsMetaData = this.usings || [];
		const usings = this.usings = Ext.create("Terrasoft.Collection");
		usingsMetaData.forEach(function(usingMetaData) {
			if (usingMetaData.createdInSchemaUId === this.uId) {
				const using = Ext.create("Terrasoft.SchemaUsing", usingMetaData);
				usings.add(using.uId, using);
			}
		}, this);
	},

	/**
	 * Adds inherited elements to collections.
	 * @param {Object} metaData Meta data of flow element.
	 */
	addInheritedElements: function(metaData, collectionName = "flowElements") {
		const key = metaData.name;
		const inheritedElements = this.inheritedElements;
		if (inheritedElements.contains(key)) {
			return;
		}
		inheritedElements.add(key, metaData);
		const items = metaData[collectionName];
		if (items) {
			items.forEach(function(item) {
				this.addInheritedElements(item, collectionName);
			}, this);
		}
	},

	/**
	 * Fix items positions for process created in old designer in 5.x version.
	 * @param {Object} container Process schema container.
	 */
	fixPositionInContainer: function(container) {
		const flowElements = this.flowElements.filterByFn(function(flowElement) {
			return flowElement.containerUId === container.uId;
		});
		if (flowElements.getCount() === 0) {
			return;
		}
		flowElements.each(function(flowElement) {
			if (flowElement.isContainer && flowElement.isExpanded) {
				this.fixPositionInContainer(flowElement);
			}
		}, this);
		flowElements.sortByFn(function(item1, item2) {
			return item1.position.X - item2.position.X;
		});
		const lastRightElement = flowElements.getByIndex(flowElements.getCount() - 1);
		const diffX = lastRightElement.position.X + lastRightElement.width;
		flowElements.sortByFn(function(item1, item2) {
			return item1.position.Y - item2.position.Y;
		});
		const lastBottomElement = flowElements.getByIndex(flowElements.getCount() - 1);
		const diffY = lastBottomElement.position.Y + lastBottomElement.height + 18;
		container.width = container.width || 0;
		container.height = container.height || 0;
		if (container.width < diffX) {
			container.width = diffX;
		}
		if (container.height < diffY) {
			container.height = diffY;
		}
		if (container.nodeType === Terrasoft.diagram.UserHandlesConstraint.Lane) {
			// Change the relative coordinates of the element to absolute
			flowElements.each(function(flowElement) {
				flowElement.position.Y += container.position.Y;
			}, this);
		}
	},

	/**
	 * Returns Lane of passed flow item.
	 * @param {Terrasoft.ProcessFlowElementSchema} flowElement Process item.
	 * @private
	 * @return {Terrasoft.ProcessLaneSchema|null} Process lane.
	 */
	findItemLane: function(flowElement) {
		if (flowElement.nodeType === Terrasoft.diagram.UserHandlesConstraint.Lane) {
			return null;
		}
		const filteredCollection = this.lanes.filterByFn(function(lane) {
			return lane.uId === flowElement.containerUId;
		});
		if (filteredCollection.getCount() === 0) {
			return null;
		}
		return filteredCollection.getByIndex(0);
	},

	/**
	 * Process schema changed event handler. Checks changes of methodsBody and compiledMethodsBody properties.
	 * If this properties changed, register changes for compilation.
	 * @param {Object} changes Key-value pair of changes.
	 * @private
	 */
	onSchemaChanged: function(changes) {
		const itemUId = Terrasoft.generateGUID();
		const changeAction = Terrasoft.process.constants.ITEM_CHANGE_ACTION.MODIFY;
		const resources = Terrasoft.Resources.ProcessSchemaDesigner.Messages;
		if (changes.hasOwnProperty("methodsBody")) {
			this.addSchemaChangedItem(itemUId, resources.ProcessSchemaMethodsBodyCaption || "methodsBody", changeAction);
		}
		if (changes.hasOwnProperty("compiledMethodsBody")) {
			this.addSchemaChangedItem(itemUId,
				resources.CompiledProcessSchemaMethodsBodyCaption || "compiledMethodsBody", changeAction);
		}
	},

	/**
	 * Finds Formula Tasks that are linked with the parameter.
	 * @private
	 * @param {Terrasoft.ProcessSchemaParameter} sourceParameter Parameter.
	 * @param {Terrasoft.ProcessFlowElementSchema} formulaTask Flow element.
	 * @return {Object|null}.
	 */
	findLinkToFormulaTasks: function(sourceParameter, formulaTask) {
		if (!(formulaTask instanceof Terrasoft.ProcessFormulaTaskSchema)) {
			return null;
		}
		if (this._getIsDependentFormulaTaskFromParameter(formulaTask, sourceParameter)) {
			return {
				sourceParameter: sourceParameter,
				dependentElement: formulaTask
			};
		}
		return null;
	},

	/**
	 * @private
	 */
	_getIsDependentFormulaTaskFromParameter: function(formulaTask, parameter) {
		const body = formulaTask.body;
		let result = false;
		if (body) {
			const resultParameter = formulaTask.resultParameterMetaPath;
			const parameterUId = parameter.uId;
			if (this.getIsProcessSchemaParameter(parameter)) {
				result = Terrasoft.includes(body, parameterUId);
				if (!result && resultParameter) {
					result = Terrasoft.includes(resultParameter, parameterUId);
				}
			} else {
				const element = parameter.processFlowElementSchema;
				const elementUId = element.uId;
				const template = Terrasoft.process.constants.PARAMETER_METAPATH_TEMPLATE;
				const bodyMetaPath = Ext.String.format(template, elementUId, parameterUId);
				result = Terrasoft.includes(body, bodyMetaPath);
				if (!result && resultParameter) {
					const resultParameterMetaPath = Ext.String.format("{0}.{1}", elementUId, parameterUId);
					result = Terrasoft.includes(resultParameter, resultParameterMetaPath);
				}
			}
		}
		return result;
	},

	/**
	 * Finds Conditional Flows that are linked with the parameter.
	 * @private
	 * @param {Terrasoft.ProcessSchemaParameter} sourceParameter Parameter.
	 * @param {Terrasoft.ProcessFlowElementSchema} conditionalFlow Flow element.
	 * @param {Array} excludedElementsNames Array of element names are excluded from the search.
	 * @return {Object|null}.
	 */
	findLinkToConditionalFlow: function(sourceParameter, conditionalFlow, excludedElementsNames) {
		if (!(conditionalFlow instanceof Terrasoft.ProcessConditionalSequenceFlowSchema)) {
			return null;
		}
		const sourceElement = conditionalFlow.findSourceElement();
		const targetElement = conditionalFlow.findTargetElement();
		if (excludedElementsNames && (excludedElementsNames.indexOf(sourceElement.name) > -1 ||
			excludedElementsNames.indexOf(targetElement.name) > -1)) {
			return;
		}
		const conditionExpression = conditionalFlow.conditionExpression;
		if (conditionExpression && this._getIsConditionalFlowDependentOnParameter(conditionExpression,
				sourceParameter)) {
			return {
				sourceParameter: sourceParameter,
				dependentElement: conditionalFlow
			};
		}
		return null;
	},

	/**
	 * Checks whether the condition expression references the given parameter.
	 * When the element-scoped check is active (default), element-level parameters are matched
	 * by their full metapath ([Element:{elementUId}].[Parameter:{parameterUId}]) to avoid
	 * false positives when different elements share the same column parameter UId.
	 * @private
	 * @param {String} conditionExpression Conditional flow expression.
	 * @param {Terrasoft.ProcessSchemaParameter} parameter Source parameter.
	 * @return {Boolean}
	 */
	_getIsConditionalFlowDependentOnParameter: function(conditionExpression, parameter) {
		if (Terrasoft.Features.getIsEnabled("DisableElementScopedConditionalFlowCheck")) {
			return conditionExpression.indexOf(parameter.uId) > -1;
		}
		if (this.getIsProcessSchemaParameter(parameter)) {
			return conditionExpression.indexOf(parameter.uId) > -1;
		}
		const element = parameter.processFlowElementSchema;
		const template = Terrasoft.process.constants.PARAMETER_METAPATH_TEMPLATE;
		const metaPath = Ext.String.format(template, element.uId, parameter.uId);
		return conditionExpression.indexOf(metaPath) > -1;
	},

	/**
	 * @private
	 */
	_isVersionSupported: function(version) {
		const trunkAppVersion = "0.0.0.0";
		const createdInAppVersion = "7.7.0.0";
		if (Ext.isEmpty(version)) {
			return true;
		}
		if (version === trunkAppVersion) {
			return true;
		}
		const schemaVersionParts = version.split(".");
		const createdInAppVersionParts = createdInAppVersion.split(".");
		for (let i = 0; i < schemaVersionParts.length; i++) {
			const schemaVersionPart = Number(schemaVersionParts[i]);
			const createdInAppVersionPart = Number(createdInAppVersionParts[i]);
			if (schemaVersionPart < createdInAppVersionPart) {
				return false;
			}
			if (schemaVersionPart > createdInAppVersionPart) {
				break;
			}
		}
		return true;
	},

	/**
	 * @private
	 */
	_getSerializableLabels: function() {
		const nodes = [];
		this.labels.each((label) => {
			if (!Terrasoft.isNull(label.x) || !Terrasoft.isNull(label.y)) {
				const metaData = this.getSerializableProperty(label);
				nodes.push(metaData);
			}
		});
		return nodes;
	},

	/**
	 * @private
	 */
	_isBoundaryElementInRoot: function(element) {
		return Terrasoft.ProcessBoundaryEventTypes.includes(element.unsupportedType);
	},

	/**
	 * @private
	 */
	_getMultiInstanceElements: function() {
		return this.flowElements.filterByFn(element => element.getIsMultiInstanceSupported &&
			element.getIsMultiInstanceModeEnabled(), this);
	},

	// endregion

	// region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.BaseSchema#initEvents
	 * @protected
	 * @override
	 */
	initEvents: function() {
		this.on("changed", this.onSchemaChanged, this);
	},

	/**
	 * @inheritdoc Terrasoft.manager.mixins.ParametrizedProcessSchemaElement#getCanAssignParameterSourceValue
	 * @override
	 */
	getCanAssignParameterSourceValue(_) {
		return true;
	},

	/**
	 * Checks item changes by uId.
	 * @param {String} itemUId Item identifier.
	 * @param {Terrasoft.process.constants.ITEM_CHANGE_ACTION} action Change action to check.
	 * @return {Boolean} True if changes for item registered, else false.
	 */
	isItemChangesRegistered: function(itemUId, action) {
		const changedItems = this.changedItems;
		const itemChanges = changedItems[itemUId];
		if (!itemChanges) {
			return false;
		}
		return itemChanges.action === action;
	},

	/**
	 * Deletes changes for item by uId
	 * @param {String} itemUId Item identifier.
	 */
	deleteItemChanges: function(itemUId) {
		delete this.changedItems[itemUId];
	},

	/**
	 * Deletes registration of all changes for process schema.
	 */
	deleteSchemaChanges: function() {
		this.changedItems = {};
	},

	/**
	 * Register changes for item by uId.
	 * @param {String} itemUId Item identifier.
	 * @param {String} caption Caption to display.
	 * @param {Terrasoft.process.constants.ITEM_CHANGE_ACTION} action Change action.
	 */
	addSchemaChangedItem: function(itemUId, caption, action) {
		const changedItems = this.changedItems;
		let changedItem = changedItems[itemUId];
		if (!changedItem) {
			changedItem = changedItems[itemUId] = {};
			changedItem.action = action;
			changedItem.caption = caption;
		}
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#getEditPageSchemaName
	 * @override
	 */
	getEditPageSchemaName: function(callback, scope) {
		callback.call(scope, "ProcessSchemaPropertiesPage");
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#getSerializableObject
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.isCreatedInSvg = this.getSerializableProperty(true);
		this.setSerializableCollectionProperty(serializableObject, "usings");
		this.setSerializableCollectionProperty(serializableObject, "mappings");
		serializableObject.laneSets = this.getSerializableLaneSets();
		serializableObject.flowElements = this.getSerializableFlowElements();
		serializableObject.labels = this._getSerializableLabels();
		this.mixins.parametrizedProcessSchemaElement.getSerializableObject.apply(this, arguments);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		const baseSerializableProperties = this.callParent(arguments);
		const serializableProperties = Ext.Array.push(baseSerializableProperties, ["createdInSchemaUId",
			"modifiedInSchemaUId", "createdInPackageId", "methods", "localizableStrings", "createdInVersion",
			"taskFillDefColor", "sequenceFlowStrokeDefColor", "artifacts", "associations", "isExpanded",
			"usageType", "parametersEditPageSchemaUId", "tag", "entitySchemaUId", "cultureName", "executionContexts",
			"isEmbedded", "isInterpretable", "useForceCompile", "methodsBody", "compiledMethodsBody"]);
		return serializableProperties;
	},

	/**
	 * Copies laneSets collection to serializableObject.
	 * @private
	 */
	getSerializableLaneSets: function() {
		return this.laneSets.mapArray((laneSet) => this.getSerializableProperty(laneSet), this);
	},

	/**
	 * Returns FlowElement collection serializable object sorted by element type.
	 * @protected
	 */
	getSerializableFlowElements: function() {
		const nodes = [];
		const connectors = [];
		this.flowElements.each(function(flowElement) {
			const container = this.findItemByUId(flowElement.containerUId) || {};
			if (!this.flowElements.contains(container.name)) {
				const flowElementMetaData = this.getSerializableProperty(flowElement);
				if (flowElement.nodeType === Terrasoft.diagram.UserHandlesConstraint.Connector) {
					connectors.push(flowElementMetaData);
				} else {
					nodes.push(flowElementMetaData);
				}
			}
			if (this._isBoundaryElementInRoot(flowElement)) {
				nodes.push(this.getSerializableProperty(flowElement));
			}
		}, this);
		return nodes.concat(connectors);
	},


	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#loadLocalizableValues
	 * @override
	 */
	loadLocalizableValues: function(localizableValues) {
		if (!localizableValues) {
			return;
		}
		if (localizableValues.EventsProcessSchema) {
			localizableValues = localizableValues.EventsProcessSchema;
		}
		this.callParent(arguments);
		const laneSetsLocalizableValues = localizableValues.LaneSets || {};
		this.laneSets.each(function(laneSet) {
			const laneSetLocalizableValues = laneSetsLocalizableValues[laneSet.name];
			laneSet.loadLocalizableValues(laneSetLocalizableValues);
		}, this);
		const flowElementsLocalizableValues = localizableValues.BaseElements || {};
		this.flowElements.each(function(flowElement) {
			const flowElementLocalizableValues = flowElementsLocalizableValues[flowElement.name];
			flowElement.loadLocalizableValues(flowElementLocalizableValues);
		}, this);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#loadLocalizableValuesByUIds
	 * @override
	 */
	loadLocalizableValuesByUIds: function(localizableValues) {
		this.callParent(arguments);
		if (!localizableValues) {
			return;
		}
		this.laneSets.each(function(laneSet) {
			laneSet.loadLocalizableValuesByUIds(localizableValues);
		}, this);
		this.flowElements.each(function(flowElement) {
			flowElement.loadLocalizableValuesByUIds(localizableValues);
		}, this);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#getLocalizableValues
	 * @override
	 */
	getLocalizableValues: function(localizableValues) {
		this.callParent(arguments);
		this.laneSets.each(function(laneSet) {
			laneSet.getLocalizableValues(localizableValues);
		}, this);
		this.flowElements.each(function(flowElement) {
			flowElement.getLocalizableValues(localizableValues);
		}, this);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#getTitleImage
	 * @override
	 */
	getTitleImage: function() {
		return {
			source: Terrasoft.ImageSources.RESOURCE_MANAGER,
			params: {
				resourceManagerName: this.resourceManagerName,
				resourceItemName: "ProcessSchemaDesigner." + this.titleImageName
			}
		};
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#collectItemsValidationResults
	 * @override
	 */
	collectItemsValidationResults: function(validationInfo) {
		this.collectValidationResults(this.laneSets, validationInfo);
		this.collectValidationResults(this.lanes, validationInfo);
		this.collectValidationResults(this.flowElements, validationInfo);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#getFlowElements
	 * @override
	 */
	getFlowElements: function() {
		return this.flowElements;
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#findLinksToFlowElement
	 * @override
	 */
	findLinksToFlowElement: function(sourceParameter, excludedElementsNames) {
		const links = this.callParent(arguments);
		this.flowElements.each(function(flowElement) {
			if (excludedElementsNames && excludedElementsNames.indexOf(flowElement.name) > -1) {
				return;
			}
			const linkFormula = this.findLinkToFormulaTasks(sourceParameter, flowElement);
			if (linkFormula) {
				links.push(linkFormula);
				return;
			}
			const linkConditionalFlow = this.findLinkToConditionalFlow(sourceParameter, flowElement, excludedElementsNames);
			if (linkConditionalFlow) {
				links.push(linkConditionalFlow);
			}
		}, this);
		return links;
	},

	// endregion

	// region Methods: Public

	/**
	 * Returns instance by item configuration.
	 * @param {Object} item Item configuration.
	 * @return {Terrasoft.ProcessBaseElementSchema} Process schema item instance.
	 */
	createItemInstance: function(item) {
		const managerItemUId = item.managerItemUId ? item.managerItemUId : item.uId;
		return Terrasoft[this.elementSchemaManagerName].createInstance(managerItemUId, item);
	},

	/**
	 * Adds item to schema.
	 * @param {Terrasoft.manager.ProcessFlowElementSchema} item Item to add.
	 * @throws Terrasoft.ItemAlreadyExistsException If schema contains item with same key, generates exception.
	 */
	add: function(item) {
		const itemName = item.name;
		if (this.contains(itemName)) {
			throw new Terrasoft.ItemAlreadyExistsException();
		}
		switch (true) {
			case item instanceof Terrasoft.ProcessLaneSetSchema:
				this.laneSets.add(item.name, item);
				break;
			case item instanceof Terrasoft.ProcessLaneSchema: {
				const laneSet = this.findItemByUId(item.containerUId);
				item.laneSetUId = item.containerUId;
				item.parent = laneSet;
				laneSet.lanes.add(item.name, item);
				this.lanes.add(item.name, item);
				break;
			}
			case item instanceof Terrasoft.ProcessSequenceFlowSchema:
				this.flowElements.add(item.name, item);
				break;
			case item.nodeType === Terrasoft.diagram.UserHandlesConstraint.Label:
				item.createdInSchemaUId = this.uId;
				this.labels.add(item.name, item);
				this.fireEvent("changed", {
					item: item
				});
				return;
			default: {
				const lane = this.findItemLane(item);
				let parentName = lane ? lane.name : null;
				if (lane == null) {
					const itemContainer = this.findItemByUId(item.containerUId);
					parentName = itemContainer && itemContainer.name;
				}
				item.parent = parentName;
				this.flowElements.add(item.name, item);
			}
		}
		item.createdInOwnerSchemaUId = this.uId;
		item.createdInSchemaUId = this.uId;
		item.modifiedInSchemaUId = this.uId;
		item.parentSchema = this;
		item.createdInPackageId = this.packageUId;
		this.synchronizeParameters(item);
		if (item.requireCompilation() === true) {
			const itemChangeAction = Terrasoft.process.constants.ITEM_CHANGE_ACTION;
			this.addSchemaChangedItem(item.uId, item.getDisplayValue(), itemChangeAction.ADD);
		}
		this.fireEvent("changed", {
			item: item
		});
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#remove
	 * @override
	 * @throws Terrasoft.ItemNotFoundException If schema doesn't contains item with passed key,
	 * generates exception.
	 */
	remove: function(itemKey) {
		if (!this.contains(itemKey)) {
			throw new Terrasoft.ItemNotFoundException();
		}
		const item = this.findItemByName(itemKey);
		const lanes = this.lanes;
		const flowElements = this.flowElements;
		const labels = this.labels;
		switch (true) {
			case lanes.contains(itemKey):
				lanes.removeByKey(itemKey);
				break;
			case flowElements.contains(itemKey):
				this.removeMapping(item);
				flowElements.removeByKey(itemKey);
				break;
			case labels.contains(itemKey): {
				labels.removeByKey(itemKey);
				this.fireEvent("changed", {
					itemName: itemKey
				});
				return;
			}
		}
		if (item.requireCompilation() === true) {
			const itemChangeAction = Terrasoft.process.constants.ITEM_CHANGE_ACTION;
			const isItemAddedInThisSession = this.isItemChangesRegistered(item.uId, itemChangeAction.ADD);
			if (isItemAddedInThisSession) {
				this.deleteItemChanges(item.uId);
			} else {
				this.addSchemaChangedItem(item.uId, item.getDisplayValue(), itemChangeAction.DELETE);
			}
		}
		this.fireEvent("changed", {
			itemName: itemKey
		});
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#contains
	 * @override
	 */
	contains: function(itemKey) {
		return this.flowElements.contains(itemKey) ||
			this.lanes.contains(itemKey) ||
			this.laneSets.contains(itemKey) ||
			this.labels.contains(itemKey);
	},

	/***
	 * Remove existing parameters mappings.
	 */
	clearSchemaMappings: function() {
		this.parameters.each(p => {
			p.clearSourceValue();
		});
	},

	/**
	 * Search process item by name. If item not found, returns null.
	 * @param {String} name Item name.
	 * @return {Terrasoft.ProcessBaseElementSchema|null} Process item.
	 */
	findItemByName: function(name) {
		const collection = [this.flowElements, this.lanes, this.laneSets, this.labels]
			.find((item) => item.contains(name));
		if (collection) {
			return collection.get(name);
		}
	},

	/**
	 * Returns process item by identifier.
	 * @param {String} uId Item identifier.
	 * @return {Terrasoft.ProcessBaseElementSchema} Process item.
	 */
	findItemByUId: function(uId) {
		const filterFunction = function(item) {
			return item.uId === uId;
		};
		let result = this.flowElements.filterByFn(filterFunction);
		if (result.getCount() === 0) {
			result = this.lanes.filterByFn(filterFunction);
		}
		if (result.getCount() === 0) {
			result = this.laneSets.filterByFn(filterFunction);
		}
		return result.first();
	},

	/**
	 * Returns process element by caption.
	 * @param {String} caption Process element caption.
	 * @return {Terrasoft.ProcessBaseElementSchema} Process item.
	 */
	findItemByCaption: function(caption) {
		const filterFunction = function(item) {
			const itemCaption = Terrasoft.ProcessSchemaDesignerUtilities.getElementCaption(item);
			return itemCaption === caption;
		};
		let result = this.flowElements.filterByFn(filterFunction);
		if (result.getCount() === 0) {
			result = this.lanes.filterByFn(filterFunction);
		}
		if (result.getCount() === 0) {
			result = this.laneSets.filterByFn(filterFunction);
		}
		return result.first();
	},

	/**
	 * Returns absolute item position.
	 * @private
	 * @param {Terrasoft.ProcessFlowElementSchema} item Process item.
	 * @return {Object} Item position.
	 * @return {Number} return.x X-axis value.
	 * @return {Number} return.y Y-axis value.
	 */
	getItemPosition: function(item) {
		const parent = this.findItemByName(item.parent);
		let parentPosition = {
			x: 0,
			y: 0
		};
		if (parent && (parent instanceof Terrasoft.ProcessEventSubprocessSchema)) {
			parentPosition = this.getItemPosition(parent);
		}
		const nodePosition = item.position;
		return {
			x: nodePosition.X + parentPosition.x,
			y: nodePosition.Y + parentPosition.y
		};
	},

	/**
	 * @private
	 */
	_setItemPosition(item, position) {
		if (position.hasOwnProperty("x")) {
			item.position.X = position.x;
		}
		if (position.hasOwnProperty("y")) {
			item.position.Y = position.y;
		}
	},

	/**
	 * Changes the position of the process item.
	 * @param {String} itemName The name of the element.
	 * @param {Object} position The new position of the element.
	 * @param {Number} position.x The x-coordinate of the element.
	 * @param {Number} position.y The coordinate of the element along the Y axis.
	 */
	changeItemPosition: function(itemName, position) {
		const item = this.findItemByName(itemName);
		if (item.nodeType === Terrasoft.diagram.UserHandlesConstraint.Label) {
			if (position.hasOwnProperty("x")) {
				item.x = position.x;
			}
			if (position.hasOwnProperty("y")) {
				item.y = position.y;
			}
		} else {
			this._setItemPosition(item, position);
		}
		this.fireEvent("changed", {
			item: item
		});
	},

	/**
	 * Changes the size of the process item.
	 * @param {String} itemName The name of the element.
	 * @param {Object} size New element sizes.
	 * @param {Number} size.x The width of the element.
	 * @param {Number} size.y The height of the element.
	 */
	changeItemSize: function(itemName, size) {
		const item = this.findItemByName(itemName);
		item.size.width = size.width;
		item.size.height = size.height;
		this.fireEvent("changed", {
			item: item
		});
	},

	/**
	 * Changes the position of the track.
	 * @param {String} itemName The name of the track.
	 * @param {Object} position The new position of the element.
	 * @param {Number} position.x The x-coordinate of the element.
	 * @param {Number} position.y The coordinate of the element along the Y axis.
	 */
	changeLinePosition: function(itemName, position) {
		const item = this.findItemByName(itemName);
		item.position.Y = position.y;
		this.fireEvent("changed", {
			item: item
		});
	},

	/**
	 * Moves the item to another container.
	 * @param {String} itemName The name of the element.
	 * @param {String} containerName The name of the new container in which you want to transfer the item.
	 */
	changeItemContainer: function(itemName, containerName) {
		const item = this.findItemByName(itemName);
		const container = this.findItemByName(containerName);
		item.containerUId = container.uId;
		item.parent = container.name;
		this.fireEvent("changed", {
			item: item
		});
	},

	/**
	 * Changes the coordinates of the break points for the stream.
	 * @param {String} sequenceFlowName The name of the stream.
	 * @param {Object []} polylinePointPositions An array of new breakpoints.
	 * @throws Terrasoft.ItemNotFoundException If an element is not found in the schema, an exception is thrown.
	 */
	changeSequenceFlowPolylinePointPositions: function(sequenceFlowName, polylinePointPositions) {
		if (!this.contains(sequenceFlowName)) {
			throw new Terrasoft.ItemNotFoundException();
		}
		const sequenceFlow = this.findItemByName(sequenceFlowName);
		delete sequenceFlow.startPoint;
		delete sequenceFlow.endPoint;
		sequenceFlow.polylinePointPositions = polylinePointPositions;
		this.fireEvent("changed", {
			item: sequenceFlow
		});
	},

	/**
	 * Loads the information on the execution amount of each process item.
	 * @param {Object []} statisticInfo The array of the number of element executions.
	 */
	loadStatisticInfo: function(statisticInfo) {
		if (!statisticInfo) {
			return;
		}
		Terrasoft.each(statisticInfo, function(executedCount, elementUId) {
			const filteredItems = this.flowElements.filter("uId", elementUId);
			const item = filteredItems.getByIndex(0);
			if (item) {
				item.executedCount = executedCount;
			}
		}, this);
	},

	/**
	 * Loads the information about the multi-instance-specific execution data of each process item.
	 * @param {Object []} statisticInfo The array of the number of element executions.
	 */
	loadMultiInstanceStatisticInfo: function(statisticInfo) {
		Terrasoft.each(this._getMultiInstanceElements(), function(element) {
			const statisticItem = Boolean(statisticInfo) ? statisticInfo[element.uId] : null;
			if (statisticItem) {
				element.completedCount = statisticItem.completedCount;
				element.failedCount = statisticItem.failedCount;
			}
			const resources = Terrasoft.Resources.ProcessSchemaDesigner.Elements;
			element.completedCountTooltipText = resources.MICompletedCountTooltipText;
			element.failedCountTooltipText = resources.MIFailedCountTooltipText;
		}, this);
	},

	/**
	 * Generates unique element name by prefix.
	 * @param {String} prefix Prefix name.
	 * @param {Function} filterFn Filter function.
	 * @param {Terrasoft.ProcessBaseElementSchema} filterFn.item Element.
	 * @param {String} filterFn.name Auto-generated name.
	 * @return {String} Unique element name.
	 * Example:
	 *
	 *      const filterFn = function(item, name) {
	 *         return item.name === name;
	 *      };
	 *      const name = parentSchema.generateItemUniqueName("Element", filterFn);
	 *
	 */
	generateItemUniqueName: function(prefix, filterFn) {
		let name = prefix + "1";
		let counter = 1;
		const internalFilterFn = function(item) {
			return filterFn(item, name);
		};
		do {
			const filteredItems = this.flowElements.filterByFn(internalFilterFn);
			if (filteredItems.getCount() === 0) {
				return name;
			}
			counter++;
			name = prefix + counter;
		} while (true);
	},

	/**
	 * Adds 'Using' to collection.
	 * @param {Object} config Config for create 'Using'.
	 * @param {String} config.uId Element identifier.
	 * @param {String} config.name Using name.
	 * @param {String} config.alias Alias name.
	 */
	addUsing: function(config) {
		Ext.apply(config, {
			createdInSchemaUId: this.uId,
			modifiedInSchemaUId: this.uId,
			createdInPackageId: this.createdInPackageId
		});
		const using = Ext.create("Terrasoft.SchemaUsing", config);
		this.usings.add(using.uId, using);
	},

	/**
	 * @inheritdoc Terrasoft.manager.BaseProcessSchema#getValidateFormulaServerMethodName
	 * @override
	 */
	getValidateFormulaServerMethodName: function() {
		return "ValidateProcessFormula";
	},

	/**
	 * Gets is process schema required compilation.
	 * @return {Boolean}
	 */
	shouldBeCompiled: function() {
		this.isInterpretable = true;
		this.flowElements.filter(function(flowElement) {
			const typeInfo = flowElement.getTypeInfo();
			return typeInfo.typeName === "ProcessScriptTaskSchema";
		}).each(function(scriptTask) {
			if (!scriptTask.useFlowEngineScriptVersion) {
				this.isInterpretable = false;
			}
		}, this);
		return !this._isVersionSupported(this.createdInVersion) || this.useForceCompile || !this.isInterpretable;
	},

	/**
	 * Determines whether a process schema contains multi-instance elements or not.
	 * @returns {Boolean}
	 */
	getContainsMultiInstanceElements: function() {
		let contains = false;
		this.flowElements.each(function(element) {
			if (element.getIsMultiInstanceSupported && element.getIsMultiInstanceModeEnabled()) {
				contains = true;
				return false;
			}
		}, this);
		return contains;
	}

	// endregion

});
