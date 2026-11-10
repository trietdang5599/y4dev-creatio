define("FacebookSearchSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		HeaderCaption: "Search on Facebook",
		ResultGridNameCaption: "Name",
		ResultGridCategoryCaption: "Category",
		ResultGridWebCaption: "Web",
		ResultGridPhoneCaption: "Phone",
		ResultGridCountryCaption: "Country",
		ResultGridCityCaption: "City",
		SearchTooltip: "Specify a link to the contact\u2019s Facebook page.",
		SearchFacebookButtonCaption: "Search on Facebook",
		SearchHelpText: "Due to changes in Facebook privacy policy, searching for a user profile by unique page name is unavailable for third-party applications. If the link to the Facebook profile of the account does not have a numeric user ID, the profile will not be displayed among the search results."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		InfoSpriteImage: {
			source: 3,
			params: {
				schemaName: "FacebookSearchSchema",
				resourceItemName: "InfoSpriteImage",
				hash: "c253d8a46fdd8595204eb650dd35e982",
				resourceItemExtension: ".png"
			}
		},
		SearchFacebookButtonImage: {
			source: 3,
			params: {
				schemaName: "FacebookSearchSchema",
				resourceItemName: "SearchFacebookButtonImage",
				hash: "838676a2e02f94ebed274cd137a285de",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});