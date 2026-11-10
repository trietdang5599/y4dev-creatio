define("DateTimeMappingPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SelectionDateTimeCaption: "Date and Time",
		SelectionDateCaption: "Date",
		SelectionTimeCaption: "Time",
		SelectionBaseCaption: "Selection:",
		SaveButtonCaption: "Select",
		CancelButtonCaption: "Cancel"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "DateTimeMappingPage",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});