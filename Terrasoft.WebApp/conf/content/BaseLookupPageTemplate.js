Terrasoft.configuration.Structures["BaseLookupPageTemplate"] = {innerHierarchyStack: ["BaseLookupPageTemplate"]};
define('BaseLookupPageTemplateStructure', ['BaseLookupPageTemplateResources'], function(resources) {return {schemaUId:'ac545d45-b915-46c9-ad64-806407e620a4',schemaCaption: "Lookup page", parentSchemaName: "", packageName: "CrtUIv2", schemaName:'BaseLookupPageTemplate',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("BaseLookupPageTemplate", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "Main",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"fitContent": false,
					"items": [],
					"color": "primary",
					"justifyContent": "start",
					"alignItems": "stretch",
					"wrap": "nowrap",
					"visible": true,
					"borderRadius": "medium",
					"gap": "medium",
					"padding": {
						"top": "24",
						"right": "32",
						"bottom": "24",
						"left": "32"
					},
					"layoutConfig": {
						"width": 420
					},
					"styles": {
						"border": "none"
					}
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MainHeader",
				"values": {
					"type": "crt.FlexContainer",
					"color": "primary",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"fitContent": true,
					"items": [],
					"borderRadius": "none",
					"gap": "none",
					"direction": "row",
					"justifyContent": "space-between",
					"alignItems": "stretch",
					"wrap": "nowrap",
					"visible": true
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "TitleContainer",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "row",
					"justifyContent": "start",
					"alignItems": "center"
				},
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "PageTitle",
				"values": {
					"type": "crt.Label",
					"id": "ModalPageTitle",
					"caption": "$HeaderCaption",
					"labelType": "headline-2",
					"labelThickness": "default",
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "h1"
				},
				"parentName": "TitleContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ActionButtonsContainer",
				"values": {
					"type": "crt.FlexContainer",
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"direction": "row",
					"items": []
				},
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CloseButton",
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"color": "default",
					"caption": "#ResourceString(CloseButton_caption)#",
					"visible": true,
					"iconPosition": "only-icon",
					"icon": "close-button-icon",
					"size": "medium",
					"clickMode": "default"
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SearchContainer",
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
					"justifyContent": "space-between",
					"alignItems": "stretch",
					"gap": "medium",
					"wrap": "nowrap"
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SearchFilterMain",
				"values": {
					"layoutConfig": {},
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(SearchFilterMain_placeholder)#",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "SearchFilterMain_DataGridMain",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"DataGridMain"
										]
									}
								]
							}
						],
						"from": [
							"SearchFilterMain_SearchValue",
							"SearchFilterMain_FilteredColumnsGroups"
						]
					},
				},
				"parentName": "SearchContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGridMainContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": false,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "nowrap",
					"layoutConfig": {}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "DataGridMain",
				"values": {
					"layoutConfig": {
						"styles": {
							"height": "min(calc(80vh - 184px), 1060px)"
						}
					},
					"type": "crt.DataGrid",
					"items": "$DataGridMain",
					"primaryColumnName": "MainDS_Id",
					"columns": [],
					"visible": true,
					"features": {
						"editable": {
							"enable": false,
							"itemsCreation": false
						}
					},
					"fitContent": true,
					"rowDoubleClick": {
						"request": "crt.LookupPageDataGridRowDoubleClickRequest",
						"params": {
							"rowId": "@event.rowId",
							"itemsAttributeName": "DataGridMain"
						}
					},
					"selectionState": "$DataGridMain_SelectionState",
					"_selectionOptions": {
						"attribute": "DataGridMain_SelectionState"
					},
					"bulkActions": [],
					"styles": {
						"height": "min(calc(80vh - 184px), 1060px)"
					}
				},
				"parentName": "DataGridMainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FooterContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "small",
						"rowGap": "none"
					},
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
					}
				},
				"parentName": "Main",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "FooterLeftColumnContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
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
				"name": "NewButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(NewButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "left-icon",
					"visible": false,
					"icon": "add-button-icon",
					"clicked": {
						"request": "crt.CreateRecordRequest",
						"params": {
							"entityName": "City"
						}
					},
					"clickMode": "default",
					"layoutConfig": {}
				},
				"parentName": "FooterLeftColumnContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FooterRightColumnContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"justifyContent": "end",
					"alignItems": "stretch",
					"wrap": "nowrap",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"color": "transparent",
					"borderRadius": "none",
					"gap": "small"
				},
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CancelButton",
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"caption": "#ResourceString(CancelButton_caption)#",
					"visible": true,
					"color": "default",
					"size": "large",
					"iconPosition": "only-text"
				},
				"parentName": "FooterRightColumnContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SelectButton",
				"values": {
					"type": "crt.Button",
					"clicked": {
						"request": "crt.SelectLookupPageRequest",
						"params": {
							"viewName": "DataGridMain",
							"filters": "$DataGridMain | crt.ToCollectionFilters : 'DataGridMain' : $DataGridMain_SelectionState"
						}
					},
					"color": "primary",
					"caption": "#ResourceString(SelectButton_caption)#",
					"visible": true,
					"size": "large",
					"iconPosition": "only-text",
					"clickMode": "default"
				},
				"parentName": "FooterRightColumnContainer",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"attributes": {
						"HeaderCaption": {
							"value": "#ResourceString(DefaultHeaderCaption)#"
						},
						"DataGridMain": {
							"isCollection": true,
							"modelConfig": {
								"path": "MainDS",
								"sortingConfig": {
									"default": [
										{
											"direction": "asc",
											"columnName": "Name"
										}
									]
								},
								"filterAttributes": [
									{
										"name": "SearchFilterMain_DataGridMain",
										"loadOnChange": true
									}
								]
							},
							"viewModelConfig": {
								"attributes": {}
							}
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
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

