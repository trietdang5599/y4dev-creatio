define("DashboardManagerItemResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CopyCaptionFormat: "{0} - Copy",
		InvalidJSONMessage: "Error while initializing dashboard \u0022{0}\u0022: \u0022{1}\u0022",
		CantShowDashboard: "Cannot display dashboard",
		CantShowDashboardHint: "Contact your system administrator"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		InfoImage: {
			source: 3,
			params: {
				schemaName: "DashboardManagerItem",
				resourceItemName: "InfoImage",
				hash: "0d2fe46bac31005b30ea5fb6de3b4984",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});