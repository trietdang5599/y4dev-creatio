define("MobileSyncSettings_ListPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "remove",
				"name": "AddButton"
			},
			{
				"operation": "merge",
				"name": "SectionContentWrapper",
				"values": {
					"direction": "row",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "merge",
				"name": "DataTable",
				"values": {
					"columns": [
						{
							"id": "0fc193f2-267a-2b80-dd18-327a555b0bc9",
							"code": "PDS_EntityCaption",
							"path": "EntityCaption",
							"caption": "#ResourceString(PDS_EntityCaption)#",
							"dataValueType": 28,
							"width": 616
						},
						{
							"id": "9afa2796-1f76-5254-59d0-50c944bfe9b6",
							"code": "PDS_IsEnabled",
							"path": "IsEnabled",
							"caption": "#ResourceString(PDS_IsEnabled)#",
							"dataValueType": 12,
							"width": 114
						},
						{
							"id": "dc2fdb35-65e3-0a2f-0048-6dbf5ef59550",
							"code": "PDS_TotalCount",
							"path": "TotalCount",
							"caption": "#ResourceString(PDS_TotalCount)#",
							"dataValueType": 4,
							"width": 175
						},
						{
							"id": "02b9977d-3f12-8ef0-e015-86ea5a626ccb",
							"code": "PDS_Count",
							"path": "Count",
							"caption": "#ResourceString(PDS_Count)#",
							"dataValueType": 4,
							"width": 188
						}
					],
					"layoutConfig": {
						"basis": "100%",
						"width": 300
					},
					"rowToolbarItems": [
						{
							"type": "crt.MenuItem",
							"caption": "#ResourceString(OpenButton_caption)#",
							"icon": "edit-row-action",
							"clicked": {
								"request": "crt.UpdateRecordRequest",
								"params": {
									"itemsAttributeName": "Items",
									"recordId": "$Items.PDS_Id"
								},
								"useRelativeContext": true
							}
						}
					],
					"primaryColumnName": "PDS_Id",
					"sorting": "$ItemsSorting | crt.ToDataTableSortingConfig: 'Items'",
					"features": {
						"editable": false
					},
					"visible": true
				}
			},
			{
				"operation": "insert",
				"name": "Button_scsl26d",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_scsl26d_caption)#",
					"color": "primary",
					"disabled": false,
					"visible": true,
					"clicked": {
						"request": "crt.ClosePageRequest"
					},
					"clickMode": "default"
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ActionsButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ActionsButton_caption)#",
					"color": "default",
					"disabled": false,
					"menuItems": [],
					"clickMode": "menu",
					"size": "large",
					"iconPosition": "only-text",
					"visible": true
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "MenuItem_8m672s8",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(MenuItem_8m672s8_caption)#",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "DataTable"
						}
					},
					"icon": "export-button-icon"
				},
				"parentName": "ActionsButton",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_hyf406i",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"gap": "medium",
					"direction": "row",
					"items": []
				},
				"parentName": "ActionContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SearchFilter_k5h063u",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(SearchFilter_k5h063u_placeholder)#",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "SearchFilter_k5h063u_Items",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"Items"
										]
									}
								]
							}
						],
						"from": [
							"SearchFilter_k5h063u_SearchValue",
							"SearchFilter_k5h063u_FilteredColumnsGroups"
						]
					},
				},
				"parentName": "FlexContainer_hyf406i",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RefreshButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(RefreshButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload"
							},
							"dataSourceName": "PDS"
						}
					},
					"iconPosition": "only-icon",
					"icon": "reload-button-icon",
					"clickMode": "default",
					"visible": true,
					"layoutConfig": {}
				},
				"parentName": "FlexContainer_hyf406i",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{
			"attributes": {
				"Items": {
					"viewModelConfig": {
						"attributes": {
							"PDS_EntityCaption": {
								"modelConfig": {
									"path": "PDS.EntityCaption"
								}
							},
							"PDS_IsEnabled": {
								"modelConfig": {
									"path": "PDS.IsEnabled"
								}
							},
							"PDS_TotalCount": {
								"modelConfig": {
									"path": "PDS.TotalCount"
								}
							},
							"PDS_Count": {
								"modelConfig": {
									"path": "PDS.Count"
								}
							},
							"PDS_Id": {
								"modelConfig": {
									"path": "PDS.Id"
								}
							}
						}
					},
					"modelConfig": {
						"path": "PDS",
						"pagingConfig": {
							"rowCount": 30
						},
						"sortingConfig": {
							"attributeName": "ItemsSorting",
							"default": []
						},
						"filterAttributes": [
							{
								"loadOnChange": true,
								"name": "Items_PredefinedFilter"
							},
							{
								"loadOnChange": true,
								"name": "SearchFilter_k5h063u_Items"
							}
						]
					}
				},
				"ItemsSorting": {},
				"Items_PredefinedFilter": {
					"value": {
						"items": {
							"WorkplaceCodeFilter": {
								"filterType": 1,
								"comparisonType": 3,
								"isEnabled": true,
								"trimDateTimeParameterToDate": false,
								"leftExpression": {
									"expressionType": 0,
									"columnPath": "WorkplaceCode"
								},
								"isAggregative": false,
								"dataValueType": 1,
								"rightExpression": {
									"expressionType": 2,
									"parameter": {
										"dataValueType": 1,
										"value": "DefaultWorkplace"
									}
								}
							}
						},
						"logicalOperation": 0,
						"isEnabled": true,
						"filterType": 6,
						"rootSchemaName": "MobileSyncSett"
					}
				}
			}
		}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{
			"dataSources": {
				"PDS": {
					"type": "crt.EntityDataSource",
					"hiddenInPageDesigner": true,
					"config": {
						"entitySchemaName": "MobileSyncSett",
						"attributes": {
							"EntityCaption": {
								"path": "EntityCaption"
							},
							"IsEnabled": {
								"path": "IsEnabled"
							},
							"TotalCount": {
								"path": "TotalCount"
							},
							"Count": {
								"path": "Count"
							}
						}
					},
					"scope": "viewElement"
				}
			}
		}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: "crt.HandleViewModelInitRequest",
				handler: async (request, next) => {
					const historyStateRequest = {
						type: "crt.7XRequest",
						action: "GetHistoryState",
						$context: request.$context
					};
					const historyState = await this.handlerChain.handlerChain$.process(historyStateRequest);
					const params = historyState.hash.historyState.split("/");
					const workplaceCode = params[params.length - 1];
					const workplaceFilter = Terrasoft.createFilterGroup();
					workplaceFilter.add("WorkplaceCodeFilter", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL, "WorkplaceCode", workplaceCode));
					request.$context.Items_PredefinedFilter = workplaceFilter.serialize();
					return next?.handle(request);
				}
			}
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});