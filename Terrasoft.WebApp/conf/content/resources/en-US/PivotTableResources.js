define("PivotTableResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NotFilledValue: "(blank)",
		LimitExceededMessage: "You have reached the limit on the number of displayed rows or columns. Please change the field settings for the pivot table to work correctly.",
		LoadingErrorMessage: "Error during calculations in the pivot table.",
		RequestDataLimitExceededMessage: "Unable to upload all records. Maximum limit of {0} records reached. Lower the number of records using additional filters or increase the limit in the \u0022Request limit for pivot table data\u0022 (\u0022PivotTableRequestDataLimit\u0022 code) system setting."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});