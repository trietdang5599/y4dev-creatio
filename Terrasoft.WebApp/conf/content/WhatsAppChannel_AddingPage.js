Terrasoft.configuration.Structures["WhatsAppChannel_AddingPage"] = {innerHierarchyStack: ["WhatsAppChannel_AddingPage"], structureParent: "ChannelBase_MiniPage"};
define('WhatsAppChannel_AddingPageStructure', ['WhatsAppChannel_AddingPageResources'], function(resources) {return {schemaUId:'e6891da1-5a53-4705-8d15-c06033ee8727',schemaCaption: "WhatsApp channel adding page", parentSchemaName: "ChannelBase_MiniPage", packageName: "CrtOmnichannelApp", schemaName:'WhatsAppChannel_AddingPage',parentSchemaUId:'fd6f97e0-40a0-4620-a4b9-579e0c54c9a9',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("WhatsAppChannel_AddingPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(PageTitle_caption)#)#",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "Name"
			},
			{
				"operation": "merge",
				"name": "ChatQueue",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 4,
						"colSpan": 1,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "Language",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 5,
						"colSpan": 1,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "PhoneNumber",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.PhoneInput",
					"label": "#ResourceString(PhoneNumber_label)#",
					"control": "$PhoneNumber",
					"labelPosition": "above",
					"placeholder": "#ResourceString(PhoneNumber_placeholder)#",
					"tooltip": "",
					"needHandleSave": false,
					"caption": "#ResourceString(PhoneNumber_caption)#",
					"visible": true,
					"readonly": false
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplicationId",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"label": "#ResourceString(ApplicationId_label)#",
					"control": "$ApplicationId",
					"placeholder": "#ResourceString(ApplicationId_placeholder)#",
					"tooltip": "",
					"readonly": false,
					"multiline": false,
					"labelPosition": "above",
					"visible": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Token",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"label": "#ResourceString(Token_label)#",
					"control": "$TwilioToken",
					"placeholder": "#ResourceString(Token_placeholder)#",
					"tooltip": "",
					"readonly": false,
					"multiline": false,
					"labelPosition": "above",
					"visible": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 2
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"ChannelDS_ChatQueue_97sm5rk": {
						"modelConfig": {
							"path": "ChannelDS.ChatQueue"
						}
					},
					"ChannelDS_Language_74ha7t2": {
						"modelConfig": {
							"path": "ChannelDS.Language"
						}
					},
					"ChannelDS_IsActive_iu60mig": {
						"modelConfig": {
							"path": "ChannelDS.IsActive"
						}
					},
					"ChannelDS_Source_с1gw512": {
						"modelConfig": {
							"path": "ChannelDS.Source"
						}
					},
					"ChannelDS_MsgSettingsId_nhf1h58": {
						"modelConfig": {
							"path": "ChannelDS.MsgSettingsId"
						}
					},
					"TwilioToken": {
						"value": "",
						"validators": {
							"required": {
								"type": "crt.Required"
							}
						}
					},
					"ApplicationId": {
						"value": "",
						"validators": {
							"required": {
								"type": "crt.Required"
							}
						}
					},
					"PhoneNumber": {
						"value": "",
						"validators": {
							"required": {
								"type": "crt.Required"
							}
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

