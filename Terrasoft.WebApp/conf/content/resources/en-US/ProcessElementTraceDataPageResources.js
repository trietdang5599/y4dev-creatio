define("ProcessElementTraceDataPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ParseTraceResponseErrorText: "Could not load trace data",
		TraceDataParameterCaption: "Parameter",
		TraceDataParameterValueAfterExecCaption: "After execution",
		TraceDataParameterValueBeforeExecCaption: "Before execution",
		TraceDataParameterValueCaption: "Value",
		TraceDataElementCaption: "Element parameters",
		TraceDataProcessCaption: "Process parameters"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "ProcessElementTraceDataPage",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});