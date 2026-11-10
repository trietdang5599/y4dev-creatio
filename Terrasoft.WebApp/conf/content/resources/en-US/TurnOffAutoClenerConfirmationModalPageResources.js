define("TurnOffAutoClenerConfirmationModalPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WithoutCleanupLabel_caption: "Without cleanup, log records will continue  \u200E",
		CancelButton_caption: "Cancel",
		AreYouSureLabel_caption: "Are you sure you want to disable automatic cleanup of the Configuration activity log?",
		YesButton_caption: "Disable cleanup",
		PageTitle_caption: "Disable automatic cleanup?",
		StorageDataLabel_caption: "amount of stored data.",
		MayLabel_caption: "may significantly increase the  \u200E",
		ToAccumulateLabel_caption: " to accumulate and  \u200E",
		YesButton_clicked_params_messageTextAfterCompletion: "Automatic cleanup of the Configuration activity log is disabled.",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Disable automatic cleanup?"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});