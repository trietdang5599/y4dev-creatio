Terrasoft.configuration.Structures["BaseDashboardTemplate"] = {innerHierarchyStack: ["BaseDashboardTemplate"]};
define('BaseDashboardTemplateStructure', ['BaseDashboardTemplateResources'], function(resources) {return {schemaUId:'eb4d4a67-25d8-fcfa-7851-c4c91efb7b9c',schemaCaption: "Dashboard page", parentSchemaName: "", packageName: "CrtUIPlatform", schemaName:'BaseDashboardTemplate',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("BaseDashboardTemplate", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "Main",
				"values": {
					"type": "crt.GridContainer",
					"rows": "28px",
					"columns": [
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)",
						"minmax(28px, 1fr)"
					],
					"gap": 8,
					"items": [],
					"stretch": true,
					"fitContent": false
				},
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


