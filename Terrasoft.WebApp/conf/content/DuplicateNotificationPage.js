Terrasoft.configuration.Structures["DuplicateNotificationPage"] = {innerHierarchyStack: ["DuplicateNotificationPage"], structureParent: "BaseMiniPageTemplate"};
define('DuplicateNotificationPageStructure', ['DuplicateNotificationPageResources'], function(resources) {return {schemaUId:'4df0eaf7-a5cb-4bb0-83c2-74fdb648c683',schemaCaption: "Duplicate Notification Page", parentSchemaName: "BaseMiniPageTemplate", packageName: "CrtNUI", schemaName:'DuplicateNotificationPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("DuplicateNotificationPage", /**SCHEMA_DEPS*/[  ]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/() /**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"headingLevel": "label",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "ContinueInOtherPageButton"
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
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"caption": "#ResourceString(CancelButton)#",
					"color": "default",
					"size": "large",
					"iconPosition": "only-text",
					"clickMode": "default"
				}
			},
			{
				"operation": "move",
				"name": "CancelButton",
				"parentName": "FooterContainer_Left",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"clicked": {
						"request": "crt.SaveDuplicationRequest"
					},
					"caption": "#ResourceString(SaveButton)#"
				}
			},
			{
				"operation": "move",
				"name": "SaveButton",
				"parentName": "FooterContainer_Right",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataGridMain",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.DataGrid",
					"features": {
						"cells": {
							"disableLinks": true
						},
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true,
								"selectAll": false
							},
							"toolbar": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false,
							"floatingEditPanel": false
						},
						"columns": {
							"adding": false,
							"dragAndDrop": false,
							"resizing": false,
							"sorting": false,
							"toolbar": false
						}
					},
					"columns": [],
					"headerToolbarItems": [],
					"items": "$DataGridMain",
					"primaryColumnName": "MainDS_Id",
					"activeRow": "$DataGridMain_ActiveRow",
					"selectionState": "$DataGridMain_SelectionState",
					"visible": true,
					"fitContent": true,
					"bulkActions": []
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FooterContainer_Left",
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
				"name": "FooterContainer_Right",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MergeDuplicateRecordsButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(MergeDuplicateRecordsButton_caption)#",
					"color": "accent",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": true,
					"clicked": {
						"request": "crt.MergeDuplicateRecordsRequest",
						"params": {
							"dataSourceName": "MainDS",
							"selectionState": "$DataGridMain_SelectionState"
						}
					},
					"clickMode": "default"
				},
				"parentName": "FooterContainer_Right",
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
					"DataGridMain": {
						"isCollection": true,
						"modelConfig": {
							"path": "MainDS",
							"filterAttributes": []
						},
						"viewModelConfig": {
							"attributes": {}
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
						"MainDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "City",
								"attributes": {}
							}
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/ [] /**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/ {} /**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/ {} /**SCHEMA_VALIDATORS*/
	};
});

