define("MLColumnSelectionSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddRootSchemaMenuItemCaption: "Object\u0027s columns",
		AddRootSchemaLinkedColumnCaption: "Linked column",
		NoData: "No data available"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AddColumnMenuIcon: {
			source: 3,
			params: {
				schemaName: "MLColumnSelectionSchema",
				resourceItemName: "AddColumnMenuIcon",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		ClearIcon: {
			source: 3,
			params: {
				schemaName: "MLColumnSelectionSchema",
				resourceItemName: "ClearIcon",
				hash: "eea0fb9df467079344db40e55b70b743",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});