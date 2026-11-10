define("OAuthSettingsMiniPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		WebInput_IdentityUrl_tooltip: "URL address where Identity service is available",
		Input_ClientId_tooltip: "Unique Client ID that enables Creatio to authorize in Identity Service",
		Button_CheckConnection_caption: "Test connection",
		Input_ClientId_label: "Client ID",
		WebInput_IdentityUrl_label: "Identity Service URL",
		Input_ClientSecret_label: "Client secret",
		SaveButton_caption: "Save",
		SettingsDescriptionLabel_caption: "Fill out the Identity Service URL and client credentials. The Identity Service manages access of external applications to Creatio via the OAuth 2.0 protocol. Before saving, you can use the \u0022Test \u0441onnection\u0022 button to verify that your settings are correct. Connection test will not save any changes",
		CancelButton: "Cancel",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Connection settings",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "OAuth 2.0 Connection settings"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});