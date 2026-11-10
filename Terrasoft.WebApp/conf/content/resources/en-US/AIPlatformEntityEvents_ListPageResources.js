define("AIPlatformEntityEvents_ListPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PushTriggersButton_caption: "Push triggers",
		PushTriggersFailedMessage: "Failed to push triggers to AI Studio.",
		PushTriggersSuccessMessage: "Synchronization finished.",
		PushTriggersSuccessMessageTemplate: "Synchronization finished. Events added/updated: ${eventTypesUpserted}, removed: ${eventTypesRemoved}.",
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
		Caption: "Creatio.ai platform object events list page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});