define("GridSettingsViewGeneratorV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		PageCaption: "List setup",
		SetButtonCaption: "Set",
		DeleteButtonCaption: "Delete",
		ExpandButtonCaption: "\u002B",
		NarrowButtonCaption: "-",
		SaveForAllButtonButtonCaption: "Save for all users",
		TiledCaption: "Tile view",
		ListedCaption: "List view",
		VerticalCaption: "Vertical list",
		UpButtonCaption: "\u25B2",
		DownButtonCaption: "\u25BC",
		ExpandLabelCaption: "Change width",
		UpLabelCaption: "Change height",
		ColumnWidthHint: "Column width"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		PlusButtonImage: {
			source: 3,
			params: {
				schemaName: "GridSettingsViewGeneratorV2",
				resourceItemName: "PlusButtonImage",
				hash: "1bbc131cf118e9ffd8fe571aed9bdaf7",
				resourceItemExtension: ".png"
			}
		},
		MinusButtonImage: {
			source: 3,
			params: {
				schemaName: "GridSettingsViewGeneratorV2",
				resourceItemName: "MinusButtonImage",
				hash: "6a12de9c4544bf69861e94068ebbd29c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});