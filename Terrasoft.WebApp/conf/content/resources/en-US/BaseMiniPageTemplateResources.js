define("BaseMiniPageTemplateResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DefaultHeaderCaption: "Title",
		ContinueInOtherPageButton_caption: "Continue in other page",
		CancelButton: "Cancel",
		CloseButton: "Close",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Mini page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});