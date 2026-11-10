define("PreconfiguredPageUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WhatPageToOpenLabelCaption: "Which page to open?",
		ToWhomOpenPageLabelCaption: "For whom to open page?",
		WhichRecordToConnectThePageToLabelCaption: "Which record to connect the page to?",
		EntitySchemaCaption: "Connected object",
		EntityCaption: "Record of connected object",
		PageParametersLabelCaption: "Page parameters",
		PageHasNoParametersLabelCaption: "Page parameters are not set",
		OpenSchemaButtonHintCaption: "Open page designer",
		AddSchemaButtonHintCaption: "Add new page",
		InteractiveElementsLabelCaption: "Which buttons complete the page?",
		PageTemplateLookupCaption: "Classic UI page",
		AngularPageTemplateLookupCaption: "Freedom UI page",
		CannotEditAngularSchemaMessage: "Please note that the Freedom UI pages cannot be accessed through the started BP if you have Freedom UI turned off in Creatio.",
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
		InformationOnStepCaption: "User hints",
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
		ProcessInformationText: "Displays any existing page in the system to the user specified in the process element properties.Best used for displaying complex custom pages that were created in the [Configuration] section.We recommend using the [Open edit page] element to display standard edit pages. \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022PreconfiguredPageUserTaskPropertiesPage\u0022\u003ERead more...\u003C/a\u003E",
		ProcessSchemaParameterEditPageCaption: "Insert parameter",
		RecepientTip: "Specify the email address of the recipient. You can select a specific email address or define it based on information from other process items.",
		RecommendationCaption: "Recommendations for filling out the page",
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
		ImageListSchemaItem1: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "ImageListSchemaItem1"
			}
		},
		AddButtonImage32: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage32",
				hash: "d30933184bec2d3279aaeda342cc0943",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "OpenButtonImage",
				hash: "dbe272c4aa382cf59c0b35a74280c79d",
				resourceItemExtension: ".png"
			}
		},
		TaskParameters: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "TaskParameters",
				hash: "6459903fca299a02797f22247bda9773",
				resourceItemExtension: ".png"
			}
		},
		TaskParameterssSelected: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "TaskParameterssSelected",
				hash: "6459903fca299a02797f22247bda9773",
				resourceItemExtension: ".png"
			}
		},
		Main: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "Main",
				hash: "6e62a8816a5eb00fd97054cace21d189",
				resourceItemExtension: ".png"
			}
		},
		MainSelected: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "MainSelected",
				hash: "6e62a8816a5eb00fd97054cace21d189",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "PreconfiguredPageUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});