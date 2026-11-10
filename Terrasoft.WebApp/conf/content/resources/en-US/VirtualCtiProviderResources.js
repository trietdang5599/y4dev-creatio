define("VirtualCtiProviderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CallNotFoundMessage: "Call with id \u0027{0}\u0027 was not found in active calls.",
		InvalidCallStateMessage: "Invalid state of the call with id \u0027{0}\u0027. Current state {1}, expected - {2}.",
		OrMessage: "or"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});