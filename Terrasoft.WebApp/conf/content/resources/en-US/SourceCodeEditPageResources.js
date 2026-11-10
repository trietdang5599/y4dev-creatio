define("SourceCodeEditPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowFindWindowButtonHint: "Search",
		ShowWhitespacesButtonHint: "Show white space",
		ExpandButtonHint: "Expand (F2)",
		CollapseButtonHint: "Collapse (F2)",
		UseFlowEngineBodyHint: "The logic of working with process parameters was changed for interpretable processes. To work with parameters, use \u0022Set\u0022 and \u0022Get\u0022 methods. \u003Cbr/\u003E\u003Ca href=\u0022#\u0022 data-context-help-code=\u0022ScriptTaskPropertiesPage\u0022\u003ERead more...\u003C/a\u003E"
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