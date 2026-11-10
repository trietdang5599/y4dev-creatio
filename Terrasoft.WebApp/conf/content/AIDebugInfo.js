Terrasoft.configuration.Structures["AIDebugInfo"] = {innerHierarchyStack: ["AIDebugInfo"], structureParent: "BaseMiniPageTemplate"};
define('AIDebugInfoStructure', ['AIDebugInfoResources'], function(resources) {return {schemaUId:'9d1c1f81-0fc7-4765-8fed-e3706393928d',schemaCaption: "Creatio.ai debug info", parentSchemaName: "BaseMiniPageTemplate", packageName: "CrtCopilot", schemaName:'AIDebugInfo',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{"DebugInfo":{"dataValueTypeName":"RichText","direction":2,"uId":"a05245b3-018b-0c14-8d1e-df9a405f3e42","isRequired":false,"referenceSchemaName":null}},schemaVersion:1,schemaDifferences:function(){

}};});
define("AIDebugInfo", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "MainHeader",
				"values": {
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "large",
						"left": "large"
					}
				}
			},
			{
				"operation": "remove",
				"name": "ContinueInOtherPageButton"
			},
			{
				"operation": "merge",
				"name": "CloseButton",
				"values": {
					"clicked": {
						"request": "crt.ClosePageRequest",
						"params": {
							"trackUnsavedData": true
						}
					},
					"caption": "#ResourceString(CloseButton)#"
				}
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"padding": {
						"top": "none",
						"right": "large",
						"bottom": "large",
						"left": "large"
					},
					"alignItems": "stretch"
				}
			},
			{
				"operation": "remove",
				"name": "FooterContainer"
			},
			{
				"operation": "remove",
				"name": "CancelButton"
			},
			{
				"operation": "remove",
				"name": "SaveButton"
			},
			{
				"operation": "insert",
				"name": "CopyAllButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(CopyAllButton)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "copy-icon",
					"clicked": {
						"request": "crt.CopyClipboardRequest",
						"params": {
							"value": "$PageParameters_PlainInfo"
						}
					},
					"clickMode": "default"
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DebugInfo_RichTextEditor",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 10
					},
					"type": "crt.RichTextEditor",
					"needHandleSave": false,
					"disableSelectionOptions": true,
					"label": "$Resources.Strings.PageParameters_DebugInfo",
					"labelPosition": "hidden",
					"control": "$PageParameters_DebugInfo",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": "",
					"toolbarDisplayMode": null,
					"filesStorage": {
						"masterRecordColumnValue": "$Id",
						"entitySchemaName": "SysFile",
						"recordColumnName": "RecordId"
					}
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"PageParameters_DebugInfo": {
						"modelConfig": {
							"path": "PageParameters.DebugInfo"
						},
						"change": {}
					},
					"PageParameters_PlainInfo": {
						"modelConfig": {
							"path": "PageParameters.PlainInfo"
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
					"dataSources": {}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

