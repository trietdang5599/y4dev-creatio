define("BaseLookupPageTemplateResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DefaultHeaderCaption: "Select:",
		CancelButton_caption: "Cancel",
		SelectButton_caption: "Select",
		NewButton_caption: "New",
		CloseButton_caption: "Close",
		SearchFilterMain_placeholder: "Search"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Lookup page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});