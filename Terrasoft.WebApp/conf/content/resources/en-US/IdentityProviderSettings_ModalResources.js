define("IdentityProviderSettings_ModalResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Button_CheckConnection_caption: "Test connection",
		WebInput_IdentityUrl_tooltip: "The identity provider\u0027s base address that Creatio calls to request access tokens",
		EncryptedInput_rot2itz_tooltip: "The confidential key paired with the Client ID. Creatio sends it with the Client ID to authenticate token requests. Keep it secure",
		Input_d172vy2_tooltip: "The public identifier issued by the identity provider when you registered Creatio as a client application",
		Input_xhlz464_tooltip: "Optional notes about this connection \u2014 for example, its purpose or which environment it applies to",
		Input_xhlz464_label: "Description",
		Input_ltkesvw_tooltip: "A unique name for this connection, used to identify the provider throughout Creatio",
		EditPageTitle_caption: "Edit identity provider",
		PageTitle_caption: "New record",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Identity provider settings modal"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});