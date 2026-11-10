Terrasoft.configuration.Structures["AddTaskMiniPage"] = {innerHierarchyStack: ["AddTaskMiniPage"], structureParent: "BaseMiniPageTemplate"};
define('AddTaskMiniPageStructure', ['AddTaskMiniPageResources'], function(resources) {return {schemaUId:'306fff85-4a1c-4cb1-ae5b-133c6d8b0be9',schemaCaption: "Tasks mini page", parentSchemaName: "BaseMiniPageTemplate", packageName: "CrtUIv2", schemaName:'AddTaskMiniPage',parentSchemaUId:'ecdcc8ff-272c-4957-9381-7d74ce17e140',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaDifferences:function(){

}};});
define("AddTaskMiniPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "remove",
				"name": "TitleContainer"
			},
			{
				"operation": "move",
				"name": "PageTitle",
				"parentName": "FlexContainer_41t1ylw",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"layoutConfig": {}
				}
			},
			{
				"operation": "merge",
				"name": "ContinueInOtherPageButton",
				"values": {
					"visible": "$CardState | crt.IsEqual : 'add'",
					"color": "default"
				}
			},
			{
				"operation": "move",
				"name": "FooterContainer",
				"parentName": "GridContainer_c7lbo6c",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "FooterContainer",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					}
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
				"name": "FlexContainer_41t1ylw",
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
				"parentName": "MainHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ContinueInEditPageButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ContinueInEditPageButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "only-icon",
					"visible": "$CardState | crt.IsEqual : 'edit'",
					"icon": "open-button-icon",
					"clicked": {
						"request": "crt.UpdateRecordRequest",
						"params": {
							"entityName": "Activity",
							"recordId": "$Parameter_9mb096a"
						}
					},
					"clickMode": "default"
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MainFlexContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 6
					},
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
					"gap": "extra-small",
					"wrap": "nowrap"
				},
				"parentName": "MainContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Subject",
				"values": {
					"type": "crt.Input",
					"multiline": true,
					"label": "$Resources.Strings.StringAttribute_wc5fiop",
					"labelPosition": "above",
					"control": "$StringAttribute_wc5fiop",
					"visible": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_h9pzaab",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
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
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Start",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.DateTimePicker",
					"pickerType": "datetime",
					"label": "$Resources.Strings.StartDate",
					"labelPosition": "above",
					"control": "$StartDate",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "GridContainer_h9pzaab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "End",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.DateTimePicker",
					"pickerType": "datetime",
					"label": "$Resources.Strings.DateTimeAttribute_x9yww5x",
					"labelPosition": "above",
					"control": "$DateTimeAttribute_x9yww5x",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "GridContainer_h9pzaab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Category",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_48nfm46",
					"labelPosition": "above",
					"control": "$LookupAttribute_48nfm46",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "",
					"tooltip": "",
					"mode": "List"
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Status",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_8xg616y",
					"labelPosition": "above",
					"control": "$LookupAttribute_8xg616y",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "",
					"tooltip": "",
					"mode": "List"
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Owner",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_k2s6y20",
					"labelPosition": "above",
					"control": "$LookupAttribute_k2s6y20",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "MeetingPlatform",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.ActivityDS_MeetingPlatform",
					"labelPosition": "above",
					"control": "$ActivityDS_MeetingPlatform",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": false,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "ShowInCalendar",
				"values": {
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.ActivityDS_ShowInScheduler_0q884gv",
					"labelPosition": "right",
					"control": "$ActivityDS_ShowInScheduler_0q884gv",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MainFlexContainer",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "GridContainer_c7lbo6c",
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
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FlexContainer_6r2we5l",
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
					"alignItems": "flex-end",
					"gap": "none",
					"wrap": "wrap"
				},
				"parentName": "GridContainer_c7lbo6c",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "JoinButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(JoinButton_caption)#",
					"color": "accent",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": "$Notes | crt.ToJoinUrlConverter | crt.ToBoolean",
					"clicked": {
						"request": "crt.JoinMeetingRequest",
						"params": {
							"joinUrl": "$Notes | crt.ToJoinUrlConverter"
						}
					}
				},
				"parentName": "FlexContainer_6r2we5l",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfigDiff: /**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [
					"attributes"
				],
				"values": {
					"StringAttribute_wc5fiop": {
						"modelConfig": {
							"path": "ActivityDS.Title"
						}
					},
					"StartDate": {
						"modelConfig": {
							"path": "ActivityDS.StartDate"
						}
					},
					"DateTimeAttribute_x9yww5x": {
						"modelConfig": {
							"path": "ActivityDS.DueDate"
						}
					},
					"LookupAttribute_48nfm46": {
						"modelConfig": {
							"path": "ActivityDS.ActivityCategory"
						}
					},
					"LookupAttribute_8xg616y": {
						"modelConfig": {
							"path": "ActivityDS.Status"
						}
					},
					"LookupAttribute_k2s6y20": {
						"modelConfig": {
							"path": "ActivityDS.Owner"
						}
					},
					"Parameter_9mb096a": {
						"modelConfig": {
							"path": "ActivityDS.Id"
						}
					},
					"ShowInSchedulerAttribute": {
						"modelConfig": {
							"path": "ActivityDS.ShowInScheduler"
						}
					},
					"Notes": {
						"modelConfig": {
							"path": "ActivityDS.Notes"
						}
					},
					"ActivityDS_ShowInScheduler_0q884gv": {
						"modelConfig": {
							"path": "ActivityDS.ShowInScheduler"
						}
					},
					"ActivityDS_MeetingPlatform": {
						"modelConfig": {
							"path": "ActivityDS.MeetingPlatform"
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
						"ActivityDS": {
							"type": "crt.EntityDataSource",
							"scope": "page",
							"config": {
								"entitySchemaName": "Activity"
							}
						}
					},
					"primaryDataSourceName": "ActivityDS"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

