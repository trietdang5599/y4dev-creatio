define("SupportEmailHelperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SupportEmailBodyTemplate: "body=%0D%0A%0D%0ASite:  {0}%0D%0ACustomer ID: {1}%0D%0AProduct: {2}%0D%0AVersion:  {3}%0D%0ALocalization: {4}%0D%0APage: {5}",
		SupportSubject: "Question about"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});