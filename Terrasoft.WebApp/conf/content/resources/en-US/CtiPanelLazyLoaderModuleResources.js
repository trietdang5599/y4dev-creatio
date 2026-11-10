define("CtiPanelLazyLoaderModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ConnectionConfigEmptyError: "",
		AccountNameLabelCaption: "",
		JobLabelCaption: "",
		AccountTypeLabelCaption: "",
		CityLabelCaption: "",
		CallDurationLabelCaption: "",
		DepartmentLabelCaption: "",
		NumberLabelCaption: "",
		AnswerButtonHint: "",
		DropButtonHint: "",
		HoldButtonHint: "",
		UnholdButtonHint: "",
		PrepareTransferButtonHint: "",
		CompleteTransferButtonHint: "",
		CancelTransferButtonHint: "",
		CompleteTransferTip: "",
		DtmfButtonHint: "",
		MuteButtonHint: "",
		UnmuteButtonHint: "",
		VideoOnButtonHint: "",
		VideoOffButtonHint: "",
		IdentificationItemsControlGroupCaption: "",
		SubscriberPanelNotFoundExceptionMessage: "",
		SelectAnotherSubscriberCaption: "",
		IdentificationSavingMessage: "",
		IdentificationFieldSavingMessage: "",
		IdentificationSavedSuccessfullyMessage: "",
		IdentificationSavedFailedMessage: "",
		PhoneNumberCantBeEmptyMessage: "",
		EmptySearchResultMessage: "",
		VideoNotSupportedMessage: "",
		EmptyHistoryMessage: "",
		EmptyHistoryTitleLabel: "",
		NotConnectedMessage: "",
		NoConnectionToTelephonyErrorMessage: "",
		DemoNoConnectionMessageCaption: "",
		DemoNoConnectionLinkCaption: "",
		DemoNoConnectionLinkUrlBeginning: "",
		PhoneNumberPlaceholderCaption: "",
		SettingsButtonHint: "",
		NotEnabledTelephonyErrorMessage: ""
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SwitchAbonentDropBoxIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "SwitchAbonentDropBoxIcon"
			}
		},
		TransferringArrows: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "TransferringArrows"
			}
		},
		MakeCallButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "MakeCallButtonIcon"
			}
		},
		ContactEmptyPhoto: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "ContactEmptyPhoto"
			}
		},
		AnswerButtonLongIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "AnswerButtonLongIcon"
			}
		},
		DropButtonLongIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "DropButtonLongIcon"
			}
		},
		DropButtonShortIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "DropButtonShortIcon"
			}
		},
		HoldButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "HoldButtonIcon"
			}
		},
		HoldButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "HoldButtonIconDisabled"
			}
		},
		UnholdButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "UnholdButtonIcon"
			}
		},
		PrepareTransferButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "PrepareTransferButtonIcon"
			}
		},
		PrepareTransferButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "PrepareTransferButtonIconDisabled"
			}
		},
		CompleteTransferButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "CompleteTransferButtonIcon"
			}
		},
		CancelTransferButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "CancelTransferButtonIcon"
			}
		},
		DtmfButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "DtmfButtonIcon"
			}
		},
		DtmfButtonIconPressed: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "DtmfButtonIconPressed"
			}
		},
		MuteButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "MuteButtonIcon"
			}
		},
		MuteButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "MuteButtonIconDisabled"
			}
		},
		VideoOffButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "VideoOffButtonIcon"
			}
		},
		VideoOffButtonIconDisabled: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "VideoOffButtonIconDisabled"
			}
		},
		VideoOnButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "VideoOnButtonIcon"
			}
		},
		UnidentifiedSubscriberPhoto: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "UnidentifiedSubscriberPhoto"
			}
		},
		AccountIdentifiedPhoto: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "AccountIdentifiedPhoto"
			}
		},
		ContactEmptyPhotoWhite: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "ContactEmptyPhotoWhite"
			}
		},
		EmptySearchResultImage: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "EmptySearchResultImage"
			}
		},
		SettingsButtonIcon: {
			source: 3,
			params: {
				schemaName: "CtiPanelLazyLoaderModule",
				resourceItemName: "SettingsButtonIcon"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});