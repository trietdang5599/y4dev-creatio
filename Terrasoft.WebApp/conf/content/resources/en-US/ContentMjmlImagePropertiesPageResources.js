define("ContentMjmlImagePropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ImageSettingsGroupCaption: "Image settings",
		SizeGroupCaption: "Size, px",
		ImageAlign: "Align",
		ImageAltText: "Alternative text",
		ImageEmbedded: "Image embedded",
		ImageHeight: "Height",
		ImageHrefLabel: "Link to open",
		ImageOptionsLabel: "Image options",
		ImageTitleText: "Title",
		ImageUrlPlaceholder: "Enter URL or select file",
		ImageWidth: "Width",
		PlaceholderAutoText: "Auto",
		SelectContentItem: "Select the template block to adjust its settings",
		UseMobileImage: "Use other image on mobile"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		UploadBackgroundImage: {
			source: 3,
			params: {
				schemaName: "ContentMjmlImagePropertiesPage",
				resourceItemName: "UploadBackgroundImage",
				hash: "dcd3df539a2fbc8a0545cb83c85329f5",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});