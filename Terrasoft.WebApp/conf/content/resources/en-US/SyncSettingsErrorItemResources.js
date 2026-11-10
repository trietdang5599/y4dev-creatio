define("SyncSettingsErrorItemResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SpecifyNewPasswordLocalizableString: "Specify new password",
		OAuthAuthenticateLocalizableString: "Connect mailbox again",
		LinkToExchangeListenerServiceAcademyCaption: "Link to Academy",
		LinkToExchangeListenerServiceAcademyUrl: "http://academy.creatio.com/documents/?product=user\u0026ver=7\u0026id=2074",
		LinkToEmailTroubleshootingAcademyCaption: "Email Troubleshooting",
		LinkToConfigurationInstructions: "Configuration instructions in Creatio Academy",
		Dismiss: "Dismiss"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ErrorIcon: {
			source: 3,
			params: {
				schemaName: "SyncSettingsErrorItem",
				resourceItemName: "ErrorIcon",
				hash: "a9764d737d1f266d77ebf7885c6fadc4",
				resourceItemExtension: ".svg"
			}
		},
		WarningIcon: {
			source: 3,
			params: {
				schemaName: "SyncSettingsErrorItem",
				resourceItemName: "WarningIcon",
				hash: "61d18199a1ba74c4f765c7e11c1ca4cb",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});