define("ContentBlockViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ContentBlockMove: {
			source: 3,
			params: {
				schemaName: "ContentBlockViewModel",
				resourceItemName: "ContentBlockMove",
				hash: "94ab689c520cb0e4ac5252da8a267911",
				resourceItemExtension: ".png"
			}
		},
		ContentBlockAdd: {
			source: 3,
			params: {
				schemaName: "ContentBlockViewModel",
				resourceItemName: "ContentBlockAdd",
				hash: "102bd8b55d95a4358c1961957e90ae58",
				resourceItemExtension: ".png"
			}
		},
		ContentBlockRemove: {
			source: 3,
			params: {
				schemaName: "ContentBlockViewModel",
				resourceItemName: "ContentBlockRemove",
				hash: "a92627f67f5663ce9b81412744c24300",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});