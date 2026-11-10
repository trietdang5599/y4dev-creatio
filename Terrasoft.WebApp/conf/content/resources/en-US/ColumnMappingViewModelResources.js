define("ColumnMappingViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SelectColumnButtonCaption: "Select column",
		AddReferenceSchemaColumnButtonCaption: "Additional contact details",
		InvalidObjectRights: "Insufficient permissions to add record in object \u0022{0}\u0022"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		EmptyDestinationImage: {
			source: 3,
			params: {
				schemaName: "ColumnMappingViewModel",
				resourceItemName: "EmptyDestinationImage",
				hash: "9ae2a22bd40ead8a8d2aa7cd78fd41cf",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});