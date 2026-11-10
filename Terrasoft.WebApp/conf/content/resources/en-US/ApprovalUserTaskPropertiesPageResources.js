define("ApprovalUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PurposeCaption: "Approval purpose",
		ApprovalObjectCaption: "Approval object",
		RecordIdCaption: "Record Id",
		ApproverCaption: "Approver",
		EmployeeCaption: "User",
		EmployeeManagerCaption: "Employee\u0027s manager",
		RoleCaption: "Role",
		EmployeeIdCaption: "Employee",
		RoleIdCaption: "Role",
		IsAllowedToDelegateCaption: "Approval may be delegated",
		SectionSelectInfoButtonCaption: "There are no sections for which the approvals are enabled. \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022ApprovalSectionSelectInfoButton\u0022\u003ERead more...\u003C/a\u003E",
		IsSendEmailToApproversCaption: "Notify that approval is required",
		EmailTemplateCaption: "Email template",
		IsSendEmailToAuthorCaption: "Notify about the approval result",
		SendEmailCaption: "Send email notification",
		IgnoreEmailErrorsCaption: "Ignore errors on sending",
		RecipientCaption: "Recipient",
		OpenTemplateHint: "Open content designer",
		AddTemplateHint: "Add email template",
		VisaMailboxSettings: "Set up mailbox for email notification. \u003Ca href=\u0022#\u0022\u003ESet up...\u003C/a\u003E",
		DefaultPurpose: "Approval required",
		AddParameterButtonCaption: "Add parameter",
		BackgroundModePriority0Caption: "By process priority",
		BackgroundModePriority300Caption: "High",
		BackgroundModePriority200Caption: "Medium",
		BackgroundModePriority100Caption: "Low",
		BackgroundModePriorityCaption: "Background execution priority",
		CaptionCaption: "Title",
		CloseButtonCaption: "Close",
		DeleteMenuItemCaption: "Delete",
		DescriptionCaption: "Description",
		DuplicateNameMessage: "Element with this code already exists.",
		DuplicateParameterNameMessage: "Parameter with this code already exists.",
		EditMenuItemCaption: "Edit",
		ElementPropertyNotFoundExceptionMessage: "Property \u0027{0}\u0027 not found in item \u0027{1}\u0027",
		EmptyParametersMessage: "Element has no parameters",
		ExtendedModeCaption: "Advanced mode",
		IgnoreMultiInstanceErrorsCaption: "Continue execution on errors",
		InavalidMappingColumn: "Invalid formula",
		IsLoggingCaption: "Enable logging",
		MappingPlaceholderCaption: "Select value",
		MultiInstanceExecutionModeCaption: "Execution mode",
		NameCaption: "Code",
		ParametersTabCaption: "Parameters",
		PrimaryModeCaption: "Primary mode",
		ProcessInformationText: "Creates an approval for specified record. This element is completed once the user set the approval status. The approval status determine the results of the process element. \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022ApprovalUserTaskPropertiesPage\u0022\u003ERead more...\u003C/a\u003E",
		ProcessSchemaParameterEditPageCaption: "Insert parameter",
		RecepientTip: "Specify the email address of the recipient. You can select a specific email address or define it based on information from other process items.",
		SaveButtonCaption: "Save",
		SerializeToDBCaption: "Serialize in DB",
		SettingsTabCaption: "Settings",
		UseBackgroundModeCaption: "Run following elements in the background",
		WrongNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \u003C/br\u003E Symbol: 0-9 cannot be first."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "OpenButtonImage",
				hash: "dbe272c4aa382cf59c0b35a74280c79d",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage32: {
			source: 3,
			params: {
				schemaName: "ApprovalUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage32",
				hash: "d30933184bec2d3279aaeda342cc0943",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});