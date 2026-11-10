Terrasoft.configuration.Structures["KnwSourceProviderSettingsPage"] = {innerHierarchyStack: ["KnwSourceProviderSettingsPage"], structureParent: "BlankPageTemplate"};
define('KnwSourceProviderSettingsPageStructure', ['KnwSourceProviderSettingsPageResources'], function(resources) {return {schemaUId:'0f388080-091b-4258-98b4-9504c47b3c7f',schemaCaption: "Knowledge Source provider settings page", parentSchemaName: "BlankPageTemplate", packageName: "CrtAIKnwLibApp", schemaName:'KnwSourceProviderSettingsPage',parentSchemaUId:'f691e828-0b36-42a7-898f-c337e9af67d0',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{"KnwSourceConfig":{"dataValueTypeName":"Text","direction":2,"uId":"ac6abe68-f1ed-ec99-d7e7-74ac50e99bb0","isRequired":true,"referenceSchemaName":null},"KnwSourceId":{"dataValueTypeName":"Guid","direction":2,"uId":"4f05173c-df35-7432-8540-87a49794ae61","isRequired":true,"referenceSchemaName":null}},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("KnwSourceProviderSettingsPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"attributes": {
						"KnwSourceId": {
							"modelConfig": {
								"path": "PageParameters.KnwSourceId"
							}
						},
						"KnwSourceConfig": {
							"modelConfig": {
								"path": "PageParameters.KnwSourceConfig"
							}
						},
						"IsLoaded": {
							"value": false
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"primaryDataSourceName": "PDS",
					"loadingConfig": {
						"PDS": {
							"type": "OnDemand"
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [],
				"values": {
					"dataSources": {
						"PDS": {
							"type": "crt.EntityDataSource",
							"config": {
								"entitySchemaName": "KnwSource"
							},
							"scope": "page"
						},
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

