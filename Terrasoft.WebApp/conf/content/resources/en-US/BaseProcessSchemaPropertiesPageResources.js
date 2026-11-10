define("BaseProcessSchemaPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		EnabledCaption: "Active",
		SysPackageCaption: "Package",
		CustomPackageName: "Custom",
		MaxLoopCountCaption: "Maximum Number of Repetitions",
		ProcessDescriptionCaption: "Description",
		ChangeSysPackageConfirmationMessage: "Modifying the package may result in losing some of the data. Modify package?",
		ChangSysPackageButtonCaption: "Modify",
		IsActiveVersionCaption: "Actual version",
		InavalidMappingMessage: "Enter a valid formula",
		UseSystemSecurityContextCaption: "Use system security context for script tasks",
		StudioFreeProcessUrlCaption: "Link to process in Studio Free",
		StudioFreeProcessUrlHint: "Open in Studio Free",
		VersionCaption: "Version",
		UseUserPermissionsCaption: "Use user permissions for elements",
		AddParameterButtonCaption: "Add parameter",
		BackgroundModePriority0Caption: "By process priority",
		BackgroundModePriority100Caption: "Low",
		BackgroundModePriority200Caption: "Medium",
		BackgroundModePriority300Caption: "High",
		BackgroundModePriorityCaption: "Execution priority of background process tasks",
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
		ProcessInformationText: "The \u0022Settings\u0022 tab contains general properties, such as title, code and logging options.",
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
				schemaName: "BaseProcessSchemaPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseProcessSchemaPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseProcessSchemaPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseProcessSchemaPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "BaseProcessSchemaPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseProcessSchemaPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseProcessSchemaPropertiesPage",
				resourceItemName: "OpenButtonImage",
				hash: "dbe272c4aa382cf59c0b35a74280c79d",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});