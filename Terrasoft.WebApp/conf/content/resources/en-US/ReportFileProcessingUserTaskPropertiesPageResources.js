define("ReportFileProcessingUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ReportsSelectCaption: "What report to generate?",
		SectionCaption: "Section",
		IsSeparateReportsCaption: "Generate separate report for each record",
		ChangeReportWarningMessage: "Are you sure you want to change the report? All field values and filter settings will be lost.",
		ReportNameCaption: "File name",
		ReportNameInfoButtonContent: "The file name consists of the selected report name and the value specified in this parameter.",
		SelectionResult: "Selection result",
		AddParameterButtonCaption: "Add parameter",
		AfterActivitySaveScriptCaption: "After Activity Saved",
		CaptionCaption: "Title",
		ChangePageSchemaButtonCaption: "Change",
		ChangeReferenceSchemaButtonCaption: "Change",
		ChangeReferenceSchemaWarningMessage: "Are you sure you want to change this object? All field values and filter settings will be lost.",
		ChangeResultActionTypeWarningMessage: "Are you sure you want to change the action? The selected saving settings will be lost.",
		ChangeSchemaWarningMessage: "Are you sure you want to change element schema? All parameters will be lost.",
		ChangeSourceActionTypeWarningMessage: "Are you sure you want to change the source? All field values and filter settings will be lost.",
		CloseButtonCaption: "Close",
		DeleteMenuItemCaption: "Delete",
		DescriptionCaption: "Description",
		DuplicateNameMessage: "Element with this code already exists.",
		DuplicateParameterNameMessage: "Parameter with this code already exists.",
		EditMenuItemCaption: "Edit",
		ElementPropertyNotFoundExceptionMessage: "Property \u0027{0}\u0027 not found in item \u0027{1}\u0027",
		EmptyParametersMessage: "Element has no parameters",
		ExtendedModeCaption: "Advanced mode",
		FilterUnitCaption: "How to filter records?",
		IgnoreMultiInstanceErrorsCaption: "Continue execution on errors",
		InavalidMappingColumn: "Invalid formula",
		InvalidEntitySchemaChange: "Process element cannot be changed",
		IsLoggingCaption: "Enable logging",
		MappingPlaceholderCaption: "Select value",
		MultiInstanceExecutionModeCaption: "Execution mode",
		NameCaption: "Code",
		ParametersTabCaption: "Parameters",
		PrimaryModeCaption: "Primary mode",
		ProcessInformationText: "Use this element to work with files. \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022ReportFileProcessingUserTaskPropertiesPage\u0022\u003ERead more...\u003C/a\u003E",
		ProcessSchemaParameterEditPageCaption: "Insert parameter",
		RecepientTip: "Specify the email address of the recipient. You can select a specific email address or define it based on information from other process items.",
		ResultActionType0Caption: "Save to object attachments",
		ResultActionType1Caption: "Use in process",
		ResultActionTypeCaption: "What to do with file?",
		SaveButtonCaption: "Save",
		SchemaAddedMessage: "The \u0022{0}\u0022 has been added. Do you wish to select it in the \u0022{1}\u0022 element?",
		SchemaOutdatedMessage: "The \u0022{0}\u0022 page has been modified. Do you wish to update the parameters of the \u0022{1}\u0022 element?",
		SerializeToDBCaption: "Serialize in DB",
		SettingsTabCaption: "Settings",
		SourceActionType0Caption: "Object attachments",
		SourceActionType1Caption: "Generated report",
		SourceActionTypeCaption: "What is the source of the file?",
		TargetEntitySchemaSelectCaption: "What object to save file to?",
		UseBackgroundModeCaption: "Run following elements in the background",
		WrongNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \u003C/br\u003E Symbol: 0-9 cannot be first."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "ReportFileProcessingUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ReportFileProcessingUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "ReportFileProcessingUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ReportFileProcessingUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "ReportFileProcessingUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ReportFileProcessingUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});