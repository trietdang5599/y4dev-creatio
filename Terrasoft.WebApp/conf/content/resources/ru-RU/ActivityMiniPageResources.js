define("ActivityMiniPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		JoinMeetingServiceButtonHint: "\u041F\u043E\u0434\u043A\u043B\u044E\u0447\u0438\u0442\u044C\u0441\u044F \u043A \u0437\u0430\u043F\u043B\u0430\u043D\u0438\u0440\u043E\u0432\u0430\u043D\u043D\u043E\u0439 \u043E\u043D\u043B\u0430\u0439\u043D \u0432\u0441\u0442\u0440\u0435\u0447\u0435.",
		JoinMeetingServiceButtonCaption: "",
		ActivityCaption: "\u0410\u043A\u0442\u0438\u0432\u043D\u043E\u0441\u0442\u044C",
		ActivityCategoryControlPlaceholder: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u043A\u0430\u0442\u0435\u0433\u043E\u0440\u0438\u044E",
		CancelButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0438\u0442\u044C \u0437\u0430\u0434\u0430\u0447\u0443",
		CancelEditButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CompleteButtonCaption: "\u0417\u0430\u0432\u0435\u0440\u0448\u0438\u0442\u044C \u0437\u0430\u0434\u0430\u0447\u0443",
		ConnectionsCaption: "\u0421\u0432\u044F\u0437\u0438",
		DetailedResultControlPlaceholder: "\u0412\u0432\u0435\u0434\u0438\u0442\u0435 \u0440\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442 \u043F\u043E\u0434\u0440\u043E\u0431\u043D\u043E",
		InsertParticipantsMessage: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0432 \u0443\u0447\u0430\u0441\u0442\u043D\u0438\u043A\u0438 \u0441\u043E\u0442\u0440\u0443\u0434\u043D\u0438\u043A\u043E\u0432 \u0438\u0437 \u0444\u0438\u043B\u044C\u0442\u0440\u0430?",
		OwnerControlPlaceholder: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u043E\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0435\u043D\u043D\u043E\u0433\u043E",
		OwnerRoleControlPlaceholder: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0440\u043E\u043B\u044C",
		ResultControlPlaceholder: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0440\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442",
		ResultsCaption: "\u0420\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442\u044B: ",
		SaveEditButtonCaption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		SaveEditButtonHint: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C (Ctrl\u002BEnter)",
		StartDateGreaterDueDate: "\u0414\u0430\u0442\u0430 \u0437\u0430\u0432\u0435\u0440\u0448\u0435\u043D\u0438\u044F \u0434\u043E\u043B\u0436\u043D\u0430 \u0431\u044B\u0442\u044C \u0431\u043E\u043B\u044C\u0448\u0435 \u0434\u0430\u0442\u044B \u043D\u0430\u0447\u0430\u043B\u0430",
		StatusControlPlaceholder: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0441\u043E\u0441\u0442\u043E\u044F\u043D\u0438\u0435",
		TitleControlPlaceholder: "\u0412\u0432\u0435\u0434\u0438\u0442\u0435 \u0437\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "AddButtonImage",
				hash: "89dbb23bf2913ac4182e414bc09b29e5",
				resourceItemExtension: ".png"
			}
		},
		OpenCurrentEntityPageImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "OpenCurrentEntityPageImage",
				hash: "857178d6a8f045a025f4455df129833c",
				resourceItemExtension: ".svg"
			}
		},
		OpenEditModeImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "OpenEditModeImage",
				hash: "f4851d37a323f17fc7a7036b77314b24",
				resourceItemExtension: ".svg"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "CloseButtonImage",
				hash: "240cebbe345223f2c270c01be7949519",
				resourceItemExtension: ".svg"
			}
		},
		SaveButtonImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "SaveButtonImage",
				hash: "9d83c749eceae73dbe461501d5b8df55",
				resourceItemExtension: ".svg"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "CancelButtonImage",
				hash: "84b6270935b18aa084d202b7f50696b6",
				resourceItemExtension: ".svg"
			}
		},
		CompleteResultButtonImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "CompleteResultButtonImage",
				hash: "5d7e009885a6bb0e7b12d742e9510af7",
				resourceItemExtension: ".svg"
			}
		},
		CancelResultButtonImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "CancelResultButtonImage",
				hash: "84b6270935b18aa084d202b7f50696b6",
				resourceItemExtension: ".svg"
			}
		},
		ConnectionsImage: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "ConnectionsImage",
				hash: "82a2caf9022ddbf42fc6455f36c3df03",
				resourceItemExtension: ".svg"
			}
		},
		AddConnectionIcon: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "AddConnectionIcon",
				hash: "dd20561c78ee86d5e1c4f3befac5cb48",
				resourceItemExtension: ".svg"
			}
		},
		TimezoneButtonIcon: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "TimezoneButtonIcon",
				hash: "1b93310aa7b98a0f879cf5d8c89bf706",
				resourceItemExtension: ".svg"
			}
		},
		JoinCameraIcon: {
			source: 3,
			params: {
				schemaName: "ActivityMiniPage",
				resourceItemName: "JoinCameraIcon",
				hash: "ea65fa452f26eaf7a6e4acd9af19c603",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});