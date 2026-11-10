define("SummarySettingsViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButtonCaption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		CancelButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		AddButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		AddColumnButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0441\u0442\u0440\u043E\u043A\u0443",
		DisplayRecordCountCaption: "\u041E\u0442\u043E\u0431\u0440\u0430\u0436\u0430\u0442\u044C \u043A\u043E\u043B\u0438\u0447\u0435\u0441\u0442\u0432\u043E \u0437\u0430\u043F\u0438\u0441\u0435\u0439",
		ColumnHeaderCaption: "\u041A\u043E\u043B\u043E\u043D\u043A\u0430",
		ColumnFuncCaption: "\u0424\u0443\u043D\u043A\u0446\u0438\u044F",
		ColumnTitleCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageDeleteButton: {
			source: 3,
			params: {
				schemaName: "SummarySettingsViewGenerator",
				resourceItemName: "ImageDeleteButton",
				hash: "2185ea9274f8cece0b49039f21947286",
				resourceItemExtension: ".png"
			}
		},
		ImageConfirmButton: {
			source: 3,
			params: {
				schemaName: "SummarySettingsViewGenerator",
				resourceItemName: "ImageConfirmButton",
				hash: "18e29d509e192058502f9a936a2dd85f",
				resourceItemExtension: ".png"
			}
		},
		ImageDiscardButton: {
			source: 3,
			params: {
				schemaName: "SummarySettingsViewGenerator",
				resourceItemName: "ImageDiscardButton",
				hash: "50670ba55c24903c8a285e68eebebdb0",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});