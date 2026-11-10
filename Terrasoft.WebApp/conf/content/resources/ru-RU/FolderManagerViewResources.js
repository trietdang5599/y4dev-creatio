define("FolderManagerViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FolderMenuSeparatorCaption: "\u0413\u0420\u0423\u041F\u041F\u0410",
		CreateStaticMenuItemCaption: "\u0421\u043E\u0437\u0434\u0430\u0442\u044C \u0441\u0442\u0430\u0442\u0438\u0447\u0435\u0441\u043A\u0443\u044E",
		CreateDynamicMenuItemCaption: "\u0421\u043E\u0437\u0434\u0430\u0442\u044C \u0434\u0438\u043D\u0430\u043C\u0438\u0447\u0435\u0441\u043A\u0443\u044E",
		CopyMenuItemCaption: "\u0421\u043A\u043E\u043F\u0438\u0440\u043E\u0432\u0430\u0442\u044C",
		RenameMenuItemCaption: "\u041F\u0435\u0440\u0435\u0438\u043C\u0435\u043D\u043E\u0432\u0430\u0442\u044C",
		DeleteMenuItemCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		MoveMenuItemCaption: "\u041F\u0435\u0440\u0435\u043C\u0435\u0441\u0442\u0438\u0442\u044C",
		EditRightsMenuItemCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043F\u0440\u0430\u0432",
		FoldersHeaderCaption: "\u0413\u0440\u0443\u043F\u043F\u044B",
		SelectFolderMenuItemCaption: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u0433\u0440\u0443\u043F\u043F\u0443",
		SelectFoldersMenuItemCaption: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u043D\u0435\u0441\u043A\u043E\u043B\u044C\u043A\u043E \u0433\u0440\u0443\u043F\u043F",
		ActionButtonCaption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		EditFolderFilters: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0444\u0438\u043B\u044C\u0442\u0440",
		CloseButtonCaption: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		FavouritesButtonHint: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0432 \u0438\u0437\u0431\u0440\u0430\u043D\u043D\u044B\u0435",
		ConfigurationButton: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		CloseButtonHint: "\u0421\u043A\u0440\u044B\u0442\u044C \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438 \u0433\u0440\u0443\u043F\u043F\u044B"
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