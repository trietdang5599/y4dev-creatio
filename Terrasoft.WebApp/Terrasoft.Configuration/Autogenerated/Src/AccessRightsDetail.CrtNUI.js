define("AccessRightsDetail", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "ExpandableRightControlsContainer",
				"parentName": "MainContainer",
				"values": {
					"visible": "$ShowExpands",
					"type": "crt.TemplateList",
					"items": "$ApplicableOperationTypes",
					"direction": "column",
					"gap": 8,
					"template": [
						{
							"type": "crt.ExpansionPanel",
							"tools": [],
							"items": [
								{
									"type": "crt.GridContainer",
									"name": "$ApplicableOperationTypes.GridContainerName",
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
									"items": [
										{
											"type": "crt.DataGrid",
											"items": "$ApplicableOperationTypes.Items",
											"rowToolbarItems": [
												{
													"type": "crt.MenuItem",
													"caption": "#ResourceString(DeleteButton)#",
													"icon": "delete-row-action",
													"clicked": {
														"request": "crt.DeleteAccessRightsRecordRequest",
														"params": {
															"operationType": "$ApplicableOperationTypes.GroupOperationType",
															"rightId": "$ApplicableOperationTypes.Items.Id",
														},
													}
												}
											],
											"createItem": {
												"request": "crt.CreateAccessRightsRecordRequest",
												"params": {
													"operationType": "$ApplicableOperationTypes.GroupOperationType",
													"index": "@event.index"
												}
											},
											"columns": [
												{
													"id": "AccessRight_SysAdminUnit",
													"code": "SysAdminUnit",
													"caption": "#ResourceString(SysAdminUnitCaption)#",
													"dataValueType": Terrasoft.DataValueType.LOOKUP,
													"readonly": true,
													"cellView": {
														"type": "crt.Link",
														"caption": "$ApplicableOperationTypes.Items.SysAdminUnit | crt.ToLookupDisplayValue",
														"link": "$ApplicableOperationTypes.Items.SysAdminUnitLink",
														"mode": "preventDefault",
														"underlining": "hover",
														"clicked": {
															"request": "crt.UpdateRecordRequest",
															"params": {
																"entityName": "SysAdminUnit",
																"recordId": '$ApplicableOperationTypes.SysAdminUnit | crt.ToObjectProp:"value"'
															}
														}
													}
												},
												{
													"id": "AccessRight_OperationType",
													"code": "OperationType",
													"caption": "#ResourceString(OperationTypeCaption)#",
													"dataValueType": Terrasoft.DataValueType.LOOKUP,
													"editingCellView": {
														"type": "crt.DataTableEditLookupCell",
														"value": "$ApplicableOperationTypes.Items.OperationType",
														"valueChange": {
															"request": "crt.AccessRightsRecordChangedRequest",
															"params": {
																"operationType": "$ApplicableOperationTypes.Items.GroupOperationType",
																"rightId": "$ApplicableOperationTypes.Items.Id",
																"value": "@event",
															}
														},
														"items": "$ApplicableOperationTypes.OperationTypeLookupValues",
														"useStaticFiltering": true
													}
												}
											],
											"layoutConfig": {
												"colSpan": 2,
												"column": 1,
												"row": 1,
												"rowSpan": 6
											},
											"features": "$GridFeatures",
											"activeRow": "$ApplicableOperationTypes.ActiveRow",
											"selectionState": "$ApplicableOperationTypes.SelectionState",
											"editingCells": "$ApplicableOperationTypes.EditingCells",
										}
									],
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
								}
							],
							"title": "$ApplicableOperationTypes.Caption",
							"toggleType": "default",
							"togglePosition": "before",
							"expanded": "$ApplicableOperationTypes.Expanded",
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
						}
					],
					"classes": []
				},
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RightControlsContainer",
				"parentName": "MainContainer",
				"values": {
					"visible": "$ShowExpands | crt.InvertBooleanValue",
					"type": "crt.TemplateList",
					"items": "$ApplicableOperationTypes",
					"direction": "column",
					"gap": 8,
					"template": [
						{
							"type": "crt.GridContainer",
							"name": "$ApplicableOperationTypes.GridContainerName",
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
							"items": [
								{
									"type": "crt.DataGrid",
									"items": "$ApplicableOperationTypes.Items",
									"rowToolbarItems": [
										{
											"type": "crt.MenuItem",
											"caption": "#ResourceString(DeleteButton)#",
											"icon": "delete-row-action",
											"clicked": {
												"request": "crt.DeleteAccessRightsRecordRequest",
												"params": {
													"operationType": "$ApplicableOperationTypes.GroupOperationType",
													"rightId": "$ApplicableOperationTypes.Items.Id",
												},
											}
										}
									],
									"createItem": {
										"request": "crt.CreateAccessRightsRecordRequest",
										"params": {
											"operationType": "$ApplicableOperationTypes.GroupOperationType",
											"index": "@event.index"
										}
									},
									"columns": [
										{
											"id": "AccessRight_SysAdminUnit",
											"code": "SysAdminUnit",
											"caption": "#ResourceString(SysAdminUnitCaption)#",
											"dataValueType": Terrasoft.DataValueType.LOOKUP,
											"readonly": true,
											"cellView": {
												"type": "crt.Link",
												"caption": "$ApplicableOperationTypes.Items.SysAdminUnit | crt.ToLookupDisplayValue",
												"link": "$ApplicableOperationTypes.Items.SysAdminUnitLink",
												"mode": "preventDefault",
												"underlining": "hover",
												"clicked": {
													"request": "crt.UpdateRecordRequest",
													"params": {
														"entityName": "SysAdminUnit",
														"recordId": '$ApplicableOperationTypes.SysAdminUnit | crt.ToObjectProp:"value"'
													}
												}
											}
										}
									],
									"layoutConfig": {
										"colSpan": 2,
										"column": 1,
										"row": 1,
										"rowSpan": 6
									},
									"features": "$GridFeatures",
									"activeRow": "$ApplicableOperationTypes.ActiveRow",
									"selectionState": "$ApplicableOperationTypes.SelectionState",
									"editingCells": "$ApplicableOperationTypes.EditingCells",
								}
							],
							"color": "transparent",
							"borderRadius": "none",
							"padding": {
								"top": "none",
								"right": "none",
								"bottom": "none",
								"left": "none"
							},
							"alignItems": "stretch"
						}
					],
					"classes": []
				},
				"propertyName": "items",
				"index": 0
			},
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"attributes": {
						"AccessRightsType": {
							"modelConfig": {
								"path": "PageParameters.AccessRightsType"
							}
						},
						"RightsSchemaName": {
							"modelConfig": {
								"path": "PageParameters.RightsSchemaName"
							}
						},
						"RecordId": {
							"modelConfig": {
								"path": "PageParameters.RecordId"
							}
						},
						"AccessRightsValue": {
							"modelConfig": {
								"path": "PageParameters.AccessRightsValue"
							}
						},
						"ShowExpands": {
							"modelConfig": {
								"path": "PageParameters.ShowExpands"
							}
						},
						"SelectedAdminUnit": {
							"value": null
						},
						"IsAccessRightsInitialized": {
							"value": false,
						},
						"GridFeatures": {
							"value": {
								"columns": {
									"sorting": false,
									"resizing": false,
									"dragAndDrop": false,
									"adding": false,
									"editing": false,
									"toolbar": false
								},
								"rows": {
									"hierarchical": false,
									"numeration": true,
									"selection": {
										"enable": false,
										"multiple": false,
										"selectAll": false,
									},
								},
								"header": {
									"visible": true,
								},
								"editable": {
									"enable": true,
									"itemsCreation": true,
									"floatingEditPanel": false,
									"lookupItemsCreation": false,
								},
								"cells": {
									"selection": true,
									"disableTextSelectionOnDoubleClick": false,
								}
							}
						},
						"ApplicableOperationTypes": {
							"isCollection": true,
							"viewModelConfig": {
								"attributes": {
									"Id": {},
									"Caption": {},
									"Expanded": { "value": false },
									"GroupOperationType": {},
									"ApplicableRights": { "value": [] },
									"OperationTypeLookupValues": { "value": [] },
									"Items": {
										"isCollection": true,
										"viewModelConfig": {
											"attributes": {
												"Id": {},
												"SysAdminUnit": {},
												"SysAdminUnitLink": {},
												"OperationType": {},
												"IsNew": { "value": false },
												"IsDeleted": { "value": false }
											}
										}
									},
									"SelectionState": {},
									"ActiveRow": {},
									"EditingCells": [],
									"IsSingleOption": {},
									"GridContainerName": {
										"from": "GroupOperationType",
										"converter": "crt.InterpolateString : 'OperationType{0}GridContainer'"
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
					"dataSources": {}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});