define("SubscriberSearchResultItemResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ContactEmptyPhotoWhite: {
			source: 3,
			params: {
				schemaName: "SubscriberSearchResultItem",
				resourceItemName: "ContactEmptyPhotoWhite",
				hash: "8da06cb2a0894f101e684dfe60fec84c",
				resourceItemExtension: ".png"
			}
		},
		AccountIdentifiedPhoto: {
			source: 3,
			params: {
				schemaName: "SubscriberSearchResultItem",
				resourceItemName: "AccountIdentifiedPhoto",
				hash: "7e38b8ec9f4f84e5030930ce2be8b53a",
				resourceItemExtension: ".png"
			}
		},
		MakeCallButtonIcon: {
			source: 3,
			params: {
				schemaName: "SubscriberSearchResultItem",
				resourceItemName: "MakeCallButtonIcon",
				hash: "75e43ae61b43c09e66573ad20a28bb62",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});