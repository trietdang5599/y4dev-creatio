define("EntityColumnPropertiesPageModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		NumberDataTypeCaption: "Precision",
		TextDateTypeCaption: "Text length",
		DateTypeCaption: "Format",
		SelectValueCaption: "Please select value from the list",
		LookupSchemaDoesNotHavePrimaryDisplayColumnMsg: "Property \u0022Displayed value\u0022 is not set in the selected lookup. You cannot select values from this lookup without this property. Set this property in \u0022Advanced settings\u0022 section and try again.",
		EditCaption: "Edit",
		EditLookupCaption: "Lookup",
		NewLookupCaption: "New lookup",
		DeleteRecordsCaption: "Delete records from {0} with this value",
		BlockDeletionCaption: "Block deletion if there are connected records in {0} with those value",
		LookupValueDeletionCaption: "On lookup value deletion:",
		LookupCaption: "Lookup",
		ListCaption: "List",
		SelectionWindowCaption: "Selection window",
		LookupViewCaption: "Lookup view",
		DataSourceCaption: "Data source",
		UndoButtonCaption: "Undo",
		ChangeTypeMessage: "If the \u0022{0}\u0022 column contains data, changing the column type may cause the loss of that data if conversion to the new data format cannot be made. Please consider backing up your data before changing the column type.",
		EditabilityCaption: "Editability",
		DuplicateColumnNameMessage: "Column with this name already exists",
		WrongPrefixMessage: "Name must contain prefix \u0022{0}\u0022",
		isMultilineTextLabel: "Multiline text",
		MakeCopy: "Copy this value when copying records",
		HideTitle: "Hide title on page",
		ReadOnly: "Read-only",
		IsRequiredOnPageLabel: "Required on page",
		IsRequired: "Required",
		LabelCaption: "Title on page",
		DesignerCaption: "Column",
		NewColumnCaption: "New column",
		CreateLookupTooltipCaption: "Add new lookup",
		EditLookupTooltipCaption: "Edit lookup"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});