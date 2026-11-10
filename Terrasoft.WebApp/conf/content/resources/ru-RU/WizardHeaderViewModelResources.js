define("WizardHeaderViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NextButtonCaption: "\u0414\u0430\u043B\u0435\u0435",
		SaveButtonCaption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		CancelButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		SaveButtonHint: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C (Ctrl\u002BS)"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ArrowRight: {
			source: 3,
			params: {
				schemaName: "WizardHeaderViewModel",
				resourceItemName: "ArrowRight",
				hash: "cf200cad135f62e939ecd36b605ca779",
				resourceItemExtension: ".png"
			}
		},
		ArrowLeft: {
			source: 3,
			params: {
				schemaName: "WizardHeaderViewModel",
				resourceItemName: "ArrowLeft",
				hash: "32458735adefa9eaf9c557d63cc6950c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});