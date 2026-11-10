define("ClearConfActivityLogConfirmationModalPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ActionConnotBeLabel_caption: "This action cannot be undone.",
		AreYouSureLabel_caption: "Are you sure you want to clear Configuration activity log records created before the selected date?  \u200E",
		ClearRecordsButton_caption: "Clear log",
		PageTitle_caption: "Clear configuration activity log records?",
		ClearRecordsButton_clicked_params_messageTextAfterCompletion: "Deleting records\u2026 This may take a few seconds",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Clear configuration activity log records"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});