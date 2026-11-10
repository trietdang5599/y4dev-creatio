define("Calls_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		addRecord_w9zt9y2_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		IndicatorWidget_w0uc9bm_template: "{0}",
		IndicatorWidget_w0uc9bm_title: "\u0412\u0440\u0435\u043C\u044F \u0443\u0434\u0435\u0440\u0436\u0430\u043D\u0438\u044F",
		IndicatorWidget_ekdzv0l_template: "{0}",
		IndicatorWidget_ekdzv0l_title: "\u0412\u0440\u0435\u043C\u044F \u0440\u0430\u0437\u0433\u043E\u0432\u043E\u0440\u0430",
		IndicatorWidget_ykhdy22_template: "{0}",
		IndicatorWidget_ykhdy22_title: "\u0412\u0440\u0435\u043C\u044F \u0434\u043E \u0441\u043E\u0435\u0434\u0438\u043D\u0435\u043D\u0438\u044F",
		IndicatorWidget_CallDuration_template: "{0}",
		IndicatorWidget_CallDuration_title: "\u0414\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C \u0437\u0432\u043E\u043D\u043A\u0430, \u0441\u0435\u043A",
		IndicatorWidget_hhwckzn_template: "{0}",
		IndicatorWidget_hhwckzn_title: "\u0414\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C \u0437\u0432\u043E\u043D\u043A\u0430",
		addRecord_cikv0o5_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		addRecord_kjzadvb_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		addRecord_3k6vvb2_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		addRecord_emlp0js_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		addRecord_1zlegwy_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		Label_jtpe1xk_caption: "\u0421\u0432\u044F\u0437\u0438",
		TabContainer_gys6o7j_caption: "\u0421\u0432\u044F\u0437\u0438",
		IndicatorWidget_CallOnHoldTime_template: "{0}",
		IndicatorWidget_CallOnHoldTime_title: "\u0414\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C \u043D\u0430 \u0443\u0434\u0435\u0440\u0436\u0430\u043D\u0438\u0438, \u0441\u0435\u043A",
		IndicatorWidget_CallConversationTime_template: "{0}",
		IndicatorWidget_CallConversationTime_title: "\u0414\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C \u0440\u0430\u0437\u0433\u043E\u0432\u043E\u0440\u0430, \u0441\u0435\u043A",
		IndicatorWidget_CallTimeToConnect_template: "{0}",
		IndicatorWidget_CallTimeToConnect_title: "\u041E\u0436\u0438\u0434\u0430\u043D\u0438\u044F \u0441\u043E\u0435\u0434\u0438\u043D\u0435\u043D\u0438\u044F, \u0441\u0435\u043A",
		Label_CallInfo_caption: "\u0418\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F \u043E \u0437\u0432\u043E\u043D\u043A\u0435",
		Label_bec6oo6_caption: "\u0418\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F \u043E \u0437\u0432\u043E\u043D\u043A\u0435",
		AttachmentAddButtonCaption: "\u0417\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C",
		AttachmentRefreshButtonCaption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		AttachmentsTabContainerCaption: "\u0424\u0430\u0439\u043B\u044B",
		BackButton: "\u041D\u0430\u0437\u0430\u0434",
		CancelButton: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CloseButton: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		DefaultHeaderCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		FeedTabContainerCaption: "\u041B\u0435\u043D\u0442\u0430",
		GeneralInfoTab_caption: "\u041E\u0441\u043D\u043E\u0432\u043D\u0430\u044F \u0438\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F",
		NewRecord: "\u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		Record: "\u0417\u0430\u043F\u0438\u0441\u044C",
		SaveButton: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		SetRecordRightsButtonCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043F\u0440\u0430\u0432"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u0437\u0430\u043F\u0438\u0441\u0438 Calls"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});