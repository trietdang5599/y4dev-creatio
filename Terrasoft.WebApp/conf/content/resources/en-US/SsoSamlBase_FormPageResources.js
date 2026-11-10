define("SsoSamlBase_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SetSamlParams_Label_caption: "After the application is registered in your SAML provider, please fill in SAML data in Creatio.",
		RegisterInIdentity_Label: "Please register Creatio application on the SAML provider side (admin permissions are required for this operation). Please follow the instructions on Creatio Academy. You can download the metadata file to simplify the configuration.",
		AdditionalParameters_ExpansionPanel_title: "Additional parameters",
		SamlEndpoints_ExpansionPanel_title: "Step 2. Define SAML provider URLs",
		Button_TestSignIn_caption: "Test Sign in",
		SigningAndEncryptionExpansionPanelTitle: "Step 3. Signing and encryption",
		WantAssertionEncryptedCheckboxLabel: "SAML message encryption",
		UploadIdpCertificateButton_caption: "Upload certificate",
		GetMetadataButton_caption: "Get metadata",
		EnableSigningLabel_caption: "Turn on the signing of SAML requests. This will remove vulnerabilities in your setup and make IdP initiated SSO flow available.",
		NotSafeConfigurationWarningLabel_caption: "Your current SSO configuration is NOT safe and cannot be used. IdP initiated SSO flow will be not available.  Please enable SAML requests signing.",
		UploadIdpCertificateLabel_caption: "Upload the public part of certificate, that will be used for SSO signing. Please note, several certificates can be uploaded for the certificate rotation purposes.",
		SetIdentityStepExpansionPanel_title: "Step 1. Perform configuration of your SAML provider",
		WantAssertionSignedCheckbox_label: "Signature validation",
		addRecord_vgetxtd_caption: "",
		UploadMetadataButton_caption: "Upload metadata",
		OrLabel_caption: "OR",
		UploadMetadataLabel_caption: "Upload the metadata file from your SSO provider to automatically define the configuration in Creatio.",
		addRecord_tja3ffy_caption: "Add new",
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
		Caption: "Custom SAML settings form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});