define("SectionModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		GridDataViewCaption: "\u0414\u0430\u043D\u043D\u044B\u0435",
		AnalyticsDataViewCaption: "\u0414\u0430\u043D\u043D\u044B\u0435"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		GridDataViewIcon: {
			source: 3,
			params: {
				schemaName: "SectionModule",
				resourceItemName: "GridDataViewIcon",
				hash: "b4b597267efa8169f8050651a83a8a10",
				resourceItemExtension: ".png"
			}
		},
		AnalyticsDataViewIcon: {
			source: 3,
			params: {
				schemaName: "SectionModule",
				resourceItemName: "AnalyticsDataViewIcon",
				hash: "5bfc79db5b48ecec38834a54fdef650e",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});