define("ProcessSchemaParameterViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		InavalidMappingColumn: "",
		CollapseControl: "Hide nested parameters",
		ExpandControl: "Show nested parameters"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ParameterEditToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessSchemaParameterViewModel",
				resourceItemName: "ParameterEditToolsButtonImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});