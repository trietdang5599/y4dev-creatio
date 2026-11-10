/**
 */
Ext.define("Terrasoft.core.mixins.ProcessSchemaDesignerCopyMixin", {

	alternateClassName: "Terrasoft.ProcessSchemaDesignerCopyMixin",

	//region Properties: Private

	/**
	 * Last paste element identifier.
	 * @private
	 * @type {String}
	 */
	lastPasteElementUId: null,

	/**
	 * Last paste element shift by X and Y axis.
	 * @private
	 * @type {Number}
	 */
	lastPasteElementShift: 0,

	//endregion

	//region Methods: Private

	/**
	 * @private
	 */
	_updateParameterUIds: function(parameterNames, options, sourceParameter, targetParameter) {
		const sourceParameterUId = sourceParameter.uId;
		const targetParameterUId = targetParameter.uId;
		Terrasoft.each(parameterNames, function(name) {
			if (options[name] === sourceParameterUId) {
				options[name] = targetParameterUId
			}
		}, this);
	},

	/**
	 * @private
	 */
	_actualizeMultiInstanceOptions: function(multiInstanceOptions, sourceParameter, targetParameter) {
		if (!multiInstanceOptions) {
			return;
		}
		const parameterNames = ["inputCollectionParameterUId", "outputCollectionParameterUId",
			"completedIterationsCountParameterUId", "terminatedIterationsCountParameterUId",
			"totalIterationsCountParameterUId"];
		this._updateParameterUIds(parameterNames, multiInstanceOptions, sourceParameter, targetParameter);
	},

	/**
	 * @private
	 */
	_actualizePerformerAssignmentOptions: function(performerAssignmentOptions, sourceParameter, targetParameter) {
		if (!performerAssignmentOptions) {
			return;
		}
		const parameterNames = ["performerParameterUId", "roleParameterUId"];
		this._updateParameterUIds(parameterNames, performerAssignmentOptions, sourceParameter, targetParameter);
	},

	//endregion

	//region Methods: Public

	/**
	 * Creates item copy.
	 * @param {Terrasoft.BaseProcessSchema} sourceItem Source item.
	 * @return {Terrasoft.BaseProcessSchema} Item copy.
	 */
	createItemCopy: function(sourceItem) {
		const managerItemUId = sourceItem.managerItemUId;
		const config = {};
		sourceItem.getSerializableObject(config);
		const propertiesForDelete = ["uId", "name", "caption", "parameters"];
		propertiesForDelete.forEach(function(propertyName) {
			delete config[propertyName];
		});
		const item = this.elementSchemaManager.createInstance(managerItemUId, config);
		item.uId = Terrasoft.generateGUID();
		this.onGenerateItemNameAndCaption(item);
		let caption = "";
		if (sourceItem.caption) {
			const sourceCaption = sourceItem.caption.getValue();
			caption = sourceCaption ? sourceCaption + Terrasoft.Resources.SchemaDesigner.CopySuffixCaption : "";
		}
		item.caption = Ext.create("Terrasoft.LocalizableString", {cultureValues: caption});
		return item;
	},

	/**
	 * Returns new position for pasted item.
	 * @param {ej.Diagram.Node} sourceNode Source element node.
	 * @return {{X: Number, Y: Number}}
	 */
	getPasteItemPosition: function(sourceNode) {
		const sourceElementUId = sourceNode.tag;
		if (this.lastPasteElementUId !== sourceElementUId) {
			this.lastPasteElementUId = sourceElementUId;
			this.lastPasteElementShift = 0;
		}
		this.lastPasteElementShift += 20;
		const shift = this.lastPasteElementShift;
		return {
			x: sourceNode.offsetX + shift,
			y: sourceNode.offsetY + shift
		};
	},

	/**
	 * Transfers parameters source values from sourceItem to item.
	 * @param {Terrasoft.BaseProcessSchema} item Destination parameters element.
	 * @param {Terrasoft.BaseProcessSchema} sourceItem Source parameters element.
	 */
	cloneParameters: function(item, sourceItem) {
		if (!sourceItem.parameters) {
			return;
		}
		const sourceParameters = sourceItem.parameters.getRoots();
		if (sourceParameters.isEmpty()) {
			return;
		}
		const processMappings = item.parentSchema.mappings;
		item.parameters.each(function(parameter) {
			processMappings.removeByKey(parameter.uId);
			item.parameters.remove(parameter);
		});
		const multiInstanceOptions = item.multiInstanceOptions;
		const performerAssignmentOptions = item.performerAssignmentOptions;
		sourceParameters.each(function(sourceParameter) {
			const parameter = sourceParameter.clone();
			this._actualizeMultiInstanceOptions(multiInstanceOptions, sourceParameter, parameter);
			this._actualizePerformerAssignmentOptions(performerAssignmentOptions, sourceParameter, parameter);
			if (!sourceParameter.getIsDynamic()) {
				const mappingInfo = item.createMappingInfo(parameter.uId, parameter);
				const sourceMapping = processMappings.find(sourceParameter.uId);
				if (sourceMapping) {
					mappingInfo.sourceParameterUId = sourceMapping.sourceParameterUId;
				}
				processMappings.add(mappingInfo.targetUId, mappingInfo);
			}
			item.parameters.add(parameter.uId, parameter);
		}, this);
	},

	/**
	 * Pastes element copy.
	 * @param {ej.Diagram.Node} sourceNode Source element node.
	 */
	pasteElement: function(sourceNode) {
		const sourceElementUId = sourceNode.tag;
		const items = this.get("Items");
		const copyItems = items.filter(function(item) {
			return item.uId === sourceElementUId;
		});
		const sourceItem = copyItems.collection.getAt(0);
		if (!this.elementSchemaManager.allowElementCopy(sourceItem)) {
			return;
		}
		const item = this.createItemCopy(sourceItem);
		const position = this.getPasteItemPosition(sourceNode);
		item.position = item.getCenterPosition(position.x, position.y);
		items.add(item.name, item);
		this.cloneParameters(item, sourceItem);
		this.loadPropertiesPage(item.name);
	}

	//endregion

});
