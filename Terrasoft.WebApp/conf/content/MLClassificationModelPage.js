Terrasoft.configuration.Structures["MLClassificationModelPage"] = {innerHierarchyStack: ["MLClassificationModelPage"], structureParent: "MLModelPage"};
define('MLClassificationModelPageStructure', ['MLClassificationModelPageResources'], function(resources) {return {schemaUId:'2cfa8208-bef7-8e1f-c35b-c2162ecff3bf',schemaCaption: "MLClassificationModelPage", parentSchemaName: "MLModelPage", packageName: "ML", schemaName:'MLClassificationModelPage',parentSchemaUId:'e198e03f-20ef-49bf-9167-0faa7be3f977',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("MLClassificationModelPage", ["MLConfigurationConsts"],
	function(MLConfigurationConsts) {
		return {
			entitySchemaName: "MLModel",
			attributes: {
			},
			methods: {
				/**
				 * @returns {Boolean} True if ConfidentValueLowEdge field should be visible.
				 */
				getIsConfidentValueLowEdgeVisible: function() {
					return this.getLookupValue("MLConfidentValueMethod")
						=== MLConfigurationConsts.ConfidentValueMethods.MaximumProbability;
				},

				/**
				 * @inheritDoc
				 * @overriden
				 */
				filterTargetColumns: function(column) {
					return this.callParent(arguments) && Terrasoft.isLookupDataValueType(column.dataValueType);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "ClassificationAcademyUrl",
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
						"caption": "$Resources.Strings.ClassificationAcademyCaption",
						"tag": {"contextHelpId": 1940}
					}
				},
				{
					"name": "MLConfidentValueMethod",
					"parentName": "AdvancedModelParametersGroup",
					"operation": "insert",
					"propertyName": "items"
				},
				{
					"name": "ConfidentValueLowEdge",
					"parentName": "AdvancedModelParametersGroup",
					"operation": "insert",
					"propertyName": "items",
					"values": {
						"visible": {
							"bindTo": "MLConfidentValueMethod",
							"bindConfig": {"converter": "getIsConfidentValueLowEdgeVisible"}
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			userCode: {}
		};
	});


