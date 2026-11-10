Terrasoft.configuration.Structures["ActivitySyncSettingsMiniPage"] = {innerHierarchyStack: ["ActivitySyncSettingsMiniPage"], structureParent: "BaseMiniPageTemplate"};
define('ActivitySyncSettingsMiniPageStructure', ['ActivitySyncSettingsMiniPageResources'], function(resources) {return {schemaUId:'88fc1660-a4b9-43fe-bc51-cf42ff9c354f',schemaCaption: "Activity Sync Settings Mini Page", parentSchemaName: "BaseMiniPageTemplate", packageName: "Exchange", schemaName:'ActivitySyncSettingsMiniPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:1,optionalProperties:[],schemaDifferences:function(){

}};});
define("ActivitySyncSettingsMiniPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(PageTitle_caption)#)#",
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "MainContainer",
				"values": {
					"gap": {
						"columnGap": "large",
						"rowGap": "small"
					},
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "medium",
						"left": "none"
					},
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"color": "default",
					"size": "large",
					"iconPosition": "only-text"
				}
			},
			{
				"operation": "insert",
				"name": "Checkbox_ImportAppointments",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"value": true,
					"disabled": "$ImportAppointmentsDisabled",
					"inversed": false,
					"label": "#ResourceString(Checkbox_ImportAppointments_label)#",
					"ariaLabel": "",
					"labelPosition": "right",
					"tooltip": "$ImportAppointmentsTooltip",
					"control": "$ActivitySyncSettingsDS_ImportAppointments"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_EnableSyncDescription",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 2,
						"rowSpan": 1
					},
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_EnableSyncDescription_caption)#)#",
					"labelType": "caption",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#00000099",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"headingLevel": "label",
					"visible": true
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ComboBox_SyncPeriod",
				"values": {
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 3,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.ActivitySyncSettingsDS_ActivitySyncPeriod",
					"ariaLabel": "",
					"isAddAllowed": true,
					"showValueAsLink": false,
					"labelPosition": "above",
					"controlActions": [],
					"listActions": [],
					"tooltip": "",
					"control": "$ActivitySyncSettingsDS_ActivitySyncPeriod",
					"visible": true,
					"readonly": false,
					"placeholder": ""
				},
				"parentName": "MainContainer",
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
					"ActivitySyncSettingsDS_ImportAppointments": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ImportAppointments"
						}
					},
					"ActivitySyncSettingsDS_ExportActivities": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ExportActivities"
						}
					},
					"ActivitySyncSettingsDS_ExportActivitiesAll": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ExportActivitiesAll"
						}
					},
					"ActivitySyncSettingsDS_ImpAppointmentsFromCalendars": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ImpAppointmentsFromCalendars"
						}
					},
					"ActivitySyncSettingsDS_ImportAppointmentsAll": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ImportAppointmentsAll"
						}
					},
					"ActivitySyncSettingsDS_ImportTasks": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ImportTasks"
						}
					},
					"ActivitySyncSettingsDS_ImportTasksAll": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ImportTasksAll"
						}
					},
					"ActivitySyncSettingsDS_ActivitySyncPeriod": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.ActivitySyncPeriod"
						}
					},
					"ActivitySyncSettingsDS_SenderEmailAddress": {
						"modelConfig": {
							"path": "ActivitySyncSettingsDS.MailboxSyncSettings.SenderEmailAddress"
						}
					},
					"ActivitySyncSettingsDS_ActivitySyncPeriod_List": {
						"isCollection": true,
						"modelConfig": {
							"sortingConfig": {
								"default": [
									{
										"columnName": "Name",
										"direction": "asc"
									}
								]
							}
						}
					},
					"ImportAppointmentsDisabled": {
						"value": true
					},
					"ImportAppointmentsTooltip": {
						"value": ""
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
						"ActivitySyncSettingsDS": {
							"type": "crt.EntityDataSource",
							"scope": "page",
							"config": {
								"entitySchemaName": "ActivitySyncSettings",
								"loadParameters": {
									"options": {
										"pagingConfig": {
											"rowCount": 1,
											"rowsOffset": -1
										},
										"sortingConfig": {
											"columns": []
										}
									}
								},
								"allowCopyingRecords": false
							}
						}
					},
					"primaryDataSourceName": "ActivitySyncSettingsDS"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

