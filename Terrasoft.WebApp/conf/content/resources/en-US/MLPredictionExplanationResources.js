define("MLPredictionExplanationResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ScoreServiceErrorMessage: "Action has been finished with failure. You can find details in the application log",
		PredictedValueCaption: "Predicted value",
		FeatureCaption: "Predictor",
		WeightCaption: "Weight"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "MLPredictionExplanation",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});