define("ProcessUserTaskActivityEditSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ActivityLinksCaption: "Connected to",
		ActivityPriorityCaption: "Priority",
		DaysCaption: "days",
		DurationCaption: "Planned duration",
		HoursCaption: "hours",
		MinutesCaption: "minutes",
		MonthsCaption: "months",
		RemindBeforeCaption: "Remind in",
		ShowInSchedulerCaption: "Show in calendar",
		StartInCaption: "Start in",
		WeeksCaption: "weeks"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ProcessUserTaskActivityEditSchema",
				resourceItemName: "AddButtonImage",
				hash: "c54f23693e5ddb0a10a6757e6d6ecfc2",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});