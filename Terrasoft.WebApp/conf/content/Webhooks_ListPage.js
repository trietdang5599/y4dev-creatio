Terrasoft.configuration.Structures["Webhooks_ListPage"] = {innerHierarchyStack: ["Webhooks_ListPage"], structureParent: "ListFreedomTemplate"};
define('Webhooks_ListPageStructure', ['Webhooks_ListPageResources'], function(resources) {return {schemaUId:'82f15a06-b021-45a9-a3e8-07bcdc75ef03',schemaCaption: "Webhooks list page", parentSchemaName: "ListFreedomTemplate", packageName: "WebhookService", schemaName:'Webhooks_ListPage',parentSchemaUId:'3f1f3f38-a0a4-4549-b895-249fb08f554a',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("Webhooks_ListPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "MainHeader",
				"values": {
					"padding": {
						"top": "large",
						"right": "large",
						"bottom": "medium",
						"left": "large"
					},
					"direction": "column",
					"justifyContent": "start",
					"alignItems": "stretch",
					"visible": true,
					"borderRadius": "none",
					"gap": "small",
					"stretch": false
				}
			},
			{
				"operation": "merge",
				"name": "TitleContainer",
				"values": {
					"justifyContent": "space-between",
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"gap": "small",
					"wrap": "wrap"
				}
			},
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"layoutConfig": {}
				}
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
					"justifyContent": "start",
					"alignItems": "stretch",
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
				"name": "ConnectWebhooksButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_tm5wk65_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": false,
					"clicked": {
						"request": "crt.OpenPageRequest",
						"params": {
							"schemaName": "LandingiDesigner_Page"
						}
					},
					"clickMode": "default",
					"icon": "webhooks-integration-button-icon"
				},
				"parentName": "TitleContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MainFilterContainer",
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
				"index": 1
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
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"alignItems": "center",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "MainFilterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FolderTreeQuickFilter",
				"values": {
					"type": "crt.FolderTreeActions",
					"folderTree": "FolderTree",
					"layoutConfig": {}
				},
				"parentName": "FilterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "WebhookStatusQuickFilter",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(WebhookStatusQuickFilter_config_caption)#",
						"hint": "",
						"icon": "filter-column-icon",
						"iconPosition": "left-icon",
						"defaultValue": [],
						"entitySchemaName": "WebhookStatus",
						"recordsFilter": null
					},
					"filterType": "lookup",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "WebhookStatusQuickFilter_DataGrid_6m6ky7l",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "DataGrid_6m6ky7l",
													"filterColumn": "Status"
												},
												"quickFilterType": "lookup"
											}
										]
									}
								]
							},
							{
								"attribute": "WebhookStatusQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"filterColumn": "Status"
												},
												"quickFilterType": "lookup"
											}
										]
									}
								]
							}
						],
						"from": "WebhookStatusQuickFilter_Value"
					},
					"visible": true
				},
				"parentName": "FilterContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DateRangeQuickFilter",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(DateRangeQuickFilter_config_caption)#",
						"hint": "",
						"icon": "date",
						"iconPosition": "left-icon",
						"defaultValue": "[#currentMonth#]"
					},
					"filterType": "date-range",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "DateRangeQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"filterColumnStart": "CreatedOn",
													"filterColumnEnd": "CreatedOn"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							},
							{
								"attribute": "DateRangeQuickFilter_IndicatorWidget_bjb3cer_c4cbf6704261bcdb0a9ceb821ad0bd79",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "IndicatorWidget_bjb3cer_c4cbf6704261bcdb0a9ceb821ad0bd79",
													"filterColumnStart": "CreatedOn",
													"filterColumnEnd": "CreatedOn"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							},
							{
								"attribute": "DateRangeQuickFilter_IndicatorWidget_22ylllo_a510b83830662ea4e0e7cba9c1aa938b",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "IndicatorWidget_22ylllo_a510b83830662ea4e0e7cba9c1aa938b",
													"filterColumnStart": "CreatedOn",
													"filterColumnEnd": "CreatedOn"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							},
							{
								"attribute": "DateRangeQuickFilter_IndicatorWidget_r66edu6_56270232d3a526acea645218bd4331fc",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "IndicatorWidget_r66edu6_56270232d3a526acea645218bd4331fc",
													"filterColumnStart": "CreatedOn",
													"filterColumnEnd": "CreatedOn"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							},
							{
								"attribute": "DateRangeQuickFilter_DataGrid_6m6ky7l",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "DataGrid_6m6ky7l",
													"filterColumnStart": "CreatedOn",
													"filterColumnEnd": "CreatedOn"
												},
												"quickFilterType": "date-range"
											}
										]
									}
								]
							}
						],
						"from": "DateRangeQuickFilter_Value"
					},
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "FilterContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ButtonToggleGroup_xizrlhp",
				"values": {
					"for": "ToggleTabPanel",
					"fitContent": true,
					"type": "crt.ButtonToggleGroup",
					"layoutConfig": {}
				},
				"parentName": "MainFilterContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FolderTree",
				"values": {
					"type": "crt.FolderTree",
					"sourceSchemaName": "FolderTree",
					"rootSchemaName": "Webhook",
					"layoutConfig": {
						"width": 328
					},
					"classes": [
						"section-folder-tree"
					],
					"_filterOptions": {
						"expose": [
							{
								"attribute": "FolderTree_active_folder_filter",
								"converters": [
									{
										"converter": "crt.FolderTreeActiveFilterAttributeConverter",
										"args": [
											"Webhook"
										]
									}
								]
							}
						],
						"from": [
							"FolderTree_items",
							"FolderTree_favoriteItems",
							"FolderTree_active_folder_id"
						]
					},
					"borderRadius": "medium"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataFlexContainer",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap",
					"stretch": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataChartsContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "small",
						"rowGap": "small"
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
					},
					"alignItems": "stretch"
				},
				"parentName": "DataFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "IndicatorWidgetFlex",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "DataChartsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UndeliveredWebhookGrid",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "small",
						"right": "medium",
						"bottom": "extra-small",
						"left": "medium"
					},
					"color": "#D2310D",
					"borderRadius": "medium",
					"visible": "$DisplayUnprocessedWebhooks",
					"alignItems": "stretch"
				},
				"parentName": "IndicatorWidgetFlex",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UndeliveredWebhookFlexContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
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
						"top": "extra-small",
						"right": "none",
						"bottom": "small",
						"left": "none"
					},
					"alignItems": "center",
					"justifyContent": "space-between",
					"gap": "extra-small",
					"wrap": "wrap"
				},
				"parentName": "UndeliveredWebhookGrid",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UndeliveredWebhookContainerLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(UndeliveredWebhookContainerLabel_caption)#)#",
					"labelType": "body-large",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#FFFFFF",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "UndeliveredWebhookFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RefreshUndeliveredWebhooksFlexContainer",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(RefreshUndeliveredWebhooksFlexContainer_caption)#",
					"color": "warn",
					"disabled": false,
					"size": "small",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "reload-icon",
					"clicked": {
						"request": "crt.RefreshUnprocessedWebhooksCountRequest"
					}
				},
				"parentName": "UndeliveredWebhookFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UndeliveredWebhookBodyContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
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
						"top": "extra-small",
						"right": "none",
						"bottom": "small",
						"left": "none"
					},
					"alignItems": "center",
					"justifyContent": "space-between",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "UndeliveredWebhookGrid",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UndeliveredWebhookLabel",
				"values": {
					"type": "crt.Label",
					"caption": "$UnprocessedWebhooksCount",
					"labelType": "large-4",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "#FFFFFF",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "UndeliveredWebhookBodyContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "OpenMiniPageButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(OpenMiniPageButton_caption)#",
					"color": "warn",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": true,
					"clicked": {
						"request": "crt.OpenPageRequest",
						"params": {
							"schemaName": "UndeliveredWebhooks_MiniPage"
						}
					},
					"clickMode": "default",
					"icon": null
				},
				"parentName": "UndeliveredWebhookBodyContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "TotalIndicatorWidget",
				"values": {
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(TotalIndicatorWidget_title)#",
						"data": {
							"providing": {
								"attribute": "IndicatorWidget_bjb3cer_c4cbf6704261bcdb0a9ceb821ad0bd79",
								"schemaName": "Webhook",
								"filters": {
									"filter": {
										"items": {},
										"logicalOperation": 1,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Webhook"
									},
									"filterAttributes": [
										{
											"attribute": "DateRangeQuickFilter_IndicatorWidget_bjb3cer_c4cbf6704261bcdb0a9ceb821ad0bd79",
											"loadOnChange": true
										}
									]
								},
								"aggregation": {
									"column": {
										"orderDirection": 0,
										"orderPosition": -1,
										"isVisible": true,
										"expression": {
											"expressionType": 1,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											},
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2
										}
									}
								},
								"dependencies": []
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"dataSourceConfig": {
							"entitySchemaName": "Webhook",
							"attributes": {
								"CreatedOn": {
									"path": "CreatedOn"
								},
								"Status": {
									"path": "Status"
								},
								"WebhookSource": {
									"path": "WebhookSource"
								},
								"RequestBody": {
									"path": "RequestBody"
								}
							}
						},
						"text": {
							"template": "#ResourceString(TotalIndicatorWidget_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "blue"
						},
						"theme": "without-fill"
					},
					"visible": true,
					"sectionBindingColumnRecordId": "$Id"
				},
				"parentName": "IndicatorWidgetFlex",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DoneIndicatorWidget",
				"values": {
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(DoneIndicatorWidget_title)#",
						"data": {
							"providing": {
								"attribute": "IndicatorWidget_22ylllo_a510b83830662ea4e0e7cba9c1aa938b",
								"schemaName": "Webhook",
								"filters": {
									"filter": {
										"items": {
											"ff212118-99a1-4447-820d-b305c03d0465": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Status"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "WebhookStatus",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Done",
																"Id": "7c3648e4-fbb1-4285-8f2c-dddfd3d7f0fd",
																"value": "7c3648e4-fbb1-4285-8f2c-dddfd3d7f0fd",
																"displayValue": "Done"
															}
														}
													}
												]
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Webhook"
									},
									"filterAttributes": [
										{
											"attribute": "DateRangeQuickFilter_IndicatorWidget_22ylllo_a510b83830662ea4e0e7cba9c1aa938b",
											"loadOnChange": true
										}
									]
								},
								"aggregation": {
									"column": {
										"orderDirection": 0,
										"orderPosition": -1,
										"isVisible": true,
										"expression": {
											"expressionType": 1,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											},
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2
										}
									}
								},
								"dependencies": []
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"dataSourceConfig": {
							"entitySchemaName": "Webhook",
							"attributes": {
								"CreatedOn": {
									"path": "CreatedOn"
								},
								"Status": {
									"path": "Status"
								},
								"WebhookSource": {
									"path": "WebhookSource"
								},
								"RequestBody": {
									"path": "RequestBody"
								}
							}
						},
						"text": {
							"template": "#ResourceString(DoneIndicatorWidget_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "green"
						},
						"theme": "without-fill"
					},
					"sectionBindingColumnRecordId": "$Id"
				},
				"parentName": "IndicatorWidgetFlex",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FailedIndicatorWidget",
				"values": {
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(FailedIndicatorWidget_title)#",
						"data": {
							"providing": {
								"attribute": "IndicatorWidget_r66edu6_56270232d3a526acea645218bd4331fc",
								"schemaName": "Webhook",
								"filters": {
									"filter": {
										"items": {
											"19011ca7-44d9-42ef-a3b0-ffbbb567dd36": {
												"filterType": 4,
												"comparisonType": 3,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "Status"
												},
												"isAggregative": false,
												"dataValueType": 10,
												"referenceSchemaName": "WebhookStatus",
												"rightExpressions": [
													{
														"expressionType": 2,
														"parameter": {
															"dataValueType": 10,
															"value": {
																"Name": "Failed",
																"Id": "266e78e8-6b57-4193-b86c-82d6d09361da",
																"value": "266e78e8-6b57-4193-b86c-82d6d09361da",
																"displayValue": "Failed"
															}
														}
													}
												]
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "Webhook"
									},
									"filterAttributes": [
										{
											"attribute": "DateRangeQuickFilter_IndicatorWidget_r66edu6_56270232d3a526acea645218bd4331fc",
											"loadOnChange": true
										}
									]
								},
								"aggregation": {
									"column": {
										"orderDirection": 0,
										"orderPosition": -1,
										"isVisible": true,
										"expression": {
											"expressionType": 1,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											},
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2
										}
									}
								},
								"dependencies": []
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(FailedIndicatorWidget_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "medium"
						},
						"layout": {
							"color": "orange"
						},
						"theme": "without-fill"
					},
					"visible": true
				},
				"parentName": "IndicatorWidgetFlex",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "WebhookDynamicsChartWidget",
				"values": {
					"visible": "$ShowChart",
					"layoutConfig": {
						"column": 3,
						"row": 1,
						"colSpan": 5,
						"rowSpan": 1
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(WebhookDynamicsChartWidget_title)#",
						"color": "navy-blue",
						"theme": "without-fill",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "#ResourceString(WebhookDynamicsChartWidget_xAxis)#",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "#ResourceString(WebhookDynamicsChartWidget_yAxis)#",
								"formatting": {
									"type": "number",
									"thousandAbbreviation": {
										"enabled": true
									}
								}
							}
						},
						"series": [
							{
								"color": "navy-blue",
								"type": "line",
								"label": "#ResourceString(WebhookDynamicsChartWidget_series_0)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"attribute": "ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
										"schemaName": "Webhook",
										"filters": {
											"filter": {
												"items": {
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Webhook"
											},
											"filterAttributes": [
												{
													"attribute": "DateRangeQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"loadOnChange": true
												},
												{
													"attribute": "WebhookStatusQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"loadOnChange": true
												}
											]
										},
										"aggregation": {
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 1,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													},
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2
												}
											}
										},
										"dependencies": [],
										"rowCount": 50,
										"grouping": {
											"type": "by-date-part",
											"column": [
												{
													"orderDirection": 0,
													"orderPosition": -1,
													"isVisible": true,
													"expression": {
														"expressionType": 1,
														"functionArgument": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"functionType": 3,
														"datePartType": 1
													}
												},
												{
													"orderDirection": 0,
													"orderPosition": -1,
													"isVisible": true,
													"expression": {
														"expressionType": 1,
														"functionArgument": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"functionType": 3,
														"datePartType": 3
													}
												}
											]
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"decimalPrecision": 0,
										"thousandSeparator": ","
									}
								},
								"dataLabel": {
									"display": false
								}
							},
							{
								"color": "green",
								"type": "bar",
								"label": "#ResourceString(WebhookDynamicsChartWidget_series_1)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"attribute": "WebhookDynamicsChartWidget_SeriesData_1",
										"schemaName": "Webhook",
										"filters": {
											"filter": {
												"items": {
													"eaa58224-b54c-4936-a9c9-1989e17a16fc": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Status"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "WebhookStatus",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Готово",
																		"Id": "7c3648e4-fbb1-4285-8f2c-dddfd3d7f0fd",
																		"value": "7c3648e4-fbb1-4285-8f2c-dddfd3d7f0fd",
																		"displayValue": "Готово"
																	}
																}
															}
														]
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Webhook"
											},
											"filterAttributes": [
												{
													"attribute": "DateRangeQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"loadOnChange": true
												},
												{
													"attribute": "WebhookStatusQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"loadOnChange": true
												}
											]
										},
										"aggregation": {
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 1,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													},
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2
												}
											}
										},
										"dependencies": [],
										"rowCount": 50,
										"grouping": {
											"type": "by-date-part",
											"column": [
												{
													"orderDirection": 0,
													"orderPosition": -1,
													"isVisible": true,
													"expression": {
														"expressionType": 1,
														"functionArgument": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"functionType": 3,
														"datePartType": 1
													}
												},
												{
													"orderDirection": 0,
													"orderPosition": -1,
													"isVisible": true,
													"expression": {
														"expressionType": 1,
														"functionArgument": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"functionType": 3,
														"datePartType": 3
													}
												}
											]
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"decimalPrecision": 0,
										"thousandSeparator": ","
									}
								},
								"dataLabel": {
									"display": false
								}
							},
							{
								"color": "orange",
								"type": "bar",
								"label": "#ResourceString(WebhookDynamicsChartWidget_series_2)#",
								"legend": {
									"enabled": true
								},
								"data": {
									"providing": {
										"attribute": "WebhookDynamicsChartWidget_SeriesData_2",
										"schemaName": "Webhook",
										"filters": {
											"filter": {
												"items": {
													"eaa58224-b54c-4936-a9c9-1989e17a16fc": {
														"filterType": 4,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "Status"
														},
														"isAggregative": false,
														"dataValueType": 10,
														"referenceSchemaName": "WebhookStatus",
														"rightExpressions": [
															{
																"expressionType": 2,
																"parameter": {
																	"dataValueType": 10,
																	"value": {
																		"Name": "Ошибка",
																		"Id": "266e78e8-6b57-4193-b86c-82d6d09361da",
																		"value": "266e78e8-6b57-4193-b86c-82d6d09361da",
																		"displayValue": "Ошибка"
																	}
																}
															}
														]
													},
													"columnIsNotNullFilter": {
														"comparisonType": 2,
														"filterType": 2,
														"isEnabled": true,
														"isNull": false,
														"trimDateTimeParameterToDate": false,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "Webhook"
											},
											"filterAttributes": [
												{
													"attribute": "DateRangeQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"loadOnChange": true
												},
												{
													"attribute": "WebhookStatusQuickFilter_ChartWidget_adnuhcw_077fc2fc9bddd5a2a2d58272f002a55b",
													"loadOnChange": true
												}
											]
										},
										"aggregation": {
											"column": {
												"orderDirection": 0,
												"orderPosition": -1,
												"isVisible": true,
												"expression": {
													"expressionType": 1,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													},
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2
												}
											}
										},
										"dependencies": [],
										"rowCount": 50,
										"grouping": {
											"type": "by-date-part",
											"column": [
												{
													"orderDirection": 0,
													"orderPosition": -1,
													"isVisible": true,
													"expression": {
														"expressionType": 1,
														"functionArgument": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"functionType": 3,
														"datePartType": 1
													}
												},
												{
													"orderDirection": 0,
													"orderPosition": -1,
													"isVisible": true,
													"expression": {
														"expressionType": 1,
														"functionArgument": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"functionType": 3,
														"datePartType": 3
													}
												}
											]
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"decimalPrecision": 0,
										"thousandSeparator": ","
									}
								},
								"dataLabel": {
									"display": false
								}
							}
						],
						"seriesOrder": {
							"type": "by-grouping-value",
							"direction": 1
						}
					},
					"sectionBindingColumnRecordId": "$Id"
				},
				"parentName": "DataChartsContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
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
					"stretch": true
				},
				"parentName": "DataFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridHeaderContainer",
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
					"justifyContent": "start",
					"alignItems": "center",
					"gap": "small",
					"wrap": "wrap",
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(GridLabel_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "GridHeaderContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridActionsContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {}
				},
				"parentName": "GridHeaderContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridAcionButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridAcionButton_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": [],
					"layoutConfig": {},
					"visible": true
				},
				"parentName": "GridActionsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MenuItem_yhiv1sr",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_yhiv1sr_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataGrid",
							"filters": "$DataGrid_6m6ky7l | crt.ToCollectionFilters : 'DataGrid_6m6ky7l' : $DataGrid_6m6ky7l_SelectionState"
						}
					},
					"visible": true
				},
				"parentName": "GridAcionButton",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MenuItem_stn1mjo",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_stn1mjo_caption)#",
					"icon": "newspaper-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.OpenPageRequest",
						"params": {
							"schemaName": "WebhooksLog_ListPage"
						}
					},
					"visible": true
				},
				"parentName": "GridAcionButton",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridRefreshButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridRefreshButton_caption)#",
					"icon": "reload-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"dataSourceName": "DataGrid_6m6ky7lDS"
						}
					},
					"visible": true,
					"clickMode": "default"
				},
				"parentName": "GridActionsContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridSearchFilter",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(GridSearchFilter_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "GridSearchFilter_DataGrid_6m6ky7l",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"DataGrid_6m6ky7l"
										]
									}
								]
							}
						],
						"from": [
							"GridSearchFilter_SearchValue",
							"GridSearchFilter_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "GridActionsContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "DataGrid",
				"values": {
					"type": "crt.DataGrid",
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true
							}
						},
						"editable": {
							"enable": false,
							"itemsCreation": false
						}
					},
					"items": "$DataGrid_6m6ky7l",
					"selectionState": "$DataGrid_6m6ky7l_SelectionState",
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "DataGrid_6m6ky7lDS_Id",
					"rowToolbarItems": [
						{
							"type": "crt.MenuItem",
							"caption": "#ResourceString(OpenActionCaption)#",
							"icon": "edit-row-action",
							"visible": true,
							"clicked": {
								"request": "crt.UpdateRecordRequest",
								"params": {
									"itemsAttributeName": "DataGrid_6m6ky7l",
									"recordId": "$DataGrid_6m6ky7l.DataGrid_6m6ky7lDS_Id"
								},
								"useRelativeContext": true
							}
						},
						{
							"type": "crt.MenuItem",
							"caption": "#ResourceString(DeleteActionCaption)#",
							"icon": "delete-row-action",
							"visible": true,
							"clicked": {
								"request": "crt.DeleteRecordRequest",
								"params": {
									"itemsAttributeName": "DataGrid_6m6ky7l",
									"recordId": "$DataGrid_6m6ky7l.DataGrid_6m6ky7lDS_Id"
								},
								"useRelativeContext": false
							}
						}
					],
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 12
					},
					"classes": [
						"section-data-grid"
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
							"visible": "$DataGrid_NoFilteredItems"
						},
						{
							"type": "crt.Placeholder",
							"image": {
								"type": "animation",
								"name": "cat"
							},
							"title": "#ResourceString(EmptySectionPlaceholderTitle)#",
							"subhead": "#ResourceString(EmptySectionPlaceholderSubHead)#",
							"visible": "$DataGrid_NoItems"
						}
					],
					"columns": [
						{
							"id": "8fe2e2b9-2708-c292-b780-32ca80087372",
							"code": "DataGrid_6m6ky7lDS_CreatedOn",
							"path": "CreatedOn",
							"caption": "#ResourceString(DataGrid_6m6ky7lDS_CreatedOn)#",
							"dataValueType": 7,
							"width": 165
						},
						{
							"id": "aaa35f25-2a4a-a967-83cd-b21ee0169e31",
							"code": "DataGrid_6m6ky7lDS_Status",
							"path": "Status",
							"caption": "#ResourceString(DataGrid_6m6ky7lDS_Status)#",
							"dataValueType": 10,
							"referenceSchemaName": "WebhookStatus",
							"width": 116
						},
						{
							"id": "49460b40-58dc-4835-7d0b-4c38fde272e8",
							"code": "DataGrid_6m6ky7lDS_WebhookSource",
							"path": "WebhookSource",
							"caption": "#ResourceString(DataGrid_6m6ky7lDS_WebhookSource)#",
							"dataValueType": 30,
							"width": 159
						},
						{
							"id": "ba5312f6-5e17-ffcf-1c1b-6b2ed224bbc1",
							"code": "DataGrid_6m6ky7lDS_RequestBody",
							"path": "RequestBody",
							"caption": "#ResourceString(DataGrid_6m6ky7lDS_RequestBody)#",
							"dataValueType": 29,
							"width": 1649
						}
					],
					"stretch": true,
					"bulkActions": [],
					"_selectionOptions": {
						"attribute": "DataGrid_6m6ky7l_SelectionState"
					}
				},
				"parentName": "GridContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "DataGrid_ExportToExcelBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Export to Excel",
					"icon": "export-button-icon",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataGrid",
							"filters": "$DataGrid_6m6ky7l | crt.ToCollectionFilters : 'DataGrid_6m6ky7l' : $DataGrid_6m6ky7l_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_6m6ky7l_SelectionState"
						}
					}
				},
				"parentName": "DataGrid",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGrid_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Delete",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "DataGrid_6m6ky7lDS",
							"filters": "$DataGrid_6m6ky7l | crt.ToCollectionFilters : 'DataGrid_6m6ky7l' : $DataGrid_6m6ky7l_SelectionState | crt.SkipIfSelectionEmpty : $DataGrid_6m6ky7l_SelectionState"
						}
					}
				},
				"parentName": "DataGrid",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ToggleTabPanel",
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
						"width": 368
					},
					"visible": true,
					"stretch": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "HelpTabContainer",
				"values": {
					"type": "crt.TabContainer",
					"tools": [],
					"items": [],
					"caption": "#ResourceString(HelpTabContainer_caption)#",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "open-book-tab-icon"
				},
				"parentName": "ToggleTabPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpTabHeaderContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "HelpTabContainer",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpTabHeaderLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_xls3uj6_caption)#)#",
					"labelType": "headline-2",
					"labelThickness": "semibold",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpTabHeaderContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpTabDataContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "HelpTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpDataContainer1GeneralInfo",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true
				},
				"parentName": "HelpTabDataContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel1",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpTabDataLabel1_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "HelpDataContainer1GeneralInfo",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel2",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpTabDataLabel2_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "HelpTabDataContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpDataContainer1ListOfRequirements",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "nowrap"
				},
				"parentName": "HelpTabDataContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer1",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "nowrap"
				},
				"parentName": "HelpDataContainer1ListOfRequirements",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemBullit1",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_pm3dklv_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer1",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_mn9u0qt",
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
						"left": "small"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "wrap"
				},
				"parentName": "HelpDataListItemContainer1",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemText1_1",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookRequirementItemText1_1_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "FlexContainer_mn9u0qt",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemTextContainer",
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
						"right": "small",
						"bottom": "none",
						"left": "small"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "wrap"
				},
				"parentName": "FlexContainer_mn9u0qt",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemText1_2",
				"values": {
					"type": "crt.Link",
					"caption": "#ResourceString(Label_7habo7b_caption)#",
					"href": "#Page/LandingiDesigner_Page",
					"visible": true,
					"layoutConfig": {},
					"linkType": "body"
				},
				"parentName": "HelpWebhookRequirementItemTextContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemText1_3",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookRequirementItemText1_3_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "FlexContainer_mn9u0qt",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer2",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "HelpDataContainer1ListOfRequirements",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemBullit2",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_23a6gea_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer2",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemText2",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookRequirementItemText2_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer2",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer3",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "HelpDataContainer1ListOfRequirements",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemBullit3",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_e52xppb_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer3",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemText3",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookRequirementItemText3_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer3",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_w709xay",
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
						"left": "medium"
					},
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "nowrap"
				},
				"parentName": "HelpDataContainer1ListOfRequirements",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer4",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap",
					"layoutConfig": {}
				},
				"parentName": "FlexContainer_w709xay",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemBullit4",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_z2h0x3a_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer4",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemText4",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookRequirementItemText4_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer4",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer5",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap",
					"layoutConfig": {}
				},
				"parentName": "FlexContainer_w709xay",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemBullit5",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_ekem5kk_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer5",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookRequirementItemText5",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookRequirementItemText5_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer5",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpDataContainer3Example",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "HelpTabDataContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel3",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpTabDataLabel3_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "HelpDataContainer3Example",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_ihf37jl",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"right": "large",
						"bottom": "medium",
						"left": "large"
					},
					"color": "primary",
					"borderRadius": "medium",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "HelpDataContainer3Example",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Label_nrszjiz",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_nrszjiz_caption)#)#",
					"labelType": "placeholder",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "GridContainer_ihf37jl",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel4",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpTabDataLabel4_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "HelpDataContainer3Example",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "HelpDataContainer4FootnoteExample",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "nowrap",
					"layoutConfig": {}
				},
				"parentName": "HelpDataContainer3Example",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer6",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "HelpDataContainer4FootnoteExample",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookFornoteItemBullit1",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_i4kvftd_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer6",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookFornoteItemText1",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookFornoteItemText1_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer6",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer7",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "HelpDataContainer4FootnoteExample",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpWebhookFornoteItemBullit2",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_35jjfa5_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer7",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookFornoteItemText2",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookFornoteItemText2_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer7",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpDataListItemContainer8",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "HelpDataContainer4FootnoteExample",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "HelpWebhookFornoteItemBullit3",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_0a06vv6_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer8",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpWebhookFornoteItemText3",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpWebhookFornoteItemText3_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpDataListItemContainer8",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel5WebhookSection",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpTabDataLabel5WebhookSection_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpTabDataContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel6CustomizeWebhook",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpTabDataLabel6CustomizeWebhook_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "HelpTabDataContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "HelpDataContainer1LearnMore",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"wrap": "wrap"
				},
				"parentName": "HelpTabDataContainer",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel7LearnMore",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(HelpTabDataLabel7LearnMore_caption)#)#",
					"labelType": "body",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "HelpDataContainer1LearnMore",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "HelpTabDataLabel7LearnMoreLink",
				"values": {
					"type": "crt.Link",
					"caption": "#ResourceString(Label_mkoc91k_caption)#",
					"href": "https://academy.creatio.com/documents?id=2411",
					"target": "_blank",
					"visible": true,
					"layoutConfig": {},
					"linkType": "body"
				},
				"parentName": "HelpDataContainer1LearnMore",
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
					"ItemsSorting": {},
					"FolderTree_visible": {
						"value": false
					},
					"FolderTree_items": {
						"isCollection": true,
						"viewModelConfig": {
							"attributes": {
								"Id": {
									"modelConfig": {
										"path": "FolderTree_items_DS.Id"
									}
								},
								"Name": {
									"modelConfig": {
										"path": "FolderTree_items_DS.Name"
									}
								},
								"ParentId": {
									"modelConfig": {
										"path": "FolderTree_items_DS.Parent.Id"
									}
								},
								"FilterData": {
									"modelConfig": {
										"path": "FolderTree_items_DS.FilterData"
									}
								}
							}
						},
						"modelConfig": {
							"path": "FolderTree_items_DS",
							"filterAttributes": [
								{
									"name": "FolderTree_items_DS_filter",
									"loadOnChange": true
								}
							]
						},
						"embeddedModel": {
							"config": {
								"type": "crt.EntityDataSource",
								"config": {
									"entitySchemaName": "FolderTree"
								}
							},
							"name": "FolderTree_items_DS"
						}
					},
					"FolderTree_active_folder_id": {},
					"FolderTree_active_folder_name": {},
					"FolderTree_items_DS_filter": {
						"value": {
							"isEnabled": true,
							"trimDateTimeParameterToDate": false,
							"filterType": 6,
							"logicalOperation": 0,
							"items": {
								"3714ebf4-41a3-9a82-8e8b-039d9ac03ce1": {
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"filterType": 1,
									"comparisonType": 3,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "EntitySchemaName"
									},
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 1,
											"value": "Webhook"
										}
									}
								}
							}
						}
					},
					"DataGrid_6m6ky7l": {
						"isCollection": true,
						"modelConfig": {
							"path": "DataGrid_6m6ky7lDS",
							"filterAttributes": [
								{
									"name": "WebhookStatusQuickFilter_DataGrid_6m6ky7l",
									"loadOnChange": true
								},
								{
									"name": "FolderTree_active_folder_filter",
									"loadOnChange": true
								},
								{
									"name": "DateRangeQuickFilter_DataGrid_6m6ky7l",
									"loadOnChange": true
								},
								{
									"name": "GridSearchFilter_DataGrid_6m6ky7l",
									"loadOnChange": true
								}
							],
							"sortingConfig": {
								"default": [
									{
										"direction": "desc",
										"columnName": "CreatedOn"
									}
								]
							}
						},
						"viewModelConfig": {
							"attributes": {
								"DataGrid_6m6ky7lDS_CreatedOn": {
									"modelConfig": {
										"path": "DataGrid_6m6ky7lDS.CreatedOn"
									}
								},
								"DataGrid_6m6ky7lDS_Status": {
									"modelConfig": {
										"path": "DataGrid_6m6ky7lDS.Status"
									}
								},
								"DataGrid_6m6ky7lDS_WebhookSource": {
									"modelConfig": {
										"path": "DataGrid_6m6ky7lDS.WebhookSource"
									}
								},
								"DataGrid_6m6ky7lDS_RequestBody": {
									"modelConfig": {
										"path": "DataGrid_6m6ky7lDS.RequestBody"
									}
								},
								"DataGrid_6m6ky7lDS_Id": {
									"modelConfig": {
										"path": "DataGrid_6m6ky7lDS.Id"
									}
								}
							}
						}
					},
					"DataGrid_NoItems": {
						"from": [
							"DataGrid_6m6ky7l"
						],
						"converter": "crt.DataGridHasNoItems"
					},
					"DataGrid_NoFilteredItems": {
						"from": [
							"DataGrid_6m6ky7l"
						],
						"converter": "crt.DataGridHasNoFilteredItems"
					},
					"ShowChart": {
						"value": true
					},
					"DisplayUnprocessedWebhooks": {
						"value": false
					},
					"UnprocessedWebhooksCount": {
						"value": 0
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
							"default": [
								{
									"direction": "asc",
									"columnName": "Status"
								}
							]
						},
						"filterAttributes": []
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Items",
					"viewModelConfig",
					"attributes"
				],
				"values": {
					"PDS_CreatedOn": {
						"modelConfig": {
							"path": "PDS.CreatedOn"
						}
					},
					"PDS_Status": {
						"modelConfig": {
							"path": "PDS.Status"
						}
					},
					"PDS_WebhookSource": {
						"modelConfig": {
							"path": "PDS.WebhookSource"
						}
					},
					"PDS_RequestBody": {
						"modelConfig": {
							"path": "PDS.RequestBody"
						}
					},
					"PDS_Id": {
						"modelConfig": {
							"path": "PDS.Id"
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
						"PDS": {
							"type": "crt.EntityDataSource",
							"hiddenInPageDesigner": true,
							"config": {
								"entitySchemaName": "Webhook",
								"attributes": {
									"CreatedOn": {
										"path": "CreatedOn"
									},
									"Status": {
										"path": "Status"
									},
									"WebhookSource": {
										"path": "WebhookSource"
									},
									"RequestBody": {
										"path": "RequestBody"
									}
								}
							},
							"scope": "viewElement"
						},
						"GridDetail_hhyvuimDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "Webhook",
								"attributes": {
									"WebhookSource": {
										"path": "WebhookSource"
									}
								}
							}
						},
						"DataGrid_amz2iaaDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "Webhook",
								"attributes": {
									"WebhookSource": {
										"path": "WebhookSource"
									}
								}
							}
						},
						"GridDetail_zvyst74DS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "Webhook",
								"attributes": {
									"CreatedOn": {
										"path": "CreatedOn"
									},
									"Status": {
										"path": "Status"
									},
									"WebhookSource": {
										"path": "WebhookSource"
									},
									"RequestBody": {
										"path": "RequestBody"
									}
								}
							}
						},
						"DataGrid_6m6ky7lDS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "Webhook",
								"attributes": {
									"CreatedOn": {
										"path": "CreatedOn"
									},
									"Status": {
										"path": "Status"
									},
									"WebhookSource": {
										"path": "WebhookSource"
									},
									"RequestBody": {
										"path": "RequestBody"
									}
								}
							}
						},
						"DataGrid_43m7ri6DS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "Webhook",
								"attributes": {
									"CreatedOn": {
										"path": "CreatedOn"
									},
									"Status": {
										"path": "Status"
									},
									"WebhookSource": {
										"path": "WebhookSource"
									},
									"RequestBody": {
										"path": "RequestBody"
									}
								}
							}
						},
						"DataGrid_56owsr3DS": {
							"type": "crt.EntityDataSource",
							"scope": "viewElement",
							"config": {
								"entitySchemaName": "Webhook",
								"attributes": {
									"CreatedOn": {
										"path": "CreatedOn"
									},
									"Status": {
										"path": "Status"
									},
									"WebhookSource": {
										"path": "WebhookSource"
									},
									"RequestBody": {
										"path": "RequestBody"
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

