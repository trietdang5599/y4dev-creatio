define("FileImportDuplicateManagementPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DuplicateColumnsGroupHeader: "Records are considered duplicates if following columns match",
		DeleteColumn: "Delete",
		AddColumnButtonCaption: "Add column",
		KeyColumnValidationFailedMessage: "The number of columns used for duplicate search is too large. Without optimization, the data may take too long to load. Please decrease the number of columns used for duplicate search to 50 or less (number of selected columns {0}).",
		BackToColumnSettingsButtonCaption: "Back",
		UpdateTemplateFlagCaption: "Save as template",
		EmptyImportSessionIdMessage: "Page URL is incorrect. Open the Data import page in System designer",
		Header: "Specify the duplicates search rule for data import to the system",
		NextButtonCaption: "Start data import"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});