define("BaseGridSectionTemplateResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FilteredEmptySectionPlaceholderSubHead: "Clear the filter or change its conditions",
		FilteredEmptySectionPlaceholderTitle: "There are no records matching the filter criteria",
		EmptySectionPlaceholderSubHead: "Add a new record to make it look prettier",
		EmptySectionPlaceholderTitle: "The section has no records"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "List page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});