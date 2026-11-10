Terrasoft.configuration.Structures["BaseShell"] = {innerHierarchyStack: ["BaseShell"]};
define('BaseShellStructure', ['BaseShellResources'], function(resources) {return {schemaUId:'b55d348b-a0aa-4622-a73d-87be774af348',schemaCaption: "Base shell layout", parentSchemaName: "", packageName: "CrtUIv2", schemaName:'BaseShell',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("BaseShell", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[{
				"operation": "insert",
				"name": "ShellContainerWithBackground",
				"values": {
					"type": "crt.AppBackground",
					"classes": "$ApplicationBackgroundClassAttribute",
					"contentDisplayed":"$ApplicationBackgroundContentDisplayedAttribute"
				}
			}]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});


