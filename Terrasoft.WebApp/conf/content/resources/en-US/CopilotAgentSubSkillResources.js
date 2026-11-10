define("CopilotAgentSubSkillResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CopilotAgentSubSkillCaption: "Creatio.ai agent subskill",
		IdCaption: "Id",
		CreatedOnCaption: "Created on",
		CreatedByCaption: "Created by",
		ModifiedOnCaption: "Modified on",
		ModifiedByCaption: "Modified by",
		NameCaption: "Title",
		DescriptionCaption: "Description",
		CodeCaption: "Code",
		ProcessListenersCaption: "Active processes",
		ModeCaption: "Mode",
		IntentCaption: "Intent",
		TypeCaption: "Type",
		StatusCaption: "Status",
		PromptCaption: "Prompt",
		PackageUIdCaption: "Package unique identifier",
		ParentIntentIdCaption: "ParentIntentId",
		ResponseFormatJsonSchemaCaption: "ResponseFormatJsonSchema",
		LlmModelCaption: "LLM Model",
		UsePageContextCaption: "Use page context",
		WorkflowOnlyCaption: "Is intent available only in workflow",
		UseChatHistoryCaption: "Use chat history",
		UseDefaultSystemPromptCaption: "Use default system prompt"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages};
});