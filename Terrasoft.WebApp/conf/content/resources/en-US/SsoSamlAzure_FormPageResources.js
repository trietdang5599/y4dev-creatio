define("SsoSamlAzure_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PartnerIdentityName_label: "Microsoft Entra identifier",
		AdditionalParameters_ExpansionPanel_title: "Additional parameters",
		BackButton: "Back",
		Button_TestSignIn_caption: "Test Sign in",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		NewRecord: "New record",
		Record: "Record",
		RegisterInIdentity_Label: "Please register Creatio application in Microsoft Entra ID portal (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		SamlEndpoints_ExpansionPanel_title: "Step 2. Define Microsoft Entra ID (formerly Azure AD) URLs",
		SaveButton: "Save",
		SetIdentityStepExpansionPanel_title: "Step 1. Perform configuration in Microsoft Entra ID (formerly Azure AD)",
		SetRecordRightsButtonCaption: "Set up access rights",
		SetSamlParams_Label_caption: "After the application is registered in Microsoft Entra ID (formerly Azure) portal, please fill in Azure data in Creatio."
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Azure settings form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});