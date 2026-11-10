define("EmailItemSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ViewModuleUrl: "ViewModule.aspx#",
		RunProcessMenuSeparator: "Run process",
		Delete: "Delete",
		DeleteConfirmationMessage: "Are you sure that you want to delete the selected items?",
		DependencyWarningMessage: "Selected items cannot be deleted because they are used in other objects.",
		RightLevelWarningMessage: "You do not have permission to delete these items.",
		MarkAsProcessed: "Mark as processed",
		Today: "Today",
		ConnectTo: "Connect to {0}",
		Yesterday: "Yesterday",
		ReadRightLevelWarningMessage: "You do not have permissions to read this contact.",
		AddRelationColumnCollectionCaption: "Add new",
		LinkRelationColumnCollectionCaption: "Link email to",
		ShowRelatedEmails: "Show related",
		ConfirmUpdateAllInChain: "Link all emails from the conversation with this record?",
		UpdateAllInChainOk: "Successfully updated {0} emails",
		UpdateAllInChainFail: "Email relations update failed"
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