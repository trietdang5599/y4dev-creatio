Terrasoft.configuration.Structures["SwitchToFreedomUIDialog"] = {innerHierarchyStack: ["SwitchToFreedomUIDialog"], structureParent: "UISwitcherBaseSwitchUIDialog"};
define('SwitchToFreedomUIDialogStructure', ['SwitchToFreedomUIDialogResources'], function(resources) {return {schemaUId:'c9b01d89-4e19-4003-91a4-4e0b6e467014',schemaCaption: "Switch to Freedom UI dialog", parentSchemaName: "UISwitcherBaseSwitchUIDialog", packageName: "CrtUISwitcher", schemaName:'SwitchToFreedomUIDialog',parentSchemaUId:'54c8d9bb-05c0-4f54-8b60-048533092a7b',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("SwitchToFreedomUIDialog", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
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
									"UseNewShellForAllUsers": "true"
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

