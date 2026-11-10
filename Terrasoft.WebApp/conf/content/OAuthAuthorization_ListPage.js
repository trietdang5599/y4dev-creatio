Terrasoft.configuration.Structures["OAuthAuthorization_ListPage"] = {innerHierarchyStack: ["OAuthAuthorization_ListPage"], structureParent: "ListFreedomTemplate"};
define('OAuthAuthorization_ListPageStructure', ['OAuthAuthorization_ListPageResources'], function(resources) {return {schemaUId:'d91f2bde-ace4-4df0-852a-9fb7fc14c612',schemaCaption: "OAuth authorization", parentSchemaName: "ListFreedomTemplate", packageName: "OAuth20", schemaName:'OAuthAuthorization_ListPage',parentSchemaUId:'3f1f3f38-a0a4-4549-b895-249fb08f554a',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("OAuthAuthorization_ListPage", /**SCHEMA_DEPS*/["@creatio-devkit/common"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(sdk)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "MainHeader",
				"values": {
					"alignItems": "center",
					"visible": true,
					"borderRadius": "none",
					"gap": "small"
				}
			},
			{
				"operation": "remove",
				"name": "TitleContainer"
			},
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(PageTitle_caption)#)#",
					"visible": true,
					"headingLevel": "label"
				}
			},
			{
				"operation": "move",
				"name": "PageTitle",
				"parentName": "FlexContainer_10imfso",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "remove",
				"name": "ActionButtonsContainer"
			},
			{
				"operation": "remove",
				"name": "AddButton"
			},
			{
				"operation": "remove",
				"name": "DataImportButton"
			},
			{
				"operation": "remove",
				"name": "MenuItem_ImportFromExcel"
			},
			{
				"operation": "remove",
				"name": "OpenLandingDesigner"
			},
			{
				"operation": "remove",
				"name": "ActionButton"
			},
			{
				"operation": "remove",
				"name": "MenuItem_ExportToExcel"
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"direction": "row",
					"color": "transparent",
					"gap": "small",
					"visible": true,
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "small",
						"bottom": "small",
						"left": "small"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "remove",
				"name": "SectionContentWrapper"
			},
			{
				"operation": "remove",
				"name": "DataTable"
			},
			{
				"operation": "insert",
				"name": "FlexContainer_5mfb2m3",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
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
					"wrap": "nowrap"
				},
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_10imfso",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "FlexContainer_5mfb2m3",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_Back",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_Back_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "back-button-icon",
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"clickMode": "default"
				},
				"parentName": "FlexContainer_10imfso",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SearchFilter",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(SearchFilter_vvtqtb6_placeholder)#",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "SearchFilter_DataGrid_k6oenvx",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"DataGrid_k6oenvx"
										]
									}
								]
							}
						],
						"from": [
							"SearchFilter_SearchValue",
							"SearchFilter_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_5mfb2m3",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_t1ggemf",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
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
					"alignItems": "flex-end",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_g7pb2bf",
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
					"alignItems": "center",
					"justifyContent": "center",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainer_t1ggemf",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_AddNewOAuthIntegration",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_AddNewOAuthIntegration_caption)#",
					"color": "primary",
					"disabled": "$HasProblem",
					"size": "large",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.CreateRecordRequest",
						"params": {
							"entityName": "OAuthClientApp"
						}
					},
					"clickMode": "default",
					"icon": "add-button-icon"
				},
				"parentName": "FlexContainer_g7pb2bf",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RefreshListButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(RefreshListButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "reload-icon",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"dataSourceName": "ApplicationsGridDS"
						}
					},
					"clickMode": "default"
				},
				"parentName": "FlexContainer_g7pb2bf",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MenuButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(MenuButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "more-button-icon",
					"menuItems": [],
					"clickMode": "menu"
				},
				"parentName": "FlexContainer_g7pb2bf",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "MenuItem_CreateDefaultResource",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_CreateDefaultResource_caption)#",
					"visible": true,
					"disabled": "$DisableCreateDefaultResource",
					"clicked": {
						"request": "crt.CreateDefaultOAuthResourceRequest"
					},
					"icon": "relationship-button-icon"
				},
				"parentName": "MenuButton",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "StatusContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "FlexContainer_t1ggemf",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ButtonToggleGroup_wrz56x8",
				"values": {
					"for": "CardToggleTabPanel",
					"fitContent": true,
					"type": "crt.ButtonToggleGroup"
				},
				"parentName": "StatusContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_nt0v89z",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
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
					"stretch": true,
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MainListContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": false,
					"visible": true,
					"color": "primary",
					"borderRadius": "medium",
					"padding": {
						"top": "medium",
						"right": "medium",
						"bottom": "medium",
						"left": "medium"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap",
					"layoutConfig": {},
					"stretch": true
				},
				"parentName": "FlexContainer_nt0v89z",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplicationsGrid",
				"values": {
					"type": "crt.DataGrid",
					"features": {
						"rows": {
							"selection": false
						},
						"cells": {
							"selection": false
						},
						"editable": {
							"enable": true,
							"itemsCreation": false,
							"floatingEditPanel": true
						}
					},
					"rowToolbarItems": [
						{
							"type": "crt.MenuItem",
							"caption": "DataGrid.RowToolbar.Open",
							"icon": "edit-row-action",
							"visible": true,
							"clicked": {
								"request": "crt.UpdateRecordRequest",
								"params": {
									"itemsAttributeName": "$DataGrid_k6oenvx",
									"recordId": "$DataGrid_k6oenvx.ApplicationsGridDS_Id"
								},
								"useRelativeContext": true
							}
						},
						{
							"type": "crt.MenuItem",
							"caption": "DataGrid.RowToolbar.Delete",
							"icon": "delete-row-action",
							"visible": true,
							"clicked": {
								"request": "crt.DeleteRecordRequest",
								"params": {
									"itemsAttributeName": "$DataGrid_k6oenvx",
									"recordId": "$DataGrid_k6oenvx.ApplicationsGridDS_Id"
								},
								"useRelativeContext": false
							}
						}
					],
					"items": "$DataGrid_k6oenvx",
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "ApplicationsGridDS_Id",
					"columns": [
						{
							"id": "5d7fcd99-0e69-8a58-1e6a-9c5eccc6ff0b",
							"code": "ApplicationsGridDS_Name",
							"caption": "#ResourceString(ApplicationsGridDS_Name)#",
							"dataValueType": 28
						},
						{
							"id": "ccb84999-cd61-f29a-6c63-c02b1f38dd5a",
							"code": "ApplicationsGridDS_IsActive",
							"caption": "#ResourceString(ApplicationsGridDS_IsActive)#",
							"dataValueType": 12,
							"width": 135
						},
						{
							"id": "c787210e-0c04-5182-f92d-79d6d7b6df55",
							"code": "ApplicationsGridDS_SystemUser",
							"caption": "#ResourceString(ApplicationsGridDS_SystemUser)#",
							"dataValueType": 10,
							"cellView": {
								"caption": "$DataGrid_k6oenvx.ApplicationsGridDS_SystemUserName",
								"type": "crt.Link",
								"mode": "preventDefault",
								"underlining": "never",
								"clicked": {
									"request": "crt.OpenUserCardRequest",
									"params": {
										"systemUserId": "$DataGrid_k6oenvx.ApplicationsGridDS_SystemUser.value"
									}
								}
							},
							"width": 258
						},
						{
							"id": "b60eabd9-bf5f-1724-917d-b173d2fb24b4",
							"code": "ApplicationsGridDS_ApplicationUrl",
							"caption": "#ResourceString(ApplicationsGridDS_ApplicationUrl)#",
							"dataValueType": 28,
							"width": 256
						}
					],
					"placeholder": false,
					"stretch": true,
					"activeRow": "$DataGrid_k6oenvx_ActiveRow",
					"selectionState": "$DataGrid_k6oenvx_SelectionState",
					"_selectionOptions": {
						"attribute": "DataGrid_k6oenvx_SelectionState"
					},
					"bulkActions": []
				},
				"parentName": "MainListContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGrid_k6oenvx_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_AddTag_caption)#",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "ApplicationsGridDS",
							"filters": "$DataGrid_k6oenvx | crt.ToCollectionFilters : 'DataGrid_k6oenvx' : $DataGrid_k6oenvx_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_k6oenvx_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "ApplicationsGrid",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGrid_k6oenvx_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_RemoveTag_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "ApplicationsGridDS",
							"filters": "$DataGrid_k6oenvx | crt.ToCollectionFilters : 'DataGrid_k6oenvx' : $DataGrid_k6oenvx_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_k6oenvx_SelectionState"
						}
					}
				},
				"parentName": "DataGrid_k6oenvx_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGrid_k6oenvx_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_ExportToExcel_caption)#",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "ApplicationsGrid",
							"filters": "$DataGrid_k6oenvx | crt.ToCollectionFilters : 'DataGrid_k6oenvx' : $DataGrid_k6oenvx_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_k6oenvx_SelectionState"
						}
					}
				},
				"parentName": "ApplicationsGrid",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataGrid_k6oenvx_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(BulkAction_Delete_caption)#",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "ApplicationsGridDS",
							"filters": "$DataGrid_k6oenvx | crt.ToCollectionFilters : 'DataGrid_k6oenvx' : $DataGrid_k6oenvx_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_k6oenvx_SelectionState"
						}
					}
				},
				"parentName": "ApplicationsGrid",
				"propertyName": "bulkActions",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "CardToggleTabPanel",
				"values": {
					"type": "crt.TabPanel",
					"items": [],
					"mode": "toggle",
					"fitContent": true,
					"styleType": "default",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto",
					"layoutConfig": {
						"maxWidth": 368,
						"minWidth": 368
					},
					"visible": true,
					"stretch": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "OpenHelpButton",
				"values": {
					"type": "crt.TabContainer",
					"tools": [],
					"items": [],
					"caption": "#ResourceString(OpenHelpButton_caption)#",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "open-book-tab-icon"
				},
				"parentName": "CardToggleTabPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_776e74i",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "OpenHelpButton",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_Help",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Help_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_776e74i",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "WhatIsOAuthContainer",
				"values": {
					"layoutConfig": {},
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "small"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "medium",
						"left": "none"
					},
					"color": "primary",
					"borderRadius": "none",
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "OpenHelpButton",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_WhatIs",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_WhatIs_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "#181818",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "WhatIsOAuthContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_Paragraph_1",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Paragraph_1_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "WhatIsOAuthContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "WhatIsOAuthLearnMoreFlexContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
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
					"gap": "extra-small",
					"wrap": "wrap"
				},
				"parentName": "WhatIsOAuthContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "LearnMoreOAuthLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(LearnMoreLabel_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "WhatIsOAuthLearnMoreFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_LearnMore_Oauth",
				"values": {
					"type": "crt.Link",
					"caption": "#MacrosTemplateString(#ResourceString(Label_LearnMore_Oauth_caption)#)#",
					"href": "https://oauth.net/2/",
					"target": "_blank",
					"visible": true,
					"linkType": "body"
				},
				"parentName": "WhatIsOAuthLearnMoreFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HowToSetUpContainer",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "small"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "medium",
						"left": "none"
					},
					"color": "primary",
					"borderRadius": "none",
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "OpenHelpButton",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_HowToSet",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_HowToSet_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "#181818",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HowToSetUpContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_Paragraph_2",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Paragraph_2_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HowToSetUpContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_Paragraph_3",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Paragraph_3_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HowToSetUpContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_Paragraph_4",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 4,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Paragraph_4_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HowToSetUpContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "LearnMoreAcademyFlexContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 5,
						"colSpan": 1,
						"rowSpan": 1
					},
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
					"gap": "extra-small",
					"wrap": "wrap"
				},
				"parentName": "HowToSetUpContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "LearnMoreAcademyLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(LearnMoreAcademyLabel_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "LearnMoreAcademyFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_LearnMore_Academy",
				"values": {
					"type": "crt.Link",
					"caption": "#MacrosTemplateString(#ResourceString(Label_LearnMore_Academy_caption)#)#",
					"href": "https://academy.creatio.com/documents?id=2514",
					"target": "_blank",
					"visible": true,
					"linkType": "body"
				},
				"parentName": "LearnMoreAcademyFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "OpenDiagnosticButton",
				"values": {
					"type": "crt.TabContainer",
					"tools": [],
					"items": [],
					"caption": "#ResourceString(OpenDiagnosticButton_caption)#",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "settings-tab-icon"
				},
				"parentName": "CardToggleTabPanel",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_rpmmana",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "OpenDiagnosticButton",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_Diagnostic",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Diagnostic_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_rpmmana",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DiagnosticsMainFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": "$ShowDiagnostic",
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
					"gap": "large",
					"wrap": "nowrap"
				},
				"parentName": "OpenDiagnosticButton",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DiagnosticsControlsFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
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
					"gap": "medium",
					"wrap": "nowrap"
				},
				"parentName": "DiagnosticsMainFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_DiagnosticsTabDescription",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_DiagnosticsTabDescription_caption)#)#",
					"labelType": "button-small",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "DiagnosticsControlsFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DiagnosticInfoFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column",
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
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "DiagnosticsControlsFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_SystemSettings",
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
					"alignItems": "center",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "DiagnosticInfoFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ImageInput_SystemSettings",
				"values": {
					"type": "crt.ImageInput",
					"label": "",
					"value": "$IsSystemSettingsFilledIn | crt.BooleanToStringValue:'images/tick.svg':'images/cross.svg' | crt.ToFileContentUrl:'OAuth20'",
					"readonly": true,
					"placeholder": "",
					"labelPosition": "auto",
					"size": "extra-small",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": true,
					"tooltip": ""
				},
				"parentName": "FlexContainer_SystemSettings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_SystemSettings",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_SystemSettings_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_SystemSettings",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_Identity",
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
					"alignItems": "center",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "DiagnosticInfoFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ImageInput_Identity",
				"values": {
					"type": "crt.ImageInput",
					"label": "",
					"value": "$IsIdentityServiceAvailable | crt.BooleanToStringValue:'images/tick.svg':'images/cross.svg' | crt.ToFileContentUrl:'OAuth20'",
					"readonly": true,
					"placeholder": "",
					"labelPosition": "auto",
					"size": "extra-small",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": true,
					"tooltip": ""
				},
				"parentName": "FlexContainer_Identity",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_IdentityAvailable",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_IdentityAvailable_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_Identity",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_vebfxqq",
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
					"alignItems": "center",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "DiagnosticInfoFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ImageInput_AccessToken",
				"values": {
					"type": "crt.ImageInput",
					"label": "",
					"value": "$IsAccessTokenRetrievableForSystemActions | crt.BooleanToStringValue:'images/tick.svg':'images/cross.svg' | crt.ToFileContentUrl:'OAuth20'",
					"readonly": true,
					"placeholder": "",
					"labelPosition": "auto",
					"size": "extra-small",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": true,
					"tooltip": ""
				},
				"parentName": "FlexContainer_vebfxqq",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_AccessToken",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_AccessToken_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_vebfxqq",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_DefaultResource",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"alignItems": "center"
				},
				"parentName": "DiagnosticInfoFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ImageInput_DefaultResource",
				"values": {
					"type": "crt.ImageInput",
					"label": "",
					"value": "$IsDefaultResourceRegistered | crt.BooleanToStringValue:'images/tick.svg':'images/cross.svg' | crt.ToFileContentUrl:'OAuth20'",
					"readonly": true,
					"placeholder": "",
					"labelPosition": "auto",
					"size": "extra-small",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": true,
					"tooltip": ""
				},
				"parentName": "FlexContainer_DefaultResource",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_DefaultResource",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_DefaultResource_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_DefaultResource",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DiagnosticButtonsFlexContainer",
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
				"parentName": "DiagnosticsControlsFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Button_RestartDiagnostic",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_RestartDiagnostic_caption)#",
					"color": "outline",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "reload-icon",
					"clicked": {
						"request": "crt.OAuthHealthCheckRequest",
						"params": {
							"showBodyMask": true
						}
					},
					"clickMode": "default"
				},
				"parentName": "DiagnosticButtonsFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_OpenSettings",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_OpenSettings_caption)#",
					"color": "outline",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.OpenPageRequest",
						"params": {
							"schemaName": "OAuthSettingsMiniPage"
						}
					},
					"clickMode": "default",
					"icon": "open-button-icon"
				},
				"parentName": "DiagnosticButtonsFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DiagnosticErrorFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"color": "transparent",
					"visible": "$HasProblem",
					"borderRadius": "medium",
					"padding": {
						"top": "small",
						"right": "medium",
						"bottom": "small",
						"left": "medium"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap",
					"styles": {
						"border-color": "#F2C1B6"
					}
				},
				"parentName": "DiagnosticsMainFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_Reason",
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
					"alignItems": "center",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "DiagnosticErrorFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ImageInput_Info",
				"values": {
					"type": "crt.ImageInput",
					"label": "",
					"value": "$ImageInput_InfoIcon|crt.ToFileContentUrl:'OAuth20'",
					"readonly": true,
					"placeholder": "",
					"labelPosition": "auto",
					"size": "extra-small",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": true,
					"tooltip": ""
				},
				"parentName": "FlexContainer_Reason",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DiagnisticErrorReasonLabel",
				"values": {
					"type": "crt.Label",
					"caption": "$HealthCheckReason",
					"labelType": "caption-large",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_Reason",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DiagnisticErrorMessageLabel",
				"values": {
					"type": "crt.Label",
					"caption": "$HealthCheckMessage",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "DiagnosticErrorFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_DiagnosticAcademy",
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
					"gap": "extra-small",
					"wrap": "wrap"
				},
				"parentName": "DiagnosticErrorFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Label_DiagnisticAcademyLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_DiagnisticAcademyLabel_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_DiagnosticAcademy",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Link_DiagnosticAcademy",
				"values": {
					"type": "crt.Link",
					"caption": "#MacrosTemplateString(#ResourceString(Link_3a44n74_caption)#)#",
					"href": "https://academy.creatio.com/documents?id=2513",
					"target": "_blank",
					"visible": true,
					"linkType": "body"
				},
				"parentName": "FlexContainer_DiagnosticAcademy",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DiagnisticSuccessFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"visible": "$HasProblem | crt.InvertBooleanValue",
					"items": [],
					"fitContent": false,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "medium",
						"bottom": "none",
						"left": "medium"
					},
					"alignItems": "center",
					"justifyContent": "center",
					"gap": "small",
					"wrap": "nowrap",
					"stretch": true
				},
				"parentName": "OpenDiagnosticButton",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ImageInput_AllGood",
				"values": {
					"type": "crt.ImageInput",
					"label": "",
					"value": "$ImageInput_AllGoodImage | crt.ToFileContentUrl:'OAuth20'",
					"readonly": true,
					"placeholder": "",
					"labelPosition": "auto",
					"size": "large",
					"borderRadius": "medium",
					"positioning": "cover",
					"visible": true,
					"tooltip": ""
				},
				"parentName": "DiagnisticSuccessFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DiagnosticSuccessHeaderLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(DiagnosticSuccessHeaderLabel_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "DiagnisticSuccessFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DiagnosticSuccessBodyLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(DiagnosticSuccessBodyLabel_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "center",
					"visible": true
				},
				"parentName": "DiagnisticSuccessFlexContainer",
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
					"ShowDiagnostic": {
						"value": false
					},
					"HasProblem": {
						"value": true
					},
					"ImageInput_InfoIcon": {
						"value": "images/hintIcon.svg"
					},
					"ImageInput_AllGoodImage": {
						"value": "images/success.svg"
					},
					"DisableCreateDefaultResource": {
						"value": true
					},
					"IsSystemSettingsFilledIn": {
						"value": false,
						"modelConfig": {}
					},
					"IsIdentityServiceAvailable": {
						"value": false,
						"modelConfig": {}
					},
					"IsAccessTokenRetrievableForSystemActions": {
						"value": false,
						"modelConfig": {}
					},
					"IsDefaultResourceRegistered": {
						"value": false,
						"modelConfig": {}
					},
					"HealthCheckMessage": {
						"value": "",
						"modelConfig": {}
					},
					"HealthCheckReason": {
						"value": "",
						"modelConfig": {}
					},
					"ItemsSorting": {},
					"FolderTree_visible": {
						"value": false
					},
					"DataGrid_k6oenvx": {
						"isCollection": true,
						"modelConfig": {
							"path": "ApplicationsGridDS",
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
									"name": "SearchFilter_DataGrid_k6oenvx",
									"loadOnChange": true
								}
							]
						},
						"viewModelConfig": {
							"attributes": {
								"ApplicationsGridDS_Name": {
									"modelConfig": {
										"path": "ApplicationsGridDS.Name"
									}
								},
								"ApplicationsGridDS_IsActive": {
									"modelConfig": {
										"path": "ApplicationsGridDS.IsActive"
									}
								},
								"ApplicationsGridDS_GrantType": {
									"modelConfig": {
										"path": "ApplicationsGridDS.GrantType"
									}
								},
								"ApplicationsGridDS_SystemUser": {
									"modelConfig": {
										"path": "ApplicationsGridDS.SystemUser"
									}
								},
								"ApplicationsGridDS_SystemUserName": {
									"modelConfig": {
										"path": "ApplicationsGridDS.SystemUser.Name"
									}
								},
								"ApplicationsGridDS_ApplicationUrl": {
									"modelConfig": {
										"path": "ApplicationsGridDS.ApplicationUrl"
									}
								},
								"ApplicationsGridDS_Id": {
									"modelConfig": {
										"path": "ApplicationsGridDS.Id"
									}
								}
							}
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items"
				],
				"values": {
					"modelConfig": {
						"path": "PDS",
						"pagingConfig": {
							"rowCount": 30
						},
						"sortingConfig": {
							"attributeName": "ItemsSorting",
							"default": []
						},
						"filterAttributes": []
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
						"PDS": {
							"type": "crt.EntityDataSource",
							"hiddenInPageDesigner": true,
							"config": {
								"entitySchemaName": "OAuthClientApp",
								"attributes": {}
							},
							"scope": "viewElement"
						},
						"ApplicationsGridDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "OAuthClientApp",
								"attributes": {
									"Name": {
										"path": "Name"
									},
									"IsActive": {
										"path": "IsActive"
									},
									"GrantType": {
										"path": "GrantType"
									},
									"SystemUser": {
										"path": "SystemUser"
									},
									"ApplicationUrl": {
										"path": "ApplicationUrl"
									}
								}
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

