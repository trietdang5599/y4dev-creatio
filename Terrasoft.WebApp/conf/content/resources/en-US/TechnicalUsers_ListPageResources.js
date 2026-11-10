define("TechnicalUsers_ListPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddButton: "New",
		RefreshButton_caption: "Refresh",
		AcademyLink: "Academy",
		HelpTabContainer_caption: "Help",
		TabTitleLabel_caption: "Help",
		HelpContentLabel3_caption: "\u2022 Technical users can authenticate in Creatio using OAuth authentication only, all other authentication options are unavailable",
		AcademyLinkCaptionLabel_caption: "Learn more about technical users in the ",
		HelpContentLabel2_caption: "\u2022 You cannot log in to Creatio web or mobile application using technical user credentials. Technical users can use only API and not UI",
		HelpContentLabel_caption: "Technical user is a separate Creatio user type whose purposes is to integrate Creatio with external systems. Unlike all other user types, technical user can interact with Creatio without any issued licenses. This lets you integrate Creatio with third party systems without spending licenses. At the same time, technical users have the following restrictions:",
		HelpContentLabel5_caption: "\u2022 Number of technical users you can add is limited by your subscription plan",
		HelpContentLabel4_caption: "\u2022 Out of the box, technical user cannot access any Creatio object or operation and only explicitly issued privileges are applied to the technical user",
		QuickFilter_wxi6or9_caption: "Quick filter",
		QuickFilter_ActiveUsers_config_caption: "Hide inactive",
		Button_Back_caption: "Back",
		ActionButton_caption: "Actions",
		Button_Data_Import: "Import",
		DefaultHeaderCaption: "Technical users",
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
		Caption: "Technical users list page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});