define("BackgroundPropertyModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		BackgroundImageUrlPlaceholder: "Enter URL",
		ImageEmbedded: "Image embedded",
		BackgroundVerticalAlign: "Vertical",
		BackgroundHorizontalAlign: "Horizontal"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		UploadBackgroundImage: {
			source: 3,
			params: {
				schemaName: "BackgroundPropertyModule",
				resourceItemName: "UploadBackgroundImage",
				hash: "da75d6ef5ad6358e274fc9acc115bded",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});