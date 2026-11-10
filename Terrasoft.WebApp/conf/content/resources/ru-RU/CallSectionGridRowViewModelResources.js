define("CallSectionGridRowViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		StopCaption: "\u041E\u0441\u0442\u0430\u043D\u043E\u0432\u0438\u0442\u044C",
		PlayCaption: "\u041F\u0440\u043E\u0441\u043B\u0443\u0448\u0430\u0442\u044C",
		PauseCaption: "\u041F\u0440\u0438\u043E\u0441\u0442\u0430\u043D\u043E\u0432\u0438\u0442\u044C",
		PlayErrorMessage: "\u041F\u0440\u0438 \u0432\u043E\u0441\u043F\u0440\u043E\u0438\u0437\u0432\u0435\u0434\u0435\u043D\u0438\u0438 \u0437\u0430\u043F\u0438\u0441\u0438 \u0440\u0430\u0437\u0433\u043E\u0432\u043E\u0440\u0430 \u0432\u043E\u0437\u043D\u0438\u043A\u043B\u0430 \u043E\u0448\u0438\u0431\u043A\u0430 \u0441 \u043A\u043E\u0434\u043E\u043C \u0027{0}\u0027"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		PauseImage: {
			source: 3,
			params: {
				schemaName: "CallSectionGridRowViewModel",
				resourceItemName: "PauseImage",
				hash: "0e97311da1b6a8c5bce410cc9904169c",
				resourceItemExtension: ".png"
			}
		},
		PlayImage: {
			source: 3,
			params: {
				schemaName: "CallSectionGridRowViewModel",
				resourceItemName: "PlayImage",
				hash: "2d672275ee365ff113c39db36e76a93b",
				resourceItemExtension: ".png"
			}
		},
		StopImage: {
			source: 3,
			params: {
				schemaName: "CallSectionGridRowViewModel",
				resourceItemName: "StopImage",
				hash: "9c2b7faff0ae0aebce2f1c7917367ea1",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});