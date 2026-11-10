define("BaseSectionMainSettingsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CaptionLabel: "Title",
		SectionSchemaCaptionTemplate: "Section schema: \u0022{0}\u0022",
		EditPageCaptionTemplate: "Card schema: \u0022{0}\u0022",
		CodeLabel: "Code",
		WorkplaceLabel: "Workplace",
		IconLabel: "Menu icon",
		AddingRecordThroughMinicardSettingLabel: "Add record through minicard",
		SectionManagerItemNotFoundExceptionMessage: "Section manager item not found",
		TopControlGroupSettingsNewSectionLabel: "Select basic properties for new section:",
		TopControlGroupSettingsExistingSectionLabel: "Select basic properties for section:",
		WrongPrefixMessage: "Code of the section must contain prefix \u0022{0}\u0022",
		EmptyFieldValueMessage: "Specify the value",
		WrongCodeMessage: "Invalid value. Use symbols: a-z, A-Z, 0-9. \nSymbol: 0-9 cannot be first.",
		NewSectionCodeMessage: "The following prefix will automatically be added to the name {0}",
		GlobalSearchAvailableLabel: "Indexing for full-text search",
		SectionSettingsLabel: "Section settings",
		IsSystem: "System section",
		SelectExistingObjectButtonCaption: "Select existing object",
		SelectExistObjectLookupPageCaption: "Select: Object",
		PrimaryDisplayColumnRequiredMessage: "Property \u0022Displayed value\u0022 is not set in the selected object. You cannot select values from this object without this property. Set this property in \u0022Advanced settings\u0022 section and try again",
		CurrentPackageSettingsErrorMessage: "Package \u0022{0}\u0022 is set as the current package. This package does not have access to the selected object. Please complete its dependencies or change the system setting \u0022Current package\u0022 and open Section wizard once again",
		EntitySectionExistsMessage: "Section for this object already exists",
		EntityIsViewMessage: "Selected object is a database view. You can create section for objects that are not views",
		TryAgainMessageButtonCaption: "Select other object",
		EntityUsingInExistSectionMessage: "This object is already being used in existing section",
		SchemaCodeIsTooLongMessage: "Selected object code is too long ({0} characters). Limit is {1}.",
		ForeignPublisherMessage: "Groups and tags won\u0027t be available in this section. Selected object is created by third-party publisher.",
		BackgroundIconColorLabel: "Background icon color"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "BaseSectionMainSettings",
				resourceItemName: "DefaultIcon",
				hash: "4c421e204b17018308c36c5d9105b121",
				resourceItemExtension: ".svg"
			}
		},
		SectionIcon: {
			source: 3,
			params: {
				schemaName: "BaseSectionMainSettings",
				resourceItemName: "SectionIcon",
				hash: "640e80bd309c99f2b2328b669dd276d5",
				resourceItemExtension: ".svg"
			}
		},
		SelectExistObjectIcon: {
			source: 3,
			params: {
				schemaName: "BaseSectionMainSettings",
				resourceItemName: "SelectExistObjectIcon",
				hash: "a5786ede76a7abb5cf1286930d197d29",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});