Terrasoft.configuration.Structures["Tasks_FormPage"] = {innerHierarchyStack: ["Tasks_FormPage"], structureParent: "PageWithTabsFreedomTemplate"};
define('Tasks_FormPageStructure', ['Tasks_FormPageResources'], function(resources) {return {schemaUId:'26566c23-fc64-4abf-a109-1a4d1994c1ac',schemaCaption: "Tasks form page", parentSchemaName: "PageWithTabsFreedomTemplate", packageName: "CrtUIv2", schemaName:'Tasks_FormPage',parentSchemaUId:'3b2e117f-8c6b-4ca5-80a2-7ebb497cddf9',extendParent:false,type:Terrasoft.SchemaType.ANGULAR_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},parameters:{},schemaVersion:0,optionalProperties:[],schemaDifferences:function(){

}};});
define("Tasks_FormPage", /**SCHEMA_DEPS*/[]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "SaveButton",
				"values": {
					"size": "large",
					"iconPosition": "only-text"
				}
			},
			{
				"operation": "merge",
				"name": "TagSelect",
				"values": {
					"tagInRecordSourceSchemaName": "ActivityInTag",
					"visible": true,
					"label": "$Resources.Strings.null"
				}
			},
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"padding": {
						"left": "small",
						"right": "small",
						"top": "none",
						"bottom": "none"
					},
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "SideAreaProfileContainer",
				"values": {
					"columns": [
						"minmax(64px, 1fr)"
					],
					"gap": {
						"columnGap": "large",
						"rowGap": "none"
					},
					"visible": true,
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "CardContentContainer",
				"values": {
					"visible": true,
					"color": "primary",
					"borderRadius": "medium",
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
				}
			},
			{
				"operation": "merge",
				"name": "Tabs",
				"values": {
					"mode": "tab",
					"styleType": "default",
					"bodyBackgroundColor": "primary-contrast-500",
					"tabTitleColor": "auto",
					"selectedTabTitleColor": "auto",
					"headerBackgroundColor": "auto",
					"underlineSelectedTabColor": "auto",
					"fitContent": true,
					"visible": true,
					"stretch": true,
					"selectedTab": {
						"value": "GeneralInfoTab"
					},
					"allowToggleClose": true
				}
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"iconPosition": "only-text",
					"visible": true
				}
			},
			{
				"operation": "remove",
				"name": "GeneralInfoTabContainer"
			},
			{
				"operation": "merge",
				"name": "CardToggleTabPanel",
				"values": {
					"styleType": "default",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto"
				}
			},
			{
				"operation": "merge",
				"name": "FeedTabContainer",
				"values": {
					"caption": "#ResourceString(FeedTabContainer_caption)#",
					"icon": "chat-tab-icon",
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "Feed",
				"values": {
					"dataSourceName": "PDS",
					"entitySchemaName": "Activity",
					"allowExternalPost": false,
					"layoutConfig": {}
				}
			},
			{
				"operation": "move",
				"name": "Feed",
				"parentName": "FlexContainer_i3sh1vv",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "remove",
				"name": "FeedTabContainerHeaderContainer"
			},
			{
				"operation": "merge",
				"name": "FeedTabContainerHeaderLabel",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(Label_bouo1vp_caption)#)#",
					"visible": true
				}
			},
			{
				"operation": "move",
				"name": "FeedTabContainerHeaderLabel",
				"parentName": "FlexContainer_u53nlxg",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "AttachmentsTabContainer",
				"values": {
					"caption": "#ResourceString(AttachmentsTabContainer_caption)#",
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "AttachmentList",
				"values": {
					"recordColumnName": "Activity",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 10
					},
					"columns": [
						{
							"id": "116092c3-8cb6-dce7-8773-791ab8bc0d07",
							"code": "AttachmentListDS_Name",
							"caption": "#ResourceString(AttachmentListDS_Name)#",
							"dataValueType": 28
						},
						{
							"id": "71dce138-b7aa-1c48-8f4f-a62680145368",
							"code": "AttachmentListDS_CreatedOn",
							"caption": "#ResourceString(AttachmentListDS_CreatedOn)#",
							"dataValueType": 7
						},
						{
							"id": "a6f08cf0-7f43-32fa-07b3-2b2b6161f47e",
							"code": "AttachmentListDS_CreatedBy",
							"caption": "#ResourceString(AttachmentListDS_CreatedBy)#",
							"dataValueType": 10
						},
						{
							"id": "04bcbcc9-36aa-94d0-d190-339045dd2a61",
							"code": "AttachmentListDS_Size",
							"caption": "#ResourceString(AttachmentListDS_Size)#",
							"dataValueType": 4
						}
					],
					"visible": true
				}
			},
			{
				"operation": "insert",
				"name": "JoinButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_18wpafg_caption)#",
					"color": "accent",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": "$StringAttribute_mced9g6 | crt.ToJoinUrlConverter | crt.ToBoolean",
					"clicked": {
						"request": "crt.JoinMeetingRequest",
						"params": {
							"joinUrl": "$StringAttribute_mced9g6 | crt.ToJoinUrlConverter"
						}
					}
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DetailsLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_s2umkbw_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					}
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SideAreaProfileFlexContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
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
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Priority",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_gcokm0a",
					"labelPosition": "auto",
					"control": "$LookupAttribute_gcokm0a",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "",
					"tooltip": "",
					"mode": "List"
				},
				"parentName": "SideAreaProfileFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Category",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_lcx88ej",
					"labelPosition": "auto",
					"control": "$LookupAttribute_lcx88ej",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"mode": "List"
				},
				"parentName": "SideAreaProfileFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Location",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.StringAttribute_1eb0wwf",
					"labelPosition": "auto",
					"control": "$StringAttribute_1eb0wwf"
				},
				"parentName": "SideAreaProfileFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "MeetingPlatform",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.PDS_MeetingPlatform",
					"labelPosition": "auto",
					"control": "$PDS_MeetingPlatform",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": false,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "SideAreaProfileFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ShowInScheduler",
				"values": {
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.ShowInSchedulerAttribute",
					"labelPosition": "right",
					"control": "$ShowInSchedulerAttribute"
				},
				"parentName": "SideAreaProfileFlexContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "GridContainer_3mhjndt",
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
					"visible": true
				},
				"parentName": "SideContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ExecutorsLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_2i2b8cv_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_3mhjndt",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Owner",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_t50oz1p",
					"labelPosition": "auto",
					"control": "$LookupAttribute_t50oz1p",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "GridContainer_3mhjndt",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Role",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_jbhd2d1",
					"labelPosition": "auto",
					"control": "$LookupAttribute_jbhd2d1",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "GridContainer_3mhjndt",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Reporter",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 4,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_eh7knlb",
					"labelPosition": "auto",
					"control": "$LookupAttribute_eh7knlb",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": []
				},
				"parentName": "GridContainer_3mhjndt",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "GridContainer_i2j0o75",
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
					"visible": true
				},
				"parentName": "SideContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "RemindersLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_7p83djj_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true,
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_i2j0o75",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_4m2hy8l",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true
				},
				"parentName": "GridContainer_i2j0o75",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "RemindOwner",
				"values": {
					"layoutConfig": {},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.BooleanAttribute_eyhfdcl",
					"labelPosition": "right",
					"control": "$BooleanAttribute_eyhfdcl",
					"visible": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "FlexContainer_4m2hy8l",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RemindOwnerOn",
				"values": {
					"layoutConfig": {},
					"type": "crt.DateTimePicker",
					"pickerType": "datetime",
					"label": "$Resources.Strings.DateTimeAttribute_ku9u8w6",
					"labelPosition": "auto",
					"control": "$DateTimeAttribute_ku9u8w6",
					"visible": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "FlexContainer_4m2hy8l",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "RemindReporter",
				"values": {
					"layoutConfig": {},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.BooleanAttribute_nh1h6iy",
					"labelPosition": "right",
					"control": "$BooleanAttribute_nh1h6iy",
					"visible": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "FlexContainer_4m2hy8l",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "RemindReporterOn",
				"values": {
					"layoutConfig": {},
					"type": "crt.DateTimePicker",
					"pickerType": "datetime",
					"label": "$Resources.Strings.DateTimeAttribute_eypz4ag",
					"labelPosition": "auto",
					"control": "$DateTimeAttribute_eypz4ag"
				},
				"parentName": "FlexContainer_4m2hy8l",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "GridContainer_t8shp26",
				"values": {
					"type": "crt.GridContainer",
					"items": [],
					"rows": "minmax(32px, max-content)",
					"columns": [
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
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_8fdqand",
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
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"color": "primary",
					"borderRadius": "none",
					"visible": true,
					"alignItems": "stretch",
					"layoutConfig": {
						"column": 1,
						"colSpan": 1,
						"row": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainer_t8shp26",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MeetingDetailsFlexContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
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
					"gap": "none",
					"wrap": "nowrap"
				},
				"parentName": "GridContainer_8fdqand",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Title",
				"values": {
					"type": "crt.Input",
					"label": "$Resources.Strings.Title",
					"control": "$Title",
					"labelPosition": "auto"
				},
				"parentName": "MeetingDetailsFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_nvmvpxk",
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
				"parentName": "MeetingDetailsFlexContainer",
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
					"labelPosition": "auto",
					"control": "$StartDate"
				},
				"parentName": "GridContainer_nvmvpxk",
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
					"label": "$Resources.Strings.DateTimeAttribute_x88il1b",
					"labelPosition": "auto",
					"control": "$DateTimeAttribute_x88il1b"
				},
				"parentName": "GridContainer_nvmvpxk",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Status",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_codveuf",
					"labelPosition": "auto",
					"control": "$LookupAttribute_codveuf",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"mode": "List"
				},
				"parentName": "GridContainer_nvmvpxk",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Result",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_t5i95nz",
					"labelPosition": "auto",
					"control": "$LookupAttribute_t5i95nz",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"mode": "List"
				},
				"parentName": "GridContainer_nvmvpxk",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "MeetingSummary",
				"values": {
					"visible": false,
					"type": "crt.RichTextEditor",
					"label": "$Resources.Strings.PDS_MeetingTranscriptMeetingSummary",
					"labelPosition": "auto",
					"control": "$PDS_MeetingTranscriptMeetingSummary",
					"filesStorage": {
						"masterRecordColumnValue": null,
						"entitySchemaName": "SysFile",
						"recordColumnName": "RecordId"
					},
					"readonly": null,
					"placeholder": null,
					"tooltip": null,
					"multiline": null,
					"toolbarDisplayMode": null
				},
				"parentName": "MeetingDetailsFlexContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ResultDetails",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.StringAttribute_12h8xq4",
					"labelPosition": "auto",
					"control": "$StringAttribute_12h8xq4"
				},
				"parentName": "MeetingDetailsFlexContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ParticipantsExpansionPanel",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_hbptvvf_title)#",
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
					"visible": true
				},
				"parentName": "GridContainer_8fdqand",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_zkjm2ww",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
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
				"parentName": "ParticipantsExpansionPanel",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_6hptjnf",
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
				"parentName": "GridContainer_zkjm2ww",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SendInvitationButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(SendInvitationButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.SendInvitesForActivityRequest",
						"params": {
							"activityId": "Id"
						}
					},
					"clickMode": "default",
					"icon": "horn-button-icon"
				},
				"parentName": "FlexContainer_6hptjnf",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DataGrid_5hjajbn",
				"values": {
					"type": "crt.DataGrid",
					"features": {
						"rows": {
							"selection": {
								"enable": true,
								"multiple": false
							}
						}
					},
					"items": "$DataGrid_5hjajbn",
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "DataGrid_5hjajbnDS_Id",
					"columns": [
						{
							"id": "bf637c9e-f080-43ed-2356-8bacb2855831",
							"code": "DataGrid_5hjajbnDS_Participant",
							"path": "Participant",
							"caption": "#ResourceString(DataGrid_5hjajbnDS_Participant)#",
							"dataValueType": 10,
							"referenceSchemaName": "Contact",
							"width": 340
						},
						{
							"id": "fb23506b-90cc-6126-4aa7-b3ba9dd0dc1c",
							"code": "DataGrid_5hjajbnDS_Role",
							"path": "Role",
							"caption": "#ResourceString(DataGrid_5hjajbnDS_Role)#",
							"dataValueType": 10,
							"referenceSchemaName": "ActivityParticipantRole",
							"width": 255
						},
						{
							"id": "fd699000-2c40-0a77-247c-097750fafd79",
							"code": "DataGrid_5hjajbnDS_InviteResponse",
							"path": "InviteResponse",
							"caption": "#ResourceString(DataGrid_5hjajbnDS_InviteResponse)#",
							"dataValueType": 10,
							"referenceSchemaName": "ParticipantResponse"
						}
					]
				},
				"parentName": "ParticipantsExpansionPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_9kt2jf4",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 11
					},
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_9kt2jf4_title)#",
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
					"visible": true
				},
				"parentName": "GridContainer_8fdqand",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridContainer_qxuk2z3",
				"values": {
					"type": "crt.GridContainer",
					"rows": "minmax(max-content, 24px)",
					"columns": [
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
				"parentName": "ExpansionPanel_9kt2jf4",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_3zwk0zu",
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
				"parentName": "GridContainer_qxuk2z3",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Notes",
				"values": {
					"type": "crt.RichTextEditor",
					"multiline": true,
					"label": "$Resources.Strings.StringAttribute_mced9g6",
					"labelPosition": "hidden",
					"control": "$StringAttribute_mced9g6",
					"placeholder": "#ResourceString(Notes_placeholder)#",
					"filesStorage": {
						"masterRecordColumnValue": "$Id",
						"entitySchemaName": "ActivityFile",
						"recordEntitySchemaName": "Activity",
						"recordColumnName": "Activity"
					},
					"visible": true,
					"readonly": false,
					"tooltip": "",
					"toolbarDisplayMode": null
				},
				"parentName": "ExpansionPanel_9kt2jf4",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ConnectionsTabContainer",
				"values": {
					"type": "crt.TabContainer",
					"tools": [],
					"items": [],
					"caption": "#ResourceString(TabContainer_4rzb4bw_caption)#",
					"iconPosition": "left-icon",
					"visible": true,
					"icon": "gantt-chart-tab-icon"
				},
				"parentName": "CardToggleTabPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_8hkqas6",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "ConnectionsTabContainer",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ConnectionsTabContainerHeaderLabel",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_t0rm6mn_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_8hkqas6",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_3427lco",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column"
				},
				"parentName": "ConnectionsTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_i3sh1vv",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column"
				},
				"parentName": "FeedTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_u53nlxg",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "FeedTabContainer",
				"propertyName": "tools",
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
					"Title": {
						"modelConfig": {
							"path": "PDS.Title"
						}
					},
					"StartDate": {
						"modelConfig": {
							"path": "PDS.StartDate"
						}
					},
					"DateTimeAttribute_x88il1b": {
						"modelConfig": {
							"path": "PDS.DueDate"
						}
					},
					"LookupAttribute_codveuf": {
						"modelConfig": {
							"path": "PDS.Status"
						}
					},
					"LookupAttribute_t5i95nz": {
						"modelConfig": {
							"path": "PDS.Result"
						}
					},
					"StringAttribute_12h8xq4": {
						"modelConfig": {
							"path": "PDS.DetailedResult"
						}
					},
					"LookupAttribute_gcokm0a": {
						"modelConfig": {
							"path": "PDS.Priority"
						}
					},
					"LookupAttribute_lcx88ej": {
						"modelConfig": {
							"path": "PDS.ActivityCategory"
						}
					},
					"StringAttribute_1eb0wwf": {
						"modelConfig": {
							"path": "PDS.Location"
						}
					},
					"LookupAttribute_t50oz1p": {
						"modelConfig": {
							"path": "PDS.Owner"
						}
					},
					"LookupAttribute_jbhd2d1": {
						"modelConfig": {
							"path": "PDS.OwnerRole"
						}
					},
					"LookupAttribute_eh7knlb": {
						"modelConfig": {
							"path": "PDS.Author"
						}
					},
					"BooleanAttribute_eyhfdcl": {
						"modelConfig": {
							"path": "PDS.RemindToOwner"
						}
					},
					"DateTimeAttribute_ku9u8w6": {
						"modelConfig": {
							"path": "PDS.RemindToOwnerDate"
						}
					},
					"BooleanAttribute_nh1h6iy": {
						"modelConfig": {
							"path": "PDS.RemindToAuthor"
						}
					},
					"DateTimeAttribute_eypz4ag": {
						"modelConfig": {
							"path": "PDS.RemindToAuthorDate"
						}
					},
					"StringAttribute_mced9g6": {
						"modelConfig": {
							"path": "PDS.Notes"
						}
					},
					"DataGrid_5hjajbn": {
						"isCollection": true,
						"modelConfig": {
							"path": "DataGrid_5hjajbnDS",
							"filterAttributes": [
								{
									"loadOnChange": true,
									"name": "DataGrid_5hjajbn_PredefinedFilter"
								}
							],
							"sortingConfig": {
								"default": [
									{
										"direction": "asc",
										"columnName": "Participant"
									}
								]
							}
						},
						"viewModelConfig": {
							"attributes": {
								"DataGrid_5hjajbnDS_Participant": {
									"modelConfig": {
										"path": "DataGrid_5hjajbnDS.Participant"
									}
								},
								"DataGrid_5hjajbnDS_Role": {
									"modelConfig": {
										"path": "DataGrid_5hjajbnDS.Role"
									}
								},
								"DataGrid_5hjajbnDS_InviteResponse": {
									"modelConfig": {
										"path": "DataGrid_5hjajbnDS.InviteResponse"
									}
								},
								"DataGrid_5hjajbnDS_Id": {
									"modelConfig": {
										"path": "DataGrid_5hjajbnDS.Id"
									}
								}
							}
						}
					},
					"DataGrid_5hjajbn_PredefinedFilter": {
						"value": {
							"items": {
								"35b24632-c25e-4360-baff-f480d8490bc1": {
									"filterType": 4,
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "Role"
									},
									"isAggregative": false,
									"dataValueType": 10,
									"referenceSchemaName": "ActivityParticipantRole",
									"rightExpressions": [
										{
											"expressionType": 2,
											"parameter": {
												"dataValueType": 10,
												"value": {
													"Name": "Optional participant",
													"Id": "36b57810-dab9-4ffe-ad79-706102ac0194",
													"value": "36b57810-dab9-4ffe-ad79-706102ac0194",
													"displayValue": "Optional participant"
												}
											}
										},
										{
											"expressionType": 2,
											"parameter": {
												"dataValueType": 10,
												"value": {
													"Name": "Owner",
													"Id": "53fc4a92-b0ea-e111-96c4-00165d094c12",
													"value": "53fc4a92-b0ea-e111-96c4-00165d094c12",
													"displayValue": "Owner"
												}
											}
										},
										{
											"expressionType": 2,
											"parameter": {
												"dataValueType": 10,
												"value": {
													"Name": "Participant",
													"Id": "1a8324e8-a6e1-df11-971b-001d60e938c6",
													"value": "1a8324e8-a6e1-df11-971b-001d60e938c6",
													"displayValue": "Participant"
												}
											}
										}
									]
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "ActivityParticipant"
						}
					},
					"ShowInSchedulerAttribute": {
						"modelConfig": {
							"path": "PDS.ShowInScheduler"
						}
					},
					"PDS_MeetingTranscriptMeetingSummary": {
						"modelConfig": {
							"path": "PDS.MeetingTranscriptMeetingSummary"
						}
					},
					"PDS_MeetingPlatform": {
						"modelConfig": {
							"path": "PDS.MeetingPlatform"
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"Id",
					"modelConfig"
				],
				"values": {
					"path": "PDS.Id"
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"primaryDataSourceName": "PDS",
					"dependencies": {
						"DataGrid_5hjajbnDS": [
							{
								"attributePath": "Activity",
								"relationPath": "PDS.Id"
							}
						]
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"PDS": {
						"type": "crt.EntityDataSource",
						"config": {
							"entitySchemaName": "Activity",
							"attributes": {
								"MeetingTranscriptMeetingSummary": {
									"path": "MeetingTranscript.MeetingSummary",
									"type": "ForwardReference"
								}
							}
						},
						"scope": "page"
					},
					"ParticipantsListDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "ActivityParticipant",
							"attributes": {
								"Participant": {
									"path": "Participant"
								},
								"Role": {
									"path": "Role"
								},
								"InviteResponse": {
									"path": "InviteResponse"
								}
							}
						}
					},
					"DataGrid_5hjajbnDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "ActivityParticipant",
							"attributes": {
								"Participant": {
									"path": "Participant"
								},
								"Role": {
									"path": "Role"
								},
								"InviteResponse": {
									"path": "InviteResponse"
								}
							}
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources",
					"AttachmentListDS",
					"config"
				],
				"values": {
					"entitySchemaName": "ActivityFile"
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});

