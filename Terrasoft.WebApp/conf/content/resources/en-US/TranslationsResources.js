define("TranslationsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CouldNotGetAdAccountError_Description: "Sorry, unable to connect your ad account.  ",
		AccessTokenDoesNotHaveRequiredScopes_Description: "Sorry, unable to connect your ad account. Please grant requested permissions to Creatio and try again.",
		SysSetting_SocialPlatformServiceInvalidValue_Description: "Sorry, unable to connect your ad account.  Please complete \u201CSocialPlatformServiceUrl\u201C, \u201CSocialAccountServiceUrl\u201C system settings and try again. ",
		SysSetting_OAuthInvalidValue_Description: " Sorry, unable to connect your ad account. Please complete \u201CAuthorization server Url for OAuth 2.0 integrations\u201C,  \u201CClient id for OAuth 2.0 integrations\u201C, \u201CClient secret for OAuth 2.0 integrations\u201C system settings and try again.",
		SysSetting_IdentityServerInvalidValue_Description: "Sorry, unable to connect your ad account.  Please complete  \u201CIdentity server Url\u201C, \u201CIdentity server client id\u201C, \u201CIdentity server client secret\u201C system settings and try again.",
		PlatformServicesUnavailable_Description: "Sorry, unable to connect your ad account. Service connection error.",
		CouldNotGetAccountError_Description: "Sorry, unable to connect your account.  "
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});