define("ContentImageElementViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Placeholder: "Add image",
		SetLinkInputBoxCaption: "Enter image URL",
		Caption: "Image"
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