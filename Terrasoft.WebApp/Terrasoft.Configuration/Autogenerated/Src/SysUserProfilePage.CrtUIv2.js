define("SysUserProfilePage", /**SCHEMA_DEPS*/["@creatio-devkit/common"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/(devkit)/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"name": "PageTitle",
				"values": {
					"caption": "$FullName"
				}
			},
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
				"name": "CancelButton",
				"values": {
					"color": "default",
					"size": "large",
					"iconPosition": "only-text"
				}
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
				"name": "TagSelect"
			},
			{
				"operation": "remove",
				"name": "CardToggleContainer"
			},
			{
				"operation": "remove",
				"name": "CardButtonToggleGroup"
			},
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"alignItems": "stretch"
				}
			},
			{
				"operation": "merge",
				"name": "SideContainer",
				"values": {
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
					"gap": "small",
					"wrap": "nowrap"
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
						"rowGap": "medium"
					},
					"visible": true
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
					"headerBackgroundColor": "auto"
				}
			},
			{
				"operation": "remove",
				"name": "GeneralInfoTab"
			},
			{
				"operation": "remove",
				"name": "GeneralInfoTabContainer"
			},
			{
				"operation": "remove",
				"name": "CardToggleTabPanel"
			},
			{
				"operation": "remove",
				"name": "FeedTabContainer"
			},
			{
				"operation": "remove",
				"name": "Feed"
			},
			{
				"operation": "remove",
				"name": "FeedTabContainerHeaderContainer"
			},
			{
				"operation": "remove",
				"name": "FeedTabContainerHeaderLabel"
			},
			{
				"operation": "remove",
				"name": "AttachmentsTabContainer"
			},
			{
				"operation": "remove",
				"name": "AttachmentList"
			},
			{
				"operation": "remove",
				"name": "AttachmentsTabContainerHeaderContainer"
			},
			{
				"operation": "remove",
				"name": "AttachmentsTabContainerHeaderLabel"
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
				"name": "Button_additional_settings",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(Button_additional_settings_caption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": true,
					"clicked": {
						"request": "crt.OpenUserProfilePageRequest"
					},
					"clickMode": "default",
					"layoutConfig": {}
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "AddTotpButton",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(AddTotpButtonCaption)#",
					"color": "default",
					"disabled": false,
					"size": "large",
					"iconPosition": "only-text",
					"visible": "$IsTotpVisible",
					"clicked": {
						"request": "crt.AddTotpRequest"
					},
					"clickMode": "default",
					"layoutConfig": {}
				},
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "UserCompactProfile",
				"values": {
					"type": "crt.UserCompactProfile",
					"readonly": false,
					"referenceColumn": "$Id",
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"visible": true
				},
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "LoginEmailFlexContainer",
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
				"parentName": "SideAreaProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Login",
				"values": {
					"layoutConfig": {},
					"type": "crt.Input",
					"multiline": false,
					"label": "#ResourceString(Login_label)#",
					"labelPosition": "above",
					"control": "$Username",
					"visible": true,
					"placeholder": "",
					"tooltip": "",
					"readonly": true
				},
				"parentName": "LoginEmailFlexContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "EmailInput_3u1xtv3",
				"values": {
					"layoutConfig": {},
					"type": "crt.EmailInput",
					"label": "$Resources.Strings.Email",
					"labelPosition": "above",
					"control": "$Email",
					"visible": "$IsEmailVisible",
					"readonly": true,
					"placeholder": "#ResourceString(EmailInput_3u1xtv3_placeholder)#",
					"tooltip": "#ResourceString(EmailInput_3u1xtv3_tooltip)#"
				},
				"parentName": "LoginEmailFlexContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "TabContainer_BasicInfo",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(TabContainer_BasicInfo_caption)#",
					"iconPosition": "only-text",
					"visible": true
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_BasicInfoInner",
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
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "large",
						"left": "none"
					},
					"color": "primary",
					"borderRadius": "none",
					"visible": true
				},
				"parentName": "TabContainer_BasicInfo",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_InnerColumns",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "medium"
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
				"parentName": "GridContainer_BasicInfoInner",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_Language",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.LanguageLookup",
					"labelPosition": "above",
					"control": "$LanguageLookup",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "",
					"tooltip": "#ResourceString(ComboBox_Language_tooltip)#"
				},
				"parentName": "GridContainer_InnerColumns",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_TimeZone",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.TimeZoneLookup",
					"labelPosition": "above",
					"control": "$TimeZoneLookup",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "#ResourceString(TimeZonePlaceholder)#",
					"tooltip": "#ResourceString(ComboBox_TimeZone_tooltip)#"
				},
				"parentName": "GridContainer_InnerColumns",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ComboBox_DateTimeFormat",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.DateTimeFormatLookup",
					"labelPosition": "above",
					"control": "$DateTimeFormatLookup",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": true,
					"placeholder": "#ResourceString(ComboBox_DateTimeFormat_placeholder)#",
					"tooltip": "#ResourceString(ComboBox_DateTimeFormat_tooltip)#",
					"readonly": false
				},
				"parentName": "GridContainer_InnerColumns",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ComboBox_NumberFormat",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 2,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.NumberFormatLookup",
					"labelPosition": "above",
					"control": "$NumberFormatLookup",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": "$IsNumberFormatLookupVisible",
					"readonly": false,
					"placeholder": "#ResourceString(ComboBox_NumberFormat_placeholder)#",
					"tooltip": "#ResourceString(ComboBox_NumberFormat_tooltip)#"
				},
				"parentName": "GridContainer_InnerColumns",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "FlexContainer_FirstDayOfWeek",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 3,
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
				"parentName": "GridContainer_InnerColumns",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ComboBox_WeekFirstDay",
				"values": {
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.SysUserProfileDS_WeekFirstDay_jor1f9n",
					"labelPosition": "above",
					"control": "$SysUserProfileDS_WeekFirstDay_jor1f9n",
					"listActions": [],
					"showValueAsLink": true,
					"controlActions": [],
					"visible": "$IsWeekFirstDayVisible",
					"readonly": false,
					"placeholder": "",
					"tooltip": "#ResourceString(ComboBox_nt6em4k_tooltip)#"
				},
				"parentName": "FlexContainer_FirstDayOfWeek",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "addRecord_itx5rgi",
				"values": {
					"code": "addRecord",
					"type": "crt.ComboboxSearchTextAction",
					"icon": "combobox-add-new",
					"caption": "#ResourceString(addRecord_itx5rgi_caption)#",
					"clicked": {
						"request": "crt.CreateRecordFromLookupRequest",
						"params": {}
					}
				},
				"parentName": "ComboBox_WeekFirstDay",
				"propertyName": "listActions",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ComboBox_Theme",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 3,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.ComboBox",
					"label": "$Resources.Strings.SysUserProfileDS_Theme_jz7hflc",
					"labelPosition": "above",
					"listActions": [],
					"controlActions": [],
					"showValueAsLink": false,
					"tooltip": "#ResourceString(ComboBox_Theme_tooltip)#",
					"placeholder": "#ResourceString(ComboBox_Theme_placeholder)#",
					"items": "$AvailableThemes",
					"value": "$Theme",
					"useStaticFiltering": true,
					"visible": "$IsThemeChangingEnabled",
					"readonly": false
				},
				"parentName": "GridContainer_InnerColumns",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "Checkbox_DisableAdvancedVisualEffects",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 4,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.DisableAdvancedVisualEffects",
					"labelPosition": "right",
					"control": "$DisableAdvancedVisualEffects",
					"tooltip": "#ResourceString(Checkbox_DisableAdvancedVisualEffects_tooltip)#"
				},
				"parentName": "GridContainer_InnerColumns",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "TabContainer_PasswordSettings",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(TabContainer_PasswordSettings_caption)#",
					"iconPosition": "only-text",
					"visible": true
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainer_9jap9ck",
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
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "TabContainer_PasswordSettings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "GridContainer_PasswordSettings",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "medium"
					},
					"items": [],
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "FlexContainer_9jap9ck",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_PasswordSettings",
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
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "GridContainer_PasswordSettings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_e2ayjhm",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_e2ayjhm_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainer_PasswordSettings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CurrentPasswordInput",
				"values": {
					"layoutConfig": {},
					"type": "crt.PasswordInput",
					"label": "#ResourceString(CurrentPasswordInput_label)#",
					"control": "$CurrentPassword",
					"placeholder": "",
					"tooltip": "",
					"readonly": false,
					"multiline": false,
					"labelPosition": "above",
					"visible": true
				},
				"parentName": "FlexContainer_PasswordSettings",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "NewPasswordInput",
				"values": {
					"layoutConfig": {},
					"type": "crt.PasswordInput",
					"label": "#ResourceString(NewPasswordInput_label)#",
					"control": "$NewUserPassword",
					"placeholder": "",
					"tooltip": "",
					"readonly": false,
					"multiline": false,
					"labelPosition": "above",
					"visible": true
				},
				"parentName": "FlexContainer_PasswordSettings",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "RepeatNewPasswordInput",
				"values": {
					"layoutConfig": {},
					"type": "crt.PasswordInput",
					"label": "#ResourceString(RepeatNewPasswordInput_label)#",
					"control": "$ConfirmUserPassword",
					"placeholder": "",
					"tooltip": "",
					"readonly": false,
					"multiline": false,
					"labelPosition": "above",
					"visible": true
				},
				"parentName": "FlexContainer_PasswordSettings",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ConfirmationCodeContainer",
				"values": {
					"type": "crt.GridContainer",
					"layoutConfig": {},
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "medium"
					},
					"items": [],
					"visible": "$ConfirmationCodeInputVisible",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "none",
						"right": "none",
						"bottom": "none",
						"left": "none"
					}
				},
				"parentName": "FlexContainer_PasswordSettings",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ConfirmationCodeInput",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.PasswordInput",
					"label": "#ResourceString(ConfirmationCodeInputLabel)#",
					"control": "$ConfirmationCode",
					"placeholder": "",
					"tooltip": "",
					"readonly": false,
					"multiline": false,
					"labelPosition": "above"
				},
				"parentName": "ConfirmationCodeContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ButtonSendTextCode",
				"values": {
					"layoutConfig": {
						"column": 2,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.Button",
					"caption": "#ResourceString(SendSmsButtonCaption)#",
					"color": "default",
					"size": "extra-large",
					"iconPosition": "only-text",
					"visible": "$TextCodeTwoFactorAuthFlowEnabled",
					"menuItems": [],
					"clickMode": "default",
					"clicked": {
						"request": "crt.SendTextCodeRequest"
					}
				},
				"parentName": "ConfirmationCodeContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Button_Change_Password",
				"values": {
					"layoutConfig": {},
					"type": "crt.Button",
					"caption": "#ResourceString(Button_Change_Password_caption)#",
					"color": "accent",
					"disabled": "$ButtonChangePasswordDisabled",
					"size": "large",
					"iconPosition": "only-text",
					"visible": true,
					"menuItems": [],
					"clickMode": "default",
					"clicked": {
						"request": "crt.ChangeUserPasswordRequest"
					}
				},
				"parentName": "FlexContainer_PasswordSettings",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "GridContainerTotpSettings",
				"values": {
					"type": "crt.GridContainer",
					"columns": [
						"minmax(32px, 1fr)",
						"minmax(32px, 1fr)"
					],
					"rows": "minmax(max-content, 32px)",
					"gap": {
						"columnGap": "large",
						"rowGap": "small"
					},
					"items": [],
					"fitContent": true,
					"visible": "$TotpSettingsVisibleForCurrentUser",
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "large",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch"
				},
				"parentName": "FlexContainer_9jap9ck",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainerTotpSettings",
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
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap",
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					}
				},
				"parentName": "GridContainerTotpSettings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Label_vim3a8k",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_vim3a8k_caption)#)#",
					"labelType": "headline-3",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainerTotpSettings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainerAuthApp",
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
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainerTotpSettings",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FlexContainerAuthAppHeader",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainerAuthApp",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "LabelAuthApp",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_0mu8kue_caption)#)#",
					"labelType": "body-large",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainerAuthAppHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainerTotpSetup",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": "$IsTotpSetupVisible",
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
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainerAuthApp",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LabelTotpSetup",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(LabelTotpSetup_caption)#)#",
					"labelType": "body",
					"labelThickness": "normal",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainerTotpSetup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_4aiqdjc",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainerTotpSetup",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ButtonTotpSetup",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ButtonTotpSetup_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.SetupTotpRequest",
						"params": {
							"referrer": "userprofile"
						}
					},
					"icon": "replace-squares-icon",
					"clickMode": "default"
				},
				"parentName": "FlexContainer_4aiqdjc",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainerResetTotp",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": "$IsTotpResetVisible",
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
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainerAuthApp",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "LabelTotpReset",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(LabelTotpReset_caption)#)#",
					"labelType": "body",
					"labelThickness": "normal",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainerResetTotp",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_53w9tjv",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainerResetTotp",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ButtonTotpReset",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ButtonTotpReset_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.ResetTotpRequest",
						"params": {
							"userName": "$Username"
						}
					},
					"icon": "close-button-icon",
					"clickMode": "default"
				},
				"parentName": "FlexContainer_53w9tjv",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainerRecoveryCode",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": "$IsRecoveryCodeVisible",
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
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainerTotpSettings",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "FlexContainerRecoveryCodeHeader",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "medium",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainerRecoveryCode",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "LabelRecoveryCode",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(LabelRecoveryCode_caption)#)#",
					"labelType": "body-large",
					"labelThickness": "default",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainerRecoveryCodeHeader",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainerRecoveryCodeGenerate",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": "$NotHaveRecoveryCodes",
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
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainerRecoveryCode",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LabelRecoveryCodeGenerate",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_5dlqvpz_caption)#)#",
					"labelType": "body",
					"labelThickness": "normal",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainerRecoveryCodeGenerate",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_dl7lsvc",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainerRecoveryCodeGenerate",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ButtonRecoveryCodeGenerate",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ButtonRecoveryCodeGenerate_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.GenerateRecoveryCodesRequest"
					},
					"icon": "add-button-icon",
					"clickMode": "default"
				},
				"parentName": "FlexContainer_dl7lsvc",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainerRecoveryCodeDelete",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "column",
					"items": [],
					"fitContent": true,
					"visible": "$HasRecoveryCodes",
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
					"gap": "small",
					"wrap": "nowrap"
				},
				"parentName": "FlexContainerRecoveryCode",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "LabelRecoveryCodeDelete",
				"values": {
					"type": "crt.Label",
					"caption": "#MacrosTemplateString(#ResourceString(Label_mx1kz3n_caption)#)#",
					"labelType": "body",
					"labelThickness": "normal",
					"labelEllipsis": false,
					"labelColor": "auto",
					"labelBackgroundColor": "transparent",
					"labelTextAlign": "start",
					"visible": true
				},
				"parentName": "FlexContainerRecoveryCodeDelete",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FlexContainer_9sg5wp6",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"items": [],
					"fitContent": true,
					"visible": true,
					"color": "transparent",
					"borderRadius": "none",
					"padding": {
						"top": "small",
						"right": "none",
						"bottom": "none",
						"left": "none"
					},
					"alignItems": "stretch",
					"justifyContent": "start",
					"gap": "small",
					"wrap": "wrap"
				},
				"parentName": "FlexContainerRecoveryCodeDelete",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ButtonRecoveryCodeRegenerate",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ButtonRecoveryCodeRegenerate_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.GenerateRecoveryCodesRequest"
					},
					"icon": "reload-icon",
					"clickMode": "default"
				},
				"parentName": "FlexContainer_9sg5wp6",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ButtonRecoveryCodeDelete",
				"values": {
					"type": "crt.Button",
					"caption": "#ResourceString(ButtonRecoveryCodeDelete_caption)#",
					"color": "default",
					"disabled": false,
					"size": "medium",
					"iconPosition": "left-icon",
					"visible": true,
					"clicked": {
						"request": "crt.DeleteRecoveryCodesRequest"
					},
					"icon": "delete-button-icon",
					"clickMode": "default"
				},
				"parentName": "FlexContainer_9sg5wp6",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "TabContainer_NotificationSettings",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(TabContainer_NotificationSettings_caption)#",
					"iconPosition": "only-text",
					"visible": true
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "NotificationSettingsByUser",
				"values": {
					"type": "crt.DataGrid",
					"features": {
						"rows": {
							"selection": false,
							"numeration": false,
							"toolbar": false
						},
						"editable": {
							"enable": true,
							"itemsCreation": false,
							"floatingEditPanel": false,
							"lookupItemsCreation": false
						},
						"columns": {
							"sorting": false,
							"toolbar": false,
							"dragAndDrop": false,
							"adding": false
						},
						"header": {
							"visible": true,
							"toolbar": false
						},
						"cells": {
							"selection": false
						}
					},
					"items": "$DataGrid_NotificationSettingsByUser",
					"activeRow": "$DataGrid_NotificationSettingsByUser_ActiveRow",
					"selectionState": "$DataGrid_NotificationSettingsByUser_SelectionState",
					"visible": true,
					"fitContent": true,
					"primaryColumnName": "DataGrid_NotificationSettingsByUserDS_Id",
					"columns": [
						{
							"id": "2f80904d-a0d3-2f33-cdf1-3a39c6c16e21",
							"code": "DataGrid_NotificationSettingsByUserDS_Name",
							"caption": "#ResourceString(DataGrid_NotificationSettingsByUserDS_Name)#",
							"dataValueType": 28,
							"width": 500,
							"readonly": true
						},
						{
							"id": "e71281c3-e6a1-acc6-3d62-3108d6e50c00",
							"code": "DataGrid_NotificationSettingsByUserDS_State",
							"caption": "#ResourceString(DataGrid_NotificationSettingsByUserDS_State)#",
							"dataValueType": 12
						}
					],
					"placeholder": false,
					"bulkActions": [],
					"rowToolbarItems": [],
					"headerToolbarItems": []
				},
				"parentName": "TabContainer_NotificationSettings",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AccessibilitySettingsTabContainer",
				"values": {
					"type": "crt.TabContainer",
					"items": [],
					"caption": "#ResourceString(AccessibilitySettingsTabContainer_caption)#",
					"iconPosition": "only-text",
					"visible": true
				},
				"parentName": "Tabs",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "AccessibilitySettingsContainer",
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
				"parentName": "AccessibilitySettingsTabContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UseAccessibleDesktopColorCheckbox",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 2,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.SysUserProfileDS_UseAccessibleDesktopColor_igzoxmf",
					"labelPosition": "right",
					"control": "$SysUserProfileDS_UseAccessibleDesktopColor_igzoxmf",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": "#ResourceString(UseAccessibleDesktopColorCheckbox_tooltip)#"
				},
				"parentName": "AccessibilitySettingsContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UseDefaultBrowserScrollbarStylesCheckbox",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 2,
						"colSpan": 2,
						"rowSpan": 1
					},
					"type": "crt.Checkbox",
					"label": "$Resources.Strings.SysUserProfileDS_UseDefaultBrowserScrollbarStyles_9gpkv80",
					"labelPosition": "right",
					"control": "$SysUserProfileDS_UseDefaultBrowserScrollbarStyles_9gpkv80",
					"visible": true,
					"readonly": false,
					"placeholder": "",
					"tooltip": ""
				},
				"parentName": "AccessibilitySettingsContainer",
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
					"IsNumberFormatLookupVisible": {
						"value": false
					},
					"IsEmailVisible": {
						"value": true
					},
					"ButtonChangePasswordDisabled": {
						"value": true
					},
					"ConfirmationCodeInputVisible": {
						"value": false
					},
					"IsTotpVisible": {
						"value": false
					},
					"TotpSettingsVisibleForCurrentUser": {
						"value": false
					},
					"IsTotpSetupVisible": {
						"value": false
					},
					"IsTotpResetVisible": {
						"value": false
					},
					"UseSeparatedPage2FA": {
						"value": false
					},
					"CurrentPassword": {
						"value": "",
						"validators": {
							"required": {
								"type": "crt.Required"
							}
						}
					},
					"NewUserPassword": {
						"value": "",
						"validators": {
							"required": {
								"type": "crt.Required"
							},
							"complexity": {
								"type": "crt.UserPasswordComplexity"
							},
							"history": {
								"type": "crt.UserPasswordHistory"
							},
							"usernameEqual": {
								"type": "crt.UserPasswordLoginEquality"
							}
						}
					},
					"ConfirmUserPassword": {
						"value": "",
						"validators": {
							"required": {
								"type": "crt.Required"
							},
							"equal": {
								"type": "crt.PasswordsDoNotMatch",
								"params": {
									"message": "#ResourceString(PasswordsDoNotMatch)#"
								}
							}
						}
					},
					"ConfirmationCode": {
						"value": "",
						"validators": {
							"required": {
								"type": "crt.Required"
							}
						}
					},
					"LanguageLookup": {
						"modelConfig": {
							"path": "SysUserProfileDS.Language"
						}
					},
					"TimeZoneLookup": {
						"modelConfig": {
							"path": "SysUserProfileDS.TimeZone"
						}
					},
					"DateTimeFormatLookup": {
						"modelConfig": {
							"path": "SysUserProfileDS.DateTimeFormat"
						}
					},
					"EnablePopups": {
						"modelConfig": {
							"path": "SysUserProfileDS.EnablePopups"
						}
					},
					"DisableAdvancedVisualEffects": {
						"modelConfig": {
							"path": "SysUserProfileDS.DisableAdvancedVisualEffects"
						}
					},
					"Username": {
						"modelConfig": {
							"path": "SysUserProfileDS.Username"
						}
					},
					"Contact": {
						"modelConfig": {
							"path": "SysUserProfileDS.Contact"
						}
					},
					"FullName": {
						"modelConfig": {
							"path": "SysUserProfileDS.FullName"
						}
					},
					"Email": {
						"modelConfig": {
							"path": "SysUserProfileDS.Email"
						}
					},
					"Photo": {
						"modelConfig": {
							"path": "SysUserProfileDS.Photo"
						}
					},
					"TextCodeTwoFactorAuthFlowEnabled": {
						"value": false
					},
					"TextCodeTwoFactorAuthFlowIsPrimary": {
						"value": false
					},
					"TotpTwoFactorAuthFlowEnabled": {
						"value": false
					},
					"TotpEnabledForCurrentUser": {
						"value": false
					},
					"Enable2FA": {
						"value": false
					},
					"CanUse2FA": {
						"value": false
					},
					"IsRecoveryCodeVisible": {
						"value": false
					},
					"HasRecoveryCodes": {
						"value": false
					},
					"NotHaveRecoveryCodes": {
						"value": false
					},
					"RecoveryCodeTwoFactorAuthFlowEnabled": {
						"value": false
					},
					"NumberFormatLookup": {
						"modelConfig": {
							"path": "SysUserProfileDS.NumberFormat"
						}
					},
					"IsWeekFirstDayVisible": {
						"value": false
					},
					"Theme": {
						"value": null,
					},
					"InitialThemeId": {
						"value": null,
					},
					"AvailableThemes": {
						"value": []
					},
					"IsThemeChangingEnabled": {
						"value": false
					},
					"SysUserProfileDS_WeekFirstDay_jor1f9n": {
						"modelConfig": {
							"path": "SysUserProfileDS.WeekFirstDay"
						}
					},
					"DataGrid_NotificationSettingsByUser": {
						"isCollection": true,
						"modelConfig": {
							"path": "DataGrid_NotificationSettingsByUserDS",
							"sortingConfig": {
								"default": [
									{
										"direction": "asc",
										"columnName": "Name"
									}
								]
							}
						},
						"viewModelConfig": {
							"attributes": {
								"DataGrid_NotificationSettingsByUserDS_Name": {
									"modelConfig": {
										"path": "DataGrid_NotificationSettingsByUserDS.Name"
									}
								},
								"DataGrid_NotificationSettingsByUserDS_State": {
									"modelConfig": {
										"path": "DataGrid_NotificationSettingsByUserDS.State"
									}
								},
								"DataGrid_NotificationSettingsByUserDS_Id": {
									"modelConfig": {
										"path": "DataGrid_NotificationSettingsByUserDS.Id"
									}
								}
							}
						}
					},
					"SysUserProfileDS_UseAccessibleDesktopColor_igzoxmf": {
						"modelConfig": {
							"path": "SysUserProfileDS.UseAccessibleDesktopColor"
						}
					},
					"SysUserProfileDS_UseDefaultBrowserScrollbarStyles_9gpkv80": {
						"modelConfig": {
							"path": "SysUserProfileDS.UseDefaultBrowserScrollbarStyles"
						}
					},
					"SysUserProfileDS_Theme_jz7hflc": {
						"modelConfig": {
							"path": "SysUserProfileDS.Theme"
						}
					}
				}
			},
			{
				"operation": "merge",
				"path": [
					"attributes",
					"CardState"
				],
				"values": {
					"value": "edit"
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
					"path": "SysUserProfileDS.Id"
				}
			}
		]/**SCHEMA_VIEW_MODEL_CONFIG_DIFF*/,
		modelConfigDiff: /**SCHEMA_MODEL_CONFIG_DIFF*/[
			{
				"operation": "merge",
				"path": [],
				"values": {
					"primaryDataSourceName": "SysUserProfileDS"
				}
			},
			{
				"operation": "merge",
				"path": [
					"dataSources"
				],
				"values": {
					"SysUserProfileDS": {
						"type": "crt.EntityDataSource",
						"scope": "page",
						"config": {
							"entitySchemaName": "SysUserProfile"
						}
					},
					"DataGrid_NotificationSettingsByUserDS": {
						"type": "crt.EntityDataSource",
						"scope": "viewElement",
						"config": {
							"entitySchemaName": "NotifySettingsByUser",
							"attributes": {
								"Name": {
									"path": "Name"
								},
								"State": {
									"path": "State"
								}
							}
						}
					}
				}
			}
		]/**SCHEMA_MODEL_CONFIG_DIFF*/,
		handlers: /**SCHEMA_HANDLERS*/[
			{
				request: "crt.InitializeThemeRequest",
				handler: async (request, next) => {
					const featureService = new devkit.FeatureService();
					const isFeatureDisabled = await featureService.getFeatureState('DisableChangeTheme');
					if (isFeatureDisabled) {
						return next?.handle(request);
					}
					const themeService = new devkit.ThemeService();
					const [canCustomizeBranding, canChangeOwnTheme] = await Promise.all([
						themeService.canCustomizeBranding(),
						themeService.canChangeOwnTheme()
					]);
					if (!canCustomizeBranding || !canChangeOwnTheme) {
						return next?.handle(request);
					}
					const availableThemes = await themeService.getAvailableThemes();
					const availableThemesLookupItems = Object.freeze(
						availableThemes.map(({ id, caption }) =>
							Object.freeze({
								value: id,
								displayValue: caption
							}),
						),
					);
					request.$context.InitialThemeId = await request.$context.SysUserProfileDS_Theme_jz7hflc;
					request.$context.AvailableThemes = availableThemesLookupItems;
					request.$context.IsThemeChangingEnabled = true;
					const handlerChain = devkit.HandlerChainService.instance;
					await handlerChain.process({
						type: "crt.UpdateThemeAttributeRequest",
						$context: request.$context,
						scopes: [...request.scopes]
					});
					return next?.handle(request);
				}
			},
			{
				request: "crt.ApplyThemeRequest",
				handler: async (request, next) => {
					if (!(await request.$context.IsThemeChangingEnabled)) {
						return next?.handle(request);
					}
					const themeId = request.themeId ?? "";
					const themeService = new devkit.ThemeService();
					await themeService.applyTheme(themeId);
					request.$context.SysUserProfileDS_Theme_jz7hflc = themeId;
					return next?.handle(request);
				}
			},
			{
				request: "crt.UpdateThemeAttributeRequest",
				handler: async (request, next) => {
					if (!(await request.$context.IsThemeChangingEnabled)) {
						return next?.handle(request);
					}
					const themeId = await request.$context.SysUserProfileDS_Theme_jz7hflc;
					const availableThemes = await request.$context.AvailableThemes;
					request.$context.Theme = availableThemes.find((theme) => theme.value === themeId) || null;
					return next?.handle(request);
				}
			},
			{
				request: "crt.RestoreInitialThemeRequest",
				handler: async (request, next) => {
					if (!(await request.$context.IsThemeChangingEnabled)) {
						return next?.handle(request);
					}
					const initialThemeId = (await request.$context.InitialThemeId) ?? "";
					const currentThemeId = (await request.$context.SysUserProfileDS_Theme_jz7hflc) ?? "";
					if (currentThemeId === initialThemeId) {
						return next?.handle(request);
					}
					const handlerChain = devkit.HandlerChainService.instance;
					await handlerChain.process({
						type: "crt.ApplyThemeRequest",
						$context: request.$context,
						scopes: [...request.scopes],
						themeId: initialThemeId,
					});
					return next?.handle(request);
				}
			},
			{
				request: 'crt.SaveRecordRequest',
				handler: async (request, next) => {
					result = await next?.handle(request);
					if (result) {
						const httpClientService = new devkit.HttpClientService();
						const endpoint = "/rest/SysUserProfileRefreshService/RefreshCurrentUser";
						const response = await httpClientService.post(endpoint);
						if (response?.body?.success && response?.body?.errorInfo === null) {
							const resetWorkplaceCacheEndpoint = "/rest/WorkplaceService/ResetWorkplaceCache";
							const resetCacheResponce = await httpClientService.post(resetWorkplaceCacheEndpoint);
							if (resetCacheResponce?.ok) {
								window.location.reload(true);
							}
						}
					}
				}
			},
			{
				request: 'crt.HandleViewModelInitRequest',
				handler: async (request, next) => {
					const handlerChain = devkit.HandlerChainService.instance;
					await handlerChain.process({
						type: 'crt.LoadDataRequest',
						$context: request.$context,
						config: {
							loadType: "reload"
						},
						dataSourceName: "SysUserProfileDS"
					});
					const email = await request.$context.Email;
					const userName = await request.$context.Username;
					request.$context.IsEmailVisible = email != '' && email !== userName;
					await handlerChain.process({
						type: "crt.InitializeThemeRequest",
						$context: request.$context,
						scopes: [...request.scopes]
					});
					await handlerChain.process({
						type: 'crt.GetAuthenticationSettingsRequest',
						$context: request.$context,
						config: {
							loadType: "reload"
						}
					});
					const useSeparatedPage2FA = await request.$context.UseSeparatedPage2FA;
					const enable2FA = await request.$context.Enable2FA;
					const totpTwoFactorAuthFlowEnabled = (await request.$context.TotpTwoFactorAuthFlowEnabled);
					const totpEnabledForCurrentUser = await request.$context.TotpEnabledForCurrentUser;
					const totpSettingsVisibleForCurrentUser = await request.$context.TotpSettingsVisibleForCurrentUser && useSeparatedPage2FA;
					request.$context.TotpSettingsVisibleForCurrentUser = totpSettingsVisibleForCurrentUser;
					request.$context.ConfirmationCodeInputVisible = enable2FA && !useSeparatedPage2FA;
					request.$context.IsTotpSetupVisible = !totpEnabledForCurrentUser;
					request.$context.IsTotpResetVisible = totpEnabledForCurrentUser;
					request.$context.IsTotpVisible = enable2FA 
						&& !totpEnabledForCurrentUser
						&& totpTwoFactorAuthFlowEnabled 
						&& !useSeparatedPage2FA;
					// Recovery codes
					const recoveryCodeTwoFactorAuthFlowEnabled = await request.$context.RecoveryCodeTwoFactorAuthFlowEnabled;
					request.$context.IsRecoveryCodeVisible = recoveryCodeTwoFactorAuthFlowEnabled;
					if (totpSettingsVisibleForCurrentUser && recoveryCodeTwoFactorAuthFlowEnabled) {
						await handlerChain.process({
							type: 'crt.GetIsRecoveryCodesGeneratedRequest', 
							$context: request.$context,
							config: {
								loadType: "reload"
							}
						});
					}
					const featureService = new devkit.FeatureService();
					const isDisableNumberFormatLookup = await featureService.getFeatureState('DisableCustomNumberFormat');
					const isWeekFirstDayVisible = await featureService.getFeatureState('EnableWeekFirstDayConfiguration');
					request.$context.IsNumberFormatLookupVisible = !isDisableNumberFormatLookup && !Terrasoft.getIsRtlMode();
					request.$context.IsWeekFirstDayVisible = isWeekFirstDayVisible;
				}
			},
			{
				request: "crt.LoadDataRequest",
				handler: async (request, next) => {
					var languageDataSourceName = 'LanguageLookup_List_DS';
					if(request.dataSourceName !== languageDataSourceName) {
						return await next?.handle(request);
					}
					request.parameters.push({
						type: "filter",
						value: {
							"items": {
								"8533d26b-cedc-4a3f-b701-c58775182a8d": {
									"filterType": 1,
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "[SysCulture:Language].Active"
									},
									"isAggregative": false,
									"dataValueType": 1,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 12,
											"value": 1
										}
									}
								}
							},
							"logicalOperation": 0,
							"isEnabled": true,
							"filterType": 6,
							"rootSchemaName": "SysLanguage"
						}
					});
					return await next?.handle(request);
				}
			},
			{
				request: "crt.HandleViewModelAttributeChangeRequest",
				handler: async (request, next) => {
					if (request.attributeName === "Theme" && typeof request.value !== "string") {
						const handlerChain = devkit.HandlerChainService.instance;
						await handlerChain.process({
							type: "crt.ApplyThemeRequest",
							$context: request.$context,
							scopes: [...request.scopes],
							themeId: request.value?.value
						});
					}
					if (request.attributeName === "SysUserProfileDS_Theme_jz7hflc") {
						const handlerChain = devkit.HandlerChainService.instance;
						await handlerChain.process({
							type: "crt.UpdateThemeAttributeRequest",
							$context: request.$context,
							scopes: [...request.scopes],
						});
					}
					if (request.attributeName === 'CurrentPassword' || request.attributeName === 'NewUserPassword'
							|| request.attributeName === 'ConfirmUserPassword'
							|| request.attributeName === 'ConfirmationCode') {
						request.$context.ButtonChangePasswordDisabled = true;
						const currentPasswordValue = await request.$context.CurrentPassword;
						const newUserPasswordValue = await request.$context.NewUserPassword;
						const confirmUserPasswordValue = await request.$context.ConfirmUserPassword;
						const username = await request.$context.Username;
						if (newUserPasswordValue !== confirmUserPasswordValue) {
							await request.$context.enableAttributeValidator('ConfirmUserPassword', 'equal');
						} else {
							await request.$context.disableAttributeValidator('ConfirmUserPassword', 'equal');
						}
						if (username.toLowerCase() === newUserPasswordValue?.toLowerCase()) {
							await request.$context.enableAttributeValidator('NewUserPassword', 'usernameEqual');
						} else {
							await request.$context.disableAttributeValidator('NewUserPassword', 'usernameEqual');
						}
						if (newUserPasswordValue === currentPasswordValue) {
							await request.$context.enableAttributeValidator('NewUserPassword', 'history');
						} else {
							await request.$context.disableAttributeValidator('NewUserPassword', 'history');
						}
						const enable2FA = await request.$context.Enable2FA;
						const useSeparatedPage2FA = await request.$context.UseSeparatedPage2FA;
						if (enable2FA && !useSeparatedPage2FA) {
							await request.$context.enableAttributeValidator('ConfirmationCode', 'required');
						} else {
							await request.$context.disableAttributeValidator('ConfirmationCode', 'required');
						}
						if ((!enable2FA || (enable2FA && !useSeparatedPage2FA)
								|| request.$context.formApiModel.controls.ConfirmationCode.status === 'VALID')
								&& request.$context.formApiModel.controls.CurrentPassword.status === 'VALID'
								&& request.$context.formApiModel.controls.NewUserPassword.status === 'VALID' 
								&& request.$context.formApiModel.controls.ConfirmUserPassword.status === 'VALID') {
							request.$context.ButtonChangePasswordDisabled = false;
						}
					}
					return next?.handle(request);
				}
			},
			{
				request: 'crt.HandleViewModelPauseRequest',
				handler: async (request, next) => {
					const handlerChain = devkit.HandlerChainService.instance;
					await handlerChain.process({
						type: "crt.RestoreInitialThemeRequest",
						$context: request.$context,
						scopes: [...request.scopes]
					});
					return next?.handle(request);
				}
			}
		]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{
			"crt.PasswordsDoNotMatch": {
				"validator": function (config) {
					return function (control) {
						return control.value === '' ? null: {
							"crt.PasswordsDoNotMatch": { message: config.message }
						};
					};
				},
				"params": [
					{
						"name": "message"
					}
				],
				"async": false
			}
		}/**SCHEMA_VALIDATORS*/
	};
});