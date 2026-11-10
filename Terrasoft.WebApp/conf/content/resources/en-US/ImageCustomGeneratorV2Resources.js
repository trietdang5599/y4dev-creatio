define("ImageCustomGeneratorV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ImageUploadButtonHint: "Add picture",
		ImageClearButtonHint: "Delete picture"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultImage: {
			source: 3,
			params: {
				schemaName: "ImageCustomGeneratorV2",
				resourceItemName: "DefaultImage",
				hash: "6985edb87f777607967eed9d8070db42",
				resourceItemExtension: ".jpg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});