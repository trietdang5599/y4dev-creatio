define("FileListViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "FileListViewGenerator",
				resourceItemName: "DeleteIcon",
				hash: "e3bb076d56173e65c4c41990fe8b0a2e",
				resourceItemExtension: ".png"
			}
		},
		SelectedArrow: {
			source: 3,
			params: {
				schemaName: "FileListViewGenerator",
				resourceItemName: "SelectedArrow",
				hash: "da82bda21f4913c648ff96fd00fabe56",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});