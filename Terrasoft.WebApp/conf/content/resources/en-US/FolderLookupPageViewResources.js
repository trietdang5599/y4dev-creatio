define("FolderLookupPageViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SelectButtonCaption: "Select",
		CancelButtonCaption: "Cancel",
		ActionButtonCaption: "Actions",
		SelectFoldersMenuItemCaption: "Select multiple folders",
		SelectFolderMenuItemCaption: "Select folder",
		FolderMenuSeparatorCaption: "FOLDER",
		CreateStaticMenuItemCaption: "New static folder",
		CreateDynamicMenuItemCaption: "New dynamic folder",
		CopyMenuItemCaption: "Copy",
		RenameMenuItemCaption: "Rename",
		DeleteMenuItemCaption: "Delete",
		SaveButtonCaption: "Save filter",
		GroupMenuItemCaption: "Group",
		UnGroupMenuItemCaption: "Ungroup",
		MoveUpMenuItemCaption: "Up",
		MoveDownMenuItemCaption: "Down",
		MoveMenuItemCaption: "Move",
		EditRightsMenuItemCaption: "Set up access rights",
		FilterGroupCaption: "Filter",
		ClearButtonCaption: "Clear"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "FolderLookupPageView",
				resourceItemName: "ApplyButtonImage",
				hash: "18e29d509e192058502f9a936a2dd85f",
				resourceItemExtension: ".png"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "FolderLookupPageView",
				resourceItemName: "CancelButtonImage",
				hash: "50670ba55c24903c8a285e68eebebdb0",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});