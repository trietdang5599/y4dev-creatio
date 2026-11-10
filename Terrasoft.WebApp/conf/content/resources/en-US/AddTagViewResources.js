define("AddTagViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageFilter: {
			source: 3,
			params: {
				schemaName: "AddTagView",
				resourceItemName: "ImageFilter",
				hash: "2dd8d6cde7d70211487db089bfd1613f",
				resourceItemExtension: ".png"
			}
		},
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "AddTagView",
				resourceItemName: "ApplyButtonImage",
				hash: "18e29d509e192058502f9a936a2dd85f",
				resourceItemExtension: ".png"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "AddTagView",
				resourceItemName: "CancelButtonImage",
				hash: "50670ba55c24903c8a285e68eebebdb0",
				resourceItemExtension: ".png"
			}
		},
		RemoveButtonImage: {
			source: 3,
			params: {
				schemaName: "AddTagView",
				resourceItemName: "RemoveButtonImage",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});