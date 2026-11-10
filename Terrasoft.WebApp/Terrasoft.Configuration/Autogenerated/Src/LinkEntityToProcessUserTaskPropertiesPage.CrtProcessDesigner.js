/**
 * Parent: ProcessFlowElementPropertiesPage
 */
define("LinkEntityToProcessUserTaskPropertiesPage", ["terrasoft", "LinkEntityToProcessUserTaskPropertiesPageResources",
	"ProcessSchemaUserTaskUtilities", "ProcessModuleUtilities", "ProcessEntryPointPropertiesPageMixin"],
		function(Terrasoft, resources, UserTaskUtilities) {
			return {
				messages: {},
				mixins: {
					processEntryPointPropertiesPageMixin: "Terrasoft.ProcessEntryPointPropertiesPageMixin"
				},
				attributes: {
					/**
					 * Connection object.
					 */
					"EntitySchemaId": {
						dataValueType: this.Terrasoft.DataValueType.LOOKUP,
						type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
						caption: resources.localizableStrings.EntitySchemaCaption,
						referenceSchemaName: "SysSchema",
						doAutoSave: true,
						isRequired: true
					},
					/**
					 * Record of connected object.
					 */
					"EntityId": {
						dataValueType: this.Terrasoft.DataValueType.MAPPING,
						type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
						caption: resources.localizableStrings.EntityCaption,
						initMethod: "initPropertySilent",
						doAutoSave: true,
						isRequired: true
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
								name: "EntitySchemaId",
								predictionParameterName: "entitySchemaUId"
							}
						]
					}
				},
				methods: {
					/**
					 * @inheritdoc Terrasoft.ProcessEntryPointPropertiesPageMixin#getEntitySchemaParameterName.
					 * @overridden
					 */
					getEntitySchemaParameterName: function() {
						return "EntitySchemaId";
					},
					/**
					 * @inheritdoc Terrasoft.BaseProcessSchemaElementPropertiesPage#onElementDataLoad.
					 * @overridden
					 */
					onElementDataLoad: function(element, callback, scope) {
						this.callParent([element, function() {
							this.initEntitySchemas(function() {
								this.initEntitySchema(element, callback, scope);
							}, this);
						}, this]);
					},
					/**
					 * @inheritdoc Terrasoft.BaseSchemaViewModel#setValidationConfig.
					 * @overridden
					 */
					setValidationConfig: function() {
						this.callParent(arguments);
						this.addColumnValidator("EntityId", UserTaskUtilities.validateMappingValue);
					},
					/**
					 * @inheritdoc Terrasoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
					 * @override
					 */
					getParameterReferenceSchemaUId: function() {
						///TODO CRM-34126 Research
						var entitySchema = this.get("EntitySchemaId");
						return entitySchema ? entitySchema.value : null;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "UserTaskContainer",
						"propertyName": "items",
						"parentName": "EditorsContainer",
						"className": "Terrasoft.GridLayoutEdit",
						"values": {
							"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "TitleTaskContainer",
						"propertyName": "items",
						"parentName": "UserTaskContainer",
						"className": "Terrasoft.GridLayoutEdit",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
							"items": [],
							"classes": {
								"wrapClassName": ["link-entity-to-process-user-task-properties-page"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "WhatPageToOpenLabel",
						"parentName": "TitleTaskContainer",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24
							},
							"itemType": Terrasoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.WhichRecordToConnectThisProcessCaption"},
							"classes": {"labelClass": ["t-title-label-proc"]}
						}
					},
					{
						"operation": "insert",
						"parentName": "TitleTaskContainer",
						"propertyName": "items",
						"name": "EntitySchemaId",
						"values": {
							"contentType": Terrasoft.ContentType.ENUM,
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24
							},
							"controlConfig": {
								"prepareList": {"bindTo": "onPrepareEntitySchemaList"},
								"filterComparisonType": Terrasoft.StringFilterType.CONTAIN
							},
							"wrapClass": ["top-caption-control"]
						}
					},
					{
						"operation": "insert",
						"parentName": "TitleTaskContainer",
						"propertyName": "items",
						"name": "EntityId",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 24
							},
							"wrapClass": ["top-caption-control"],
							"enabled": {"bindTo": "EntitySchemaId"}
						}
					}
				]
			};
		}
);
