define("ContentImageElementViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Placeholder: "\u0414\u043E\u0431\u0430\u0432\u044C\u0442\u0435 \u0438\u0437\u043E\u0431\u0440\u0430\u0436\u0435\u043D\u0438\u0435",
		SetLinkInputBoxCaption: "\u0423\u043A\u0430\u0436\u0438\u0442\u0435 \u0430\u0434\u0440\u0435\u0441",
		Caption: "\u041A\u0430\u0440\u0442\u0438\u043D\u043A\u0430"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		UploadIcon: {
			source: 3,
			params: {
				schemaName: "ContentImageElementViewModel",
				resourceItemName: "UploadIcon",
				hash: "31356dcb984379c4ab7eff49f6c7d16e",
				resourceItemExtension: ".png"
			}
		},
		LinkIcon: {
			source: 3,
			params: {
				schemaName: "ContentImageElementViewModel",
				resourceItemName: "LinkIcon",
				hash: "de358ef22a38c7e1a6e0307cc56628f5",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});