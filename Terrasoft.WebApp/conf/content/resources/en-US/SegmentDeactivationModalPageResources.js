define("SegmentDeactivationModalPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButton_caption: "Pause segment",
		PageTitle_caption: "Pause this segment",
		PauseSegmentLabel_caption: "Pausing stops the segment\u0027s lifecycle - it won\u0027t refresh and can\u0027t be selected in campaigns until you resume it.",
		CancelButton: "Cancel",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Segment deactivation modal page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});