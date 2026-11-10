define("SsoSettingsV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ExpansionPanel_OidcMatchingRules_title: "OIDC user matching rules",
		Label_OidcMatchingRulesHint_caption: "Rules are evaluated in the Order shown (ascending). The first rule that matches a user is applied; the remaining rules are skipped.",
		DataGrid_OidcMatchingRulesDS_OidcTokenClaim: "OIDC token claim",
		DataGrid_OidcMatchingRulesDS_SysAdminUnitColumn: "User column",
		DataGrid_OidcMatchingRulesDS_Order: "Order",
		RefreshButtonCaption: "",
		SearchFilter_placeholder: "",
		TabContainer_i2vhfxs_caption: "",
		TabContainer_y2orwdm_caption: "",
		AddButton_caption: "New",
		TabContainer_lmbm2dd_caption: "",
		TabContainer_JIT_caption: "JIT provisioning",
		Label_AdditionalInformation_caption: "Additional information",
		TabContainer_SsoProviders_caption: "SSO Identity provider",
		TabContainer_xyznn6k_caption: "",
		Button_JIT_caption: "Just-In-Time provisioning",
		Button_Azure_caption: "Single Sign On via Microsoft Entra ID (formerly Azure AD)",
		MenuItem_AddNewProvider_caption: "",
		Button_OneLogin_caption: "Single Sign On via OneLogin",
		Button_ADFS_caption: "Single Sign On via AD FS",
		TabContainer_JIT_OPENID_caption: "OPENID provisioning",
		Checkbox_UseJIT_tooltip: "Use Just-in-Time Provisioning for general users",
		Checkbox_UseJIT_label: "Create and update company employees data when log in (Just-In-Time Provisioning)",
		ExpansionPanel_OpenIdAttributes_title: "OpenID provisioning",
		ExpansionPanel_SamlProvisioning_title: "SAML data to contact fields mapping",
		SaveButton_caption: "Save",
		ExpansionPanel_SsoProviders_title: "External identity providers",
		ExpansionPanel_OpenIdProvisioning_title: "OpenID data to contact fields mapping",
		SsoSettingsTemplate_ColumnCaption: "Protocol",
		EntityID_ColumnCaption: "Entity ID",
		BackButton_caption: "Back",
		Checkbox_UseSLO_tooltip: "Use Single-Log-Out when logging out from Creatio",
		Checkbox_UseSLO_label: "Sign out from identity provider when signing out from Creatio",
		Button_y1ig7vh_caption: "Single Sign On via Cognito",
		Checkbox_SspUseJIT_tooltip: "Use Just-in-Time Provisioning for external users",
		Checkbox_SspUseJIT_label: "Create and update external users data when log in (Just-In-Time Provisioning)",
		AtLeastOneHasNotSafeConfigurationWarningLabel_caption: "At least one of your SSO providers has insecure configuration. Unsecure settings cannot be used for logging in. Please enable SAML requests signing to activate the provider.",
		ActionButton_caption: "Actions",
		Button_Data_Import: "Import",
		DefaultHeaderCaption: "Page title",
		EmptySectionPlaceholderSubHead: "Add a new record to make it look prettier",
		EmptySectionPlaceholderTitle: "The section has no records",
		FilteredEmptySectionPlaceholderSubHead: "Clear the filter or change its conditions",
		FilteredEmptySectionPlaceholderTitle: "There are no records matching the filter criteria",
		ListTitleCaption: "List title",
		MenuItem_ExportToExcel_caption: "Export to Excel",
		MenuItem_ImportFromExcel_caption: "Excel",
		OpenLandingDesignerCaption: "Web forms and pages"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "SSO settings page (v. 2)"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});