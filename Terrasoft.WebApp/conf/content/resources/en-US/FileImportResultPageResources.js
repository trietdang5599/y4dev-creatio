define("FileImportResultPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CloseButtonCaption: "Close",
		DataImportFinishedLabelCaption: "Import complete.",
		ImportStatusLabelFormat: "{1} of {0} records imported from the source file.",
		NotImportedStatusLabelFormat: "{0} record(s) not imported.",
		ImportDetailsLabelFormat: "You can view import details in the",
		ImportDetailsEndLabelFormat: ".",
		ImportLogLink: "Open data import log",
		FailureImportHeader: "Finished.",
		OpenImportedDataLink: "Open imported records",
		LookupProcessingErrorsLabel: "Some lookup columns could not be processed. See the import log for details.",
		EmptyImportSessionIdMessage: "Page URL is incorrect. Open the Data import page in System designer",
		Header: "Congratulations!",
		NextButtonCaption: "Next"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CongratulationImage: {
			source: 3,
			params: {
				schemaName: "FileImportResultPage",
				resourceItemName: "CongratulationImage",
				hash: "6646be2fd248715cd1608e3ec3f18b4b",
				resourceItemExtension: ".png"
			}
		},
		CloseImage: {
			source: 3,
			params: {
				schemaName: "FileImportResultPage",
				resourceItemName: "CloseImage",
				hash: "5e22e1a0a5bf2fad0e0a77b298fcbd7c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});