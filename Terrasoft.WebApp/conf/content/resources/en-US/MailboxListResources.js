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
		ActionButton_caption: "Actions",
		Button_Data_Import: "Import",
		DashboardsTabContainer_caption: "Dashboards",
		DefaultHeaderCaption: "Page title",
		EmptySectionPlaceholderSubHead: "Add a new record to make it look prettier",
		EmptySectionPlaceholderTitle: "The section has no records",
		FilteredEmptySectionPlaceholderSubHead: "Clear the filter or change its conditions",
		FilteredEmptySectionPlaceholderTitle: "There are no records matching the filter criteria",
		ListTabContainer_caption: "List",
		ListTitleCaption: "List title",
		LookupQuickFilterByTag_config_caption: "Tag",
		LookupQuickFilterByTag_config_hint: "Select tag",
		MenuItem_ExportToExcel_caption: "Export to Excel",
		MenuItem_ImportFromExcel_caption: "Excel",
		OpenLandingDesignerCaption: "Web forms and pages",
		RefreshButtonCaption: "Refresh",
		SearchFilter_placeholder: "Search"
	};
	var parametersLocalizableStrings = {
		LookupParameter1: "Dropdown 1"
	};
	var propertiesLocalizableStrings = {
		Caption: "Mailboxes list"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});