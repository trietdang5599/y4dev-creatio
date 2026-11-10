define("FileDownloaderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FileMismatchErrorMessage: "File \u0027{0}\u0027 is not fully uploaded.",
		FileDownloadErrorMessage: "The file \u0027{0}\u0027 could not be downloaded. It may have been deleted, is corrupted, or you do not have permission to access it."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});