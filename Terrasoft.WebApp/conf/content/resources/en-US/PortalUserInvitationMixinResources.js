define("PortalUserInvitationMixinResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PortalAccountNotExistErrorMessage: "Organization wasn\u0027t created for this Account.\nTo create Organization please go to Organizational roles in System designer",
		UsersCreatedSuccessMessage: "New external users have been created. Do you wish to send them invitation emails?",
		UsersFailedMessage: "Creatio was unable to create any new external users.\n{0}",
		SomeUsersFailedMessage: "Creatio was unable to create following external users: {0}. Please contact system administrator.\n\nThe rest of the external users have been created. Do you wish to send them invitation emails?",
		OrganizationNotExistErrorMessage: "An organization for this account has not yet been registered",
		CreateOrganizationButtonCaption: "Create organization",
		CantAdministratePortalUsers: "You do not have permission to perform this operation.\n\nPlease contact your system administrator and request permission to perform the following system operation with code: \u00ABCanAdministratePortalUsers\u00BB.",
		SomeUsersWithoutEmailErrorMessage: "Unable to send email invitations to the external users. Before you attempt to send invitations again, please check data of the following external users: {0}",
		UserSuccessInviteMessage: "Invitations have been sent to the external users",
		InviteUsersButtonCaption: "Send invitation",
		CorporateDomainErrorMessage: "Unable to create users. Some of the specified email addresses have the corporate domain of the company. Such addresses are not allowed for external users. Exclude the corporate email addresses and try again."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});