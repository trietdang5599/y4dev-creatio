define("Chats_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ChatInfoLabel_caption: "\u0418\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F \u043F\u043E \u0447\u0430\u0442\u0443",
		Provider_ariaLabel: "\u0412\u044B\u043F\u0430\u0434\u0430\u044E\u0449\u0438\u0439 \u0441\u043F\u0438\u0441\u043E\u043A",
		ChatStartDate_label: "\u0414\u0430\u0442\u0430 \u043D\u0430\u0447\u0430\u043B\u0430",
		ChatEndDate_label: "\u0414\u0430\u0442\u0430 \u0437\u0430\u0432\u0435\u0440\u0448\u0435\u043D\u0438\u044F",
		ChatMetricsLabel_caption: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u0435\u043B\u0438 \u0447\u0430\u0442\u0430",
		ChatDurationIndicatorWidget_template: "{0}",
		ChatDurationIndicatorWidget_title: "\u0414\u043B\u0438\u0442\u0435\u043B\u044C\u043D\u043E\u0441\u0442\u044C \u0447\u0430\u0442\u0430, \u043C\u0438\u043D.",
		RelatedChatsAddTagsBulkAction_caption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0442\u0435\u0433",
		RelatedChatsSearchFilter_placeholder: "\u041F\u043E\u0438\u0441\u043A",
		RelatedChatsSettingsButton_caption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		RelatedChatsRefreshButton_caption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		RelatedChatsExpansionPanel_title: "\u0421\u0432\u044F\u0437\u0430\u043D\u043D\u044B\u0435 \u0447\u0430\u0442\u044B",
		RelatedInfoTab_caption: "\u0421\u0432\u044F\u0437\u0430\u043D\u043D\u0430\u044F \u0438\u043D\u0444\u043E\u0440\u043C\u0430\u0446\u0438\u044F",
		ChatFirstResponseTimeIndicatorWidget_template: "{0}",
		ChatFirstResponseTimeIndicatorWidget_title: "\u0412\u0440\u0435\u043C\u044F \u043F\u0435\u0440\u0432\u043E\u0433\u043E \u043E\u0442\u0432\u0435\u0442\u0430, \u0441\u0435\u043A.",
		RelatedChatsExportDataButton_caption: "\u042D\u043A\u0441\u043F\u043E\u0440\u0442 \u0432 Excel",
		RelatedChatsDeleteBulkAction_caption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		RelatedChatsExportToExcelBulkAction_caption: "\u042D\u043A\u0441\u043F\u043E\u0440\u0442 \u0432 Excel",
		RelatedChatsRemoveTagsBulkAction_caption: "\u0423\u0431\u0440\u0430\u0442\u044C \u0442\u0435\u0433",
		AttachmentRefreshButton_caption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		AttachmentAddButton_caption: "\u0417\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C",
		RelatedChatsListDS_Status: "\u0421\u0442\u0430\u0442\u0443\u0441",
		RelatedChatsListDS_CreatedOn: "\u0414\u0430\u0442\u0430 \u043D\u0430\u0447\u0430\u043B\u0430",
		AttachmentAddButtonCaption: "\u0417\u0430\u0433\u0440\u0443\u0437\u0438\u0442\u044C",
		AttachmentRefreshButtonCaption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		AttachmentsTabContainerCaption: "\u0424\u0430\u0439\u043B\u044B",
		BackButton: "\u041D\u0430\u0437\u0430\u0434",
		CancelButton: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CloseButton: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		DefaultHeaderCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		FeedTabContainerCaption: "\u041B\u0435\u043D\u0442\u0430",
		GeneralInfoTab_caption: "\u0420\u0430\u0437\u0433\u043E\u0432\u043E\u0440",
		NewRecord: "\u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		Record: "\u0417\u0430\u043F\u0438\u0441\u044C",
		SaveButton: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		SetRecordRightsButtonCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u043F\u0440\u0430\u0432"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u0437\u0430\u043F\u0438\u0441\u0438 Chats"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});