define("SysUserProfilePage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "OptimizeComponentsAccessibilityBehaviorCheckbox",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"rowSpan": 1,
						"row": 3
					},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.SysUserProfileDS_OptimizeComponentsAccessibilityBehavior",
					"labelPosition": "right",
					"control": "$SysUserProfileDS_OptimizeComponentsAccessibilityBehavior",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": "#ResourceString(OptimizeComponentsAccessibilityBehaviorCheckbox_tooltip)#"
				},
				"parentName": "AccessibilitySettingsContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "TabContainer_ExternalApplications",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(TabContainer_ExternalApplications_caption)#",
					"iconPosition": "only-text",
					"visible": true
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_ni5j195",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_ni5j195_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "TabContainer_ExternalApplications",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_e1v1r9l",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
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
				"parentName": "ExpansionPanel_ni5j195",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_deq39qn",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_e1v1r9l",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_RefreshConnectedGallery",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_RefreshConnectedGallery_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"refreshDataConfig": {
								"mode": "RefreshSpecific",
								"targetDataSourceNames": [
									"Gallery_id2n1k2DS",
									"Gallery_herr6dpDS"
								]
							}
						}
					},
					"clickMode": "default",
					"icon": "reload-icon"
				},
				"parentName": "FlexContainer_deq39qn",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_96h03am",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_96h03am_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ExpansionPanel_ni5j195",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_29epoqr",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": 0
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": []
				},
				"parentName": "ExpansionPanel_ni5j195",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Gallery_ConnectedApplications",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.Gallery",
					"selectionState": "$Gallery_id2n1k2_SelectionState",
					"_selectionOptions": {
						"attribute": "Gallery_id2n1k2_SelectionState"
					},
					"itemConfig": {
						"defaultSize": "medium",
						"templateValuesMapping": {
							"caption": "Gallery_id2n1k2DS_Name",
							"description": "Gallery_id2n1k2DS_Description",
							"image": "Gallery_id2n1k2DS_Logo",
							"id": "Gallery_id2n1k2DS_Id"
						},
						"specificPageRecordId": "Gallery_id2n1k2DS_Id"
					},
					"items": "$Gallery_id2n1k2",
					"bulkActions": [],
					"useSpecificPage": true,
					"visible": true,
					"specificPage": "UserConnectedAppPage"
				},
				"parentName": "GridContainer_29epoqr",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Gallery_id2n1k2_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Add tag",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "Gallery_id2n1k2DS",
							"filters": "$Gallery_id2n1k2 | crt.ToCollectionFilters : 'Gallery_id2n1k2' : $Gallery_id2n1k2_SelectionState | crt.SkipIfSelectionEmpty : $Gallery_id2n1k2_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "Gallery_ConnectedApplications",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Gallery_id2n1k2_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Remove tag",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "Gallery_id2n1k2DS",
							"filters": "$Gallery_id2n1k2 | crt.ToCollectionFilters : 'Gallery_id2n1k2' : $Gallery_id2n1k2_SelectionState | crt.SkipIfSelectionEmpty : $Gallery_id2n1k2_SelectionState"
						}
					}
				},
				"parentName": "Gallery_id2n1k2_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Gallery_id2n1k2_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Delete",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "Gallery_id2n1k2DS",
							"filters": "$Gallery_id2n1k2 | crt.ToCollectionFilters : 'Gallery_id2n1k2' : $Gallery_id2n1k2_SelectionState | crt.SkipIfSelectionEmpty : $Gallery_id2n1k2_SelectionState"
						}
					}
				},
				"parentName": "Gallery_ConnectedApplications",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_rd0vz6l",
				"values": {
					"type": "crt.GridContainer",
					"items": [],
					"rows": "minmax(32px, max-content)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
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
				"parentName": "TabContainer_ExternalApplications",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_jv39i1l",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_jv39i1l_title)#",
					"toggleType": "default",
					"togglePosition": "before",
					"expanded": true,
					"labelColor": "auto",
					"fullWidthHeader": false,
					"titleWidth": 20,
					"padding": {
						"top": "small",
						"bottom": "small",
						"left": "none",
						"right": "none"
					},
					"fitContent": true,
					"visible": true,
					"alignItems": "stretch"
				},
				"parentName": "GridContainer_rd0vz6l",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_qt5ouhv",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
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
				"parentName": "ExpansionPanel_jv39i1l",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_4wtg22y",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"gap": "none",
					"alignItems": "center",
					"items": [],
					"layoutConfig": {
						"colSpan": 1,
						"column": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_qt5ouhv",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Button_RefreshAllGallery",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_RefreshAllGallery_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload",
								"useLastLoadParameters": true
							},
							"refreshDataConfig": {
								"mode": "RefreshSpecific",
								"targetDataSourceNames": [
									"Gallery_id2n1k2DS",
									"Gallery_herr6dpDS"
								]
							}
						}
					},
					"clickMode": "default",
					"icon": "reload-icon"
				},
				"parentName": "FlexContainer_4wtg22y",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_lduxnuz",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_lduxnuz_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#757575",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "ExpansionPanel_jv39i1l",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_dhyiu0n",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 32px)",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"styles": {
						"overflow-x": "hidden"
					},
					"items": [],
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
				"parentName": "ExpansionPanel_jv39i1l",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Gallery_AvailableApplications",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 2,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.Gallery",
					"selectionState": "$Gallery_herr6dp_SelectionState",
					"_selectionOptions": {
						"attribute": "Gallery_herr6dp_SelectionState"
					},
					"itemConfig": {
						"defaultSize": "medium",
						"templateValuesMapping": {
							"caption": "Gallery_herr6dpDS_Name",
							"description": "Gallery_herr6dpDS_Description",
							"image": "Gallery_herr6dpDS_Logo",
							"id": "Gallery_herr6dpDS_Id"
						},
						"specificPageRecordId": "Gallery_herr6dpDS_Id"
					},
					"items": "$Gallery_herr6dp",
					"bulkActions": [],
					"useSpecificPage": true,
					"visible": true,
					"specificPage": "UserConnectedAppPage"
				},
				"parentName": "GridContainer_dhyiu0n",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Gallery_herr6dp_AddTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Add tag",
					"icon": "tag-icon",
					"clicked": {
						"request": "crt.AddTagsInRecordsRequest",
						"params": {
							"dataSourceName": "Gallery_herr6dpDS",
							"filters": "$Gallery_herr6dp | crt.ToCollectionFilters : 'Gallery_herr6dp' : $Gallery_herr6dp_SelectionState | crt.SkipIfSelectionEmpty : $Gallery_herr6dp_SelectionState"
						}
					},
					"items": []
				},
				"parentName": "Gallery_AvailableApplications",
				"propertyName": "bulkActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Gallery_herr6dp_RemoveTagsBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Remove tag",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.RemoveTagsInRecordsRequest",
						"params": {
							"dataSourceName": "Gallery_herr6dpDS",
							"filters": "$Gallery_herr6dp | crt.ToCollectionFilters : 'Gallery_herr6dp' : $Gallery_herr6dp_SelectionState | crt.SkipIfSelectionEmpty : $Gallery_herr6dp_SelectionState"
						}
					}
				},
				"parentName": "Gallery_herr6dp_AddTagsBulkAction",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Gallery_herr6dp_DeleteBulkAction",
				"values": {
					"type": "crt.MenuItem",
					"caption": "Delete",
					"icon": "delete-button-icon",
					"clicked": {
						"request": "crt.DeleteRecordsRequest",
						"params": {
							"dataSourceName": "Gallery_herr6dpDS",
							"filters": "$Gallery_herr6dp | crt.ToCollectionFilters : 'Gallery_herr6dp' : $Gallery_herr6dp_SelectionState | crt.SkipIfSelectionEmpty : $Gallery_herr6dp_SelectionState"
						}
					}
				},
				"parentName": "Gallery_AvailableApplications",
				"propertyName": "bulkActions",
				"index": 1
			},
			{
				"operation": "move",
				"name": "AccessibilitySettingsTabContainer",
				"parentName": "Tabs",
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
					"Gallery_id2n1k2": {
						"isCollection": true,
						"modelConfig": {
							"path": "Gallery_id2n1k2DS",
							"filterAttributes": [
								{
									"loadOnChange": true,
									"name": "Gallery_id2n1k2_PredefinedFilter"
								}
							]
						},
						"viewModelConfig": {
							"attributes": {
								"Gallery_id2n1k2DS_Name": {
									"modelConfig": {
										"path": "Gallery_id2n1k2DS.Name"
									}
								},
								"Gallery_id2n1k2DS_Description": {
									"modelConfig": {
										"path": "Gallery_id2n1k2DS.Description"
									}
								},
								"Gallery_id2n1k2DS_Logo": {
									"modelConfig": {
										"path": "Gallery_id2n1k2DS.Logo"
									}
								},
								"Gallery_id2n1k2DS_Id": {
									"modelConfig": {
										"path": "Gallery_id2n1k2DS.Id"
									}
								},
								"Gallery_id2n1k2DS_Active": {
									"modelConfig": {
										"path": "Gallery_id2n1k2DS.Active"
									}
								}
							}
						}
					},
					"Gallery_herr6dp": {
						"isCollection": true,
						"modelConfig": {
							"path": "Gallery_herr6dpDS",
							"filterAttributes": [
								{
									"loadOnChange": true,
									"name": "Gallery_herr6dp_PredefinedFilter"
								}
							]
						},
						"viewModelConfig": {
							"attributes": {
								"Gallery_herr6dpDS_Name": {
									"modelConfig": {
										"path": "Gallery_herr6dpDS.Name"
									}
								},
								"Gallery_herr6dpDS_Description": {
									"modelConfig": {
										"path": "Gallery_herr6dpDS.Description"
									}
								},
								"Gallery_herr6dpDS_Logo": {
									"modelConfig": {
										"path": "Gallery_herr6dpDS.Logo"
									}
								},
								"Gallery_herr6dpDS_Id": {
									"modelConfig": {
										"path": "Gallery_herr6dpDS.Id"
									}
								},
								"Gallery_herr6dpDS_Active": {
									"modelConfig": {
										"path": "Gallery_herr6dpDS.Active"
									}
								}
							}
						}
					},
					"Gallery_id2n1k2_PredefinedFilter": {
						"value": {
							"items": {
								"e07c8bff-5a3b-4392-8861-06c71950d517": {
									"filterType": 1,
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "Active"
									},
									"isAggregative": false,
									"dataValueType": 12,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 12,
											"value": true
										}
									}
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "ConnectedOAuthClientApp"
						}
					},
					"Gallery_herr6dp_PredefinedFilter": {
						"value": {
							"items": {
								"28a9bf38-9a20-48e6-be53-a07c14ecb624": {
									"filterType": 1,
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "Active"
									},
									"isAggregative": false,
									"dataValueType": 12,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 12,
											"value": false
										}
									}
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "ConnectedOAuthClientApp"
						}
					},
					"SysUserProfileDS_OptimizeComponentsAccessibilityBehavior": {
						"modelConfig": {
							"path": "SysUserProfileDS.OptimizeComponentsAccessibilityBehavior"
						}
					}
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"Gallery_id2n1k2DS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "ConnectedOAuthClientApp",
							"attributes": {
								"Name": {
									"path": "Name"
								},
								"Description": {
									"path": "Description"
								},
								"Logo": {
									"path": "Logo"
								}
							}
						}
					},
					"Gallery_herr6dpDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "ConnectedOAuthClientApp",
							"attributes": {
								"Name": {
									"path": "Name"
								},
								"Description": {
									"path": "Description"
								},
								"Logo": {
									"path": "Logo"
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