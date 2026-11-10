define("BaseUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OwnerCaption: "Owner",
		StartInCaption: "Start in",
		DurationCaption: "Planned duration",
		RemindBeforeCaption: "Remind in",
		ShowExecutionPageCaption: "Show page automatically",
		ShowInSchedulerCaption: "Show in calendar",
		ActivityLinksCaption: "Connected to",
		InformationOnStepCaption: "Hint  for user",
		RecommendationCaption: "What should be done?",
		MainTabInformationText: "Enter the main parameters for the task",
		TaskParametersTabInformationText: "Enter the temporary parameters for the task",
		NextTabButtonCaption: "Next \u003E",
		SettingsButtonCaption: "Set",
		MinutesCaption: "minutes",
		HoursCaption: "hours",
		DaysCaption: "days",
		WeeksCaption: "weeks",
		MonthsCaption: "months",
		OwnerRegionCaption: "Who performs the task?",
		CurrentUserContactDisplayValue: "[#System variable.Current user contact#]",
		CreateActivityCaption: "Log activity",
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
		ProcessInformationText: "Hint",
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
		TaskParameters: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "TaskParameters",
				hash: "6459903fca299a02797f22247bda9773",
				resourceItemExtension: ".png"
			}
		},
		TaskParameterssSelected: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "TaskParameterssSelected",
				hash: "6459903fca299a02797f22247bda9773",
				resourceItemExtension: ".png"
			}
		},
		Main: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "Main",
				hash: "6e62a8816a5eb00fd97054cace21d189",
				resourceItemExtension: ".png"
			}
		},
		MainSelected: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "MainSelected",
				hash: "6e62a8816a5eb00fd97054cace21d189",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});