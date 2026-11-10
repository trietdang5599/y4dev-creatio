define("CommunicationPanelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OmniChatMenuHint: "Chats",
		CenterNotificationMenuHint: "Notification center",
		CloseRightSidePanel: "Collapse panel",
		CommunicationPanelTip: "\u003Cspan class=\u0022tip-header\u0022\u003ECommunication panel\u003C/span\u003E\u003Cbr\u003EMake calls, work with email, view notifications and reminders, read and post messages in the enterprise social network\u003Cbr\u003E\u003Ca href=\u0022#\u0022 data-context-help-id=\u00221011\u0022 \u003ERead more\u003C/a\u003E",
		EmailMenuHint: "Email",
		ESNFeedMenuHint: "Feed",
		ESNNotificationMenuHint: "ESN notifications",
		MenuItemIconNameTemplate: "{0}Menu{1}{2}Icon",
		NotificationsMenuHint: "Notifications",
		ProcessDashboardMenuHint: "Business process tasks",
		VisaMenuHint: "Approvals",
		CtiPanelMenuHint: "Calls"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ESNFeedMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNFeedMenuIcon",
				hash: "48e23079e19d0b9204c35150a08d1a7a",
				resourceItemExtension: ".png"
			}
		},
		ESNFeedMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNFeedMenuPressedIcon",
				hash: "558f12510e3600eaf64e3a214a7580d9",
				resourceItemExtension: ".png"
			}
		},
		ESNFeedMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNFeedMenuCounterIcon",
				hash: "53a2aec2441816f4d0193f2e8ea06a6f",
				resourceItemExtension: ".png"
			}
		},
		ESNFeedMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNFeedMenuPressedCounterIcon",
				hash: "28f8f85e75094452f5122b4480320c69",
				resourceItemExtension: ".png"
			}
		},
		NotificationsMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "NotificationsMenuIcon",
				hash: "dcc85375c6e07c776098f74c1db7fb9d",
				resourceItemExtension: ".png"
			}
		},
		NotificationsMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "NotificationsMenuPressedIcon",
				hash: "dee7f1a25b9824117d1da699a7a7cc56",
				resourceItemExtension: ".png"
			}
		},
		NotificationsMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "NotificationsMenuCounterIcon",
				hash: "47b0b288ed8b542d8d3ffcf9f5958e08",
				resourceItemExtension: ".png"
			}
		},
		NotificationsMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "NotificationsMenuPressedCounterIcon",
				hash: "0dcd88ea925210840ad83b188ca3ac95",
				resourceItemExtension: ".png"
			}
		},
		VisaMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "VisaMenuIcon",
				hash: "53bac3007cf405140ec13cf837813266",
				resourceItemExtension: ".png"
			}
		},
		VisaMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "VisaMenuPressedIcon",
				hash: "c467d8a4cc822d5045c43e0c2b02dfdc",
				resourceItemExtension: ".png"
			}
		},
		VisaMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "VisaMenuCounterIcon",
				hash: "23231bb7a69411fd561c172dd11c642e",
				resourceItemExtension: ".png"
			}
		},
		VisaMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "VisaMenuPressedCounterIcon",
				hash: "6e484351d0aa6b3f48dad23043896310",
				resourceItemExtension: ".png"
			}
		},
		ImageCloseRightSidePanelButton: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ImageCloseRightSidePanelButton",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		EmailMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "EmailMenuIcon",
				hash: "c04ad1dbefa662e77051080df4aca9f8",
				resourceItemExtension: ".png"
			}
		},
		EmailMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "EmailMenuPressedIcon",
				hash: "df59a4256e05de7d48bb6d7aec6778f2",
				resourceItemExtension: ".png"
			}
		},
		EmailMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "EmailMenuCounterIcon",
				hash: "53a2aec2441816f4d0193f2e8ea06a6f",
				resourceItemExtension: ".png"
			}
		},
		EmailMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "EmailMenuPressedCounterIcon",
				hash: "28f8f85e75094452f5122b4480320c69",
				resourceItemExtension: ".png"
			}
		},
		CenterNotificationMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CenterNotificationMenuIcon",
				hash: "9f24d39028c318d30df6dc1976ac2241",
				resourceItemExtension: ".png"
			}
		},
		CenterNotificationMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CenterNotificationMenuPressedIcon",
				hash: "697eceef2c9fdac62154a84eca2d3964",
				resourceItemExtension: ".png"
			}
		},
		CenterNotificationMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CenterNotificationMenuCounterIcon",
				hash: "a89eaaf6d9c81a98a63f2b301f4df2e9",
				resourceItemExtension: ".png"
			}
		},
		CenterNotificationMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CenterNotificationMenuPressedCounterIcon",
				hash: "25c05c9ddf017365ecb869af0e98417b",
				resourceItemExtension: ".png"
			}
		},
		ESNFeedMenuIconSVG: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNFeedMenuIconSVG",
				hash: "c08430f39d4395399647618cc38cf020",
				resourceItemExtension: ".svg"
			}
		},
		NotificationsMenuIconSVG: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "NotificationsMenuIconSVG",
				hash: "d0a350614ce1e3b2c3a6c661069674dd",
				resourceItemExtension: ".svg"
			}
		},
		EmailMenuIconSVG: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "EmailMenuIconSVG",
				hash: "717ca6940c20c7f5441e0fd282dc4981",
				resourceItemExtension: ".svg"
			}
		},
		CenterNotificationMenuIconSVG: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CenterNotificationMenuIconSVG",
				hash: "d0a350614ce1e3b2c3a6c661069674dd",
				resourceItemExtension: ".svg"
			}
		},
		ProcessDashboardMenuIconSVG: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ProcessDashboardMenuIconSVG",
				hash: "934f8eafafd89571a6a37dd70db12542",
				resourceItemExtension: ".svg"
			}
		},
		OmniChatMenuIconSVG: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "OmniChatMenuIconSVG",
				hash: "2fb0a39a8255780da2262046a6e207a6",
				resourceItemExtension: ".svg"
			}
		},
		ESNNotificationMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNNotificationMenuIcon",
				hash: "9f24d39028c318d30df6dc1976ac2241",
				resourceItemExtension: ".png"
			}
		},
		ESNNotificationMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNNotificationMenuPressedIcon",
				hash: "697eceef2c9fdac62154a84eca2d3964",
				resourceItemExtension: ".png"
			}
		},
		ESNNotificationMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNNotificationMenuCounterIcon",
				hash: "a89eaaf6d9c81a98a63f2b301f4df2e9",
				resourceItemExtension: ".png"
			}
		},
		ESNNotificationMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "ESNNotificationMenuPressedCounterIcon",
				hash: "25c05c9ddf017365ecb869af0e98417b",
				resourceItemExtension: ".png"
			}
		},
		OmniChatNotificationIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "OmniChatNotificationIcon",
				hash: "3256a5604385318474af2051651a1e47",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CtiPanelMenuIcon",
				hash: "240654689cea754ecc890901ee75e1e6",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CtiPanelMenuPressedIcon",
				hash: "d03a44ea13cc2c3d1cea7ea37b4280a2",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CtiPanelMenuCounterIcon",
				hash: "445e5547ccccdd689ddbe4e5ff1add07",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuPressedCounterIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CtiPanelMenuPressedCounterIcon",
				hash: "6df4339dbe188686cce705440ada0560",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuCallDurationIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CtiPanelMenuCallDurationIcon",
				hash: "c30eb1019759690f80ed346acfec2a09",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuCallDurationPressedIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CtiPanelMenuCallDurationPressedIcon",
				hash: "ca29a10f2ab55fd5c0b2ad0bacdc8e5b",
				resourceItemExtension: ".png"
			}
		},
		CtiPanelMenuIconSVG: {
			source: 3,
			params: {
				schemaName: "CommunicationPanel",
				resourceItemName: "CtiPanelMenuIconSVG",
				hash: "657881e32cadf5e84f06ac208bc381fd",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});