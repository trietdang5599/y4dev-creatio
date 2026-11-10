define("SourceCodeEditPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowFindWindowButtonHint: "\u041F\u043E\u0438\u0441\u043A",
		ShowWhitespacesButtonHint: "\u041E\u0442\u043E\u0431\u0440\u0430\u0437\u0438\u0442\u044C \u0432\u0441\u0435 \u0437\u043D\u0430\u043A\u0438",
		ExpandButtonHint: "\u0420\u0430\u0437\u0432\u0435\u0440\u043D\u0443\u0442\u044C (F2)",
		CollapseButtonHint: "\u0421\u0432\u0435\u0440\u043D\u0443\u0442\u044C (F2)",
		UseFlowEngineBodyHint: "\u0414\u043B\u044F \u0438\u043D\u0442\u0435\u0440\u043F\u0440\u0435\u0442\u0438\u0440\u0443\u0435\u043C\u044B\u0445 \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432 \u0438\u0437\u043C\u0435\u043D\u0435\u043D\u0430 \u043B\u043E\u0433\u0438\u043A\u0430 \u0440\u0430\u0431\u043E\u0442\u044B \u0441 \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440\u0430\u043C\u0438 \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u0430. \u0427\u0442\u043E\u0431\u044B \u043E\u0431\u0440\u0430\u0442\u0438\u0442\u044C\u0441\u044F \u043A \u043F\u0430\u0440\u0430\u043C\u0435\u0442\u0440\u0430\u043C, \u0438\u0441\u043F\u043E\u043B\u044C\u0437\u0443\u0439\u0442\u0435 \u043C\u0435\u0442\u043E\u0434\u044B \u0022Set\u0022 \u0438 \u0022Get\u0022. \u003Cbr/\u003E\u003Ca href=\u0022#\u0022 data-context-help-code=\u0022ScriptTaskPropertiesPage\u0022\u003E\u041F\u043E\u0434\u0440\u043E\u0431\u043D\u0435\u0435...\u003C/a\u003E"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SearchImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeEditPage",
				resourceItemName: "SearchImage",
				hash: "fe73ae684f4f0539db05ee2e4df062b7",
				resourceItemExtension: ".png"
			}
		},
		ShowWhitespacesImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeEditPage",
				resourceItemName: "ShowWhitespacesImage",
				hash: "fa880aac7a52f0c048a8926564622d10",
				resourceItemExtension: ".png"
			}
		},
		ExpandImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeEditPage",
				resourceItemName: "ExpandImage",
				hash: "0e6e9a3ad33ee9dc36c01ae8a20e281d",
				resourceItemExtension: ".png"
			}
		},
		CollapseImage: {
			source: 3,
			params: {
				schemaName: "SourceCodeEditPage",
				resourceItemName: "CollapseImage",
				hash: "3238ca5b1233bb385935768af0131d0e",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});