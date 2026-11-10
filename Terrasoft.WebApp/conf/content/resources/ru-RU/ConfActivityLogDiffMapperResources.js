define("ConfActivityLogDiffMapperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SourceCode: "Source code",
		Metadata: "Metadata",
		DefaultErrorMessage: "Unable to load changed files.",
		Descriptor: "Descriptor",
		NoFilesTitle: "No files to compare",
		NoFilesMessage: "The selected log entry does not have comparable files.",
		NoSupportedContentTitle: "No supported compare content is available",
		NoSupportedContentMessage: "The selected log entry does not contain source code, metadata, or descriptor files."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});