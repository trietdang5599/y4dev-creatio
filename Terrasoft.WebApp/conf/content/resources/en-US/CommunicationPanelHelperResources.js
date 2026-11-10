define("CommunicationPanelHelperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		EsnFeedMenuHint: "Feed",
		RemindingsMenuHint: "Notifications",
		VisasMenuHint: "Approvals",
		MenuItemIconNameTemplate: "{0}Menu{1}{2}Icon",
		CtiPanelMenuHint: "CTI panel"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CtiPanelMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "CtiPanelMenuIcon",
				hash: "7244f0840b33009e878b2a3a9cf859af",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "CtiPanelMenuPressedIcon",
				hash: "cc06d6e4b7629e85a84fdc67f59804f8",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "CtiPanelMenuCounterIcon",
				hash: "db24514cf020125a5cffcce587c471fe",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "CtiPanelMenuPressedCounterIcon",
				hash: "6d88d5035d840aa0a3681cf67b922fc0",
				resourceItemExtension: ".png"
			}
		},
		EsnFeedMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EsnFeedMenuIcon",
				hash: "2e1340322b111734ac38e8737a91ca92",
				resourceItemExtension: ".png"
			}
		},
		EsnFeedMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EsnFeedMenuPressedIcon",
				hash: "33b09bdf16ce7a22c6c156fd234f0476",
				resourceItemExtension: ".png"
			}
		},
		EsnFeedMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EsnFeedMenuCounterIcon",
				hash: "98b64abe3185b283124ebc29855693f6",
				resourceItemExtension: ".png"
			}
		},
		EsnFeedMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EsnFeedMenuPressedCounterIcon",
				hash: "0fafbe3399f121a144426a331abf82f3",
				resourceItemExtension: ".png"
			}
		},
		RemindingsMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "RemindingsMenuIcon",
				hash: "e71a6911e8f2c8666f2c52ca68e94f1c",
				resourceItemExtension: ".png"
			}
		},
		RemindingsMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "RemindingsMenuPressedIcon",
				hash: "b770a82a310190cfa36b95c6d07dd310",
				resourceItemExtension: ".png"
			}
		},
		RemindingsMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "RemindingsMenuCounterIcon",
				hash: "3ee373e1fce6b0861a38c2f5f51a3304",
				resourceItemExtension: ".png"
			}
		},
		RemindingsMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "RemindingsMenuPressedCounterIcon",
				hash: "98626fac2eb34e1b0697c04d6d2e76c5",
				resourceItemExtension: ".png"
			}
		},
		VisasMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "VisasMenuIcon",
				hash: "5dfb6dfdff3dce6e52b478e6a03d4bcd",
				resourceItemExtension: ".png"
			}
		},
		VisasMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "VisasMenuPressedIcon",
				hash: "cd53c405b05cd1a4fcc6ee7de447ee9c",
				resourceItemExtension: ".png"
			}
		},
		VisasMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "VisasMenuCounterIcon",
				hash: "29f908448b8a5e8a302bb33b60bcd492",
				resourceItemExtension: ".png"
			}
		},
		VisasMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "VisasMenuPressedCounterIcon",
				hash: "62a2b19a992d5a5daf4d5ce18a243a66",
				resourceItemExtension: ".png"
			}
		},
		ChatMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "ChatMenuIcon",
				hash: "e247e625f1c35a110e4ef3fa5123f831",
				resourceItemExtension: ".png"
			}
		},
		ChatMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "ChatMenuPressedIcon",
				hash: "82ccf78cdeb6f3adb64498c828487bae",
				resourceItemExtension: ".png"
			}
		},
		ChatMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "ChatMenuCounterIcon",
				hash: "ccfd472dc847f6bba2b792e1161ed526",
				resourceItemExtension: ".png"
			}
		},
		ChatMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "ChatMenuPressedCounterIcon",
				hash: "d27b080223b7102f7020c6804c69c59e",
				resourceItemExtension: ".png"
			}
		},
		EmailsMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EmailsMenuIcon",
				hash: "a2767c105c09f4a45047184ef7ad321a",
				resourceItemExtension: ".png"
			}
		},
		EmailsMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EmailsMenuPressedIcon",
				hash: "62c51160a9df69ec30aa0d74f8605dec",
				resourceItemExtension: ".png"
			}
		},
		EmailsMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EmailsMenuCounterIcon",
				hash: "9b3d864726e35cdf4dfa2180345e17b4",
				resourceItemExtension: ".png"
			}
		},
		EmailsMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "EmailsMenuPressedCounterIcon",
				hash: "62c321c10fe341c6aaa98083401842cd",
				resourceItemExtension: ".png"
			}
		},
		ImageCloseRightSidePanelButton: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelHelper",
				resourceItemName: "ImageCloseRightSidePanelButton",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});