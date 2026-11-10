define("OpenEditPageUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		EditModeCaption: "Editing mode",
		AddNewRecordCaption: "Add new record",
		EditExistingRecordCaption: "Edit existing record",
		ChangePageSchemaWarningMessage: "Are you sure you want to change this page? All field values and filter settings will be lost.",
		ChangPageSchemaeButtonCaption: "Change",
		RecommendationForFillPageCaption: "Recommendation for filling in the page",
		WhoFillPageLabelCaption: "Who fills in the page?",
		HowElementPerformedLabelCaption: "You can use the list of values in this column to set up process branching via conditional flows.",
		RecordIdCaption: "Record ID",
		DefaultValuesLabelCaption: "Which default values to set in the fields of new records?",
		GenerateDecisionsFromColumnCaption: "Create a list of results by column",
		DecisionalColumnMetaPathCaption: "Column",
		ConsiderElementExecutedCaption: "When is the element considered complete?",
		ExecutedAfterRecordSavedCaption: "Immediately after saving the record",
		ExecutedIfMatchConditionsCaption: "If the record matches conditions",
		FilterInformationText: "Filtering parameters are required",
		FilterInvalidMessage: "Filtering parameters can not be empty",
		RecordIdInvalidMessage: "\u0022Record Id\u0022 field must be filled in",
		PortalPageMarkerCaption: "Portal",
		ExecutedIfRecordMeetsConditionsCaption: "If the record meets the specified conditions",
		ExecutedAfterSaveButtonPressedCaption: "Immediately after the user saves the record",
		ActivityLinksCaption: "Connected to",
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
		CreateActivityCaption: "Log activity",
		CurrentUserContactDisplayValue: "[#System variable.Current user contact#]",
		DaysCaption: "days",
		DeleteMenuItemCaption: "Delete",
		DescriptionCaption: "Description",
		DuplicateNameMessage: "Element with this code already exists.",
		DuplicateParameterNameMessage: "Parameter with this code already exists.",
		DurationCaption: "Planned duration",
		EditMenuItemCaption: "Edit",
		ElementPropertyNotFoundExceptionMessage: "Property \u0027{0}\u0027 not found in item \u0027{1}\u0027",
		EmptyParametersMessage: "Element has no parameters",
		ExtendedModeCaption: "Advanced mode",
		HoursCaption: "hours",
		IgnoreMultiInstanceErrorsCaption: "Continue execution on errors",
		InavalidMappingColumn: "Invalid formula",
		InformationOnStepCaption: "Hint  for user",
		IsLoggingCaption: "Enable logging",
		MainTabInformationText: "Enter the main parameters for the task",
		MappingPlaceholderCaption: "Select value",
		MinutesCaption: "minutes",
		MonthsCaption: "months",
		MultiInstanceExecutionModeCaption: "Execution mode",
		NameCaption: "Code",
		NextTabButtonCaption: "Next \u003E",
		OwnerCaption: "Owner",
		OwnerRegionCaption: "Who performs the task?",
		ParametersTabCaption: "Parameters",
		PrimaryModeCaption: "Primary mode",
		ProcessInformationText: "Opens the selected edit for the user. You can choose to create a new record or open an existing one.Use this item to prompt the user to add and edit records in the system using edit pages.To add and edit records automatically, use the [Add data] and [Edit data] process elements. \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022OpenEditPageUserTaskPropertiesPage\u0022\u003ERead more...\u003C/a\u003E",
		ProcessSchemaParameterEditPageCaption: "Insert parameter",
		RecepientTip: "Specify the email address of the recipient. You can select a specific email address or define it based on information from other process items.",
		RecommendationCaption: "Which page to open?",
		RemindBeforeCaption: "Remind in",
		SaveButtonCaption: "Save",
		SchemaAddedMessage: "The \u0022{0}\u0022 has been added. Do you wish to select it in the \u0022{1}\u0022 element?",
		SchemaOutdatedMessage: "The \u0022{0}\u0022 page has been modified. Do you wish to update the parameters of the \u0022{1}\u0022 element?",
		SerializeToDBCaption: "Serialize in DB",
		SettingsButtonCaption: "Set",
		SettingsTabCaption: "Settings",
		ShowExecutionPageCaption: "Show page automatically",
		ShowInSchedulerCaption: "Show in calendar",
		StartInCaption: "Start in",
		TaskParametersTabInformationText: "Enter the temporary parameters for the task",
		UseBackgroundModeCaption: "Run following elements in the background",
		WeeksCaption: "weeks",
		WrongNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \u003C/br\u003E Symbol: 0-9 cannot be first."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		TaskParameters: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "TaskParameters",
				hash: "6459903fca299a02797f22247bda9773",
				resourceItemExtension: ".png"
			}
		},
		TaskParameterssSelected: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "TaskParameterssSelected",
				hash: "6459903fca299a02797f22247bda9773",
				resourceItemExtension: ".png"
			}
		},
		Main: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "Main",
				hash: "6e62a8816a5eb00fd97054cace21d189",
				resourceItemExtension: ".png"
			}
		},
		MainSelected: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "MainSelected",
				hash: "6e62a8816a5eb00fd97054cace21d189",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "OpenEditPageUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});