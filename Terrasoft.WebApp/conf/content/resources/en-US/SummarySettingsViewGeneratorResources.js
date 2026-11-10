define("SummarySettingsViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		AddButtonCaption: "New",
		AddColumnButtonCaption: "Add row",
		DisplayRecordCountCaption: "Display number of records",
		ColumnHeaderCaption: "Column",
		ColumnFuncCaption: "Function",
		ColumnTitleCaption: "Title"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageDeleteButton: {
			source: 3,
			params: {
				schemaName: "SummarySettingsViewGenerator",
				resourceItemName: "ImageDeleteButton",
				hash: "2185ea9274f8cece0b49039f21947286",
				resourceItemExtension: ".png"
			}
		},
		ImageConfirmButton: {
			source: 3,
			params: {
				schemaName: "SummarySettingsViewGenerator",
				resourceItemName: "ImageConfirmButton",
				hash: "18e29d509e192058502f9a936a2dd85f",
				resourceItemExtension: ".png"
			}
		},
		ImageDiscardButton: {
			source: 3,
			params: {
				schemaName: "SummarySettingsViewGenerator",
				resourceItemName: "ImageDiscardButton",
				hash: "50670ba55c24903c8a285e68eebebdb0",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});