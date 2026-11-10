define("BaseMessagePublisherPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PublishButtonCaption: "Publish",
		DropZoneHoverCaption: "Drop file here",
		MessagePublishError: "Failed to send a message. {0}",
		NotPublishedMessage: "This page contains unsaved changes. Do you still wish to leave the page?",
		TimeOutError: "Connection failed (timeout)",
		UploadFileError: "Error occurred while loading the file"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});