define("ContentHTMLElementViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Placeholder: "Place for your html.",
		EditDataInputBoxCaption: "HTML edit"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ClearIcon: {
			source: 3,
			params: {
				schemaName: "ContentHTMLElementViewModel",
				resourceItemName: "ClearIcon",
				hash: "6218401a3e034e8242a2c8ddfe0ee47e",
				resourceItemExtension: ".png"
			}
		},
		EditIcon: {
			source: 3,
			params: {
				schemaName: "ContentHTMLElementViewModel",
				resourceItemName: "EditIcon",
				hash: "504c53444bc9269b355b7d0b8ddc31aa",
				resourceItemExtension: ".png"
			}
		},
		UploadIcon: {
			source: 3,
			params: {
				schemaName: "ContentHTMLElementViewModel",
				resourceItemName: "UploadIcon",
				hash: "31356dcb984379c4ab7eff49f6c7d16e",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});