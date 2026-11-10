define("EntityColumnMappingMixinResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		EntityColumnMapping_ColumnValuesLabelCaption: "Which column values to set for modified records?",
		EntityColumnMapping_AddRecordColumnValuesButtonCaption: "Add field",
		EntityColumnMapping_ProcessLookupPageCaption: "Select columns",
		EntityColumnMapping_DeleteMenuItemCaption: "Delete"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		EntityColumnMapping_AddButtonImage: {
			source: 3,
			params: {
				schemaName: "EntityColumnMappingMixin",
				resourceItemName: "EntityColumnMapping_AddButtonImage",
				hash: "6a1a82a3614d2620ae44e09a94b752ec",
				resourceItemExtension: ".png"
			}
		},
		EntityColumnMapping_ToolButtonImage: {
			source: 3,
			params: {
				schemaName: "EntityColumnMappingMixin",
				resourceItemName: "EntityColumnMapping_ToolButtonImage",
				hash: "51f50d3e7772d0dadb7c2bb05750a490",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});