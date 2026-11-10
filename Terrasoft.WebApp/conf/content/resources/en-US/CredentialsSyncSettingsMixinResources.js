define("CredentialsSyncSettingsMixinResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ForbiddenError: "Mail provider rejected authorization. Contact your system administrator.",
		GeneralError: "Unable to add an account. Contact your system administrator.",
		AlreadyExistsError: "This mailbox already exists.",
		MailServerTemplateError: "Unable to add an account. Please contact your system administrator. {0}"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});