define("StructureExploreModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		LookupColumnSelectError: "Select lookup value",
		ItemColumnSelectError: "Specify value for selected column",
		CountDisplayValue: "Quantity(#Caption#)"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ExpandImage: {
			source: 3,
			params: {
				schemaName: "StructureExploreModule",
				resourceItemName: "ExpandImage",
				hash: "9b9a086a3b47892e36c4b2f5633dd2e3",
				resourceItemExtension: ".png"
			}
		},
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "StructureExploreModule",
				resourceItemName: "CloseIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});