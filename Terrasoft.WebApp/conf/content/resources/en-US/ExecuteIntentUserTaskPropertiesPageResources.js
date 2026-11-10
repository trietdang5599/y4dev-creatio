define("ExecuteIntentUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		IntentSchemaSelectCaption: "Which sub-agent to call?",
		AddSchemaButtonHintCaption: "Add new sub-agent",
		OpenSchemaButtonHintCaption: "Open sub-agent settings page",
		IntentSchemasEmptyListPlaceholder: "There are no sub-agent schemas configured",
		ExecuteIntentParametersCaption: "Sub-agent parameters",
		ExecuteIntentEmptyParametersMessage: "Parameters are not set in sub-agent",
		IntentCallStatus_WrongIntentMode: "Unsupported",
		IntentCallStatus_ResponseParsingFailed: "Parsing Error",
		IntentCallStatus_IntentNotFound: "Not Found",
		IntentCallStatus_InsufficientPermissions: "No Permissions",
		IntentCallStatus_InactiveIntent: "Inactive",
		IntentCallStatus_CantGenerateGoodResponse: "No Response",
		IntentCallStatus_FailedToExecute: "Execution Error",
		IntentCallStatus_ExecutedSuccessfully: "Success",
		IntentNotFoundMessage: "Sub-agent is missing or removed",
		IntentDeactivatedMessage: "Sub-agent is inactive",
		ExecuteIntentAttachmentsDisabledMessage: "",
		AddParameterButtonCaption: "Add parameter",
		AfterActivitySaveScriptCaption: "After Activity Saved",
		BackgroundModePriority0Caption: "By process priority",
		BackgroundModePriority100Caption: "Low",
		BackgroundModePriority200Caption: "Medium",
		BackgroundModePriority300Caption: "High",
		BackgroundModePriorityCaption: "Background execution priority",
		CaptionCaption: "Title",
		ChangePageSchemaButtonCaption: "Change",
		ChangeSchemaWarningMessage: "Are you sure you want to change element schema? All parameters will be lost.",
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
		ProcessInformationText: "Use this element to call Creatio.ai workflow. Before using the element, workflow sub-agent must be configured in Creatio.ai sub-agent section. \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022ExecuteIntentUserTaskPropertiesPage\u0022\u003ERead more...\u003C/a\u003E",
		ProcessSchemaParameterEditPageCaption: "Insert parameter",
		RecepientTip: "Specify the email address of the recipient. You can select a specific email address or define it based on information from other process items.",
		SaveButtonCaption: "Save",
		SchemaAddedMessage: "The \u0022{0}\u0022 has been added. Do you wish to select it in the \u0022{1}\u0022 element?",
		SchemaOutdatedMessage: "The \u0022{0}\u0022 page has been modified. Do you wish to update the parameters of the \u0022{1}\u0022 element?",
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
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "OpenButtonImage",
				hash: "dbe272c4aa382cf59c0b35a74280c79d",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage32: {
			source: 3,
			params: {
				schemaName: "ExecuteIntentUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage32",
				hash: "d30933184bec2d3279aaeda342cc0943",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});