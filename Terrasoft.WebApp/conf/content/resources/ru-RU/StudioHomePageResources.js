define("StudioHomePageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		crtChartWidget778cabc9ca843bd6520dcb76ede8de60_series_0: "\u041A\u043E\u043D\u0442\u0430\u043A\u0442\u044B",
		crtChartWidget778cabc9ca843bd6520dcb76ede8de60_series_1: "\u041A\u043E\u043D\u0442\u0440\u0430\u0433\u0435\u043D\u0442\u044B",
		crtChartWidget778cabc9ca843bd6520dcb76ede8de60_series_2: "\u0410\u043A\u0442\u0438\u0432\u043D\u043E\u0441\u0442\u0438",
		crtChartWidget778cabc9ca843bd6520dcb76ede8de60_title: "\u0414\u0438\u043D\u0430\u043C\u0438\u043A\u0430 \u0441\u043E\u0437\u0434\u0430\u043D\u0438\u044F \u0437\u0430\u043F\u0438\u0441\u0435\u0439 \u0437\u0430 30 \u0434\u043D\u0435\u0439",
		crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_series_0: "\u0412\u044B\u043F\u043E\u043B\u043D\u044F\u0435\u0442\u0441\u044F",
		crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_series_1: "\u0417\u0430\u0432\u0435\u0440\u0448\u0435\u043D",
		crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_series_2: "\u041E\u0442\u043C\u0435\u043D\u044F\u0435\u0442\u0441\u044F",
		crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_series_3: "\u041E\u0442\u043C\u0435\u043D\u0435\u043D",
		crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_series_4: "\u041E\u0448\u0438\u0431\u043A\u0430",
		crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_title: "\u0414\u0438\u043D\u0430\u043C\u0438\u043A\u0430 \u0437\u0430\u043F\u0443\u0441\u043A\u043E\u0432 \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432 \u0437\u0430 \u0441\u0435\u0433\u043E\u0434\u043D\u044F",
		crtChartWidgeta52c0bfa80e3b15e2ff560b13cdd78e0_xAxis: "\u0427\u0430\u0441",
		crtChartWidgetc4975985fb18bfd8b567c6786ae46694_series_0: "\u0421\u0435\u0433\u043E\u0434\u043D\u044F",
		crtChartWidgetc4975985fb18bfd8b567c6786ae46694_title: "\u0410\u043A\u0442\u0438\u0432\u043D\u044B\u0435 \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u0438 \u0437\u0430 \u0441\u0435\u0433\u043E\u0434\u043D\u044F",
		crtChartWidgetc4975985fb18bfd8b567c6786ae46694_xAxis: "\u0427\u0430\u0441",
		crtIndicatorWidget36551d0719c71252aea435e530446ecf_template: "{0}",
		crtIndicatorWidget36551d0719c71252aea435e530446ecf_title: "\u0417\u0430\u043A\u0430\u043D\u0447\u0438\u0432\u0430\u0435\u0442\u0441\u044F \u043B\u0438\u0446\u0435\u043D\u0437\u0438\u0439",
		crtIndicatorWidget92614f4ce845a46b7185f51c1ca91eee_template: "{0}",
		crtIndicatorWidget92614f4ce845a46b7185f51c1ca91eee_title: "\u041E\u0448\u0438\u0431\u043E\u043A \u043C\u043E\u0434\u0435\u043B\u0435\u0439 \u0418\u0418 \u0437\u0430 \u0441\u0435\u0433\u043E\u0434\u043D\u044F",
		crtIndicatorWidgetb9c29e8222a36992760d99ac65893f94_template: "{0}",
		crtIndicatorWidgetb9c29e8222a36992760d99ac65893f94_title: "\u0417\u0430\u0432\u0435\u0440\u0448\u0435\u043D\u043D\u044B\u0445 \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432 \u0437\u0430 \u0441\u0435\u0433\u043E\u0434\u043D\u044F",
		crtIndicatorWidgetd0b21510a5aebfd9e5f2f7e52b2cb68d_template: "{0}",
		crtIndicatorWidgetd0b21510a5aebfd9e5f2f7e52b2cb68d_title: "\u0417\u0430\u043F\u0443\u0449\u0435\u043D\u043D\u044B\u0445 \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u043E\u0432 \u0437\u0430 \u0441\u0435\u0433\u043E\u0434\u043D\u044F",
		crtIndicatorWidgetdb00dbf565a97c41f8ab24a6cbd21127_template: "{0}",
		crtIndicatorWidgetdb00dbf565a97c41f8ab24a6cbd21127_title: "\u041E\u0448\u0438\u0431\u043E\u043A \u0432 \u043F\u0440\u043E\u0446\u0435\u0441\u0441\u0430\u0445 \u0437\u0430 \u0441\u0435\u0433\u043E\u0434\u043D\u044F",
		crtIndicatorWidgetf02a4503289dce007c289c7a2aaa6ef1_template: "{0}",
		crtIndicatorWidgetf02a4503289dce007c289c7a2aaa6ef1_title: "\u0410\u043A\u0442\u0438\u0432\u043D\u044B\u0445 \u043F\u043E\u043B\u044C\u0437\u043E\u0432\u0430\u0442\u0435\u043B\u0435\u0439, \u0441\u0435\u0439\u0447\u0430\u0441"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u0414\u043E\u043C\u0430\u0448\u043D\u044F\u044F \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0430 Studio"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});