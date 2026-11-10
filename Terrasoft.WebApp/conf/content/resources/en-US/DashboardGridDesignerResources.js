define("DashboardGridDesignerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WidgetDesignerCaption: "List setup",
		QueryPropertiesLabel: "How to sort",
		NewWidget: "New list",
		DescendingOrder: "Descending",
		AscendingOrder: "Ascending",
		StyleLabel: "Style",
		OrderDirectionLabel: "Sorting order",
		RowsQuantityLabel: "Number of records",
		ColumnToOrderLabel: "Sorting column",
		SetupColumnsButtonLabel: "Select fields to display",
		ColumnSettingsTabCaption: "Column setup",
		ViewSettingsTabCaption: "Display options",
		EmptyGridSettingsMsg: "The list has no displayed fields. Please select fields to display before saving.",
		RowCountInvalidMsg: "Value should be greater than 0",
		PivotTableSettingsTabCaption: "PIVOT TABLE SETTINGS",
		BlankSlateDescription: "To build a report, select fields from the list of dimensions in the pivot table"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		PivotTableBlankSlateIcon: {
			source: 3,
			params: {
				schemaName: "DashboardGridDesigner",
				resourceItemName: "PivotTableBlankSlateIcon",
				hash: "a61259bb743c1036fd8ecb7afb08bcf6",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});