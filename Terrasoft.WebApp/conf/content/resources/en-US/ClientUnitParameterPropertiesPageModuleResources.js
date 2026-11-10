define("ClientUnitParameterPropertiesPageModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		isRequiredLabel: "Is required parameter",
		LabelCaption: "Title",
		NewColumnCaption: "New parameter",
		DesignerCaption: "Parameter",
		LenghtMessage: "Length is different for the process parameter and the page. If you change precision/format/length, it will affect both the process parameter and the page.",
		PrecisionMessage: "Column Precision is different for the process parameter and the page. If you change precision, it will affect both the process parameter and the page.",
		DateMessage: "Format is different for the process parameter and the page. If you change format, it will affect both the process parameter and the page."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});