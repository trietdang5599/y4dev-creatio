Terrasoft.configuration.Structures["SmsChannel_AddingPage"] = {innerHierarchyStack: ["SmsChannel_AddingPage"], structureParent: "ChannelBase_MiniPage"};
define('SmsChannel_AddingPageStructure', ['SmsChannel_AddingPageResources'], function(resources) {return {schemaUId:'3ea9413c-d656-44e1-9c03-ea8bec8fae48',schemaCaption: "SMS channel adding page", parentSchemaName: "ChannelBase_MiniPage", packageName: "CrtOmnichannelApp", schemaName:'SmsChannel_AddingPage',parentSchemaUId:'fd6f97e0-40a0-4620-a4b9-579e0c54c9a9',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("SmsChannel_AddingPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
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
				"operation": "merge",
				"name": "IsActive",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 6,
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
					"ChannelDS_MsgSettingsId_nhf1h59": {
						"modelConfig": {
							"path": "ChannelDS.MsgSettingsId"
						}
					},
					"ChannelDS_Source_с1gw512": {
						"modelConfig": {
							"path": "ChannelDS.Source"
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
					},
					"ChannelDS_Language_4acds5q_List": {
						"isCollection": true,
						"modelConfig": {
							"sortingConfig": {
								"default": [
									{
										"columnName": "Name",
										"direction": "asc"
									}
								]
							}
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
					"ChannelDS",
					"config"
				],
				"values": {
					"loadParameters": {
						"options": {
							"pagingConfig": {
								"rowCount": 1,
								"rowsOffset": -1
							},
							"sortingConfig": {
								"columns": []
							}
						}
					},
					"allowCopyingRecords": false
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

