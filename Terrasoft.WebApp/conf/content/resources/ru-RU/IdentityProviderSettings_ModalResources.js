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
		CancelButton: "\u041E\u0442\u043C\u0435\u043D\u0430",
		CloseButton: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		ContinueInOtherPageButton_caption: "\u041F\u0440\u043E\u0434\u043E\u043B\u0436\u0438\u0442\u044C \u043D\u0430 \u0434\u0440\u0443\u0433\u043E\u0439 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435",
		DefaultHeaderCaption: "\u0417\u0430\u0433\u043E\u043B\u043E\u0432\u043E\u043A",
		NewRecord: "\u041D\u043E\u0432\u0430\u044F \u0437\u0430\u043F\u0438\u0441\u044C",
		Record: "\u0417\u0430\u043F\u0438\u0441\u044C",
		SaveButton: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "\u041C\u0438\u043D\u0438\u043A\u0430\u0440\u0442\u043E\u0447\u043A\u0430"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});