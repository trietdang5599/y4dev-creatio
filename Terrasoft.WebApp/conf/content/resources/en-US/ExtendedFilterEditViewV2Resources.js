define("ExtendedFilterEditViewV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SchemaNameStaticCaptionPart: "Filters setup ",
		SaveButtonCaption: "Save",
		ApplyButtonCaption: "Apply",
		ActionsButtonCaption: "Actions",
		GroupMenuItemCaption: "Group",
		UnGroupMenuItemCaption: "Ungroup",
		MoveUpMenuItemCaption: "Up",
		MoveDownMenuItemCaption: "Down",
		ExtendedFilterSettingsCaption: "Filters setup",
		CloseButtonCaption: "Close",
		BackButtonHint: "Go back to folder area",
		CloseButtonHint: "Close folder setup"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ClosePanelImage: {
			source: 3,
			params: {
				schemaName: "ExtendedFilterEditViewV2",
				resourceItemName: "ClosePanelImage",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		BackImage: {
			source: 3,
			params: {
				schemaName: "ExtendedFilterEditViewV2",
				resourceItemName: "BackImage",
				hash: "f3a598534aac8b2961300ada022ec476",
				resourceItemExtension: ".png"
			}
		},
		SearchFolderIcon: {
			source: 3,
			params: {
				schemaName: "ExtendedFilterEditViewV2",
				resourceItemName: "SearchFolderIcon",
				hash: "5af2275506420a0e3f762a1f2394181b",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});