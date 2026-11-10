define("GridSettingsDesignerContainerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ColumlLimitExceededMessage: "Column limit exceeded ({0})",
		CanNotRemoveColumnMessageTpl: "You can not delete a column that is used in a formula. First edit the formula in field: {0}.",
		ChangesWillNotBeAppliedInFormulaMessageTpl: "Changes to the column will not affect calculations in formula: {0}."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ChangeIcon: {
			source: 3,
			params: {
				schemaName: "GridSettingsDesignerContainer",
				resourceItemName: "ChangeIcon",
				hash: "5da86868faed4ae499027eee95bb3bb2",
				resourceItemExtension: ".svg"
			}
		},
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "GridSettingsDesignerContainer",
				resourceItemName: "DeleteIcon",
				hash: "4e5c557d7ebbc8cb3e3f547550135401",
				resourceItemExtension: ".svg"
			}
		},
		AddIcon: {
			source: 3,
			params: {
				schemaName: "GridSettingsDesignerContainer",
				resourceItemName: "AddIcon",
				hash: "a3482369679073270ead2927bea2c5ad",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});