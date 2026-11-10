define("MiniPage_ClearConfActivityLogResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CancelButtonLabel: "Cancel",
		PageTitleText: "Delete records",
		ConfirmDeleteButtonCaption: "Delete records",
		BeDeletedText: "be deleted",
		NotLabelText: "NOT \u200E",
		RecordCreatedOnText: "Records created on this date will \u200E",
		ActionCannotBeUndoneText: "permanently deleted. The action cannot be undone.",
		SelectedDateText: "the selected date will be",
		BeforeText: "before  \u200E",
		RecordsCreatedText: "Records created \u200E",
		ConfirmDeleteSuccessMessage: "Deleting records\u2026 This may take a few seconds",
		CloseButtonLabel: "Close",
		ConfirmDeleteButton_caption: "Clear log",
		BeDeletedLabel_caption: "be cleared",
		ActionCannotBeUndoneLabel_caption: "permanently cleared. The action cannot be undone.",
		PageTitle_caption: "Clear configuration activity log",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record"
	};
	var parametersLocalizableStrings = {
		DeleteRecordsBefore: "Clear records created before"
	};
	var propertiesLocalizableStrings = {
		Caption: "Configuration activity log cleaner modal page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});