define("EmailSyncSettingsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		LoadAllMessages: "Download all emails from mailbox",
		LoadFromFolders: "Download emails from customized folders",
		NotSetSendingOrReceivingCheckMessage: "Please, select either the \u0022Enable email receiving\u0022 or \u0022Use mailbox to send messages\u0022 setting.",
		FieldValidationError: "Field \u0022Synchronization period\u0022: Specify the value",
		UseMailboxAsDefaultTpl: "Use \u0022{0}\u0022 as default mailbox when sending emails",
		MailboxRightsDetailCaption: "Which access rights to add?",
		EmailDefRightsDetailCaption: "Emails from this mailbox access rights",
		RightsEmpty: "No data",
		UserRoleCaption: "User / Role",
		MailboxEmailsRightsDetailCaption: "Which access rights to add?",
		SendAccess: "Send emails",
		ContentAccess: "Access emails",
		EditAccess: "Setup mailbox",
		SynchronizationHelpMsg: "Select emails to download. Downloaded emails would be saved to Creatio and linked to customer records",
		SendHelpMsg: "Setup signature and default mailbox for sending emails from Creatio",
		SharedMailboxsHelpMsg: "Allow other users to send emails using this mailbox or access emails downloaded from this  mailbox",
		DownloadFromFoldersValidationError: "While loading letters from folders, at least one folder from the list must be selected",
		FieldValidationErrorTemplate: "Field \u0022{0}\u0022: Specify the value"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteImage: {
			source: 3,
			params: {
				schemaName: "EmailSyncSettings",
				resourceItemName: "DeleteImage",
				hash: "44eb99cfc918ebe3431ac73b384f81d6",
				resourceItemExtension: ".svg"
			}
		},
		EditImage: {
			source: 3,
			params: {
				schemaName: "EmailSyncSettings",
				resourceItemName: "EditImage",
				hash: "75a71305408bcad3e962e4140ded181e",
				resourceItemExtension: ".svg"
			}
		},
		ReadImage: {
			source: 3,
			params: {
				schemaName: "EmailSyncSettings",
				resourceItemName: "ReadImage",
				hash: "9dc688c941c704118a142509ce11b828",
				resourceItemExtension: ".svg"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "EmailSyncSettings",
				resourceItemName: "AddButtonImage",
				hash: "7bc1980b519205382d39ea022bd498f8",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});