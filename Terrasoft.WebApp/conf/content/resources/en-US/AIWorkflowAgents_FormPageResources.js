define("AIWorkflowAgents_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WorkflowProcessNameTemplate: "{0} Process",
		SchemaAccessRightPlaceholder_caption: "Save the workflow agent to be able to edit its access rights.",
		SchemaAccessRightBindingInstruction_caption: "When exporting a workflow agent into a package, it is essential to manually configure access rights bindings.",
		SaveButton_clicked_params_messageTextAfterCompletion: "",
		AttachmentAddButtonCaption: "Upload",
		AttachmentRefreshButtonCaption: "Refresh",
		AttachmentsTabContainerCaption: "Attachments",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		Code_label: "Code",
		DefaultHeaderCaption: "Page title",
		Description_placeholder: "Describe the agent\u0027s main tasks and functionality. This will help users and Creatio understand its purpose.",
		Description_tooltip: "Describe the agent\u0027s main tasks and functionality. This will help users and Creatio understand its purpose.",
		FeedTabContainerCaption: "Feed",
		GeneralInfoTab_caption: "General information",
		Label_Description_caption: "Description",
		LlmModel_label: "Model",
		LlmModel_placeholder: "Default",
		LlmModel_tooltip: "Large language model that will be used during operation. If you don\u2019t select one, the system will use the default Creatio-hosted model.",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights",
		Title_placeholder: "Enter the agent\u0027s name",
		Title_tooltip: "The name of your AI agent. It will be displayed to users."
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Creatio.ai workflow agent form page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});