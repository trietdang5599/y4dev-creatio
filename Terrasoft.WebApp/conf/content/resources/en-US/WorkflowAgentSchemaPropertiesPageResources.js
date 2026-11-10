define("WorkflowAgentSchemaPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AccessRightsPlaceholder: "Save the agent to be able to edit its access rights.",
		AccessRightsTitle: "Permissions to execute",
		AddParameterButtonCaption: "Add parameter",
		BackgroundModePriority0Caption: "By process priority",
		BackgroundModePriority100Caption: "Low",
		BackgroundModePriority200Caption: "Medium",
		BackgroundModePriority300Caption: "High",
		BackgroundModePriorityCaption: "Execution priority of background process tasks",
		CancelModuleButtonCaption: "Cancel",
		CaptionCaption: "Process parameters and settings",
		ChangeSysPackageConfirmationMessage: "Modifying the package may result in losing some of the data. Modify package?",
		ChangSysPackageButtonCaption: "Modify",
		CloseButtonCaption: "Close",
		CompiledProcessMethodsCaption: "Compiled process methods (obsolete)",
		ConfigureCompositeObjectCaption: "Create from element",
		CustomPackageName: "Custom",
		DeleteButtonCaption: "Delete",
		DeleteMenuItemCaption: "Delete",
		DescriptionCaption: "Process description",
		DuplicateNameMessage: "Process with this code already exists.",
		DuplicateParameterNameMessage: "Parameter with this code already exists.",
		EditButtonCaption: "Edit",
		EditMenuItemCaption: "Edit",
		ElementPropertyNotFoundExceptionMessage: "Property \u0027{0}\u0027 not found in item \u0027{1}\u0027",
		EmptyParametersMessage: "This process has no parameters",
		EnabledCaption: "Active",
		ExtendedModeCaption: "Advanced mode",
		IgnoreMultiInstanceErrorsCaption: "Continue execution on errors",
		InavalidMappingColumn: "Invalid formula",
		InavalidMappingMessage: "Enter a valid formula",
		IsActiveVersionCaption: "Actual version",
		IsLoggingCaption: "Enable logging",
		IsRequiredCaption: "Required parameter",
		MappingPlaceholderCaption: "Select value",
		MaxLoopCountCaption: "Maximum Number of Repetitions",
		MethodsTabCaption: "Methods",
		MultiInstanceExecutionModeCaption: "Execution mode",
		NameCaption: "Code",
		NotificationCaption: "",
		OtherMenuItemCaption: "Other",
		ParameterLookupCaption: "Lookup",
		ParameterNameCaption: "Name",
		ParametersCaption: "Parameters",
		ParametersTabCaption: "Parameters",
		ParameterTypeCaption: "Value type",
		PrimaryModeCaption: "Primary mode",
		ProcessDescriptionCaption: "Description",
		ProcessInformationText: "The \u0022Settings\u0022 tab contains general process properties, such as title, code and logging options.The \u0022Parameters\u0022 tab contains a list of process parameters used for exchanging information between different processes or between elements of one process.On the \u0022Methods\u0022 tab, software developers can add program methods to be used in a process. \u003Ca href=\u0022#\u0022 data-context-help-code=\u0022ProcessSchemaPropertiesPage\u0022 \u003ERead more...\u003C/a\u003E",
		ProcessMethodsCaption: "Methods",
		ProcessSchemaParameterEditPageCaption: "Insert parameter",
		RecepientTip: "Specify the email address of the recipient. You can select a specific email address or define it based on information from other process items.",
		RegenerateCompositeObjectMenuItemCaption: "Regenerate",
		SaveButtonCaption: "Save",
		SaveModuleButtonCaption: "Save",
		SerializeToDBCaption: "Serialize in DB",
		SettingsTabCaption: "Settings",
		StudioFreeProcessUrlCaption: "Link to process in Studio Free",
		StudioFreeProcessUrlHint: "Open in Studio Free",
		SysPackageCaption: "Package",
		TagCaption: "Tag",
		TitleCaption: "Process",
		UseBackgroundModeCaption: "Run following elements in the background",
		UseForceCompileCaption: "Force compile",
		UseSystemSecurityContextCaption: "Use system security context for script tasks",
		UseUserPermissionsCaption: "Use user permissions for elements",
		UsingsGroupCaption: "Usings",
		VersionCaption: "Version",
		WrongNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \u003C/br\u003E Symbol: 0-9 cannot be first."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "WorkflowAgentSchemaPropertiesPage",
				resourceItemName: "CloseButtonImage",
				hash: "c5d6edb4bb180f8b30301d3dca7a12d8",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "WorkflowAgentSchemaPropertiesPage",
				resourceItemName: "ToolsButtonImage",
				hash: "67b9187f776eb0c57c20bd86b63d4efc",
				resourceItemExtension: ".svg"
			}
		},
		InfoButtonImage: {
			source: 3,
			params: {
				schemaName: "WorkflowAgentSchemaPropertiesPage",
				resourceItemName: "InfoButtonImage",
				hash: "f67a1328d14dbc7091cc94589d7d2148",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "WorkflowAgentSchemaPropertiesPage",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		},
		AddParameterButton: {
			source: 3,
			params: {
				schemaName: "WorkflowAgentSchemaPropertiesPage",
				resourceItemName: "AddParameterButton",
				hash: "5820e7d4d72f80e196c309ee4642adeb",
				resourceItemExtension: ".png"
			}
		},
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "WorkflowAgentSchemaPropertiesPage",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "WorkflowAgentSchemaPropertiesPage",
				resourceItemName: "OpenButtonImage",
				hash: "dbe272c4aa382cf59c0b35a74280c79d",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});