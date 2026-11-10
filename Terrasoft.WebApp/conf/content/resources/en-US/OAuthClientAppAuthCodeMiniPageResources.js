define("OAuthClientAppAuthCodeMiniPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButton_caption: "Save",
		PageTitleError_caption: "Identity Service update required",
		Label_MainDescription_caption: "Your version of Identity Service does not support this type of OAuth authorization. To update Identity Service to the latest version:",
		Label_CloudCaseHint_caption: "\u2022 If you use Creatio in the cloud, contact Creatio support",
		Label_OnSiteCaseHintSecondLine_caption: "in the ",
		Label_OnSiteCaseHintFirstLine_caption: "\u2022 If you use Creatio on-site, follow the instructions",
		AcademyLink: "Academy",
		CancelButton_caption: "Cancel",
		Button_fmycwhi: "Cancel",
		Button_Close_caption: "Close",
		Checkbox_qtngvc0_tooltip: "Select this option if the application cannot securely store a client secret, such as a mobile app or single-page application (SPA). Leave it cleared for server-side applications that can keep the client secret protected.",
		CloseButton: "Close",
		ContinueInOtherPageButton_caption: "Continue in other page",
		DefaultHeaderCaption: "Title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "OAuth client app auth code mini page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});