define("FileUploadErrorHandlersResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MaxFileSizeExceededExceptionMessage: "{0} MB maximum file size limit exceeded.",
		FileListHeader: "Files",
		UploadFileError: "General loading errors occurred for the following file(s).",
		ChangeFileSizeInfoMessage: "You can increase the maximum file size in the \u201CAttachment max size\u201D system setting.",
		ChangeSizeCaption: "Change size"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});