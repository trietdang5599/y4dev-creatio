define("Chats_ListPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PDS_Status: "Status",
		RefreshButton_caption: "Refresh",
		ChatsInProgressIndicatorWidget_template: "{0}",
		ChatsInProgressIndicatorWidget_title: "Chats in progress",
		WaitingForProcessingIndicatorWidget_template: "{0}",
		WaitingForProcessingIndicatorWidget_title: "Waiting for processing",
		AverageChatDurationIndicatorWidget_template: "{0}",
		AverageChatDurationIndicatorWidget_title: "Average chat duration, min.",
		AverageFirstResponseTimeIndicatorWidget_template: "{0}",
		AverageFirstResponseTimeIndicatorWidget_title: "Average first response time, sec.",
		DataTableExportToExcelBulkAction_caption: "Export to Excel",
		DataTableDeleteBulkAction_caption: "Delete",
		DataTableRemoveTagsBulkAction_caption: "Remove tag",
		DataTableAddTagsBulkAction_caption: "Add tag",
		StatusFilter_config_caption: "Status",
		AgentFilter_config_caption: "Agent",
		DateFilter_caption: "Select period",
		DateFilter_config_caption: "Select period",
		RowToolbar_OpenItem_caption: "Open",
		RowToolbar_DeleteItem_caption: "Delete",
		PDS_CreatedOn: "Start date",
		ActionButton_caption: "Actions",
		AddButton: "New",
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
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Chats list page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});