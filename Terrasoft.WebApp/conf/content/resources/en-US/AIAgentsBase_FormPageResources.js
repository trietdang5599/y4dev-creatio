define("AIAgentsBase_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Description_tooltip: "Describe the agent\u0027s main tasks and functionality. This will help users and Creatio understand its purpose.",
		Description_placeholder: "Describe the agent\u0027s main tasks and functionality. This will help users and Creatio understand its purpose.",
		Label_Description_caption: "Description",
		LlmModel_tooltip: "Large language model that will be used during operation. If you don\u2019t select one, the system will use the default Creatio-hosted model.",
		LlmModel_placeholder: "Default",
		LlmModel_label: "Model",
		Code_label: "Code",
		Title_tooltip: "The name of your AI agent. It will be displayed to users.",
		Title_placeholder: "Enter the agent\u0027s name",
		AccessRightsExpansionPanel_title: "Permissions to execute",
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
		Caption: "Creatio.ai base agent form page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});