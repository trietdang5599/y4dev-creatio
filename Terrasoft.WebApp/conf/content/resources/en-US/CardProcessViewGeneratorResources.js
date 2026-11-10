define("CardProcessViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WhatCanIDoForYou: "What can I do for you?",
		SaveButtonCaption: "Save",
		ChangeButtonCaption: "Edit",
		DoLaterButtonCaption: "Fill in later",
		CancelButtonCaption: "Cancel",
		ActionButtonCaption: "Actions",
		GotoButtonCaption: "Go to",
		ViewButtonCaption: "View",
		RightsButtonCaption: "Access rights",
		ShowAllButtonCaption: "Show all fields",
		EditPageCaption: "Page designer"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ContactPhoto: {
			source: 3,
			params: {
				schemaName: "CardProcessViewGenerator",
				resourceItemName: "ContactPhoto",
				hash: "6660dfa270095f8b29a2288fc12aad6d",
				resourceItemExtension: ".png"
			}
		},
		InfoImage: {
			source: 3,
			params: {
				schemaName: "CardProcessViewGenerator",
				resourceItemName: "InfoImage",
				hash: "5d1082888ff8b8984fa8e6ef315e4251",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});