define("SocialChannelPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SubscribeButtonCaption: "Follow",
		UnsubscribeButtonCaption: "Unfollow",
		AllUsersPublisherRights: "All users can post",
		EditorsPublisherRights: "Only users with edit permission for this channel can post",
		PublisherRightKind: "Permission to post entries"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SocialChannelImage: {
			source: 3,
			params: {
				schemaName: "SocialChannelPage",
				resourceItemName: "SocialChannelImage",
				hash: "ccf544a6ecded2938958d7bf8a0993f3",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});