define("ProcessRemindModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OKCaption: "\u041E\u041A",
		CancelCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		StepsCaption: "\u041F\u043E \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u0443 \u0441\u043E\u0437\u0434\u0430\u043D\u044B \u043D\u043E\u0432\u044B\u0435 \u0448\u0430\u0433\u0438"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		HideIcon: {
			source: 3,
			params: {
				schemaName: "ProcessRemindModule",
				resourceItemName: "HideIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		ArrowBlue: {
			source: 3,
			params: {
				schemaName: "ProcessRemindModule",
				resourceItemName: "ArrowBlue",
				hash: "3d86909d175e70a32dc0f8f1b3a7f9a3",
				resourceItemExtension: ".png"
			}
		},
		ArrowGray: {
			source: 3,
			params: {
				schemaName: "ProcessRemindModule",
				resourceItemName: "ArrowGray",
				hash: "41b59562bc80c1a2aa1ce6e257552f07",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});