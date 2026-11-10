Terrasoft.configuration.Structures["NotificationsPanel_AnniversaryNotificationsTab"] = {innerHierarchyStack: ["NotificationsPanel_AnniversaryNotificationsTab"], structureParent: "BaseSidebarTemplate"};
define('NotificationsPanel_AnniversaryNotificationsTabStructure', ['NotificationsPanel_AnniversaryNotificationsTabResources'], function(resources) {return {schemaUId:'8e038041-f182-462b-bd96-f1f2683e88da',schemaCaption: "Anniversary notifications tab of the notifications panel", parentSchemaName: "BaseSidebarTemplate", packageName: "CrtUIv2", schemaName:'NotificationsPanel_AnniversaryNotificationsTab',parentSchemaUId:'b11e72c4-3787-407e-9415-9d499413d5b8',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("NotificationsPanel_AnniversaryNotificationsTab", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "AnniversaryNotificationsSchema",
				"values": {
					"type": "crt.ModuleLoader",
					"module": "BaseSchemaModuleV2",
					"instanceConfig": {
						"useHistoryState": false,
						"isSchemaConfigInitialized": true,
						"schemaName": "AnniversaryNotificationsSchema"
					}
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

