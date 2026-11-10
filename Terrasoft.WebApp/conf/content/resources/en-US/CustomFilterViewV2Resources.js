define("CustomFilterViewV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddConditionMenuItemCaption: "Add filter",
		ShowFoldersMenuItemCaption: "Show folders",
		ExtendedModeMenuItemCaption: "Switch to advanced mode",
		ClearFilterMenuItemCaption: "Clear",
		SaveAsDynamicFolderMenuItemCaption: "Save as dynamic folder",
		SimpleFilterEmptyColumnEditPlaceHolder: "Column",
		SimpleFilterEmptyValueEditPlaceHolder: "Value",
		FavoriteFoldersMenuItemCaption: "Favorite folders",
		ApplyButtonHint: "Apply filter",
		CancelButtonHint: "Reset filter"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "CustomFilterViewV2",
				resourceItemName: "ApplyButtonImage",
				hash: "88768289520a58c95c434b7c53ee902c",
				resourceItemExtension: ".png"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "CustomFilterViewV2",
				resourceItemName: "CancelButtonImage",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		RemoveButtonImage: {
			source: 3,
			params: {
				schemaName: "CustomFilterViewV2",
				resourceItemName: "RemoveButtonImage",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		CollapseFiltersImage: {
			source: 3,
			params: {
				schemaName: "CustomFilterViewV2",
				resourceItemName: "CollapseFiltersImage",
				hash: "5c76488182d7112c0aea29cc61a974b4",
				resourceItemExtension: ".png"
			}
		},
		ImageFilter: {
			source: 3,
			params: {
				schemaName: "CustomFilterViewV2",
				resourceItemName: "ImageFilter",
				hash: "124f910abe91ebe4045613a9c5b379d1",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});