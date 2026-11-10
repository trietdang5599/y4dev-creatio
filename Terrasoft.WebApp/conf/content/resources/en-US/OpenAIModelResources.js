define("OpenAIModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OpenAIModelCaption: "OpenAI Model",
		IdCaption: "Id",
		CreatedOnCaption: "Created on",
		CreatedByCaption: "Created by",
		ModifiedOnCaption: "Modified on",
		ModifiedByCaption: "Modified by",
		NameCaption: "Name",
		DescriptionCaption: "Description",
		ProcessListenersCaption: "Active processes",
		CanUseStructuredOutputCaption: "CanUseStructuredOutput",
		CanUseFunctionCallingCaption: "CanUseFunctionCalling",
		LlmProviderCaption: "LLM provider",
		CodeCaption: "Code",
		EncryptedConfigCaption: "Json Config",
		ApiKeyCaption: "API key",
		ModelCaption: "Model name",
		ConfigurationFailureReasonCaption: "Configuration Failure Reason"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages};
});