define("SyncSettingsErrorItemResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SpecifyNewPasswordLocalizableString: "\u0423\u043A\u0430\u0437\u0430\u0442\u044C \u043D\u043E\u0432\u044B\u0439 \u043F\u0430\u0440\u043E\u043B\u044C",
		OAuthAuthenticateLocalizableString: "\u041F\u043E\u0434\u043A\u043B\u044E\u0447\u0438\u0442\u044C \u043F\u043E\u0432\u0442\u043E\u0440\u043D\u043E",
		LinkToExchangeListenerServiceAcademyCaption: "\u0421\u0441\u044B\u043B\u043A\u0430 \u043D\u0430 \u0430\u043A\u0430\u0434\u0435\u043C\u0438\u044E",
		LinkToExchangeListenerServiceAcademyUrl: "http://academy.terrasoft.ru/documents/?product=user\u0026ver=7\u0026id=2074",
		LinkToEmailTroubleshootingAcademyCaption: "\u0423\u0441\u0442\u0440\u0430\u043D\u0435\u043D\u0438\u0435 \u043D\u0435\u043F\u043E\u043B\u0430\u0434\u043E\u043A email",
		LinkToConfigurationInstructions: "\u0418\u043D\u0441\u0442\u0440\u0443\u043A\u0446\u0438\u0438 \u043D\u0430 \u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438 Creatio",
		Dismiss: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C"
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