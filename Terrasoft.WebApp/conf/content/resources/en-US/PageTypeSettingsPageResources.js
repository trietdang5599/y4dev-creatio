define("PageTypeSettingsPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		TypeColumnCaption: "Which field will determine the page layout?",
		TypeValueCaption: "Select the value of the \u0022{0}\u0022 field for which the new page will be used",
		HeaderCaption: "New page",
		ContinueButtonCaption: "Continue",
		SchemaCaptionColumnCaption: "Page name"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "PageTypeSettingsPage",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "PageTypeSettingsPage",
				resourceItemName: "CloseButtonImage",
				hash: "bcf2d4125a9751584d37cd8d0be121ca",
				resourceItemExtension: ".svg"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "PageTypeSettingsPage",
				resourceItemName: "ProcessButtonImage",
				hash: "6115d9cbfb41ebbb550c740d40604b48",
				resourceItemExtension: ".png"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "PageTypeSettingsPage",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});