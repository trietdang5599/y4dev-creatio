define("FileImportColumnsMappingPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DuplicateFieldMessageTemplate: "Selected column \u0022{0}\u0022 is already mapped to \u0022{1}\u0022 file column. Change the mapping and try again.",
		DuplicateAttributeMessageTemplate: "The column was already selected",
		ValidationMessageTemplate: "Column \u0022{0}\u0022 is required. Map this column and try again.",
		CommunicationOptionCaption: "Communication option",
		AddressCaption: "Address",
		ColumnMappingNoAppendRightTemplate: "You do not have permission to add new entries to \u0022{0}\u0022.",
		EmptyImportSessionIdMessage: "Page URL is incorrect. Open the Data import page in System designer",
		Header: "Specify column mapping between Excel file and the system",
		NextButtonCaption: "Next"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ExcelLogo: {
			source: 3,
			params: {
				schemaName: "FileImportColumnsMappingPage",
				resourceItemName: "ExcelLogo",
				hash: "63c025f09c2484c6ef0597a94f53103f",
				resourceItemExtension: ".png"
			}
		},
		BpmonlineLogo: {
			source: 3,
			params: {
				schemaName: "FileImportColumnsMappingPage",
				resourceItemName: "BpmonlineLogo",
				hash: "d7e4c9b1680409baadac3b368fdae024",
				resourceItemExtension: ".png"
			}
		},
		DeleteImage: {
			source: 3,
			params: {
				schemaName: "FileImportColumnsMappingPage",
				resourceItemName: "DeleteImage",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});