define("TelegramChannel_AddingPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Token_placeholder: "Enter Telegram bot token",
		Token_label: "Token",
		PageTitle_caption: "New Telegram channel",
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
		Caption: "Telegram channel adding page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});