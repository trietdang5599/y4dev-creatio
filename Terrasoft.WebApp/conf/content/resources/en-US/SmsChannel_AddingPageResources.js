define("SmsChannel_AddingPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Token_placeholder: "Enter your Twilio account token",
		Token_label: "Token",
		ApplicationId_placeholder: "Enter your Twilio account SID",
		ApplicationId_label: "Application Id",
		PhoneNumber_caption: "Phone number",
		PhoneNumber_placeholder: "Enter phone number",
		PhoneNumber_label: "Phone number",
		CancelButton: "Cancel",
		ChatQueue_addRecord_caption: "Add new",
		ChatQueue_placeholder: "Select a queue for distributing chats",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "New SMS channel",
		Language_placeholder: "Select contact preferred language",
		Language_tooltip: "Creatio will set selected language as preferred language of contacts created through this channel. You can select only active languages. Go to the Languages lookup to activate/deactivate languages.",
		NewRecord: "New SMS channel",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "SMS channel adding page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});