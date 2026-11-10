Terrasoft.configuration.Structures["CommunicationsPanel_EmailTab"] = {innerHierarchyStack: ["CommunicationsPanel_EmailTab"], structureParent: "BaseSidebarTemplate"};
define('CommunicationsPanel_EmailTabStructure', ['CommunicationsPanel_EmailTabResources'], function(resources) {return {schemaUId:'8b120855-efa6-469c-8997-7dd95a9a6ea5',schemaCaption: "Email tab of the communications panel", parentSchemaName: "BaseSidebarTemplate", packageName: "CrtUIv2", schemaName:'CommunicationsPanel_EmailTab',parentSchemaUId:'b11e72c4-3787-407e-9415-9d499413d5b8',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("CommunicationsPanel_EmailTab", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "EmailModule",
				"values": {
					"type": "crt.ModuleLoader",
					"module": "EmailModule"
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

