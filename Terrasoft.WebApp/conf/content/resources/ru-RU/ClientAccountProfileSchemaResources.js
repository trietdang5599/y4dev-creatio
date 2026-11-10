define("ClientAccountProfileSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ProfileHeaderCaption: "\u041A\u043B\u0438\u0435\u043D\u0442"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BlankSlateIcon: {
			source: 3,
			params: {
				schemaName: "ClientAccountProfileSchema",
				resourceItemName: "BlankSlateIcon",
				hash: "1d9a0f56594f86dfe103ac4fec80c534",
				resourceItemExtension: ".svg"
			}
		},
		ClearButton: {
			source: 3,
			params: {
				schemaName: "ClientAccountProfileSchema",
				resourceItemName: "ClearButton",
				hash: "d8fd671de0a34cf0dfde9e8f690078b9",
				resourceItemExtension: ".png"
			}
		},
		ProfileIcon: {
			source: 3,
			params: {
				schemaName: "ClientAccountProfileSchema",
				resourceItemName: "ProfileIcon",
				hash: "1d9a0f56594f86dfe103ac4fec80c534",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});