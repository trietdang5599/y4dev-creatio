define("CustomLlmModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CustomLlmModelCaption: "CustomLlmModel",
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
		ConfigurationFailureReasonCaption: "Configuration Failure Reason",
		JsonConfigCaption: "Model configuration (JSON)"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages};
});