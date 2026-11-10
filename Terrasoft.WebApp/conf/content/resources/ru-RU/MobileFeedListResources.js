define("MobileFeedListResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MobileFeedListMessageTodayFormat: " {0} \u0447",
		MobileFeedListMessageYesterdayFormat: "\u0412\u0447\u0435\u0440\u0430 \u0432 {0}",
		MobileFeedListMessageDateFormat: " {0} \u0432 {1}",
		MobileFeedListMessageMinutesFormat: " {0} \u043C\u0438\u043D",
		MobileFeedListMessageBeforeYesterdayFormat: "\u041F\u043E\u0437\u0430\u0432\u0447\u0435\u0440\u0430 \u0432 {0}",
		MobileFeedListItemLikeCountLabel: "\u041D\u0440\u0430\u0432\u0438\u0442\u0441\u044F",
		MobileFeedListItemCommentCountLabel: "\u041A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0435\u0432",
		MobileFeedListItemCommentButtonCaption: "\u041A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0439",
		MobileFeedListItemLikeButtonCaption: "\u041D\u0440\u0430\u0432\u0438\u0442\u0441\u044F",
		MobileFeedListDotSeparator: "\u2022",
		MobileFeedListReadMoreLabel: "\u0427\u0438\u0442\u0430\u0442\u044C \u0434\u0430\u043B\u044C\u0448\u0435"
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