Terrasoft.configuration.Structures["BaseHomePage"] = {innerHierarchyStack: ["BaseHomePage"]};
define('BaseHomePageStructure', ['BaseHomePageResources'], function(resources) {return {schemaUId:'0c5cfb7a-1ed9-41b8-905e-9a38c6915550',schemaCaption: "Homepage", parentSchemaName: "", packageName: "CrtUIPlatform", schemaName:'BaseHomePage',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("BaseHomePage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "Main",
				"values": {
					"type": "crt.GridContainer",
					"rows": "64px",
					"columns": [
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)",
						"minmax(35px, 1fr)"
					],
					"gap": 8,
					"items": [],
					"stretch": true,
					"fitContent": false
				},
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{
			"attributes": {
				"HeaderCaption": {},
			}
		}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


