define("EditDetailViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		LoadButtonCaption: "\u0417\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C \u0435\u0449\u0451",
		RemoveButtonCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "EditDetailViewGenerator",
				resourceItemName: "DeleteIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});