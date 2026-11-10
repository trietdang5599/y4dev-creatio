Terrasoft.configuration.Structures["CommunicationsPanel_OmniChatTab"] = {innerHierarchyStack: ["CommunicationsPanel_OmniChatTab"], structureParent: "BaseSidebarTemplate"};
define('CommunicationsPanel_OmniChatTabStructure', ['CommunicationsPanel_OmniChatTabResources'], function(resources) {return {schemaUId:'64757510-f700-4c91-9c8f-3051647011d4',schemaCaption: "Omni chat tab of the communications panel", parentSchemaName: "BaseSidebarTemplate", packageName: "CrtUIv2", schemaName:'CommunicationsPanel_OmniChatTab',parentSchemaUId:'b11e72c4-3787-407e-9415-9d499413d5b8',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("CommunicationsPanel_OmniChatTab", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"id": "OmniChatModule_WrapContainer"
				}
			},
			{
				"operation": "insert",
				"name": "OmniChatModule",
				"values": {
					"type": "crt.ModuleLoader",
					"module": "OmniChatModule"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

