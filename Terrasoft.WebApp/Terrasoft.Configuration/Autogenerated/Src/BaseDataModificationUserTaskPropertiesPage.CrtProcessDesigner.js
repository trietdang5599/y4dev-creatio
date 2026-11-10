/**
 * Parent: ProcessFlowElementPropertiesPage
 */
define("BaseDataModificationUserTaskPropertiesPage", ["terrasoft",
		"BaseDataModificationUserTaskPropertiesPageResources", "FilterModuleMixin", "EntitySchemaSelectMixin"],
	function(Terrasoft, resources) {
		return {
			messages: {},
			mixins: {
				filterModuleMixin: "Terrasoft.FilterModuleMixin",
				entitySchemaSelectMixin: "Terrasoft.EntitySchemaSelectMixin"
			},
			attributes: {

				/**
				 * Attribute for select control of an entity schema.
				 * @protected
				 * @type {Object}
				 */
				"EntitySchemaSelect": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},

				/**
				 * Flag that indicates whether filters are required.
				 * @protected
				 * @type {Boolean}
				 */
				"IsFiltersRequired": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * Flag that indicates whether visibility of filters info button.
				 * @protected
				 * @type {Boolean}
				 */
				"FilterInfoButtonVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},

				/**
				 * Attribute names that triggers update of next elements suggestions.
				 * @protected
				 * @type {Object}
				 */
				"SuggestionsTriggerAttributes": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: [
						{
							name: "ReferenceSchemaUId",
							predictionParameterName: "entitySchemaUId"
						}
					]
				}
			},
			methods: {

				/**
				 * @inheritdoc Terrasoft.BaseProcessSchemaElementPropertiesPage#customValidator
				 * @overridden
				 */
				customValidator: function() {
					const validationInfo = {
						isValid: true,
						invalidMessage: ""
					};
					if (this.get("IsFiltersRequired") !== true) {
						return validationInfo;
					}
					const filterEditData = this.get("FilterEditData");
					if (this.isFiltersEmpty(filterEditData)) {
						validationInfo.isValid = false;
						validationInfo.invalidMessage = this.get("Resources.Strings.FilterDataIsNullOrEmptyMessage");
					}
					if (!validationInfo.isValid) {
						this.addCustomValidationResult(validationInfo);
					}
					return validationInfo;
				},

				/**
				 * @inheritdoc Terrasoft.FilterModuleMixin#onFiltersChanged
				 * @overridden
				 */
				onFiltersChanged: function() {
					this.mixins.filterModuleMixin.onFiltersChanged.apply(this, arguments);
					this.setFilterInfoButtonVisible();
				},

				/**
				 * Returns filters is empty.
				 * @param {Object} filterEditData Filters data.
				 * @return {Boolean} True if filters is empty, else false.
				 */
				isFiltersEmpty: function(filterEditData) {
					return this.Ext.isEmpty(filterEditData) || filterEditData.isEmpty();
				},

				/**
				 * Sets visibility for filter info button.
				 * @protected
				 */
				setFilterInfoButtonVisible: function() {
					if (this.get("IsFiltersRequired") !== true) {
						this.set("FilterInfoButtonVisible", false);
						return;
					}
					const filterEditData = this.get("FilterEditData");
					let visible = this.isFiltersEmpty(filterEditData);
					visible = visible && this.getIsFilterUnitVisible();
					this.set("FilterInfoButtonVisible", visible);
				},

				/**
				 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
				 * @overridden
				 */
				onElementDataLoad: function(element, callback, scope) {
					this.callParent([element, function() {
						this.initReferenceSchemas(element);
						this.initEntitySchemaSelectMixin();
						const filterReferenceSchemaUIdParameterName = this.getFilterReferenceSchemaParameterName();
						const filterConfig = {referenceSchemaParameterName: filterReferenceSchemaUIdParameterName};
						this.initFilterModuleMixin(filterConfig, function() {
							this.initEntitySchemaSelect(function() {
								this.setValidationInfo("EntitySchemaSelect", true, null);
								this.setFilterInfoButtonVisible();
								callback.call(scope);
							}, this);
						}, this);
					}, this]);
				},

				/**
				 * Reverts value of attribute EntitySchemaSelect if empty but ReferenceSchemaUId not changed.
				 * @private
				 */
				revertEntitySchemaSelectAttribute: function() {
					const referenceSchemaUId = this.get("ReferenceSchemaUId");
					const referenceSchema = this.get("EntitySchemaSelect");
					if (referenceSchemaUId && !referenceSchema) {
						this.set("EntitySchemaSelect", {
							value: referenceSchemaUId
						});
					}
				},

				/**
				 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
				 * @overridden
				 */
				saveValues: function() {
					this.callParent(arguments);
					const element = this.get("ProcessElement");
					this.saveDataSourceFilters(element);
					this.saveReferenceSchemas(element);
					this.revertEntitySchemaSelectAttribute();
				},

				/**
				 * @inheritdoc EntitySchemaSelectMixin#getEntitySchemaUId
				 * @overridden
				 */
				getEntitySchemaUId: function() {
					return this.get("ReferenceSchemaUId");
				},

				/**
				 * @inheritdoc Terrasoft.EntitySchemaSelectMixin#onEntitySchemaSelectChanged
				 * @overridden
				 */
				onEntitySchemaSelectChanged: function(model, newReferenceSchema) {
					const oldReferenceSchemaUId = this.get("ReferenceSchemaUId");
					const newReferenceSchemaUId = newReferenceSchema ? newReferenceSchema.value : null;
					if (this.Ext.isEmpty(newReferenceSchemaUId)) {
						return;
					}
					if (this.Ext.isEmpty(oldReferenceSchemaUId)) {
						this.onUpdatedEntitySchema();
						return;
					}
					if (oldReferenceSchemaUId === newReferenceSchemaUId) {
						return;
					}
					const config = this.getCanRemoveReferenceSchemaConfig();
					if (config.canRemove) {
						const message = resources.localizableStrings.ChangeReferenceSchemaWarningMessage;
						const changeButton = this.getChangeReferenceSchemaButtonConfig();
						this.showConfirmationDialog(message, function(returnCode) {
							if (returnCode === changeButton.returnCode) {
								this.onUpdatedEntitySchema();
							} else {
								this.getEntitySchemaInfo(oldReferenceSchemaUId, function(item) {
									this.set("EntitySchemaSelect", item);
								}, this);
							}
						}, [changeButton, "cancel"], {defaultButton: 0});
					} else {
						this.showInvalidEntitySchemaChangeDialog(config.validationInfo, function() {
							this.getEntitySchemaInfo(oldReferenceSchemaUId, function(item) {
								this.set("EntitySchemaSelect", item);
							}, this);
						}, this);
					}
				},

				/**
				 * Returns flag that indicates capability to change reference schema.
				 * @private
				 */
				getCanRemoveReferenceSchemaConfig: function()  {
					const element = this.get("ProcessElement");
					const parentSchema = element.parentSchema;
					const config = parentSchema.canRemoveElements([element.name]);
					return config;
				},

				/**
				 * Shows invalid entity schema change dialog.
				 * @private
				 * @param {String} validationInfo Error text message.
				 * @param {Function} callback Handler for dialog events.
				 * @param {Object} scope Scope for dialog handler.
				 */
				showInvalidEntitySchemaChangeDialog: function(validationInfo, callback, scope) {
					Terrasoft.ProcessSchemaDesignerUtilities.showProcessMessageBox({
						caption: resources.localizableStrings.InvalidEntitySchemaChange,
						message: validationInfo,
						handler: callback,
						scope: scope
					});
				},

				/**
				 * @inheritdoc Terrasoft.BaseObject#onDestroy
				 * @overridden
				 */
				onDestroy: function() {
					this.destroyFilterModuleMixin();
					this.callParent(arguments);
				},

				/**
				 * Initializes reference schemas.
				 * @protected
				 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
				 */
				initReferenceSchemas: function(element) {
					const referenceSchemaParameterName = this.getReferenceSchemaUIdParameterName();
					this.initReferenceSchemaUId(element, referenceSchemaParameterName, "ReferenceSchemaUId");
				},

				/**
				 * Saves reference schemas.
				 * @protected
				 * @param {Terrasoft.ProcessBaseElementSchema} element Process element.
				 */
				saveReferenceSchemas: function(element) {
					const referenceSchemaUIdParameterName = this.getReferenceSchemaUIdParameterName();
					this.saveReferenceSchemaUId(element, referenceSchemaUIdParameterName, "ReferenceSchemaUId");
				},

				/**
				 * Clears current filters and updates filter module.
				 * @protected
				 */
				clearFilters: function() {
					this.set("FilterEditData", null);
					this.updateFilterModule();
				},

				/**
				 * Update filters on reference schema changed.
				 * @protected
				 */
				updateFiltersOnEntitySchemaSelectChanged: function() {
					this.clearFilters();
				},

				/**
				 * Processes the event of entity schema update.
				 * @protected
				 * @virtual
				 */
				onUpdatedEntitySchema: function() {
					const referenceSchema = this.get("EntitySchemaSelect") || {};
					const referenceSchemaUId = referenceSchema.value;
					this.set("ReferenceSchemaUId", referenceSchemaUId);
					this.updateFiltersOnEntitySchemaSelectChanged();
				},

				/**
				 * Returns settings for the Change button.
				 * @protected
				 * @virtual
				 * @return {Object} Change button settings.
				 */
				getChangeReferenceSchemaButtonConfig: function() {
					const caption = resources.localizableStrings.ChangeReferenceSchemaButtonCaption;
					return Terrasoft.getButtonConfig("change", caption, "Change");
				},

				/**
				 * Returns the name of the parameter that stores entity schema identifier.
				 * @protected
				 * @virtual
				 * @return {String}
				 */
				getReferenceSchemaUIdParameterName: function() {
					return "EntitySchemaUId";
				},

				/**
				 * Returns the name of the parameter that stores entity schema identifier for the filter module.
				 * @protected
				 * @virtual
				 * @return {String}
				 */
				getFilterReferenceSchemaParameterName: function() {
					return this.getReferenceSchemaUIdParameterName();
				},

				/**
				 * Indicates that the filter module is visible.
				 * @protected
				 * @virtual
				 * @return {Boolean}
				 */
				getIsFilterUnitVisible: function() {
					const attributeName = this.getFilterReferenceSchemaAttributeName();
					const referenceSchemaUId = this.get(attributeName);
					return !this.Ext.isEmpty(referenceSchemaUId);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "BaseDataModificationLayout",
					"parentName": "EditorsContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"classes": {
							"wrapClassName": ["base-data-modification-user-task-properties-page"]
						}
					}
				},
				{
					"operation": "insert",
					"name": "RecommendationLabel",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.EntitySchemaSelectCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"name": "EntitySchemaSelect",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"contentType": Terrasoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {"bindTo": "prepareEntityList"},
							"filterComparisonType": Terrasoft.StringFilterType.CONTAIN
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
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 23
						},
						"itemType": Terrasoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.FilterUnitCaption"},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"labelConfig": {
							"visible": {"bindTo": "getIsFilterUnitVisible"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "FilterInfoButtonContainer",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 23,
							"row": 2,
							"colSpan": 1
						},
						"visible": {
							"bindTo": "FilterInfoButtonVisible"
						},
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"markerValue": "FilterInfoButtonContainer",
						"wrapClass": ["filter-info-button-container"]
					}
				},
				{
					"operation": "insert",
					"parentName": "FilterInfoButtonContainer",
					"propertyName": "items",
					"name": "FilterInfoButton",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.INFORMATION_BUTTON,
						"content": {
							"bindTo": "Resources.Strings.FilterInformationText"
						}
					}
				},
				{
					"operation": "insert",
					"name": "ExtendedFiltersContainer",
					"parentName": "BaseDataModificationLayout",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
						"id": "ExtendedFiltersContainer",
						"selectors": {"wrapEl": "#ExtendedFiltersContainer"},
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": [],
						"wrapClass": ["extended-filters-container"],
						"beforererender": {bindTo: "unloadFilterUnitModule"},
						"afterrender": {bindTo: "updateFilterModule"},
						"afterrerender": {bindTo: "updateFilterModule"},
						"visible": {"bindTo": "getIsFilterUnitVisible"}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
