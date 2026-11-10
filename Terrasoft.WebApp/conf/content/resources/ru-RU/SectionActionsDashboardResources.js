define("SectionActionsDashboardResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SendToChatContactErrorMessage: "\u041D\u0435\u0432\u043E\u0437\u043C\u043E\u0436\u043D\u043E \u043E\u0442\u043F\u0440\u0430\u0432\u0438\u0442\u044C \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435 \u0432\u044B\u0431\u0440\u0430\u043D\u043D\u043E\u043C\u0443 \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u0443",
		NoContactsForChatMessage: "\u041D\u0435\u0442 \u0441\u0432\u044F\u0437\u0430\u043D\u043D\u044B\u0445 \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u043E\u0432",
		NoContactForChatMessage: "\u041D\u0435\u0442 \u0441\u0432\u044F\u0437\u0430\u043D\u043D\u043E\u0433\u043E \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u0430",
		ActualDcmSchemaInformationButtonCaption: "\u041D\u0430\u0439\u0434\u0435\u043D \u0431\u043E\u043B\u0435\u0435 \u043F\u043E\u0434\u0445\u043E\u0434\u044F\u0449\u0438\u0439 \u043A\u0435\u0439\u0441 \u043F\u043E \u0443\u0441\u043B\u043E\u0432\u0438\u044E \u0437\u0430\u043F\u0443\u0441\u043A\u0430. \u003Ca href=\u0022#\u0022\u003E\u0417\u0430\u043F\u0443\u0441\u0442\u0438\u0442\u044C...\u003C/a\u003E",
		ActualDcmSchemaVersionInformationButtonCaption: "\u041D\u0430\u0439\u0434\u0435\u043D\u0430 \u0434\u0440\u0443\u0433\u0430\u044F \u0430\u043A\u0442\u0443\u0430\u043B\u044C\u043D\u0430\u044F \u0432\u0435\u0440\u0441\u0438\u044F \u043A\u0435\u0439\u0441\u0430. \u003Ca href=\u0022#\u0022\u003E\u0417\u0430\u043F\u0443\u0441\u0442\u0438\u0442\u044C...\u003C/a\u003E",
		BlankSlateDescription: "\u0423 \u0432\u0430\u0441 \u0435\u0449\u0435 \u043D\u0435\u0442 \u0437\u0430\u0434\u0430\u0447\u003Cp\u003E\u041D\u0430\u0436\u043C\u0438\u0442\u0435 \u003Cimg src=\u0022{0}\u0022 \u003E \u0432\u044B\u0448\u0435, \u0447\u0442\u043E\u0431\u044B \u0434\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0437\u0430\u0434\u0430\u0447\u0443",
		ChangeCaseButtonCaption: "\u0418\u0437\u043C\u0435\u043D\u0438\u0442\u044C \u043A\u0435\u0439\u0441",
		DashboardTabCaptionPattern: "\u0421\u043B\u0435\u0434\u0443\u044E\u0449\u0438\u0435 \u0448\u0430\u0433\u0438 ({0})",
		EmailTitleCaption: "Re: {0} {1}",
		HideItemsCaption: "\u0441\u043A\u0440\u044B\u0442\u044C",
		ShowAllItemsCaption: "\u043F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u0432\u0441\u0435",
		StageChangeDialogText: "\u041F\u043E\u0434\u0442\u0432\u0435\u0440\u0434\u0438\u0442\u044C \u0438\u0437\u043C\u0435\u043D\u0435\u043D\u0438\u0435 \u0441\u0442\u0430\u0434\u0438\u0438?",
		PlaybookButtonCaption: "Playbook"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		LoadMoreIcon: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "LoadMoreIcon",
				hash: "d757aaf069c75446184760d4935622e9",
				resourceItemExtension: ".png"
			}
		},
		LoadLessIcon: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "LoadLessIcon",
				hash: "f1aa9a0e4d16dc471383067e5207d625",
				resourceItemExtension: ".png"
			}
		},
		BlankSlateImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "BlankSlateImage",
				hash: "71ca1e06fc6c5119c41da0b69a1d3196",
				resourceItemExtension: ".svg"
			}
		},
		FlagGreyImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "FlagGreyImage",
				hash: "de5ec586cf912d75ae03e3a3071b3252",
				resourceItemExtension: ".svg"
			}
		},
		CallMessageTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "CallMessageTabImage",
				hash: "0e1c543ccf948c3e7fb034d214ae4934",
				resourceItemExtension: ".svg"
			}
		},
		CallTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "CallTabImage",
				hash: "fb4972b6c02e21ec7e850654370dc393",
				resourceItemExtension: ".png"
			}
		},
		EmailMessageTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "EmailMessageTabImage",
				hash: "26f9635f645fd8047a176991ce41dc2c",
				resourceItemExtension: ".svg"
			}
		},
		EmailTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "EmailTabImage",
				hash: "7cbca8d08ee0269c400adb615b284537",
				resourceItemExtension: ".png"
			}
		},
		SocialMessageTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "SocialMessageTabImage",
				hash: "02bcae291b631010e4d4793bcb673994",
				resourceItemExtension: ".svg"
			}
		},
		TaskMessageTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "TaskMessageTabImage",
				hash: "cd4d0710b0c8e534d0c847d692043fc0",
				resourceItemExtension: ".svg"
			}
		},
		WhatsAppMessageTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "WhatsAppMessageTabImage",
				hash: "30ec0d83651ae2695baa9b7810af71c4",
				resourceItemExtension: ".svg"
			}
		},
		TelegramMessageTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "TelegramMessageTabImage",
				hash: "6ed2b31ed4047758e8769e333f12afb9",
				resourceItemExtension: ".svg"
			}
		},
		FacebookMessageTabImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "FacebookMessageTabImage",
				hash: "93600fabf87a0d3f837ee3b40395f211",
				resourceItemExtension: ".svg"
			}
		},
		PlaybookImage: {
			source: 3,
			params: {
				schemaName: "SectionActionsDashboard",
				resourceItemName: "PlaybookImage",
				hash: "7b515a57b747cbb084a9c9baabbef997",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});