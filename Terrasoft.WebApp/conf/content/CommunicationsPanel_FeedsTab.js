Terrasoft.configuration.Structures["CommunicationsPanel_FeedsTab"] = {innerHierarchyStack: ["CommunicationsPanel_FeedsTab"], structureParent: "BaseSidebarTemplate"};
define('CommunicationsPanel_FeedsTabStructure', ['CommunicationsPanel_FeedsTabResources'], function(resources) {return {schemaUId:'624c65b5-88fa-41c0-9993-bd227fa68602',schemaCaption: "Feeds tab of the communications panel", parentSchemaName: "BaseSidebarTemplate", packageName: "CrtUIv2", schemaName:'CommunicationsPanel_FeedsTab',parentSchemaUId:'b11e72c4-3787-407e-9415-9d499413d5b8',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("CommunicationsPanel_FeedsTab", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "FlexContainer_inner",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"classes": [
						"ts-feed-container"
					]
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Feed",
				"values": {
					"type": "crt.Feed",
					"feedType": "User",
					"primaryColumnValue": "$Id",
					"cardState": "$CardState",
					"entitySchemaName": null,
					"dataSourceName": null,
					"visible": true
				},
				"parentName": "FlexContainer_inner",
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

