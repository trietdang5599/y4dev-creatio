define("AnniversaryDetailResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "AnniversaryDetail",
				resourceItemName: "DeleteIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		DatePickerIcon: {
			source: 3,
			params: {
				schemaName: "AnniversaryDetail",
				resourceItemName: "DatePickerIcon",
				hash: "aec6a18f274f5cfa12c78d1369420cb0",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});