define("SsoOpenId_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Label_zw8c4k1_caption: "Please register Creatio application on the OpenID provider side (admin permissions are required for this operation). Please follow the instructions on Creatio Academy.",
		ExpansionPanel_u1xsykp_title: "Step 1. Perform configuration of your OpenID provider",
		AdditionalParameters_ExpansionPanel_title: "Additional settings",
		ExpansionPanel_y8yurgj_title: "Step 2. Define OpenID provider params",
		Input_21ng1v6_tooltip: "\u041C\u043E\u0436\u0435 \u0431\u0443\u0442\u0438 \u043F\u0443\u0441\u0442\u0438\u043C",
		ExpansionPanel_Finalize_title: "Finalize setup",
		ExpansionPanel_f0m6eop_title: "Finalize setup",
		SetIOpenIDStep_ExpansionPanel_title: "Step 1. Perform configuration of your OpenID provider",
		OpenIDEndpoints_ExpansionPanel_title: "Step 2. Define OpenID provider params",
		DiscoveryUrlPlaceholder: "[YourOpenIDProdviderUrl]\u002B/.well-known/openid-configuration",
		SessionUrlPlaceholder: "",
		EndSessionSessionUrlPlaceholder: "[YourOpenIDProdviderUr] \u002B /logout",
		UrlPlaceholder: "Just domains without path or subdirectory",
		addRecord_v6t58ad_caption: "Add new",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "OpenID Settings Form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});