define("SortingOrderControlsMixinResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SortingOrder2Caption: "Descending",
		SortingOrder1Caption: "Ascending",
		SortingOrder0Caption: "Disabled"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseButton: {
			source: 3,
			params: {
				schemaName: "SortingOrderControlsMixin",
				resourceItemName: "CloseButton",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});