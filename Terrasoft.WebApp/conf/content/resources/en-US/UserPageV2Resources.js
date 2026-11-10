define("UserPageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AuthControlGroupHintCaption: "Select Creatio authentication if you are going to add users to Creatio directly. Select LDAP authentication if you are going to synchronize users with Active Directory or OpenLDAP. In this case, the username must match the name from a LDAP lookup.",
		LDAPNotAvailableHintCaption: "LDAP authentication is not available for Growth plan. Upgrade your subscription to Enterprise",
		LDAPExternalNotAvailableHintCaption: "This option is not available for external users.",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		AccessRulesTabCaption: "Access rules",
		ActionButtonCaption: "Actions",
		ActiveCaption: "Active",
		AuthControlGroupCaption: "Authentication",
		AuthUseForm: "Creatio authentication",
		AuthUseLdap: "LDAP authentication",
		BeginProcessButtonMenuItemCaption: "Start process",
		BlockedUserLabelCaption: "User is blocked after a series of attempts to enter the wrong password during login",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ChangeUserConnectionTypeMessage: "All user roles will be deleted. Continue changing the type?",
		CheckLicensesCaption: "Select all",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		DeleteButtonCaption: "Delete",
		DeleteErrorMessage: "Unable to delete the selected user: the user is connected to other objects.",
		DeleteUserMessage: "Are you sure you want to delete this user?",
		EditRightsCaption: "Set up access rights",
		FieldLockHint: "Non-editable field",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		GeneralInfoTabCaption: "General information",
		GrantedRightsTabCaption: "Rights delegation",
		HeaderTipAcademyBtnCaption: "Learn more at the Academy",
		HeaderTipCaption: "Page appearance has been improved in Creatio 7.8",
		HeaderTipContent: "The page field layout has changed. Only the fields that you configured for the previous version are displayed here. For your convenience, you can move these fields to the record profile (on the left) or to the tab array using the Page Designer.",
		HeaderTipDesignerBtnCaption: "Set up now",
		HeaderTipNotShowBtnCaption: "Do not show this message again",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		LicAvailableCountCaption: "{0} of {1} available",
		NewRecordPageCaptionSuffix: ": New record",
		NotesAndFilesTabCaption: "Attachments and notes",
		NotesGroupCaption: "Notes",
		OpenChangeLogMenuCaption: "View change log",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		OurCompanyUserCaption: "Company employee",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderTemplate: "{0} / {1}",
		PasswordCaption: "Password",
		PasswordConfirmationCaption: "Password confirmation",
		PasswordMask: "123456789",
		PasswordMissMatchMessageCaption: "Passwords do not match",
		PortalUserCaption: "External user",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QuickAddButtonHint: "Add related activity",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		RolesTabCaption: "Roles",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		ServerLicAvailableCountCaption: "Issued {0} of unlimited",
		SessionGroupCaption: "Session settings",
		SessionTimeoutTitle: "User session timeout, min",
		SpecifyPasswordMessage: "Specify the value",
		SysLicPackageCaption: "Name",
		SysLicUserTabCaption: "Licenses",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		TabVisaCaption: "Approvals",
		TagButtonHint: "Tags",
		TypeCaption: "Type",
		UnblockErrorMessage: "Unable to unblock this user",
		UnblockSuccessMessage: "The user has been successfully unblocked. Login available",
		UnblockUserButtonCaption: "Unblock",
		UncheckLicensesCaption: "Clear all",
		UserEmailCaption: "Email",
		UserEmailNotUnique: "",
		UserNameCaption: "Username",
		UserNameNotUnique: "Administration object with this name or email already exists.",
		UserPageHeader: "User",
		ViewOptionsButtonCaption: "View",
		ESNTabCaption: "Feed",
		SubscribeCaption: "Follow the feed",
		UnsubscribeCaption: "Unfollow the feed",
		SubscribedInformationDialog: "You are now following feed: {0}",
		UnsubscribedInformationDialog: "You have stopped following feed: {0}",
		OrganizationCaption: "Organization",
		UserNameTip: "Serves as Creatio login. Manage the field availability for external users via the \u201CAllow use Username as login to Creatio for External users\u201D system setting",
		UserNamePlaceholder: "Not available for external users",
		PhoneCaption: "Phone",
		RedistributeLicensesBasedOnRoleCaption: "Redistribute licenses based on roles",
		WeekFirstDayCaption: "First day of the week",
		TimeZoneCaption: "Time Zone",
		TimelineTabCaption: "Timeline"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		DefaultPhoto: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "DefaultPhoto",
				hash: "6985edb87f777607967eed9d8070db42",
				resourceItemExtension: ".jpg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "ToolsButtonImage",
				hash: "5313afea21fddf8b1fdcf38278a0b684",
				resourceItemExtension: ".png"
			}
		},
		TagButtonIcon: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "TagButtonIcon",
				hash: "749c444773b4d39e64c4f6938fdf6d76",
				resourceItemExtension: ".svg"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "UserPageV2",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});