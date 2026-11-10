define("EmailFormPage", /**SCHEMA_DEPS*/["@creatio-devkit/common"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(devkit)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "CancelButton",
				"values": {
					"visible": "$VisibleCancelButton"
				}
			},
			{
				"operation": "remove",
				"name": "SideContainer"
			},
			{
				"operation": "remove",
				"name": "SideAreaProfileContainer"
			},
			{
				"operation": "merge",
				"name": "CenterContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 2,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "Tabs",
				"values": {
					"styleType": "default",
					"mode": "tab",
					"bodyBackgroundColor": "primary-contrast-500",
					"selectedTabTitleColor": "auto",
					"tabTitleColor": "auto",
					"underlineSelectedTabColor": "auto",
					"headerBackgroundColor": "auto",
					"visible": "$ComposerVisible | crt.InvertBooleanValue"
				}
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"caption": "#ResourceString(TabContainer_2eqcl4q_caption)#",
					"iconPosition": "only-text",
					"visible": true
				}
			},
			{
				"operation": "move",
				"name": "GeneralInfoTabContainer",
				"parentName": "MessageTab",
				"propertyName": "items",
				"index": 0
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
					"visible": true
				}
			},
			{
				"operation": "merge",
				"name": "Feed",
				"values": {
					"dataSourceName": "ActivityDS",
					"entitySchemaName": "Activity",
					"allowExternalPost": false
				}
			},
			{
				"operation": "move",
				"name": "Feed",
				"parentName": "FlexContainer_76kv6qn",
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
					"caption": "#MacrosTemplateString(#ResourceString(Label_2jzb4wj_caption)#)#",
					"visible": true
				}
			},
			{
				"operation": "move",
				"name": "FeedTabContainerHeaderLabel",
				"parentName": "FlexContainer_xbtb80n",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "AttachmentsTabContainer",
				"values": {
					"caption": "#ResourceString(AttachmentsTabContainer_caption)#",
					"visible": "$ComposerVisible | crt.InvertBooleanValue"
				}
			},
			{
				"operation": "merge",
				"name": "AttachmentList",
				"values": {
					"recordColumnName": "Activity",
					"layoutConfig": {},
					"items": "$FileList_ws2rkiu",
					"primaryColumnName": "FileList_ws2rkiuDS_Id",
					"columns": [
						{
							"id": "edea2af3-94ec-8e9d-9caf-703c229a75d7",
							"code": "FileList_ws2rkiuDS_Name",
							"caption": "#ResourceString(FileList_ws2rkiuDS_Name)#",
							"dataValueType": 28
						},
						{
							"id": "a64bc742-feae-924c-1348-e39cc120a29d",
							"code": "FileList_ws2rkiuDS_CreatedOn",
							"caption": "#ResourceString(FileList_ws2rkiuDS_CreatedOn)#",
							"dataValueType": 7
						},
						{
							"id": "204a55a5-f197-7161-48a9-1268bca0b3e5",
							"code": "FileList_ws2rkiuDS_CreatedBy",
							"caption": "#ResourceString(FileList_ws2rkiuDS_CreatedBy)#",
							"dataValueType": 10
						},
						{
							"id": "a1f435fc-92ff-baf7-f415-1bf7c6270155",
							"code": "FileList_ws2rkiuDS_Size",
							"caption": "#ResourceString(FileList_ws2rkiuDS_Size)#",
							"dataValueType": 4
						}
					],
					"rowToolbarItems": [],
					"visible": true,
					"droppable": false
				}
			},
			{
				"operation": "move",
				"name": "AttachmentList",
				"parentName": "FlexContainer_sllw0dz",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "remove",
				"name": "AttachmentsTabContainerHeaderContainer"
			},
			{
				"operation": "merge",
				"name": "AttachmentsTabContainerHeaderLabel",
				"values": {
					"caption": "#MacrosTemplateString(#ResourceString(Label_qh6twyb_caption)#)#",
					"visible": true
				}
			},
			{
				"operation": "move",
				"name": "AttachmentsTabContainerHeaderLabel",
				"parentName": "FlexContainer_g98tvxt",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "remove",
				"name": "AttachmentAddButton"
			},
			{
				"operation": "remove",
				"name": "AttachmentRefreshButton"
			},
			{
				"operation": "insert",
				"name": "ReplyButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ReplyButton_caption)#",
					"color": "accent",
					"disabled": false,
					"size": "large",
					"iconPosition": "left-icon",
					"layoutConfig": {},
					"visible": "$ReplyButtonVisible",
					"clicked": {
						"request": "crt.ReplyEmailPageRequest",
						"params": {
							"recordId": "$Id"
						}
					},
					"clickMode": "default",
					"icon": "email-button-icon"
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SummarizeButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(SummarizeButton_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-icon",
					"visible": true,
					"icon": "copilot-rewrite-btn-icon",
					"clicked": {
						"request": "crt.CopilotActionRequest",
						"params": {
							"prompt": "Summarize email"
						}
					},
					"clickMode": "default"
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "GridContainer_EmailComposer",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "none",
						"rowGap": "none"
					},
					"items": [],
					"fitContent": true,
					"padding": {
						"top": "medium",
						"right": "medium",
						"bottom": "medium",
						"left": "medium"
					},
					"color": "primary",
					"borderRadius": "none",
					"visible": "$ComposerVisible"
				},
				"parentName": "CardContentContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MessageComposerSelector",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.MessageComposerSelector",
					"items": []
				},
				"parentName": "GridContainer_EmailComposer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "EmailComposer",
				"values": {
					"type": "crt.EmailComposer",
					"classes": [
						"view-element"
					],
					"sortedByColumn": "CreatedOn",
					"data": {
						"uId": "0db39de6-6a2b-996e-b515-eee6ea6c3ed9",
						"schemaType": "Email",
						"sortedByColumn": "CreatedOn",
						"typeName": "crt.EmailComposer",
						"caption": "Email"
					},
					"emailComposerCleared": {
						"request": "crt.onEmailComposerClearedRequest"
					},
					"recordId": "$Id",
					"emailId": "$EmailId",
					"defaultSenderRequest": "crt.DefaultSenderComposerRequest",
					"entitySchemaName": "Activity",
					"expandOnLoad": true
				},
				"parentName": "MessageComposerSelector",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MessageTab",
				"values": {
					"caption": "#ResourceString(GeneralInfoTab_caption)#",
					"type": "crt.TabContainer",
					"items": [],
					"iconPosition": "only-text",
					"visible": true
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Input_1o1d6zh",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.StringAttribute_1f7oacn",
					"labelPosition": "auto",
					"control": "$StringAttribute_1f7oacn",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "GeneralInfoTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DateTimePicker_40lh0zp",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.DateTimePicker",
					"pickerType": "datetime",
					"label": "$Resources.Strings.SendDate",
					"labelPosition": "auto",
					"control": "$SendDate",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "GeneralInfoTabContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Input_bh923ll",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.StringAttribute_wue3gni",
					"labelPosition": "auto",
					"control": "$StringAttribute_wue3gni",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MessageTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Input_h81lhul",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.StringAttribute_femvk0g",
					"labelPosition": "auto",
					"control": "$StringAttribute_femvk0g",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MessageTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Input_e0pijnl",
				"values": {
					"type": "crt.Input",
					"multiline": false,
					"label": "$Resources.Strings.StringAttribute_bnepc3v",
					"labelPosition": "auto",
					"control": "$StringAttribute_bnepc3v",
					"visible": true,
					"readonly": true,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "MessageTab",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "EmailBodyIFrame",
				"values": {
					"type": "crt.IFrame",
					"isSandbox": true,
					"sandbox": "allow-same-origin allow-popups allow-popups-to-escape-sandbox",
					"htmlContent": "$EmailBody",
					"stretch": true,
					"visible": "$UseEmailBodyRichTextEditor | crt.InvertBooleanValue"
				},
				"parentName": "MessageTab",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "EmailBody",
				"values": {
					"type": "crt.RichTextEditor",
					"multiline": false,
					"label": "$Resources.Strings.StringAttribute_xuis68w",
					"labelPosition": "hidden",
					"control": "$EmailBody",
					"visible": "$UseEmailBodyRichTextEditor",
					"placeholder": "",
					"tooltip": "",
					"readonly": true
				},
				"parentName": "MessageTab",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "GridContainer_o8sjhpd",
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
						"rowGap": 0
					}
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ExpansionPanel_kb90i8i",
				"values": {
					"type": "crt.ExpansionPanel",
					"tools": [],
					"items": [],
					"title": "#ResourceString(ExpansionPanel_kb90i8i_title)#",
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
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridContainer_r75fga8",
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
				"parentName": "ExpansionPanel_kb90i8i",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_ojkvng0",
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
				"parentName": "GridContainer_r75fga8",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailRefreshBtn_xpb1hrb",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailRefreshBtn_xpb1hrb_caption)#",
					"icon": "reload-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.LoadDataRequest",
						"params": {
							"config": {
								"loadType": "reload"
							},
							"dataSourceName": "GridDetail_jj11595DS"
						}
					}
				},
				"parentName": "FlexContainer_ojkvng0",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailSettingsBtn_gedpuqq",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(GridDetailSettingsBtn_gedpuqq_caption)#",
					"icon": "actions-button-icon",
					"iconPosition": "only-icon",
					"color": "default",
					"size": "medium",
					"clickMode": "menu",
					"menuItems": []
				},
				"parentName": "FlexContainer_ojkvng0",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailExportDataBtn_sdroz27",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GridDetailExportDataBtn_sdroz27_caption)#",
					"icon": "export-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ExportDataGridToExcelRequest",
						"params": {
							"viewName": "GridDetail_jj11595"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_gedpuqq",
				"propertyName": "menuItems",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetailImportDataBtn_vp5z3z6",
				"values": {
					"type": "crt.MenuItem",
					"caption": "#ResourceString(GridDetailImportDataBtn_vp5z3z6_caption)#",
					"icon": "import-button-icon",
					"color": "default",
					"size": "medium",
					"clicked": {
						"request": "crt.ImportDataRequest",
						"params": {
							"entitySchemaName": "ActivityParticipant"
						}
					}
				},
				"parentName": "GridDetailSettingsBtn_gedpuqq",
				"propertyName": "menuItems",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "GridDetailSearchFilter_55p780w",
				"values": {
					"type": "crt.SearchFilter",
					"placeholder": "#ResourceString(GridDetailSearchFilter_55p780w_placeholder)#",
					"iconOnly": true,
					"_filterOptions": {
						"expose": [
							{
								"attribute": "GridDetailSearchFilter_55p780w_GridDetail_jj11595",
								"converters": [
									{
										"converter": "crt.SearchFilterAttributeConverter",
										"args": [
											"GridDetail_jj11595"
										]
									}
								]
							}
						],
						"from": [
							"GridDetailSearchFilter_55p780w_SearchValue",
							"GridDetailSearchFilter_55p780w_FilteredColumnsGroups"
						]
					}
				},
				"parentName": "FlexContainer_ojkvng0",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "GridContainer_ghnxrfq",
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
				"parentName": "ExpansionPanel_kb90i8i",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridDetail_jj11595",
				"values": {
					"type": "crt.DataGrid",
					"layoutConfig": {
						"colSpan": 2,
						"column": 1,
						"row": 1,
						"rowSpan": 6
					},
					"features": {
						"rows": {
							"selection": false,
							"numeration": false
						},
						"editable": {
							"enable": false,
							"itemsCreation": false
						}
					},
					"items": "$GridDetail_jj11595",
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "GridDetail_jj11595DS_Id",
					"columns": [
						{
							"id": "d93b0207-a6ae-63bc-9597-c5fee70939fd",
							"code": "GridDetail_jj11595DS_Participant",
							"path": "Participant",
							"caption": "#ResourceString(GridDetail_jj11595DS_Participant)#",
							"dataValueType": 10,
							"referenceSchemaName": "Contact",
							"width": 391
						},
						{
							"id": "bfc56870-e4ca-b02e-3a95-252a5e65e46f",
							"code": "GridDetail_jj11595DS_Role",
							"path": "Role",
							"caption": "#ResourceString(GridDetail_jj11595DS_Role)#",
							"dataValueType": 10,
							"referenceSchemaName": "ActivityParticipantRole",
							"width": 278
						},
						{
							"id": "4e7cf0a7-cd2e-d779-a91a-027c9e09722b",
							"code": "GridDetail_jj11595DS_ParticipantAccount",
							"path": "Participant.Account",
							"caption": "#ResourceString(GridDetail_jj11595DS_ParticipantAccount)#",
							"dataValueType": 10,
							"referenceSchemaName": "Account"
						},
						{
							"id": "395d9350-d139-806c-43b0-34c0fbabd445",
							"code": "GridDetail_jj11595DS_ParticipantJob",
							"path": "Participant.Job",
							"caption": "#ResourceString(GridDetail_jj11595DS_ParticipantJob)#",
							"dataValueType": 10,
							"referenceSchemaName": "Job"
						}
					]
				},
				"parentName": "GridContainer_ghnxrfq",
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
					"caption": "#ResourceString(ConnectionsTabContainer_caption)#",
					"iconPosition": "left-icon",
					"visible": "$ComposerVisible | crt.InvertBooleanValue",
					"icon": "gantt-chart-tab-icon"
				},
				"parentName": "CardToggleTabPanel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_rankbgy",
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
					"caption": "#MacrosTemplateString(#ResourceString(Label_v9e0gvg_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "#0D2E4E",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_rankbgy",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_xcsqs87",
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
				"name": "ComboBox_trqjvws",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_bxrm9cf",
					"labelPosition": "auto",
					"control": "$LookupAttribute_bxrm9cf",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": []
				},
				"parentName": "FlexContainer_xcsqs87",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "addRecord_jxahw51",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_jxahw51_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_trqjvws",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_xvd7y3i",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_q885fq2",
					"labelPosition": "auto",
					"control": "$LookupAttribute_q885fq2",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": []
				},
				"parentName": "ConnectionsTabContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "addRecord_u2ih2ms",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_u2ih2ms_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_xvd7y3i",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_sudsu7t",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LookupAttribute_5sqtahh",
					"labelPosition": "auto",
					"control": "$LookupAttribute_5sqtahh",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": []
				},
				"parentName": "ConnectionsTabContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "addRecord_hi4kfnp",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_hi4kfnp_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_sudsu7t",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_76kv6qn",
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
				"name": "FlexContainer_xbtb80n",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "FeedTabContainer",
				"propertyName": "tools",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_sllw0dz",
				"values": {
					"type": "crt.FlexContainer",
					"items": [],
					"direction": "column"
				},
				"parentName": "AttachmentsTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_g98tvxt",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"alignItems": "center",
					"items": []
				},
				"parentName": "AttachmentsTabContainer",
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
					"EmailId": {
						"from": [
							"Id",
							"IsReplyMode"
						],
						"converter": "crt.ConditionalEmailId"
					},
					"ComposerVisible": {
						"value": false
					},
					"UseEmailBodyRichTextEditor": {
						"value": false
					},
					"IsReplyMode": {
						"value": false
					},
					"ReplyButtonVisible": {
						"value": false
					},
					"VisibleCancelButton": {
						"value": false
					},
					"StringAttribute_1f7oacn": {
						"modelConfig": {
							"path": "ActivityDS.Sender"
						}
					},
					"StringAttribute_wue3gni": {
						"modelConfig": {
							"path": "ActivityDS.Recepient"
						}
					},
					"EmailBody": {
						"modelConfig": {
							"path": "ActivityDS.Body"
						}
					},
					"IsHtmlBody": {
						"modelConfig": {
							"path": "ActivityDS.IsHtmlBody"
						}
					},
					"FileList_ws2rkiu": {
						"isCollection": true,
						"modelConfig": {
							"path": "FileList_ws2rkiuDS",
							"sortingConfig": {
								"default": [
									{
										"columnName": "CreatedOn",
										"direction": "desc"
									}
								]
							}
						},
						"viewModelConfig": {
							"attributes": {
								"FileList_ws2rkiuDS_Name": {
									"modelConfig": {
										"path": "FileList_ws2rkiuDS.Name"
									}
								},
								"FileList_ws2rkiuDS_CreatedOn": {
									"modelConfig": {
										"path": "FileList_ws2rkiuDS.CreatedOn"
									}
								},
								"FileList_ws2rkiuDS_CreatedBy": {
									"modelConfig": {
										"path": "FileList_ws2rkiuDS.CreatedBy"
									}
								},
								"FileList_ws2rkiuDS_Size": {
									"modelConfig": {
										"path": "FileList_ws2rkiuDS.Size"
									}
								},
								"FileList_ws2rkiuDS_Id": {
									"modelConfig": {
										"path": "FileList_ws2rkiuDS.Id"
									}
								}
							}
						}
					},
					"LookupAttribute_bxrm9cf": {
						"modelConfig": {
							"path": "ActivityDS.SenderContact"
						}
					},
					"SendDate": {
						"modelConfig": {
							"path": "ActivityDS.SendDate"
						}
					},
					"StringAttribute_femvk0g": {
						"modelConfig": {
							"path": "ActivityDS.CopyRecepient"
						}
					},
					"LookupAttribute_q885fq2": {
						"modelConfig": {
							"path": "ActivityDS.Account"
						}
					},
					"LookupAttribute_5sqtahh": {
						"modelConfig": {
							"path": "ActivityDS.Contact"
						}
					},
					"StringAttribute_bnepc3v": {
						"modelConfig": {
							"path": "ActivityDS.BlindCopyRecepient"
						}
					},
					"GridDetail_jj11595": {
						"isCollection": true,
						"modelConfig": {
							"path": "GridDetail_jj11595DS",
							"filterAttributes": [
								{
									"name": "GridDetailSearchFilter_55p780w_GridDetail_jj11595",
									"loadOnChange": true
								}
							]
						},
						"viewModelConfig": {
							"attributes": {
								"GridDetail_jj11595DS_Participant": {
									"modelConfig": {
										"path": "GridDetail_jj11595DS.Participant"
									}
								},
								"GridDetail_jj11595DS_Role": {
									"modelConfig": {
										"path": "GridDetail_jj11595DS.Role"
									}
								},
								"GridDetail_jj11595DS_ParticipantAccount": {
									"modelConfig": {
										"path": "GridDetail_jj11595DS.ParticipantAccount"
									}
								},
								"GridDetail_jj11595DS_ParticipantJob": {
									"modelConfig": {
										"path": "GridDetail_jj11595DS.ParticipantJob"
									}
								},
								"GridDetail_jj11595DS_Id": {
									"modelConfig": {
										"path": "GridDetail_jj11595DS.Id"
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
					"primaryDataSourceName": "ActivityDS",
					"dependencies": {
						"GridDetail_jj11595DS": [
							{
								"attributePath": "Activity",
								"relationPath": "ActivityDS.Id"
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
					"ActivityDS": {
						"type": "crt.EntityDataSource",
						"scope": "page",
						"config": {
							"entitySchemaName": "Activity"
						}
					},
					"FileList_ws2rkiuDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "ActivityFile",
							"attributes": {
								"Name": {
									"path": "Name"
								},
								"CreatedOn": {
									"path": "CreatedOn"
								},
								"CreatedBy": {
									"path": "CreatedBy"
								},
								"Size": {
									"path": "Size"
								}
							}
						}
					},
					"GridDetail_jj11595DS": {
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
								"ParticipantAccount": {
									"type": "ForwardReference",
									"path": "Participant.Account"
								},
								"ParticipantJob": {
									"type": "ForwardReference",
									"path": "Participant.Job"
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: "crt.HandleViewModelInitRequest",
				handler: async (request, next) => {
					const featureService = new devkit.FeatureService();
					request.$context.UseEmailBodyRichTextEditor =
						await featureService.getFeatureState('UseEmailBodyRichTextEditor');
					return next?.handle(request);
				}
			},
			{
				request: "crt.ReplyEmailPageRequest",
				handler: async (request, next) => {
					request.$context.ComposerVisible = true;
					request.$context.IsReplyMode = true;
					const handlerChain = devkit.HandlerChainService.instance;
					const recordId = await request.$context.Id;
					await new Promise(resolve => setTimeout(resolve, 500));
					await handlerChain.process({
						type: 'crt.ReplyEmailComposerRequest',
						recordId,
						$context: request.$context
					});
					return next?.handle(request);
				},
			},
			{
				request: "crt.HandleViewModelAttributeChangeRequest",
				handler: async (request, next) => {
					const attributeName = request.attributeName;
					if (attributeName === 'IsChanged' || attributeName === 'ComposerVisible' || 
							attributeName === 'SendDate') {
						const emailSent = !!(await request.$context.SendDate);
						const composerVisible = await request.$context.ComposerVisible;
						const isChangedVm = await request.$context.IsChanged;
						request.$context.ReplyButtonVisible = emailSent && !composerVisible;
						request.$context.VisibleCancelButton = (composerVisible && emailSent) || isChangedVm;
					}
					return next?.handle(request);
				}
			},
			{
				request: "crt.CancelRecordChangesRequest",
				handler: async (request, next) => {
					request.$context.ComposerVisible = false;
					request.$context.IsReplyMode = false;
					return next?.handle(request);
				}
			},
			{
				request: "crt.HandleModelEventRequest",
				handler: async (request, next) => {
					const composerVisible = await request.$context.ComposerVisible;
					// Do not refresh page data while composer is visible.
					if (request.modelEvent?.type === 'update' && composerVisible) {
						return;
					}
					await next?.handle(request);
				}
			}
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});