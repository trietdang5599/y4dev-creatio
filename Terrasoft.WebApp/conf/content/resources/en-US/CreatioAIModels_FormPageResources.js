define("CreatioAIModels_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ModelCaption: "Model",
		ConnectionSettingsExpansionPanel_title: "Connection settings",
		LLMTitle_tooltip: "Short title of your model, visible in LLM selection.",
		LLMDescription_tooltip: "A short description of your model visible in LLM selection.",
		LLMProvider_label: "LLM provider",
		AttachmentAddButtonCaption: "Upload",
		AttachmentRefreshButtonCaption: "Refresh",
		AttachmentsTabContainerCaption: "Attachments",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		FeedTabContainerCaption: "Feed",
		GeneralInfoTab_caption: "General information",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Creatio.ai models form page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});