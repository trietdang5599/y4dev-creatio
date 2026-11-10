define("ProcessDashboardSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FutureTaskFilter: "\u041E\u0442\u043E\u0431\u0440\u0430\u0436\u0430\u0442\u044C \u0431\u0443\u0434\u0443\u0449\u0438\u0435 \u0437\u0430\u0434\u0430\u0447\u0438",
		DisplayMode_Group_Caption: "\u0413\u0440\u0443\u043F\u043E\u0432\u044B\u0435",
		DisplayMode_Personal_Caption: "\u041F\u0435\u0440\u0441\u043E\u043D\u0430\u043B\u044C\u043D\u044B\u0435",
		DisplayMode_All_Caption: "\u0412\u0441\u0435",
		OwnerActionsButtonCaption: "\u0414\u0435\u0439\u0441\u0442\u0432\u0438\u044F",
		OwnerActionAssignCaption: "\u041D\u0430\u0437\u043D\u0430\u0447\u0438\u0442\u044C",
		OwnerActionAssignToMeCaption: "\u041D\u0430\u0437\u043D\u0430\u0447\u0438\u0442\u044C \u043C\u043D\u0435",
		OwnerActionExecuteCaption: "\u0412\u044B\u043F\u043E\u043B\u043D\u0438\u0442\u044C",
		OwnerLookupCaption: "\u0412\u044B\u0431\u043E\u0440: \u041A\u043E\u043D\u0442\u0430\u043A\u0442",
		ContextHelpCode: "",
		ContextHelpId: "1839",
		EmptyResultMessage: "\u0423\u0437\u043D\u0430\u0439\u0442\u0435 \u0431\u043E\u043B\u044C\u0448\u0435 \u043E \u0431\u0438\u0437\u043D\u0435\u0441-\u043F\u0440\u043E\u0446\u0435\u0441\u0441\u0430\u0445 \u0432 {0}\u0410\u043A\u0430\u0434\u0435\u043C\u0438\u0438{1}.",
		EmptyResultTitle: "\u041F\u043E\u0445\u043E\u0436\u0435, \u0443 \u0432\u0430\u0441 \u0435\u0449\u0435 \u043D\u0435\u0442 \u0437\u0430\u0434\u0430\u0447 \u043F\u043E \u0431\u0438\u0437\u043D\u0435\u0441-\u043F\u0440\u043E\u0446\u0435\u0441\u0441\u0430\u043C \u0434\u043B\u044F \u0432\u044B\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u044F",
		ObsoleteDecorateItemMethodMessage: "",
		ObsoleteRemoveColumnsMethodMessage: "\u0440\u0430\u0441\u0448\u0438\u0440\u0435\u043D\u0438\u0435 \u043C\u0435\u0442\u043E\u0434\u043E\u0432: addColumns, addFilters"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		EmptyResultImage: {
			source: 3,
			params: {
				schemaName: "ProcessDashboardSchema",
				resourceItemName: "EmptyResultImage",
				hash: "a202b80583e5d608faa21f55dadc7845",
				resourceItemExtension: ".svg"
			}
		},
		Default: {
			source: 3,
			params: {
				schemaName: "ProcessDashboardSchema",
				resourceItemName: "Default",
				hash: "e43e33a3ae1d4c1a57e7e161d1b39dad",
				resourceItemExtension: ".svg"
			}
		},
		Filter: {
			source: 3,
			params: {
				schemaName: "ProcessDashboardSchema",
				resourceItemName: "Filter",
				hash: "31bd325b9d223868893ac5b0a8617a62",
				resourceItemExtension: ".svg"
			}
		},
		DefaultRemindingIcon: {
			source: 3,
			params: {
				schemaName: "ProcessDashboardSchema",
				resourceItemName: "DefaultRemindingIcon",
				hash: "fc25e15a25188b310d43e0d790d71956",
				resourceItemExtension: ".svg"
			}
		},
		OwnerRoleIcon: {
			source: 3,
			params: {
				schemaName: "ProcessDashboardSchema",
				resourceItemName: "OwnerRoleIcon",
				hash: "2f83c4882627d7dc91665ec1b01e9011",
				resourceItemExtension: ".svg"
			}
		},
		OwnerIcon: {
			source: 3,
			params: {
				schemaName: "ProcessDashboardSchema",
				resourceItemName: "OwnerIcon",
				hash: "aa7489ca0550082fe70fd33021c53f2a",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});