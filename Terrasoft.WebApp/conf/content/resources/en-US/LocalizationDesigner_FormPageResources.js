define("LocalizationDesigner_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DataGrid_ConfigurationElementsLcz_caption: "Element",
		QuickFilter_ConfigurationElementLcz_caption: "Element",
		SearchFilter_ConfigurationElemLcz_placeholder: "Search",
		QuickFilter_ConfigurationElement_caption: "Element",
		QuickFilter_stzwbhw_caption: "Quick filter",
		QuickFilter_yz13uh9_caption: "Quick filter",
		TabContainer_HelpToggleButton_caption: "Help",
		Label_455poas_caption: "Help",
		QuickFilter_4midvgq_caption: "Quick filter",
		addRecord_yiex6dt_caption: "Add new",
		addRecord_iaculf4_caption: "Add new",
		addRecord_g3ckx5b_caption: "Add new",
		TabContainer_LocalizableData_caption: "Localizable data",
		SearchFilter_a9emdwx_placeholder: "Search",
		TabContainer_PropertiesToggleTab_caption: "Properties",
		Label_PropertiesToggleTabTitle_caption: "Element properties",
		Button_RefereshLocalizableDataGrid_caption: "Button",
		Button_RefereshConfigurationElementsGrid_caption: "Refresh data",
		SummaryItem_ggeaykf_label: "Count",
		SummaryItem_nh76qbr_label: "Count",
		Label_HelpUseCasesDescription_caption: "Use this page to find the exact value of a key within a specific package.  The data in this list is read-only. To change a value, edit it in the designer of the related schema (for example, the Freedom UI Designer) or in the Translation section.",
		Label_HelpLocalizableValueSourcesDescription_caption: "Localizable values may be replaced when a parent schema is replaced in the package or when translations are applied from the Translation section.",
		Label_HelpValueColumnDescription_caption: "\u2022 The Value column displays the translation for the currently opened language. ",
		Label_HelpKeyColumnDescription_caption: "\u2022 The Key column contains the unique identifier of the UI caption.",
		Label_HelpConfElementColumnDescription_caption: "\u2022 The Element column shows the name of the configuration element.",
		Label_HelpColumnsListTitle_caption: "In the list:",
		Label_HelpConfElementsTabDescription_caption: "The Configuration elements tab contains a list of all localizable strings from configuration elements, such as object and column captions, business process element titles, button labels, page tab names, and more.",
		Label_HelpPropertiesPanelDescription_caption: "In the Properties panel, you can see the package name, as well as the language and culture code of the current localization.",
		Label_HelpPageDescription_caption: "This page helps you review which localizable content is included in the selected package for a specific language.",
		AttachmentAddButtonCaption: "Upload",
		AttachmentRefreshButtonCaption: "Refresh",
		AttachmentsTabContainerCaption: "Attachments",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		FeedTabContainerCaption: "Feed",
		GeneralInfoTab_caption: "Configuration elements",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights"
	};
	var parametersLocalizableStrings = {
		SchemaLanguage: "Language",
		SchemaPackage: "Package",
		SchemaTitle: "Title",
		SchemaCode: "Code",
		Culture: "Culture code"
	};
	var propertiesLocalizableStrings = {
		Caption: "Localization designer"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});