define("FixedFilterViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
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
		QuickListSettingsCaption: "Set up quick list",
		PeriodToLabelCaption: "till",
		EmptyDateDisplayValue: "unlimited",
		StartDatePlaceholder: "\u003CStart date\u003E",
		DueDatePlaceholder: "\u003CDue date\u003E"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		PeriodButtonImage: {
			source: 3,
			params: {
				schemaName: "FixedFilterView",
				resourceItemName: "PeriodButtonImage",
				hash: "c46b0cccd75e79147c6999e8714f2f46",
				resourceItemExtension: ".png"
			}
		},
		LookupButtonImage: {
			source: 3,
			params: {
				schemaName: "FixedFilterView",
				resourceItemName: "LookupButtonImage",
				hash: "59d8177ae48bd82c7c73515fc98e8b66",
				resourceItemExtension: ".png"
			}
		},
		RemoveButtonImage: {
			source: 3,
			params: {
				schemaName: "FixedFilterView",
				resourceItemName: "RemoveButtonImage",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		ApplyButtonImage: {
			source: 3,
			params: {
				schemaName: "FixedFilterView",
				resourceItemName: "ApplyButtonImage",
				hash: "18e29d509e192058502f9a936a2dd85f",
				resourceItemExtension: ".png"
			}
		},
		CancelButtonImage: {
			source: 3,
			params: {
				schemaName: "FixedFilterView",
				resourceItemName: "CancelButtonImage",
				hash: "50670ba55c24903c8a285e68eebebdb0",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});