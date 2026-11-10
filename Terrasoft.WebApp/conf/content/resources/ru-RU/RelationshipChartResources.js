define("RelationshipChartResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddParentTooltip: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0440\u043E\u0434\u0438\u0442\u0435\u043B\u044C\u0441\u043A\u0438\u0439 \u044D\u043B\u0435\u043C\u0435\u043D\u0442",
		AddChildTooltip: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0434\u043E\u0447\u0435\u0440\u043D\u0438\u0439 \u044D\u043B\u0435\u043C\u0435\u043D\u0442",
		DeleteTooltip: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "RelationshipChart",
				resourceItemName: "DeleteIcon",
				hash: "c3fb4d1491598c4974ed65674490b110",
				resourceItemExtension: ".svg"
			}
		},
		AddIcon: {
			source: 3,
			params: {
				schemaName: "RelationshipChart",
				resourceItemName: "AddIcon",
				hash: "83fdff8cd37a68e64bf872f6656119a4",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});