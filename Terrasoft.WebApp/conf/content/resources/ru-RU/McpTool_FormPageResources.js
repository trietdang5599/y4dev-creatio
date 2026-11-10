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
		AttachmentAddButtonCaption: "\u0417\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C",
		AttachmentRefreshButtonCaption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		AttachmentsTabContainerCaption: "\u0424\u0430\u0439\u043B\u044B",
		BackButton: "\u041D\u0430\u0437\u0430\u0434",
		CancelButton: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CloseButton: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		DefaultHeaderCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		FeedTabContainerCaption: "\u041B\u0435\u043D\u0442\u0430",
		GeneralInfoTab_caption: "\u041E\u0441\u043D\u043E\u0432\u043D\u0430\u044F \u0438\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F",
		NewRecord: "\u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		PostponeQueueItemButton_caption: "",
		Record: "\u0417\u0430\u043F\u0438\u0441\u044C",
		RequeueQueueItemButton_caption: "",
		SaveButton: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		SetRecordRightsButtonCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043F\u0440\u0430\u0432",
		SelectProcessButton_caption: "Change process",
		SelectProcessButton_tooltip: "Change the source process (from the process library)",
		UnsupportedParamsWarningPrefix: "This tool will not work at runtime: its process has parameter(s) of unsupported type(s): "
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u0441 \u0432\u043A\u043B\u0430\u0434\u043A\u0430\u043C\u0438 \u0438 \u043E\u0441\u0442\u0440\u043E\u0432\u0430\u043C\u0438 \u0441\u043B\u0435\u0432\u0430"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});