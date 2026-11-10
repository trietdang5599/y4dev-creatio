define("ProcessSchemaParameterViewConfigResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MappingPlaceholderCaption: "Select value",
		AddNesstedParameterCaption: "Add nested parameter"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessSchemaParameterViewConfig",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});