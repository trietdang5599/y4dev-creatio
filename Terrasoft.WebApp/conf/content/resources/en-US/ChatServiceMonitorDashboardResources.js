define("ChatServiceMonitorDashboardResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ChatsByAgentsChartWidget_series_0: "Chats",
		ProcessedVsMissedChatsChartWidget_series_1: "Missed",
		ProcessedVsMissedChatsChartWidget_series_0: "Processed",
		ChatsByChannelChartWidget_label: "Chat",
		ChatsByChannelChartWidget_title: "Chats by channel",
		ProcessedVsMissedChatsChartWidget_label: "Missed",
		ProcessedVsMissedChatsChartWidget_title: "Processed vs Missed chats",
		ChatsBySourceChartWidget_label: "Chat",
		ChatsBySourceChartWidget_title: "Chats by source",
		ChatsByAgentsChartWidget_label: "Chats",
		ChatsByAgentsChartWidget_title: "Chats by agents",
		ChatsRegistrationDynamicChartWidget_series_0: "Chats",
		ChatsRegistrationDynamicChartWidget_label: "Chats",
		ChatsRegistrationDynamicChartWidget_title: "Chats registration dynamic",
		ChatsByStatusChartWidget_series_0: "Chat",
		ChatsByStatusChartWidget_label: "Chat",
		ChatsByStatusChartWidget_title: "Chats by status",
		ChatsInProgressIndicatorWidget_template: "{0}",
		ChatsInProgressIndicatorWidget_title: "Chats in progress",
		WaitingForProcessingIndicatorWidget_template: "{0}",
		WaitingForProcessingIndicatorWidget_title: "Waiting for processing",
		AverageChatDurationIndicatorWidget_template: "{0}",
		AverageChatDurationIndicatorWidget_title: "Average chat duration, min.",
		AverageFirstResponseTimeIndicatorWidget_template: "{0}",
		AverageFirstResponseTimeIndicatorWidget_title: "Average first response time, sec.",
		ChatsByChannelChartWidget_series_0: "Chat",
		ChatsBySourceChartWidget_series_0: "Chat"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Chat service monitor"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});