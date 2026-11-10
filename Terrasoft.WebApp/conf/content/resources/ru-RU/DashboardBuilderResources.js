define("DashboardBuilderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Caption: "\u0418\u0442\u043E\u0433\u0438",
		ToolsCaption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		AddButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		EditButtonCaption: "\u0418\u0437\u043C\u0435\u043D\u0438\u0442\u044C",
		DeleteButtonCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		RightsButtonCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043F\u0440\u0430\u0432\u0430 \u0434\u043E\u0441\u0442\u0443\u043F\u0430",
		DeleteConfirmationMessage: "\u0412\u044B \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u0445\u043E\u0442\u0438\u0442\u0435 \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u0432\u044B\u0431\u0440\u0430\u043D\u043D\u0443\u044E \u043F\u0430\u043D\u0435\u043B\u044C \u0438\u0442\u043E\u0433\u043E\u0432?",
		NotEnoughRightsMessage: "\u041D\u0435\u0434\u043E\u0441\u0442\u0430\u0442\u043E\u0447\u043D\u043E \u043F\u0440\u0430\u0432 \u0434\u043B\u044F \u0432\u044B\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u044F \u044D\u0442\u043E\u0439 \u043E\u043F\u0435\u0440\u0430\u0446\u0438\u0438",
		NoDashboardsAvailable: "\u0412 \u0441\u0438\u0441\u0442\u0435\u043C\u0435 \u043D\u0435\u0442 \u0434\u043E\u0441\u0442\u0443\u043F\u043D\u044B\u0445 \u0432\u0430\u043C \u0438\u0442\u043E\u0433\u043E\u0432",
		CopyButtonCaption: "\u041A\u043E\u043F\u0438\u0440\u043E\u0432\u0430\u0442\u044C",
		SettingsButtonHint: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		TabControlScrollLeftHint: "\u0412\u043B\u0435\u0432\u043E",
		TabControlScrollRightHint: "\u0412\u043F\u0440\u0430\u0432\u043E",
		ScreenshotButtonCaption: "\u0421\u043A\u0440\u0438\u043D\u0448\u043E\u0442",
		SearchDashboardButtonHint: "\u041F\u043E\u0438\u0441\u043A \u0432\u043A\u043B\u0430\u0434\u043E\u043A"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Settings: {
			source: 3,
			params: {
				schemaName: "DashboardBuilder",
				resourceItemName: "Settings",
				hash: "a8bd9c465829019c84dc848375c6ce93",
				resourceItemExtension: ".png"
			}
		},
		SearchDashboard: {
			source: 3,
			params: {
				schemaName: "DashboardBuilder",
				resourceItemName: "SearchDashboard",
				hash: "0c97ee376ddf8f0a250b7df3d0788458",
				resourceItemExtension: ".svg"
			}
		},
		Favorite: {
			source: 3,
			params: {
				schemaName: "DashboardBuilder",
				resourceItemName: "Favorite",
				hash: "ff535b8ccd4680fcfddc4b0b2347a2b6",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});