define("TranslationActualizationSettingsMiniPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButton_caption: "Update",
		Label_uf3ltxt_caption: "You are about to start translation update. Once it is finished, you will receive notification in communication panel. New values will become available in the section. ",
		PageTitle_caption: "Translation update settings",
		WarningDescriptionCaption: "Please note that actualization that during actualization performed from scrutch the changes in translations that were previously made, but were not applied will be lost. Apply your changes before running translations update from scratch",
		WarningTitleCaption: "Important",
		Label_jncep89_caption: "If you run update from scratch, all translation changes that were previously made but not applied will be lost. Apply changes before running translation update from scratch ",
		CancelButton_caption: "Cancel",
		CloseButton_caption: "Close",
		Checkbox_eias582_tooltip: "When you run update from scratch, section values are deleted and populated from the beginning. Make sure that all edited values are applied before running such update ",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {
		RunActualizationFromScratch: "Run update from scratch"
	};
	var propertiesLocalizableStrings = {
		Caption: "Translation actualization settings"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});