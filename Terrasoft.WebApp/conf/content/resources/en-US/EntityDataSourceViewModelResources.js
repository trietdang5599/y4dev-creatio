define("EntityDataSourceViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NewFieldsDisabledMessage: "This elements is not available",
		NewFieldsDisabledToolTipMessage: "Adding new fields for DB view schemas is not available. Contact your system administrator.",
		NewColumnCaption: "New column",
		ExistingColumnsCaption: "Existing columns",
		Caption: ""
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		InfoSpriteImage: {
			source: 3,
			params: {
				schemaName: "EntityDataSourceViewModel",
				resourceItemName: "InfoSpriteImage",
				hash: "c253d8a46fdd8595204eb650dd35e982",
				resourceItemExtension: ".png"
			}
		},
		DataModelImage: {
			source: 3,
			params: {
				schemaName: "EntityDataSourceViewModel",
				resourceItemName: "DataModelImage",
				hash: "fc45fee87c114c7343be50ce48baa66d",
				resourceItemExtension: ".svg"
			}
		},
		DataModelMenuImage: {
			source: 3,
			params: {
				schemaName: "EntityDataSourceViewModel",
				resourceItemName: "DataModelMenuImage",
				hash: "df03c3177a972b7f3b6987430f988ca3",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});