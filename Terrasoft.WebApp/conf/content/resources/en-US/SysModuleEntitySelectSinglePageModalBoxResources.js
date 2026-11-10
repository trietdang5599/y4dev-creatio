define("SysModuleEntitySelectSinglePageModalBoxResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AcceptButtonCaption: "Save",
		HeaderCaption: "Return to single page layout",
		CancelBoxButtonCaption: "Cancel",
		WarningMessage: "All other page layouts will be deleted. This cannot be undone.",
		DescriptionMessage: "Choose the page layout you want to keep"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySelectSinglePageModalBox",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySelectSinglePageModalBox",
				resourceItemName: "CloseButtonImage",
				hash: "bcf2d4125a9751584d37cd8d0be121ca",
				resourceItemExtension: ".svg"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySelectSinglePageModalBox",
				resourceItemName: "ProcessButtonImage",
				hash: "6115d9cbfb41ebbb550c740d40604b48",
				resourceItemExtension: ".png"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySelectSinglePageModalBox",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		},
		InfoIcon: {
			source: 3,
			params: {
				schemaName: "SysModuleEntitySelectSinglePageModalBox",
				resourceItemName: "InfoIcon",
				hash: "2351461e423aa16ed15032b78e1f9c2c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});