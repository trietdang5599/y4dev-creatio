define("SourceCodeDesignerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowFindWindowButtonHint: "Search",
		ShowWhitespacesButtonHint: "Show white space"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SearchImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeDesigner",
				resourceItemName: "SearchImage",
				hash: "fe73ae684f4f0539db05ee2e4df062b7",
				resourceItemExtension: ".png"
			}
		},
		ShowWhitespacesImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeDesigner",
				resourceItemName: "ShowWhitespacesImage",
				hash: "fa880aac7a52f0c048a8926564622d10",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});