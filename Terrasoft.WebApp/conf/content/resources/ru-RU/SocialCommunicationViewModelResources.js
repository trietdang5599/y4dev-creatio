define("SocialCommunicationViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ChoosePhoneTypeCaption: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0442\u0438\u043F \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0430",
		NoSynchronizationAccont: "\u0423 \u0432\u0430\u0441 \u043D\u0435 \u0434\u043E\u0431\u0430\u0432\u043B\u0435\u043D\u0430 \u0443\u0447\u0435\u0442\u043D\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C {0}. \u041E\u0431\u0440\u0430\u0442\u0438\u0442\u0435\u0441\u044C \u043A \u0441\u0438\u0441\u0442\u0435\u043C\u043D\u043E\u043C\u0443 \u0430\u0434\u043C\u0438\u043D\u0438\u0441\u0442\u0440\u0430\u0442\u043E\u0440\u0443.",
		DeleteCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C ",
		WrongEmailFormat: "\u041D\u0435\u043F\u0440\u0430\u0432\u0438\u043B\u044C\u043D\u044B\u0439 \u0444\u043E\u0440\u043C\u0430\u0442 Email",
		CommunicationTypePlaceholder: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0442\u0438\u043F",
		WrongSkypeFormat: "\u041D\u0435\u043F\u0440\u0430\u0432\u0438\u043B\u044C\u043D\u044B\u0439 \u0444\u043E\u0440\u043C\u0430\u0442 Skype",
		WrongPhoneFormat: "\u041D\u0435\u043F\u0440\u0430\u0432\u0438\u043B\u044C\u043D\u044B\u0439 \u0444\u043E\u0440\u043C\u0430\u0442",
		CommunicationAlreadyExist: "\u042D\u0442\u043E \u0441\u0440\u0435\u0434\u0441\u0442\u0432\u043E \u0441\u0432\u044F\u0437\u0438 \u0443\u0436\u0435 \u0443\u043A\u0430\u0437\u0430\u043D\u043E"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CallIcon: {
			source: 3,
			params: {
				schemaName: "SocialCommunicationViewModel",
				resourceItemName: "CallIcon",
				hash: "8e9ae7d81ae771eb769a432f0c486e88",
				resourceItemExtension: ".png"
			}
		},
		WebIcon: {
			source: 3,
			params: {
				schemaName: "SocialCommunicationViewModel",
				resourceItemName: "WebIcon",
				hash: "0f14365f0d6287160499dc06416aab84",
				resourceItemExtension: ".png"
			}
		},
		EmailIcon: {
			source: 3,
			params: {
				schemaName: "SocialCommunicationViewModel",
				resourceItemName: "EmailIcon",
				hash: "03da0c68be2402866d8fd134eb180065",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});