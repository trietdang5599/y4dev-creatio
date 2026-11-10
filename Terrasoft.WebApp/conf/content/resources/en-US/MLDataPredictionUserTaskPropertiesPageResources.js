define("MLDataPredictionUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddParameterButtonCaption: "Add parameter",
		BackgroundModePriority0Caption: "By process priority",
		BackgroundModePriority300Caption: "High",
		BackgroundModePriority200Caption: "Medium",
		BackgroundModePriority100Caption: "Low",
		BackgroundModePriorityCaption: "Background execution priority",
		CaptionCaption: "Title",
		CFFilterAlreadyInteractedItemsCaption: "Receive recommendations for an item previously interacted",
		CFItemFilterDataCaption: "Recommended object",
		CFItemFilterInfoButtonText: "If filter parameters aren\u0027t set all items used for training will be used for recommendation",
		CFTopNCaption: "Number of recommended Items",
		CFUserFilterDataCaption: "Recommended to (Subject)",
		CloseButtonCaption: "Close",
		DataPredictModeCaption: "What type of prediction to use?",
		DeleteMenuItemCaption: "Delete",
		DescriptionCaption: "Description",
		DuplicateNameMessage: "Element with this code already exists.",
		DuplicateParameterNameMessage: "Parameter with this code already exists.",
		EditMenuItemCaption: "Edit",
		ElementPropertyNotFoundExceptionMessage: "Property \u0027{0}\u0027 not found in item \u0027{1}\u0027",
		EmptyParametersMessage: "Element has no parameters",
		EntityRecordCaption: "What record to perform prediction on?",
		ExtendedModeCaption: "Advanced mode",
		FilterDataIsNullOrEmptyMessage: "Filtering parameters are required",
		IgnoreMultiInstanceErrorsCaption: "Continue execution on errors",
		InavalidMappingColumn: "Invalid formula",
		IsLoggingCaption: "Enable logging",
		MappingPlaceholderCaption: "Select value",
		MLModelCaption: "Machine learning model",
		MultiInstanceExecutionModeCaption: "Execution mode",
		NameCaption: "Code",
		ParametersTabCaption: "Parameters",
		PredictCollectionCaption: "Predicting for a collection of records",
		PredictFilterDataCaption: "What records to perform prediction on?",
		PredictionTopNCaption: "How many items to suggest?",
		PredictSingleItemCaption: "Predicting for one record",
		PrimaryModeCaption: "Primary mode",
		ProcessInformationText: "Use this element for predicting data. Make sure you configure and successfully train the machine learning models in the [ML models] section before using the element. \u003Ca href=\u0022#\u0022 data-context-help-id=\u00227150\u0022\u003ERead more...\u003C/a\u003E",
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
				schemaName: "MLDataPredictionUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "MLDataPredictionUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "MLDataPredictionUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "MLDataPredictionUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "MLDataPredictionUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "MLDataPredictionUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});