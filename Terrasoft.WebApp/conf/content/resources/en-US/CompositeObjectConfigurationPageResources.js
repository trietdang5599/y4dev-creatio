define("CompositeObjectConfigurationPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SelectDeselectAllCheckboxCaption: "Select/Deselect all",
		ElementParametersEmptyGridMessage: "This element has no parameters",
		ElementParametersNoElementsFoundMessage: "No process elements found",
		ElementParametersNoParametersFoundMessage: "No element parameters found",
		ElementParametersNoRequiredParameters: "There are no parameters of required type",
		ElementParametersSearchPlaceholder: "Search element parameter",
		ElementSearchPlaceholder: "Search process element",
		ElementsEmptyGridMessage: "This process has no elements with parameters"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});