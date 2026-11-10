define("WebhooksLog_ListPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "MainHeader",
				"values": {
					"direction": "column",
					"justifyContent": "start",
					"alignItems": "stretch",
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
				"operation": "remove",
				"name": "PageTitle"
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
				"operation": "remove",
				"name": "DataTable"
			},
			{
				"operation": "insert",
				"name": "MainHeaderContainer",
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
					"alignItems": "center",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_w8jtnds",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "MainHeaderContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BackButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_uwdgoxo_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"clickMode": "default",
					"icon": "back-button-icon"
				},
				"parentName": "FlexContainer_w8jtnds",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HeaderTitle",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HeaderTitle_caption)#)#",
					"labelType": "headline-1",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "FlexContainer_w8jtnds",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_gg4qwd2",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "MainHeaderContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ExportButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ExportButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "export-button-icon",
					"menuItems": [],
					"clickMode": "default",
					"layoutConfig": {},
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "WebhooksLogGrid",
							"filters": "$Items | crt.ToCollectionFilters : 'Items' : $DataTable_SelectionState"
						}
					}
				},
				"parentName": "MainHeaderContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FilterContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "small",
						"bottom": "small",
						"left": "small"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "wrap",
					"layoutConfig": {}
				},
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "QuickFilter_DateRange",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(QuickFilter_DateRange_config_caption)#",
						"hint": "",
						"icon": "date",
						"iconPosition": "left-icon",
						"defaultValue": "[#currentMonth#]"
					},
					"filterType": "date-range",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "QuickFilter_DateRange_Items",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "Items",
													"filterColumn": "CreatedOn"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							}
						],
						"from": "QuickFilter_DateRange_Value"
					},
					"visible": true
				},
				"parentName": "FilterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "WebhooksLogGrid",
				"values": {
					"type": "crt.DataGrid",
					"rowToolbarItems": [
						{
							"type": "crt.MenuItem",
							"caption": "#ResourceString(DeleteActionCaption)#",
							"icon": "delete-row-action",
							"visible": true,
							"clicked": {
								"request": "crt.DeleteRecordRequest",
								"params": {
									"itemsAttributeName": "Items",
									"recordId": "$Items.DataTableDS_Id"
								},
								"useRelativeContext": false
							}
						}
					],
					"placeholder": [
						{
							"type": "crt.Placeholder",
							"image": {
								"type": "animation",
								"name": "search"
							},
							"title": "#ResourceString(FilteredEmptySectionPlaceholderTitle)#",
							"subhead": "#ResourceString(FilteredEmptySectionPlaceholderSubHead)#",
							"visible": "$DataTable_NoFilteredItems"
						},
						{
							"type": "crt.Placeholder",
							"image": {
								"type": "animation",
								"name": "cat"
							},
							"title": "#ResourceString(EmptySectionPlaceholderTitle)#",
							"subhead": "#ResourceString(EmptySectionPlaceholderSubHead)#",
							"visible": "$DataTable_NoItems"
						}
					],
					"columns": [
						{
							"id": "2d6b85c6-efd4-7a4f-0c9a-67b37aa8bb2e",
							"code": "DataTableDS_CreatedOn",
							"path": "CreatedOn",
							"caption": "#ResourceString(DataTableDS_CreatedOn)#",
							"dataValueType": 7,
							"width": 175
						},
						{
							"id": "7f362465-4317-b0a9-393f-1d948ac64d36",
							"code": "DataTableDS_Webhook",
							"path": "Webhook",
							"caption": "#ResourceString(DataTableDS_Webhook)#",
							"dataValueType": 10,
							"referenceSchemaName": "Webhook",
							"width": 219
						},
						{
							"id": "e38abf22-76da-8e8c-4d4a-7c40a64afa62",
							"code": "DataTableDS_Message",
							"path": "Message",
							"caption": "#ResourceString(DataTableDS_Message)#",
							"dataValueType": 29,
							"width": 353
						}
					],
					"items": "$Items",
					"layoutConfig": {
						"basis": "100%"
					},
					"classes": [
						"section-data-grid"
					],
					"selectionState": "$DataTable_SelectionState",
					"_selectionOptions": {
						"attribute": "DataTable_SelectionState"
					},
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "DataTableDS_Id",
					"features": {
						"editable": {
							"enable": false,
							"itemsCreation": false
						}
					}
				},
				"parentName": "SectionContentWrapper",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{
			"attributes": {
				"Items": {
					"viewModelConfig": {
						"attributes": {
							"DataTableDS_CreatedOn": {
								"modelConfig": {
									"path": "DataTableDS.CreatedOn"
								}
							},
							"DataTableDS_Webhook": {
								"modelConfig": {
									"path": "DataTableDS.Webhook"
								}
							},
							"DataTableDS_Message": {
								"modelConfig": {
									"path": "DataTableDS.Message"
								}
							},
							"DataTableDS_Id": {
								"modelConfig": {
									"path": "DataTableDS.Id"
								}
							}
						}
					},
					"modelConfig": {
						"filterAttributes": [
							{
								"loadOnChange": true,
								"name": "Items_PredefinedFilter"
							},
							{
								"name": "QuickFilter_DateRange_Items",
								"loadOnChange": true
							}
						],
						"path": "DataTableDS",
						"sortingConfig": {
							"default": [
								{
									"direction": "desc",
									"columnName": "CreatedOn"
								}
							]
						}
					}
				},
				"Items_PredefinedFilter": {
					"value": null
				}
			}
		}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{
			"dataSources": {
				"DataTableDS": {
					"type": "crt.EntityDataSource",
					"scope": "viewElement",
					"config": {
						"entitySchemaName": "WebhookLog",
						"attributes": {
							"CreatedOn": {
								"path": "CreatedOn"
							},
							"Webhook": {
								"path": "Webhook"
							},
							"Message": {
								"path": "Message"
							}
						}
					}
				}
			}
		}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});
