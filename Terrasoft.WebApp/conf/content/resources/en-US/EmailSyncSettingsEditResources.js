define("EmailSyncSettingsEditResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddNewServer: "Add New Server",
		AddToCommunicationDetail: "Add email to contact communication detail ?",
		AuthorizationTo: "Authorization to",
		BackToServerList: "Choose another service",
		Cancel: "Cancel",
		ChangeExistingSettingsMessage: "The {0} email account credentials has been successfully updated. Do you wish to download all emails for the last week?",
		ChangeSettingsButtonCaption: "CHANGE SETTINGS",
		ChangeSettingsMessage: "The email account {0} has been successfully added. Do you wish to download all emails for the last week?",
		CheckGoogleSettingsMessage: "Your email or password is incorrect. If you have 2-Step-Verification enabled - please use the \u003Ca href=\u0027https://support.google.com/accounts/answer/185833?hl=en\u0027 target=\u0027blank\u0027\u003Eapp password\u003C/a\u003E.",
		CheckOfficeSettingsMessage: "Your email or password is incorrect. If you have 2-Step-Verification enabled - please use the \u003Ca href=\u0027https://support.microsoft.com/en-us/account-billing/using-app-passwords-with-apps-that-don-t-support-two-step-verification-5896ed9b-4263-e681-128a-a6f2979a7944\u0027 target=\u0027blank\u0027\u003Eapp password\u003C/a\u003E.",
		EnterEmail: "New email account",
		ExchangeListenerNotDeployed: "The ExchangeListener service is not deployed. Please contact your system administrator. The deployment instructions are available on \u003Ca href=\u0027{0}\u0027 target=\u0027blank\u0027\u003ECreatio Academy\u003C/a\u003E.",
		LinkToExchangeListenerServiceAcademyCaption: "Link to Academy",
		LinkToExchangeListenerServiceAcademyUrl: "http://academy.creatio.com/documents/?product=user\u0026ver=7\u0026id=2074",
		LoginError: "Your email or password is incorrect. Please check the \u003Ca href=\u0027{0}\u0027 target=\u0027blank\u0027\u003EEmail troubleshooting section\u003C/a\u003E on the Academy.",
		MailboxExist: "This account already created by user {0}. Change the email or request access to an existing account.",
		Next: "Next",
		Other: " Unable to add an account . Contact your system administrator",
		SelectMailService: "Select mail service",
		SignIn: "Sign In",
		TypeEmailAddress: "email@domain.com",
		TypePassword: "Password",
		TypeUserName: "User name"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "EmailSyncSettingsEdit",
				resourceItemName: "DefaultIcon",
				hash: "e9154c61cddcacd9f3ec93c9e0368425",
				resourceItemExtension: ".png"
			}
		},
		CloseModal: {
			source: 3,
			params: {
				schemaName: "EmailSyncSettingsEdit",
				resourceItemName: "CloseModal",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		ErrorIcon: {
			source: 3,
			params: {
				schemaName: "EmailSyncSettingsEdit",
				resourceItemName: "ErrorIcon",
				hash: "04a5c38f6c374acc1d1620a916062fbe",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});