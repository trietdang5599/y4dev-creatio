define("ActivitySyncSettingsTabResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		LoadAllAppointments: "Import all appointments and meetings",
		LoadAppointmentsFromCalendars: "Import appointments and meetings from specific MS Exchange calendars",
		LoadAllTasks: "Import all tasks",
		LoadTasksFromFolders: "Import tasks from specific MS Exchange calendars",
		ExportActivitiesFromGroupsCaption: "Export tasks and meetings from specific folders",
		ExportActivitiesAllCaption: "Export all tasks and meetings",
		ExchangeAutoSynchronization: "Synchronize calendar automatically",
		ActiveCalendarDialogMessage: "You already have an active calendar"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});