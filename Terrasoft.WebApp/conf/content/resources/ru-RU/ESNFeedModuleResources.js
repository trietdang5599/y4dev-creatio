define("ESNFeedModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SortCreatedOn: "\u0421\u043E\u0440\u0442\u0438\u0440\u043E\u0432\u0430\u0442\u044C \u043F\u043E \u0434\u0430\u0442\u0435 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u044F",
		SortLastActionOn: "\u0421\u043E\u0440\u0442\u0438\u0440\u043E\u0432\u0430\u0442\u044C \u043F\u043E \u0434\u0430\u0442\u0435 \u043F\u043E\u0441\u043B\u0435\u0434\u043D\u0435\u0433\u043E \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		SelectChannelHint: "\u0412\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u043A\u0430\u043D\u0430\u043B",
		Publish: "\u041E\u043F\u0443\u0431\u043B\u0438\u043A\u043E\u0432\u0430\u0442\u044C",
		Comments: "\u041A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0438",
		HideComments: "\u0421\u043A\u0440\u044B\u0442\u044C \u043A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0438",
		ShowComments: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u0435\u0449\u0435 {0} \u043A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0435\u0432",
		Send: "\u041A\u043E\u043C\u043C\u0435\u043D\u0442\u0438\u0440\u043E\u0432\u0430\u0442\u044C",
		Cancel: "\u041E\u0442\u043C\u0435\u043D\u0430",
		WriteComment: "\u041D\u0430\u043F\u0438\u0448\u0438\u0442\u0435 \u043A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0439",
		SelectChannelMessage: "\u0414\u043B\u044F \u043F\u0443\u0431\u043B\u0438\u043A\u0430\u0446\u0438\u0438 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u044F \u0432\u044B\u0431\u0435\u0440\u0438\u0442\u0435 \u043A\u0430\u043D\u0430\u043B",
		WritePostMessage: "\u0414\u043B\u044F \u043F\u0443\u0431\u043B\u0438\u043A\u0430\u0446\u0438\u0438 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u044F \u043D\u0430\u043F\u0438\u0448\u0438\u0442\u0435 \u0447\u0442\u043E-\u043D\u0438\u0431\u0443\u0434\u044C",
		WritePostHint: "\u041D\u0430\u0434 \u0447\u0435\u043C \u0432\u044B \u0441\u0435\u0439\u0447\u0430\u0441 \u0440\u0430\u0431\u043E\u0442\u0430\u0435\u0442\u0435?",
		FeedCaption: "\u041B\u0435\u043D\u0442\u0430",
		LikedUsersContainerCaption: "\u041B\u044E\u0434\u0438, \u043A\u043E\u0442\u043E\u0440\u044B\u043C \u044D\u0442\u043E \u043D\u0440\u0430\u0432\u0438\u0442\u0441\u044F",
		CloseLikedUsersContainerButton: "\u0417\u0430\u043A\u0440\u044B\u0442\u044C",
		EditPostComment: "\u0418\u0437\u043C\u0435\u043D\u0438\u0442\u044C",
		ShowNewSocialMessage: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C 1 \u043D\u043E\u0432\u043E\u0435 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435",
		ShowMoreThanOneNewSocialMessages: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C {0} \u043D\u043E\u0432\u044B\u0445 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0439",
		HideCommentsShort: "\u0421\u043A\u0440\u044B\u0442\u044C",
		ShowCommentsShort: "\u0415\u0449\u0435 ({0})",
		SocialChannelCaption: "\u041A\u0430\u043D\u0430\u043B\u044B",
		PublishInCaption: "\u041E\u043F\u0443\u0431\u043B\u0438\u043A\u043E\u0432\u0430\u0442\u044C \u0432: {0}",
		DeleteConfirmationMessage: "\u0412\u044B \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u0445\u043E\u0442\u0438\u0442\u0435 \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u0432\u044B\u0434\u0435\u043B\u0435\u043D\u043D\u044B\u0439 \u044D\u043B\u0435\u043C\u0435\u043D\u0442?",
		LikeButtonCaption: "\u041D\u0440\u0430\u0432\u0438\u0442\u0441\u044F",
		UnLikeButtonCaption: "\u041D\u0435 \u043D\u0440\u0430\u0432\u0438\u0442\u0441\u044F",
		DeletePostComment: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		CreatedByToEntity: "\u043E\u043F\u0443\u0431\u043B\u0438\u043A\u043E\u0432\u0430\u043B(\u0430) \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435 \u0432",
		CreatedBy: "\u043E\u043F\u0443\u0431\u043B\u0438\u043A\u043E\u0432\u0430\u043B(\u0430) \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435",
		MaxMessagesNumberPerSearchIterationReached: "\u041D\u0435\u043E\u0431\u0445\u043E\u0434\u0438\u043C\u043E\u0435 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u0435 \u043D\u0435 \u043D\u0430\u0439\u0434\u0435\u043D\u043E \u0441\u0440\u0435\u0434\u0438 \u043F\u043E\u0441\u043B\u0435\u0434\u043D\u0438\u0445 {0} \u043E\u043F\u0443\u0431\u043B\u0438\u043A\u043E\u0432\u0430\u043D\u043D\u044B\u0445. \u041F\u0440\u043E\u0434\u043E\u043B\u0436\u0438\u0442\u044C \u043F\u043E\u0438\u0441\u043A \u043F\u043E \u0431\u043E\u043B\u0435\u0435 \u0440\u0430\u043D\u043D\u0438\u043C \u043F\u0443\u0431\u043B\u0438\u043A\u0430\u0446\u0438\u044F\u043C?",
		ViewModuleUrl: "ViewModule.aspx#",
		InsertMessageError: "\u041F\u0440\u043E\u0438\u0437\u043E\u0448\u043B\u0430 \u043E\u0448\u0438\u0431\u043A\u0430 \u043F\u0440\u0438 \u0441\u043E\u0445\u0440\u0430\u043D\u0435\u043D\u0438\u0438 \u0441\u043E\u043E\u0431\u0449\u0435\u043D\u0438\u044F \u043B\u0435\u043D\u0442\u044B",
		RightsErrorMessage: "\u0423 \u0432\u0430\u0441 \u043D\u0435\u0442 \u043F\u0440\u0430\u0432 \u043D\u0430 \u0432\u044B\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u0435 \u0434\u0430\u043D\u043D\u043E\u0433\u043E \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u044F. \u041E\u0431\u0440\u0430\u0442\u0438\u0442\u0435\u0441\u044C \u043A \u0441\u0438\u0441\u0442\u0435\u043C\u043D\u043E\u043C\u0443 \u0430\u0434\u043C\u0438\u043D\u0438\u0441\u0442\u0440\u0430\u0442\u043E\u0440\u0443."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Comment: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Comment",
				hash: "a7f20515d229765fdadd142ba8898f04",
				resourceItemExtension: ".png"
			}
		},
		Like: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Like",
				hash: "f73d792a0906561eed24e5cfe17f0517",
				resourceItemExtension: ".png"
			}
		},
		Empty: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Empty",
				hash: "4d56cebebf22614808a51428798f37be",
				resourceItemExtension: ".png"
			}
		},
		Sort: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Sort",
				hash: "a8bd9c465829019c84dc848375c6ce93",
				resourceItemExtension: ".png"
			}
		},
		Liked: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Liked",
				hash: "b4851e0f64e827ec7762a82634dafea9",
				resourceItemExtension: ".png"
			}
		},
		NoChannel: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "NoChannel",
				hash: "ccf544a6ecded2938958d7bf8a0993f3",
				resourceItemExtension: ".png"
			}
		},
		Arrow: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Arrow",
				hash: "03ef59deedda43659a59ffedca857b90",
				resourceItemExtension: ".png"
			}
		},
		Delete: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Delete",
				hash: "5a9c89d631b6612924992d3ee02d7b8a",
				resourceItemExtension: ".png"
			}
		},
		Edit: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "Edit",
				hash: "18581e1054fe4e9c38ee8aaa66dd0f87",
				resourceItemExtension: ".png"
			}
		},
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "CloseIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		PublishButton: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "PublishButton",
				hash: "88768289520a58c95c434b7c53ee902c",
				resourceItemExtension: ".png"
			}
		},
		More: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "More",
				hash: "031d369f5cd473c41a1f54e907d86519",
				resourceItemExtension: ".png"
			}
		},
		ESNFeedDataViewIcon: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "ESNFeedDataViewIcon",
				hash: "5b30780bb761f779a33b0c24de6e88fa",
				resourceItemExtension: ".png"
			}
		},
		SocialChannelDataViewIcon: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "SocialChannelDataViewIcon",
				hash: "5b30780bb761f779a33b0c24de6e88fa",
				resourceItemExtension: ".png"
			}
		},
		DefaultCreatedBy: {
			source: 3,
			params: {
				schemaName: "ESNFeedModule",
				resourceItemName: "DefaultCreatedBy",
				hash: "7c719b318f2d4d210c9bec4991dabfc9",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});