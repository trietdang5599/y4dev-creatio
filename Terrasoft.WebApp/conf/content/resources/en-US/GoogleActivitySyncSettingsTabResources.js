define("GoogleActivitySyncSettingsTabResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		GoogleCalendarAutoSynchronization: "Synchronize calendar automatically",
		MultipleMinutesCaption: "every {0} minutes",
		OneMinuteCaption: "every minute",
		CalendarSyncIntervalCaption: "Synchronize calendar automatically",
		CalendarSyncDateCaption: "Synchronize activities starting from",
		ActiveCalendarDialogMessage: "You already have an active calendar",
		FieldValidationError: "Fields \u0022Synchronize activities starting from\u0022 and \u0022Synchronize calendar automatically\u0022 must be filled in. Specify the value",
		SyncDateLiesTooFarInThePastMessage: "Period of exporting data from Google is too long. Please specify a shorter period (15-20 days)."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});