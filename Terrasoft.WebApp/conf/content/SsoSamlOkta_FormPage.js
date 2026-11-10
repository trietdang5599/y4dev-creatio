Terrasoft.configuration.Structures["SsoSamlOkta_FormPage"] = {innerHierarchyStack: ["SsoSamlOkta_FormPage"], structureParent: "SsoSamlBase_FormPage"};
define('SsoSamlOkta_FormPageStructure', ['SsoSamlOkta_FormPageResources'], function(resources) {return {schemaUId:'75d31728-c8a3-48a3-9df7-bd2f66c2a968',schemaCaption: "Okta settings form", parentSchemaName: "SsoSamlBase_FormPage", packageName: "SsoSettings", schemaName:'SsoSamlOkta_FormPage',parentSchemaUId:'0979a9b2-a613-45c6-980e-327ce1b51b0c',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("SsoSamlOkta_FormPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PartnerIdentityName",
				"values": {
					"label": "#ResourceString(PartnerIdentityName_label)#"
				}
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"SingleLogoutServiceUrl": {
						"validators": {
							"IsUrlValidator": {
								"params": {
									"SkipEmptyValues": false
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

