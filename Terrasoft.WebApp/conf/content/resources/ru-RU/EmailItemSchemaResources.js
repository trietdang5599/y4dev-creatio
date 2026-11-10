define("EmailItemSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ViewModuleUrl: "ViewModule.aspx#",
		RunProcessMenuSeparator: "\u0417\u0430\u043F\u0443\u0441\u0442\u0438\u0442\u044C \u043F\u0440\u043E\u0446\u0435\u0441\u0441",
		Delete: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		DeleteConfirmationMessage: "\u0412\u044B \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u0445\u043E\u0442\u0438\u0442\u0435 \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u0432\u044B\u0434\u0435\u043B\u0435\u043D\u043D\u044B\u0435 \u044D\u043B\u0435\u043C\u0435\u043D\u0442\u044B?",
		DependencyWarningMessage: "\u0412\u044B\u0431\u0440\u0430\u043D\u043D\u044B\u0435 \u044D\u043B\u0435\u043C\u0435\u043D\u0442\u044B \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u043D\u0435\u0432\u043E\u0437\u043C\u043E\u0436\u043D\u043E, \u0442\u0430\u043A \u043A\u0430\u043A \u043E\u043D\u0438 \u0438\u0441\u043F\u043E\u043B\u044C\u0437\u0443\u044E\u0442\u0441\u044F \u0432 \u0434\u0440\u0443\u0433\u0438\u0445 \u043E\u0431\u044A\u0435\u043A\u0442\u0430\u0445.",
		RightLevelWarningMessage: "\u0412\u044B\u0431\u0440\u0430\u043D\u043D\u044B\u0435 \u044D\u043B\u0435\u043C\u0435\u043D\u0442\u044B \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u043D\u0435\u0432\u043E\u0437\u043C\u043E\u0436\u043D\u043E, \u0442\u0430\u043A \u043A\u0430\u043A \u0443 \u0412\u0430\u0441 \u043D\u0435\u0442 \u043F\u0440\u0430\u0432 \u043D\u0430 \u0443\u0434\u0430\u043B\u0435\u043D\u0438\u0435 \u044D\u0442\u0438\u0445 \u044D\u043B\u0435\u043C\u0435\u043D\u0442\u043E\u0432.",
		MarkAsProcessed: "\u041E\u0431\u0440\u0430\u0431\u043E\u0442\u0430\u0442\u044C",
		Today: "\u0421\u0435\u0433\u043E\u0434\u043D\u044F",
		ConnectTo: "\u041F\u0440\u0438\u0432\u044F\u0437\u0430\u0442\u044C \u043A {0}",
		Yesterday: "\u0412\u0447\u0435\u0440\u0430",
		ReadRightLevelWarningMessage: "\u0423 \u0412\u0430\u0441 \u043D\u0435\u0442 \u043F\u0440\u0430\u0432 \u043D\u0430 \u0447\u0442\u0435\u043D\u0438\u0435 \u044D\u0442\u043E\u0433\u043E \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u0430.",
		AddRelationColumnCollectionCaption: "\u0421\u043E\u0437\u0434\u0430\u0442\u044C \u043D\u043E\u0432\u044B\u0439",
		LinkRelationColumnCollectionCaption: "\u0421\u0432\u044F\u0437\u0430\u0442\u044C \u043F\u0438\u0441\u044C\u043C\u043E \u0441 \u0441\u0443\u0449\u0435\u0441\u0442\u0432\u0443\u044E\u0449\u0438\u043C",
		ShowRelatedEmails: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u0441\u0432\u044F\u0437\u0430\u043D\u043D\u044B\u0435",
		ConfirmUpdateAllInChain: "\u0421\u0432\u044F\u0437\u0430\u0442\u044C \u0441 \u044D\u0442\u043E\u0439 \u0437\u0430\u043F\u0438\u0441\u044C\u044E \u0432\u0441\u0435 \u043F\u0438\u0441\u044C\u043C\u0430 \u0438\u0437 \u0446\u0435\u043F\u043E\u0447\u043A\u0438?",
		UpdateAllInChainOk: "\u0423\u0441\u043F\u0435\u0448\u043D\u043E \u043E\u0431\u043D\u043E\u0432\u043B\u0435\u043D\u043E {0} \u043F\u0438\u0441\u0435\u043C",
		UpdateAllInChainFail: "\u041D\u0435 \u0443\u0434\u0430\u043B\u043E\u0441\u044C \u043E\u0431\u043D\u043E\u0432\u0438\u0442\u044C \u0441\u0432\u044F\u0437\u0438 \u043F\u0438\u0441\u0435\u043C"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultPhoto: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "DefaultPhoto",
				hash: "7c719b318f2d4d210c9bec4991dabfc9",
				resourceItemExtension: ".png"
			}
		},
		ActionsButtonImage: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "ActionsButtonImage",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "ApplyButtonImage",
				hash: "88768289520a58c95c434b7c53ee902c",
				resourceItemExtension: ".png"
			}
		},
		AccountDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "AccountDefaultIcon",
				hash: "ac2838bba823b861a25431fe22ac3c3c",
				resourceItemExtension: ".png"
			}
		},
		ContactDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "ContactDefaultIcon",
				hash: "fa31ab8e8c57eb1888e1f2bd10bd81f8",
				resourceItemExtension: ".png"
			}
		},
		OpportunityDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "OpportunityDefaultIcon",
				hash: "29f785c4908a71b0e807ded9bf4e5203",
				resourceItemExtension: ".png"
			}
		},
		DocumentDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "DocumentDefaultIcon",
				hash: "2f3e891e037a3dcd01fc889e0265b706",
				resourceItemExtension: ".png"
			}
		},
		LeadDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "LeadDefaultIcon",
				hash: "3bf95459c48240616912f4ba8f283f3e",
				resourceItemExtension: ".png"
			}
		},
		OrderDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "OrderDefaultIcon",
				hash: "4c163d528cb92de31fc7c6932c75e27c",
				resourceItemExtension: ".png"
			}
		},
		ContractDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "ContractDefaultIcon"
			}
		},
		ActivityConnectionDefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "ActivityConnectionDefaultIcon",
				hash: "006737fa2ca100880ba3db1fce4bafd1",
				resourceItemExtension: ".png"
			}
		},
		RelationsImage: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "RelationsImage",
				hash: "f589bcfcdde710b8225b98a6f518ba3e",
				resourceItemExtension: ".png"
			}
		},
		DeleteEmailButtonImage: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "DeleteEmailButtonImage",
				hash: "8ed04e4c8ba5f2d12f8cb5177f61be74",
				resourceItemExtension: ".png"
			}
		},
		ContactEnrichmentIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "ContactEnrichmentIcon",
				hash: "588f9021245791159b6a98d86790d502",
				resourceItemExtension: ".svg"
			}
		},
		AttachmentsIcon: {
			source: 3,
			params: {
				schemaName: "EmailItemSchema",
				resourceItemName: "AttachmentsIcon",
				hash: "dd6599e5225015a2c48502bdca409f6b",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});