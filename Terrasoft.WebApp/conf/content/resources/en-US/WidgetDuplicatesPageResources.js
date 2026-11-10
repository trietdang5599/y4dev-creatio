define("WidgetDuplicatesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WidgetPageInfoTitleLabelCaption: "Great job! No duplicates of this record found in Creatio. Return to the section or run sectionwide duplicate search",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		AccountEmptyInfoTitleLabelCaption: "Good job! Your database seems to have no duplicate accounts. Now it\u0027s a good time to enjoy a cup of coffee.",
		AccountHeaderCaption: "Duplicate accounts",
		AccountHeaderLabelCaption: "This is the list of duplicate accounts found according to the duplicates rules. {0}How does it work{1}?",
		ActionButtonCaption: "Actions",
		BeginProcessButtonMenuItemCaption: "Start process",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		CommonErrorMessage: "We\u0027re sorry, for some reason we were not able to run the search engine. Please try again later or contact your administrator for help.",
		ConfirmationRunDeduplicationMessage: "Before we start the search, we\u0027ll have to clear all the previous search results.\nDo you want to continue?",
		ContactEmptyInfoTitleLabelCaption: "Good job! Your database seems to have no duplicate contacts. Now it\u0027s a good time to enjoy a cup of coffee.",
		ContactHeaderCaption: "Duplicate contacts",
		ContactHeaderLabelCaption: "This is the list of duplicate contacts found according to the duplicates rules. {0}How does it work{1}?",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		DuplicatesRulesSetupCaption: "Setup duplicates rules",
		DuplicatesSummaryCaption: "Duplicates:",
		EmptyCollectionWithFiltersDescription: "Clear the filter or change its conditions.",
		EmptyCollectionWithFiltersTitle: "There are no records matching the filter criteria.",
		EmptyInfoDescriptionLabelCaption: "Things change quickly. You can always run another search to fight duplicates again.",
		FieldLockHint: "Non-editable field",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		FilterButtonCaption: "Filters",
		FindAccountDuplicatesButtonCaption: "Run duplicate accounts search",
		FindContactDuplicatesButtonCaption: "Run duplicate contacts search",
		FindDuplicatesButtonCaption: "Find duplicates",
		FindDuplicatesButtonCaptionPattern: "Run duplicate search",
		FirstRunInfoDescriptionLabelCaption: "You can go to Actions and run the search now.",
		FirstRunInfoTitleLabelCaption: "Looks like you haven\u0027t searched for duplicates yet.",
		FirstRunMarker: "FirstRun",
		GroupSummaryCaption: "Groups:",
		HeaderCaption: "Duplicates",
		HeaderLabelCaption: "This is the list of duplicates according to the duplicates rules. {0}How does it work{1}?",
		HeaderTipAcademyBtnCaption: "Learn more at the Academy",
		HeaderTipCaption: "Page appearance has been improved in Creatio 7.8",
		HeaderTipContent: "The page field layout has changed. Only the fields that you configured for the previous version are displayed here. For your convenience, you can move these fields to the record profile (on the left) or to the tab array using the Page Designer.",
		HeaderTipDesignerBtnCaption: "Set up now",
		HeaderTipNotShowBtnCaption: "Do not show this message again",
		IncrementMaskSuffix: "CodeMask",
		IncrementNumberSuffix: "LastNumber",
		InProgressMessage: "We\u0027re investigating your customer base right now to find any records that are duplicates. Please hold on, and we\u0027ll send you a notification once we\u0027re done.",
		ItemsIsEmptyMarker: "ItemsIsEmpty",
		NewRecordPageCaptionSuffix: ": New record",
		NotesAndFilesTabCaption: "Attachments and notes",
		NotesGroupCaption: "Notes",
		OpenListSettingsCaption: "List setting",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderMask: "Duplicates search in the \u0027{0}\u0027 section",
		PageHeaderTemplate: "{0} / {1}",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QuickAddButtonHint: "Add related activity",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		SearchInProcessInfoDescriptionLabelCaption: "This will take a few minutes. When it is completed, you will receive a notification.",
		SearchInProcessInfoTitleLabelCaption: "Duplicate search is running.",
		SearchInProcessMarker: "SearchInProcess",
		SearchIsInProcessErrorMessage: "Duplicate search was launched earlier. Wait until current Duplicate search will finish, before starting new search.",
		SetUpBulkDeduplicationRules: "Duplicate search rules are missing or disabled. To start the search, please setup the rules.",
		SuccessMessage: "Search executed successfully.",
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
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		ItemsIsEmptyImage: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "ItemsIsEmptyImage",
				hash: "111fa004c4428588a93a21af8007964e",
				resourceItemExtension: ".png"
			}
		},
		FirstRunImage: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "FirstRunImage",
				hash: "0df64d6971c268276b517a3be1fe7436",
				resourceItemExtension: ".png"
			}
		},
		SearchInProcessImage: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "SearchInProcessImage",
				hash: "eb6de105007c629d873f0b514ec04c23",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "WidgetDuplicatesPage",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});