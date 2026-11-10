define("ProcessFlowElementPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ProcessSchemaParameterEditPageCaption: "Insert parameter",
		EmptyParametersMessage: "Element has no parameters",
		ParametersTabCaption: "Parameters",
		AddParameterButtonCaption: "Add parameter",
		IsLoggingCaption: "Enable logging",
		SerializeToDBCaption: "Serialize in DB",
		MappingPlaceholderCaption: "Select value",
		RecepientTip: "Specify the email address of the recipient. You can select a specific email address or define it based on information from other process items.",
		UseBackgroundModeCaption: "Run following elements in the background",
		MultiInstanceExecutionModeCaption: "Execution mode",
		IgnoreMultiInstanceErrorsCaption: "Continue execution on errors",
		BackgroundModePriority100Caption: "Low",
		BackgroundModePriority200Caption: "Medium",
		BackgroundModePriority300Caption: "High",
		BackgroundModePriority0Caption: "By process priority",
		BackgroundModePriorityCaption: "Background execution priority",
		CaptionCaption: "Title",
		CloseButtonCaption: "Close",
		DeleteMenuItemCaption: "Delete",
		DescriptionCaption: "Description",
		DuplicateNameMessage: "Element with this code already exists.",
		DuplicateParameterNameMessage: "Parameter with this code already exists.",
		EditMenuItemCaption: "Edit",
		ElementPropertyNotFoundExceptionMessage: "Property \u0027{0}\u0027 not found in item \u0027{1}\u0027",
		ExtendedModeCaption: "Advanced mode",
		InavalidMappingColumn: "Invalid formula",
		NameCaption: "Code",
		PrimaryModeCaption: "Primary mode",
		ProcessInformationText: "Hint",
		SaveButtonCaption: "Save",
		SettingsTabCaption: "Settings",
		WrongNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \u003C/br\u003E Symbol: 0-9 cannot be first."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessFlowElementPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessFlowElementPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessFlowElementPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessFlowElementPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "ProcessFlowElementPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessFlowElementPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});