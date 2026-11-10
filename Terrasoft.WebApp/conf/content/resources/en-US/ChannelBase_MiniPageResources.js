define("ChannelBase_MiniPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Language_tooltip: "Creatio will set selected language as preferred language of contacts created through this channel. You can select only active languages. Go to the Languages lookup to activate/deactivate languages.",
		Language_placeholder: "Select contact preferred language",
		ChatQueue_addRecord_caption: "Add new",
		ChatQueue_placeholder: "Select a queue for distributing chats",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Channel base mini page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});