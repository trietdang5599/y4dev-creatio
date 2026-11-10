define("SimpleTaskAddModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ModifyTaskCaption: "Edit activity",
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		ModuleCaptionTemplate: "{0}{1}-{2}{3}",
		ShortDayStringTemplate: " {0}, {1} ",
		InProgress: "In progress",
		Finished: "Completed",
		NotStarted: "Not started",
		Canceled: "Canceled",
		SetAs: "Mark as \u0022{0}\u0022",
		ModuleMarker: "simple-task-add-module",
		ModuleInitializedMarker: "simple-task-add-module-initialized"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ModifyTaskIcon: {
			source: 3,
			params: {
				schemaName: "SimpleTaskAddModule",
				resourceItemName: "ModifyTaskIcon",
				hash: "bd9fc887b89b2316777ba66788b97f22",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});