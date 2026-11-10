Terrasoft.configuration.Structures["OktaSettingsForm"] = {innerHierarchyStack: ["OktaSettingsForm"], structureParent: "CustomIdpSettingsForm"};
define('OktaSettingsFormStructure', ['OktaSettingsFormResources'], function(resources) {return {schemaUId:'f3fcccc7-7d83-466a-adc8-8c89033873b0',schemaCaption: "Okta settings form", parentSchemaName: "CustomIdpSettingsForm", packageName: "SsoSettings", schemaName:'OktaSettingsForm',parentSchemaUId:'11d18d1c-1788-40c7-81d4-7d700d10c0be',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("OktaSettingsForm", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "SetIdentityStep_ExpansionPanel",
				"values": {
					"title": "#ResourceString(OktaSetIdentityStep_ExpansionPanel_title)#"
				}
			},
			{
				"operation": "merge",
				"name": "RegisterInIdentity_Label",
				"values": {
					"caption": "#ResourceString(OktaRegisterInIdentity_Label_caption)#"
				}
			},
			{
				"operation": "merge",
				"name": "SamlEndpoints_ExpansionPanel",
				"values": {
					"title": "#ResourceString(OktaSamlEndpoints_ExpansionPanel_title)#"
				}
			},
			{
				"operation": "merge",
				"name": "SetSamlParams_Label",
				"values": {
					"caption": "#ResourceString(OktaSetSamlParams_Label_caption)#"
				}
			},
			{
				"operation": "merge",
				"name": "PartnerIdentityName",
				"values": {
					"label": "#ResourceString(OktaPartnerIdentityName_Input_caption)#"
				}
			},
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

