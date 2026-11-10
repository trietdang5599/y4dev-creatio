define("SegmentActivationValidationPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MissingCriteriaLabel_caption: "Entry rules haven not been configured yet. Add the entry criteria to activate/resume this segment",
		PageTitle_caption: "Missing entry rules",
		SaveButton_caption: "OK",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Segment activation validation page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});