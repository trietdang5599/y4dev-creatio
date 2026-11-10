define("SummaryViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OpenSettingPageCaption: "Set up summaries",
		OpenGridSettingsPageCaption: "Select fields to display"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageDeleteButton: {
			source: 3,
			params: {
				schemaName: "SummaryView",
				resourceItemName: "ImageDeleteButton",
				hash: "2185ea9274f8cece0b49039f21947286",
				resourceItemExtension: ".png"
			}
		},
		ImageOpenButton: {
			source: 3,
			params: {
				schemaName: "SummaryView",
				resourceItemName: "ImageOpenButton",
				hash: "de93213e4131c0b5b91f465fde41f75a",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});