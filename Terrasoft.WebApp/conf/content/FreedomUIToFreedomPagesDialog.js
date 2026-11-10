Terrasoft.configuration.Structures["FreedomUIToFreedomPagesDialog"] = {innerHierarchyStack: ["FreedomUIToFreedomPagesDialog"], structureParent: "UISwitcherBaseSwitchPageDialog"};
define('FreedomUIToFreedomPagesDialogStructure', ['FreedomUIToFreedomPagesDialogResources'], function(resources) {return {schemaUId:'142bbee3-735d-451b-a285-14d3e0e0ade4',schemaCaption: "Freedom UI to Freedom pages dialog", parentSchemaName: "UISwitcherBaseSwitchPageDialog", packageName: "CrtUISwitcher", schemaName:'FreedomUIToFreedomPagesDialog',parentSchemaUId:'95534802-9210-491c-a59f-a9738705e1fa',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("FreedomUIToFreedomPagesDialog", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
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
									"EditPagesUIType":"f4d757e1-2aeb-496f-b751-3d5b39708ea3"
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

