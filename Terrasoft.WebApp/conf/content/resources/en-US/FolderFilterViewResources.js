define("FolderFilterViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FolderFilterEmptyFolderEditPlaceHolder: "Folder",
		AddConditionMenuItemCaption: "Select folder"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		FolderImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterView",
				resourceItemName: "FolderImage",
				hash: "3219a27bd21060a52ff1e6ec6cc36a3c",
				resourceItemExtension: ".png"
			}
		},
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterView",
				resourceItemName: "ApplyButtonImage",
				hash: "18e29d509e192058502f9a936a2dd85f",
				resourceItemExtension: ".png"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterView",
				resourceItemName: "CancelButtonImage",
				hash: "50670ba55c24903c8a285e68eebebdb0",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});