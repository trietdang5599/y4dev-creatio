define("BusinessRulesApplierV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		InvalidRuleFormatExceptionException: "Invalid rule format \u0022{0}\u0022",
		ThrownException: "Exception was thrown in method \u0027{0}\u0027 with text: \u0027{1}\u0027.",
		ConditionFieldIsPresentedInActionError: "Error in \u0022{0}\u0022 business rule: condition must not contain fields from action",
		InvalidActionColumnError: "Error in \u0022{0}\u0022 business rule: \u0022{1}\u0022 action column was deleted or renamed",
		InvalidSysSetting: "Error in business rule: \u0022{0}\u0022 system setting was deleted or renamed",
		InvalidColumn: "Error in business rule: \u0022{0}\u0022 column was deleted or renamed",
		InvalidSysValue: "Error in business rule: \u0022{0}\u0022 system value was deleted or renamed",
		InvalidTabExceptionMessage: "Error in business rule: \u0022{0}\u0022 tab was deleted or renamed"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});