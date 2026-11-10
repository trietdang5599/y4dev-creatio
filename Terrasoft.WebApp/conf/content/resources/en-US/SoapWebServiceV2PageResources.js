define("SoapWebServiceV2PageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SoapNamespaceCaption: "Namespaces",
		SoapNamespaceHint: "Insert only namespaces used in methods (operations) and parameters. Namespaces are declared as \u0022Namespace prefix\u0022:\u0022Namespace name\u0022 separated by \u0022;\u0022 symbol or newline, for example, nsprefix1:http://example.com/ns1; nsprefix2:http://example.com/ns2. If there is only one namespace, prefix is unnecessary, for example, http://example.com/ns1.",
		InvalidNamespaceMessage: "Invalid value. Please check that syntax matches the pattern described in the tooltip.",
		InvalidParameterMessage: "- Parameter \u0022{0}\u0022 in method \u0022{1}\u0022: prefix \u0022{2}\u0022",
		InvalidMethodMessage: "- Method \u0022{0}\u0022: prefix \u0022{1}\u0022",
		InvalidSchemaTitleMessage: "Some namespace prefixes from \u0022Method code in WSDL\u0022 field in methods or from method parameter codes are missing from \u0022Namespaces\u0022 service field. Please change them or add namespaces to correctly call the service:",
		SaveServiceButtonCaption: "Save web service",
		AcademyDesignerUrl: "http://academy.bpmonline.com/documents/docs/product/bpm\u0027online%20sales/enterprise/7.8.0/BPMonlineHelp/chapter_section_wizard/section_wizard_page_fields_setup.htm#XREF_49522",
		ActionButtonCaption: "Actions",
		AuthCaption: "Authentication",
		AuthTypeBasicCaption: "Basic",
		AuthTypeDigestCaption: "Digest",
		AuthTypeNoneCaption: "None",
		BaseUriCaption: "Web service URI",
		BeginProcessButtonMenuItemCaption: "Start process",
		CancelButtonCaption: "Cancel",
		CanCustomizeWarning: "Define {0} attribute instead of overriding function {1} to empty",
		CaptionCaption: "Name",
		ChangeQueueItemDateButtonCaption: "Postpone till",
		ChangeURIButtonCaption: "",
		ClearButtonHint: "Clear value",
		CloseButtonCaption: "Close",
		CodeHint: "Used by developers for interacting with the web service in Creatio source code",
		ColumnFilterInvalidFormatException: "Filtering by the {0} column is configured incorrectly",
		ContinueProcessButtonMenuItemCaption: "Continue process",
		DelayExecutionButtonCaption: "Perform later",
		DenyAccess: "The package of the web service cannot be modified or you do not have permission to edit this web service. Copy this web service or modify the \u0022Current package\u0022 system setting, or obtain corresponding permissions.",
		DescriptionCaption: "Description",
		DuplicateNameMessage: "Service with this code already exists.",
		EmptyGrid: "",
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
		MethodsTabCaption: "Methods",
		MultipleQueueItemsFoundError: "More than one queue element connected to the process. Process Id: {0}",
		NameCaption: "Code",
		NewRecordPageCaptionSuffix: ": New record",
		NoAvailablePackages: "No packages available. Create a package in the \u0022Advanced settings\u0022 section where this web service will be saved.",
		NotesAndFilesTabCaption: "Attachments and notes",
		NotesGroupCaption: "Notes",
		OpenAdvancedSettings: "Open advanced settings",
		OpenListSettingsCaption: "List setup",
		OpenNewSectionDesignerButtonCaption: "Open new page designer",
		OpenSectionDesignerButtonCaption: "Open page designer",
		PackageHint: "Creatio configuration package that stores the web service. You can add a custom package available for modification for new web services",
		PackageNameCaption: "Package",
		PageContainsUnsavedChanges: "You have unsaved changes that will be lost. Continue?",
		PageHeaderTemplate: "{0} / {1}",
		PostponeQueueItemButtonCaption: "Re-queue",
		PostponeQueueItemError: "Unable to re-queue item. Error message: {0}",
		PrintButtonCaption: "Print",
		ProcessEntryPointButtonCaption: "Move down the process",
		ProsessButtonCaption: "Run process",
		QueueItemIsEmptyError: "Page is not connected to the agent desktop queue element. Action cancelled.",
		QueueItemPostponeFailedMessage: "Unable to re-queue item",
		QueueItemPostponeSucceedMessage: "Successfully re-queued",
		QuickAddButtonHint: "Add related activity",
		RequiredFieldIsEmptyCaption: "Fill in the required {0} field to save the record",
		RetiresHint: "If the response from the web service contains an error code or response has timed out, the request will be repeated specified number of times",
		RetryCountCaption: "Retries on call failure",
		SaveButtonCaption: "Save",
		SaveEditButtonHint: "Save (Ctrl\u002BEnter)",
		SchemaLocalizableString1: "",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		TabVisaCaption: "Approvals",
		TypeCaption: "Type",
		UriHint: "Complete address for calling the web service will consist of this URI and settings specified in the method setup page",
		ViewOptionsButtonCaption: "View",
		WrongNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \u003C/br\u003E Symbol: 0-9 cannot be first.",
		WrongPrefixMessage: "Code must contain prefix \u0022{0}\u0022"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		EditIcon: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "EditIcon",
				hash: "c4420910a8aa27acfd7c15f041a2b516",
				resourceItemExtension: ".png"
			}
		},
		SettingIcon: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "SettingIcon",
				hash: "b465d6addc6086cf88b6dc35692dd43d",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "SoapWebServiceV2Page",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});