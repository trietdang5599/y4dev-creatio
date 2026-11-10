define("AzureSettingsFormResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AzureSamlEndpoints_ExpansionPanel_title: "Step 2. Define Microsoft Entra ID (formerly Azure AD) URLs",
		AzureSetIdentityStep_ExpansionPanel_title: "Step 1. Perform configuration in Microsoft Entra ID (formerly Azure AD)",
		AzureSetSamlParams_Label_caption: "After the application is registered in Microsoft Entra ID (formerly Azure) portal, please fill in data in Creatio.",
		AzurePartnerIdentityName_Input_caption: "Microsoft Entra identifier",
		AzureRegisterInIdentity_Label_caption: "Please register Creatio application in Microsoft Entra ID portal (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		AdditionalParameters_ExpansionPanel_title: "Additional parameters",
		CancelButton: "Cancel",
		CloseButton: "Close",
		GetMetadata_Button_caption: "Get metadata",
		NewRecord: "New record",
		PartnerIdentityName_label: "Name",
		Record: "Record",
		RegisterInIdentity_Label_caption: "Please register Creatio application on the SAML provider side (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		SamlEndpoints_ExpansionPanel_title: "Step 2. Define SAML provider URLs",
		SaveButton: "Save",
		SetIdentityStep_ExpansionPanel_title: "Step 1. Perform configuration of your SAML provider",
		SetSamlParams_Label_caption: "After the application is registered in your SAML provider, please fill in SAML data in Creatio."
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Azure settings form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});