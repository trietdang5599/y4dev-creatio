define("MeetingInvitationsMixinResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CanNotChangeMeetingMessage: "Only the meeting organizer can change the description, date and list of the meeting participants.",
		ResendMeetingInvitationsMessage: "When the meeting is saved all participants will receive a meeting update. Please confirm that you want to proceed.",
		SuccessSendingInvitationMessage: "Invitations were successfully sent.",
		ErrorSendingInvitationMessage: "The invitations were not sent. It may be a temporary issue, please try again later.",
		ResendObsoleteMeetingInvitationsMessage: "Meeting occurs in the past. All participants will receive a meeting update. Please confirm that you want to proceed.",
		DeleteMeetingWithInvitationsConfirmationMessage: "Are you sure that you want to delete the selected record? All participants will receive a meeting update. Please confirm that you want to proceed.",
		MultiDeleteMeetingWithInvitationsConfirmationMessage: "Are you sure that you want to delete the selected records? All participants will receive a meeting update. Please confirm that you want to proceed.",
		DeleteMeetingWithInvitationsByNotOrganizerMessage: "Only the meeting organizer can delete the meeting.",
		MultiDeleteMeetingWithInvitationsByNotOrganizerMessage: "Selected records contain meetings with sended invitations. Only the meeting organizer can delete these meetings."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});