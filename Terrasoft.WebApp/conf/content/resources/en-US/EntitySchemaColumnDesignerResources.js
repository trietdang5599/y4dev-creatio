define("EntitySchemaColumnDesignerResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DataValueTypeLabel: "Data type",
		CaptionLabel: "Title",
		NameLabel: "Name in DB",
		DescriptionLabel: "Description",
		referenceSchemaUIdLabel: "Lookup",
		isVirtualLabel: "Read-only",
		isValueCloneableLabel: "Make copy",
		isMultilineTextLabel: "Multiline text",
		DropDownTypeLabel: "List",
		isCascadeLabel: "Cascade connection",
		UseExistingLookupCaption: "Select existing lookup",
		CreateNewLookupCaption: "Add new lookup",
		NewSchemaCaptionFieldCaption: "Title",
		NewSchemaNameFieldCaption: "Name",
		DuplicateColumnNameMessage: "Column with this name already exists",
		WrongPrefixMessage: "Name must contain prefix \u0022{0}\u0022",
		WrongColumnNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9.  Symbol: 0-9 cannot be first.",
		DuplicateSchemaNameMessage: "Schema with this name already exists",
		WrongSchemaNameMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9.  Symbol: 0-9 cannot be first.",
		WrongSchemaNameLengthMessage: "Code cannot be longer than {0} characters",
		NewColumnCaption: "New column",
		ColumnCaption: "Title",
		LookupCaption: "Lookup",
		LookupTypeCaption: "Lookup view:",
		LookupTypeLabel: "Pop-up window",
		IsValueCloneableHint: "Select the checkbox if you need to copy the values in the columns to the new record when copying",
		LookupSchemaDoesNotHavePrimaryDisplayColumnMsg: "Property \u0022Displayed value\u0022 is not set in the selected lookup. You cannot select values from this lookup without this property. Set this property in \u0022Advanced settings\u0022 section and try again.",
		isRequiredLabel: "Required",
		CancelButtonCaption: "Cancel",
		DesignerCaption: "Column",
		SaveButtonCaption: "Save"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});