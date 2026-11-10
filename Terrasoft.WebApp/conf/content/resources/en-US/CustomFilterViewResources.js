define("CustomFilterViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddConditionMenuItemCaption: "Add filter",
		ShowFoldersMenuItemCaption: "Show folders",
		ExtendedModeMenuItemCaption: "Switch to advanced mode",
		ClearFilterMenuItemCaption: "Clear",
		SaveAsDynamicFolderMenuItemCaption: "Save as dynamic folder",
		SimpleFilterEmptyColumnEditPlaceHolder: "Column",
		SimpleFilterEmptyValueEditPlaceHolder: "Value"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageFilter: {
			source: 3,
			params: {
				schemaName: "CustomFilterView",
				resourceItemName: "ImageFilter",
				hash: "a2a46afd3afbdcad5d1c1dafa8307a93",
				resourceItemExtension: ".png"
			}
		},
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "CustomFilterView",
				resourceItemName: "ApplyButtonImage",
				hash: "18e29d509e192058502f9a936a2dd85f",
				resourceItemExtension: ".png"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "CustomFilterView",
				resourceItemName: "CancelButtonImage",
				hash: "50670ba55c24903c8a285e68eebebdb0",
				resourceItemExtension: ".png"
			}
		},
		RemoveButtonImage: {
			source: 3,
			params: {
				schemaName: "CustomFilterView",
				resourceItemName: "RemoveButtonImage",
				hash: "2185ea9274f8cece0b49039f21947286",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});