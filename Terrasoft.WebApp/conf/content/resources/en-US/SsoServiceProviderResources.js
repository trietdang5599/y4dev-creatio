define("SsoServiceProviderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SsoServiceProviderCaption: "SSO service provider",
		IdCaption: "Id",
		CreatedOnCaption: "Created on",
		CreatedByCaption: "Created by",
		ModifiedOnCaption: "Modified on",
		ModifiedByCaption: "Modified by",
		ProcessListenersCaption: "Active processes",
		UseJitCaption: "Create and update users data when log in (Just-In-Time Provisioning)",
		SamlUserRoleCaption: "Saml user role",
		SamlUserNameCaption: "Saml user name",
		LocalCertificateThumbprintCaption: "Local certificate thumbprint",
		AssertionConsumerServiceUrlCaption: "Assertion consumer service Url",
		NameCaption: "Name",
		SsoIdentityProviderCaption: "SSO identity provider",
		SspUseJitCaption: "Use Just-in-Time Provisioning for portal users",
		ServiceUniqueColumnCaption: "ServiceUniqueColumn",
		SingleLogoutServiceUrlCaption: "Single logout service Url",
		UseSloCaption: "Use SLO"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages};
});