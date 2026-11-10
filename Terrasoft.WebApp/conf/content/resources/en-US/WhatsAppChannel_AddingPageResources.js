define("WhatsAppChannel_AddingPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Token_placeholder: "Enter your Twilio account token",
		Token_label: "Token",
		ApplicationId_placeholder: "Enter your Twilio account SID",
		ApplicationId_label: "Application Id",
		PhoneNumber_label: "Phone number",
		PhoneNumber_caption: "Phone number",
		PageTitle_caption: "New WhatsApp channel",
		PhoneNumber_placeholder: "Enter WhatsApp phone number",
		addRecord_e6g78i2_caption: "Add new",
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
		Caption: "WhatsApp channel adding page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});