define("OpenAIModel_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Input_35ncsgt_tooltip: "Enter the full endpoint URL for your LLM provider\u2019s API. This is where the system will send requests.",
		Input_35ncsgt_placeholder: "https://",
		SetRecordRightsButton_caption: "Set up access rights",
		Apikey_tooltip: "Provide the authentication key or token issued by your LLM provider. Required for secure access to the API.",
		ModelName_tooltip: "Specify the exact identifier of the model you want to use. Must match the model name supported by your provider.",
		ModelName_placeholder: "e.g., gpt-4.1",
		AttachmentAddButtonCaption: "Upload",
		AttachmentRefreshButtonCaption: "Refresh",
		AttachmentsTabContainerCaption: "Attachments",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ConnectionSettingsExpansionPanel_title: "Connection settings",
		DefaultHeaderCaption: "Page title",
		FeedTabContainerCaption: "Feed",
		GeneralInfoTab_caption: "General information",
		LLMDescription_tooltip: "A short description of your model visible in LLM selection.",
		LLMProvider_label: "LLM provider",
		LLMTitle_tooltip: "Short title of your model, visible in LLM selection.",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "OpenAIModel_FormPage"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});