define("FolderManagerViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FolderMenuSeparatorCaption: "FOLDER",
		CreateStaticMenuItemCaption: "New static folder",
		CreateDynamicMenuItemCaption: "New dynamic folder",
		CopyMenuItemCaption: "Copy",
		RenameMenuItemCaption: "Rename",
		DeleteMenuItemCaption: "Delete",
		MoveMenuItemCaption: "Move",
		EditRightsMenuItemCaption: "Set up access rights",
		FoldersHeaderCaption: "Folders",
		SelectFolderMenuItemCaption: "Select folder",
		SelectFoldersMenuItemCaption: "Select multiple folders",
		ActionButtonCaption: "Actions",
		EditFolderFilters: "Set up filter",
		CloseButtonCaption: "Close",
		FavouritesButtonHint: "Add to favourites",
		ConfigurationButton: "Actions",
		CloseButtonHint: "Close folder setup"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ClosePanelImage: {
			source: 3,
			params: {
				schemaName: "FolderManagerView",
				resourceItemName: "ClosePanelImage",
				hash: "3ff0663bcbd7695a2c1dfe52af4e63bc",
				resourceItemExtension: ".svg"
			}
		},
		FastFilterImage: {
			source: 3,
			params: {
				schemaName: "FolderManagerView",
				resourceItemName: "FastFilterImage",
				hash: "31008ddc17213272bf4d110a36d0153d",
				resourceItemExtension: ".png"
			}
		},
		SettingsImage: {
			source: 3,
			params: {
				schemaName: "FolderManagerView",
				resourceItemName: "SettingsImage",
				hash: "47746d40580dfbb675744525fc2e03b1",
				resourceItemExtension: ".svg"
			}
		},
		AddToFavoritesImage: {
			source: 3,
			params: {
				schemaName: "FolderManagerView",
				resourceItemName: "AddToFavoritesImage",
				hash: "54b2337f4191281125d3b9d675c6a371",
				resourceItemExtension: ".svg"
			}
		},
		RemoveFromFavorites: {
			source: 3,
			params: {
				schemaName: "FolderManagerView",
				resourceItemName: "RemoveFromFavorites",
				hash: "ef3bc70aba9f628cd98a4678aad25d9a",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});