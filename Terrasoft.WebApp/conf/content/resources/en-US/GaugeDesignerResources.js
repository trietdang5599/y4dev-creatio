define("GaugeDesignerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WidgetDesignerCaption: "Gauge designer",
		NewWidget: "New gauge",
		MinCaption: "Minimum",
		MiddleFromCaption: "Average from",
		MiddleToCaption: "Average to",
		MaxCaption: "Maximum",
		OrderDirectionCaption: "Display order",
		StyleCaption: "Style",
		AscendingOrder: "The more the better",
		DescendingOrder: "The less the better",
		ScaleCaption: "Scale"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ScaleUpIcon: {
			source: 3,
			params: {
				schemaName: "GaugeDesigner",
				resourceItemName: "ScaleUpIcon",
				hash: "bd70b8f2466ea4d1de3741542b12762d",
				resourceItemExtension: ".png"
			}
		},
		ScaleDownIcon: {
			source: 3,
			params: {
				schemaName: "GaugeDesigner",
				resourceItemName: "ScaleDownIcon",
				hash: "33114220e0908c122acdf81d3509d163",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});