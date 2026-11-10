define("SmsChannel_EditPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SmsChannel_caption: "SMS channel",
		SmsChannel_label: "SMS channel",
		SmsPhoneNumber_caption: "Phone number",
		SmsPhoneNumber_label: "Phone number",
		SaveButton_caption: "Save",
		CancelButton: "Cancel",
		ChatQueue_addRecord_caption: "Add new",
		ChatQueue_placeholder: "Select a queue for distributing chats",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		Language_placeholder: "Select contact preferred language",
		Language_tooltip: "Creatio will set selected language as preferred language of contacts created through this channel. You can select only active languages. Go to the Languages lookup to activate/deactivate languages.",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "SMS channel edit page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});