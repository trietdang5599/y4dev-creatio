define("McpTool_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ExternalNameValidationMessage: "Allowed characters: letters, digits, underscore (_), and hyphen (-); max 64 characters. No spaces, dots, or other symbols.",
		TtExternalName: "Unique tool identifier sent to MCP clients (the tool name). Allowed: A-Z a-z 0-9 _ - \u2014 max 64 characters, no spaces or other symbols.",
		TtDescription: "Human-readable explanation of what the tool does; the LLM uses it to decide when to call the tool (MCP description).",
		TtInputSchema: "JSON Schema (object) describing the tool\u0027s input arguments (MCP inputSchema).",
		TtOutputSchema: "Optional JSON Schema describing the tool\u0027s structured result (MCP outputSchema).",
		TtAnnotations: "Optional JSON behavior hints: title, readOnlyHint, destructiveHint, idempotentHint, openWorldHint (MCP annotations).",
		RefreshOutputMenuItem_caption: "Output schema",
		RefreshInputMenuItem_caption: "Input schema",
		RefreshSchemasButton_caption: "Refresh from process",
		OpenProcessButton_caption: "Open process",
		TitleInput_label: "Title",
		TitleInput_tooltip: "Optional human-readable display title for the tool, shown to users in MCP client UIs. If omitted, the tool\u0027s name is shown instead.",
		OpenProcessButton_tooltip: "Open this process in the Process Designer (in a new browser tab)",
		RefreshSchemasButton_tooltip: "Rebuild the input or output fields from the selected process",
		SelectProcessFirstMessage: "Select a process first",
		InputSchemaRefreshedMessage: "Input schema refreshed from process",
		OutputSchemaRefreshedMessage: "Output schema refreshed from process",
		JsonValidationMessage: "Value must be valid JSON.",
		SourceCodeActionInput_label: "Source code action",
		RefreshSourceActionButton_caption: "Refresh from source code action",
		RefreshSourceActionButton_tooltip: "Rebuild the input or output fields from the source code action",
		OpenSourceActionButton_caption: "Open source code action",
		OpenSourceActionButton_tooltip: "Open this source code action in the Source Code Designer (in a new browser tab)",
		SourceActionNotFoundMessage: "Could not find the source code schema for this action.",
		InputSchemaRefreshedFromActionMessage: "Input schema refreshed from source code action",
		OutputSchemaRefreshedFromActionMessage: "Output schema refreshed from source code action",
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
		PostponeQueueItemButton_caption: "",
		Record: "Record",
		RequeueQueueItemButton_caption: "",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights",
		SelectProcessButton_caption: "Change process",
		SelectProcessButton_tooltip: "Change the source process (from the process library)",
		UnsupportedParamsWarningPrefix: "This tool will not work at runtime: its process has parameter(s) of unsupported type(s): "
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "MCP Tools form page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});