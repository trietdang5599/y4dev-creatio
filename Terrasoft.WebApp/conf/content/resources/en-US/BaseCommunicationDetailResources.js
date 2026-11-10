define("BaseCommunicationDetailResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DetailCaption: "Communication options",
		AddButtonCaption: "New",
		PhoneMenuItem: "Phone",
		SocialNetworksMenuItem: "Social",
		ValidationErrorTemplate: "Please, fill in the \u0022{0}\u0022 field",
		ErrorTemplate: "Detail {0}",
		DeleteMenuItemCaption: "Delete",
		NumberValidationErrorTemplate: "Specify a value for the communication option type \u0022{1}\u0022.",
		CommunicationTypeValidationErrorTemplate: "Specify the phone type for the communication option.",
		Caption: "",
		FieldsGroupCollapseButtonHint: "Collapse/expand"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationDetail",
				resourceItemName: "DeleteIcon",
				hash: "b0d3b031c07b8cc39b910c3aa4d4339f",
				resourceItemExtension: ".png"
			}
		},
		LookUpIcon: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationDetail",
				resourceItemName: "LookUpIcon",
				hash: "c1a599bbebb97d8ded060f6e2df8ba9a",
				resourceItemExtension: ".png"
			}
		},
		CallIcon: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationDetail",
				resourceItemName: "CallIcon",
				hash: "8e9ae7d81ae771eb769a432f0c486e88",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationDetail",
				resourceItemName: "AddButtonImage",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationDetail",
				resourceItemName: "ToolsButtonImage",
				hash: "48d545549ca4ddb13d7a7bb58f60ed5e",
				resourceItemExtension: ".svg"
			}
		},
		TwitterLinkImage: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationDetail",
				resourceItemName: "TwitterLinkImage",
				hash: "177b2cfd853b604b05045a21db11d301",
				resourceItemExtension: ".png"
			}
		},
		FacebookLinkImage: {
			source: 3,
			params: {
				schemaName: "BaseCommunicationDetail",
				resourceItemName: "FacebookLinkImage",
				hash: "96c94f9b83d555e712a845e769523959",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});