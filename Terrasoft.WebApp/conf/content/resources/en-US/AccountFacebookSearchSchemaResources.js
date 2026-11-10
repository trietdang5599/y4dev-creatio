define("AccountFacebookSearchSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SearchTooltip: "Specify a link to the account\u2019s Facebook page."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		InfoSpriteImage: {
			source: 3,
			params: {
				schemaName: "AccountFacebookSearchSchema",
				resourceItemName: "InfoSpriteImage",
				hash: "c253d8a46fdd8595204eb650dd35e982",
				resourceItemExtension: ".png"
			}
		},
		SearchFacebookButtonImage: {
			source: 3,
			params: {
				schemaName: "AccountFacebookSearchSchema",
				resourceItemName: "SearchFacebookButtonImage",
				hash: "838676a2e02f94ebed274cd137a285de",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});