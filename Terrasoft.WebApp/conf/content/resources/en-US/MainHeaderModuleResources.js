define("MainHeaderModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ProfileImageButtonHintCaption: "Profile",
		ProfileMenuItemCaption: "Your profile",
		ExitMenuItemCaption: "Exit",
		SystemDesignerCaption: "System designer",
		LogoHint: "Go to Main menu",
		SystemDesignerTip: "\u003Cspan class=\u0022tip-header\u0022\u003ESystem designer\u003C/span\u003E\u003Cbr\u003EOpens the administration and customization options\u003Cbr\u003E\u003Ca href=\u0022#\u0022 data-context-help-id=\u00221243\u0022 \u003ERead more\u003C/a\u003E\u003Cbr\u003E\u003Ca href=\u0022https://youtu.be/vBnvSmo1Dn8?list=PLnolcTT5TeE08u9GbWA7R29awrDDANt-5\u0022 target=\u0022_blank\u0022\u003EVideo tutorial\u003C/a\u003E"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ContactEmptyPhoto: {
			source: 3,
			params: {
				schemaName: "MainHeaderModule",
				resourceItemName: "ContactEmptyPhoto",
				hash: "4f510c4533e491fcafb195e9759dbbbb",
				resourceItemExtension: ".png"
			}
		},
		RemindingsIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderModule",
				resourceItemName: "RemindingsIcon",
				hash: "3ea0156e63905378b7fd1ac1e64ebee6",
				resourceItemExtension: ".png"
			}
		},
		Logo: {
			source: 3,
			params: {
				schemaName: "MainHeaderModule",
				resourceItemName: "Logo",
				hash: "bc1d40336aabccb8f0c407deea82c3a9",
				resourceItemExtension: ".png"
			}
		},
		YourProfileIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderModule",
				resourceItemName: "YourProfileIcon",
				hash: "d37bb092b1deaaf360581ffff32b5df7",
				resourceItemExtension: ".png"
			}
		},
		SystemDesignerIcon: {
			source: 3,
			params: {
				schemaName: "MainHeaderModule",
				resourceItemName: "SystemDesignerIcon",
				hash: "0992eb1590280f15047068feec5d71a7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});