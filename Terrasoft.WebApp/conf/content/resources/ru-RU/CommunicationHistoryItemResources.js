define("CommunicationHistoryItemResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CreateNewContactMenuItemCaption: "\u0421\u043E\u0437\u0434\u0430\u0442\u044C \u043A\u043E\u043D\u0442\u0430\u043A\u0442",
		CreateNewAccountMenuItemCaption: "\u0421\u043E\u0437\u0434\u0430\u0442\u044C \u043A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442\u0430",
		AddToExistingContactMenuItemCaption: "\u0421\u0432\u044F\u0437\u0430\u0442\u044C \u0441 \u0441\u0443\u0449\u0435\u0441\u0442\u0432\u0443\u044E\u0449\u0438\u043C \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u043E\u043C",
		SelectContactLookupCaption: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u043A\u043E\u043D\u0442\u0430\u043A\u0442 \u0434\u043B\u044F {0}",
		ShowAllConnectionsMenuItemCaption: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u0432\u0441\u0435 \u0441\u0432\u044F\u0437\u0438",
		HideConnectionsMenuItemCaption: "\u0421\u043A\u0440\u044B\u0442\u044C \u0441\u0432\u044F\u0437\u0438",
		OpenCallPageCaption: "\u041E\u0442\u043A\u0440\u044B\u0442\u044C \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443 \u0437\u0432\u043E\u043D\u043A\u0430"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ContactEmptyPhotoWhite: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "ContactEmptyPhotoWhite",
				hash: "8da06cb2a0894f101e684dfe60fec84c",
				resourceItemExtension: ".png"
			}
		},
		AccountIdentifiedPhoto: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "AccountIdentifiedPhoto",
				hash: "01889b1912c8147381649dd23def4901",
				resourceItemExtension: ".png"
			}
		},
		IncomingCallIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "IncomingCallIcon",
				hash: "8b762a2f07579b53ed1c2b6319c23872",
				resourceItemExtension: ".png"
			}
		},
		MissedIconCall: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "MissedIconCall",
				hash: "58dd6b4cae175d2475cba148fc5f5f66",
				resourceItemExtension: ".png"
			}
		},
		OutgoingCallIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "OutgoingCallIcon",
				hash: "546496843e595e94b1284be928d64907",
				resourceItemExtension: ".png"
			}
		},
		MakeCallButtonIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "MakeCallButtonIcon",
				hash: "75e43ae61b43c09e66573ad20a28bb62",
				resourceItemExtension: ".png"
			}
		},
		CreateLinkButtonIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "CreateLinkButtonIcon",
				hash: "0dcb6a1579f36640d93321d10546936d",
				resourceItemExtension: ".png"
			}
		},
		ContactFieldIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "ContactFieldIcon",
				hash: "ba00ae4d2f0b419bf0b40ec99d6ef101",
				resourceItemExtension: ".png"
			}
		},
		AccountFieldIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "AccountFieldIcon",
				hash: "1fb0a641f8114c9c9f998a7937f94a8a",
				resourceItemExtension: ".png"
			}
		},
		ActivityFieldIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "ActivityFieldIcon",
				hash: "b77b4b686dc5769d88e9bf7f4edb6036",
				resourceItemExtension: ".png"
			}
		},
		ContactAnonymousPhoto: {
			source: 3,
			params: {
				schemaName: "CommunicationHistoryItem",
				resourceItemName: "ContactAnonymousPhoto",
				hash: "fa31ab8e8c57eb1888e1f2bd10bd81f8",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});