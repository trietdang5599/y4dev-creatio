define("WordPrintablePageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ReportCaptionLabel: "Report name",
		ShowInSectionLabel: "Show in the list view",
		ShowInCardLabel: "Show in the record page",
		MacrosListDetailCaption: "Set up report data",
		TablePartsDetailCaption: "Set up report tables",
		MacrosListDetailInfoButtonText: "Select the fields that contain the data to display in the report. You can also use additional features of \u003Ca href=\u0022https://academy.creatio.com/documents?id=15701\u0022 target=\u0022_blank\u0022\u003Ebasic macros\u003C/a\u003E",
		TablePartsDetailInfoButtonText: "Select the fields that will be used to generate the report tables",
		EmptyDetailMessageCaption: "No data",
		InfoBlockCaption: "Note",
		InfoBlockStepsCaption: "To setup report:",
		InfoBlockStep1: "Install the Microsoft Word \u003Ca href=\u0022https://academy.creatio.com/documents?id=1412\u0022 target=\u0022_blank\u0022\u003Eplugin\u003C/a\u003E.",
		InfoBlockStep2: "Add the report\u0027s fields and table components. This page contains all the necessary settings.",
		InfoBlockStep3: "Open Microsoft Word and configure the report template. Save your to Creatio by running the corresponding command in the Microsoft Word plug-in.",
		InfoBlockDescription: "You can open an existing template for editing from the plugin. To do this, open Microsoft Word and select the desired template from the list.",
		InfoBlockAcademyLinkCaption: "Learn more about customizing Microsoft Word reports in Creatio Academy.",
		InfoBlockAcademyLink: "https://academy.creatio.com/documents?id=1247",
		TablePartsHeaderLabel: "Table name",
		EditButtonHint: "Edit",
		RemoveButtonHint: "Delete",
		FileImportContainerDescription: "In order to download to a PC or upload a Word report template to Creatio, use the steps below:",
		FileImportDragAndDropContainerCaption: "Drag and drop *.docx template here or",
		FileImportInvalidFileTypeMessage: "Incorrect file format. Please select an Word file (*.docx).",
		FileImportUploadFileButtonCaption: "Select file",
		FileImportDownloadTemplateFileCaption: "Download template",
		FileImportUploadTemplateFileCaption: "Upload template",
		TemplateSuccessfullyUploadedMessage: "Report template was successfully uploaded",
		Template404UploadError: "The report with current identifier is absent.",
		Template405UploadError: "The service is currently not available.",
		Template406UploadError: "Creatio was unable to parse the file. The file may be empty, encrypted or damaged. Please upload a different *.docx file.",
		TemplateGeneralUploadError: "Something went wrong.",
		FileImportInvalidSizeMessage: "File wasn\u0027t uploaded in case of maximum file size ({0} Mb) restrictions{1}.",
		CopyButtonHint: "Copy",
		SysModuleCaption: "Object",
		SysEntitySchemaHitLockContent: "The value cannot be changed because the report settings use the columns of the selected object",
		SysEntitySchemaHint: "Printing reports by any object is available only for Freedom UI pages. For Classic UI pages, you can only print reports by a section list page or section record page",
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
		SaveButtonCaption: "Apply",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		ViewOptionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AddTablePartIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "AddTablePartIcon",
				hash: "2e6f926cd4eda62282ea843667305962",
				resourceItemExtension: ".png"
			}
		},
		EditTablePartIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "EditTablePartIcon",
				hash: "bfa74c173dd5e19deb25bbfea4c8e8f4",
				resourceItemExtension: ".svg"
			}
		},
		DeleteTablePartIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "DeleteTablePartIcon",
				hash: "3fb6fd3ff62f2e034a562effe92797e9",
				resourceItemExtension: ".svg"
			}
		},
		InfoBlockIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "InfoBlockIcon",
				hash: "3ff52fd68beb60b4a8de6d2eddd8ece6",
				resourceItemExtension: ".png"
			}
		},
		FileImportEmptyFileImage: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "FileImportEmptyFileImage",
				hash: "8a7e6ded494970e56f56c08bd0a2720c",
				resourceItemExtension: ".png"
			}
		},
		FileImportErrorFileImage: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "FileImportErrorFileImage",
				hash: "47721e5c6d19ec12a93caaf6a7b3a133",
				resourceItemExtension: ".png"
			}
		},
		FileImportWordIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "FileImportWordIcon",
				hash: "ab99305ca510b0d54a8baf32de78fb20",
				resourceItemExtension: ".png"
			}
		},
		FileImportDeleteTemplateIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "FileImportDeleteTemplateIcon",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		FileImportUploadTemplateIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "FileImportUploadTemplateIcon",
				hash: "67d2b27a2452938855341111b33cd6e0",
				resourceItemExtension: ".png"
			}
		},
		FileImportDownloadTemplateIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "FileImportDownloadTemplateIcon",
				hash: "f5e5a3a9f0823b310d012701bfddf409",
				resourceItemExtension: ".png"
			}
		},
		CopyTablePartIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "CopyTablePartIcon",
				hash: "07a9eac5c56f1e2b11f1f564eabb0651",
				resourceItemExtension: ".svg"
			}
		},
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "WordPrintablePage",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});