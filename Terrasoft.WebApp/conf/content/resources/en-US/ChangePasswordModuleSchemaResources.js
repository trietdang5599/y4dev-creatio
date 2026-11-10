define("ChangePasswordModuleSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		saveButtonCaption: "Change password",
		cancelButtonCaption: "Cancel",
		headerCaption: "Changing password",
		passwordMissMatchMessageCaption: "Passwords do not match",
		currentPasswordCaption: "Current password",
		newPasswordCaption: "New password",
		newPasswordConfirmationCaption: "Confirm new password",
		successPasswordChangeMessage: "Password successfully changed.",
		errorPasswordChangeMessage: "The attempt to change the password failed. To resolve this issue, contact your system administrator.",
		invalidTotpToken: "Provided TOTP code is invalid. Please, check it and try once again.",
		totpCodeCaption: "TOTP Code",
		confirmationCodeCaption: "Confirmation code",
		requiredConfirmationCodeMessage: "Enter a value",
		sendTextCodeCaption: "Send code via SMS"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});