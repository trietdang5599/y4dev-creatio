define("SyncSettingsMixinResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ErrorOnGettingSyncSettings: "Failed to get synchronization settings",
		SynchronizeWith: "Synchronize with {0}",
		SetUpExistsSyncSettings: "Set up {0}",
		ActiveCalendarDialogMessage: "You already have an active calendar"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});