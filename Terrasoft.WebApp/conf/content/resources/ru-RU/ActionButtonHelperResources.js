define("ActionButtonHelperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		RedButtonImage: {
			source: 3,
			params: {
				schemaName: "ActionButtonHelper",
				resourceItemName: "RedButtonImage",
				hash: "84e0d956001c5c948ab5273033dfe1f7",
				resourceItemExtension: ".png"
			}
		},
		GreenButtonImage: {
			source: 3,
			params: {
				schemaName: "ActionButtonHelper",
				resourceItemName: "GreenButtonImage",
				hash: "bf1e1dd86f7e996c5d3f609619279231",
				resourceItemExtension: ".png"
			}
		},
		GreyButtonImage: {
			source: 3,
			params: {
				schemaName: "ActionButtonHelper",
				resourceItemName: "GreyButtonImage",
				hash: "51587299689e6221ec963e30b8ba37f2",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});