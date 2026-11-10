define("DcmMappingPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ElementParametersMappingCaption: "Case parameters"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "DcmMappingPage",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});