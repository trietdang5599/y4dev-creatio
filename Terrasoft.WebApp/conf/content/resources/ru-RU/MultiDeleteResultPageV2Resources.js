define("MultiDeleteResultPageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PageCaption: "\u0423\u0434\u0430\u043B\u0435\u043D\u0438\u0435 \u0437\u0430\u043F\u0438\u0441\u0435\u0439",
		ByRightsCaption: "{0} \u0437\u0430\u043F\u0438\u0441\u0435\u0439 \u0431\u0435\u0437 \u043F\u0440\u0430\u0432 \u0443\u0434\u0430\u043B\u0435\u043D\u0438\u044F",
		ByConstraintsCaption: "{0} \u0437\u0430\u043F\u0438\u0441\u0435\u0439 \u0438\u0441\u043F\u043E\u043B\u044C\u0437\u0443\u044E\u0442\u0441\u044F \u0432 \u0434\u0440\u0443\u0433\u0438\u0445 \u0440\u0430\u0437\u0434\u0435\u043B\u0430\u0445",
		PlusCaption: "\u002B",
		MinusCaption: "-",
		DeleteRecord: "\u0421 \u0443\u0434\u0430\u043B\u0435\u043D\u0438\u0435\u043C \u0441\u0432\u044F\u0437\u0430\u043D\u043D\u044B\u0445 \u0437\u0430\u043F\u0438\u0441\u0435\u0439",
		UnlinkRecord: "\u0411\u0435\u0437 \u0443\u0434\u0430\u043B\u0435\u043D\u0438\u044F \u0441\u0432\u044F\u0437\u0430\u043D\u043D\u044B\u0445 \u0437\u0430\u043F\u0438\u0441\u0435\u0439",
		DeletedSuccessfully: "\u0417\u0430\u043F\u0438\u0441\u0438 \u0443\u0441\u043F\u0435\u0448\u043D\u043E \u0443\u0434\u0430\u043B\u0435\u043D\u044B",
		DeleteAllHint: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C \u0432\u0441\u0435",
		IgnoreHint: "\u0423\u0431\u0440\u0430\u0442\u044C \u0438\u0437 \u0441\u043F\u0438\u0441\u043A\u0430",
		DeleteRecordsButton: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C \u0437\u0430\u043F\u0438\u0441\u0438",
		DeleteRecordButton: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C \u0437\u0430\u043F\u0438\u0441\u044C"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		DeleteItemIcon: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "DeleteItemIcon",
				hash: "1f90c37936f6e8e4483ac4b62a6f5401",
				resourceItemExtension: ".png"
			}
		},
		CollapsedImage: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "CollapsedImage",
				hash: "3d6306c8f81a1f61d1276242235a4167",
				resourceItemExtension: ".png"
			}
		},
		ErrorTypes: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "ErrorTypes",
				hash: "c11886f79a80dc48bae22364a75e189f",
				resourceItemExtension: ".png"
			}
		},
		IgnoreItemIcon: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "IgnoreItemIcon",
				hash: "274fa587acc3b23ae770895890b5a09b",
				resourceItemExtension: ".svg"
			}
		},
		CollapsedImageBtn: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "CollapsedImageBtn",
				hash: "9e007f22da6265304aa84927e2dd1ed3",
				resourceItemExtension: ".png"
			}
		},
		ExpandImageBtn: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "ExpandImageBtn",
				hash: "f64b0e1fce94b21349ab096c55d88432",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "MultiDeleteResultPageV2",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});