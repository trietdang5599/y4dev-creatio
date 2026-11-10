define("SspBusinessRuleSectionResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		EmptyInfoImage: {
			source: 3,
			params: {
				schemaName: "SspBusinessRuleSection",
				resourceItemName: "EmptyInfoImage",
				hash: "f7367adb83003fc8600e74023d24be5c",
				resourceItemExtension: ".svg"
			}
		},
		InvalidBusinessRuleSectionImage: {
			source: 3,
			params: {
				schemaName: "SspBusinessRuleSection",
				resourceItemName: "InvalidBusinessRuleSectionImage",
				hash: "fe6489ee78ae1e42bf52ac05d4dfac7a",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});