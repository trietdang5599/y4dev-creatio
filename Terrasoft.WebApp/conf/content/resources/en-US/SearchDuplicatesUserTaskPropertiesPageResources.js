define("SearchDuplicatesUserTaskPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SourceObjectCaption: "Object",
		DuplicateRulesLabelCaption: "Deduplication rules",
		IsAutoMergeCaption: "Automatic duplicates merge",
		EntityColumnMappingCaption: "Columns mapping",
		EntityColumnMapping_DeleteMenuItemCaption: "Delete",
		EntityIdCaption: "Record identifier",
		EntityIdSchemaEmpty: "Selected record is emply",
		SearchEntitySchemaEmpty: "Duplicates search object is empty",
		SourceEntitySchemaEmpty: "Source object schema is empty",
		TypeCaption: "Find and merge duplicates",
		RuleCaption: "Rule",
		DuplicateRule_AddRecordColumnValuesButtonCaption: "Add a rule",
		EntityIdInfoCaption: "The element will find and merge duplicates of a record with this unique identifier",
		EntitySchemaInfoCaption: "The element will find and merge duplicates in this object",
		RuleSelectModeCaption: "Duplicate search rules",
		ReadOnlySelectedRulesCaption: "Specific rules",
		ReadAllRulesCaption: "All active rules",
		BlankSlateDescription: "Set up global search and deduplication to work with this element. Learn more about setting up Creatio components on the \u003Ca target=\u0022_blank\u0022 href=\u0022https://academy.creatio.com/documents?product=administration\u0026ver=7\u0026id=1959\u0022\u003EAcademy\u003C/a\u003E website.",
		AddParameterButtonCaption: "Add parameter",
		AfterActivitySaveScriptCaption: "After Activity Saved",
		CaptionCaption: "Title",
		ChangePageSchemaButtonCaption: "Change",
		ChangeReferenceSchemaButtonCaption: "Change",
		ChangeReferenceSchemaWarningMessage: "Are you sure you want to change this object? All field values and filter settings will be lost.",
		ChangeSchemaWarningMessage: "Are you sure you want to change element schema? All parameters will be lost.",
		CloseButtonCaption: "Close",
		DeleteMenuItemCaption: "Delete",
		DescriptionCaption: "Description",
		DuplicateNameMessage: "Element with this code already exists.",
		DuplicateParameterNameMessage: "Parameter with this code already exists.",
		EditMenuItemCaption: "Edit",
		ElementPropertyNotFoundExceptionMessage: "Property \u0027{0}\u0027 not found in item \u0027{1}\u0027",
		EmptyParametersMessage: "Element has no parameters",
		EntitySchemaSelectCaption: "Source object schema",
		ExtendedModeCaption: "Advanced mode",
		FilterDataIsNullOrEmptyMessage: "Filtering parameters are required",
		FilterInformationText: "Filtering parameters are required",
		FilterUnitCaption: "Modify all records that match condition",
		IgnoreMultiInstanceErrorsCaption: "Continue execution on errors",
		InavalidMappingColumn: "Invalid formula",
		InvalidEntitySchemaChange: "Process element cannot be changed",
		IsLoggingCaption: "Enable logging",
		MappingPlaceholderCaption: "Select value",
		MultiInstanceExecutionModeCaption: "Execution mode",
		NameCaption: "Code",
		ParametersTabCaption: "Parameters",
		PrimaryModeCaption: "Primary mode",
		ProcessInformationText: "Merges the duplicates into a resulting record based on the earliest-created record. During the merge, the element will update only the empty fields of the resulting record. The empty fields will be populated with the data of the latest-created record. The fields that have already contained data will remain unchanged. The data from details of all duplicate records will be added to the resulting record",
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
				schemaName: "SearchDuplicatesUserTaskPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "SearchDuplicatesUserTaskPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "SearchDuplicatesUserTaskPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "SearchDuplicatesUserTaskPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "SearchDuplicatesUserTaskPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "SearchDuplicatesUserTaskPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		},
		EntityColumnMapping_ToolButtonImage: {
			source: 3,
			params: {
				schemaName: "SearchDuplicatesUserTaskPropertiesPage",
				resourceItemName: "EntityColumnMapping_ToolButtonImage",
				hash: "51f50d3e7772d0dadb7c2bb05750a490",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});