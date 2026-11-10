define("SectionDesignerLogModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		HeaderCaption: "Compilation errors",
		CloseCaption: "Close",
		FileNameCaption: "File name",
		LineCaption: "String",
		ErrorTextCaption: "Error details"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "SectionDesignerLogModule",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});