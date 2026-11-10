define("MailboxListResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MenuItem_h7ruh6b_caption: "Migrate selected mailboxes",
		PageTitle_caption: "Mailbox migration tool",
		NewMailServer_ariaLabel: "Target mail server",
		NewMailServer_label: "Target mail server",
		addRecord_qljk0uw_caption: "Add new",
		SetMigrateToMailServerButton_caption: "Set as target server",
		SetMigrateToMailServer_Result: "Mail server was set as migration target",
		QuickFilter_trbci50_config_caption: "Email provider",
		QuickFilter_trbci50_caption: "Quick filter",
		SetMigrateToMailServer_Error: "Could not save the migration target mail server.",
		RunBulkMailboxMigration_MissingTarget: "Set a migration target mail server before running bulk migration.",
		BulkMigrationConfirmationTitle: "Confirm mailbox migration",
		BulkMigrationConfirmationPrompt: "Start mailbox migration to",
		BulkMigrationConfirmButtonCaption: "Migrate",
		BulkMigrationCancelButtonCaption: "Cancel",
		ActionButton_caption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		Button_Data_Import: "\u0418\u043C\u043F\u043E\u0440\u0442",
		DashboardsTabContainer_caption: "\u0410\u043D\u0430\u043B\u0438\u0442\u0438\u043A\u0430",
		DefaultHeaderCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		EmptySectionPlaceholderSubHead: "\u0414\u043E\u0431\u0430\u0432\u044C\u0442\u0435 \u043D\u043E\u0432\u0443\u044E \u0437\u0430\u043F\u0438\u0441\u044C, \u0438 \u0432 \u0440\u0430\u0437\u0434\u0435\u043B\u0435 \u043D\u0435 \u0431\u0443\u0434\u0435\u0442 \u0442\u0430\u043A \u043E\u0434\u0438\u043D\u043E\u043A\u043E",
		EmptySectionPlaceholderTitle: "\u0412 \u0440\u0430\u0437\u0434\u0435\u043B\u0435 \u043D\u0435\u0442 \u043D\u0438 \u043E\u0434\u043D\u043E\u0439 \u0437\u0430\u043F\u0438\u0441\u0438",
		FilteredEmptySectionPlaceholderSubHead: "\u041E\u0447\u0438\u0441\u0442\u0438\u0442\u0435 \u0444\u0438\u043B\u044C\u0442\u0440 \u0438\u043B\u0438 \u0438\u0437\u043C\u0435\u043D\u0438\u0442\u0435 \u0443\u0441\u043B\u043E\u0432\u0438\u044F \u0444\u0438\u043B\u044C\u0442\u0440\u0430\u0446\u0438\u0438",
		FilteredEmptySectionPlaceholderTitle: "\u041F\u0440\u0438 \u0443\u0441\u0442\u0430\u043D\u043E\u0432\u043B\u0435\u043D\u043D\u043E\u043C \u0444\u0438\u043B\u044C\u0442\u0440\u0435 \u0432 \u0440\u0430\u0437\u0434\u0435\u043B\u0435 \u043D\u0435\u0442 \u043D\u0438 \u043E\u0434\u043D\u043E\u0439 \u0437\u0430\u043F\u0438\u0441\u0438",
		ListTabContainer_caption: "\u0421\u043F\u0438\u0441\u043E\u043A",
		ListTitleCaption: "\u041D\u0430\u0437\u0432\u0430\u043D\u0438\u0435 \u0441\u043F\u0438\u0441\u043A\u0430",
		LookupQuickFilterByTag_config_caption: "\u0422\u0435\u0433",
		LookupQuickFilterByTag_config_hint: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u0442\u0435\u0433 \u0434\u043B\u044F \u0444\u0438\u043B\u044C\u0442\u0440\u0430\u0446\u0438\u0438",
		MenuItem_ExportToExcel_caption: "\u042D\u043A\u0441\u043F\u043E\u0440\u0442 \u0432 Excel",
		MenuItem_ImportFromExcel_caption: "Excel",
		OpenLandingDesignerCaption: "Web-\u0444\u043E\u0440\u043C\u044B \u0438 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u044B",
		RefreshButtonCaption: "\u041E\u0431\u043D\u043E\u0432\u0438\u0442\u044C",
		SearchFilter_placeholder: "\u041F\u043E\u0438\u0441\u043A"
	};
	var parametersLocalizableStrings = {
		LookupParameter1: "Dropdown 1"
	};
	var propertiesLocalizableStrings = {
		Caption: "\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430 \u0441 \u0440\u0435\u0435\u0441\u0442\u0440\u043E\u043C"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});