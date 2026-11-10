define("ChatTimelineItemViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowChatButtonCaption: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u0447\u0430\u0442",
		HideChatButtonCaption: "\u0421\u043A\u0440\u044B\u0442\u044C \u0447\u0430\u0442"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ShowMoreImage: {
			source: 3,
			params: {
				schemaName: "ChatTimelineItemViewModel",
				resourceItemName: "ShowMoreImage",
				hash: "cc550b8d4e8b66669f0a2b5297c46c42",
				resourceItemExtension: ".svg"
			}
		},
		ShowLessImage: {
			source: 3,
			params: {
				schemaName: "ChatTimelineItemViewModel",
				resourceItemName: "ShowLessImage",
				hash: "29abe2155918d5f7ff6892930b4bb0bc",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});