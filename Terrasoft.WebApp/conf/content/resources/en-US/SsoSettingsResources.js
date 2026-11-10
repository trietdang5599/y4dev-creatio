define("SsoSettingsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddButton_caption: "New Provider",
		JitArticleButton_caption: "Just-In-Time user provisioning",
		OneLoginSsoArticleButton_caption: "Single Sign On via OneLogin",
		AdfsSsoArticleButton_caption: "Single Sign On via AD FS",
		AzureSsoArticleButton_caption: "Single Sign On via Microsoft Entra ID (formerly Azure AD)",
		CloseButton_caption: "Close",
		SaveButton_caption: "Save",
		Checkbox_3o79wm4_ariaLabel: "",
		Checkbox_3o79wm4_label: "",
		Checkbox_UseJit_label: "Create and update users data when log in (Just-In-Time Provisioning)",
		TestSsoButton_caption: "TEST \u25B7",
		AdditionalInfoLabel_caption: "\u24D8 Additional Information",
		DataGrid_RowToolbar_Open: "Open",
		EmptySectionPlaceholderSubHead: "Add a new record to make it look prettier",
		EmptySectionPlaceholderTitle: "The section has no records",
		FilteredEmptySectionPlaceholderSubHead: "Clear the filter or change its conditions",
		FilteredEmptySectionPlaceholderTitle: "There are no records matching the filter criteria"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "SSO settings page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});