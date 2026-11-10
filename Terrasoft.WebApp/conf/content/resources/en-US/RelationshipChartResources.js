define("RelationshipChartResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddParentTooltip: "Add parent element",
		AddChildTooltip: "Add child element",
		DeleteTooltip: "Delete"
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