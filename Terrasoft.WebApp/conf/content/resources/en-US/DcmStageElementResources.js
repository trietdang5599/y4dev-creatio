define("DcmStageElementResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Remove: {
			source: 3,
			params: {
				schemaName: "DcmStageElement",
				resourceItemName: "Remove",
				hash: "565e0172f3355da8942e8a0a754a1032",
				resourceItemExtension: ".svg"
			}
		},
		RemoveNotValid: {
			source: 3,
			params: {
				schemaName: "DcmStageElement",
				resourceItemName: "RemoveNotValid"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});