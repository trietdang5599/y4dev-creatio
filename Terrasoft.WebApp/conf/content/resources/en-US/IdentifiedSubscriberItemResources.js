define("IdentifiedSubscriberItemResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AccountIdentifiedPhoto: {
			source: 3,
			params: {
				schemaName: "IdentifiedSubscriberItem",
				resourceItemName: "AccountIdentifiedPhoto",
				hash: "7e38b8ec9f4f84e5030930ce2be8b53a",
				resourceItemExtension: ".png"
			}
		},
		ContactEmptyPhotoWhite: {
			source: 3,
			params: {
				schemaName: "IdentifiedSubscriberItem",
				resourceItemName: "ContactEmptyPhotoWhite",
				hash: "8da06cb2a0894f101e684dfe60fec84c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});