define("Tasks_ListPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PDS_DueDate: "\u041A\u043E\u043D\u0435\u0446",
		QuickFilter_uqq4ljs_config_caption: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u043E\u0442\u043C\u0435\u043D\u0435\u043D\u043D\u044B\u0435 \u0437\u0430\u0434\u0430\u0447\u0438",
		QuickFilter_uqq4ljs_caption: "\u0411\u044B\u0441\u0442\u0440\u044B\u0439 \u0444\u0438\u043B\u044C\u0442\u0440",
		QuickFilter_9qc6vlm_config_caption: "\u0422\u043E\u043B\u044C\u043A\u043E \u043C\u043E\u0438 \u0437\u0430\u0434\u0430\u0447\u0438",
		QuickFilter_9qc6vlm_caption: "\u0411\u044B\u0441\u0442\u0440\u044B\u0439 \u0444\u0438\u043B\u044C\u0442\u0440",
		PDS_Title: "\u041D\u0430\u0437\u0432\u0430\u043D\u0438\u0435",
		PDS_ActivityCategory: "\u041A\u0430\u0442\u0435\u0433\u043E\u0440\u0438\u044F",
		PDS_Owner: "\u041E\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0435\u043D\u043D\u044B\u0439",
		PDS_Account: "\u041A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442",
		PDS_StartDate: "\u041D\u0430\u0447\u0430\u043B\u043E",
		PDS_DurationInMnutesAndHours: "\u0414\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C",
		QuickFilter_ydb8pbh_config_caption: "\u0421\u043E\u0442\u0440\u0443\u0434\u043D\u0438\u043A",
		QuickFilter_ydb8pbh_caption: "\u0411\u044B\u0441\u0442\u0440\u044B\u0439 \u0444\u0438\u043B\u044C\u0442\u0440",
		QuickFilter_ydb8pbh_config_hint: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0441\u043E\u0442\u0440\u0443\u0434\u043D\u0438\u043A\u0430",
		QuickFilter_Date_config_hint: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0434\u0430\u0442\u0443",
		QuickFilter_Date_config_caption: "\u0414\u0430\u0442\u0430",
		QuickFilter_Employee_config_hint: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0441\u043E\u0442\u0440\u0443\u0434\u043D\u0438\u043A\u0430",
		QuickFilter_Employee_config_caption: "\u0421\u043E\u0442\u0440\u0443\u0434\u043D\u0438\u043A",
		QuickFilter_CanceledTasks_config_caption: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u043E\u0442\u043C\u0435\u043D\u0435\u043D\u043D\u044B\u0435 \u0437\u0430\u0434\u0430\u0447\u0438",
		MenuItem_ce34t5o_caption: "\u0418\u043C\u043F\u043E\u0440\u0442 \u0434\u0430\u043D\u043D\u044B\u0445",
		QuickFilter_4lysw92_config_hint: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0442\u0435\u0433 \u0434\u043B\u044F \u0444\u0438\u043B\u044C\u0442\u0440\u0430\u0446\u0438\u0438",
		QuickFilter_4lysw92_config_caption: "\u0422\u0435\u0433",
		QuickFilter_4lysw92_caption: "\u0411\u044B\u0441\u0442\u0440\u044B\u0439 \u0444\u0438\u043B\u044C\u0442\u0440",
		DataTable_RemoveTagsBulkAction_caption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C \u0442\u0435\u0433",
		DataTable_AddTagsBulkAction_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0442\u0435\u0433",
		DashboardsTabContainer_caption: "\u0410\u043D\u0430\u043B\u0438\u0442\u0438\u043A\u0430",
		ListTabContainer_caption: "\u0421\u043F\u0438\u0441\u043E\u043A"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u0441 \u0440\u0435\u0435\u0441\u0442\u0440\u043E\u043C \u0437\u0430\u0434\u0430\u0447"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});