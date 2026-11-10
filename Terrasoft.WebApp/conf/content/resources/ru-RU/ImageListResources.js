define("ImageListResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "ImageList",
				resourceItemName: "CloseIcon",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "ImageList",
				resourceItemName: "DefaultIcon",
				hash: "c4cfa03b4fb5255fa0aa352546141efe",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});