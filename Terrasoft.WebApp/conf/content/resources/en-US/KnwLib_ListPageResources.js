define("KnwLib_ListPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PageTitle_caption: "Knowledge library",
		AddButton_caption: "New",
		ActionButton_caption: "Actions",
		AddButton: "New",
		Button_Data_Import: "Import",
		DefaultHeaderCaption: "Page title",
		EmptySectionPlaceholderSubHead: "Add a new record to make it look prettier",
		EmptySectionPlaceholderTitle: "The section has no records",
		FilteredEmptySectionPlaceholderSubHead: "Clear the filter or change its conditions",
		FilteredEmptySectionPlaceholderTitle: "There are no records matching the filter criteria",
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
		Caption: "Knowledge library list page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});