define("AppFeature_DetailResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ActionsButtonCaption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		AddButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		Caption: "\u041F\u0435\u0440\u0435\u043A\u043B\u044E\u0447\u0435\u043D\u0438\u0435 \u0444\u0443\u043D\u043A\u0446\u0438\u043E\u043D\u0430\u043B\u044C\u043D\u043E\u0441\u0442\u0438",
		CopyMenuCaption: "\u041A\u043E\u043F\u0438\u0440\u043E\u0432\u0430\u0442\u044C",
		DeleteConfirmationMessage: "\u0412\u044B \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u0445\u043E\u0442\u0438\u0442\u0435 \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u0432\u044B\u0434\u0435\u043B\u0435\u043D\u043D\u0443\u044E \u0437\u0430\u043F\u0438\u0441\u044C?",
		DeleteMenuCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		DetailWizardMenuCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0434\u0435\u0442\u0430\u043B\u044C",
		EditMenuCaption: "\u0418\u0437\u043C\u0435\u043D\u0438\u0442\u044C",
		ExportListToExcelFileButtonCaption: "\u042D\u043A\u0441\u043F\u043E\u0440\u0442 \u0432 Excel",
		FieldsGroupCollapseButtonHint: "\u0421\u0432\u0435\u0440\u043D\u0443\u0442\u044C/\u0440\u0430\u0437\u0432\u0435\u0440\u043D\u0443\u0442\u044C",
		LoadMoreButtonCaption: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u0431\u043E\u043B\u044C\u0448\u0435",
		MasterRecordIdErrorMessage: "\u041F\u0430\u0440\u0430\u043C\u0435\u0442\u0440 MasterRecordId \u043D\u0435 \u0438\u043D\u0438\u0446\u0438\u0430\u043B\u0438\u0437\u0438\u0440\u043E\u0432\u0430\u043D \u0432 \u0434\u0435\u0442\u0430\u043B\u0438 {0}, hash \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B {1}",
		MultiDeleteConfirmationMessage: "\u0412\u044B \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u0445\u043E\u0442\u0438\u0442\u0435 \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u0432\u044B\u0434\u0435\u043B\u0435\u043D\u043D\u044B\u0435 \u0437\u0430\u043F\u0438\u0441\u0438?",
		MultiModeMenuCaption: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u043D\u0435\u0441\u043A\u043E\u043B\u044C\u043A\u043E \u0437\u0430\u043F\u0438\u0441\u0435\u0439",
		OpenObjectChangeLogSettingsCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0436\u0443\u0440\u043D\u0430\u043B \u0438\u0437\u043C\u0435\u043D\u0435\u043D\u0438\u0439",
		OpenRecordChangeLogCaption: "\u041E\u0442\u043A\u0440\u044B\u0442\u044C \u0436\u0443\u0440\u043D\u0430\u043B \u0438\u0437\u043C\u0435\u043D\u0435\u043D\u0438\u0439",
		OperationAccessDenied: "\u0423 \u0442\u0435\u043A\u0443\u0449\u0435\u0433\u043E \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u044F \u043D\u0435 \u0434\u043E\u0441\u0442\u0430\u0442\u043E\u0447\u043D\u043E \u043F\u0440\u0430\u0432 \u0434\u043B\u044F \u0432\u044B\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u044F \u043E\u043F\u0435\u0440\u0430\u0446\u0438\u0438 \u0022{0}\u0022",
		ProcessButtonHint: "\u0417\u0430\u043F\u0443\u0441\u0442\u0438\u0442\u044C \u043F\u0440\u043E\u0446\u0435\u0441c \u043F\u043E \u0437\u0430\u043F\u0438\u0441\u0438",
		QuickFilterCaption: "\u0423\u0441\u0442\u0430\u043D\u043E\u0432\u0438\u0442\u044C \u0444\u0438\u043B\u044C\u0442\u0440",
		RecordRightsSetupMenuItemCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u043F\u0440\u0430\u0432\u0430 \u0434\u043E\u0441\u0442\u0443\u043F\u0430",
		RelationshipButtonHint: "\u041F\u043E \u0434\u043E\u0447\u0435\u0440\u043D\u0438\u043C \u0441\u0432\u044F\u0437\u044F\u043C",
		RemoveQuickFilterCaption: "\u0421\u043A\u0440\u044B\u0442\u044C \u0444\u0438\u043B\u044C\u0442\u0440",
		SchemaLocalizableString1: "",
		SetupGridMenuCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043A\u043E\u043B\u043E\u043D\u043E\u043A",
		SetupTotalMenuCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u0438\u0442\u043E\u0433\u043E\u0432",
		SingleModeMenuCaption: "\u041E\u0442\u043C\u0435\u043D\u0438\u0442\u044C \u043C\u043D\u043E\u0436\u0435\u0441\u0442\u0432\u0435\u043D\u043D\u044B\u0439 \u0432\u044B\u0431\u043E\u0440",
		SortMenuCaption: "\u0421\u043E\u0440\u0442\u0438\u0440\u043E\u0432\u043A\u0430",
		ToolsButtonHint: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		ViewButtonCaption: "\u0412\u0438\u0434"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		LoadMoreIcon: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "LoadMoreIcon",
				hash: "d757aaf069c75446184760d4935622e9",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "AddButtonImage",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "ToolsButtonImage",
				hash: "48d545549ca4ddb13d7a7bb58f60ed5e",
				resourceItemExtension: ".svg"
			}
		},
		RelationshipButtonImage: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "RelationshipButtonImage",
				hash: "0c19637a3f87200944f7330b499d7c8c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		ExportToExcelBtnImage: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "ExportToExcelBtnImage",
				hash: "1883b16fe86f1acadfc158894338fc09",
				resourceItemExtension: ".svg"
			}
		},
		ImageFilter: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "ImageFilter",
				hash: "ef37ab38ddacefd3ba86c6bbcf4e7501",
				resourceItemExtension: ".svg"
			}
		},
		SortIcon: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "SortIcon",
				hash: "f5e0b50ec74a47fb66f7d7d403b760c3",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "GridSettingsIcon",
				hash: "3f4eb707ce7f259fce295490879a8f9b",
				resourceItemExtension: ".svg"
			}
		},
		FilterIcon20: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "FilterIcon20",
				hash: "124f910abe91ebe4045613a9c5b379d1",
				resourceItemExtension: ".svg"
			}
		},
		ObjectChangeLogSettingsBtnImage: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "ObjectChangeLogSettingsBtnImage",
				hash: "f0169f1a725a65ec76c564d5e9705277",
				resourceItemExtension: ".svg"
			}
		},
		OpenRecordChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "AppFeature_Detail",
				resourceItemName: "OpenRecordChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});