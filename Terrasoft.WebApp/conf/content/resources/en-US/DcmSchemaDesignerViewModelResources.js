define("DcmSchemaDesignerViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DefaultStageCaption: "New Stage",
		DcmCaptionColumnCaption: "Case title",
		RemoveStageFromGroupMessage: "The \u0022{0}\u0022 stage will be excluded from the group. Do you wish to proceed?",
		AddStageToGroupMessage: "The \u0022{0}\u0022 stage will be grouped with the \u0022{1}\u0022 stage. Do you wish to proceed?",
		DcmSettingsIdNotFoundMessage: "DcmSettingsId not found.",
		SchemaFiltersCaption: "",
		RemoveDcmSchemaElementMessage: "If you remove the element \u0022{0}\u0022, element {1} will be performed right after the stage start. Do you wish to remove the element?",
		SavingCase: "Saving case",
		SchemaWasExported: "Case was exported. Saving changes in the current case may result in errors of the running case instances",
		SchemaCreatedInForeignMaintainerQuestion: "Case was created by a third-party publisher or imported from an archive file. Changes in this schema cannot be saved",
		ExistsRunningCasesQuestion: "Case has several running instances. Saving changes in the current case may result in errors of the running case instances",
		NeedSetActualSchemaVersionConfirmationMessage: "Set the current version of the case \u0022{0}\u0022 actual?"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});