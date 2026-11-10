define("HomePageGaugeDesignerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WithoutFillTheme: "Plain white",
		FullFillTheme: "Fully colored",
		GaugeThemeLabel: "Gauge style",
		ColorCaption: "Color",
		AggregationColumnLabel: "Column",
		AggregationTypeLabel: "Function",
		AscendingOrder: "The more the better",
		CancelButtonCaption: "Cancel",
		CaptionLabel: "Title",
		DefaultRelatedObjectCaptionFormat: "Connect \u0022{0}\u0022 object with current object by field",
		DescendingOrder: "The less the better",
		DetailBindingColumnFormat: "",
		EntitySchemaNameLabel: "Object",
		FilterLabel: "Filter",
		FilterPropertiesLabel: "How to filter",
		FormatDecimalPrecision: "Number of digits after decimal point",
		FormatLabel: "Format",
		FormatPropertiesLabel: "How to display",
		MaxCaption: "Maximum",
		MiddleFromCaption: "Average from",
		MiddleToCaption: "Average to",
		MinCaption: "Minimum",
		NewWidget: "New gauge",
		OrderDirectionCaption: "Display order",
		QueryPropertiesLabel: "What to display",
		RelatedObjectCaptionFormat: "Connect \u0022{0}\u0022 object with \u0022{1}\u0022 {2} by field",
		RelatedObjectDetail: "detail",
		RelatedObjectSection: "section",
		SaveButtonCaption: "Save",
		ScaleCaption: "Scale",
		SectionBindingColumnCaption: "Not associated with page data",
		SectionBindingColumnFormat: "Connect \u0022{0}\u0022 object with \u0022{1}\u0022 page by field",
		SectionBindingGroupCaption: "How to associate with page data",
		StyleCaption: "Style",
		UseSectionFiltrationCaption: "Use section filter",
		WidgetDesignerCaption: "Gauge designer"
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