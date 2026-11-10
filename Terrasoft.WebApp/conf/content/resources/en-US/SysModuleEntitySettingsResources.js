define("SysModuleEntitySettingsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ModuleSettingsGroupCaption: "Page settings:",
		SinglePageCaption: "One page for all records",
		MultiPageCaption: "Multiple pages",
		MultiPageDescription: "Different page layouts will be used for different record types. For example, you can show the \u201DAddress\u201D column for activities of the \u201CMeeting\u201D type but not show it for activities of the \u201CTask\u201D type.",
		AddPageButton: "New",
		DeleteConfirmationMessage: "Are you sure that you want to delete the edit page?",
		SingleEditPageCaptionTemplate: "Card schema: \u0022{0}\u0022",
		MultyEditPageCaptionTemplate: "Card schema: \u0022{0}\u0022 ({1})",
		SinglePageTypeCaption: "Single page",
		NewPageTypeCaption: "New page",
		WithoutTypeCaption: "Without type",
		TypeReferenceEntitySchemaCaptionMask: "Section object type \u0022{0}\u0022",
		TypeColumnCaption: "Type",
		GridTypeColumnCaption: "Pages",
		GridDescriptionColumnCaption: "Current page",
		AllTypedPageValidateMessageMask: "You have not finished setting up multiple pages. Specify the value of the \u0022{0}\u0022 column for each page layout.",
		MultiPageGridCaption: "Use different page layout depending on the column value",
		OnDeleteLastPageMessage: "You cannot delete the last page.",
		ConvertToSinglePageModalBoxHeader: "Return to single page",
		ConvertToSinglePageModalBoxWarning: "All other pages will be deleted",
		ConvertToSinglePageModalBoxControlLabel: "Choose the page you want to keep",
		ChangeTypeColumnModalBoxHeader: "Page settings",
		ChangeTypeColumnModalBoxWarning: "Changing the column which identifies different pages will delete all pages except selected below.",
		ChangeTypeColumnModalBoxControlLabel: "Choose the page you want to keep",
		SingleSysModuleEditCaptionTemplate: "New"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySettings",
				resourceItemName: "AddButtonImage",
				hash: "6a1a82a3614d2620ae44e09a94b752ec",
				resourceItemExtension: ".png"
			}
		},
		SaveIcon: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySettings",
				resourceItemName: "SaveIcon",
				hash: "575a68319ee12f0eeea80d5e96d20b8c",
				resourceItemExtension: ".png"
			}
		},
		CancelIcon: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySettings",
				resourceItemName: "CancelIcon",
				hash: "4d7e95ef8492814296ac405a885ad87f",
				resourceItemExtension: ".png"
			}
		},
		RemoveIcon: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySettings",
				resourceItemName: "RemoveIcon",
				hash: "bd597784a7b16552632811674f869a11",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});