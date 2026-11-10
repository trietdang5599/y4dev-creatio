define("FileImportStartPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		UploadFileButtonCaption: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u0444\u0430\u0439\u043B",
		DragAndDropContainerCaption: "\u041F\u0435\u0440\u0435\u0442\u0430\u0449\u0438\u0442\u0435 \u0441\u044E\u0434\u0430 \u0444\u0430\u0439\u043B \u0438\u043B\u0438",
		FileNotSelectedMessage: "\u041D\u0435 \u0432\u044B\u0431\u0440\u0430\u043D \u0444\u0430\u0439\u043B \u0434\u043B\u044F \u0437\u0430\u0433\u0440\u0443\u0437\u043A\u0438 \u0434\u0430\u043D\u043D\u044B\u0445. \u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0444\u0430\u0439\u043B \u0438 \u043F\u043E\u0432\u0442\u043E\u0440\u0438\u0442\u0435 \u043F\u043E\u043F\u044B\u0442\u043A\u0443.",
		InvalidFileTypeMessage: "\u0412\u044B \u0432\u044B\u0431\u0440\u0430\u043B\u0438 \u0444\u0430\u0439\u043B, \u0442\u0438\u043F \u043A\u043E\u0442\u043E\u0440\u043E\u0433\u043E \u043D\u0435 \u043F\u043E\u0434\u0434\u0435\u0440\u0436\u0438\u0432\u0430\u0435\u0442\u0441\u044F. \u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0444\u0430\u0439\u043B Excel (.xlsx).",
		EmptyHeaderExceptionMessage: "\u0424\u0430\u0439\u043B \u043D\u0435 \u0441\u043E\u0434\u0435\u0440\u0436\u0438\u0442 \u0437\u0430\u0433\u043E\u043B\u043E\u0432\u043A\u043E\u0432 \u043A\u043E\u043B\u043E\u043D\u043E\u043A \u0437\u0430\u043F\u0438\u0441\u0435\u0439, \u043A\u043E\u0442\u043E\u0440\u044B\u0435 \u0437\u0430\u0433\u0440\u0443\u0436\u0430\u044E\u0442\u0441\u044F. \u0417\u0430\u043F\u043E\u043B\u043D\u0438\u0442\u0435 \u043F\u0435\u0440\u0432\u0443\u044E \u0441\u0442\u0440\u043E\u043A\u0443 \u0444\u0430\u0439\u043B\u0430 \u0437\u0430\u0433\u043E\u043B\u043E\u0432\u043A\u0430\u043C\u0438 \u043A\u043E\u043B\u043E\u043D\u043E\u043A \u0438 \u043F\u043E\u0432\u0442\u043E\u0440\u0438\u0442\u0435 \u043F\u043E\u043F\u044B\u0442\u043A\u0443.",
		EmptyDataExceptionMessage: "\u0424\u0430\u0439\u043B \u043F\u0443\u0441\u0442\u043E\u0439. \u0423\u0431\u0435\u0434\u0438\u0442\u0435\u0441\u044C, \u0447\u0442\u043E \u0444\u0430\u0439\u043B \u0441\u043E\u0434\u0435\u0440\u0436\u0438\u0442 \u0437\u0430\u0433\u043E\u043B\u043E\u0432\u043A\u0438 \u043A\u043E\u043B\u043E\u043D\u043E\u043A, \u0437\u043D\u0430\u0447\u0435\u043D\u0438\u044F, \u0438 \u043F\u043E\u0432\u0442\u043E\u0440\u0438\u0442\u0435 \u043F\u043E\u043F\u044B\u0442\u043A\u0443.",
		EmptyImportObjectMessage: "\u041D\u0435 \u0432\u044B\u0431\u0440\u0430\u043D \u043E\u0431\u044A\u0435\u043A\u0442 \u0434\u043B\u044F \u0437\u0430\u0433\u0440\u0443\u0437\u043A\u0438 \u0434\u0430\u043D\u043D\u044B\u0445. \u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435, \u043A\u0443\u0434\u0430 \u0432\u044B \u0445\u043E\u0442\u0438\u0442\u0435 \u0437\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C \u0434\u0430\u043D\u043D\u044B\u0435, \u0438 \u043F\u043E\u0432\u0442\u043E\u0440\u0438\u0442\u0435 \u043F\u043E\u043F\u044B\u0442\u043A\u0443.",
		SelectImportObject: "\u041A\u0443\u0434\u0430 \u0432\u044B \u0445\u043E\u0442\u0438\u0442\u0435 \u0437\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C \u0434\u0430\u043D\u043D\u044B\u0435?",
		ExcelFileCaption: "\u0412\u044B \u0432\u044B\u0431\u0440\u0430\u043B\u0438 \u0444\u0430\u0439\u043B",
		ContactCaption: "\u041A\u043E\u043D\u0442\u0430\u043A\u0442",
		AccountCaption: "\u041A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442",
		OtherObjectCaption: "\u0414\u0440\u0443\u0433\u043E\u0435",
		InvalidObjectRights: "\u041D\u0435\u0434\u043E\u0441\u0442\u0430\u0442\u043E\u0447\u043D\u043E \u043F\u0440\u0430\u0432 \u0434\u043B\u044F \u0434\u043E\u0431\u0430\u0432\u043B\u0435\u043D\u0438\u044F \u0437\u0430\u043F\u0438\u0441\u0438 \u0432 \u043E\u0431\u044A\u0435\u043A\u0442 \u0022{0}\u0022",
		SelectedTemplateLabel: "\u0412\u044B\u0431\u0440\u0430\u043D \u0448\u0430\u0431\u043B\u043E\u043D: ",
		SelectTemplateLabel: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u0448\u0430\u0431\u043B\u043E\u043D",
		SelectEntityCaption: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u043E\u0431\u044A\u0435\u043A\u0442",
		EmptyImportSessionIdMessage: "\u0412\u044B \u043F\u0435\u0440\u0435\u0448\u043B\u0438 \u043F\u043E \u043D\u0435\u043A\u043E\u0440\u0440\u0435\u043A\u0442\u043D\u043E\u0439 \u0441\u0441\u044B\u043B\u043A\u0435. \u041E\u0442\u043A\u0440\u043E\u0439\u0442\u0435 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443 \u0417\u0430\u0433\u0440\u0443\u0437\u043A\u0438 \u0434\u0430\u043D\u043D\u044B\u0445 \u0438\u0437 \u0414\u0438\u0437\u0430\u0439\u043D\u0435\u0440\u0430 \u0441\u0438\u0441\u0442\u0435\u043C\u044B.",
		Header: "FileImportWizardStepPageHeader",
		NextButtonCaption: "\u0414\u0430\u043B\u0435\u0435"
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