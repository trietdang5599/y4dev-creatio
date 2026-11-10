define("BaseCommunicationDetailResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DetailCaption: "\u0421\u0440\u0435\u0434\u0441\u0442\u0432\u0430 \u0441\u0432\u044F\u0437\u0438",
		AddButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C",
		PhoneMenuItem: "\u0422\u0435\u043B\u0435\u0444\u043E\u043D",
		SocialNetworksMenuItem: "\u0421\u043E\u0446\u0438\u0430\u043B\u044C\u043D\u044B\u0435 \u0441\u0435\u0442\u0438",
		ValidationErrorTemplate: "\u041F\u043E\u043B\u0435 \u0022{0}\u0022: \u041D\u0435\u043E\u0431\u0445\u043E\u0434\u0438\u043C\u043E \u0443\u043A\u0430\u0437\u0430\u0442\u044C \u0437\u043D\u0430\u0447\u0435\u043D\u0438\u0435",
		ErrorTemplate: "\u0414\u0435\u0442\u0430\u043B\u044C {0}",
		DeleteMenuItemCaption: "\u0423\u0434\u0430\u043B\u0438\u0442\u044C",
		NumberValidationErrorTemplate: "\u0423\u043A\u0430\u0436\u0438\u0442\u0435 \u0437\u043D\u0430\u0447\u0435\u043D\u0438\u0435 \u0441\u0440\u0435\u0434\u0441\u0442\u0432\u0430 \u0441\u0432\u044F\u0437\u0438 \u0441 \u0442\u0438\u043F\u043E\u043C \u0022{1}\u0022.",
		CommunicationTypeValidationErrorTemplate: "\u0423\u043A\u0430\u0436\u0438\u0442\u0435 \u0442\u0438\u043F \u0442\u0435\u043B\u0435\u0444\u043E\u043D\u0430 \u0434\u043B\u044F \u0441\u0440\u0435\u0434\u0441\u0442\u0432\u0430 \u0441\u0432\u044F\u0437\u0438.",
		Caption: "",
		FieldsGroupCollapseButtonHint: "\u0421\u0432\u0435\u0440\u043D\u0443\u0442\u044C/\u0440\u0430\u0437\u0432\u0435\u0440\u043D\u0443\u0442\u044C"
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