define("VwProcessLibSectionResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowExtendedPropertiesActionCaption: "Process setup",
		RunProcessButtonCaption: "Run process",
		CancelRunningProcessesActionCaption: "Cancel running processes",
		ProcessPropertiesEnableProcess: "Activate process",
		ProcessPropertiesDisableProcess: "Deactivate process",
		OpenRecordGridRowButtonCaption: "Open",
		OpenInDesignerButtonCaption: "Open in designer",
		DeleteProcessConfirmationMessage: "Are you sure that you want to delete process?\u0027",
		DeleteRunningProcessConfirmationMessage: "Are you sure that you want to cancel and delete selected process?\n\nNumber of process running instances found: {0}",
		OpenProcessLogButtonCaption: "Process log",
		AddRecordButtonCaption: "New process",
		RunMiltiplyProcessesMessage: "You have selected {0} processes to run.\nDo you really want to run so many processes at once?",
		RunMiltiplyProcessesButtonCaption: "Run",
		DeactivateMiltiplyProcessesMessage: "You have selected {0} processes to deactivate.\nDo you really want to deactivate so many processes at once?",
		DeactivateMiltiplyProcessesButtonCaption: "Deactivate",
		ProcessesItemsMessage: "Processed {0} items",
		DeleteMiltiplyProcessesMessage: "You have selected {0} processes to delete.\nDo you really want to delete so many processes at once?",
		RunMiltiplyProcessesMessageResult: "{0} processes were started",
		DeleteMiltiplyProcessesMessageResult: "Deleted {0} processes",
		DeactivateMiltiplyProcessesMessageResult: "Deactivated {0} processes",
		ActivateMiltiplyProcessesMessageResult: "Activated {0} processes",
		DeleteProcessButtonCaption: "Delete",
		ProcessCaption: "Process",
		YesForAllButton: "Yes for all",
		ImportFromBpmnCaption: "Import from *.bpmn",
		EnableParameterDataOptimization: "Enable parameter data optimization",
		DisableParameterDataOptimization: "Disable parameter data optimization",
		DisableMultiplyParameterDataOptimizationResult: "Parameter data optimization disabled for {0} processes",
		EnableMultiplyParameterDataOptimizationResult: "Parameter data optimization enabled for {0} processes",
		ProcessParameterDataOptimizationSaveException: "The error occurred while saving the property. Please try again",
		DeleteParameterDataOptimization: "Delete parameter data optimization user property",
		ExportListToExcelFileButtonCaption: "Export to Excel",
		MultiTagButtonCaption: "Add tag",
		OpenChangeLogMenuCaption: "View change log",
		OpenObjectChangeLogSettingsCaption: "Change log setup",
		OperationAccessDenied: "Current user does not have sufficient permissions to run \u0022{0}\u0022",
		QueryOptimizationFailedRecommendation: "Please try changing the filter parameters or contact technical support.",
		QueryOptimizationFailedTitle: "Unfortunately, your filter could not be processed within the time allotted.",
		ReExecuteMessage: "We are doing our best to optimize your filter. This will not take long."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImportIcon: {
			source: 3,
			params: {
				schemaName: "VwProcessLibSection",
				resourceItemName: "ImportIcon",
				hash: "3ef83963cdc470a20dfe2c65e929430e",
				resourceItemExtension: ".svg"
			}
		},
		ShowDuplicatesBtnImage: {
			source: 3,
			params: {
				schemaName: "VwProcessLibSection",
				resourceItemName: "ShowDuplicatesBtnImage",
				hash: "fa120a8db42142879bc508b69c6a5993",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});