define("SysWorkplacePageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		HeaderCaption: "User\u0027s workplace",
		SettingsTabCaption: "Workplace setup",
		HomePageCaption: "Home page",
		OpenHomePageDesignerButtonHintCaption: "Open page designer",
		AddNewHomePageButtonHintCaption: "Add new home page",
		CopyHomePageDesignerButtonHintCaption: "Copy and open page designer",
		CannotEditPageHintCaption: "You cannot edit this page. You can only edit pages created in the Page Designer.\nTo change your homepage, select a different page available in the dropdown.\nTo add a new homepage, clear the field and click [\u002B]",
		CannotCopyPageHintCaption: "You cannot copy this page. You can only copy pages created in the Page Designer.\nTo copy your homepage, select a different page available in the dropdown.",
		HomepageWithUIdNotFound: "The workplace homepage is not available. Select another page or create a new page.",
		ChangeApplicationTypeWarningMessage: "You are about to change the type of the workplace. All sections incompatible with selected type of workplace will be removed. Do you wish to remove the sections?",
		CallServiceErrorMessage: "Something went wrong. Please contact system administrator.",
		RemoveButtonCaption: "Remove",
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
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "SysWorkplacePageV2",
				resourceItemName: "AddButtonImage",
				hash: "d30933184bec2d3279aaeda342cc0943",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "SysWorkplacePageV2",
				resourceItemName: "OpenButtonImage",
				hash: "9b2bbf4cdf66a372be8da9c52e0f4478",
				resourceItemExtension: ".svg"
			}
		},
		CopyButtonImage: {
			source: 3,
			params: {
				schemaName: "SysWorkplacePageV2",
				resourceItemName: "CopyButtonImage",
				hash: "7e9252c46738755e1e1bd73975478a8a",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});