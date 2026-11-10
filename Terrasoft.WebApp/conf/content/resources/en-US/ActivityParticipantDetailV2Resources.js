define("ActivityParticipantDetailV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ResendInvitationsButtonCaption: "Resend Invitations",
		SendInvitationsButtonCaption: "Send Invitations",
		SynchronizationNotEnabledHintTemplate: "Please set up the calendar synchronization in order to send the invitations\u003Cbr\u003Eand use all the features of the calendars.\u003Cbr\u003E\u003Ca href=\u0022{0}\u0022 target=\u0022_blank\u0022\u003ESynchronization configuration for Microsoft Exchange\u003C/a\u003E\u003Cbr\u003E\u003Ca href=\u0022{1}\u0022 target=\u0022_blank\u0022\u003ESynchronization configuration for Google Calendars\u003C/a\u003E",
		SendingInvitationToOldMeeting: "Meeting occurs in the past. Are you sure you want to send an invitation to the participants?",
		CanUserChangeMeetingResolveMessage: "You want to modify the list of the meeting participants. All participants will receive a meeting update. Please confirm that you want to proceed.",
		DeleteMeetingWithInvitationsConfirmationMessage: "Are you sure that you want to delete the selected record? Deleted participant will receive a notification about the cancellation of the meeting. Please confirm that you want to proceed.",
		MultiDeleteMeetingWithInvitationsConfirmationMessage: "Are you sure that you want to delete the selected records? Deleted participants will receive a notification about the cancellation of the meeting. Please confirm that you want to proceed.",
		CanNotChangeMeetingMessage: "Only the meeting organizer can change the description, date and list of the meeting participants.",
		CanUserChangeObsolteMeetingResolveMessage: "Meeting occurs in the past. You want to modify the list of the meeting participants. All participants will receive a meeting update. Please confirm that you want to proceed.",
		ActionsButtonCaption: "Actions",
		AddButtonCaption: "New",
		Caption: "Participants",
		CopyMenuCaption: "Copy",
		DeleteConfirmationMessage: "Are you sure that you want to delete the selected record?",
		DeleteMenuCaption: "Delete",
		DetailWizardMenuCaption: "Detail setup",
		DontInviteParticipant: "Don\u0027t invite participant",
		DontInviteSelectedParticipants: "Don\u0027t invite selected participants",
		EditMenuCaption: "Edit",
		ExportListToExcelFileButtonCaption: "Export to Excel",
		FieldsGroupCollapseButtonHint: "Collapse/expand",
		InviteParticipant: "Invite participant",
		InviteSelectedParticipants: "Invite selected participants",
		LoadMoreButtonCaption: "Show more",
		MasterRecordIdErrorMessage: "MasterRecordId parameter is not initialized in {0} detail, with hash {1}",
		MultiDeleteConfirmationMessage: "Are you sure that you want to delete the selected records?",
		MultiModeMenuCaption: "Select multiple records",
		OpenObjectChangeLogSettingsCaption: "Change log setup",
		OpenRecordChangeLogCaption: "View change log",
		OperationAccessDenied: "Current user does not have sufficient permissions to run \u0022{0}\u0022",
		ProcessButtonHint: "Run process by record",
		QuickFilterCaption: "Apply filter",
		RecordRightsSetupMenuItemCaption: "Set up access rights",
		RelationshipButtonHint: "By the child connections",
		RemoveQuickFilterCaption: "Hide filter",
		SchemaLocalizableString1: "",
		SetupGridMenuCaption: "Columns setup",
		SetupTotalMenuCaption: "Summaries setup",
		SingleModeMenuCaption: "Cancel multiple selection",
		SortMenuCaption: "Sort by",
		ToolsButtonHint: "Actions",
		ViewButtonCaption: "View",
		WarningResponsibleDelete: "You cannot delete a participant responsible for this activity"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ResendInvitationsImage: {
			source: 3,
			params: {
				schemaName: "ActivityParticipantDetailV2",
				resourceItemName: "ResendInvitationsImage",
				hash: "2bd0f8f592290139b063766b70686f23",
				resourceItemExtension: ".svg"
			}
		},
		SendInvitationsImage: {
			source: 3,
			params: {
				schemaName: "ActivityParticipantDetailV2",
				resourceItemName: "SendInvitationsImage",
				hash: "bb12b619dc92bf425d3a39c5b9a77e7b",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});