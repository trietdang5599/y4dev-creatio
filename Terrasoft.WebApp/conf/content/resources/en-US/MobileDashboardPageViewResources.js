define("MobileDashboardPageViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MobileDashboardPageTitle: "Dashboards",
		MobileDashboardPageNoDataLabelText: "Data in the section is available with Internet connection only",
		MobileDashboardPageNoDashboardsText: "No dashboards available"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		IconArrowDownWhite: {
			source: 3,
			params: {
				schemaName: "MobileDashboardPageView",
				resourceItemName: "IconArrowDownWhite",
				hash: "20fbee73a1152b70cd94a11912d75c8e",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});