define("SocialMessagePublisherPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WritePostHint: "\u0412\u0430\u0448\u0435 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435 \u0431\u0443\u0434\u0435\u0442 \u0434\u043E\u0441\u0442\u0443\u043F\u043D\u043E \u0442\u043E\u043B\u044C\u043A\u043E \u0432\u043D\u0443\u0442\u0440\u0435\u043D\u043D\u0438\u043C \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u044F\u043C",
		SocialMaskCaption: "\u0412\u043D\u0443\u0442\u0440\u0435\u043D\u043D\u0438\u0439 \u043A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0439 \u0434\u043E\u0431\u0430\u0432\u043B\u0435\u043D \u0432 \u043B\u0435\u043D\u0442\u0443",
		WritePostHintOnPortal: "\u0412\u0432\u0435\u0434\u0438\u0442\u0435 \u0441\u0432\u043E\u0439 \u0432\u043E\u043F\u0440\u043E\u0441 \u0438 \u043D\u0430\u0436\u043C\u0438\u0442\u0435 \u041E\u041F\u0423\u0411\u041B\u0418\u041A\u041E\u0412\u0410\u0422\u042C",
		TemplateButtonCaption: "\u0428\u0430\u0431\u043B\u043E\u043D\u044B",
		SetupTemplates: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0448\u0430\u0431\u043B\u043E\u043D\u044B"
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