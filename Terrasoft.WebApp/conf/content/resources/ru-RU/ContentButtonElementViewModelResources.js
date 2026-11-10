define("ContentButtonElementViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Placeholder: "\u0414\u043E\u0431\u0430\u0432\u044C\u0442\u0435 \u0438\u0437\u043E\u0431\u0440\u0430\u0436\u0435\u043D\u0438\u0435",
		SetLinkInputBoxCaption: "\u0423\u043A\u0430\u0436\u0438\u0442\u0435 \u0430\u0434\u0440\u0435\u0441"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		UploadIcon: {
			source: 3,
			params: {
				schemaName: "ContentButtonElementViewModel",
				resourceItemName: "UploadIcon",
				hash: "5b77f0baff088fc67cfb77aeba8626d5",
				resourceItemExtension: ".svg"
			}
		},
		LinkIcon: {
			source: 3,
			params: {
				schemaName: "ContentButtonElementViewModel",
				resourceItemName: "LinkIcon",
				hash: "fc6346f465ad1a54e0b074011b92257a",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});