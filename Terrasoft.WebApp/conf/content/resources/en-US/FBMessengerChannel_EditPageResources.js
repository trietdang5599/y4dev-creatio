define("FBMessengerChannel_EditPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FacebookPage_caption: "Rich text",
		FacebookPage_label: "Facebook page",
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
		Caption: "Facebook messenger channel edit page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});