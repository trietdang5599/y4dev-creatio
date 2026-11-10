Terrasoft.configuration.Structures["BaseActivityUserTaskPropertiesPage"] = {innerHierarchyStack: ["BaseActivityUserTaskPropertiesPage"], structureParent: "BaseUserTaskPropertiesPage"};
define('BaseActivityUserTaskPropertiesPageStructure', ['BaseActivityUserTaskPropertiesPageResources'], function(resources) {return {schemaUId:'29d2ae27-fd0e-4847-acbc-58d964011393',schemaCaption: "Base properties page of activity user task", parentSchemaName: "BaseUserTaskPropertiesPage", packageName: "CrtProcessDesigner", schemaName:'BaseActivityUserTaskPropertiesPage',parentSchemaUId:'824a1fba-a081-4d8a-940c-6c258c298687',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
/**
 * Parent: BaseUserTaskPropertiesPage
 */
define("BaseActivityUserTaskPropertiesPage", ["terrasoft", "BaseActivityUserTaskPropertiesPageResources", "Activity",
	"ext-base", "ProcessLookupPageMixin", "ActivityConnectionsEditMixin"
], function(Terrasoft) {
	return {
		mixins: {
			processLookupPageMixin: "Terrasoft.ProcessLookupPageMixin",
			activityConnectionsEditMixin: "Terrasoft.ActivityConnectionsEditMixin"
		},
		attributes: {
			/**
			 * Activity connection view models.
			 */
			"ActivityConnectionViewModels": {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true,
				value: this.Ext.create("Terrasoft.ObjectCollection")
			},
			/**
			 * Entity connections.
			 */
			"EntityConnections": {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
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
						name: "Recommendation"
					}
				]
			}
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.ActivityConnectionsEditMixin#getVisibleActivityCategory
			 * @overridden
			 */
			getIsActivityTaskVisible: function() {
				return !this.getIsActivityModuleEnabled();
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#initParameters
			 * @overridden
			 */
			initParameters: function(element) {
				this.callParent(arguments);
				const activityModuleDisabled = !this.getIsActivityModuleEnabled();
				this.mixins.activityConnectionsEditMixin.init.call(this, activityModuleDisabled);
			},

			/**
			 * @inheritdoc ProcessFlowElementPropertiesPage#saveParameters
			 * @overridden
			 */
			saveParameters: function(element) {
				this.callParent(arguments);
				if (!this.getIsActivityModuleEnabled()) {
					this.saveActivityConnectionParameters(element);
				}
			},

			/**
			 * @inheritdoc BaseUserTaskPropertiesPage#getIsOptionalActivitySupported
			 * @overridden
			 */
			getIsOptionalActivitySupported: function() {
				return false;
			},

			/**
			 * @inheritdoc BaseUserTaskPropertiesPage#getIsActivityModuleEnabled
			 * @overridden
			 */
			getIsActivityModuleEnabled: function() {
				return true;
			},

			//endregion

			//region Methods: Private

			/**
			 * Returns ModalBox  captions .
			 * @protected
			 */
			getModalBoxCaption: function() {
				return this.get("Resources.Strings.ProcessLookupPageCaption");
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "TitleTaskContainer",
				"propertyName": "items",
				"name": "Recommendation",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"labelConfig": {
						"visible": false
					},
					"wrapClass": ["no-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "BaseActivityTaskContainer",
				"propertyName": "items",
				"parentName": "UserTaskContainer",
				"className": "Terrasoft.GridLayoutEdit",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "move",
				"name": "ActivityControlsContainer",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "ActivityControlsContainer",
				"parentName": "BaseActivityTaskContainer",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
				}
			},
			{
				"operation": "insert",
				"name": "useBackgroundMode",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"visible": { "bindTo": "canUseBackgroundProcessMode" },
					"wrapClass": ["t-checkbox-control"]
				}
			},
			{
				"operation": "insert",
				"name": "InformationOnStep",
				"parentName": "BaseActivityTaskContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 3, "colSpan": 24 },
					"caption": { "bindTo": "Resources.Strings.InformationOnStepCaption" },
					"wrapClass": ["top-caption-control"]
				}
			},
			{
				"operation": "insert",
				"name": "ActivityConnectionTitleContainer",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["container-list-header"],
					"items": [],
					"visible": { "bindTo": "getIsActivityTaskVisible" }
				}
			},
			{
				"operation": "insert",
				"name": "ActivityConnectionLabel",
				"parentName": "ActivityConnectionTitleContainer",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.ActivityLinksCaption" },
					"classes": {
						"labelClass": ["t-title-label-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "AddActivityConnectionRecordButton",
				"parentName": "ActivityConnectionTitleContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": { "bindTo": "Resources.Images.AddButtonImage" },
					"click": { "bindTo": "openLookupActivityConnectionWindow" }
				}
			},
			{
				"operation": "insert",
				"name": "ActivityConnection",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"idProperty": "ElementId",
					"onItemClick": { "bindTo": "onItemClick" },
					"collection": "ActivityConnectionViewModels",
					"onGetItemConfig": "getConnectionParameterViewConfig",
					"rowCssSelector": ".paramContainer",
					"classes": { "wrapClassName": ["activity-connection"] },
					"visible": { "bindTo": "getIsActivityTaskVisible" }
				}
			}
		]/**SCHEMA_DIFF*/
	};
});


