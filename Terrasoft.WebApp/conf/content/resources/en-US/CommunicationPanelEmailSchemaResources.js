define("CommunicationPanelEmailSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddEmailButtonCaption: "New email",
		SynchronizeEmail: "Synchronize email",
		EmailBoxSettings: "Go to mailbox settings",
		MailboxSettingsEmpty: "Set up the mailbox synchronization to receive emails",
		IncomingEmail: "Incoming",
		OutgoingEmail: "Outgoing",
		DraftEmail: "Drafts",
		LoadingMessagesComplete: "Synchronization is started. We will notify you when it is completed.",
		EmailBoxNotProcessedCaption: "Not processed",
		EmailBoxIsProcessedCaption: "Processed",
		EditExistingAccount: "Edit email accounts",
		NewEmailAccountCaption: "New email account",
		EmailboxSyncSettingsInsertedTooltipCaption: "User account {0} was added successfully. You can \u003Ca data-context-mailserverid=\u0027{1}\u0027 href=\u0027#\u0027\u003Emodify\u003C/a\u003E its settings that are set by default.",
		OneNewMessage: "Show 1 new message",
		MoreThanOneNewMessage: "Show {0} new messages",
		AllMailboxesCaption: "All mailboxes",
		DiagnosticPageCaption: "Diagnostic tool",
		ManageServiceProviders: "Manage service providers"
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