define("PrintReportUtilitiesResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AsynGenerationPopupTitle: "Generate report",
		AsynGenerationPopupBody: "We are preparing your report file, but it may take longer than expected. You can continue working with the application; your report will start downloading automatically",
		AsynGenerationErrorPopupBody: "An error occurred while generating a downloadable file for the following report. Please try downloading the report later",
		AsynGenerationErrorPopupBodyTpl: "An error occurred while generating a downloadable file for the following report: {0}. Please try downloading the report later"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AsynGenerationPopupIcon: {
			source: 3,
			params: {
				schemaName: "PrintReportUtilities",
				resourceItemName: "AsynGenerationPopupIcon",
				hash: "553d0db3f017e6ae3bbf80eaec091c05",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});