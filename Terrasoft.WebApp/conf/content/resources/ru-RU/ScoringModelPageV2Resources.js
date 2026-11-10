define("ScoringModelPageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ScoringRuleTabCaption: "\u041F\u0440\u0430\u0432\u0438\u043B\u0430 \u0441\u043A\u043E\u0440\u0438\u043D\u0433\u0430",
		ScoringModelCaption: "\u0421\u043A\u043E\u0440\u0438\u043D\u0433\u043E\u0432\u0430\u044F \u043C\u043E\u0434\u0435\u043B\u044C: {0}",
		ScoringParameterCaption: "\u041A\u0430\u043A\u043E\u0439 \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440 \u0440\u0430\u0441\u0441\u0447\u0438\u0442\u044B\u0432\u0430\u0442\u044C?",
		ContextHelpDescription: "\u0423\u0437\u043D\u0430\u0439\u0442\u0435 \u0432 \u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438 \u043E \u0442\u043E\u043C, \u043A\u0430\u043A \u044D\u0444\u0444\u0435\u043A\u0442\u0438\u0432\u043D\u043E \u043D\u0430\u0441\u0442\u0440\u043E\u0438\u0442\u044C \u0440\u0430\u0431\u043E\u0442\u0443 \u0441\u043A\u043E\u0440\u0438\u043D\u0433\u0430 \u0434\u043B\u044F \u0442\u043E\u0433\u043E, \u0447\u0442\u043E\u0431\u044B \u044D\u0444\u0444\u0435\u043A\u0442\u0438\u0432\u043D\u0435\u0435 \u0440\u0430\u0431\u043E\u0442\u0430\u0442\u044C \u0441 \u043F\u043E\u0442\u043E\u043A\u043E\u043C \u0432\u0430\u0448\u0438\u0445 \u043B\u0438\u0434\u043E\u0432.",
		ScoringParameterTip: "\u041F\u043E\u043B\u0435, \u0432 \u043A\u043E\u0442\u043E\u0440\u043E\u043C \u0445\u0440\u0430\u043D\u0438\u0442\u0441\u044F \u0440\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442 \u0441\u043A\u043E\u0440\u0438\u043D\u0433\u0430. \u0414\u043E\u0441\u0442\u0443\u043F\u043D\u044B \u0442\u043E\u043B\u044C\u043A\u043E \u0447\u0438\u0441\u043B\u043E\u0432\u044B\u0435 \u043F\u043E\u043B\u044F.",
		ScoringObjectLookupCaption: "\u0421\u043A\u043E\u0440\u0438\u043D\u0433\u043E\u0432\u044B\u0435 \u043E\u0431\u044A\u0435\u043A\u0442\u044B"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		TagButtonIcon: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "TagButtonIcon",
				hash: "749c444773b4d39e64c4f6938fdf6d76",
				resourceItemExtension: ".svg"
			}
		},
		ContextHelpIcon: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "ContextHelpIcon",
				hash: "7e5a0cdddee3a830af9d97bb923e39c3",
				resourceItemExtension: ".png"
			}
		},
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "CloseButtonImage",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "ProcessButtonImage",
				hash: "b2718527a6bf360a3e641e9cb3a00904",
				resourceItemExtension: ".svg"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataIcon: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "AnalyticsDataIcon",
				hash: "797f9955cfd47e5ca74c16a682de6853",
				resourceItemExtension: ".svg"
			}
		},
		GridSettingsIcon: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "GridSettingsIcon",
				hash: "c4949763b4bc893604fbb2d5d458a028",
				resourceItemExtension: ".svg"
			}
		},
		OpenChangeLogBtnImage: {
			source: 3,
			params: {
				schemaName: "ScoringModelPageV2",
				resourceItemName: "OpenChangeLogBtnImage",
				hash: "cbebcb32589828e1055caf62150ff717",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});