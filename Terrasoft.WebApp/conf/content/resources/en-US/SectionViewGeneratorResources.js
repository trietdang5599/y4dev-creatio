define("SectionViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowMoreButtonCaption: "Show more",
		AddButtonCaption: "New",
		EditButtonCaption: "Edit",
		CopyButtonCaption: "Copy",
		DeleteButtonCaption: "Delete",
		ViewButtonCaption: "View",
		graphiscsCaption: "Charts",
		ReportCaption: "Reports"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageOpenButton: {
			source: 3,
			params: {
				schemaName: "SectionViewGenerator",
				resourceItemName: "ImageOpenButton",
				hash: "de93213e4131c0b5b91f465fde41f75a",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});