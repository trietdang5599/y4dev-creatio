define("SyncSettingsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ActivitySettingsTabCaption: "Calendar",
		AddContactEmailMessage: "Add the specified email address to the list of your communication options?",
		AddToCommunicationDetail: "Add email to contact communication detail ?",
		CancelButtonCaption: "Cancel",
		ChangeEmailSettings: "Change email settings",
		CloseButtonCaption: "Close",
		ContactSettingsTabCaption: "Contacts",
		EmailSettingsTabCaption: "Email",
		HeaderCaptionTpl: "{0} settings",
		NotSetSendingOrReceivingCheckMessage: "Please, select either the \u0022Enable email receiving\u0022 or \u0022Use mailbox to send messages\u0022 setting.",
		SaveButtonCaption: "Save",
		SMTPSettingsNotSetMessage: "Email parameters are not configured for the specified email provider",
		ThisIsNotImapOption: "This settings is for Exchange settings only."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});