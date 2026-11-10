define("FullPipelineModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		StageConversionCaption: "Stage conversion rate",
		ToFirstStageConversionCaption: "Pipeline conversion",
		ConversionByCountCaption: "Number of records",
		YesterdayCaption: "Yesterday",
		TodayCaption: "Today",
		TomorrowCaption: "Tomorrow",
		PastWeekCaption: "Previous week",
		CurrentWeekCaption: "Current week",
		NextWeekCaption: "Next week",
		PastMonthCaption: "Previous month",
		CurrentMonthCaption: "Current month",
		NextMonthCaption: "Next month",
		ClearCaption: "Clear",
		PeriodToLabelCaption: "till",
		EmptyDateDisplayValue: "unlimited",
		StartDatePlaceholder: "\u003CStart date\u003E",
		DueDatePlaceholder: "\u003CDue date\u003E",
		SelectPeriodHint: "Select period",
		RemoveButtonHint: "Remove filter"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		MonthPeriodButtonImage: {
			source: 3,
			params: {
				schemaName: "FullPipelineModule",
				resourceItemName: "MonthPeriodButtonImage",
				hash: "6b4d71fc7d7f7a2e53eba5af3be93511",
				resourceItemExtension: ".png"
			}
		},
		WeekPeriodButtonImage: {
			source: 3,
			params: {
				schemaName: "FullPipelineModule",
				resourceItemName: "WeekPeriodButtonImage",
				hash: "a5588b7ec5578919e824c959a31d1604",
				resourceItemExtension: ".png"
			}
		},
		DayPeriodButtonImage: {
			source: 3,
			params: {
				schemaName: "FullPipelineModule",
				resourceItemName: "DayPeriodButtonImage",
				hash: "feab677ed3bc1e15a0b3219496f2113a",
				resourceItemExtension: ".png"
			}
		},
		RemoveButtonImage: {
			source: 3,
			params: {
				schemaName: "FullPipelineModule",
				resourceItemName: "RemoveButtonImage",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});