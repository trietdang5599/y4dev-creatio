define("DuplicateNotificationPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MergeDuplicateRecordsButton_caption: "Merge",
		CancelButton: "Edit record",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Potential duplicates found",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save anyway"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Duplicate Notification Page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});