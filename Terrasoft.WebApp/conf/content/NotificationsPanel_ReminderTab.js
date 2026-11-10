Terrasoft.configuration.Structures["NotificationsPanel_ReminderTab"] = {innerHierarchyStack: ["NotificationsPanel_ReminderTab"], structureParent: "BaseSidebarTemplate"};
define('NotificationsPanel_ReminderTabStructure', ['NotificationsPanel_ReminderTabResources'], function(resources) {return {schemaUId:'9bd98694-dc94-421c-80fd-d3b7259a49c8',schemaCaption: "Reminder tab of the notifications panel", parentSchemaName: "BaseSidebarTemplate", packageName: "CrtUIv2", schemaName:'NotificationsPanel_ReminderTab',parentSchemaUId:'b11e72c4-3787-407e-9415-9d499413d5b8',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("NotificationsPanel_ReminderTab", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "ReminderNotificationsSchema",
				"values": {
					"type": "crt.ModuleLoader",
					"module": "BaseSchemaModuleV2",
					"instanceConfig": {
						"useHistoryState": false,
						"isSchemaConfigInitialized": true,
						"schemaName": "ReminderNotificationsSchema"
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

