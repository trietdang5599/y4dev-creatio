Terrasoft.configuration.Structures["UserConnectedAppPage"] = {innerHierarchyStack: ["UserConnectedAppPage"], structureParent: "BaseMiniPageTemplate"};
define('UserConnectedAppPageStructure', ['UserConnectedAppPageResources'], function(resources) {return {schemaUId:'e9b8a0fa-ee3c-4716-931a-6b68b43423d5',schemaCaption: "User connected application", parentSchemaName: "BaseMiniPageTemplate", packageName: "OAuth20", schemaName:'UserConnectedAppPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("UserConnectedAppPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
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
					"type": "crt.FlexContainer",
					"gap": "small",
					"fitContent": true,
					"padding": {
						"top": "large",
						"right": "none",
						"bottom": "large",
						"left": "none"
					},
					"direction": "column",
					"alignItems": "stretch",
					"justifyContent": "start",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "remove",
				"name": "MainContainer",
				"properties": [
					"columns",
					"rows",
					"stretch"
				]
			},
			{
				"operation": "merge",
				"name": "FooterContainer",
				"values": {
					"justifyContent": "space-between",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"color": "transparent",
					"borderRadius": "none",
					"gap": "large"
				}
			},
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"caption": "#ResourceString(CancelButton_caption)#",
					"color": "default",
					"size": "large",
					"iconPosition": "only-text",
					"clickMode": "default"
				}
			},
			{
				"operation": "move",
				"name": "CancelButton",
				"parentName": "CloseButtonContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "remove",
				"name": "SaveButton"
			},
			{
				"operation": "insert",
				"name": "FlexContainer_yio2a1h",
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
					"justifyContent": "center",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplicationLogoImageInput",
				"values": {
					"type": "crt.ImageInput",
					"labelPosition": "auto",
					"value": "$ConnectedAppDS_Logo",
					"size": "large",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": true,
					"label": "$Resources.Strings.ConnectedAppDS_Logo",
					"readonly": true,
					"tooltip": ""
				},
				"parentName": "FlexContainer_yio2a1h",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "NameInput",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.ConnectedAppDS_Name",
					"labelPosition": "above",
					"control": "$ConnectedAppDS_Name",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AccessSharingDateTimePicker",
				"values": {
					"type": "crt.DateTimePicker",
					"pickerType": "datetime",
					"label": "$Resources.Strings.ConnectedAppDS_AccessSharedOn",
					"labelPosition": "above",
					"control": "$ConnectedAppDS_AccessSharedOn",
					"visible": false,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ApplicationURLWebInput",
				"values": {
					"type": "crt.WebInput",
					"label": "$Resources.Strings.ConnectedAppDS_ApplicationUrl",
					"labelPosition": "above",
					"control": "$ConnectedAppDS_ApplicationUrl",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "DescriptionInput",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.ConnectedAppDS_Description",
					"labelPosition": "above",
					"control": "$ConnectedAppDS_Description",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "IntegrationActivityCheckbox",
				"values": {
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.ConnectedAppDS_Active",
					"labelPosition": "right",
					"control": "$ConnectedAppDS_Active",
					"visible": false,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "RevokeAccessContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RevokeAccessButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(RevokeAccessButton_caption)#",
					"color": "warn",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": false,
					"clicked": {
						"request": "crt.RevokeClientTokensRequest",
						"params": {
							"clientId": "$ConnectedAppDS_ClientId",
							"usersId": [
								"$ConnectedAppDS_User"
							],
							"dataSourceName": "ConnectedAppDS"
						}
					},
					"clickMode": "default"
				},
				"parentName": "RevokeAccessContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CloseButtonContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
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
					"ConnectedAppDS_ClientId": {
						"modelConfig": {
							"path": "ConnectedAppDS.ClientId"
						}
					},
					"ConnectedAppDS_User": {
						"modelConfig": {
							"path": "ConnectedAppDS.SysUser"
						}
					},
					"ConnectedAppDS_Active": {
						"modelConfig": {
							"path": "ConnectedAppDS.Active"
						}
					},
					"ConnectedAppDS_Name": {
						"modelConfig": {
							"path": "ConnectedAppDS.Name"
						}
					},
					"ConnectedAppDS_Logo": {
						"modelConfig": {
							"path": "ConnectedAppDS.Logo"
						}
					},
					"ConnectedAppDS_AccessSharedOn": {
						"modelConfig": {
							"path": "ConnectedAppDS.AccessSharedOn"
						}
					},
					"ConnectedAppDS_ApplicationUrl": {
						"modelConfig": {
							"path": "ConnectedAppDS.ApplicationUrl"
						}
					},
					"ConnectedAppDS_Description": {
						"modelConfig": {
							"path": "ConnectedAppDS.Description"
						}
					},
					"ConnectedAppDS_AccessShared_59682k4": {
						"modelConfig": {
							"path": "ConnectedAppDS.AccessShared"
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
					"dataSources": {
						"ConnectedAppDS": {
							"type": "crt.EntityDataSource",
							"scope": "page",
							"config": {
								"entitySchemaName": "ConnectedOAuthClientApp",
								"loadParameters": {
									"options": {
										"pagingConfig": {
											"rowCount": 1,
											"rowsOffset": -1
										},
										"sortingConfig": {
											"columns": [
												{
													"columnName": "CreatedOn",
													"direction": "desc"
												}
											]
										}
									}
								},
								"allowCopyingRecords": false
							}
						}
					},
					"primaryDataSourceName": "ConnectedAppDS"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

