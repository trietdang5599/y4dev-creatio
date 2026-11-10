define("CallSectionGridRowViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		StopCaption: "Stop",
		PlayCaption: "Play",
		PauseCaption: "Suspend",
		PlayErrorMessage: "Error while conversation playback. Error code: \u0027{0}\u0027"
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