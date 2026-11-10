define("ExtendedFilterEditViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SchemaNameStaticCaptionPart: "Filters setup ",
		SaveButtonCaption: "Save",
		ApplyButtonCaption: "Apply",
		ActionsButtonCaption: "Actions",
		GroupMenuItemCaption: "Group",
		UnGroupMenuItemCaption: "Ungroup",
		MoveUpMenuItemCaption: "Up",
		MoveDownMenuItemCaption: "Down",
		ExtendedFilterSettingsCaption: "Filters setup"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ClosePanelImage: {
			source: 3,
			params: {
				schemaName: "ExtendedFilterEditView",
				resourceItemName: "ClosePanelImage",
				hash: "3d98349cbb44e7437232b5495e902d47",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});