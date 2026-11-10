define("AzureModel_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		APIVersion_tooltip: "The required API version for your Azure deployment (e.g., 2024-02-01).",
		APIVersion_placeholder: "e.g., 2024-02-01",
		AzureResourceName_tooltip: "Enter the unique Azure Resource Name (e.g., my-company-ai). The full endpoint will be generated automatically.",
		AzureResourceName_placeholder: "e.g., my-openai-instance",
		APIKey_tooltip: "Provide the authentication key or token issued by your LLM provider. Required for secure access to the API.",
		ModelName_tooltip: "Specify the identifier of the model or Azure deployment. It must match a name supported by your API provider.",
		ModelName_placeholder: "e.g., gpt-4.1",
		SetRecordRightsButton_caption: "Set up access rights",
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
		Caption: "AzureModel_FormPage"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});