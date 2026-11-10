define("SsoSamlAdfs_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AdfsUrl_Input_label: "AD FS tenant URL",
		AdditionalParameters_ExpansionPanel_title: "Additional parameters",
		BackButton: "Back",
		Button_TestSignIn_caption: "Test Sign in",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		NewRecord: "New record",
		Record: "Record",
		RegisterInIdentity_Label: "Please register a new Trusted Relaying Party in your AD FS tenant (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		SamlEndpoints_ExpansionPanel_title: "Step 2. Define AD FS URLs",
		SaveButton: "Save",
		SetIdentityStepExpansionPanel_title: "Step 1. Perform configuration of your AD FS tenant",
		SetRecordRightsButtonCaption: "Set up access rights",
		SetSamlParams_Label_caption: "Please define the AD FS tenant URL. SAML endpoints will be filled automatically."
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Adfs Settings Form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});