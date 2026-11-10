define("BaseEntityCatalogPage", /**SCHEMA_DEPS*/["css!BaseEntityCatalogPage"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "Main",
				"values": {
					"gap": "none"
				}
			},
			{
				"operation": "merge",
				"name": "MainHeader",
				"values": {
					"padding": {
						"top": "large",
						"right": "large",
						"bottom": "small",
						"left": "large"
					},
					"visible": true,
					"alignItems": "stretch",
					"justifyContent": "start",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "merge",
				"name": "ActionButtonsContainer",
				"values": {
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "small",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"gap": "small"
				}
			},
			{
				"operation": "remove",
				"name": "CloseButton"
			},
			{
				"operation": "remove",
				"name": "SetRecordRightsButton"
			},
			{
				"operation": "remove",
				"name": "MainHeaderBottom"
			},
			{
				"operation": "remove",
				"name": "CardToolsContainer"
			},
			{
				"operation": "remove",
				"name": "CardToggleContainer"
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"padding": {
						"left": "none",
						"right": "none",
						"top": "none",
						"bottom": "none"
					},
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap"
				}
			},
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"type": "crt.FlexContainer",
					"gap": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"fitContent": false,
					"direction": "row",
					"wrap": "nowrap",
					"color": "primary",
					"visible": true,
					"borderRadius": "none",
					"alignItems": "stretch",
					"justifyContent": "start"
				}
			},
			{
				"operation": "remove",
				"name": "CardContentWrapper",
				"properties": [
					"columns",
					"rows"
				]
			},
			{
				"operation": "insert",
				"name": "CatalogToggleContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"wrap": "nowrap",
					"padding": {
						"left": "large",
						"top": "small",
						"right": "none",
						"bottom": "small"
					},
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogButtonToggleGroup",
				"values": {
					"for": "CatalogToggleTabPanel",
					"fitContent": true,
					"type": "crt.ButtonToggleGroup",
					"allowUntoggle": false
				},
				"parentName": "CatalogToggleContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogToggleTabPanel",
				"values": {
					"type": "crt.TabPanel",
					"items": [],
					"mode": "toggle",
					"fitContent": false,
					"styleType": "default",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto",
					"classes": [
						"container-flex-1"
					],
				},
				"parentName": "CardContentWrapper",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogTabContainer",
				"values": {
					"type": "crt.TabContainer",
					"tools": [],
					"items": [],
					"caption": "#ResourceString(CatalogTabContainer_caption)#",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "catalog-icon"
				},
				"parentName": "CatalogToggleTabPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"stretch": true,
					"items": [],
					"fitContent": false,
					"visible": true,
					"color": "primary",
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
				"parentName": "CatalogTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "EntityHierarchyFilter",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 18,
						"width": 320
					},
					"type": "crt.EntityHierarchyFilter",
					"nodesConfig": [],
					"_filterOptions": {
						"expose": [
							{
								"attribute": "EntityHierarchyFilter_Filters",
								"converters": [
									{
										"converter": "crt.ToHierarchyFiltersConverter"
									}
								]
							}
						],
						"from": [
							"EntityHierarchyFilter_SelectedNode",
							"EntityHierarchyFilter_SpecificationFilters"
						]
					}
				},
				"parentName": "CatalogFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogContentFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column",
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "none",
					"wrap": "nowrap",
					"fitContent": false
				},
				"parentName": "CatalogFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CatalogMainFilterContainer",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "none",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "large"
					},
					"alignItems": "stretch"
				},
				"parentName": "CatalogContentFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogFilterFlexContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"wrap": "nowrap",
					"padding": {
						"left": "none",
						"top": "none",
						"right": "none",
						"bottom": "none"
					},
					"visible": true,
					"color": "primary",
					"borderRadius": "none",
					"alignItems": "center",
					"justifyContent": "start",
					"gap": "medium",
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 2,
						"rowSpan": 1
					}
				},
				"parentName": "CatalogMainFilterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogTagFilter",
				"values": {
					"type": "crt.QuickFilter",
					"config": {
						"caption": "#ResourceString(CatalogTagFilter_config_caption)#",
						"hint": "",
						"icon": "tag-icon",
						"iconPosition": "left-icon",
						"defaultValue": [],
						"entitySchemaName": null,
						"recordsFilter": null
					},
					"filterType": "lookup",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "CatalogTagFilter_DataGrid_fqyjxvm",
								"converters": [
									{
										"converter": "crt.QuickFilterAttributeConverter",
										"args": [
											{
												"target": {
													"viewAttributeName": "DataGrid_fqyjxvm",
													"filterColumn": null
												},
												"quickFilterType": "lookup"
											}
										]
									}
								]
							}
						],
						"from": "CatalogTagFilter_Value"
					},
					"visible": true
				},
				"parentName": "CatalogFilterFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CatalogSearchFilter",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(CatalogSearchFilter_placeholder)#",
					"_filterOptions": {
						"expose": [
							{
								"attribute": "CatalogSearchFilter_DataGrid_fqyjxvm",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"DataGrid_fqyjxvm"
										]
									}
								]
							}
						],
						"from": [
							"CatalogSearchFilter_SearchValue",
							"CatalogSearchFilter_FilteredColumnsGroups"
						]
					},
				},
				"parentName": "CatalogFilterFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "EntityCatalogDataGrid",
				"values": {
					"type": "crt.DataGrid",
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": true
							}
						}
					},
					"primaryColumnName": "EntityCatalogDataGridDS_Id",
					"items": "$DataGrid_fqyjxvm",
					"activeRow": "$DataGrid_fqyjxvm_ActiveRow",
					"selectionState": "$DataGrid_fqyjxvm_SelectionState",
					"fitContent": false,
					"classes": [
						"safari-product-catalog-min-height-datagrid-fix"
					],
					"stretch": true,
					"visible": true
				},
				"parentName": "CatalogContentFlexContainer",
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
					"CatalogToggleTabPanel_SelectedItem": {
						"value": {
							"value": "CatalogTabContainer",
							"icon": "catalog-icon",
							"iconPosition": "left-icon",
							"displayValue": "Catalog"
						}
					},
					"DataGrid_fqyjxvm_PredefinedFilter": {
						"value": null
					},
					"DataGrid_fqyjxvm": {
						"isCollection": true,
						"modelConfig": {
							"path": "EntityCatalogDataGridDS",
							"filterAttributes": [
								{
									"loadOnChange": true,
									"name": "DataGrid_fqyjxvm_PredefinedFilter"
								},
								{
									"name": "CatalogTagFilter_DataGrid_fqyjxvm",
									"loadOnChange": true
								},
								{
									"name": "EntityHierarchyFilter_Filters",
									"loadOnChange": true
								},
								{
									"name": "CatalogSearchFilter_DataGrid_fqyjxvm",
									"loadOnChange": true
								}
							]
						},
						"viewModelConfig": {
							"attributes": {
								"EntityCatalogDataGridDS_Id": {
									"modelConfig": {
										"path": "EntityCatalogDataGridDS.Id"
									}
								}
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
						"EntityCatalogDataGridDS": {
							"type": "crt.EntityDataSource",
							"hiddenInPageDesigner": true,
							"scope": "viewElement",
							"config": {}
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