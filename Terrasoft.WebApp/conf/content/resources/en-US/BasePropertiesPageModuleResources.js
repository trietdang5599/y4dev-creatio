define("BasePropertiesPageModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButtonCaption: "Save",
		WrongCaptionLengthMessage: "The value cannot be longer than {0} characters",
		WrongColumnNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9.  Symbol: 0-9 cannot be first.",
		GeneralCaption: "General",
		HideInactiveLanguages: "Hide inactive languages",
		ShowAllLanguages: "Show all languages",
		CancelButtonCaption: "Cancel",
		ApplyButtonCaption: "Apply",
		CodeLabel: "Code",
		CaptionLabel: "Title",
		AppearenceCaption: "Appearence",
		AdvancedCaption: "Advanced",
		TooltipLabel: "Tooltip",
		WrongColumnNameWithPrefixMessage: "Selected value must be longer than prefix \u0022{0}\u0022"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});