Terrasoft.configuration.Structures["MLRegressionModelPage"] = {innerHierarchyStack: ["MLRegressionModelPage"], structureParent: "MLModelPage"};
define('MLRegressionModelPageStructure', ['MLRegressionModelPageResources'], function(resources) {return {schemaUId:'b6608d9c-2fd5-995c-ed0d-dbcc50850358',schemaCaption: "MLRegressionModelPage", parentSchemaName: "MLModelPage", packageName: "ML", schemaName:'MLRegressionModelPage',parentSchemaUId:'e198e03f-20ef-49bf-9167-0faa7be3f977',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("MLRegressionModelPage", [], function() {
	return {
		entitySchemaName: "MLModel",
		methods: {
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
				"name": "RegressionAcademyUrl",
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
					"caption": "$Resources.Strings.RegressionAcademyCaption",
					"tag": {"contextHelpId": 1941}
				}
			}
		]
	};
});


