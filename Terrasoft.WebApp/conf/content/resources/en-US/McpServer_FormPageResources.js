define("McpServer_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ToolsSettingsButton_caption: "Actions",
		CopyUrlButton_caption: "Copy URL",
		SaveButton_caption: "Save",
		ToolsExpansionPanel_title: "Tools",
		AddTagsBulkAction_caption: "Add tag",
		AttachmentCol_Name_caption: "Name",
		AttachmentsTab_caption: "Attachments",
		CodeInput_label: "Code",
		Col_ExternalName_caption: "External tool name",
		Col_IsEnabled_caption: "Enabled",
		Col_Title_caption: "Title",
		DeleteBulkAction_caption: "Delete",
		DescriptionInput_label: "Description",
		ExportToExcel_caption: "Export to Excel",
		FeedTab_caption: "Feed",
		GeneralInfoTab_caption: "Tools",
		MakeOfflineButton_caption: "Make it offline",
		MakeOnlineButton_caption: "Make it online",
		NameInput_label: "Name",
		RemoveTagsBulkAction_caption: "Remove tag",
		SelectProcessWindowCaption: "Select process(es)",
		ToolsAddButton_caption: "Add tool",
		ToolsAddFailedMessage: "Could not add the selected tool(s). Please try again.",
		ToolsAddedMessage: "Selected tools added successfully",
		ToolsPartialAddedMiddle: " tool(s) added, but ",
		ToolsPartialAddedSuffix: " could not be added",
		ToolsRefreshButton_caption: "Refresh",
		ToolsSearchFilter_placeholder: "Search",
		AddToolFromProcessMenuItem_caption: "Add from process",
		AddToolFromSourceActionMenuItem_caption: "Add from source code action",
		SelectSourceActionWindowCaption: "Select source code action(s)",
		FullUrlInput_label: "Full URL",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		NewRecord: "New record",
		PostponeQueueItemButton_caption: "",
		Record: "Record",
		RequeueQueueItemButton_caption: "",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights",
		CodeValidationMessage: "Only letters (a-z, A-Z) and digits (0-9) are allowed. No spaces or other symbols, because Code is used in the MCP endpoint URL."
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "McpServer_FormPage"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});