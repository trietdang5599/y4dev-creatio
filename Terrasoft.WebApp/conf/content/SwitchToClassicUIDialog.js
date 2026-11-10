Terrasoft.configuration.Structures["SwitchToClassicUIDialog"] = {innerHierarchyStack: ["SwitchToClassicUIDialog"], structureParent: "UISwitcherBaseSwitchUIDialog"};
define('SwitchToClassicUIDialogStructure', ['SwitchToClassicUIDialogResources'], function(resources) {return {schemaUId:'032b62ca-9006-4b16-ab31-c90a66ac30d3',schemaCaption: "Switch to Classic UI dialog", parentSchemaName: "UISwitcherBaseSwitchUIDialog", packageName: "CrtUISwitcher", schemaName:'SwitchToClassicUIDialog',parentSchemaUId:'54c8d9bb-05c0-4f54-8b60-048533092a7b',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("SwitchToClassicUIDialog", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
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
								"processName": "UISwitcherFreedomOrClassicUI",
								"processRunType": "RegardlessOfThePage",
								"processParameters": {
									"UseNewShellForAllUsers": "false"
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

