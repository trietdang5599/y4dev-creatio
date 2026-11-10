define("TagModuleSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddNewPrivateTagCaption: "New private tag {0}",
		AddNewCorporateTagCaption: "New corporate tag {0}",
		AddNewPublicTagCaption: "New public tag {0}",
		TagsHeaderLabelCaption: "Tags",
		PlaceholderText: "Enter tag name",
		EntityTagSchemaIsEmptyMessage: "Tags object schema name not entered.",
		NoRightsToAdd: "Insufficient rights to add record to the \u0022{0}\u0022 object"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CreateNewPrivateTagIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "CreateNewPrivateTagIcon",
				hash: "e4138ed6e03c8eb96fc3ea267b751006",
				resourceItemExtension: ".png"
			}
		},
		CreateNewCorporateTagIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "CreateNewCorporateTagIcon",
				hash: "ab2971fe5445cf9a8becd1cdfd793a30",
				resourceItemExtension: ".png"
			}
		},
		CreateNewPublicTagIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "CreateNewPublicTagIcon",
				hash: "7517f7692f0a3aaee666af9601a731e8",
				resourceItemExtension: ".png"
			}
		},
		ExistsPrivateTagIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "ExistsPrivateTagIcon",
				hash: "0192a23102c02be604c3c5734b99c3ec",
				resourceItemExtension: ".png"
			}
		},
		ExistsCorporateTagIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "ExistsCorporateTagIcon",
				hash: "f17e638132bb5471f4705c52a7f3fa96",
				resourceItemExtension: ".png"
			}
		},
		ExistsPublicTagIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "ExistsPublicTagIcon",
				hash: "d295fbb57fef4b0857a9f9d7761b81b3",
				resourceItemExtension: ".png"
			}
		},
		RemoveTagFromEntityIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "RemoveTagFromEntityIcon",
				hash: "475a4ce49b197d6768eb41b087a35645",
				resourceItemExtension: ".png"
			}
		},
		LookupRightIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "LookupRightIcon",
				hash: "9bc3210805e83a3df60a1ab6a370dbfc",
				resourceItemExtension: ".png"
			}
		},
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "TagModuleSchema",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});