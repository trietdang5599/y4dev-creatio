Terrasoft.configuration.Structures["OAuthSettingsMiniPage"] = {innerHierarchyStack: ["OAuthSettingsMiniPage"], structureParent: "BaseMiniPageTemplate"};
define('OAuthSettingsMiniPageStructure', ['OAuthSettingsMiniPageResources'], function(resources) {return {schemaUId:'88f31df4-5061-4efe-927e-dfd3a104dd5f',schemaCaption: "OAuth 2.0 Connection settings", parentSchemaName: "BaseMiniPageTemplate", packageName: "OAuth20", schemaName:'OAuthSettingsMiniPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("OAuthSettingsMiniPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "remove",
				"name": "ContinueInOtherPageButton"
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"gap": {
						"columnGap": "large",
						"rowGap": "small"
					},
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "FooterContainer",
				"values": {
					"justifyContent": "space-between",
					"color": "transparent",
					"borderRadius": "none",
					"gap": "small"
				}
			},
			{
				"operation": "move",
				"name": "CancelButton",
				"parentName": "FlexContainer_qagnxjj",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"color": "default",
					"size": "large",
					"iconPosition": "only-text"
				}
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"caption": "#ResourceString(SaveButton_caption)#"
				}
			},
			{
				"operation": "move",
				"name": "SaveButton",
				"parentName": "FlexContainer_qagnxjj",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SettingsDescriptionLabel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(SettingsDescriptionLabel_caption)#)#",
					"labelType": "body",
					"labelThickness": "normal",
					"labelEllipsis": false,
					"labelColor": "#181818",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_Settings",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "WebInput_IdentityUrl",
				"values": {
					"type": "crt.WebInput",
					"label": "#ResourceString(WebInput_IdentityUrl_label)#",
					"labelPosition": "above",
					"control": "$ServerUrl",
					"tooltip": "#ResourceString(WebInput_IdentityUrl_tooltip)#",
					"visible": true,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "FlexContainer_Settings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Input_ClientId",
				"values": {
					"type": "crt.Input",
					"label": "#ResourceString(Input_ClientId_label)#",
					"labelPosition": "above",
					"control": "$ClientId",
					"multiline": false,
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": "#ResourceString(Input_ClientId_tooltip)#"
				},
				"parentName": "FlexContainer_Settings",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Input_ClientSecret",
				"values": {
					"type": "crt.PasswordInput",
					"label": "#ResourceString(Input_ClientSecret_label)#",
					"labelPosition": "above",
					"control": "$ClientSecret",
					"multiline": false,
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "FlexContainer_Settings",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FlexContainer_xjt2eup",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_CheckConnection",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_CheckConnection_caption)#",
					"color": "outline",
					"disabled": "$ButtonTestDisabled",
					"size": "large",
					"iconPosition": "only-text",
					"clicked": {
						"request": "crt.TestOAuthConnectionResourceRequest",
						"params": {
							"serverUrl": "$ServerUrl",
							"clientId": "$ClientId",
							"clientSecret": "$ClientSecret"
						}
					},
					"visible": true
				},
				"parentName": "FlexContainer_xjt2eup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_qagnxjj",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FooterContainer",
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
					"ServerUrl": {
						"value": "",
						"modelConfig": {}
					},
					"ClientId": {
						"value": "",
						"modelConfig": {}
					},
					"ClientSecret": {
						"value": ""
					},
					"ButtonTestDisabled": {
						"value": true
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

