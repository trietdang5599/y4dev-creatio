define("CtiConstantsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		LicenseNotFoundMessage: "There is no phone connector license or it has expired. Required operations: {0}",
		SysMsgLibSettingsEmptyMessage: "The \u0022Message exchange library\u0022 system setting is not set up",
		ConnectionConfigIncorrectMessage: "Unable to receive telephony connection parameters. Set up parameters in the \u0022Call center parameters setup\u0022 menu of the user profile",
		ConnectionConfigEmptyMessage: "Telephony connection parameters not found. Set up parameters in the \u0022Call center parameters setup\u0022 menu of the user profile.",
		ActiveAgentStateCaption: "Active"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});