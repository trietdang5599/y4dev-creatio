define("SocialMessagePublisherPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WritePostHint: "Your post will only be visible to internal users",
		SocialMaskCaption: "Post is published to feed",
		WritePostHintOnPortal: "Write your question and press PUBLISH",
		TemplateButtonCaption: "Templates",
		SetupTemplates: "Setup Templates"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultCreatedBy: {
			source: 3,
			params: {
				schemaName: "SocialMessagePublisherPage",
				resourceItemName: "DefaultCreatedBy",
				hash: "2699ad04824ff3164c06bcd3740a4062",
				resourceItemExtension: ".png"
			}
		},
		TemplateButtonImage: {
			source: 3,
			params: {
				schemaName: "SocialMessagePublisherPage",
				resourceItemName: "TemplateButtonImage",
				hash: "cab55b7fe67011de8d606f8a7ae2ed6c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});