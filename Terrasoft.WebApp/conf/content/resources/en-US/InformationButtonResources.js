define("InformationButtonResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "InformationButton",
				resourceItemName: "DefaultIcon",
				hash: "21a6ca27805264700476d72b58d42525",
				resourceItemExtension: ".png"
			}
		},
		WarningIcon: {
			source: 3,
			params: {
				schemaName: "InformationButton",
				resourceItemName: "WarningIcon",
				hash: "cd424fcb51b7c567400ca4a26b94e2b9",
				resourceItemExtension: ".png"
			}
		},
		AttentionIcon: {
			source: 3,
			params: {
				schemaName: "InformationButton",
				resourceItemName: "AttentionIcon",
				hash: "1d54166ddf6f2976880ab158ba1142e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});