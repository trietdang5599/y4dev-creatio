define("BaseSyncSettingsEditResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MailboxExist: "This account already created by user {0}. Change the email or request access to an existing account.",
		Other: " Unable to add an account . Contact your system administrator",
		LoginError: "Your email or password is incorrect. Please check the \u003Ca href=\u0027{0}\u0027 target=\u0027blank\u0027\u003EEmail troubleshooting section\u003C/a\u003E on the Academy.",
		SelectMailService: "Select mail service",
		AddNewServer: "Add New Server",
		Cancel: "Cancel",
		AuthorizationTo: "Authorization to",
		TypeEmailAddress: "email@domain.com",
		TypeUserName: "User name",
		TypePassword: "Password",
		SignIn: "Sign In",
		BackToServerList: "Choose another service",
		AddToCommunicationDetail: "Add email to contact communication detail ?",
		CheckGoogleSettingsMessage: "Your email or password is incorrect. If you have 2-Step-Verification enabled - please use the \u003Ca href=\u0027https://support.google.com/accounts/answer/185833?hl=en\u0027 target=\u0027blank\u0027\u003Eapp password\u003C/a\u003E.",
		ChangeSettingsButtonCaption: "CHANGE SETTINGS",
		ChangeSettingsMessage: "The email account {0} has been successfully added. Do you wish to download all emails for the last week?",
		EnterEmail: "New email account",
		Next: "Next",
		ChangeExistingSettingsMessage: "The {0} email account credentials has been successfully updated. Do you wish to download all emails for the last week?",
		LinkToExchangeListenerServiceAcademyCaption: "Link to Academy",
		LinkToExchangeListenerServiceAcademyUrl: "http://academy.creatio.com/documents/?product=user\u0026ver=7\u0026id=2074",
		ExchangeListenerNotDeployed: "The ExchangeListener service is not deployed. Please contact your system administrator. The deployment instructions are available on \u003Ca href=\u0027{0}\u0027 target=\u0027blank\u0027\u003ECreatio Academy\u003C/a\u003E.",
		CheckOfficeSettingsMessage: "Your email or password is incorrect. If you have 2-Step-Verification enabled - please use the \u003Ca href=\u0027https://support.microsoft.com/en-us/account-billing/using-app-passwords-with-apps-that-don-t-support-two-step-verification-5896ed9b-4263-e681-128a-a6f2979a7944\u0027 target=\u0027blank\u0027\u003Eapp password\u003C/a\u003E."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "BaseSyncSettingsEdit",
				resourceItemName: "DefaultIcon",
				hash: "e9154c61cddcacd9f3ec93c9e0368425",
				resourceItemExtension: ".png"
			}
		},
		CloseModal: {
			source: 3,
			params: {
				schemaName: "BaseSyncSettingsEdit",
				resourceItemName: "CloseModal",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		ErrorIcon: {
			source: 3,
			params: {
				schemaName: "BaseSyncSettingsEdit",
				resourceItemName: "ErrorIcon",
				hash: "04a5c38f6c374acc1d1620a916062fbe",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});