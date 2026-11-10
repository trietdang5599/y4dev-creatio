define("SocialAccountAuthUtilitiesResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SetIsPublisSocialAccount: "Grant other users permission to browse social network data using this account?",
		SocialNetworkAuthError: "Error occurred while trying to authorize with the social network. Please try again.",
		QueryAdministartor: "Contact your system administrator. The application should be integrated with ",
		QueryAdministrator: "Contact your system administrator. The application should be integrated with ",
		ToAcademyBtn: "Go to Academy",
		ProceedBtn: "Proceed",
		NewReturnUrlNotify: "In new Creatio version changed Google request handler url. You need to change settings in GSuite account for Creatio application. Read more in Academy."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});