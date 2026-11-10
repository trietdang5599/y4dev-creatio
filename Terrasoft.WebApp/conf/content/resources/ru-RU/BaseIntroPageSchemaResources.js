define("BaseIntroPageSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ButtonCaption: "\u041F\u0435\u0440\u0435\u0439\u0442\u0438",
		BannerCaption: "\u0410\u043A\u0430\u0434\u0435\u043C\u0438\u044F",
		BannerHint: "\u0432\u0438\u0434\u0435\u043E, \u0434\u043E\u043A\u0443\u043C\u0435\u043D\u0442\u0430\u0446\u0438\u044F, \u0442\u0435\u0441\u0442\u044B \u043F\u043E \u0441\u0438\u0441\u0442\u0435\u043C\u0435",
		MobileAppCaption: "\u041C\u043E\u0431\u0438\u043B\u044C\u043D\u0430\u044F \u0432\u0435\u0440\u0441\u0438\u044F",
		AndroidUrl: "https://play.google.com/store/apps/details?id=com.creatio.mobileapp",
		IosUrl: "https://itunes.apple.com/us/app/bpmonline-mobile-7/id708432450?mt=8",
		LinkedInUrl: "https://linkedin.bpmonline.com",
		GoogleUrl: "https://plus.google.com/u/0/116164135679912261451/posts",
		TwitterUrl: "https://twitter.bpmonline.com",
		FacebookUrl: "https://facebook.bpmonline.com",
		YoutubeUrl: "https://youtube.bpmonline.com",
		SdkCaption: "\u0420\u0443\u043A\u043E\u0432\u043E\u0434\u0441\u0442\u0432\u043E \u043F\u043E \u0440\u0430\u0437\u0440\u0430\u0431\u043E\u0442\u043A\u0435 \u043D\u0430 \u043F\u043B\u0430\u0442\u0444\u043E\u0440\u043C\u0435 Creatio",
		CommunityCaption: "\u041D\u0430\u0439\u0442\u0438 \u043E\u0442\u0432\u0435\u0442\u044B",
		CommunityUrl: "http://www.community.terrasoft.ru/",
		CommunityLabel: "\u0421\u043E\u043E\u0431\u0449\u0435\u0441\u0442\u0432\u043E",
		WindowsUrl: "",
		SocialAccountsCaption: "\u0421\u0432\u044F\u0436\u0438\u0442\u0435\u0441\u044C \u0441 \u043D\u0430\u043C\u0438",
		AndroidLabel: "Google play",
		IosLabel: "App Store",
		WindowsLabel: "",
		AcademyCaption: "\u0412\u0438\u0434\u0435\u043E\u043A\u0443\u0440\u0441\u044B. \u0422\u0440\u0435\u043D\u0438\u043D\u0433\u0438. \u0422\u0435\u0441\u0442\u0438\u0440\u043E\u0432\u0430\u043D\u0438\u044F",
		MarketplaceCaption: "\u041A\u0430\u0442\u0430\u043B\u043E\u0433 \u0440\u0430\u0441\u0448\u0438\u0440\u0435\u043D\u0438\u0439 \u0438 \u0431\u0438\u0437\u043D\u0435\u0441-\u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432",
		MarketplaceUrl: "https://marketplace.terrasoft.ru/",
		MarketplaceLabel: "\u041C\u0430\u0440\u043A\u0435\u0442\u043F\u043B\u0435\u0439\u0441"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		TwitterIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "TwitterIcon",
				hash: "43ef41cba1450cadf1eb65f93a7b0d25",
				resourceItemExtension: ".svg"
			}
		},
		FacebookIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "FacebookIcon",
				hash: "27130fdf43a9e78bf3f36e626a3e1781",
				resourceItemExtension: ".svg"
			}
		},
		GoogleIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "GoogleIcon",
				hash: "b2c07233caac08d4f65769e921a4d232",
				resourceItemExtension: ".svg"
			}
		},
		YoutubeIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "YoutubeIcon",
				hash: "16f3900d772354c3ce0af6c68f0c5226",
				resourceItemExtension: ".svg"
			}
		},
		LinkedinIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "LinkedinIcon",
				hash: "76b4011e0b60d2e1c264706026ba938f",
				resourceItemExtension: ".svg"
			}
		},
		AcademyBanner: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "AcademyBanner",
				hash: "d20c340712aea48adc656782fb3492a0",
				resourceItemExtension: ".svg"
			}
		},
		Arrow: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "Arrow",
				hash: "c0d0aa169329d87d6266a5f96a48b1a3",
				resourceItemExtension: ".png"
			}
		},
		playBtn: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "playBtn",
				hash: "c711cfac383baf15e71dc80c28dc1e35",
				resourceItemExtension: ".png"
			}
		},
		playBtnActive: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "playBtnActive",
				hash: "96ae802491edb2fd144a503a859a4eb8",
				resourceItemExtension: ".png"
			}
		},
		AndroidIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "AndroidIcon",
				hash: "385d1b4f9e6d5d385239801b140a8c09",
				resourceItemExtension: ".svg"
			}
		},
		IosIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "IosIcon",
				hash: "83443f1c07e583d16de6a799b8a8dd54",
				resourceItemExtension: ".svg"
			}
		},
		CommunityIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "CommunityIcon",
				hash: "51369be2d145e1cc23b93799e6af99ad",
				resourceItemExtension: ".svg"
			}
		},
		WindowsIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "WindowsIcon"
			}
		},
		MarketplaceIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "MarketplaceIcon",
				hash: "79bf31568c3cc50782a3860592d58825",
				resourceItemExtension: ".svg"
			}
		},
		SdkIcon: {
			source: 3,
			params: {
				schemaName: "BaseIntroPageSchema",
				resourceItemName: "SdkIcon",
				hash: "6b55d73e8805d47ab6c202ae2691010a",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});