define("CtiPanelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ConnectionConfigEmptyError: "Unable to receive telephony connection parameters. Set up parameters in the \u0022Call center parameters setup\u0022 menu of the user profile",
		AccountNameLabelCaption: "Account",
		JobLabelCaption: "Job title",
		AccountTypeLabelCaption: "Type",
		CityLabelCaption: "City",
		CallDurationLabelCaption: "Duration:",
		DepartmentLabelCaption: "Department",
		NumberLabelCaption: "Number",
		AnswerButtonHint: "Answer call",
		DropButtonHint: "End call",
		HoldButtonHint: "Put on hold",
		UnholdButtonHint: "Unhold",
		PrepareTransferButtonHint: "Transfer",
		CompleteTransferButtonHint: "Transfer",
		CancelTransferButtonHint: "Cancel transfer",
		CompleteTransferTip: "Click to transfer",
		DtmfButtonHint: "Dial panel",
		MuteButtonHint: "Sound off",
		UnmuteButtonHint: "Sound on",
		VideoOnButtonHint: "Video on",
		VideoOffButtonHint: "Video off",
		IdentificationItemsControlGroupCaption: "Search results",
		SubscriberPanelNotFoundExceptionMessage: "Unable to find identified subscriber panel by the \u0027{0}\u0027 Id",
		SelectAnotherSubscriberCaption: "Select another record",
		IdentificationSavingMessage: "Saving call id: \u0027{0}\u0027",
		IdentificationFieldSavingMessage: "Field \u0027{0}\u0027, value \u0027{1}\u0027",
		IdentificationSavedSuccessfullyMessage: "action completed successfully",
		IdentificationSavedFailedMessage: "error while performing action",
		PhoneNumberCantBeEmptyMessage: "The \u0022Number\u0022 field can not be empty",
		EmptySearchResultMessage: "There are no records matching your search criteria.",
		VideoNotSupportedMessage: "Your browser does not support video playback",
		EmptyHistoryMessage: "Make free voice calls to other users or setup connector to your existing telephone system.\n\u003C/br\u003E\u003C/br\u003E\nLearn more about using calls from the {0}Academy{1}.",
		EmptyHistoryTitleLabel: "Seems that you have not made any calls yet",
		NotConnectedMessage: "Telephony is not available",
		NoConnectionToTelephonyErrorMessage: "Phone server connection is unavailable. Please ensure that connection parameters are set up and that the server is online.",
		DemoNoConnectionMessageCaption: "The ability to make calls is unavailable in the demo version.",
		DemoNoConnectionLinkCaption: "30 day free trial",
		DemoNoConnectionLinkUrlBeginning: "https://www.bpmonline.com/trial?product=en-",
		PhoneNumberPlaceholderCaption: "Whom you want to call?",
		SettingsButtonHint: "Call Center parameters setup",
		NotEnabledTelephonyErrorMessage: "You do not have telephony integration configured. Learn more about using calls from the Academy."
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