define("CtiPanelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ConnectionConfigEmptyError: "\u041E\u0448\u0438\u0431\u043A\u0430 \u043F\u043E\u043B\u0443\u0447\u0435\u043D\u0438\u044F \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440\u043E\u0432 \u043F\u043E\u0434\u043A\u043B\u044E\u0447\u0435\u043D\u0438\u044F \u043A \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0438\u0438. \u0423\u043A\u0430\u0436\u0438\u0442\u0435 \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440\u044B \u0432 \u043C\u0435\u043D\u044E \u0022\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438 \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440\u043E\u0432 Call Centre\u0022 \u0432 \u043F\u0440\u043E\u0444\u0438\u043B\u0435 \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u044F",
		AccountNameLabelCaption: "\u041A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442",
		JobLabelCaption: "\u0414\u043E\u043B\u0436\u043D\u043E\u0441\u0442\u044C",
		AccountTypeLabelCaption: "\u0422\u0438\u043F",
		CityLabelCaption: "\u0413\u043E\u0440\u043E\u0434",
		CallDurationLabelCaption: "\u0414\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C:",
		DepartmentLabelCaption: "\u0414\u0435\u043F\u0430\u0440\u0442\u0430\u043C\u0435\u043D\u0442",
		NumberLabelCaption: "\u041D\u043E\u043C\u0435\u0440",
		AnswerButtonHint: "\u041E\u0442\u0432\u0435\u0442\u0438\u0442\u044C \u043D\u0430 \u0437\u0432\u043E\u043D\u043E\u043A",
		DropButtonHint: "\u0417\u0430\u0432\u0435\u0440\u0448\u0438\u0442\u044C \u0437\u0432\u043E\u043D\u043E\u043A",
		HoldButtonHint: "\u041F\u043E\u0441\u0442\u0430\u0432\u0438\u0442\u044C \u043D\u0430 \u0443\u0434\u0435\u0440\u0436\u0430\u043D\u0438\u0435",
		UnholdButtonHint: "\u0421\u043D\u044F\u0442\u044C \u0441 \u0443\u0434\u0435\u0440\u0436\u0430\u043D\u0438\u044F",
		PrepareTransferButtonHint: "\u041F\u0435\u0440\u0435\u0432\u0435\u0441\u0442\u0438 \u0437\u0432\u043E\u043D\u043E\u043A",
		CompleteTransferButtonHint: "\u0421\u043E\u0435\u0434\u0438\u043D\u0438\u0442\u044C \u0430\u0431\u043E\u043D\u0435\u043D\u0442\u043E\u0432",
		CancelTransferButtonHint: "\u041E\u0442\u043C\u0435\u043D\u0438\u0442\u044C \u043F\u0435\u0440\u0435\u0432\u043E\u0434",
		CompleteTransferTip: "\u041D\u0430\u0436\u043C\u0438\u0442\u0435, \u0434\u043B\u044F \u0441\u043E\u0435\u0434\u0438\u043D\u0435\u043D\u0438\u044F \u0430\u0431\u043E\u043D\u0435\u043D\u0442\u043E\u0432",
		DtmfButtonHint: "\u041F\u0430\u043D\u0435\u043B\u044C \u043D\u0430\u0431\u043E\u0440\u0430 \u043D\u043E\u043C\u0435\u0440\u0430",
		MuteButtonHint: "\u041E\u0442\u043A\u043B\u044E\u0447\u0438\u0442\u044C \u0437\u0432\u0443\u043A",
		UnmuteButtonHint: "\u0412\u043A\u043B\u044E\u0447\u0438\u0442\u044C \u0437\u0432\u0443\u043A",
		VideoOnButtonHint: "\u0412\u043A\u043B\u044E\u0447\u0438\u0442\u044C \u0432\u0438\u0434\u0435\u043E",
		VideoOffButtonHint: "\u041E\u0442\u043A\u043B\u044E\u0447\u0438\u0442\u044C \u0432\u0438\u0434\u0435\u043E",
		IdentificationItemsControlGroupCaption: "\u0420\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442\u044B \u043F\u043E\u0438\u0441\u043A\u0430",
		SubscriberPanelNotFoundExceptionMessage: "\u041D\u0435 \u0443\u0434\u0430\u043B\u043E\u0441\u044C \u043D\u0430\u0439\u0442\u0438 \u043F\u0430\u043D\u0435\u043B\u044C \u0438\u0434\u0435\u043D\u0442\u0438\u0444\u0438\u0446\u0438\u0440\u043E\u0432\u0430\u043D\u043D\u043E\u0433\u043E \u0430\u0431\u043E\u043D\u0435\u043D\u0442\u0430 \u043F\u043E \u0438\u0434\u0435\u043D\u0442\u0438\u0444\u0438\u043A\u0430\u0442\u043E\u0440\u0443 \u0027{0}\u0027",
		SelectAnotherSubscriberCaption: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u0434\u0440\u0443\u0433\u0443\u044E \u0437\u0430\u043F\u0438\u0441\u044C",
		IdentificationSavingMessage: "\u0421\u043E\u0445\u0440\u0430\u043D\u0435\u043D\u0438\u0435 \u0438\u0434\u0435\u043D\u0442\u0438\u0444\u0438\u043A\u0430\u0446\u0438\u0438 \u0437\u0432\u043E\u043D\u043A\u0430 \u0441 id \u0027{0}\u0027",
		IdentificationFieldSavingMessage: "\u041F\u043E\u043B\u0435 \u0027{0}\u0027, \u0437\u043D\u0430\u0447\u0435\u043D\u0438\u0435 \u0027{1}\u0027",
		IdentificationSavedSuccessfullyMessage: "\u0432\u044B\u043F\u043E\u043B\u043D\u0435\u043D\u043E \u0443\u0441\u043F\u0435\u0448\u043D\u043E",
		IdentificationSavedFailedMessage: "\u0432\u044B\u043F\u043E\u043B\u043D\u0435\u043D\u043E \u0441 \u043E\u0448\u0438\u0431\u043A\u043E\u0439",
		PhoneNumberCantBeEmptyMessage: "\u041F\u043E\u043B\u0435 \u041D\u043E\u043C\u0435\u0440 \u043D\u0435 \u043C\u043E\u0436\u0435\u0442 \u0431\u044B\u0442\u044C \u043F\u0443\u0441\u0442\u044B\u043C",
		EmptySearchResultMessage: "\u041D\u0435\u0442 \u0437\u0430\u043F\u0438\u0441\u0435\u0439 \u0443\u0434\u043E\u0432\u043B\u0435\u0442\u0432\u043E\u0440\u044F\u044E\u0449\u0438\u0445 \u0443\u0441\u043B\u043E\u0432\u0438\u044F\u043C \u043F\u043E\u0438\u0441\u043A\u0430.",
		VideoNotSupportedMessage: "\u0412\u0430\u0448 \u0431\u0440\u0430\u0443\u0437\u0435\u0440 \u043D\u0435 \u043F\u043E\u0434\u0434\u0435\u0440\u0436\u0438\u0432\u0430\u0435\u0442 \u043E\u0442\u043E\u0431\u0440\u0430\u0436\u0435\u043D\u0438\u0435 \u0432\u0438\u0434\u0435\u043E",
		EmptyHistoryMessage: "\u0417\u0432\u043E\u043D\u0438\u0442\u0435 \u0434\u0440\u0443\u0433\u0438\u043C \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u044F\u043C \u0438\u043B\u0438 \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u0442\u0435 \u043A\u043E\u043D\u043D\u0435\u043A\u0442\u043E\u0440 \u0434\u043B\u044F \u0432\u0430\u0448\u0435\u0439 \u003Ca href=\u0022https://www.terrasoft.ru/bpmonline-marketplace\u0022 target=\u0022_blank\u0022\u003E\u0441\u0438\u0441\u0442\u0435\u043C\u044B \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0438\u0438\u003C/a\u003E.\u003C/br\u003E\u003C/br\u003E\u0423\u0437\u043D\u0430\u0439\u0442\u0435 \u0431\u043E\u043B\u044C\u0448\u0435 \u043E \u0440\u0430\u0431\u043E\u0442\u0435 \u0441\u043E \u0437\u0432\u043E\u043D\u043A\u0430\u043C\u0438 \u0432 {0}\u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438{1}.",
		EmptyHistoryTitleLabel: "\u041F\u043E\u0445\u043E\u0436\u0435, \u0432\u044B \u0435\u0449\u0435 \u043D\u0435 \u0441\u043E\u0432\u0435\u0440\u0448\u0430\u043B\u0438 \u0437\u0432\u043E\u043D\u043A\u043E\u0432",
		NotConnectedMessage: "\u0422\u0435\u043B\u0435\u0444\u043E\u043D\u0438\u044F \u043D\u0435 \u043F\u043E\u0434\u043A\u043B\u044E\u0447\u0435\u043D\u0430",
		NoConnectionToTelephonyErrorMessage: "\u041E\u0442\u0441\u0443\u0442\u0441\u0442\u0432\u0443\u0435\u0442 \u043F\u043E\u0434\u043A\u043B\u044E\u0447\u0435\u043D\u0438\u0435 \u043A \u0441\u0435\u0440\u0432\u0435\u0440\u0443 \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0438\u0438. \u0412\u043E\u0437\u043C\u043E\u0436\u043D\u043E, \u043D\u0435 \u043D\u0430\u0441\u0442\u0440\u043E\u0435\u043D\u044B \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440\u044B \u0441\u043E\u0435\u0434\u0438\u043D\u0435\u043D\u0438\u044F \u0438\u043B\u0438 \u0441\u0435\u0440\u0432\u0435\u0440 \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0438\u0438 \u043D\u0435\u0434\u043E\u0441\u0442\u0443\u043F\u0435\u043D.",
		DemoNoConnectionMessageCaption: "\u0412\u043E\u0437\u043C\u043E\u0436\u043D\u043E\u0441\u0442\u044C \u0441\u043E\u0432\u0435\u0440\u0448\u0435\u043D\u0438\u044F \u0437\u0432\u043E\u043D\u043A\u043E\u0432 \u043E\u0433\u0440\u0430\u043D\u0438\u0447\u0435\u043D\u0430 \u0432 \u0434\u0435\u043C\u043E\u043D\u0441\u0442\u0440\u0430\u0446\u0438\u043E\u043D\u043D\u043E\u0439 \u0432\u0435\u0440\u0441\u0438\u0438.",
		DemoNoConnectionLinkCaption: "\u0431\u0435\u0441\u043F\u043B\u0430\u0442\u043D\u043E\u0439 \u0432\u0435\u0440\u0441\u0438\u0438 \u043D\u0430 30 \u0434\u043D\u0435\u0439",
		DemoNoConnectionLinkUrlBeginning: "https://www.terrasoft.ru/trial?product=",
		PhoneNumberPlaceholderCaption: "\u041A\u043E\u043C\u0443 \u0432\u044B \u0445\u043E\u0442\u0438\u0442\u0435 \u043F\u043E\u0437\u0432\u043E\u043D\u0438\u0442\u044C?",
		SettingsButtonHint: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438 \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440\u043E\u0432 Call Centre",
		NotEnabledTelephonyErrorMessage: "\u0423 \u0432\u0430\u0441 \u043D\u0435 \u043D\u0430\u0441\u0442\u0440\u043E\u0435\u043D\u0430 \u0438\u043D\u0442\u0435\u0433\u0440\u0430\u0446\u0438\u044F \u0441 \u0441\u0438\u0441\u0442\u0435\u043C\u043E\u0439 \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0438\u0438. \u0411\u043E\u043B\u044C\u0448\u0435 \u0438\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u0438 \u043E\u0431 \u0438\u0441\u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u043D\u0438\u0438 \u0437\u0432\u043E\u043D\u043A\u043E\u0432 \u0434\u043E\u0441\u0442\u0443\u043F\u043D\u043E \u043D\u0430 \u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SwitchAbonentDropBoxIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "SwitchAbonentDropBoxIcon",
				hash: "e666623681456cf7d8e69fbfd3f4499a",
				resourceItemExtension: ".png"
			}
		},
		TransferringArrows: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "TransferringArrows",
				hash: "b61ad6b3c7ca0a53e74d8829e6c307ea",
				resourceItemExtension: ".png"
			}
		},
		MakeCallButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "MakeCallButtonIcon",
				hash: "75e43ae61b43c09e66573ad20a28bb62",
				resourceItemExtension: ".png"
			}
		},
		ContactEmptyPhoto: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "ContactEmptyPhoto",
				hash: "6985edb87f777607967eed9d8070db42",
				resourceItemExtension: ".jpg"
			}
		},
		AnswerButtonLongIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "AnswerButtonLongIcon",
				hash: "c71ea18644a6e8110fac1293940fb1e6",
				resourceItemExtension: ".png"
			}
		},
		DropButtonLongIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "DropButtonLongIcon",
				hash: "7629d93e40846d20c303088188d8e4a1",
				resourceItemExtension: ".png"
			}
		},
		DropButtonShortIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "DropButtonShortIcon",
				hash: "c1983752b03ae4adf6cd9329492eeff9",
				resourceItemExtension: ".png"
			}
		},
		HoldButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "HoldButtonIcon",
				hash: "267f413d2507dff2de559cd5ffacb0ab",
				resourceItemExtension: ".png"
			}
		},
		HoldButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "HoldButtonIconDisabled",
				hash: "ede30f5823d4b9866fa73676e55d1ee5",
				resourceItemExtension: ".png"
			}
		},
		UnholdButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "UnholdButtonIcon",
				hash: "c5a39d1c4fd9b99f9e8cdaa636b09a38",
				resourceItemExtension: ".png"
			}
		},
		PrepareTransferButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "PrepareTransferButtonIcon",
				hash: "10d7a7e79ecfae491fad3ebe46cac494",
				resourceItemExtension: ".png"
			}
		},
		PrepareTransferButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "PrepareTransferButtonIconDisabled",
				hash: "459ec584d7cc6a3f7a65db95681bb2b9",
				resourceItemExtension: ".png"
			}
		},
		CompleteTransferButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "CompleteTransferButtonIcon",
				hash: "814f0f275e02da04bd5b63a02b7a9ec2",
				resourceItemExtension: ".png"
			}
		},
		CancelTransferButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "CancelTransferButtonIcon",
				hash: "f29943cea1239c6d22716c6716c668de",
				resourceItemExtension: ".png"
			}
		},
		DtmfButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "DtmfButtonIcon",
				hash: "ecc004bb090bb74f75f3dc85471542a3",
				resourceItemExtension: ".png"
			}
		},
		DtmfButtonIconPressed: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "DtmfButtonIconPressed",
				hash: "f8c1b77e816ded0325a50a5eb853d4e5",
				resourceItemExtension: ".png"
			}
		},
		MuteButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "MuteButtonIcon",
				hash: "635be20ddb3f9c779436ae38d4f25e87",
				resourceItemExtension: ".png"
			}
		},
		MuteButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "MuteButtonIconDisabled",
				hash: "9baff8394942b8d3b9deabe4e92c2b6b",
				resourceItemExtension: ".png"
			}
		},
		VideoOffButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "VideoOffButtonIcon",
				hash: "e9dcc60a70c52135b89e7ba16f6ad35d",
				resourceItemExtension: ".png"
			}
		},
		VideoOffButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "VideoOffButtonIconDisabled",
				hash: "78d5d34055795c9449cf2786aa0d8b76",
				resourceItemExtension: ".png"
			}
		},
		VideoOnButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "VideoOnButtonIcon",
				hash: "e34860c1dcf4eea815a32b15846ecaf5",
				resourceItemExtension: ".png"
			}
		},
		UnidentifiedSubscriberPhoto: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "UnidentifiedSubscriberPhoto",
				hash: "54952b0b7cb8ad1d67634d3442262c92",
				resourceItemExtension: ".png"
			}
		},
		AccountIdentifiedPhoto: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "AccountIdentifiedPhoto",
				hash: "7e38b8ec9f4f84e5030930ce2be8b53a",
				resourceItemExtension: ".png"
			}
		},
		ContactEmptyPhotoWhite: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "ContactEmptyPhotoWhite",
				hash: "8da06cb2a0894f101e684dfe60fec84c",
				resourceItemExtension: ".png"
			}
		},
		EmptySearchResultImage: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "EmptySearchResultImage",
				hash: "105bb9cb80c3ce1da8d5eb9869eb19e1",
				resourceItemExtension: ".png"
			}
		},
		SettingsButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanel",
				resourceItemName: "SettingsButtonIcon",
				hash: "937897ca7534dc30662fe6a1d532c60c",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});