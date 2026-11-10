define("ESNFeedModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SortCreatedOn: "Sort by message date",
		SortLastActionOn: "Sort by date of last activity",
		SelectChannelHint: "Select channel",
		Publish: "Publish",
		Comments: "Comments",
		HideComments: "Hide comments",
		ShowComments: "Show next {0} comments",
		Send: "Comment",
		Cancel: "Cancel",
		WriteComment: "Write comment",
		SelectChannelMessage: "Select channel for posting",
		WritePostMessage: "Write message text",
		WritePostHint: "What are you working on?",
		FeedCaption: "Feed",
		LikedUsersContainerCaption: "People who liked this",
		CloseLikedUsersContainerButton: "Close",
		EditPostComment: "Edit",
		ShowNewSocialMessage: "Show 1 new message",
		ShowMoreThanOneNewSocialMessages: "Show {0} new messages",
		HideCommentsShort: "Hide",
		ShowCommentsShort: "More ({0})",
		SocialChannelCaption: "Channels",
		PublishInCaption: "Publish in: {0}",
		DeleteConfirmationMessage: "Are you sure that you want to delete the selected item?",
		LikeButtonCaption: "Like",
		UnLikeButtonCaption: "Unlike",
		DeletePostComment: "Delete",
		CreatedByToEntity: "posted in",
		CreatedBy: "posted",
		MaxMessagesNumberPerSearchIterationReached: "The message was not found among {0} recently posted messages. Load earlier messages?",
		ViewModuleUrl: "ViewModule.aspx#",
		InsertMessageError: "Error while saving feed post",
		RightsErrorMessage: "Insufficient rights to perform this action. Contact your system administrator."
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