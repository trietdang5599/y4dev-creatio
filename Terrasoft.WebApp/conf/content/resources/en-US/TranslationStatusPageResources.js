define("TranslationStatusPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		QuickFilter_yt46o13_config_caption: "Culture",
		QuickFilter_yt46o13_caption: "Quick filter",
		PageTitle_caption: "Translation validation result",
		Button_Back_caption: "Back",
		TabTitleLabel_caption: "Help",
		HelpTabPanel_caption: "Help",
		Label_Paragraph_1_caption: "This page displays differences between runtime translations and design-time values. Each column provides specific details to help you identify and resolve discrepancies in your translations. Below is an explanation of each column and the steps you can take to fix any issues detected.",
		MenuItem_OpenTranslationSection_caption: "Translations",
		Label_rwqe5bc_caption: "\u2022",
		Label_StaticContentHint_caption: "If the discrepancy is between the expected value and the static content value, use the Compilation action located in the configuration section. This process regenerates the static content so that the translation values on Creatio pages are updated correctly.",
		Label_StaticContentBullet_caption: "\u2022",
		Label_BusinessProcessBullet_caption: "\u2022",
		Label_BusinessProcessHint_caption: "If you see a mismatch between the actual value and the expected value, run the \u0022Apply Translations\u0022 business process. This will update the runtime localization to match the values in the Translations section.",
		Label_ApplyChangesHintTitle_caption: "2. Apply Corrections",
		Label_ErrorsHint_caption: "For each key listed in the validation results, check the associated Error field in the Translations section. Ensure all errors have been corrected before applying any fixes. ",
		Label_ErrorHintTitle_caption: "1. Review and eliminate errors in the Translation section",
		Label_ResolutionsContainerTitle_caption: "How to resolve issues",
		Label_StaticContentValueDescription_caption: "\u2022 Static content value column displays the value found in page resources (static content bundles), such as page button titles. This column is populated only for translations that have a corresponding static resource in Creatio pages.",
		Label_ActualValueDescription_caption: "\u2022 Actual value column reflects the value currently stored in the localizations data. A difference between the expected value and actual value suggests that the latest changes have not been applied.",
		Label_ExpectedValueDescription_caption: "\u2022 The Expected value column shows the translation value as set in the Translations section.",
		Label_CultureColumnDescription_caption: "\u2022 The Culture column indicates the culture in which the issue was detected. ",
		Label_KeyColumnDescription_caption: "\u2022 Key column corresponds to the Key field in the Translations section.",
		ActionButton_caption: "Actions",
		AddButton: "New",
		Button_Data_Import: "Import",
		DefaultHeaderCaption: "Translation validation result",
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
		Caption: "Translation validation result"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});