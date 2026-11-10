define("ContentHTMLElementViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Placeholder: "\u0417\u0434\u0435\u0441\u044C \u043C\u043E\u0433 \u0431\u044B \u0431\u044B\u0442\u044C \u0432\u0430\u0448 html.",
		EditDataInputBoxCaption: "\u0420\u0435\u0434\u0430\u043A\u0442\u0438\u0440\u043E\u0432\u0430\u043D\u0438\u0435 HTML"
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