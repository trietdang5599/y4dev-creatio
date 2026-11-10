define("CustomModel_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		JsonConfig_tooltip: "JSON configuration for the model. Include model name and optional parameters like temperature (0-2), max_tokens, top_p, frequency_penalty, and presence_penalty.\n\nExample: {\u0022model\u0022: \u0022openai/gpt-4\u0022, \u0022temperature\u0022: 0.7, \u0022max_tokens\u0022: 2000}\n\nLearn more: https://docs.litellm.ai/docs/completion/input",
		JsonConfig_placeholder: "Enter model configuration in JSON format. Example: {\u0022model\u0022: \u0022openai/gpt-4\u0022, \u0022temperature\u0022: 0.7, \u0022max_tokens\u0022: 2000}",
		SetupGuideLink_caption: "Custom model setup guide",
		Label_ImportantNotesAndGuides_caption: "To set up the custom provider, you need to create a connection string. For details, follow the link in the documentation",
		ImportantNotesAndGuidesPanelExpansionPanel_title: "Important notes and guides",
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
		ModelCaption: "Model",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "CustomModel_FormPage"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});