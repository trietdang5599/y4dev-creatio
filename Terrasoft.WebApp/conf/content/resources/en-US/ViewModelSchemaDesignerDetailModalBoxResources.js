define("ViewModelSchemaDesignerDetailModalBoxResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DetailModalBoxSaveButtonCaption: "Save",
		DetailModalBoxCancelButtonCaption: "Cancel",
		WrongDetailCaptionLengthMessage: "Field group title cannot be longer than {0} characters",
		DetailModalBoxHeader: "Detail settings",
		DetailNameCaption: "Detail",
		DetailEntitySchemaColumnCaption: "Detail column",
		MasterEntitySchemaTitle: "Object column",
		DetailCaptionOnThePage: "Caption on the page",
		SelectValueCaption: "Please select value from the list",
		NameLabelCaption: "Code",
		DataSourceCaption: "What records to show on the page?",
		MasterSchemaTitle: "Equals to page column",
		DetailSchemaColumnCaption: "Where detail column",
		DuplicateDetailNameMessage: "Detail with this code already exists"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BackButtonImage: {
			source: 3,
			params: {
				schemaName: "ViewModelSchemaDesignerDetailModalBox",
				resourceItemName: "BackButtonImage",
				hash: "4d184b84a2c67d95553b4017a7154ad3",
				resourceItemExtension: ".png"
			}
		},
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "ViewModelSchemaDesignerDetailModalBox",
				resourceItemName: "CloseButtonImage",
				hash: "bcf2d4125a9751584d37cd8d0be121ca",
				resourceItemExtension: ".svg"
			}
		},
		ProcessButtonImage: {
			source: 3,
			params: {
				schemaName: "ViewModelSchemaDesignerDetailModalBox",
				resourceItemName: "ProcessButtonImage",
				hash: "6115d9cbfb41ebbb550c740d40604b48",
				resourceItemExtension: ".png"
			}
		},
		QuickAddButtonImage: {
			source: 3,
			params: {
				schemaName: "ViewModelSchemaDesignerDetailModalBox",
				resourceItemName: "QuickAddButtonImage",
				hash: "5e12a5f2ab5d04c2b8107f4b4e671176",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});