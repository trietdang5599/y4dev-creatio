define("ChatQueues_FormPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ChatTimeout_tooltip: "Maximum waiting time before the chat will be automatically completed",
		RoutingRule_tooltip: "The way chats will be distributed to agents",
		QueueAgentsList_DeleteBulkAction_caption: "Delete",
		QueueAgentsExpansionPanel_title: "Queue agents",
		QueueAgentsListDS_Operator: "User/Role",
		QueueAgentsAddButton_caption: "New",
		QueueAgentsSearchFilter_placeholder: "Search",
		QueueAgentsRefreshButton_caption: "Refresh",
		OngoingResponseTime_tooltip: "Maximum time allowed for the agent to reply to customer messages during an active chat before it becomes overdue",
		FirstResponseTime_tooltip: "Maximum time allowed for the agent to send the first reply before the chat becomes overdue",
		BackButton: "Back",
		CancelButton: "Cancel",
		CloseButton: "Close",
		DefaultHeaderCaption: "Page title",
		NewRecord: "New record",
		Record: "Record",
		SaveButton: "Save",
		SetRecordRightsButtonCaption: "Set up access rights"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Chat queues form page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});