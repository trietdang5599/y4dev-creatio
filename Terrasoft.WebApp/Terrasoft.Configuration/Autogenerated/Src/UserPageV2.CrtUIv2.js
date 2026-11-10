define("UserPageV2", ["UserPageV2Resources", "ServiceHelper", "BusinessRuleModule", "ConfigurationConstants", "EmailHelper",
		"ViewUtilities", "RightUtilities", "ProcessModuleUtilities", "css!AdministrationCSSV2"],
	function(resources, ServiceHelper, BusinessRuleModule, ConfigurationConstants, EmailHelper, ViewUtilities, RightUtilities,
			 ProcessModuleUtilities) {
		return {
			entitySchemaName: "VwSysAdminUnit",
			messages: {

				/**
				 * @message GetChiefId
				 * ############ ### ######## ############## ####### #### ############.
				 */
				"GetChiefId": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message SetRecordInformation
				 * ########## ######, ######### ## ####### ######### # ############ ####### ###### #
				 * #### ########### ######.
				 */
				"SetRecordInformation": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message UpdateSectionGrid
				 * ######## ####### # ############# ############# ######, ##### ######## ########.
				 * ############## ####### #######
				 */
				"UpdateSectionGrid": {
					mode: this.Terrasoft.MessageMode.BROADCAST,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				"UnblockUser": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				"DeleteUser": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				},

				"UserDeletedSuccessfully": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

				"SetIsUserBlocked": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},

                "RolesChanged": {
    				mode: Terrasoft.MessageMode.BROADCAST,
    				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
    			}

			},
			details: /**SCHEMA_DETAILS*/{
				SysAdminUnitIPRangeDetailV2: {
					schemaName: "SysAdminUnitIPRangeDetailV2",
					filter: {
						masterColumn: "Id"
					}
				},
				SessionDetailV2: {
					schemaName: "SessionDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysUser"
					}
				},
				SysFuncRoleInUserDetailV2: {
					schemaName: "SysFuncRoleInUserDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysUser"
					}
				},
				SysOrgRoleInUserDetailV2: {
					schemaName: "SysOrgRoleInUserDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysUser"
					}
				},
				SysAdminUnitGrantedRightDetailV2: {
					schemaName: "SysAdminUnitGrantedRightDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "GrantorSysAdminUnit"
					},
					filterMethod: "getSysAdminUnitGrantedRightDetailV2Filters"
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "CardContentContainer",
					"values": {
						"wrapClass": ["UserPageV2", "center-main-container"]
					}
				},
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "actions"
				},
				{
					"operation": "remove",
					"name": "ViewOptionsButton"
				},
				{
					"operation": "insert",
					"name": "DeleteButton",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.DeleteButtonCaption"},
						"classes": {"textClass": "actions-button-margin-right"},
						"click": {"bindTo": "onDeleteClick"}
					}
				},
				{
					"operation": "insert",
					"name": "UserUnblockButton",
					"parentName": "LeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.UnblockUserButtonCaption"},
						"classes": {"textClass": "actions-button-margin-right"},
						"click": {"bindTo": "onUnblockClick"},
						"visible": {"bindTo": "IsUserBlocked"},
						"hint": {"bindTo": "Resources.Strings.BlockedUserLabelCaption"}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "PhotoContainer",
					"values": {
						"visible": Terrasoft.Features.getIsEnabled("SysAdminUnitFeatures.ShowContactInAdminUnit"),
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"wrapClass": ["image-edit-container"],
						"layout": {"column": 0, "row": 0, "rowSpan": 3, "colSpan": 1},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "PhotoContainer",
					"propertyName": "items",
					"name": "Photo",
					"values": {
						"getSrcMethod": "getSrcMethod",
						"onPhotoChange": "onPhotoChange",
						"beforeFileSelected": "beforeFileSelected",
						"readonly": true,
						"defaultImage": {"bindTo": "getUserDefaultImageURL"},
						"generator": "ImageCustomGeneratorV2.generateCustomImageControl"
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0,
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1,
					"name": "RolesTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.RolesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "RolesTab",
					"propertyName": "items",
					"name": "SysOrgRoleInUserDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "RolesTab",
					"propertyName": "items",
					"name": "SysFuncRoleInUserDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2,
					"name": "LicenseTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SysLicUserTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 3,
					"name": "GrantedRightsTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.GrantedRightsTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "GrantedRightsTab",
					"propertyName": "items",
					"name": "SysAdminUnitGrantedRightDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 4,
					"name": "AccessRulesTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AccessRulesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "AccessRulesTab",
					"propertyName": "items",
					"name": "SysAdminUnitIPRangeDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "SessionSettingsGroup",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.SessionGroupCaption"
						}
					},
					"parentName": "AccessRulesTab",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "SessionTimeout",
					"parentName": "SessionSettingsGroup",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.TEXT,
						"caption": {
							"bindTo": "Resources.Strings.SessionTimeoutTitle"
						},
						"value": {"bindTo": "SessionTimeout"}
					}
				},
				{
					"operation": "insert",
					"parentName": "AccessRulesTab",
					"propertyName": "items",
					"name": "SessionDetailV2",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "Contact",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"visible": Terrasoft.Features.getIsEnabled("SysAdminUnitFeatures.ShowContactInAdminUnit"),
						"dataValueType": this.Terrasoft.DataValueType.LOOKUP,
						"value": {"bindTo": "Contact"},
						"layout": {"column": 1, "row": 0, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "SysCulture",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.ENUM,
						"value": {"bindTo": "SysCulture"},
						"layout": {"column": 13, "row": 0, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "DateTimeFormat",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": Terrasoft.DataValueType.ENUM,
						"value": {"bindTo": "DateTimeFormat"},
						"layout": {"column": 13, "row": 1, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "TimeZone",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.ENUM,
						"caption": {"bindTo": "Resources.Strings.TimeZoneCaption"},						
						"value": {"bindTo": "TimeZone"},
						"layout": {"column": 13, "row": 2, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "WeekFirstDay",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.ENUM,
						"caption": {"bindTo": "Resources.Strings.WeekFirstDayCaption"},						
						"value": {"bindTo": "WeekFirstDay"},
						"layout": {"column": 13, "row": 3, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "UserConnectionType",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.ENUM,
						"caption": {"bindTo": "Resources.Strings.TypeCaption"},
						"value": {"bindTo": "UserConnectionType"},
						"enabled": { "bindTo": "ActiveAllPortalUsersGroup" },
						"layout": {"column": 1, "row": 1, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"name": "HomePage",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.LOOKUP,
						"value": {"bindTo": "HomePage"},
						"layout": {"column": 1, "row": 3, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "MobileHomePage",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.LOOKUP,
						"contentType": this.Terrasoft.ContentType.ENUM,
						"value": {"bindTo": "MobileHomePage"},
						"layout": {"column": 1, "row": 4, "colSpan": 8}
					}
				},
				{
					"operation": "insert",
					"name": "Active",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 1, "row": 2, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"name": "AuthControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.AuthControlGroupCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "LicenseTab",
					"name": "LicenseControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTROL_GROUP,
						"caption": {"bindTo": "Resources.Strings.SysLicUserTabCaption"},
						"items": [],
						"tools": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "ToolsButton",
					"parentName": "LicenseControlGroup",
					"propertyName": "tools",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.ToolsButtonImage"},
						"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"wrapperClass": ["license-tools-button-wrapper", "license-t-btn-wrapper"],
							"menuClass": ["license-tools-button-menu"]
						},
						"menu": []
					}
				},
				{
					"operation": "insert",
					"name": "CheckAllLicenses",
					"parentName": "ToolsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CheckLicensesCaption"},
						"click": {"bindTo": "onCheckAllLicenses"},
						"enabled": {"bindTo": "isLicenseActionsEnabled"}
					}
				},
				{
					"operation": "insert",
					"name": "UncheckAllLicenses",
					"parentName": "ToolsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.UncheckLicensesCaption"},
						"click": {"bindTo": "onUncheckAllLicenses"},
						"enabled": {"bindTo": "isLicenseActionsEnabled"}
					}
				},
				{
					"operation": "insert",
					"name": "RedistributeLicensesBasedOnRole",
					"parentName": "ToolsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.RedistributeLicensesBasedOnRoleCaption"},
						"click": {"bindTo": "onRedistributeLicensesBasedOnRole"},
						"enabled": {"bindTo": "isRoleBasedLicenseDistributionButtonEnabled"},
						"visible": {"bindTo": "isRoleBasedLicenseDistributionButtonVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "LicenseList",
					"parentName": "LicenseControlGroup",
					"propertyName": "items",
					"values": {
						"generator": "ConfigurationItemGenerator.generateContainerList",
						"idProperty": "Id",
						"collection": "LicenseCollection",
						"observableRowNumber": 15,
						"onGetItemConfig": "getItemViewConfig",
						"dataItemIdPrefix": "lic-item"
					}
				},
				{
					"operation": "insert",
					"parentName": "AuthControlGroup",
					"name": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FormAuthGridLayout",
					"name": "FormUserNameControlLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 12},
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Name",
					"parentName": "FormUserNameControlLayout",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isNameEnabled"},
						"dataValueType": this.Terrasoft.DataValueType.TEXT,
						"caption": {"bindTo": "Resources.Strings.UserNameCaption"},
						"value": {"bindTo": "Name"},
						"enabled": {"bindTo": "isNameEnabled"},
						"isRequired": {"bindTo": "isNameRequired"},
						"tip": {
							"content": {
								"bindTo": "Resources.Strings.UserNameTip"
							}
						}
					},
					"dependencies": [{
						"columns": ["Name"]
					}]
				},
				{
					"operation": "insert",
					"name": "NamePlaceholder",
					"parentName": "FormUserNameControlLayout",
					"propertyName": "items",
					"values": {
						"visible": {"bindTo": "isNamePlaceholderVisible"},
						"dataValueType": this.Terrasoft.DataValueType.TEXT,
						"caption": {"bindTo": "Resources.Strings.UserNameCaption"},
						"enabled": false,
						"isRequired": false,
						"controlConfig": {
							"markerValue": "ParameterCodeMarker",
							"placeholder": {"bindTo": "Resources.Strings.UserNamePlaceholder"},
							"classes": "placeholderOpacity",
							"autocomplete": Terrasoft.generateGUID()
						},
						"tip": {
							"content": {
								"bindTo": "Resources.Strings.UserNameTip"
							}
						}
					},
					"dependencies": [{
						"columns": ["Name"]
					}]
				},
				{
					"operation": "insert",
					"name": "Email",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.TEXT,
						"caption": {"bindTo": "Resources.Strings.UserEmailCaption"},
						"value": {"bindTo": "Email"},
						"layout": {"column": 0, "row": 1, "colSpan": 12},
						"isRequired": {"bindTo": "isEmailRequired"}
					},
					"dependencies": [{
						"columns": ["Email"]
					}]
				},
				{
					"operation": "insert",
					"name": "Phone",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.TEXT,
						"caption": {"bindTo": "Resources.Strings.PhoneCaption"},
						"value": {"bindTo": "Phone"},
						"layout": {"column": 0, "row": 2, "colSpan": 12}
					},
					"dependencies": [{
						"columns": ["Phone"]
					}]
				},
				{
					"operation": "insert",
					"name": "UserPassword",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"id": "new-password",
						"selectors": {"wrapEl": "#new-password"},
						"caption": {"bindTo": "Resources.Strings.PasswordCaption"},
						"value": {"bindTo": "UserPassword"},
						"layout": {"column": 0, "row": 3, "colSpan": 12},
						"controlConfig": {
							"protect": true,
							"keyup": {
								"bindTo": "onNewPasswordKeypress"
							}
						},
						"isRequired": {bindTo: "isRequiredFieldsVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "PasswordConfirmation",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"id": "new-password-confirmation",
						"selectors": {"wrapEl": "#new-password-confirmation"},
						"value": {"bindTo": "PasswordConfirmation"},
						"caption": {"bindTo": "Resources.Strings.PasswordConfirmationCaption"},
						"layout": {"column": 0, "row": 4, "colSpan": 12},
						"controlConfig": {
							"protect": true,
							"keyup": {
								"bindTo": "onNewPasswordConfirmationKeypress"
							}
						},
						"isRequired": {bindTo: "isRequiredFieldsVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "PasswordExpireDate",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"dataValueType": this.Terrasoft.DataValueType.DATE,
						"value": {"bindTo": "PasswordExpireDate"},
						"layout": {"column": 0, "row": 5, "colSpan": 12}
					}
				},
				{
					"operation": "insert",
					"name": "ForceChangePassword",
					"parentName": "FormAuthGridLayout",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 6, "colSpan": 12}
					}
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				/**
				 * User name.
				 */
				"Name": {
					dependencies: [{
						columns: ["Email"],
						methodName: "setNameFromEmail"
					}],
					validateOrder: 4
				},
				"Email": {
					validateOrder: 5
				},
				/**
				 * User password.
				 */
				"UserPassword": {
					dataValueType: this.Terrasoft.DataValueType.TEXT,
					validateOrder: 6
				},
				/**
				 * Password confirmation.
				 */
				"PasswordConfirmation": {
					dataValueType: this.Terrasoft.DataValueType.TEXT,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					caption: resources.localizableStrings.PasswordConfirmationCaption,
					validateOrder: 7
				},
				/**
				 * Stores value of system setting "MaxPasswordAge".
				 */
				"PasswordDuration": {
					dataValueType: this.Terrasoft.DataValueType.INTEGER,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Current user contact.
				 */
				"Contact": {
					lookupListConfig: {
						columns: ["Photo"],
						orders: [{columnPath: "Name"}],
						filter: function() {
							var filterGroup = this.Terrasoft.createFilterGroup();
							var notExistsFilter = this.Terrasoft.createNotExistsFilter("[SysAdminUnit:Contact].Id");
							filterGroup.addItem(notExistsFilter);
							return filterGroup;
						}
					},
					isRequired: Terrasoft.Features.getIsEnabled("SysAdminUnitFeatures.ShowContactInAdminUnit"),
					validateOrder: 1
				},
				/**
				 * Home page.
				 */
				"HomePage": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filters: [
							{
								method: () => {
									const filterGroup = Terrasoft.createFilterGroup();
									filterGroup.add("sectionSchemaExist", Terrasoft.createExistsFilter("[SysSchema:UId:SectionSchemaUId].Id"));
									return filterGroup;
								}
							}
						]
					}
				},
				/**
				 * Mobile Home page.
				 * Persists to SysAdminUnit.MobileHomePageId via the base VwSysAdminUnit schema.
				 * Filter exposes SysSchema rows tagged with Group=MobilePage.
				 */
				"MobileHomePage": {
					dataValueType: Terrasoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filters: [
							{
								method: () => {
									const filterGroup = Terrasoft.createFilterGroup();
									filterGroup.logicalOperation = Terrasoft.LogicalOperatorType.AND;
									filterGroup.add(
										"propertyName",
										Terrasoft.createColumnFilterWithParameter(
											Terrasoft.ComparisonType.EQUAL,
											"[SysSchemaProperty:SysSchema:Id].Name",
											"SchemaType"
										)
									);
									filterGroup.add(
										"propertyValue",
										Terrasoft.createColumnFilterWithParameter(
											Terrasoft.ComparisonType.EQUAL,
											"[SysSchemaProperty:SysSchema:Id].Value",
											"MobileSchema"
										)
									);
									return filterGroup;
								}
							}
						]
					}
				},
				/**
				 * Password expire date.
				 */
				"PasswordExpireDate": {
					dependencies: [{
						columns: ["PasswordConfirmation"],
						methodName: "onPasswordConfirmationChanged"
					}]
				},
				/**
				 * User connection type.
				 */
				"UserConnectionType": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function() {
							var filterGroup = this.Terrasoft.createFilterGroup();
							filterGroup.add("UserValue",
								Terrasoft.createColumnInFilterWithParameters(
									"Value", [
										ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees,
										ConfigurationConstants.SysAdminUnit.ConnectionType.PortalUsers
									]));
							return filterGroup;
						}
					},
					dependencies: [{
						columns: ["UserConnectionType"],
						methodName: "onUserConnectionTypeChanged"
					}],
					isRequired: true,
					validateOrder: 2
				},
				/**
				 * Value of connection type.
				 */
				"ConnectionType": {
					dependencies: [{
						columns: ["UserConnectionType"],
						methodName: "setConnectionTypeFromUserConnectionType"
					}]
				},
				/**
				 * User culture.
				 */
				"SysCulture": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					isRequired: true,
					validateOrder: 3
				},
				/**
				 * Date time format.
				 */
				"DateTimeFormat": {
					dataValueType: Terrasoft.DataValueType.LOOKUP
				},
				/**
				*TimeZone
				*/
				"TimeZone": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					isRequired: false,
					validateOrder: 4
				},
				/**
				*WeekFirstDay
				*/
				"WeekFirstDay": {
					dataValueType: this.Terrasoft.DataValueType.LOOKUP,
					isRequired: false,
					validateOrder: 5
				},
				/**
				 * License collection.
				 */
				"LicenseCollection": {
					dataValueType: this.Terrasoft.DataValueType.COLLECTION
				},
				/**
				 * Determines if user is active.
				 */
				"Active": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN
				},
				/**
				 * Determines if user has license managing right.
				 */
				"CanManageLicUsers": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Determines if licenses were loaded.
				 */
				"IsLicenseDataLoaded": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Current vertical grid record connectionType.
				 */
				"CurrentFolderConnectionType": {
					dataValueType: this.Terrasoft.DataValueType.INTEGER,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Determines if `All Portal Users` role is active.
				 */
				"ActiveAllPortalUsersGroup": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Previous value of user connection type.
				 */
				"PrevUserConnectionType": {
					dataValueType: this.Terrasoft.DataValueType.GUID,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsUserBlocked": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
					type: this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"AllowUsernameForExternalUsers": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN
				},
				"IsDemoMode": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN
				},
				"NeedToDistributeLicenses": {
					dataValueType: this.Terrasoft.DataValueType.BOOLEAN
				},
			},
			rules: {
				"Contact": {
					"BindParameterEnabledContact": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"logical": this.Terrasoft.LogicalOperatorType.OR,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Operation"
								},
								"comparisonType": this.Terrasoft.core.enums.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": this.Terrasoft.ConfigurationEnums.CardOperation.ADD
								}
							},
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "CurrentFolderConnectionType"
								},
								"comparisonType": this.Terrasoft.core.enums.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.UserType.SSP
								}
							}
						]
					}
				},
				"PasswordExpireDate": {
					"BindParameterEnabledPasswordExpireDate": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "PasswordDuration"
								},
								"comparisonType": this.Terrasoft.ComparisonType.GREATER,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": 0
								}
							}
						]
					}
				}
			},
			methods: {
				/**
				 * @inheritDoc Terrasoft.BasePageV2#validateColumn
				 * @overridden
				 */
				validateColumn: function(columnName) {
					if (columnName === "Name" && !this.isNameEnabled()) {
						this.setColumnRequired("Name", false);
						return true;
					}
					return this.callParent(arguments);
				},

				/**
				 * @private
				 */
				setColumnRequired: function(columnName, isRequired) {
					const nameColumn = this.columns[columnName];
					nameColumn.isRequired = isRequired;
				},

				/**
				 * @private
				 */
				isNamePlaceholderVisible: function() {
					return !this.isNameEnabled();
				},

				/**
				 * @private
				 */
				isExternalUser: function() {
					return this.$ConnectionType == 1;
				},

				/**
				 *
				 * @private
				 */
				setNameFromEmail: function() {
					if(!this.isAllowUsernameForExternalUsers() && this.isExternalUser()) {
						this.$Name = this.$Email;
					}
				},

				/**
				 * @private
				 */
				isNameEnabled: function() {
					let result;
					if (this.isAllowUsernameForExternalUsers()) {
						result = true;
					} else {
						if (this.isExternalUser()) {
							result = false;
						} else {
							result = true;
						}
					}
					return result;
				},

				/**
				 * @private
				 */
				isNameRequired: function() {
					return this.isNameEnabled();
				},

				/**
				 * @private
				 */
				isEmailRequired() {
					const result = !this.isNameEnabled();
					this.setColumnRequired("Email", result);
					return result;
				},

				/**
				 * @private
				 */
				isAllowUsernameForExternalUsers: function() {
					return (!this.get("IsDemoMode") && this.get("CanUseLdapForExternalUsers"))
						|| this.get("AllowUsernameForExternalUsers");

				},

				initLDAPLicOperationStatuses: function() {
					ServiceHelper.callCoreService({
							serviceName: "LicenseService",
							methodName: "GetLicOperationStatuses",
							data: {
								"licOperationCodes": ["CanUseLdap", "CanUseLdapForExternalUsers"]
							}
						},
						function (response) {
							var result = response.GetLicOperationStatusesResult;
							if(result.success) {
								Terrasoft.each(result.licOperationStatuses, function(licOperationStatus) {
									this.set(licOperationStatus.Key, licOperationStatus.Value);
								}, this);
							}
						},
						this);
				},

				/**
				 * get demo mode state from LicenseService.
				 */
				initDemoModeState: function() {
					ServiceHelper.callCoreService({
							serviceName: "LicenseService",
							methodName: "GetIsDemoMode"
						},
						function (response) {
							if (response?.success) {
								this.set("IsDemoMode", response.isDemoMode);
							}
						},
						this);
				},

				/**
				 * Set ConnectionType from UserConnectionType.
				 */
				setConnectionTypeFromUserConnectionType: function() {
					this.$ConnectionType =
						this.$UserConnectionType.value === ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.AllEmployees
							? ConfigurationConstants.SysAdminUnit.ConnectionType.AllEmployees
							: ConfigurationConstants.SysAdminUnit.ConnectionType.PortalUsers;
				},

				/**
				 * Return true if previous value of UserConnectionType equals value of UserConnectionType.
				 * @returns {bool} true, if previous value of UserConnectionType equals UserConnectionType,
				 * else - false.
				 */
				isPrevUserConnectionTypeEqualUserConnectionType: function() {
					return this.$UserConnectionType && this.$PrevUserConnectionType &&
						this.$PrevUserConnectionType.value === this.$UserConnectionType.value;
				},

				/**
				 * Raises the onchange event for UserConnectionType.
				 */
				onUserConnectionTypeChanged: function() {
					if (this.isAddMode() || this.isPrevUserConnectionTypeEqualUserConnectionType()) {
						return {};
					}
					this.showConfirmationDialog(this.get("Resources.Strings.ChangeUserConnectionTypeMessage"),
						function(returnCode) {
							if (returnCode === this.Terrasoft.MessageBoxButtons.NO.returnCode) {
								this.setUserConnectionType(this.$PrevUserConnectionType);
								return;
							}
							this.setPrevUserConnectionType();
							this.showBodyMask();
							this.changeUserConnectionType();
						},
						[
							this.Terrasoft.MessageBoxButtons.NO.returnCode,
							this.Terrasoft.MessageBoxButtons.YES.returnCode
						],
						null
					);
				},

				/**
				 * Send query of change UserConnectionType to server.
				 */
				changeUserConnectionType: function() {
					var dataSend = {
						userId: this.$Id,
						connectionType: this.$ConnectionType
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: this.getChangeUserConnectionTypeMethodName(),
						data: dataSend
					};
					this.callService(config, this.onChangeUserConnectionType, this);
				},

				/**
				 * Callback-function on query of changing UserConnectionType.
				 * @param {} response ##### #######.
				 */
				onChangeUserConnectionType: function(response) {
					var result = this.Ext.decode(response[this.getChangeUserConnectionTypeMethodName() + "Result"]);
					response.message = result.ExceptionMessage;
					response.success = result.Success;
					this.reloadEntity();
					this.validateResponse(response);
					this.hideBodyMask();
				},

				/**
				 * Get name of method of changing UserConnectionType.
				 * @returns {string} ######## ######.
				 */
				getChangeUserConnectionTypeMethodName: function() {
					return "ChangeUserConnectionType";
				},

				/**
				 * Filter for detail SysAdminUnitGrantedRightDetailV2.
				 * @protected
				 * @return {Terrasoft.FilterGroup} ########## ###### ########.
				 */
				getSysAdminUnitGrantedRightDetailV2Filters: function() {
					var filters = this.Terrasoft.createFilterGroup();
					filters.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
					filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "GrantorSysAdminUnit.Id", this.get("Id")));
					filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "GranteeSysAdminUnit.Id", this.get("Id")));
					return filters;
				},

				/**
				 * @inheritDoc BasePageV2#onEntityInitialized
				 * @protected
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.setUserDefaultValues();
					this.changeColumnCaption("Name", this.get("Resources.Strings.UserNameCaption"));
					this.callParent(arguments);
				},

				/**
				 * ############# ### ####### ##### ######## #########.
				 * @param {String} columnName ######## ####### #######.
				 * @param {String} columnCaption ######### ####### #######.
				 */
				changeColumnCaption: function(columnName, columnCaption) {
					var column = this.getColumnByName(columnName);
					column.caption = columnCaption;
				},

				/**
				 * Set specified value of UserConnectionType.
				 * @protected
				 */
				setUserConnectionType: function(value) {
					value = value || ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.AllEmployees;
					this.$UserConnectionType = value;
				},

				/**
				 * Initialize attributes of activity for `All Portal Users` role.
				 */
				initializeActivityAllPortalUsers: function() {
					var esq = Ext.create("Terrasoft.EntitySchemaQuery", {rootSchemaName: "SysAdminUnit"});
					esq.addColumn("Active");
					esq.getEntity(ConfigurationConstants.SysAdminUnit.Id.PortalUsers, function(data) {
						if (data && data.success && data.entity) {
							this.$ActiveAllPortalUsersGroup = data.entity.values.Active;
						}
					}, this);
				},

				/**
				 * Return true if connection type equals General.
				 * @returns {bool} true, if connection type equals General else - false.
				 */
				isGeneralConnection: function(connectionType) {
					return connectionType === 0;
				},

				/**
				 * Set UserConnectionType to PrevUserConnectionType.
				 */
				setPrevUserConnectionType: function() {
					this.$PrevUserConnectionType = this.$UserConnectionType;
				},

				/**
				 * ############# ######## ## ######### ### ##### viewModel.
				 * @protected
				 */
				setUserDefaultValues: function() {
					this.$ActiveAllPortalUsersGroup = false;
					var esq = Ext.create("Terrasoft.EntitySchemaQuery", {rootSchemaName: "SysAdminUnit"});
					esq.addColumn("Active");
					var currentConnectionType = this.$ConnectionType;
					var connectionType = this.Ext.isEmpty(currentConnectionType)
						? this.$CurrentFolderConnectionType
						: currentConnectionType;
					if (this.isAddMode()) {
						var userConnectionType;
						if (this.isGeneralConnection(connectionType)) {
							userConnectionType = this.createLookupValue(
								ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.AllEmployees,
								this.get("Resources.Strings.OurCompanyUserCaption"));
						}
						else {
							userConnectionType = this.createLookupValue(
								ConfigurationConstants.SysAdminUnit.ConnectionTypeGuid.PortalUsers,
								this.get("Resources.Strings.PortalUserCaption"));
						}
						this.setUserConnectionType(userConnectionType);
						this.$SysAdminUnitType = ConfigurationConstants.SysAdminUnit.TypeGuid.User;
					} else {
						var passwordMask = this.get("Resources.Strings.PasswordMask");
						this.set("UserPassword", passwordMask);
						this.set("PasswordConfirmation", passwordMask);
						this.setPrevUserConnectionType();
						this.changedValues = {};
						esq.getEntity(ConfigurationConstants.SysAdminUnit.Id.PortalUsers, function(data) {
							if (data && data.success && data.entity) {
								this.$ActiveAllPortalUsersGroup = data.entity.values.Active;
							}
						}, this);
					}
				},

				/**
				 * Create value of lookup.
				 * @param value Value of lookup.
				 * @param displayValue Display value of lookup.
				 * @returns {{value: *, displayValue: *}} value of lookup.
				 */
				createLookupValue: function(value, displayValue) {
					return {
						value: value,
						displayValue: displayValue
					};
				},

				/**
				 * ####### ####### ######### ######### ##############.
				 * @protected
				 * @param {Object} config ###### ###### ######## ##############.
				 * @return {Terrasoft.BaseViewModel} ####### ######### ######### ##############.
				 */
				getLicenseCollectionItem: function(config) {
					var licText;
					if (config.Type === ConfigurationConstants.SysAdminUnit.SysLicType.Server) {
						licText = this.Ext.String.format(
							this.get("Resources.Strings.ServerLicAvailableCountCaption"), config.UsedCount);
					} else {
						licText = this.Ext.String.format(
							this.get("Resources.Strings.LicAvailableCountCaption"),
							config.AvailableCount, config.PaidCount);
					}
					var collectionItem = this.Ext.create("Terrasoft.BaseViewModel", {
						values: {
							Id: config.Id,
							Name: config.Caption,
							Checked: config.Checked,
							Enabled: config.Enabled,
							AvailableCount: config.AvailableCount,
							PaidCount: config.PaidCount,
							AvailableCountCaption: licText,
							LicSource: config.SysLicSource
						}
					});
					collectionItem.sandbox = this.sandbox;
					return collectionItem;
				},

				/**
				 * ########## ######### ######## ######## # ###### ########.
				 * @private
				 */
				onCheckChange: function() {
					if (this.get("IsLicenseDataLoaded")) {
						if (this.get("ModifyAllLicenses")) {
							this.updateButtonsVisibility(true);
							this.set("IsChanged", true, {silent: true});
							this.set("Restored", true, {silent: true});
						} else if (this.isEditMode()) {
							this.save({isSilent: true});
						}
					}
				},

				/**
				 * ######## ### ########.
				 * @protected
				 */
				onCheckAllLicenses: function() {
					this.modifyAllLicenses(true);
				},

				/**
				 * ####### ### ########.
				 * @protected
				 */
				onUncheckAllLicenses: function() {
					this.modifyAllLicenses(false);
				},

				/**
				 * Executes process that redistributes licenses based on role for specific user
				 * @protected
				 */
				onRedistributeLicensesBasedOnRole: function() {
					var userId = this.getPrimaryColumnValue();
					var parameters = {
						UserId: userId
					};
					ProcessModuleUtilities.runProcess("RedistributeLicensesForSpecificUser", parameters,
						this.redistributeLicensesProcessCallback, this);
				},

				/**
				 * Callback function executed after license redistribution process is finished
				 * @protected
				 */
				redistributeLicensesProcessCallback: function() {
					this.getAvailableLicenses(this.hideBodyMask, this);
				},

				/**
				 * ############### ######### ######### ##############.
				 * @private
				 */
				initCollection: function() {
					var collection = this.Ext.create("Terrasoft.BaseViewModelCollection");
					collection.on("itemChanged", this.onCheckChange, this);
					this.set("LicenseCollection", collection);
				},

				/**
				 * ######## ######## ######### ######### LicenseCollection.
				 * @param {Boolean} checked ####### ######.
				 * @param {Boolean=} enabled ####### ########### ######## ##########.
				 */
				modifyAllLicenses: function(checked, enabled) {
					var collection = this.get("LicenseCollection");
					this.set("ModifyAllLicenses", true);
					collection.each(function(model) {
						model.set("Checked", checked);
						if (!this.Ext.isEmpty(enabled)) {
							model.set("Enabled", enabled);
						}
					}, this);
					this.set("ModifyAllLicenses", false);
				},

				/**
				 * ######## ###### ######### ##############, ############## ## #######.
				 * @protected
				 * @param {Function=} callback ####### ######### ######.
				 * @param {Object=} scope ######## ####### ######### ######.
				 */
				getAvailableLicenses: function(callback, scope) {
					var userId = this.isAddMode()
						? this.Terrasoft.GUID_EMPTY
						: (this.get("PrimaryColumnValue") || this.get(this.entitySchema.primaryColumnName));
					var dataSend = {
						userId: userId
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "GetAvailableLicPackages",
						data: dataSend
					};
					this.set("IsLicenseDataLoaded", false);
					this.showMaskOnLicenses();
					this.callService(config, function(response) {
						this.onGetAvailableLicenses(response, callback, scope);
					}, this);
				},

				/**
				 * ######### ######### ######### ##############.
				 * @protected
				 * @param {Object} response ##### #######.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Terrasoft.BaseViewModel} scope ######## ####### ######### ######.
				 */
				onGetAvailableLicenses: function(response, callback, scope) {
					var collection = this.get("LicenseCollection");
					collection.clear();
					if (response && response.GetAvailableLicPackagesResult) {
						var items = this.Ext.decode(response.GetAvailableLicPackagesResult);
						this.Terrasoft.each(items, function(item) {
							var licenseItem = this.getLicenseCollectionItem(item);
							collection.add(item.Id, licenseItem);
						}, this);
					}
					this.set("IsLicenseDataLoaded", true);
					this.hideMaskOnLicenses();
					if (this.Ext.isFunction(callback)) {
						callback.call(scope);
					}
				},

				/**
				 * ########## ##### ### ###### ########.
				 * @private
				 */
				showMaskOnLicenses: function() {
					var maskConfig = {
						selector: "#LicenseListContainerList",
						timeout: 0
					};
					var elements = this.Ext.select(maskConfig.selector);
					if (elements.item(0)) {
						this.licenseListMaskId = this.Terrasoft.Mask.show(maskConfig);
					}
				},

				/**
				 * ######## ##### ### ###### ########.
				 * @private
				 */
				hideMaskOnLicenses: function() {
					this.Terrasoft.Mask.hide(this.licenseListMaskId);
				},

				/**
				 * ######### viewConfig ### ######## ###### ######### ##############.
				 * @param {Object} itemConfig viewConfig ######## ##########.
				 * @param {Terrasoft.BaseViewModel} item ####### ###### ######### ##############.
				 */
				getItemViewConfig: function(itemConfig, item) {
					var labelClass = ["license-label"];
					if (!item.get("Enabled")) {
						labelClass.push("disabled-label");
					}
					var config = ViewUtilities.getContainerConfig("license-view");
					var labelConfig = {
						className: "Terrasoft.Label",
						caption: {bindTo: "Name"},
						classes: {labelClass: labelClass},
						inputId: item.get("Id") + "-el"
					};
					var editConfig = {
						className: "Terrasoft.CheckBoxEdit",
						id: item.get("Id"),
						checked: {bindTo: "Checked"},
						enabled: {bindTo: "Enabled"}
					};
					var sourceConfig = {
						className: "Terrasoft.Label",
						caption: {bindTo: "LicSource"},
						classes: {labelClass: ["license-source-label"]},
					};
					var countConfig = {
						className: "Terrasoft.Label",
						caption: {bindTo: "AvailableCountCaption"},
						classes: {labelClass: labelClass.concat(["count-label"])}
					};
					config.items.push(labelConfig, editConfig, sourceConfig, countConfig);
					itemConfig.config = config;
				},

				/**
				 * @inheritDoc BasePageV2#getHeader
				 * @protected
				 * @overridden
				 */
				getHeader: function() {
					return this.get("Resources.Strings.UserPageHeader");
				},

				/**
				 * ########## ######### # ######## ###########.
				 * @protected
				 */
				onPhotoChange: this.Terrasoft.emptyFn,

				/**
				 * ########## ##### ####### ########### #### ###### #####.
				 * @protected
				 */
				beforeFileSelected: this.Terrasoft.emptyFn,

				/**
				 * ######## ###### ## ###########.
				 * @protected
				 * @return {String|*} Url ###########.
				 */
				getSrcMethod: function() {
					var contact = this.get("Contact");
					if (contact && contact.Photo) {
						var imageConfig = {
							source: this.Terrasoft.ImageSources.SYS_IMAGE,
							params: {
								primaryColumnValue: contact.Photo.value
							}
						};
						return this.Terrasoft.ImageUrlBuilder.getUrl(imageConfig);
					}
					return this.getUserDefaultImageURL();
				},

				/**
				 * Returns default user photo url.
				 * @return {String} Default user photo url.
				 */
				getUserDefaultImageURL: function() {
					return this.Terrasoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultPhoto);
				},

				/**
				 * ########## ######### #### "############# ######".
				 * #### ###### ######### ######### "#### ######## ######", ########## #### "#### #########
				 * ######## ######" ########, ###### ####### #### + ########## ####, ######### # #########
				 * #########.
				 * @protected
				 */
				onPasswordConfirmationChanged: function() {
					var password = this.get("UserPassword");
					var passwordDuration = this.get("PasswordDuration");
					if (!this.Ext.isEmpty(password) && password === this.get("PasswordConfirmation") &&
						passwordDuration > 0) {
						var passwordExpireDate = this.Ext.Date.add(new Date(), this.Ext.Date.DAY, passwordDuration);
						passwordExpireDate = this.Ext.Date.clearTime(passwordExpireDate);
						this.set("PasswordExpireDate", passwordExpireDate);
					}
				},

				/**
				 * ############## ################ ######### ### #### "############# ######".
				 * @inheritDoc BaseSchemaViewModel#setValidationConfig
				 * @protected
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("PasswordConfirmation", function(newPasswordConfirmation) {
						var password = this.get("UserPassword");
						var invalidMessage = "";
						if (!this.Ext.isEmpty(password) && !this.get("SynchronizeWithLDAP")) {
							if (password !== newPasswordConfirmation) {
								invalidMessage = this.get("Resources.Strings.PasswordMissMatchMessageCaption");
							}
						}
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					});
					this.addColumnValidator("UserPassword", function() {
						var password = this.get("UserPassword");
						var invalidMessage = "";
						if (this.Ext.isEmpty(password) && !this.get("SynchronizeWithLDAP")) {
							invalidMessage = this.get("Resources.Strings.SpecifyPasswordMessage");
						}
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					});
					this.addColumnValidator("Email", EmailHelper.getEmailValidator);
				},

				/**
				 * ######## ######## ######### ######### PasswordDuration.
				 * @protected
				 * @param {String} settingCode ### ######### #########.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				initSysSettingsValue: function(settingCode, callback, scope) {
					this.Terrasoft.SysSettings.querySysSettingsItem(settingCode,
						function(value) {
							this.set(settingCode, value);
							if (this.Ext.isFunction(callback)) {
								callback.call(scope);
							}
						},
						this);
				},

				/**
				 * ######### ######## ## ####### GetChiefId # SetRecordInformation.
				 * @protected
				 */
				publishMessages: function() {
					var result = this.sandbox.publish("GetChiefId", {}, [this.sandbox.id]);
					if (this.Ext.isEmpty(result)) {
						result = this.sandbox.publish("SetRecordInformation", {}, [this.sandbox.id]);
					}
					if (!this.Ext.isEmpty(result)) {
						this.set("Parent", result.parent);
						var connectionType = this.getConnectionType(result.defaultValues);
						this.set("CurrentFolderConnectionType", this.Ext.isEmpty(connectionType)
							? null
							: connectionType.value);
					}
				},

				/**
				 * ## ####### ######## ## ######### ########## ######## # ###### "ConnectionType" ### null.
				 * @param {Array} defaultValues ######### ######## ## ######### ###### "############".
				 * @return {Object} ### ############ ### null, #### ### ############ ## ###### ##### ########
				 * ## #########.
				 */
				getConnectionType: function(defaultValues) {
					var result = null;
					this.Terrasoft.each(defaultValues, function(value) {
						if (value.name === "ConnectionType") {
							result = value;
						}
					});
					return result;
				},

				/**
				 * ######### ######### # ############# ######## ########### ###### #######.
				 * @protected
				 */
				publishUpdateSectionGrid: function() {
					if (this.isAddMode()) {
						this.sandbox.publish("UpdateSectionGrid");
					}
				},

				/**
				 * #########, #### ## # ############ ##### ## ########## ########## ########
				 * ######## CanManageLicUsers.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				checkCanManageLicUsers: function(callback, scope) {
					RightUtilities.checkCanExecuteOperation({
						operation: "CanManageLicUsers"
					}, function(result) {
						this.set("CanManageLicUsers", result);
						if (this.Ext.isFunction(callback)) {
							callback.call(scope);
						}
					}, this);
				},

				/**
				 * @inheritDoc BasePageV2#init
				 * @protected
				 * @overridden
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				init: function(callback, scope) {
					this.subscribeEvents();
					this.callParent([
						function() {
							this.publishMessages();
							this.initCollection();
							this.initLDAPLicOperationStatuses();
							this.initDemoModeState();
							this.Terrasoft.chain(
								function(next) {
									this.getAvailableLicenses(function() {
										next();
									}, this);
								},
								function(next) {
									this.initSysSettingsValue("PasswordDuration", function() {
										next();
									}, this);
								},
								function(next) {
									this.initSysSettingsValue("AccountTypeForOurCompany", function() {
										next();
									}, this);
								},
								function(next) {
									this.initSysSettingsValue("AllowUsernameForExternalUsers", function() {
										next();
									}, this);
								},
								function(next) {
									this.checkCanManageLicUsers(function() {
										next();
									}, this);
								},
								function(next) {
									this.getIsUserBlocked(function() {
										next();
									}, this);
								},
								function(next) {
									callback.call(scope);
									next();
								},
								this);
						}, this
					]);
				},

				/**
				 * Performs messages subscriptions.
				 * @private
				 */
				subscribeEvents: function() {
					this.sandbox.subscribe("UnblockUser", this.onUnblockClick, this, []);
					this.sandbox.subscribe("DeleteUser", this.onDeleteClick, this, []);
					this.sandbox.subscribe("RolesChanged", () => this.onRolesChanged(), this, []);
				},

				onRolesChanged: function() {
                  this.getAvailableLicenses();
                },

				/**
				 * @inheritDoc BasePageV2#updateDetails
				 * @overridden
				 */
				updateDetails: function() {
					this.callParent(arguments);
					this.getAvailableLicenses();
				},

				/**
				 * @inheritDoc BasePageV2#fireDiscardChangesEvent
				 * @protected
				 * @overridden
				 */
				fireDiscardChangesEvent: function() {
					var entityInfo = this.onGetEntityInfo();
					this.sandbox.publish("DiscardChanges", entityInfo);
				},

				/**
				 * @inheritDoc BasePageV2#onDiscardChangesClick
				 * @protected
				 * @overridden
				 */
				onDiscardChangesClick: function() {
					if (this.isNew) {
						this.sandbox.publish("BackHistoryState");
						return;
					}

					this.set("IsEntityInitialized", false);
					this.loadEntity(this.get("Id"), function() {
						this.discardPasswordChanges();
						this.resetLicensesCollection();
						this.updateButtonsVisibility(false, {
							force: true
						});
						this.set("IsEntityInitialized", true);
						this.discardDetailChange();
					}, this);
					if (this.get("ForceUpdate")) {
						this.set("ForceUpdate", false);
					}
				},

				/**
				 * ########## #### "######" # "############# ######" # ## ######### ##-#########.
				 */
				discardPasswordChanges: function() {
					var info = {
						invalidMessage: "",
						isValid: true
					};
					this.set("UserPassword", this.get("Resources.Strings.PasswordMask"),
						{preventValidation: true});
					this.set("PasswordConfirmation", this.get("UserPassword"),
						{preventValidation: true});
					this.validationInfo.set("UserPassword", info);
					this.validationInfo.set("PasswordConfirmation", info);
					this.changedValues = {};
				},

				/**
				 * ############### ######## ## ######### ### ######### ########.
				 * @private
				 */
				resetLicensesCollection: function() {
					var collection = this.get("LicenseCollection");
					this.set("ModifyAllLicenses", true);
					collection.each(function(model) {
						if (model.getIsChanged()) {
							model.set("Checked", model.values.Checked);
							model.set("Enabled", model.values.Enabled);
						}
					}, this);
					this.set("ModifyAllLicenses", false);
				},

				/**
				 * #########, ########## ## #### ####### ########, ####### ########### #### "############# ######".
				 * ####### ########## ###### ## ######### ########### ####.
				 * @protected
				 * @overridden
				 * @return {Boolean} ########## true #### #### ######### # ######### ####### ##### ########,
				 * false - # ######## ######
				 */
				isChanged: function() {
					var result = this.callParent(arguments);
					return result || !this.Ext.isEmpty(this.changedValues.PasswordConfirmation);
				},

				/**
				 * #### ### ####### ######, ##### ######### ######### ###### ## ####### ##### #####
				 * ###### ValidatePassword # Terrasoft.Core.PasswordUtilities.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				validatePassword: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.UserPassword)) {
						callback.call(scope || this, result);
					} else {
						var dataSend = {
							userName: this.get("Name"),
							password: this.get("UserPassword")
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: "ValidatePassword",
							data: dataSend
						};
						this.callService(config, function(response) {
							if (response) {
								if (!this.Ext.isEmpty(response.ValidatePasswordResult)) {
									result.message = response.ValidatePasswordResult;
									result.success = false;
								}
								callback.call(scope || this, result);
							}
						});
					}
				},

				/**
				 * ######## ################ ###### AdministrationService
				 * ### ########## ################ ########.
				 * @param {Function} next
				 */
				saveLicenses: function(next) {
					var licenseItems = {};
					var collection = this.get("LicenseCollection");
					collection.each(function(model) {
						if (this.isAddMode() || model.getIsChanged()) {
							licenseItems[model.get("Id")] = model.get("Checked");
						}
					}, this);
					if (this.Terrasoft.isEmptyObject(licenseItems)) {
						this.cardSaveResponse = {success: true};
						next();
					} else {
						var dataSend = {
							userId: this.get("Id"),
							licenseItems: this.Ext.encode(licenseItems)
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: this.getSaveLicensesMethodName(),
							data: dataSend
						};
						this.callService(config, function(response) {
							this.onSaveLicenses(response, next);
						}, this);
					}
				},

				/**
				 * calls  AdministrationService to redistribute user licenses
				 * if Role-based distribution enabled.
				 * @param {Function} next
				 */
				redistributeLicenses: function(next) {
					if (!this.NeedToDistributeLicenses) {
						next();
						return;
					} 
					var licenseItems = [];
					var collection = this.get("LicenseCollection");
					collection.each(function(model) {
						if (model.get("Checked")) {
							licenseItems.push(model.get("Name"));
						}
					}, this);
					var dataSend = {
						userId: this.get("Id"),
						licPackages: licenseItems
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: this.getRedistributeLicensesMethodName(),
						data: dataSend
					};
					this.callService(config, function(response) {
						this.onRedistributeLicenses(response, next);
					}, this);	
				},

				/**
				 * Returns save license method name
				 * @protected
				 * @return {String} Method name.
				 */
				getSaveLicensesMethodName: function() {
					return "UpdateLicenseInfo";
				},

				/**
				 * Returns redistribute license method name
				 * @protected
				 * @return {String} Method name.
				 */
				getRedistributeLicensesMethodName: function() {
					return "RedistributeLicenses";
				},
				
				/**
				 * ######### ############# ########## ######## ############.
				 * @param {Object} response ##### #######.
				 * @param {Function} next ######### ##### # #######.
				 */
				onSaveLicenses: function(response, next) {
					if (response) {
						response.message = response[this.getSaveLicensesMethodName() + "Result"];
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.cardSaveResponse = response;
							next();
						} else {
							this.getAvailableLicenses();
						}
					}
				},

				/**
				 * ######### ############# ########## ######## ############.
				 * @param {Object} response ##### #######.
				 * @param {Function} next ######### ##### # #######.
				 */
				onRedistributeLicenses: function(response, next) {
					if (response) {
						response.message = response[this.getRedistributeLicensesMethodName() + "Result"];
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.cardSaveResponse = response;
							next();
						} else {
							this.getAvailableLicenses();
						}
					}
				},

				/**
				 * Call configuration service AdministrtionService for save user..
				 * @param {Function} next
				 */
				saveUser: function(next) {
					var changedColumns = {};
					this.Terrasoft.each(this.entitySchema.columns,
						function(column) {
							if (this.changedValues.hasOwnProperty(column.name)) {
								var columnValue = this.get(column.name);
								if (columnValue) {
									columnValue = columnValue.value || columnValue;
								}
								changedColumns[column.name] = columnValue;
							}
						}, this);
					if (this.Terrasoft.isEmptyObject(changedColumns)) {
						this.cardSaveResponse = {success: true};
						next();
					} else {
						if (this.Ext.isEmpty(changedColumns.Id)) {
							changedColumns.Id = this.get("Id");
						}
						var dataSend = {
							jsonObject: this.Ext.encode(changedColumns),
							roleId: this.get("Parent")
						};
						var config = {
							serviceName: "AdministrationService",
							methodName: this.getSaveUserMethodName(),
							data: dataSend
						};
						this.callService(config, function(response) {
							this.onSaveUser(response, next);
						}, this);
					}
				},

				/**
				 * Returns save user method name
				 * @protected
				 * @return {String} Method name.
				 */
				getSaveUserMethodName: function() {
					return "UpdateOrCreateUser";
				},

				/**
				 * ######### ############# ##########.
				 * @param {Object} response ##### #######.
				 * @param {Function} next ######### ##### # #######.
				 */
				onSaveUser: function(response, next) {
					if (response) {
						response.message = response[this.getSaveUserMethodName() + "Result"];
						response.success = this.Ext.isEmpty(response.message);
						if (this.validateResponse(response)) {
							this.NeedToDistributeLicenses = this.isNew && this.getIsFeatureEnabled("UseRoleBasedLicenseDistribution"); 
							this.isNew = false;
							this.changedValues = null;
							this.cardSaveResponse = response;
							next();
						}
					}
				},

				/**
				 * ######### ########## ############.
				 * @overridden
				 * @param {Object} config
				 */
				save: function(config) {
					this.showBodyMask();
					this.NeedToDistributeLicenses = false;
					this.Terrasoft.chain(
						this.saveCheckCanEditRight,
						this.saveAsyncValidate,
						this.saveUser,
						this.saveLicenses,
						this.redistributeLicenses,
						function(next) {
							this.saveDetails(function(response) {
								if (this.validateResponse(response)) {
									next();
								}
							}, this);
						},
						function() {
							this.onSaved(this.cardSaveResponse, config);
							this.cardSaveResponse = null;
							delete this.cardSaveResponse;
						},
						this);
				},

				/**
				 * @inheritDoc BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
					if (this.isEditMode()) {
						this.getAvailableLicenses();
					}
				},

				/**
				 * ######### ######## ##### ############ ## ############.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				validateUniqueUserName: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.Name)) {
						callback.call(scope || this, result);
					} else {
						var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						esq.addColumn("Id");
						var primaryColumnValue = this.get("PrimaryColumnValue");
						if (!Ext.isEmpty(primaryColumnValue)) {
							esq.filters.add("primaryColumnFilter", this.Terrasoft.createColumnFilterWithParameter(
								this.Terrasoft.ComparisonType.NOT_EQUAL, "Id", primaryColumnValue));
						}
						var uniqueNameAndEmailFilterGroup = Ext.create("Terrasoft.FilterGroup");
						uniqueNameAndEmailFilterGroup.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
						uniqueNameAndEmailFilterGroup.add("emailFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.EQUAL, "Email", this.get("Name")));
						uniqueNameAndEmailFilterGroup.add("nameFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.EQUAL, "Name", this.get("Name")));
						esq.filters.add("uniqueNameAndEmail", uniqueNameAndEmailFilterGroup);
						esq.filters.add("adminUnitEmployeeFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.GREATER_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 4));
						esq.filters.add("adminUnitSspFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.LESS_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 5));
						esq.getEntityCollection(function(response) {
							if (response && response.success) {
								if (response.collection.getCount() > 0) {
									result.message = this.get("Resources.Strings.UserNameNotUnique");
									result.success = false;
								}
								callback.call(scope || this, result);
							}
						}, this);
					}
				},

				/**
				 * ######### ######## Email ############ ## ############.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				validateUniqueUserEmail: function(callback, scope) {
					var result = {
						success: true
					};
					if (!this.changedValues || this.Ext.isEmpty(this.changedValues.Email)) {
						callback.call(scope || this, result);
					} else {
						var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
							rootSchemaName: this.entitySchemaName
						});
						esq.addColumn("Id");
						var primaryColumnValue = this.get("PrimaryColumnValue");
						if (!Ext.isEmpty(primaryColumnValue)) {
							esq.filters.add("primaryColumnFilter", this.Terrasoft.createColumnFilterWithParameter(
								this.Terrasoft.ComparisonType.NOT_EQUAL, "Id", primaryColumnValue));
						}
						var uniqueNameAndEmailFilterGroup = Ext.create("Terrasoft.FilterGroup");
						uniqueNameAndEmailFilterGroup.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
						uniqueNameAndEmailFilterGroup.add("emailFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.EQUAL, "Email", this.get("Email")));
						uniqueNameAndEmailFilterGroup.add("nameFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.EQUAL, "Name", this.get("Email")));
						esq.filters.add("uniqueNameAndEmail", uniqueNameAndEmailFilterGroup);
						esq.filters.add("adminUnitEmployeeFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.GREATER_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 4));
						esq.filters.add("adminUnitSspFilter", this.Terrasoft.createColumnFilterWithParameter(
							this.Terrasoft.ComparisonType.LESS_OR_EQUAL, "SysAdminUnit.SysAdminUnitTypeValue", 5));
						esq.getEntityCollection(function(response) {
							if (response && response.success) {
								if (response.collection.getCount() > 0) {
									result.message = this.get("Resources.Strings.UserNameNotUnique");
									result.success = false;
								}
								callback.call(scope || this, result);
							}
						}, this);
					}
				},

				/**
				 * @inhericDoc BasePageV2#asyncValidate
				 * @protected
				 * @overridden
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						this.Terrasoft.chain(
							function(next) {
								this.validatePassword(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								this.validateUniqueUserName(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								this.validateUniqueUserEmail(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								callback.call(scope, response);
								next();
							}, this);
					}, this]);
				},

				/**
				 * ########## ##### # #### "######".
				 * ######### ######## ##### ## ############ # ########## UserPassword.
				 * ### ########## ### ####, ##### ######### ###### ########### ###########,
				 * # ## ###### ### ###### ######.
				 * @private
				 */
				onNewPasswordKeypress: function() {
					var newPasswordTextEdit = this.Ext.getCmp("new-password");
					var newPasswordInputValue = newPasswordTextEdit.getTypedValue();
					this.set("UserPassword", newPasswordInputValue);
					this.validate();
				},

				/**
				 * ##########, ##### #### "######" ######## #####.
				 * ####### ######## # ##### "######" # "############# ######".
				 * @private
				 */
				onPasswordGetFocus: function() {
					this.set("UserPassword", null, {preventValidation: true});
					this.set("PasswordConfirmation", null, {preventValidation: true});
				},

				/**
				 * ########## ##### # #### "############# ######".
				 * ######### ######## ##### ## ############ # ########## PasswordConfirmation.
				 * ### ########## ### ####, ##### ######### ###### ########### ###########,
				 * # ## ###### ### ###### ######.
				 * @private
				 */
				onNewPasswordConfirmationKeypress: function() {
					var newPasswordConfirmationTextEdit = this.Ext.getCmp("new-password-confirmation");
					var newPasswordConfirmationInputValue = newPasswordConfirmationTextEdit.getTypedValue();
					this.set("PasswordConfirmation", newPasswordConfirmationInputValue);
				},

				/**
				 * ############ ######## ######## isRequired.
				 * @protected
				 * @virtual
				 */
				isRequiredFieldsVisible: function() {
					return true;
				},

				/**
				 * ######### ###### # ############# ######## ##########.
				 * @protected
				 * @param {Object} args ########## ## ########### ######### ###### {action: "", rows: []}
				 */
				fireUpdateDetail: function(args) {
					this.sandbox.publish("UpdateDetail", args, [this.sandbox.id]);
				},

				/**
				 * @inheritDoc BasePageV2#onCloseCardButtonClick
				 * @protected
				 * @overridden
				 */
				onCloseCardButtonClick: function() {
					this.callParent(arguments);
					this.publishUpdateSectionGrid();
				},

				/**
				 * ######### ##### ####### # ######### ############ # ###### ####### ######.
				 * @protected
				 * @param {String} response ############ ##### #######
				 * @param {String} message ######### # ###### ######
				 * @param {Function} callback ####### ######### ###### # ###### ########## #######.
				 * @param {Object} scope  ######## ####### ######### ######.
				 */
				validateServiceResponse: function(response, message, callback, scope) {
					this.hideBodyMask();
					var result = this.Ext.decode(response);
					var isSuccess = result && result.Success;
					if (isSuccess) {
						callback.call(scope);
					} else if (result.IsSecurityException) {
						this.showInformationDialog(result.ExceptionMessage);
					} else {
						this.showInformationDialog(message);
					}
				},

				/**
				 * ######## ########### ##### ######## ############.
				 * @protected
				 */
				afterUserDeleted: function() {
					this.sandbox.publish("UserDeletedSuccessfully");
					this.fireUpdateDetail({reloadAll: true});
					this.onCloseCardButtonClick();
				},

				/**
				 * ######### # ########## ######## ############ # ###### ######,
				 * ######### ###### "############" # ############# ########## #######
				 * # ######### ######## ### ######## ########.
				 * @param {Object} response ##### #######.
				 * @protected
				 */
				onDeleteUserResponseHandler: function(response) {
					var message = this.get("Resources.Strings.DeleteErrorMessage");
					var responseResult = response[this.getOnDeleteCurrentUserClickMethodName() + "Result"];
					this.validateServiceResponse(responseResult, message, this.afterUserDeleted, this);
				},

				/**
				 * ######## ###### ######## ############# # ######### ######## ### ######## ########.
				 * @protected
				 * @virtual
				 */
				onDeleteCurrentUserClick: function() {
					this.showConfirmationDialog(this.get("Resources.Strings.DeleteUserMessage"),
						function(returnCode) {
							if (returnCode === this.Terrasoft.MessageBoxButtons.NO.returnCode) {
								return;
							}
							var dataSend = {userId: this.get("Id")};
							var config = {
								serviceName: "AdministrationService",
								methodName: this.getOnDeleteCurrentUserClickMethodName(),
								data: dataSend
							};
							this.showBodyMask();
							this.callService(config, this.onDeleteUserResponseHandler, this);
						},
						[
							this.Terrasoft.MessageBoxButtons.YES.returnCode,
							this.Terrasoft.MessageBoxButtons.NO.returnCode
						],
						null
					);
				},

				/**
				 * Returns delete user method name
				 * @protected
				 * @return {String} Method name.
				 */
				getOnDeleteCurrentUserClickMethodName: function() {
					return "DeleteUser";
				},

				/**
				 * ########## ###### "DeleteButton".
				 * @protected
				 * @virtual
				 */
				onDeleteClick: function() {
					this.onDeleteCurrentUserClick();
				},

				getOnUnblockUserClickMethodName: function() {
					return "UnblockUser";
				},

				onUnblockClick: function() {
					var dataSend = {userId: this.get("Id")};
					var config = {
						serviceName: "AdministrationService",
						methodName: this.getOnUnblockUserClickMethodName(),
						data: dataSend
					};
					this.showBodyMask();
					this.callService(config, this.onUnblockUserResponseHandler, this);
				},

				onUnblockUserResponseHandler: function(response) {
					var message = this.get("Resources.Strings.UnblockErrorMessage");
					var responseResult = response[this.getOnUnblockUserClickMethodName() + "Result"];
					this.validateServiceResponse(responseResult, message, this.afterUserUnblocked, this);
				},

				afterUserUnblocked: function() {
					var message = this.get("Resources.Strings.UnblockSuccessMessage");
					this.showInformationDialog(message);
					this.getIsUserBlocked();
				},

				setIsUserBlocked: function(value) {
					this.set("IsUserBlocked", value);
					this.sandbox.publish("SetIsUserBlocked", {"IsUserBlocked": value});
				},

				getIsUserBlocked: function(callback, scope) {
					this.setIsUserBlocked(false);
					var userId = this.isAddMode()
						? this.Terrasoft.GUID_EMPTY
						: (this.get("PrimaryColumnValue") || this.get(this.entitySchema.primaryColumnName));
					var dataSend = {
						userId: userId
					};
					var config = {
						serviceName: "AdministrationService",
						methodName: "GetIsUserBlocked",
						data: dataSend
					};
					this.callService(config, function(response) {
						this.onGetIsUserBlockedHandler(response, callback, scope);
					}, this);
				},

				onGetIsUserBlockedHandler: function(response, callback, scope) {
					if (response && response.GetIsUserBlockedResult) {
						this.setIsUserBlocked(response.GetIsUserBlockedResult);
					}
					if (this.Ext.isFunction(callback)) {
						callback.call(scope);
					}
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaViewModel#getSectionCode
				 * @override
				 */
				getSectionCode: function() {
					return "SystemUsers";
				},

				isLicenseActionsEnabled: function() {
					return this.$Active && this.$CanManageLicUsers;
				},

				isRoleBasedLicenseDistributionButtonEnabled: function() {
					var featureEnabled = this.getIsFeatureEnabled("UseRoleBasedLicenseDistribution");
					return this.$Active && this.$CanManageLicUsers && featureEnabled;
				},

				isRoleBasedLicenseDistributionButtonVisible: function() {
					return this.getIsFeatureEnabled("UseRoleBasedLicenseDistribution");
				}
			}
		};
	});

