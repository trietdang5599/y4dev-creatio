define("PortalUserInvitationModuleSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PortalUserInvitationCaption: "Create external users",
		PortalUserInvitationModalBoxMessage: "Create external users by adding their email addresses below. After adding the new users you will be able to send invitations to their email addresses. Users will be able to log in using these email addresses as user names",
		InviteButtonCaption: "Create users",
		CancelButtonCaption: "Cancel",
		PortalUserInvitationEmailToolTipText: "Separate each email address using gaps or commas. Note, you can not invite users by sending an invitation to a mailing list (like info@company.com).",
		PortalUserInvitationLabelText: "Email addresses",
		InviteUserInformationMessage: "Invitations were sent to each email address",
		EmptyEmailsErrorMessage: "Enter email addresses",
		InvalidEmailEntered: "Invalid email entered",
		PortalUserOptionalFuncRolesMessage: "Select additional permissions that will be granted to the new external users:",
		CorporateDomainErrorMessage: "Unable to invite users. Some of the specified email addresses have the corporate domain of the company. Such addresses are not allowed for external users. Exclude the corporate email addresses and try again."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});