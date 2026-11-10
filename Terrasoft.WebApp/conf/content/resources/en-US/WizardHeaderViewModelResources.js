define("WizardHeaderViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NextButtonCaption: "Next",
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		SaveButtonHint: "Save (Ctrl\u002BS)"
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