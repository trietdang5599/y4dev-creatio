define("GridUtilitiesResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OpenSettingPageCaption: "Set up summaries",
		OpenGridSettingsPageCaption: "Select fields to display",
		LoadButtonCaption: "Show more",
		SortCaption: "Sort by",
		AscendingDirectionCaption: "ascending order",
		DescendingDirectionCaption: "descending order",
		DependencyWarningMessage: "Selected items cannot be deleted because they are used in other objects.",
		RightLevelWarningMessage: "You do not have permission to delete these items.",
		Deleting: "Executing",
		ActionsButtonCaption: "View"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SettingsButtonImage: {
			source: 3,
			params: {
				schemaName: "GridUtilities",
				resourceItemName: "SettingsButtonImage",
				hash: "de93213e4131c0b5b91f465fde41f75a",
				resourceItemExtension: ".png"
			}
		},
		MoreArrowIcon: {
			source: 3,
			params: {
				schemaName: "GridUtilities",
				resourceItemName: "MoreArrowIcon",
				hash: "d757aaf069c75446184760d4935622e9",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "GridUtilities",
				resourceItemName: "AddButtonImage",
				hash: "57156eb4fb845713d16b9e10db32d805",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});