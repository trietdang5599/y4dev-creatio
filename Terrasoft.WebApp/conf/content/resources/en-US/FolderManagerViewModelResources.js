define("FolderManagerViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AllFoldersCaption: "All",
		FavoriteFoldersCaption: "Favorites",
		OnDeleteWarning: "Are you sure that you want to delete the selected items?",
		NewSearchFolderInputBoxCaption: "New folder",
		NewGeneralFolderInputBoxCaption: "New static folder",
		AddToFavoriteMenuItemCaption: "Add to favorites",
		RemoveFromFavoriteMenuItemCaption: "Remove from favorites",
		GeneralFolderInputBoxCaption: "Static folder",
		SearchFolderInputBoxCaption: "Folder"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		RemoveFromFavorites: {
			source: 3,
			params: {
				schemaName: "FolderManagerViewModel",
				resourceItemName: "RemoveFromFavorites",
				hash: "8fb8093797943ff123c0a1125ab6555a",
				resourceItemExtension: ".png"
			}
		},
		AddToFavoritesImage: {
			source: 3,
			params: {
				schemaName: "FolderManagerViewModel",
				resourceItemName: "AddToFavoritesImage",
				hash: "ede4532a4edffc3220e52a55ebb19c06",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});