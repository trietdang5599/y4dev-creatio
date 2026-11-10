define("MobileFeedListResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MobileFeedListMessageTodayFormat: " {0} h",
		MobileFeedListMessageYesterdayFormat: "Yesterday at {0}",
		MobileFeedListMessageDateFormat: " {0} at {1}",
		MobileFeedListMessageMinutesFormat: " {0} min",
		MobileFeedListMessageBeforeYesterdayFormat: "The day before yesterday at {0}",
		MobileFeedListItemLikeCountLabel: "Likes",
		MobileFeedListItemCommentCountLabel: "Comments",
		MobileFeedListItemCommentButtonCaption: "Comment",
		MobileFeedListItemLikeButtonCaption: "Like",
		MobileFeedListDotSeparator: "\u2022",
		MobileFeedListReadMoreLabel: "Continue reading"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		IconArrowDownGray: {
			source: 3,
			params: {
				schemaName: "MobileFeedList",
				resourceItemName: "IconArrowDownGray",
				hash: "1929d821455624a1ef0e6d2ed4431e88",
				resourceItemExtension: ".png"
			}
		},
		LikeIcon: {
			source: 3,
			params: {
				schemaName: "MobileFeedList",
				resourceItemName: "LikeIcon",
				hash: "79573ff03e7e06b80d5713e7e088676b",
				resourceItemExtension: ".png"
			}
		},
		LikeIconPressed: {
			source: 3,
			params: {
				schemaName: "MobileFeedList",
				resourceItemName: "LikeIconPressed",
				hash: "b51942edb36d081b0a43dd5b09c5b04a",
				resourceItemExtension: ".png"
			}
		},
		CommentIcon: {
			source: 3,
			params: {
				schemaName: "MobileFeedList",
				resourceItemName: "CommentIcon",
				hash: "fe34b524d974ceb3a8767d34f5ff1116",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});