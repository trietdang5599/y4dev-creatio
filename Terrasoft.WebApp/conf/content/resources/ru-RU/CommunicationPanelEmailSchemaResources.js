define("CommunicationPanelEmailSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddEmailButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C e-mail",
		SynchronizeEmail: "\u0421\u0438\u043D\u0445\u0440\u043E\u043D\u0438\u0437\u0438\u0440\u043E\u0432\u0430\u0442\u044C \u043F\u043E\u0447\u0442\u0443",
		EmailBoxSettings: "\u041F\u0435\u0440\u0435\u0439\u0442\u0438 \u043A \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0435 \u043F\u043E\u0447\u0442\u043E\u0432\u044B\u0445 \u044F\u0449\u0438\u043A\u043E\u0432",
		MailboxSettingsEmpty: "\u0414\u043B\u044F \u043F\u0440\u0438\u043D\u044F\u0442\u0438\u044F \u043F\u043E\u0447\u0442\u044B \u043D\u0435\u043E\u0431\u0445\u043E\u0434\u0438\u043C\u043E \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0441\u0438\u043D\u0445\u0440\u043E\u043D\u0438\u0437\u0430\u0446\u0438\u044E \u0441 \u043F\u043E\u0447\u0442\u043E\u0432\u044B\u043C \u044F\u0449\u0438\u043A\u043E\u043C",
		IncomingEmail: "\u0412\u0445\u043E\u0434\u044F\u0449\u0438\u0435",
		OutgoingEmail: "\u0418\u0441\u0445\u043E\u0434\u044F\u0449\u0438\u0435",
		DraftEmail: "\u0427\u0435\u0440\u043D\u043E\u0432\u0438\u043A\u0438",
		LoadingMessagesComplete: "\u0421\u0438\u043D\u0445\u0440\u043E\u043D\u0438\u0437\u0430\u0446\u0438\u044F \u043D\u0430\u0447\u0430\u0442\u0430. \u041C\u044B \u043F\u043E\u043A\u0430\u0436\u0435\u043C \u0432\u0430\u043C \u0443\u0432\u0435\u0434\u043E\u043C\u043B\u0435\u043D\u0438\u0435, \u043A\u043E\u0433\u0434\u0430 \u043E\u043D\u0430 \u0437\u0430\u0432\u0435\u0440\u0448\u0438\u0442\u0441\u044F.",
		EmailBoxNotProcessedCaption: "\u041D\u0435\u043E\u0431\u0440\u0430\u0431\u043E\u0442\u0430\u043D\u043D\u044B\u0435",
		EmailBoxIsProcessedCaption: "\u041E\u0431\u0440\u0430\u0431\u043E\u0442\u0430\u043D\u043D\u044B\u0435",
		EditExistingAccount: "\u0420\u0435\u0434\u0430\u043A\u0442\u0438\u0440\u043E\u0432\u0430\u0442\u044C \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438",
		NewEmailAccountCaption: "\u041D\u043E\u0432\u0430\u044F \u0443\u0447\u0435\u0442\u043D\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		EmailboxSyncSettingsInsertedTooltipCaption: "\u0423\u0447\u0435\u0442\u043D\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C {0} \u0443\u0441\u043F\u0435\u0448\u043D\u043E \u0434\u043E\u0431\u0430\u0432\u043B\u0435\u043D\u0430. \u0412\u044B \u043C\u043E\u0436\u0435\u0442\u0435 \u003Ca data-context-mailserverid=\u0027{1}\u0027 href=\u0027#\u0027\u003E\u0438\u0437\u043C\u0435\u043D\u0438\u0442\u044C\u003C/a\u003E \u0435\u0435 \u043D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438, \u043A\u043E\u0442\u043E\u0440\u044B\u0435 \u043C\u044B \u0443\u0441\u0442\u0430\u043D\u043E\u0432\u0438\u043B\u0438 \u043F\u043E \u0443\u043C\u043E\u043B\u0447\u0430\u043D\u0438\u044E.",
		OneNewMessage: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C 1 \u043D\u043E\u0432\u043E\u0435 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435",
		MoreThanOneNewMessage: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C {0} \u043D\u043E\u0432\u044B\u0445 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0439",
		AllMailboxesCaption: "\u0412\u0441\u0435 \u043F\u043E\u0447\u0442\u043E\u0432\u044B\u0435 \u044F\u0449\u0438\u043A\u0438",
		DiagnosticPageCaption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u0434\u0438\u0430\u0433\u043D\u043E\u0441\u0442\u0438\u043A\u0438",
		ManageServiceProviders: "\u0423\u043F\u0440\u0430\u0432\u043B\u044F\u0442\u044C \u0441\u0435\u0440\u0432\u0438\u0441-\u043F\u0440\u043E\u0432\u0430\u0439\u0434\u0435\u0440\u0430\u043C\u0438"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ActionsButtonImage: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelEmailSchema",
				resourceItemName: "ActionsButtonImage",
				hash: "ab08a8639d9061e25c46ab0eb562e671",
				resourceItemExtension: ".png"
			}
		},
		Processed: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelEmailSchema",
				resourceItemName: "Processed",
				hash: "e3ee0372837d60522d3304eccb138704",
				resourceItemExtension: ".png"
			}
		},
		NoProcessed: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelEmailSchema",
				resourceItemName: "NoProcessed",
				hash: "1fa0a107b5b56041df4c50999f194031",
				resourceItemExtension: ".png"
			}
		},
		RelationsImage: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelEmailSchema",
				resourceItemName: "RelationsImage",
				hash: "f589bcfcdde710b8225b98a6f518ba3e",
				resourceItemExtension: ".png"
			}
		},
		AddEmailImage: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelEmailSchema",
				resourceItemName: "AddEmailImage",
				hash: "9b3a38af6a8dc85aa746612aa640c099",
				resourceItemExtension: ".png"
			}
		},
		More: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelEmailSchema",
				resourceItemName: "More",
				hash: "031d369f5cd473c41a1f54e907d86519",
				resourceItemExtension: ".png"
			}
		},
		ActiveMenuIcon: {
			source: 3,
			params: {
				schemaName: "CommunicationPanelEmailSchema",
				resourceItemName: "ActiveMenuIcon",
				hash: "043707680993738938752364032b940a",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});