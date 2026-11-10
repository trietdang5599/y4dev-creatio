Terrasoft.configuration.Structures["MLScoringModelPage"] = {innerHierarchyStack: ["MLScoringModelPage"], structureParent: "MLModelPage"};
define('MLScoringModelPageStructure', ['MLScoringModelPageResources'], function(resources) {return {schemaUId:'f32342f7-e078-44b2-84c4-cc57ac670e21',schemaCaption: "MLScoringModelPage", parentSchemaName: "MLModelPage", packageName: "ML", schemaName:'MLScoringModelPage',parentSchemaUId:'e198e03f-20ef-49bf-9167-0faa7be3f977',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("MLScoringModelPage", [], function() {
	return {
		entitySchemaName: "MLModel",
		attributes: {
			"TargetColumnEnabled": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			}
		},
		methods: {
			/**
			 * @inheritDoc
			 * @override
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.updateTrainingOutputFilterModule();
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRootSchemaChanged: function() {
				this.callParent(arguments);
				this.updateTrainingOutputFilterModule();
			},

			/**
			 * @return {Boolean} True if RootSchema is not set.
			 */
			getIsRootSchemaNotSet: function() {
				return this.Ext.isEmpty(this.$RootSchema);
			},
			/**
			 * Returns Target expression group caption.
			 * @return {String}
			 */
			getTargetColumnGroupCaption: function() {
				return this.get("Resources.Strings.TargetColumnGroup_Filters_Caption");
			},

			/**
			 * Returns Target expression group tip content.
			 * @return {String}
			 */
			getTargetColumnGroupInfoButtonContent: function() {
				return this.get("Resources.Strings.TargetColumnGroupInfoButton_Filters_Content");
			},

			/**
			 * @inheritDoc
			 * @overriden
			 */
			filterTargetColumns: function(column) {
				return this.callParent(arguments) && Terrasoft.isNumberDataValueType(column.dataValueType);
			}
		},
		diff: [
			{
				"name": "ScoringAcademyUrl",
				"operation": "insert",
				"parentName": "FaqUrls",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"classes": {
						"textClass": ["faq-button", "base-edit-link"]
					},
					"click": {"bindTo": "onFaqClick"},
					"caption": "$Resources.Strings.ScoringAcademyCaption",
					"tag": {"contextHelpId": 1942}
				}
			},
			{
				"name": "TargetColumnGroupEmptyRootSchemaLabel",
				"parentName": "TargetColumnGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.RootSchemaNotSet",
					"visible": {
						"bindTo": "getIsRootSchemaNotSet"
					},
					"labelConfig": {
						"classes": ["placeholder-label"]
					}
				}
			},
			{
				"name": "TrainingOutputFilterDataContainer",
				"parentName": "TargetColumnGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"id": "TrainingOutputFilterDataContainer",
					"selectors": {"wrapEl": "#TrainingOutputFilterDataContainer"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["training-filters-container"],
					"beforererender": {"bindTo": "unloadTrainingOutputFilterUnitModule"},
					"afterrender": {"bindTo": "updateTrainingOutputFilterModule"},
					"afterrerender": {"bindTo": "updateTrainingOutputFilterModule"}
				}
			}
		]
	};
});


