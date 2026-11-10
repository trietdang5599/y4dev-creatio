define("MainHeaderSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DefaultPageHeaderCaption: "\u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		ProfileImageButtonHintCaption: "\u041F\u0440\u043E\u0444\u0438\u043B\u044C",
		ProfileMenuItemCaption: "\u0412\u0430\u0448 \u043F\u0440\u043E\u0444\u0438\u043B\u044C",
		ExitMenuItemCaption: "\u0412\u044B\u0445\u043E\u0434",
		SystemDesignerCaption: "\u0414\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u0441\u0438\u0441\u0442\u0435\u043C\u044B",
		LogoHint: "\u041F\u0435\u0440\u0435\u0439\u0442\u0438 \u043A \u0433\u043B\u0430\u0432\u043D\u043E\u043C\u0443 \u043C\u0435\u043D\u044E",
		SystemDesignerTip: "\u003Cspan class=\u0022tip-header\u0022\u003E\u0414\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u0441\u0438\u0441\u0442\u0435\u043C\u044B\u003C/span\u003E\u003Cbr\u003E\u041E\u0442\u043A\u0440\u043E\u0439\u0442\u0435 \u043C\u0435\u043D\u044E \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438 \u0441\u0438\u0441\u0442\u0435\u043C\u044B\u003Cbr\u003E\u003Ca href=\u0022#\u0022 data-context-help-id=\u00221243\u0022 \u003E\u041F\u043E\u0434\u0440\u043E\u0431\u043D\u0435\u0435\u003C/a\u003E\u003Cbr\u003E\u003Ca href=\u0022https://www.youtube.com/watch?v=mVB3fED4v6g\u0026index=25\u0026list=PLDp-M9ZGnvgH5uPrXsjxblaSWMmQ17Xt9\u0022 target=\u0022_blank\u0022\u003E\u0412\u0438\u0434\u0435\u043E: \u0414\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u0441\u0438\u0441\u0442\u0435\u043C\u044B Creatio\u003C/a\u003E",
		DevButtonCaption: "\u041A\u043E\u043D\u0444\u0438\u0433\u0443\u0440\u0430\u0446\u0438\u044F",
		TelephonyMenuSeparator: "\u0422\u0435\u043B\u0435\u0444\u043E\u043D\u0438\u044F",
		ChatMenuSeparator: "\u0427\u0430\u0442",
		CompanyProfileCaption: "\u041F\u0440\u043E\u0444\u0438\u043B\u044C \u043E\u0440\u0433\u0430\u043D\u0438\u0437\u0430\u0446\u0438\u0438",
		ExtendedUserProfileCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438",
		SspProfileCaption: "\u041F\u0440\u043E\u0444\u0438\u043B\u044C",
		OpenSystemDesignerCaption: "\u041E\u0442\u043A\u0440\u044B\u0442\u044C \u0434\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u0441\u0438\u0441\u0442\u0435\u043C\u044B",
		EditPageCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443",
		CannotEditPageMessage: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u043D\u0435\u0434\u043E\u0441\u0442\u0443\u043F\u043D\u0430 \u0434\u043B\u044F \u0440\u0435\u0434\u0430\u043A\u0442\u0438\u0440\u043E\u0432\u0430\u043D\u0438\u044F. \u0412\u044B \u043C\u043E\u0436\u0435\u0442\u0435 \u043E\u0442\u0440\u0435\u0434\u0430\u043A\u0442\u0438\u0440\u043E\u0432\u0430\u0442\u044C \u0442\u043E\u043B\u044C\u043A\u043E \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B, \u0441\u043E\u0437\u0434\u0430\u043D\u043D\u044B\u0435 \u0432 \u0434\u0438\u0437\u0430\u0439\u043D\u0435\u0440\u0435 \u0441\u0442\u0440\u0430\u043D\u0438\u0446. \u0427\u0442\u043E\u0431\u044B \u0438\u0437\u043C\u0435\u043D\u0438\u0442\u044C \u0434\u043E\u043C\u0430\u0448\u043D\u044E\u044E \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443 \u0438\u043B\u0438 \u0434\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u043D\u043E\u0432\u0443\u044E, \u043F\u0435\u0440\u0435\u0439\u0434\u0438\u0442\u0435 \u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0435 \u0440\u0430\u0431\u043E\u0447\u0435\u0433\u043E \u043C\u0435\u0441\u0442\u0430.",
		RedirectToWorkplaceCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u0440\u0430\u0431\u043E\u0447\u0435\u0433\u043E \u043C\u0435\u0441\u0442\u0430",
		SystemDesignerMenuButtonHint: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438",
		OpenApplicationHubCaption: "\u0426\u0435\u043D\u0442\u0440 \u043F\u0440\u0438\u043B\u043E\u0436\u0435\u043D\u0438\u0439",
		ShellButtonCaption: "\u041E\u0431\u043E\u043B\u043E\u0447\u043A\u0430"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ContactEmptyPhoto: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "ContactEmptyPhoto",
				hash: "fb0d25738f0b8bf5af60435713520d3d",
				resourceItemExtension: ".svg"
			}
		},
		RemindingsIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "RemindingsIcon",
				hash: "3ea0156e63905378b7fd1ac1e64ebee6",
				resourceItemExtension: ".png"
			}
		},
		Logo: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "Logo",
				hash: "bdb66e5c2bb53a77d88ddc91741b68be",
				resourceItemExtension: ".svg"
			}
		},
		YourProfileIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "YourProfileIcon",
				hash: "d37bb092b1deaaf360581ffff32b5df7",
				resourceItemExtension: ".png"
			}
		},
		SystemDesignerIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "SystemDesignerIcon",
				hash: "d0bbeb5f9c29014630af81fdced84933",
				resourceItemExtension: ".svg"
			}
		},
		DevButtonIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "DevButtonIcon",
				hash: "8cb031c7803ebece8ddb11809deb24c7",
				resourceItemExtension: ".svg"
			}
		},
		CompanyProfileIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "CompanyProfileIcon",
				hash: "29343db3ee97c7ae993ac2b35f7696d9",
				resourceItemExtension: ".svg"
			}
		},
		UserSettingsIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "UserSettingsIcon",
				hash: "2fe81015a1b597e0f790b189adf84ab5",
				resourceItemExtension: ".svg"
			}
		},
		SspProfileIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "SspProfileIcon",
				hash: "98e527eabf36435c0a614541dc97159d",
				resourceItemExtension: ".svg"
			}
		},
		SspExitButton: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "SspExitButton",
				hash: "0cd019cab8755e23b3099ba3cd1f7979",
				resourceItemExtension: ".svg"
			}
		},
		NewIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "NewIcon",
				hash: "07d32537d2b32cb8d5ce2361fee826df",
				resourceItemExtension: ".svg"
			}
		},
		ShellButtonIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderSchema",
				resourceItemName: "ShellButtonIcon",
				hash: "4b71381bb7f0dfbbc75d883371beae09",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});