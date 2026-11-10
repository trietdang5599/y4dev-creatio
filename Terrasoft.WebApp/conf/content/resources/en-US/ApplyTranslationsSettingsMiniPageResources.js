define("ApplyTranslationsSettingsMiniPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WindowDescriptionLabel_caption: "You are about to run translations apply action. Once applied, the translations will become available in the Creatio interface. You can apply the changes for all languages or specific one. To apply the changes for a single language, check the box below.",
		addRecord_r4hmp8x_caption: "Add new",
		PageTitle_caption: "Apply translation settings",
		SaveButton_caption: "Apply",
		CloseButton_caption: "Close",
		CancelButton_caption: "Cancel",
		ApplyAllTranslationsForcedlyCheckbox_tooltip: "Select the checkbox to apply all translations for the language. This is useful if you need to make data between runtime and the Translation section consistent. ",
		ApplySpecificLanguageCheckbox_tooltip: "Select the checkbox to choose a specific language to apply translations. This is useful if you want to execute the process faster or if translations for all languages are not verified. Leave the checkbox clear to apply changes for all languages. ",
		SkipTranslationsValidationCheckbox_tooltip: "Select the checkbox if you do not need Creatio to perform automatic translation validation and provide you with a report after the process is finished. This can be useful in cases where you need to apply translations to a limited number of records and can check the results manually, without extending the process time. ",
		addRecord_y8l2200_caption: "",
		ExpansionPanel_AdvancedSettings_title: "Advanced settings",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {
		Language: "Language",
		ApplyAllTranslationsForcedly: "Force apply all translations",
		UseSpecifiedLanguageOnly: "Apply translations for specified language",
		SkipTranslationsValidationAfterApply: "Skip translation validation after they are applied",
		LocalizationPackage: "Save localization to package"
	};
	var propertiesLocalizableStrings = {
		Caption: "Apply translations settings mini page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});