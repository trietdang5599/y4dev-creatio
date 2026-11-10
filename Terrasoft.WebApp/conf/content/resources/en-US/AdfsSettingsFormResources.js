define("AdfsSettingsFormResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AdfsSetIdentityStep_ExpansionPanel_title: "Step 1. Perform configuration of your AD FS tenant",
		AdfsSamlEndpoints_ExpansionPanel_title: "Step 2. Define AD FS URLs",
		AdfsRegisterInIdentity_Label_caption: "Please register a new Trusted Relaying Party in your AD FS tenant (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		AdfsUrl_Input_label: "AD FS tenant URL",
		AdfsSetSamlParams_Label_caption: "Please define the AD FS tenant URL. SAML endpoints will be filled automatically.",
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
		Caption: "Adfs Settings Form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});