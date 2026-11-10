Terrasoft.configuration.Structures["OpenAIModel_FormPage"] = {innerHierarchyStack: ["OpenAIModel_FormPage"], structureParent: "CreatioAIModels_FormPage"};
define('OpenAIModel_FormPageStructure', ['OpenAIModel_FormPageResources'], function(resources) {return {schemaUId:'be0a12e7-508b-4c31-bec8-9dd999f46d16',schemaCaption: "OpenAIModel_FormPage", parentSchemaName: "CreatioAIModels_FormPage", packageName: "CrtCopilot", schemaName:'OpenAIModel_FormPage',parentSchemaUId:'9ba7314e-6fc8-4f89-9826-62a5b6afbe7a',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("OpenAIModel_FormPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "SetRecordRightsButton",
				"values": {
					"caption": "#ResourceString(SetRecordRightsButton_caption)#",
					"visible": false
				}
			},
			{
				"operation": "insert",
				"name": "ModelName",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"label": "$Resources.Strings.PDS_Model_pkt5foo",
					"control": "$PDS_Model_pkt5foo",
					"placeholder": "#ResourceString(ModelName_placeholder)#",
					"tooltip": "#ResourceString(ModelName_tooltip)#",
					"readonly": false,
					"multiline": false,
					"labelPosition": "auto",
					"visible": true
				},
				"parentName": "ConnectionSettingGridContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Apikey",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.PasswordInput",
					"label": "$Resources.Strings.PDS_ApiKey_jr4syei",
					"labelPosition": "auto",
					"control": "$PDS_ApiKey_jr4syei",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": "#ResourceString(Apikey_tooltip)#"
				},
				"parentName": "ConnectionSettingGridContainer",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"PDS_ApiKey_jr4syei": {
						"modelConfig": {
							"path": "PDS.ApiKey"
						}
					},
					"PDS_Model_pkt5foo": {
						"modelConfig": {
							"path": "PDS.Model"
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"dataSources",
					"PDS",
					"config"
				],
				"values": {
					"entitySchemaName": "OpenAIModel"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

