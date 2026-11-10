Terrasoft.configuration.Structures["FreedomUIToClassicPagesDialog"] = {innerHierarchyStack: ["FreedomUIToClassicPagesDialog"], structureParent: "UISwitcherBaseSwitchPageDialog"};
define('FreedomUIToClassicPagesDialogStructure', ['FreedomUIToClassicPagesDialogResources'], function(resources) {return {schemaUId:'059a0ad2-abf6-4085-8b21-5a059be2b075',schemaCaption: "Freedom UI to classic pages dialog", parentSchemaName: "UISwitcherBaseSwitchPageDialog", packageName: "CrtUISwitcher", schemaName:'FreedomUIToClassicPagesDialog',parentSchemaUId:'95534802-9210-491c-a59f-a9738705e1fa',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("FreedomUIToClassicPagesDialog", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "YesButton",
				"values": {
					"clicked": [
						{
							"request": "crt.RunBusinessProcessRequest",
							"params": {
								"processName": "UISwitcherSetFormPagesUI",
								"processRunType": "RegardlessOfThePage",
								"processParameters": {
									"ForNewShell": "true",
									"EditPagesUIType":"d823260d-75be-44ee-8e3a-669bb83a5ce4"
								}
							}
						},
						{
							"request": "crt.OpenPageRequest",
							"params": {
								"schemaName": "UISwitcherLogoutDialog"
							}
						}
					]
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

