define("MainMenuResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SettingsButtonCatpion: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438",
		ProfileButtonCatpion: "\u041F\u0440\u043E\u0444\u0438\u043B\u044C",
		ExitButtonCaption: "\u0412\u044B\u0445\u043E\u0434",
		JournalProcessesButtonCatpion: "\u0416\u0443\u0440\u043D\u0430\u043B \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432",
		ConfigurationSettingsMenuCaption: "\u0423\u043F\u0440\u0430\u0432\u043B\u0435\u043D\u0438\u0435 \u043A\u043E\u043D\u0444\u0438\u0433\u0443\u0440\u0430\u0446\u0438\u0435\u0439",
		WorkplaceSettingsMenuCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u0440\u0430\u0431\u043E\u0447\u0438\u0445 \u043C\u0435\u0441\u0442",
		ExternalFormsSettingsMenuCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u0444\u043E\u0440\u043C \u0432\u043D\u0435\u0448\u043D\u0438\u0445 \u0440\u0435\u0441\u0443\u0440\u0441\u043E\u0432",
		SysOperationAuditSectionMenuCaption: "\u0416\u0443\u0440\u043D\u0430\u043B \u0430\u0443\u0434\u0438\u0442\u0430",
		SectionDesignerMenuItemCaption: "\u0421\u043E\u0437\u0434\u0430\u0442\u044C \u043D\u043E\u0432\u044B\u0439 \u0440\u0430\u0437\u0434\u0435\u043B",
		SysProcessLogSectionMenuCaption: "\u0416\u0443\u0440\u043D\u0430\u043B \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SettingsIcon: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "SettingsIcon",
				hash: "ccc404d136d73edb907a333daafd9184",
				resourceItemExtension: ".png"
			}
		},
		ProfileIcon: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "ProfileIcon",
				hash: "e3f52eaeb5006161a315564d21985c4e",
				resourceItemExtension: ".png"
			}
		},
		Logo: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "Logo",
				hash: "b1e3109969481938f5eb3d283823c343",
				resourceItemExtension: ".png"
			}
		},
		ExitIcon: {
			source: 3,
			params: {
				schemaName: "MainMenu",
				resourceItemName: "ExitIcon",
				hash: "6578427df816ae8ca009f5286cdddd70",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});