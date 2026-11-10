define("FindContactsInSocialNetworksModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		CloseButtonCaption: "Cancel",
		ViewButtonCaption: "View",
		CreateNewContactButtonCaption: "Create contact",
		FindButtonCaption: "Search",
		AllSocialNetworksCaption: "All results",
		SocialAccountColCaption: "Username",
		SocialMediaColCaption: "Social network",
		SearchEditLabelCaption: "Search in social networks",
		FilterSocialNetworksLabelCaption: "Filter search results by social networks",
		ResultsLabelCaption: "Search results",
		OKButtonCaption: "Select",
		SocialNetworkAuthError: "Unable to retrieve social network data. Log in to ",
		SocialNetworkError: "Unable to retrieve social network data ",
		InfoCaption: "Information",
		WindowCaption: "Find contacts in social networks",
		SocialNetworksError: "Unable to retrieve social network data. Log in to "
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		facebookimg: {
			source: 3,
			params: {
				schemaName: "FindContactsInSocialNetworksModule",
				resourceItemName: "facebookimg",
				hash: "0cea4154b9fecb110fdb238a0fee88d4",
				resourceItemExtension: ".png"
			}
		},
		twitterimg: {
			source: 3,
			params: {
				schemaName: "FindContactsInSocialNetworksModule",
				resourceItemName: "twitterimg",
				hash: "bee2663ab8f6be897f8b6e7b66e4fece",
				resourceItemExtension: ".png"
			}
		},
		linkedinimg: {
			source: 3,
			params: {
				schemaName: "FindContactsInSocialNetworksModule",
				resourceItemName: "linkedinimg",
				hash: "cf8c7f4f99136639fb0c634e0a4e012c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});