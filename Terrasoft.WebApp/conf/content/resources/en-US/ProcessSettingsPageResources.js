define("ProcessSettingsPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ModalBoxCaption: "Business process launch settings",
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		ProcessSelectionLabel: "Which process to run?",
		ParameterSelectionLabel: "Process parameter where the record is passed",
		RunByRecordCaption: "For selected record",
		RunWithoutRecordCaption: "Regardless of record",
		ParameterRecordPlaceholder: "Select parameter",
		ParameterRecordNotFoundPlaceholder: "Parameters not found",
		AddProcessButtonHintCaption: "Add new process",
		OpenProcessButtonHintCaption: "Open process designer"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "ProcessSettingsPage",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessSettingsPage",
				resourceItemName: "AddButtonImage",
				hash: "d30933184bec2d3279aaeda342cc0943",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessSettingsPage",
				resourceItemName: "OpenButtonImage",
				hash: "dbe272c4aa382cf59c0b35a74280c79d",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});