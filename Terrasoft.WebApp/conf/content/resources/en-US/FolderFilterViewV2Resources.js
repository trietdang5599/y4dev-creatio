define("FolderFilterViewV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FolderFilterEmptyFolderEditPlaceHolder: "Folder",
		AddConditionMenuItemCaption: "Select folder",
		ShowAllGroupsMenuItemCaption: "Show all folders",
		FavoriteGroupMenuItemCaption: "FAVORITE FOLDERS",
		NewMenuItemCaption: "New",
		CustomersByPaymentMenuItemCaption: "Customers by payments",
		PartnersMenuItemCaption: "Partners"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		FolderImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterViewV2",
				resourceItemName: "FolderImage",
				hash: "3219a27bd21060a52ff1e6ec6cc36a3c",
				resourceItemExtension: ".png"
			}
		},
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterViewV2",
				resourceItemName: "ApplyButtonImage"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterViewV2",
				resourceItemName: "CancelButtonImage"
			}
		},
		ShowAllFoldersImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterViewV2",
				resourceItemName: "ShowAllFoldersImage",
				hash: "505ceaf6ac4b11c8b5c0a9ac5d9a663f",
				resourceItemExtension: ".png"
			}
		},
		SearchFolderImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterViewV2",
				resourceItemName: "SearchFolderImage",
				hash: "1ad3999ecac93ac3e2f0fdafc833c464",
				resourceItemExtension: ".png"
			}
		},
		GeneralFolderImage: {
			source: 3,
			params: {
				schemaName: "FolderFilterViewV2",
				resourceItemName: "GeneralFolderImage",
				hash: "d4494ec1f8bdddca9c982acb3b279523",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});