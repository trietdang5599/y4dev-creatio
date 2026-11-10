define("SocialFeedResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SortCreatedOn: "Sort by message date",
		SortLastActionOn: "Sort by date of last activity",
		Publish: "Publish",
		SelectChannelHint: "Select channel",
		WritePostHint: "What are you working on?",
		ShowMoreThanOneNewSocialMessages: "Show {0} new messages",
		ShowNewSocialMessage: "Show 1 new message",
		WritePostMessage: "Write message text",
		SelectChannelMessage: "Select channel for posting",
		CurrentChannelHint: "Current channel",
		ConfigurationButtonHint: "Configuration button",
		SubscribeCaption: "Follow",
		UnsubscribeCaption: "Unfollow"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Sort: {
			source: 3,
			params: {
				schemaName: "SocialFeed",
				resourceItemName: "Sort",
				hash: "a8bd9c465829019c84dc848375c6ce93",
				resourceItemExtension: ".png"
			}
		},
		More: {
			source: 3,
			params: {
				schemaName: "SocialFeed",
				resourceItemName: "More",
				hash: "031d369f5cd473c41a1f54e907d86519",
				resourceItemExtension: ".png"
			}
		},
		DefaultCreatedBy: {
			source: 3,
			params: {
				schemaName: "SocialFeed",
				resourceItemName: "DefaultCreatedBy",
				hash: "7c719b318f2d4d210c9bec4991dabfc9",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});