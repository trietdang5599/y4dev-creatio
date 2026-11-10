Terrasoft.configuration.Structures["UISwitcherLogoutDialog"] = {innerHierarchyStack: ["UISwitcherLogoutDialog"], structureParent: "UISwitcherBaseConfirmationDialog"};
define('UISwitcherLogoutDialogStructure', ['UISwitcherLogoutDialogResources'], function(resources) {return {schemaUId:'b0089ebe-a7a2-4997-a9a8-55e75ef7f4af',schemaCaption: "Logout dialog in UI management section", parentSchemaName: "UISwitcherBaseConfirmationDialog", packageName: "CrtUISwitcher", schemaName:'UISwitcherLogoutDialog',parentSchemaUId:'5da36354-d454-4231-a517-0e312444e5d4',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("UISwitcherLogoutDialog", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "NoButton",
				"values": {
					"clicked": {
						"request": "crt.OpenPageRequest",
						"params": {
							"schemaName": "UISwitcher_ListPage"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "YesButton",
				"values": {
					"clicked": {
						"request": "crt.UISwitcherLogout"
					}
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: 'crt.UISwitcherLogout',
				handler: async (request, next) => {
					await Terrasoft.MainMenuUtilities.logout();
				}
			},
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

