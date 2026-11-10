define("SysSettingPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DefaultValueCaption: "Default value",
		ReferenceSchemaCaption: "Lookup",
		TypeCaption: "Type",
		IsCacheableInfoTip: "Used for system settings whose value is being read frequently. The value of the system setting will be saved in memory for quick access.",
		IsPersonalInfoTip: "If a user modifies the value of system setting, the modification will be applied only for this user. The system setting value will be unmodified for all other employees.",
		FileSelectCaption: "Select file",
		ClearBinaryValueCaption: "Clear value",
		DuplicateCodeMessage: "The entered code is already in use. Please enter another system setting code.",
		SaveToFileCaption: "Save to file",
		IsCacheableCaption: "Cached",
		ReadRightsGroupCaption: "Access for reading for internal users",
		WriteRightsGroupCaption: "Access for modification for internal users",
		IsSSPAvailableGroupCaption: "Access for external users",
		AllowAllButtonCaption: "Allow for all",
		RestrictAllButtonCaption: "Restrict for all",
		AllowByOperationButtonCaption: "Allow by operation",
		SysAdminOperationLookupPlaceholder: "Select operation",
		IsSSPAvailableCaption: "Allow reading for portal users",
		IsPersonalCaption: "Save value for current user",
		ReadRightsGroupInfoButtonCaption: "Users with permission to the \u003Ca href={0} target=\u0022_blank\u0022\u003E\u0022Access to \u0022System settings\u0022 section\u0022\u003C/a\u003E operation always have a full access.",
		ReadWriteRightsGroupInfoButtonCaption: "Users with permission to the \u003Ca href={0} target=\u0022_blank\u0022\u003E\u0022Access to \u0022System settings\u0022 section\u0022\u003C/a\u003E operation always have a full access. Access for modification by operation also means a reading access.",
		CodeInfoTip: "Used by developers for interacting with the system setting in Creatio source code.",
		SysSettingTypeInfoButtonTipMessage: "System settings with the \u0022Secured text\u0022 type are not being transmitted to the client (browser). This process is controlled by the \u0022UseSecureSettingsOnClient\u0022 flag in the Web.config configuration file of the Creatio application. Their values can still be set from the client (browser).",
		IsCacheableDisableInfoButtonContent: "The \u0022Cached\u0022 property is not available for the following data types: BLOB, Text (500 characters), Unlimited-length text, Encrypted string, Date/Time, and Date and Time.",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		ActionButtonCaption: "Actions",
		BeginProcessButtonMenuItemCaption: "Start process",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		FieldLockHint: "Non-editable field",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		HeaderTipAcademyBtnCaption: "Learn more at the Academy",
		HeaderTipCaption: "Page appearance has been improved in Creatio 7.8",
		HeaderTipContent: "The page field layout has changed. Only the fields that you configured for the previous version are displayed here. For your convenience, you can move these fields to the record profile (on the left) or to the tab array using the Page Designer.",
		HeaderTipDesignerBtnCaption: "Set up now",
		HeaderTipNotShowBtnCaption: "Do not show this message again",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		NewRecordPageCaptionSuffix: ": New record",
		NotesAndFilesTabCaption: "Attachments and notes",
		NotesGroupCaption: "Notes",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderTemplate: "{0} / {1}",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QuickAddButtonHint: "Add related activity",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		TabVisaCaption: "Approvals",
		ViewOptionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		InfoSpriteImage: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "InfoSpriteImage",
				hash: "c253d8a46fdd8595204eb650dd35e982",
				resourceItemExtension: ".png"
			}
		},
		ClearBinaryValueImage: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "ClearBinaryValueImage",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "SysSettingPage",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});