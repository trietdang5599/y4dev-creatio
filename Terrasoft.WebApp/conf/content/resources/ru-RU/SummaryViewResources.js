define("SummaryViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OpenSettingPageCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0438\u0442\u043E\u0433\u0438",
		OpenGridSettingsPageCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043A\u043E\u043B\u043E\u043D\u043A\u0438"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageDeleteButton: {
			source: 3,
			params: {
				schemaName: "SummaryView",
				resourceItemName: "ImageDeleteButton",
				hash: "2185ea9274f8cece0b49039f21947286",
				resourceItemExtension: ".png"
			}
		},
		ImageOpenButton: {
			source: 3,
			params: {
				schemaName: "SummaryView",
				resourceItemName: "ImageOpenButton",
				hash: "de93213e4131c0b5b91f465fde41f75a",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});