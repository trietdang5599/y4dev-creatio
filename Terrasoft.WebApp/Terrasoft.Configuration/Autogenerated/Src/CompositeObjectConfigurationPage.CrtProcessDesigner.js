 /**
 * Parent: ProcessElementParametersMappingPage
 */
define("CompositeObjectConfigurationPage", [
	"CompositeObjectConfigurationPageResources",
	"css!CompositeObjectConfigurationPage"
], function() {
	return {
		attributes: {

			/**
			 * Flow element name.
			 * @type {Terrasoft.dataValueType.TEXT}
			 */
			"FlowElementName": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Flow element parameters data.
			 */
			"FlowElementParametersData": {
				dataValueType: this.Terrasoft.DataValueType.COLLECTION,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Array of selected element parameters.
			 */
			"SelectedElementParameters": {
				dataValueType: this.Terrasoft.DataValueType.COLLECTION,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Name of the already mapped element.
			 */
			"MappedElementName": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Collection of the already mapped element parameters.
			 */
			"MappedElementParameters": {
				dataValueType: this.Terrasoft.DataValueType.COLLECTION,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * The unique identifier of the composite object parameter the element parameters are mapped to. 
			 */
			"MappedToParameterUId": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Determines whether the select all checkbox is checked or not.
			 */
			"SelectAllChecked": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Maximum parameter nesting level that allowed to specify mapping to. If defined as null parameter
			 * with any nesting level will be allowed to map to.
			 */
			"AllowedCollectionItemNestingLevel": {
				dataValueType: this.Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: 1
			}
		},
		messages: {},
		properties: {},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseParametersMappingPage#init
			 * @overridden
			 */
			init: function(callback) {
				this.callParent([function() {
					if (this._getIsDisableCreateFromRecordCollection()) {
						this.set("AllowedCollectionItemNestingLevel", null);
					}
					this.$FlowElementParametersData = Ext.create("Terrasoft.Collection");
					this.$SelectedElementParameters = [];
					this.on("change:SelectedElementParameters", this._onSelectedElementParametersChange, this);
					this.on("change:SelectAllChecked", this._onSelectDeselectChecked, this);
					callback.call(this);
				}, this]);
			},

			/**
			 * @private
			 */
			_getIsDisableCreateFromRecordCollection: function() {
				return Terrasoft.Features.getIsEnabled("ProcessFeatures.DisableCreateRecordCollectionFromElement");
			},

			/**
			 * @private
			 */
			_selectColumns: function(all) {
				this.$SelectedElementParameters = [];
				if (all) {
					this.$SelectedElementParameters = [...this.$ParametersGridData.getKeys()];
				}
			},

			/**
			 * @inheritdoc Terrasoft.ProcessElementParametersMappingPage#onSelectFlowElement
			 * @overridden
			 */
			onSelectFlowElement: function(flowElementPrimaryColumn) {
				this.set("FlowElementName", flowElementPrimaryColumn);
				this.$SelectAllChecked = false;
				this._selectColumns(false);
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_publishResultActiveRowMessage: function(elementName, parameters) {
				const parametersValue = parameters ?? [];
				this.sandbox.publish("ResultActiveRow", {
					elementName: elementName,
					parameters: parametersValue,
					mappedToParameterUId: this.$MappedToParameterUId,
					isSaveAllowed: Terrasoft.isNotEmpty(parametersValue),
					mappingType: Terrasoft.MappingEnums.MappingType.COMPOSITE_OBJECT_CONFIGURATION,
				}, [this.sandbox.id]);
			},

			/**
			 * @private
			 */
			_initSelectedParameters: function() {
				const mappedParameterNames = this.$MappedParameterNames;
				if (Terrasoft.isEmpty(mappedParameterNames)) {
					return;
				}
				this.$SelectedElementParameters = Terrasoft.map(mappedParameterNames, function(parameterName) {
					const parameterData = this.$FlowElementParametersData
						.findByFn(f => f.parameter.name === parameterName, this);
					return parameterData?.parameter.uId;
				}, this);
			},

			/**
			 * @private
			 */
			_getIsProcessSchemaParameter: function(parameter) {
				return parameter instanceof Terrasoft.Core.Process.ProcessSchemaParameter;
			},

			/**
			 * @private
			 */
			_applyCollectionParameterMappingData: function(parameterData, parameter) {
				if (!this._getIsProcessSchemaParameter(parameter)) {
					return;
				}
				const dataValueType = parameter.dataValueType;
				if (dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST) {
					parameterData['isCollectionParameter'] = true;
				}
				if (!parameter.hasParent()) {
					return;
				}
				const parentParameter = parameter.getParent();  
				if (parentParameter.dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST) {
					parameterData['isCollectionParameterItem'] = true;
				}
			},

			/**
			 * @inheritdoc Terrasoft.ProcessElementParametersMappingPage#getMainRowCollection
			 * @overridden
			 */
			getMainRowCollection: function() {
				const collection = this.callParent(arguments);
				const mappedElementName = this.$MappedElementName;
				if (Terrasoft.isEmpty(mappedElementName)) {
					return collection;
				}
				const mappedElement = collection[mappedElementName];
				if (Terrasoft.isEmpty(mappedElement)) {
					return collection;
				}
				return {
					[mappedElementName]: mappedElement
				};
			},

			/**
			 * @private
			 */
			_getIsNestedCollectionParameter: function(parameter) {
				return parameter.dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST &&
					parameter.hasParent() &&
					parameter.getParent().dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST;
			},

			/**
			 * @private
			 */
			_filterGridRows: function(gridRowCollection) {
				const keysToExclude = [];
				if (this._getIsDisableCreateFromRecordCollection()) {
					Terrasoft.each(gridRowCollection, function(gridRowValue, gridRowKey) {
						const parameter = gridRowValue.get("Parameter");
						if (parameter.dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST) {
							keysToExclude.push(gridRowKey);
						} else {
							const parameterParameter = parameter.getParent();
							if (parameterParameter &&
								parameterParameter.dataValueType === Terrasoft.DataValueType.COMPOSITE_OBJECT_LIST) {
								keysToExclude.push(gridRowKey);
							}
						}
					}, this);
				} else {
					Terrasoft.each(gridRowCollection, function(gridRowValue, gridRowKey) {
						const parameter = gridRowValue.get("Parameter");
						if (!this._getIsProcessSchemaParameter(parameter)) {
							return true;
						}
						if (!parameter.hasParent()) {
							return true;
						}
						if (this._getIsNestedCollectionParameter(parameter)) {
							keysToExclude.push(gridRowKey);
						} else {
							const parameterParameter = parameter.getParent();
							if (this._getIsNestedCollectionParameter(parameterParameter)) {
								keysToExclude.push(gridRowKey);
							}
						}
					}, this);
				}
				Terrasoft.each(keysToExclude, function(gridRowKey) {
					delete gridRowCollection[gridRowKey];
				}, this);
				this.set("HasParameters", !Ext.isEmpty(gridRowCollection));
			},

			/**
			 * @inheritdoc Terrasoft.ProcessElementParametersMappingPage#loadParametersGrid
			 * @overridden
			 */
			loadParametersGrid: function(gridRowCollection) {
				this._filterGridRows(gridRowCollection);
				this.callParent(arguments);
				const gridItems = this.getParametersGridData();
				const flowElementName = this.get("FlowElementName");
				const flowElement = this.getGridData("ElementsGrid").find(flowElementName);
				this.$FlowElementParametersData.clear();
				Terrasoft.each(gridItems, function(gridItem) {
					const parameter = gridItem.get("Parameter");
					const parameterData = {
						parameter,
						mappingType: Terrasoft.MappingEnums.MappingType.COMPOSITE_OBJECT_CONFIGURATION
					};
					this._applyCollectionParameterMappingData(parameterData, parameter);
					const parameterValue = this.getParameterSelectedValue(flowElement, gridItem);
					if (parameterValue && parameterValue.value) {
						parameterValue.value =
							Terrasoft.ProcessSchemaDesignerUtilities.addParameterMask(parameterValue.value);
						parameterValue.displayValue =
							Terrasoft.ProcessSchemaDesignerUtilities.addParameterMask(parameterValue.displayValue);
						parameterValue.referenceSchemaUId = parameter.referenceSchemaUId;
					}
					parameterData['parameterValue'] = parameterValue;
					this.$FlowElementParametersData.add(parameter.uId, parameterData);
				}, this);
				this._publishResultActiveRowMessage(flowElementName);
				this._initSelectedParameters();
			},

			/**
			 * @inheritdoc BaseParametersMappingPage#onChangeActiveRow
			 * @overridden
			 */
			onChangeActiveRow: Terrasoft.emptyFn,

			/**
			 * @inheritdoc BaseParametersMappingPage#onGridDoubleClick
			 * @overridden
			 */
			onGridDoubleClick: Terrasoft.emptyFn,

			/**
			 * @private
			 */
			_onSelectDeselectAllLabelClick: function() {
				this.$SelectAllChecked = !this.$SelectAllChecked;
			},

			/**
			 * @private
			 */
			_onSelectDeselectChecked: function(sender, checked) {
				if (Terrasoft.isEmpty(checked)) {
					return;
				}
				this._selectColumns(checked);
			},

			/**
			 * @private
			 */
			_onSelectedElementParametersChange: function() {
				const parameters = this.$FlowElementParametersData;
				const selectedParameters = Terrasoft.map(this.$SelectedElementParameters, function(parameterUId) {
					return parameters.find(parameterUId);
				}, this);
				this._publishResultActiveRowMessage(this.$FlowElementName, selectedParameters);
			},

			/**
			 * @private
			 */
			onRowSelectionChange: function(selectedUId, rowSelected) {
				if (this._getIsDisableCreateFromRecordCollection()) {
					return;
				}
				const parametersData = this.$FlowElementParametersData;
				const parameterData = parametersData.find(selectedUId);
				if (!parameterData || !parameterData.isCollectionParameter) {
					return;
				}
				const selectedOrDeselectedItems = [];
				selectedOrDeselectedItems.push(selectedUId);
				Terrasoft.each(parametersData, function(parameterData) {
					if (parameterData.isCollectionParameterItem) {
						const parentParameter = parameterData.parameter.getParent();
						if (parentParameter.uId === selectedUId) {
							selectedOrDeselectedItems.push(parameterData.parameter.uId);
						}
					}
				}, this);
				const selectedParameters = this.$SelectedElementParameters;
				if (rowSelected) {
					Terrasoft.each(selectedParameters, function(selectedParameter) {
						if (!selectedOrDeselectedItems.includes(selectedParameter)) {
							selectedOrDeselectedItems.push(selectedParameter);
						}
					}, this);
					this.$SelectedElementParameters = selectedOrDeselectedItems;
					return;
				}
				const result = [];
				Terrasoft.each(selectedParameters, function(selectedParameter) {
					if (!selectedOrDeselectedItems.includes(selectedParameter)) {
						result.push(selectedParameter);
					}
				}, this);
				this.$SelectedElementParameters = result;
			},

			/**
			 * @private
			 */
			onSelectRow: function(selectedUId) {
				this.onRowSelectionChange(selectedUId,true);
			},

			/**
			 * @private
			 */
			onUnSelectRow: function(selectedUId) {
				this.onRowSelectionChange(selectedUId, false);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "SelectDeselectContainer",
				"parentName": "right-grid-container",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"classes": {
						"wrapClassName": "select-deselect-container"
					}
				}
			},
			{
				"operation": "insert",
				"name": "SelectDeselectAllCheckbox",
				"parentName": "SelectDeselectContainer",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"controlConfig": {
						"className": "Terrasoft.CheckBoxEdit",
						"checked": { "bindTo": "SelectAllChecked" },
					},
					"labelConfig": {
						"visible": false
					},
					"caption": {
						"bindTo": "Resources.Strings.SelectDeselectAllCheckboxCaption"
					},
					"markerValue": "SelectDeselectAllCb",
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "insert",
				"name": "SelectDeselectAllLabel",
				"parentName": "SelectDeselectContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"labelClass": ["t-title-label-proc"]
					},
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "Resources.Strings.SelectDeselectAllCheckboxCaption"
					},
					"click": { "bindTo": "_onSelectDeselectAllLabelClick" },
					"markerValue": "SelectDeselectAllLbl"
				}
			},
			{
				"operation": "merge",
				"name": "ParametersGrid",
				"values": {
					"multiSelect": true,
					"selectedRows": "$SelectedElementParameters",
					"selectRow": {"bindTo": "onSelectRow"},
					"unSelectRow": {"bindTo": "onUnSelectRow"}
				}
			}
		]
	};
});
