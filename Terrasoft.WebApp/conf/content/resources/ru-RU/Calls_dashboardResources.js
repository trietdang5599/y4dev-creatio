define("Calls_dashboardResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ChartWidget_CallsPerContact_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		ChartWidget_CallsResult_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		ChartWidget_CallsVolumeTrend_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		ChartWidget_CallsVolumeTrend_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		ChartWidget_CallsPerAccount_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		ChartWidget_CallsPerAccount_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		ChartWidget_13pwpzz_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		ChartWidget_CallsPerAgent_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		ChartWidget_CallsPerAgent_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		ChartWidget_4gu3c4s_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		ChartWidget_4gu3c4s_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsPerAgentChart_label: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsPerAgentChart_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsPerAgentChart_title: "\u041A\u043E\u043B\u0438\u0447\u0435\u0441\u0442\u0432\u043E \u0437\u0432\u043E\u043D\u043A\u043E\u0432 \u043F\u043E \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u044E",
		CallsPerAccountChart_label: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsPerAccountChart_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsPerAccountChart_title: "\u041A\u043E\u043B\u0438\u0447\u0435\u0441\u0442\u0432\u043E \u0437\u0432\u043E\u043D\u043A\u043E\u0432 \u043F\u043E \u043A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442\u0443",
		CallsPerContactChart_label: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsPerContactChart_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsPerContactChart_title: "\u041A\u043E\u043B\u0438\u0447\u0435\u0441\u0442\u0432\u043E \u0437\u0432\u043E\u043D\u043A\u043E\u0432 \u043F\u043E \u043A\u043E\u043D\u0442\u0430\u043A\u0442\u0443",
		CallsVolumeTrendChart_label: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsVolumeTrendChart_name: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsVolumeTrendChart_title: "\u0422\u0440\u0435\u043D\u0434 \u0440\u0430\u0441\u043F\u0440\u0435\u0434\u0435\u043B\u0435\u043D\u0438\u044F \u0437\u0432\u043E\u043D\u043A\u043E\u0432",
		CallsResultChart_label: "\u0417\u0432\u043E\u043D\u043E\u043A",
		CallsResultChart_title: "\u0420\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442 \u0437\u0432\u043E\u043D\u043A\u043E\u0432",
		CallOnHoldTimeWidget_template: "{0}",
		CallOnHoldTimeWidget_title: "\u041E\u0431\u0449\u0435\u0435 \u0432\u0440\u0435\u043C\u044F \u043D\u0430 \u0443\u0434\u0435\u0440\u0436\u0430\u043D\u0438\u0438, \u0441\u0435\u043A",
		CallConversationTimeWidget_template: "{0}",
		CallConversationTimeWidget_title: "\u041E\u0431\u0449\u0435\u0435 \u0432\u0440\u0435\u043C\u044F \u0440\u0430\u0437\u0433\u043E\u0432\u043E\u0440\u0430, \u0441\u0435\u043A",
		AverageCallDurationWidget_template: "{0}",
		AverageCallDurationWidget_title: "\u0421\u0440\u0435\u0434\u043D\u044F\u044F \u0434\u043B\u0438\u043D\u0430 \u0437\u0432\u043E\u043D\u043A\u0430, \u0441\u0435\u043A",
		CallDurationWidget_template: "{0}",
		CallDurationWidget_title: "\u041E\u0431\u0449\u0430\u044F \u0434\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C \u0437\u0432\u043E\u043D\u043A\u043E\u0432, \u0441\u0435\u043A",
		CallsVolumeTrendChart_yAxis: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsVolumeTrendChart_xAxis: "\u0417\u0432\u043E\u043D\u043A\u0438",
		CallsVolumeTrendChart_series_0: "\u0417\u0432\u043E\u043D\u043A\u0438"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u0410\u043D\u0430\u043B\u0438\u0442\u0438\u043A\u0430 \u0437\u0432\u043E\u043D\u043A\u043E\u0432"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});