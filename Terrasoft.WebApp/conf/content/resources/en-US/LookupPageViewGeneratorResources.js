define("LookupPageViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SelectButtonCaption: "Select",
		CancelButtonCaption: "Cancel",
		ActionButtonCaption: "Actions",
		AddButtonCaption: "New",
		DeleteButtonCaption: "Delete",
		EditButtonCaption: "Edit",
		CopyButtonCaption: "Copy",
		SelectedRecordsLabelCaption: "Records selected",
		SettingsColumnButtonCaption: "Columns setup",
		SearchButtonCaption: "Search",
		CountSelectedRecord: "Records selected:",
		StartProcessButtonCaption: "Run",
		ShowProcessLogButtonCaption: "Process log",
		UnSelectAllActionCaption: "Deselect all",
		RunButtonCaption: "Run",
		SelectAllActionButtonCaption: "Select all"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "LookupPageViewGenerator",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});