define("MobileDetailDesignerModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddDetailButtonCaption: "New detail",
		AddDetailLabelCaption: "Add detail",
		ConfigureControlGroupButtonCaption: "Set",
		RemoveControlGroupButtonCaption: "Delete",
		AddGridLayoutItemButtonCaption: "New column",
		RemoveGridLayoutItemButtonCaption: "Delete column"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		MoveUpButtonImage: {
			source: 3,
			params: {
				schemaName: "MobileDetailDesignerModule",
				resourceItemName: "MoveUpButtonImage",
				hash: "0f8171507e8b8f7929e7fb06d10df336",
				resourceItemExtension: ".png"
			}
		},
		MoveDownButtonImage: {
			source: 3,
			params: {
				schemaName: "MobileDetailDesignerModule",
				resourceItemName: "MoveDownButtonImage",
				hash: "0b9bc9c60af93a1bb791892cc1048367",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});