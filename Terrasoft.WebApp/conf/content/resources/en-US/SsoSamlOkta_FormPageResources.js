define("SsoSamlOkta_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PartnerIdentityName_label: "IdP Issuer",
		AdditionalParameters_ExpansionPanel_title: "Additional parameters",
		BackButton: "Back",
		Button_TestSignIn_caption: "Test Sign in",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		NewRecord: "New record",
		Record: "Record",
		RegisterInIdentity_Label: "Please register Creatio application in Okta portal (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		SamlEndpoints_ExpansionPanel_title: "Step 2. Define Okta URLs",
		SaveButton: "Save",
		SetIdentityStepExpansionPanel_title: "Step 1. Perform configuration in Okta",
		SetRecordRightsButtonCaption: "Set up access rights",
		SetSamlParams_Label_caption: "After the application is registered in Okta portal, please fill in Okta data in Creatio."
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Okta settings form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});