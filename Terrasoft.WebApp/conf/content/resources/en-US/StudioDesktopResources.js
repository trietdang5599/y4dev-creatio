define("StudioDesktopResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		IndicatorWidget_ActiveUsersNow_template: "{0}",
		IndicatorWidget_ActiveUsersNow_title: "Active users, now",
		IndicatorWidget_InstalledApplications_template: "{0}",
		IndicatorWidget_InstalledApplications_title: "Installed applications",
		ChartWidget_StartedProcessesToday_series_0: "Started processes",
		ChartWidget_StartedProcessesToday_title: "Started processes, today",
		Label_Greeting_caption: "Hello, [#Current user.Recipient Name#]!"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Studio Desktop"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});