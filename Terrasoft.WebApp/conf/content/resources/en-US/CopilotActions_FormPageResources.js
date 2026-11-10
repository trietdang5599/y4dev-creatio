define("CopilotActions_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Type_label: "Type",
		Type_ariaLabel: "Dropdown",
		Code_label: "Code",
		Description_label: "Description",
		Name_label: "Name",
		ActionSettingsTabLabel_caption: "Settings",
		ActionHelpTabLabel_caption: "Important points",
		ActionHelpTab_caption: "Help",
		ActionSchemaTab_caption: "Tool schema",
		ActionSettingsTab_caption: "Settings",
		ActionParametersTab_caption: "Parameters",
		RequireConfirmation_ariaLabel: "Checkbox",
		RequireConfirmation_label: "Require confirmation before start",
		RequireConfirmation_tooltip: "When this option is enabled, Creatio.ai will ask the user to confirm the tool before execution. The confirmation message and button labels are generated automatically by the AI model based on the tool description and its parameters. Ensure the description clearly explains what the tool does and what outcome to expect, as this context is used to compose the confirmation shown to the user.",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Creatio.ai Tools form page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});