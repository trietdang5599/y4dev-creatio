define("BaseProfileSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ClearButtonCaption: "Clear column",
		SetActionCaption: "Add relationship",
		AddRecordButtonCaption: "New",
		ErrorOnSaveMessage: "An error occurred while saving. Please contact your system administrator for more information.",
		SearchButtonCaption: "Search"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BlankSlateIcon: {
			source: 3,
			params: {
				schemaName: "BaseProfileSchema",
				resourceItemName: "BlankSlateIcon",
				hash: "b244cd3a4bd2e9740c3aa1480fd96a77",
				resourceItemExtension: ".png"
			}
		},
		ClearButton: {
			source: 3,
			params: {
				schemaName: "BaseProfileSchema",
				resourceItemName: "ClearButton",
				hash: "d8fd671de0a34cf0dfde9e8f690078b9",
				resourceItemExtension: ".png"
			}
		},
		ProfileIcon: {
			source: 3,
			params: {
				schemaName: "BaseProfileSchema",
				resourceItemName: "ProfileIcon",
				hash: "6985edb87f777607967eed9d8070db42",
				resourceItemExtension: ".jpg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});