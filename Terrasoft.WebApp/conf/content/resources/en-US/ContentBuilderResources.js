define("ContentBuilderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PreviewBlockCaption: "Block library",
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		ContentSheetPlaceholder: "Drag block here",
		PreviewButtonCaption: "Preview",
		CancelMessage: "Discard changes",
		WidthIncorrectMinValueValidationMessage: "{0} px minimum",
		DefaultCaption: "Content designer",
		PxLabelCaption: "px",
		WidthIncorrectMaxValueValidationMessage: "{0} px maximum",
		MacroTemplate: "[#{0}#]",
		EmptyMacrosEntityMessage: "There is no entity for column selection.",
		SheetPositionCaption: "Position",
		SheetWidthCaption: "Width",
		SearchPlaceholder: "Search",
		ElementsGroupCaption: "Elements",
		GridElementsLabelCaption: "Grid Elements",
		UserBlocksGroupCaption: "User blocks",
		MigrateButtonCaption: "Migrate",
		ContentBuilderStateErrorMessage: "Save action is blocked. Turn on feature \u0022{0}\u0022 to edit template",
		Caption: "Template",
		SearchUserBlockPlaceholder: "Enter name of block",
		DeleteUserBlockQuestion: "Are you sure that you want to delete the block \u0022{0}\u0022 from the Block Library?",
		PropertiesPageCaption: "Template settings",
		PropertiesPageContextHelp: "Template allows to set basic styles for content. \u003Ca href=\u0022{0}\u0022 data-context-help-code=\u0022ContentTemplateProperties\u0022 target=\u0022_blank\u0022\u003ERead more\u003C/a\u003E"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultBlockImage: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "DefaultBlockImage",
				hash: "a7c2fa85d3678fea73d83d75a3fe5778",
				resourceItemExtension: ".png"
			}
		},
		SheetSettingsButton: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SheetSettingsButton",
				hash: "54b2b0a5d74696111ea5737ffcd6fdb3",
				resourceItemExtension: ".png"
			}
		},
		SettingsButtonIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SettingsButtonIcon",
				hash: "60d54200d901c207568e8f6154229252",
				resourceItemExtension: ".png"
			}
		},
		SearchIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SearchIcon",
				hash: "c0960e5d98faf61a2a5532aba9a8ccd0",
				resourceItemExtension: ".svg"
			}
		},
		SearchUserBlockIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SearchUserBlockIcon",
				hash: "ef96400dd632c3b0ed257d5c577f05b2",
				resourceItemExtension: ".svg"
			}
		},
		PropertiesPageIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "PropertiesPageIcon",
				hash: "738d5d03e8b8231882e0338b44d66fbc",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});