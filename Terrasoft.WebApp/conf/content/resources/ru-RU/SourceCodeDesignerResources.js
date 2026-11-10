define("SourceCodeDesignerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowFindWindowButtonHint: "\u041F\u043E\u0438\u0441\u043A",
		ShowWhitespacesButtonHint: "\u041E\u0442\u043E\u0431\u0440\u0430\u0437\u0438\u0442\u044C \u0432\u0441\u0435 \u0437\u043D\u0430\u043A\u0438"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SearchImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeDesigner",
				resourceItemName: "SearchImage",
				hash: "fe73ae684f4f0539db05ee2e4df062b7",
				resourceItemExtension: ".png"
			}
		},
		ShowWhitespacesImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeDesigner",
				resourceItemName: "ShowWhitespacesImage",
				hash: "fa880aac7a52f0c048a8926564622d10",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});