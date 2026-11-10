define("AccountFacebookSearchSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SearchTooltip: "\u0423\u043A\u0430\u0436\u0438\u0442\u0435 \u0441\u0441\u044B\u043B\u043A\u0443 \u043D\u0430 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443 \u043A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442\u0430 \u0432 Facebook."
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