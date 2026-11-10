define("ContactCommunicationDetailV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DetailCaption: "Communication options",
		AddButtonCaption: "New",
		DoNotUseEmail: "Do not use email",
		DoNotUseCall: "Do not use phone",
		DoNotUseSms: "Do not use SMS",
		DoNotUseFax: "Do not use fax",
		DoNotUseMail: "Do not use mail",
		DoNotUseEmailCaption: "Email",
		DoNotUseCallCaption: "Phone",
		DoNotUseSmsCaption: "SMS",
		DoNotUseFaxCaption: "Fax",
		DoNotUseMailCaption: "Mail",
		DoNotUseCommunicationCaption: "Do not use",
		PhoneMenuItem: "Phone",
		SocialNetworksMenuItem: "Social",
		ValidationErrorTemplate: "The {0} detail is invalid"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "ContactCommunicationDetailV2",
				resourceItemName: "DeleteIcon",
				hash: "b8ed94f31f1b674db8c47c1cf439369c",
				resourceItemExtension: ".png"
			}
		},
		LookUpIcon: {
			source: 3,
			params: {
				schemaName: "ContactCommunicationDetailV2",
				resourceItemName: "LookUpIcon",
				hash: "c1a599bbebb97d8ded060f6e2df8ba9a",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage: {
			source: 3,
			params: {
				schemaName: "ContactCommunicationDetailV2",
				resourceItemName: "AddButtonImage",
				hash: "db1b0d1a50235c598db887d5529030ae",
				resourceItemExtension: ".svg"
			}
		},
		ToolsButtonImage: {
			source: 3,
			params: {
				schemaName: "ContactCommunicationDetailV2",
				resourceItemName: "ToolsButtonImage",
				hash: "48d545549ca4ddb13d7a7bb58f60ed5e",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});