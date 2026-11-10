define("FolderManagerViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AllFoldersCaption: "\u0412\u0441\u0435",
		FavoriteFoldersCaption: "\u0418\u0437\u0431\u0440\u0430\u043D\u043D\u044B\u0435",
		OnDeleteWarning: "\u0412\u044B \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u0445\u043E\u0442\u0438\u0442\u0435 \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u0432\u044B\u0434\u0435\u043B\u0435\u043D\u043D\u044B\u0435 \u044D\u043B\u0435\u043C\u0435\u043D\u0442\u044B?",
		NewSearchFolderInputBoxCaption: "\u041D\u043E\u0432\u0430\u044F \u0433\u0440\u0443\u043F\u043F\u0430",
		NewGeneralFolderInputBoxCaption: "\u041D\u043E\u0432\u0430\u044F \u0441\u0442\u0430\u0442\u0438\u0447\u0435\u0441\u043A\u0430\u044F \u0433\u0440\u0443\u043F\u043F\u0430",
		AddToFavoriteMenuItemCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0432 \u0438\u0437\u0431\u0440\u0430\u043D\u043D\u044B\u0435",
		RemoveFromFavoriteMenuItemCaption: "\u0418\u0441\u043A\u043B\u044E\u0447\u0438\u0442\u044C \u0438\u0437 \u0438\u0437\u0431\u0440\u0430\u043D\u043D\u044B\u0445",
		GeneralFolderInputBoxCaption: "\u0421\u0442\u0430\u0442\u0438\u0447\u0435\u0441\u043A\u0430\u044F \u0433\u0440\u0443\u043F\u043F\u0430",
		SearchFolderInputBoxCaption: "\u0413\u0440\u0443\u043F\u043F\u0430"
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