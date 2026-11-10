define("CustomIdpSettingsFormResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PartnerIdentityName_label: "Name",
		GetMetadata_Button_caption: "Get metadata",
		RegisterInIdentity_Label_caption: "Please register Creatio application on the SAML provider side (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		AdditionalParameters_ExpansionPanel_title: "Additional parameters",
		SamlEndpoints_ExpansionPanel_title: "Step 2. Define SAML provider URLs",
		SetIdentityStep_ExpansionPanel_title: "Step 1. Perform configuration of your SAML provider",
		SetSamlParams_Label_caption: "After the application is registered in your SAML provider, please fill in SAML data in Creatio.",
		CancelButton: "Cancel",
		CloseButton: "Close",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Custom IDP settings form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});