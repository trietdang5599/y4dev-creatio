define("MLColumnSelectionSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddRootSchemaMenuItemCaption: "\u041A\u043E\u043B\u043E\u043D\u043A\u0443 \u043E\u0431\u044A\u0435\u043A\u0442\u0430",
		AddRootSchemaLinkedColumnCaption: "\u0421\u0432\u044F\u0437\u0430\u043D\u043D\u0443\u044E \u043A\u043E\u043B\u043E\u043D\u043A\u0443",
		NoData: "\u041D\u0435\u0442 \u0434\u0430\u043D\u043D\u044B\u0445"
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