define("CopilotAgentResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CopilotAgentCaption: "Creatio.ai Agent",
		IdCaption: "Id",
		CreatedOnCaption: "Created on",
		CreatedByCaption: "Created by",
		ModifiedOnCaption: "Modified on",
		ModifiedByCaption: "Modified by",
		NameCaption: "Title",
		DescriptionCaption: "Description",
		CodeCaption: "Code",
		ProcessListenersCaption: "Active processes",
		TypeCaption: "Type",
		StatusCaption: "Status",
		PromptCaption: "Agent instructions",
		PackageUIdCaption: "Package unique identifier",
		RestrictionsCaption: "Restrictions",
		RoleDescriptionCaption: "RoleDescription",
		LlmModelCaption: "LLM Model",
		UsePageContextCaption: "Use page context",
		WorkflowOnlyCaption: "Is intent available only in workflow",
		ParamsCaption: "Params",
		UseChatHistoryCaption: "Use chat history",
		UseDefaultSystemPromptCaption: "Use default system prompt"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages};
});