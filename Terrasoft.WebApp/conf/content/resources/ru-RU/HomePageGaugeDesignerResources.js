define("HomePageGaugeDesignerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WithoutFillTheme: "\u041F\u0440\u043E\u0441\u0442\u043E\u0439 \u0431\u0435\u043B\u044B\u0439",
		FullFillTheme: "\u041F\u043E\u043B\u043D\u043E\u0446\u0432\u0435\u0442\u043D\u044B\u0439",
		GaugeThemeLabel: "\u0421\u0442\u0438\u043B\u044C \u0448\u043A\u0430\u043B\u044B",
		ColorCaption: "\u0426\u0432\u0435\u0442",
		AggregationColumnLabel: "\u041A\u043E\u043B\u043E\u043D\u043A\u0430",
		AggregationTypeLabel: "\u0424\u0443\u043D\u043A\u0446\u0438\u044F",
		AscendingOrder: "\u0427\u0435\u043C \u0431\u043E\u043B\u044C\u0448\u0435, \u0442\u0435\u043C \u043B\u0443\u0447\u0448\u0435",
		CancelButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CaptionLabel: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A",
		DefaultRelatedObjectCaptionFormat: "\u041F\u043E\u043B\u0435 \u0441\u0432\u044F\u0437\u0438 \u043E\u0431\u044A\u0435\u043A\u0442\u0430 \u0022{0}\u0022 \u0441 \u0442\u0435\u043A\u0443\u0449\u0438\u043C \u043E\u0431\u044A\u0435\u043A\u0442\u043E\u043C",
		DescendingOrder: "\u0427\u0435\u043C \u043C\u0435\u043D\u044C\u0448\u0435, \u0442\u0435\u043C \u043B\u0443\u0447\u0448\u0435",
		DetailBindingColumnFormat: "",
		EntitySchemaNameLabel: "\u041E\u0431\u044A\u0435\u043A\u0442",
		FilterLabel: "\u0424\u0438\u043B\u044C\u0442\u0440",
		FilterPropertiesLabel: "\u041A\u0430\u043A \u043E\u0442\u0444\u0438\u043B\u044C\u0442\u0440\u043E\u0432\u0430\u0442\u044C",
		FormatDecimalPrecision: "\u0422\u043E\u0447\u043D\u043E\u0441\u0442\u044C \u0434\u0435\u0441\u044F\u0442\u0438\u0447\u043D\u043E\u0439 \u0447\u0430\u0441\u0442\u0438",
		FormatLabel: "\u0424\u043E\u0440\u043C\u0430\u0442",
		FormatPropertiesLabel: "\u041A\u0430\u043A \u043E\u0442\u043E\u0431\u0440\u0430\u0437\u0438\u0442\u044C",
		MaxCaption: "\u041C\u0430\u043A\u0441\u0438\u043C\u0443\u043C",
		MiddleFromCaption: "\u0421\u0440\u0435\u0434\u043D\u0435\u0435 \u043E\u0442",
		MiddleToCaption: "\u0421\u0440\u0435\u0434\u043D\u0435\u0435 \u0434\u043E",
		MinCaption: "\u041C\u0438\u043D\u0438\u043C\u0443\u043C",
		NewWidget: "\u041D\u043E\u0432\u0430\u044F \u0448\u043A\u0430\u043B\u0430",
		OrderDirectionCaption: "\u041F\u043E\u0440\u044F\u0434\u043E\u043A \u043E\u0442\u043E\u0431\u0440\u0430\u0436\u0435\u043D\u0438\u044F",
		QueryPropertiesLabel: "\u0427\u0442\u043E \u043E\u0442\u043E\u0431\u0440\u0430\u0437\u0438\u0442\u044C",
		RelatedObjectCaptionFormat: "\u041F\u043E\u043B\u0435 \u0441\u0432\u044F\u0437\u0438 \u043E\u0431\u044A\u0435\u043A\u0442\u0430 \u0022{0}\u0022 c {2} \u0022{1}\u0022",
		RelatedObjectDetail: "\u0434\u0435\u0442\u0430\u043B\u044C\u044E",
		RelatedObjectSection: "\u0440\u0430\u0437\u0434\u0435\u043B\u043E\u043C",
		SaveButtonCaption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		ScaleCaption: "\u0428\u043A\u0430\u043B\u0430",
		SectionBindingColumnCaption: "\u041D\u0435\u0442 \u0441\u0432\u044F\u0437\u0438 \u0441\u043E \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435\u0439",
		SectionBindingColumnFormat: "\u041F\u043E\u043B\u0435 \u0441\u0432\u044F\u0437\u0438 \u043E\u0431\u044A\u0435\u043A\u0442\u0430 \u0022{0}\u0022 \u0441\u043E \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435\u0439 \u0022{1}\u0022",
		SectionBindingGroupCaption: "\u041A\u0430\u043A \u0441\u0432\u044F\u0437\u0430\u0442\u044C \u0441\u043E \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435\u0439",
		StyleCaption: "\u0421\u0442\u0438\u043B\u044C",
		UseSectionFiltrationCaption: "\u0418\u0441\u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u044C \u0444\u0438\u043B\u044C\u0442\u0440 \u0440\u0430\u0437\u0434\u0435\u043B\u0430",
		WidgetDesignerCaption: "\u0414\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u0448\u043A\u0430\u043B\u044B"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ScaleUpIcon: {
			source: 3,
			params: {
				schemaName: "HomePageGaugeDesigner",
				resourceItemName: "ScaleUpIcon",
				hash: "bd70b8f2466ea4d1de3741542b12762d",
				resourceItemExtension: ".png"
			}
		},
		ScaleDownIcon: {
			source: 3,
			params: {
				schemaName: "HomePageGaugeDesigner",
				resourceItemName: "ScaleDownIcon",
				hash: "33114220e0908c122acdf81d3509d163",
				resourceItemExtension: ".svg"
			}
		},
		ScaleUpIconOverride: {
			source: 3,
			params: {
				schemaName: "HomePageGaugeDesigner",
				resourceItemName: "ScaleUpIconOverride",
				hash: "a4debe15b57b2f0e616aa0c13f0f6328",
				resourceItemExtension: ".svg"
			}
		},
		ScaleDownIconOverride: {
			source: 3,
			params: {
				schemaName: "HomePageGaugeDesigner",
				resourceItemName: "ScaleDownIconOverride",
				hash: "ca9e9418dfb1b2a0523a5db670edd02e",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});