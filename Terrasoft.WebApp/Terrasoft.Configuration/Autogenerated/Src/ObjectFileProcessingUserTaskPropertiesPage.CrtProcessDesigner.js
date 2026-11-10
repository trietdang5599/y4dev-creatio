/**
 * Parent: BaseFileProcessingUserTaskPropertiesPage
 */
define("ObjectFileProcessingUserTaskPropertiesPage", ["ObjectFileProcessingUserTaskPropertiesPageResources",
		"ProcessSchemaUserTaskUtilities", "SectionDesignerEnums", "ProcessUserTaskConstants",
		"FilterModuleMixin", "SortingOrderControlsMixin"],
	function(resources, userTaskUtilities, SectionDesignerEnums) {
		return {
			properties: {
				_defaultRecordsToRead: 50
			},
			mixins: {
				sortingOrderControlsMixin: "Terrasoft.SortingOrderControlsMixin"
			},
			messages: {
			},
			attributes: {

				/**
				 * Source action type.
				 * @type {Integer}
				 */
				"SourceActionType": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: Terrasoft.ProcessUserTaskConstants.ObjectFileProcessingUserTaskSourceActionType.ReadFiles
				},

				/**
				 * Source entity schema unique identifier.
				 * @type {String}
				 */
				"SourceEntitySchemaUId": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					referenceSchemaName: "SysSchema",
					isRequired: true
				},

				/**
				 * Determines whether the selected source schema is File successor or not.
				 * @type {Boolean}
				 */
				"SourceEntitySchemaIsFileSuccessor": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: false
				},

				/**
				 * Source data schema unique identifier.
				 * @type {String}
				 */
				"SourceDataEntitySchemaUId": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					referenceSchemaName: "SysSchema",
					isRequired: false,
					parameterBindConfig: {
						onInit: "initDataEntitySchemaUId",
					}
				},

				/**
				 * Attribute for select control of an entity schema.
				 * @protected
				 * @type {Object}
				 */
				"SourceEntitySchemaSelect": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Collection of the sorting order.
				 * @protected
				 * @type {Terrasoft.ObjectCollection}
				 */
				"SortingOrderDirections": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true
				},

				/**
				 * Sorting order view config.
				 * @protected
				 * @type {Object}
				 */
				"SortingOrderViewConfig": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * View models of sorting orders.
				 * @protected
				 * @type {Terrasoft.ObjectCollection}
				 */
				"SortingOrderControls": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isCollection: true,
					value: this.Ext.create("Terrasoft.ObjectCollection")
				},

				/**
				 * Number of records to read.
				 * @type {Integer}
				 */
				"RecordsToRead": {
					dataValueType: Terrasoft.DataValueType.INTEGER,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * @private
				 * @type {Object}
				 */
				"FilterManagerConfig": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * @private
				 */
				_getSourceSchemaUIdParameterName: function() {
					return "SourceEntitySchemaUId";
				},

				/**
				 * @private
				 */
				_getSourceDataSchemaUIdParameterName: function() {
					return "SourceDataEntitySchemaUId";
				},

				/**
				 * @private
				 */
				_initRecordsToRead: function(element) {
					const parameter = element.findParameterByName("RecordsToRead");
					if (parameter) {
						const rowsCount = parameter.getValue();
						this.set("RecordsToRead", Ext.isEmpty(rowsCount)
							? this._defaultRecordsToRead
							: rowsCount !== "0" ? Number(rowsCount) : null)
					}
				},

				/**
				 * @private
				 */
				_resetSortingColumns: function() {
					const value = this.get("SortingOrderControls");
					if (value) {
						value.clear();
					}
				},

				/**
				 * Initializes SortingColumnsSelect needed by FilterModuleMixin
				 * @protected
				 */
				_initSortingColumnsSelect: function(schemaUId, callback, scope) {
					if (Terrasoft.isEmpty(schemaUId)) {
						Ext.callback(callback, scope);
						return;
					}
					const utils = this.getEntitySchemaDesignerUtilities();
					utils.getSortingColumnsSelectItems(schemaUId, function(entitySchemaColumns) {
						this.set("EntitySchemaColumnsSelect", entitySchemaColumns);
						Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @private
				 */
				_onSourceEntitySchemaChanged: function(value) {
					this.onEntitySchemaChange(value, "Source", function(entitySchemaUId, changed) {
						this.set("SourceEntitySchemaIsFileSuccessor", value?.isFileSuccessor);
						if (changed) {
							this._initSortingColumnsSelect(entitySchemaUId, function() {
								this._resetSortingColumns();
								const fileEntitySchemaUId = value?.fileEntitySchemaUId ?? entitySchemaUId;
								if (this.useSysFile) {
									this.set("SourceDataEntitySchemaUId", entitySchemaUId);
									this.set("SourceEntitySchemaUId", fileEntitySchemaUId);
								} else {
									this.set("SourceEntitySchemaUId", entitySchemaUId);
								}
								this._initFilterManagerConfig(fileEntitySchemaUId, entitySchemaUId,
									this.clearFilters, this);
							}, this);
						}
					}, this);
				},

				/**
				 * @private
				 */
				_saveRecordsToRead: function(element) {
					const recordsToRead = this.get("RecordsToRead");
					const rowsCount = recordsToRead && recordsToRead.toString();
					let parameter = element.findParameterByName("RecordsToRead");
					parameter.setMappingValue({
						value: rowsCount,
						source: Terrasoft.ProcessSchemaParameterValueSource.ConstValue
					});
				},

				/**
				 * @private
				 */
				_getIsSysFile: function(sourceSchemaUId) {
					const utils = this.getEntitySchemaDesignerUtilities();
					return utils.getIsSysFileSchema(sourceSchemaUId);
				},

				/**
				 * @private
				 */
				_initFilterManagerConfig: function(sourceSchemaUId, sourceDataSchemaUId, callback, scope) {
					if (!this.useSysFile) {
						Ext.callback(callback, scope);
						return;
					}
					this.set("FilterManagerConfig", null);
					if (Terrasoft.isEmpty(sourceSchemaUId) || Terrasoft.isEmpty(sourceDataSchemaUId) ||
							!this._getIsSysFile(sourceSchemaUId)) {
						Ext.callback(callback, scope);
						return;
					}
					Terrasoft.EntitySchemaManager.getInstanceByUId(sourceDataSchemaUId, function(schema) {
						if (schema.primaryDisplayColumn) {
							const entitySchemaName = schema.getName();
							this.set("FilterManagerConfig", {
								entitySchemaName: entitySchemaName
							});
						}
						Ext.callback(callback, scope);
					}, this);
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						Terrasoft.chain(function(next) {
								const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
								const sourceSchemaUId = this.get(sourceSchemaUIdParameterName);
								this._initSortingColumnsSelect(sourceSchemaUId, next, this);
							},
							(next) => {
								const sourceDataSchemaUIdParameterName = this._getSourceDataSchemaUIdParameterName();
								const sourceDataSchemaUId = this.get(sourceDataSchemaUIdParameterName);
								const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
								const sourceSchemaUId = this.get(sourceSchemaUIdParameterName);
								this._initFilterManagerConfig(sourceSchemaUId, sourceDataSchemaUId, next, this);
							},
							this.initFilterModule,
							function() {
								this.set("ResultActionTypeList", Ext.create("Terrasoft.Collection"));
								this._initRecordsToRead(element);
								this.initSortingOrderControlsMixin(element);
								Ext.callback(callback, scope);
							}, this);
					}, this]);
				},

				/**
				 * @inheritdoc Terrasoft.FilterModuleMixin#getFilterReferenceSchemaAttributeName
				 * @override
				 */
				getFilterReferenceSchemaAttributeName: function() {
					return this._getSourceSchemaUIdParameterName();
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#getCanChangeElementConfig
				 * @override
				 */
				getCanChangeElementConfig: function() {
					const element = this.get("ProcessElement");
					const parentSchema = element.parentSchema;
					const parameter = element.findParameterByName("CreatedObjectFileIds");
					const checkResult = parentSchema.canRemoveParameter(parameter);
					return {
						canRemove: checkResult.canRemove,
						validationInfo: checkResult.validationInfo
					};
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#saveReferencedSchemas
				 * @override
				 */
				saveReferencedSchemas: function(element) {
					this.callParent(arguments);
					const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
					this.saveReferenceSchemaUId(element, sourceSchemaUIdParameterName, sourceSchemaUIdParameterName);
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#saveReferencedDataSchemas
				 * @override
				 */
				saveReferencedDataSchemas: function(element) {
					this.callParent(arguments);
					const sourceDataSchemaUIdAttributeName = this._getSourceDataSchemaUIdParameterName();
					const value = this.get(sourceDataSchemaUIdAttributeName);
					if (this.get("SourceEntitySchemaIsFileSuccessor")) {
						this.clearParameterSourceValue(element, sourceDataSchemaUIdAttributeName);
					} else {
						this.setParameterConstValue(element, sourceDataSchemaUIdAttributeName, value);
					}
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#saveValues
				 * @override
				 */
				saveValues: function() {
					const element = this.get("ProcessElement");
					this.saveSortingOrderInfo(element);
					this._saveRecordsToRead(element);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc SortingOrderControlsMixin#getOrderInfoParameterName
				 * @overridden
				 */
				getOrderInfoParameterName: function() {
					return "OrderByInfo";
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					const rowsCountRangeValidator = userTaskUtilities.validateRowsCountRange;
					this.addColumnValidator("RecordsToRead", rowsCountRangeValidator);
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#getReferencedSchemaUIds
				 * @override
				 */
				getReferencedSchemaUIds: function(element) {
					const parentList = this.callParent(arguments);
					const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
					this.initReferenceSchemaUId(element, sourceSchemaUIdParameterName, sourceSchemaUIdParameterName, true);
					const sourceSchemaUId = this.get(sourceSchemaUIdParameterName);
					parentList.push(sourceSchemaUId);
					const sourceDataSchemaUIdParameterName = this._getSourceDataSchemaUIdParameterName();
					const sourceDataSchemaUId = this.get(sourceDataSchemaUIdParameterName);
					parentList.push(sourceDataSchemaUId);
					return parentList;
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#onGetEntitySchemas
				 * @override
				 */
				onGetEntitySchemas: function(fileEntities, callback, scope) {
					this.callParent([fileEntities, function() {
						const sourceSchemaUIdParameterName = this._getSourceSchemaUIdParameterName();
						const sourceDataSchemaUIdParameterName = this._getSourceDataSchemaUIdParameterName();
						const sourceDataSchemaUId = this.get(sourceDataSchemaUIdParameterName);
						const sourceSchemaUId =
							Terrasoft.isNotEmpty(sourceDataSchemaUId) && !Terrasoft.isEmptyGUID(sourceDataSchemaUId)
								? sourceDataSchemaUId
								: this.get(sourceSchemaUIdParameterName);
						this.set("SourceEntitySchemaSelect", fileEntities[sourceSchemaUId], { silent: true });
						Ext.callback(callback, scope);
					}, this]);
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#getIsResultSettingsVisible
				 * @override
				 */
				getIsResultSettingsVisible: function() {
					return this.getIsSourceSchemaVisible();
				},

				/**
				 * Determines whether the source schema is visible or not.
				 * @protected
				 */
				getIsSourceSchemaVisible: function() {
					return this.getIsElementConfigured();
				},

				/**
				 * @inheritdoc Terrasoft.BaseFileProcessingUserTaskPropertiesPage#getIsElementConfigured
				 * @override
				 */
				getIsElementConfigured: function() {
					const sourceSchemaAttributeName = this._getSourceSchemaUIdParameterName();
					const sourceSchemaUId = this.get(sourceSchemaAttributeName);
					return !Terrasoft.isEmpty(sourceSchemaUId);
				},

				/**
				 * @inheritdoc Terrasoft.FilterModuleMixin#getFilterModuleConfig
				 * @overridden
				 */
				getFilterModuleConfig: function() {
					const config = this.callParent(arguments);
					const filterManagerConfig = this.get("FilterManagerConfig");
					if (!filterManagerConfig) {
						return config;
					}
					config.recreateFilterManager = true;
					config.filterManagerConfig = {
						columnsConfig: {
							"SysFile": {
								"RecordId": {
									"dataValueType": Terrasoft.DataValueType.LOOKUP,
									"referenceSchemaName": filterManagerConfig.entitySchemaName
								}
							}
						}
					};
					return config;
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "SourceEntitySchemaSelectLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.SourceEntitySchemaSelectCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "SourceEntitySchemaSelect",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": { "bindTo": "prepareFileEntityList" },
							"filterComparisonType": Terrasoft.StringFilterType.CONTAIN,
							"change": { "bindTo": "_onSourceEntitySchemaChanged" }
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"name": "FilterUnitLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 23
						},
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.FilterUnitCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"labelConfig": {
							"visible": {"bindTo": "getIsSourceSchemaVisible"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ExtendedFiltersContainer",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						},
						"id": "ExtendedFiltersContainer",
						"selectors": { "wrapEl": "#ExtendedFiltersContainer" },
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["extended-filters-container"],
						"beforererender": { "bindTo": "unloadFilterUnitModule" },
						"afterrender": { "bindTo": "updateFilterModule" },
						"afterrerender": { "bindTo": "updateFilterModule" },
						"visible": { "bindTo": "getIsSourceSchemaVisible" }
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "RowCountContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["row-count-container"],
						"visible": { "bindTo": "getIsSourceSchemaVisible" },
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "RowCountContainer",
					"propertyName": "items",
					"name": "RecordsToRead",
					"values": {
						"bindTo": "RecordsToRead",
						"dataValueType": Terrasoft.DataValueType.INTEGER,
						"caption": "$Resources.Strings.ReadOnlyCaption"
					}
				},
				{
					"operation": "insert",
					"name": "MoreLabel",
					"parentName": "RowCountContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": "$Resources.Strings.RecordsCaption"
					}
				},
				{
					"operation": "insert",
					"name": "OrderDirectionLabel",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.OrderDirectionCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"visible": {
							"bindTo": "getIsSourceSchemaVisible"
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseFileSelectionContainer",
					"propertyName": "items",
					"name": "SortingOrderContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"visible": { "bindTo": "getIsSourceSchemaVisible" },
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "SortingOrderContainer",
					"propertyName": "items",
					"name": "SelectedSortingOrderContainer",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "SortingOrderControls",
						"onGetItemConfig": "getSelectedSortingOrderViewConfig",
						"classes": {
							"wrapClassName": ["record-column-values-container", "grid-layout"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "SortingOrderContainer",
					"propertyName": "items",
					"name": "AddSortingOrderButton",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.AddSortingOrderButtonCaption"
						},
						"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"imageConfig": {
							"bindTo": "Resources.Images.AddButtonImage"
						},
						"classes": {
							"wrapperClass": ["add-record-column-values-button"]
						},
						"click": {
							"bindTo": "onAddSortingOrderButtonClick"
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
 