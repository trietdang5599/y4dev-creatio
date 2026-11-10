define("ClientProfileSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Client: "Customer",
		WarningMessage: "Customer field has contact and account"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BlankSlateIcon: {
			source: 3,
			params: {
				schemaName: "ClientProfileSchema",
				resourceItemName: "BlankSlateIcon",
				hash: "369d63a19da2554e643df227d9995539",
				resourceItemExtension: ".svg"
			}
		},
		ClearButton: {
			source: 3,
			params: {
				schemaName: "ClientProfileSchema",
				resourceItemName: "ClearButton",
				hash: "d8fd671de0a34cf0dfde9e8f690078b9",
				resourceItemExtension: ".png"
			}
		},
		WarningIcon: {
			source: 3,
			params: {
				schemaName: "ClientProfileSchema",
				resourceItemName: "WarningIcon",
				hash: "c85c45255218f55d5b7e9a332d215c14",
				resourceItemExtension: ".png"
			}
		},
		ProfileIcon: {
			source: 3,
			params: {
				schemaName: "ClientProfileSchema",
				resourceItemName: "ProfileIcon",
				hash: "369d63a19da2554e643df227d9995539",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});