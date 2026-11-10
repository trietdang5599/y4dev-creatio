define("StructureExploreModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		LookupColumnSelectError: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0437\u043D\u0430\u0447\u0435\u043D\u0438\u0435 \u0438\u0437 \u0441\u043F\u0440\u0430\u0432\u043E\u0447\u043D\u0438\u043A\u0430",
		ItemColumnSelectError: "\u0423\u043A\u0430\u0436\u0438\u0442\u0435 \u0437\u043D\u0430\u0447\u0435\u043D\u0438\u0435 \u0434\u043B\u044F \u0432\u044B\u0431\u0440\u0430\u043D\u043D\u043E\u0439 \u043A\u043E\u043B\u043E\u043D\u043A\u0438",
		CountDisplayValue: "\u041A\u043E\u043B\u0438\u0447\u0435\u0441\u0442\u0432\u043E(#Caption#)"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ExpandImage: {
			source: 3,
			params: {
				schemaName: "StructureExploreModule",
				resourceItemName: "ExpandImage",
				hash: "9b9a086a3b47892e36c4b2f5633dd2e3",
				resourceItemExtension: ".png"
			}
		},
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "StructureExploreModule",
				resourceItemName: "CloseIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});