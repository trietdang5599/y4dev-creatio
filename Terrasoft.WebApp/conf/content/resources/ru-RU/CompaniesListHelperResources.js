define("CompaniesListHelperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SuggestedCompaniesHeader: "\u041F\u0440\u0435\u0434\u043E\u0441\u0442\u0430\u0432\u043B\u0435\u043D\u043E",
		ProvidedByCompanyName: "Clearbit"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultLogo: {
			source: 3,
			params: {
				schemaName: "CompaniesListHelper",
				resourceItemName: "DefaultLogo",
				hash: "421751696ddf1170585f8f1f05f263fe",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});