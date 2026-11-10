define("SsoOpenIdCognito_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ExpansionPanel_y8yurgj_title: "Step 2. Define Cognito provider params",
		Label_zw8c4k1_caption: "Please register Creatio application on the Cognito provider side (admin permissions are required for this operation). Please follow the instructions on Creatio Academy.",
		ExpansionPanel_u1xsykp_title: "Step 1. Perform configuration of your Cognito",
		Label_ypit4eo_caption: "Url example: https://[CognitoDomainPrefix].auth.[Region].amazoncognito.com",
		Label_tpyihd5_caption: "Url example: https://cognito-idp.[Region].amazonaws.com/[UserPoolId]/.well-known/openid-configuration",
		ExpansionPanel_fqp99hq_title: "Finalize setup",
		Input_rdplwi2_tooltip: "https://[CognitoDomainPrefix].auth.[region].amazoncognito.com",
		Input_74rw7jr_tooltip: "https://[CognitoDomainPrefix].auth.[region].amazoncognito.com",
		AdditionalParameters_ExpansionPanel_title: "Finalize setup",
		Label_nyblyw8_caption: "Please fill in the settings for Cognito. To fill in, you will also need to know [CognitoDomainPrefix] and [Region] which can be found in the Cognito admin panel.",
		Label_5av05mu_caption: "Url example: https://[CognitoDomainPrefix].auth.[Region].amazoncognito.com/logout?client_id={client_id}\u0026logout_uri={redirect_uri}\u0026state={state}",
		Label_af69la3_caption: "Please fill in the settings for Cognito. To fill in, you will also need to know [CognitoDomainPrefix] and [Region] which can be found in the Cognito admin panel. Put these values in the appropriate places in the fields below.",
		SetIOpenIDStep_ExpansionPanel_title: "Step 1. Perform configuration of your Cognito",
		OpenIDEndpoints_ExpansionPanel_title: "Step 2. Define Cognito provider params",
		Input_74rw7jr_placeholder: "Url example: https://[CognitoDomainPrefix].auth.[Region].amazoncognito.com",
		Input_45yctgp_placeholder: "Url example: https://cognito-idp.[Region].amazonaws.com/[UserPoolId]/.well-known/openid-configuration",
		Input_vs58l4j_placeholder: "Url example: https://[CognitoDomainPrefix].auth.[Region].amazoncognito.com/logout?client_id={client_id}\u0026logout_uri={redirect_uri}\u0026state={state}",
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
		Caption: "Cognito AWS Settings Form"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});