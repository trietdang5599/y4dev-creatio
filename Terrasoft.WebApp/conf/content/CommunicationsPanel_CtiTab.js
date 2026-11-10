Terrasoft.configuration.Structures["CommunicationsPanel_CtiTab"] = {innerHierarchyStack: ["CommunicationsPanel_CtiTab"], structureParent: "BaseSidebarTemplate"};
define('CommunicationsPanel_CtiTabStructure', ['CommunicationsPanel_CtiTabResources'], function(resources) {return {schemaUId:'a11c8dac-2c4b-48ae-8b25-f37fd6c9d792',schemaCaption: "Cti tab of the communications panel", parentSchemaName: "BaseSidebarTemplate", packageName: "CrtUIv2", schemaName:'CommunicationsPanel_CtiTab',parentSchemaUId:'b11e72c4-3787-407e-9415-9d499413d5b8',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("CommunicationsPanel_CtiTab", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"classes": [
						"ts-cti-container"
					]
				}
			},
			{
				"operation": "insert",
				"name": "CtiPanelModule",
				"values": {
					"type": "crt.ModuleLoader",
					"module": "CtiPanelModule"
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

