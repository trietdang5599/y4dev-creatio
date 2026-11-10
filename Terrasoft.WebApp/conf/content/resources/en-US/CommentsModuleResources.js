define("CommentsModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ViewMoreCaption: "Show more {0}",
		DeleteMessage: "Are you sure that you want to delete the comment?",
		EditButtonCaption: "Edit",
		DeleteButtonCaption: "Delete",
		AddCommentWatermark: "Add comment",
		InfoDataSeparator: " in "
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SelectedArrow: {
			source: 3,
			params: {
				schemaName: "CommentsModule",
				resourceItemName: "SelectedArrow",
				hash: "da82bda21f4913c648ff96fd00fabe56",
				resourceItemExtension: ".png"
			}
		},
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "CommentsModule",
				resourceItemName: "DeleteIcon",
				hash: "e3bb076d56173e65c4c41990fe8b0a2e",
				resourceItemExtension: ".png"
			}
		},
		EditIcon: {
			source: 3,
			params: {
				schemaName: "CommentsModule",
				resourceItemName: "EditIcon",
				hash: "26fa3135f108e0937c35ea2726cba063",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});