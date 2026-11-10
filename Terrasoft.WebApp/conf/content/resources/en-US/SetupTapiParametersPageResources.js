define("SetupTapiParametersPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		LineCaption: "Line",
		NumberCaption: "Number",
		CancelButtonCaption: "Cancel",
		DebugModeCaption: "Enable debugging",
		DisableCallCentreCaption: "Disable Call Center integration",
		FieldValidationError: "Field \u0022{0}\u0022: {1}",
		HeaderCaption: "TAPI parameters setup",
		SaveButtonCaption: "Save",
		UseBlindTransferCaption: "Use blind transfer"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});