define("MobileBaseDesignerModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ConfigureControlGroupButtonCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C",
		RemoveControlGroupButtonCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		AddGridLayoutItemButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u043A\u043E\u043B\u043E\u043D\u043A\u0443",
		RemoveGridLayoutItemButtonCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C \u043A\u043E\u043B\u043E\u043D\u043A\u0443"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		MoveUpButtonImage: {
			source: 3,
			params: {
				schemaName: "MobileBaseDesignerModule",
				resourceItemName: "MoveUpButtonImage",
				hash: "0f8171507e8b8f7929e7fb06d10df336",
				resourceItemExtension: ".png"
			}
		},
		MoveDownButtonImage: {
			source: 3,
			params: {
				schemaName: "MobileBaseDesignerModule",
				resourceItemName: "MoveDownButtonImage",
				hash: "0b9bc9c60af93a1bb791892cc1048367",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});