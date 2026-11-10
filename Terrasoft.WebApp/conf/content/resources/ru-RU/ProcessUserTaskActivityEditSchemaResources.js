define("ProcessUserTaskActivityEditSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ActivityLinksCaption: "\u0421\u0432\u044F\u0437\u0438 \u0430\u043A\u0442\u0438\u0432\u043D\u043E\u0441\u0442\u0438",
		ActivityPriorityCaption: "\u041F\u0440\u0438\u043E\u0440\u0438\u0442\u0435\u0442",
		DaysCaption: "\u0434\u043D\u044F",
		DurationCaption: "\u041F\u043B\u0430\u043D\u043E\u0432\u0430\u044F \u0434\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C",
		HoursCaption: "\u0447\u0430\u0441\u043E\u0432",
		MinutesCaption: "\u043C\u0438\u043D\u0443\u0442",
		MonthsCaption: "\u043C\u0435\u0441\u044F\u0446\u0430",
		RemindBeforeCaption: "\u041D\u0430\u043F\u043E\u043C\u043D\u0438\u0442\u044C \u0437\u0430",
		ShowInSchedulerCaption: "\u041E\u0442\u043E\u0431\u0440\u0430\u0436\u0430\u0442\u044C \u0432 \u0440\u0430\u0441\u043F\u0438\u0441\u0430\u043D\u0438\u0438",
		StartInCaption: "\u0421\u0442\u0430\u0440\u0442\u043E\u0432\u0430\u0442\u044C \u0447\u0435\u0440\u0435\u0437",
		WeeksCaption: "\u043D\u0435\u0434\u0435\u043B\u044C"
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