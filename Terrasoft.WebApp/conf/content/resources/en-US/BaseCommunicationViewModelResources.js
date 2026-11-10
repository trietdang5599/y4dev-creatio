define("BaseCommunicationViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NoSynchronizationAccont: "You do not have the {0} account added. Contact your system administrator.",
		DeleteCaption: "Delete ",
		WrongEmailFormat: "Invalid email format",
		CommunicationTypePlaceholder: "Select type",
		WrongSkypeFormat: "Invalid Skype format",
		WrongPhoneFormat: "Invalid format",
		CommunicationAlreadyExist: "This communication option is already entered"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CallIcon: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationViewModel",
				resourceItemName: "CallIcon",
				hash: "8e9ae7d81ae771eb769a432f0c486e88",
				resourceItemExtension: ".png"
			}
		},
		WebIcon: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationViewModel",
				resourceItemName: "WebIcon",
				hash: "0f14365f0d6287160499dc06416aab84",
				resourceItemExtension: ".png"
			}
		},
		EmailIcon: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationViewModel",
				resourceItemName: "EmailIcon",
				hash: "03da0c68be2402866d8fd134eb180065",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});