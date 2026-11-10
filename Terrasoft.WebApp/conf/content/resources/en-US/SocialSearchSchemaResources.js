define("SocialSearchSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		HeaderCaption: "",
		SelectButtonCaption: "Select",
		CloseButtonCaption: "Cancel",
		SearchButtonCaption: "Search",
		SearchResultContainerCaption: "Select page",
		SearchResultCounterCaption: "Found:",
		SearchTooltip: "If you know the contact\u0027s (account\u0027s) web page, specify its link here and we will find it. This will speed up your search."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		InfoSpriteImage: {
			source: 3,
			params: {
				schemaName: "SocialSearchSchema",
				resourceItemName: "InfoSpriteImage",
				hash: "c253d8a46fdd8595204eb650dd35e982",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});