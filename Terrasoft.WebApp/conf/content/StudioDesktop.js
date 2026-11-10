Terrasoft.configuration.Structures["StudioDesktop"] = {innerHierarchyStack: ["StudioDesktop"], structureParent: "CentralAreaDesktopTemplate"};
define('StudioDesktopStructure', ['StudioDesktopResources'], function(resources) {return {schemaUId:'16ff944c-ff76-4aab-97e7-725b12bed0ec',schemaCaption: "Studio Desktop", parentSchemaName: "CentralAreaDesktopTemplate", packageName: "CrtUIv2", schemaName:'StudioDesktop',parentSchemaUId:'fbc98c89-0691-479c-bc25-59c11ac2365f',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("StudioDesktop", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "GridContainer_sbua9b5",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 8,
						"rowSpan": 1
					},
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
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "medium",
						"left": "none"
					}
				},
				"parentName": "FixedGridSlot_qwe4asds",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_Greeting",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_Greeting_caption)#)#",
					"labelType": "large-2",
					"labelThickness": "light",
					"labelEllipsis": false,
					"labelColor": "#FFFFFF",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "GridContainer_sbua9b5",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ChartWidget_StartedProcessesToday",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 6,
						"rowSpan": 6
					},
					"type": "crt.ChartWidget",
					"config": {
						"title": "#ResourceString(ChartWidget_StartedProcessesToday_title)#",
						"color": "green",
						"theme": "glassmorphism",
						"scales": {
							"stacked": false,
							"xAxis": {
								"name": "",
								"formatting": {
									"type": "string",
									"maxLinesCount": 2,
									"maxLineLength": 10
								}
							},
							"yAxis": {
								"name": "",
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
								"color": "coral",
								"type": "area",
								"label": "#ResourceString(ChartWidget_StartedProcessesToday_series_0)#",
								"legend": {
									"enabled": false
								},
								"data": {
									"providing": {
										"schemaName": "SysProcessLog",
										"rowCount": 50,
										"sectionBindingColumn": {},
										"grouping": {
											"column": [
												{
													"isVisible": true,
													"expression": {
														"functionType": 3,
														"datePartType": 6,
														"expressionType": 1,
														"functionArgument": {
															"columnPath": "CreatedOn",
															"expressionType": 0
														}
													}
												}
											],
											"type": "by-date-part"
										},
										"aggregation": {
											"column": {
												"expression": {
													"expressionType": 1,
													"functionType": 2,
													"aggregationType": 1,
													"aggregationEvalType": 2,
													"functionArgument": {
														"expressionType": 0,
														"columnPath": "Id"
													}
												}
											}
										},
										"filters": {
											"filter": {
												"items": {
													"07f5b51b-c844-4229-9d49-065a8c719b00": {
														"filterType": 1,
														"comparisonType": 3,
														"isEnabled": true,
														"trimDateTimeParameterToDate": true,
														"leftExpression": {
															"expressionType": 0,
															"columnPath": "CreatedOn"
														},
														"isAggregative": false,
														"dataValueType": 7,
														"rightExpression": {
															"expressionType": 1,
															"functionType": 1,
															"macrosType": 4
														}
													}
												},
												"logicalOperation": 0,
												"isEnabled": true,
												"filterType": 6,
												"rootSchemaName": "SysProcessLog"
											}
										}
									},
									"formatting": {
										"type": "number",
										"decimalSeparator": ".",
										"decimalPrecision": 0,
										"thousandSeparator": ","
									}
								}
							}
						],
						"seriesOrder": {
							"type": "by-grouping-value",
							"direction": 1
						}
					}
				},
				"parentName": "FixedGridSlot_qwe4asds",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "IndicatorWidget_ActiveUsersNow",
				"values": {
					"layoutConfig": {
						"column": 7,
						"row": 2,
						"colSpan": 2,
						"rowSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(IndicatorWidget_ActiveUsersNow_title)#",
						"data": {
							"providing": {
								"schemaName": "SysAdminUnit",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {
											"390b9123-6af8-4edb-abbb-1146b9a94d82": {
												"filterType": 5,
												"comparisonType": 15,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "[SysUserSession:SysUser].Id"
												},
												"isAggregative": true,
												"dataValueType": 4,
												"subFilters": {
													"items": {
														"467fccfe-4d88-40ff-99b4-4439ef1beb72": {
															"filterType": 2,
															"comparisonType": 1,
															"isEnabled": true,
															"trimDateTimeParameterToDate": false,
															"leftExpression": {
																"expressionType": 0,
																"columnPath": "SessionEndDate"
															},
															"isAggregative": false,
															"dataValueType": 7,
															"isNull": true
														},
														"379068a2-0307-4435-aa1d-49b12f6ef585": {
															"items": {
																"68c99a5e-f7fb-4ec6-8efe-5d511a974e41": {
																	"filterType": 1,
																	"comparisonType": 3,
																	"isEnabled": true,
																	"trimDateTimeParameterToDate": true,
																	"leftExpression": {
																		"expressionType": 0,
																		"columnPath": "SessionStartDate"
																	},
																	"isAggregative": false,
																	"dataValueType": 7,
																	"rightExpression": {
																		"expressionType": 1,
																		"functionType": 1,
																		"macrosType": 4
																	}
																},
																"3aad1763-94eb-4fa7-8b5a-9977123e3625": {
																	"filterType": 1,
																	"comparisonType": 3,
																	"isEnabled": true,
																	"trimDateTimeParameterToDate": true,
																	"leftExpression": {
																		"expressionType": 0,
																		"columnPath": "SessionStartDate"
																	},
																	"isAggregative": false,
																	"dataValueType": 7,
																	"rightExpression": {
																		"expressionType": 1,
																		"functionType": 1,
																		"macrosType": 3
																	}
																}
															},
															"logicalOperation": 1,
															"isEnabled": true,
															"filterType": 6,
															"rootSchemaName": "SysUserSession",
															"key": "379068a2-0307-4435-aa1d-49b12f6ef585"
														}
													},
													"logicalOperation": 0,
													"isEnabled": true,
													"filterType": 6,
													"rootSchemaName": "SysUserSession",
													"key": "5b311126-4a7b-49b2-a978-1d78d539d304"
												}
											},
											"97edad7a-90b6-43e5-b82f-1e0b34dccc9e": {
												"filterType": 1,
												"comparisonType": 4,
												"isEnabled": true,
												"trimDateTimeParameterToDate": false,
												"leftExpression": {
													"expressionType": 0,
													"columnPath": "ConnectionType"
												},
												"isAggregative": false,
												"dataValueType": 4,
												"rightExpression": {
													"expressionType": 2,
													"parameter": {
														"dataValueType": 4,
														"value": 1
													}
												}
											}
										},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "SysAdminUnit"
									}
								},
								"sectionBindingColumn": {
									"path": null
								}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(IndicatorWidget_ActiveUsersNow_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "large"
						},
						"layout": {
							"color": "transparent"
						},
						"theme": "glassmorphism"
					}
				},
				"parentName": "FixedGridSlot_qwe4asds",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "IndicatorWidget_InstalledApplications",
				"values": {
					"layoutConfig": {
						"column": 7,
						"row": 5,
						"colSpan": 2,
						"rowSpan": 3
					},
					"type": "crt.IndicatorWidget",
					"config": {
						"title": "#ResourceString(IndicatorWidget_InstalledApplications_title)#",
						"data": {
							"providing": {
								"schemaName": "SysInstalledApp",
								"aggregation": {
									"column": {
										"expression": {
											"expressionType": 1,
											"functionType": 2,
											"aggregationType": 1,
											"aggregationEvalType": 2,
											"functionArgument": {
												"expressionType": 0,
												"columnPath": "Id"
											}
										}
									}
								},
								"filters": {
									"filter": {
										"items": {},
										"logicalOperation": 0,
										"isEnabled": true,
										"filterType": 6,
										"rootSchemaName": "SysInstalledApp"
									}
								},
								"sectionBindingColumn": {}
							},
							"formatting": {
								"type": "number",
								"decimalSeparator": ".",
								"decimalPrecision": 0,
								"thousandSeparator": ","
							}
						},
						"text": {
							"template": "#ResourceString(IndicatorWidget_InstalledApplications_template)#",
							"metricMacros": "{0}",
							"fontSizeMode": "large"
						},
						"layout": {
							"color": "transparent"
						},
						"theme": "glassmorphism"
					}
				},
				"parentName": "FixedGridSlot_qwe4asds",
				"propertyName": "items",
				"index": 3
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

