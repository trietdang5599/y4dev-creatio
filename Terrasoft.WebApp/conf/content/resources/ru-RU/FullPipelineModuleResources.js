define("FullPipelineModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		StageConversionCaption: "\u041A\u043E\u043D\u0432\u0435\u0440\u0441\u0438\u044F \u0441\u0442\u0430\u0434\u0438\u0438",
		ToFirstStageConversionCaption: "\u041A \u043F\u0435\u0440\u0432\u043E\u0439 \u0441\u0442\u0430\u0434\u0438\u0438",
		ConversionByCountCaption: "\u041F\u043E \u043A\u043E\u043B\u0438\u0447\u0435\u0441\u0442\u0432\u0443",
		YesterdayCaption: "\u0412\u0447\u0435\u0440\u0430",
		TodayCaption: "\u0421\u0435\u0433\u043E\u0434\u043D\u044F",
		TomorrowCaption: "\u0417\u0430\u0432\u0442\u0440\u0430",
		PastWeekCaption: "\u041F\u0440\u043E\u0448\u043B\u0430\u044F \u043D\u0435\u0434\u0435\u043B\u044F",
		CurrentWeekCaption: "\u0422\u0435\u043A\u0443\u0449\u0430\u044F \u043D\u0435\u0434\u0435\u043B\u044F",
		NextWeekCaption: "\u0421\u043B\u0435\u0434\u0443\u044E\u0449\u0430\u044F \u043D\u0435\u0434\u0435\u043B\u044F",
		PastMonthCaption: "\u041F\u0440\u043E\u0448\u043B\u044B\u0439 \u043C\u0435\u0441\u044F\u0446",
		CurrentMonthCaption: "\u0422\u0435\u043A\u0443\u0449\u0438\u0439 \u043C\u0435\u0441\u044F\u0446",
		NextMonthCaption: "\u0421\u043B\u0435\u0434\u0443\u044E\u0449\u0438\u0439 \u043C\u0435\u0441\u044F\u0446",
		ClearCaption: "\u041E\u0447\u0438\u0441\u0442\u0438\u0442\u044C",
		PeriodToLabelCaption: "\u043F\u043E",
		EmptyDateDisplayValue: "\u043D\u0435 \u043E\u0433\u0440\u0430\u043D\u0438\u0447\u0435\u043D\u043E",
		StartDatePlaceholder: "\u003C\u041D\u0430\u0447\u0430\u043B\u043E\u003E",
		DueDatePlaceholder: "\u003C\u0417\u0430\u0432\u0435\u0440\u0448\u0435\u043D\u0438\u0435\u003E",
		SelectPeriodHint: "\u0412\u044B\u0431\u0440\u0430\u0442\u044C \u043F\u0435\u0440\u0438\u043E\u0434",
		RemoveButtonHint: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C \u0444\u0438\u043B\u044C\u0442\u0440"
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