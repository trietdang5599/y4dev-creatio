define("FileImportStartPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		UploadFileButtonCaption: "Select file",
		DragAndDropContainerCaption: "Drag and drop file here or",
		FileNotSelectedMessage: "No file for import is specified. Select the file and try again.",
		InvalidFileTypeMessage: "Incorrect file format. Please select an Excel file (.xlsx).",
		EmptyHeaderExceptionMessage: "File doesn\u0027t contain column headers. Fill in the first row of the file with column headers and try again.",
		EmptyDataExceptionMessage: "File is empty. Make sure the file contains column captions and values and then try again.",
		EmptyImportObjectMessage: "No object for import is specified. Select an object and try again.",
		SelectImportObject: "Where do you want the data imported to?",
		ExcelFileCaption: "Selected file",
		ContactCaption: "Contact",
		AccountCaption: "Account",
		OtherObjectCaption: "Other",
		InvalidObjectRights: "Insufficient permissions to add record in object \u0022{0}\u0022",
		SelectedTemplateLabel: "Selected template: ",
		SelectTemplateLabel: "Select template",
		SelectEntityCaption: "Select object",
		EmptyImportSessionIdMessage: "Page URL is incorrect. Open the Data import page in System designer",
		Header: "FileImportWizardStepPageHeader",
		NextButtonCaption: "Next"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		EmptyFileImage: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "EmptyFileImage",
				hash: "8a7e6ded494970e56f56c08bd0a2720c",
				resourceItemExtension: ".png"
			}
		},
		ErrorFileImage: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "ErrorFileImage",
				hash: "47721e5c6d19ec12a93caaf6a7b3a133",
				resourceItemExtension: ".png"
			}
		},
		ExcelFileImage: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "ExcelFileImage",
				hash: "ccdaf1eeddae9837ea4146d050d7c882",
				resourceItemExtension: ".png"
			}
		},
		ExcelFileDeleteImage: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "ExcelFileDeleteImage",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		ContactImage: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "ContactImage",
				hash: "dc69eb4ae1513c09d7788597c34cdd8d",
				resourceItemExtension: ".png"
			}
		},
		ContactImageSelected: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "ContactImageSelected",
				hash: "cd03f9f5c45e8510e848b8c70ccadcad",
				resourceItemExtension: ".png"
			}
		},
		AccountImage: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "AccountImage",
				hash: "b353d718f3fb070abd2311b0f3185105",
				resourceItemExtension: ".png"
			}
		},
		AccountImageSelected: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "AccountImageSelected",
				hash: "f45192e040454ed46900e28b7bbacd21",
				resourceItemExtension: ".png"
			}
		},
		OtherObjectImage: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "OtherObjectImage",
				hash: "cc37cf17deff45f38b0b8e358ef77657",
				resourceItemExtension: ".png"
			}
		},
		OtherObjectImageSelected: {
			source: 3,
			params: {
				schemaName: "FileImportStartPage",
				resourceItemName: "OtherObjectImageSelected",
				hash: "85038297340d5ffd4becfc5fe0bde91e",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});