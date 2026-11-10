define("SetRuleForCleanerConfActivityLogModalPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MinValidatorMessage: "Enter a number of days greater than or equal to 1",
		RecordsNewerLabel_caption: "Records newer than this will be kept. Cleanup runs automatically once per day",
		RecordsOlderLabel_caption: "Records older than the specified number of  \u200E",
		DeleteRecordsOlderThanDaysNumberInput_tooltip: "Specify the number of days to keep log records. Set the value to 0 to disable automatic cleanup.",
		TurnedOffLabel_caption: "is disabled.  \u200E",
		AutomaticDataCleanupLabel_caption: "Automatic data cleanup for the  \u200E",
		SaveChangesButton_caption: "Save changes",
		RecordsLabel_caption: " to accumulate and may  \u200E",
		WithoutLabel_caption: "Without cleanup, log  \u200E",
		AutomaticallyDeletedLabel_caption: "automatically deleted  \u200E",
		DaysWillBeLabel_caption: "days will be  \u200E",
		SignificantlyLabel_caption: "significantly  \u200E",
		ActivityLogLabel_caption: "activity log  \u200E",
		ConfigurationLabel_caption: "configuration  \u200E",
		SaveChangesButton_clicked_params_messageTextAfterCompletion: "Configuration activity log cleanup period updated",
		HelpsLabel_caption: "helps keep the table\u200E clean and improves performance.",
		AmountLabel_caption: "amount of stored data.",
		EnableCleanUpCheckbox_label: "Enable automatica data cleanup",
		ByScheduledLabel_caption: "by a scheduled process. This  \u200E",
		RecordsWillLabel_caption: "records will continue  \u200E",
		IncraseStorageLabel_caption: "increase the   \u200E ",
		Button_ConfirmDelete_caption: "Save changes",
		Button_ConfirmDelete_clicked_params_messageTextAfterCompletion: "Deleting records\u2026 This may take a few seconds",
		Button_n7dff8e: "Save",
		CancelButton: "Cancel",
		CancelButton_caption: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		Label_ActionCannotBeUndone_caption: "by a",
		Label_BeDeleted_caption: "be deleted",
		Label_Before_caption: "automatically deleted  \u200E",
		Label_Not_caption: "NOT \u200E",
		Label_RecordCreatedOn_caption: "Records newer than this will be kept Cleanup runs automatically once per day",
		Label_RecordsCreated_caption: "Records older than the specified number of",
		Label_SelectedDate_caption: "days will be  \u200E",
		NewRecord: "New record",
		PageTitle_caption: "Automatic data cleanup",
		Record: "Record"
	};
	var parametersLocalizableStrings = {
		DeleteRecordsOlderThan: "Keep records for (days)",
		EnableCleanUp: "Enable automatic data cleanup"
	};
	var propertiesLocalizableStrings = {
		Caption: "Configuration activity log auto cleaner modal page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});