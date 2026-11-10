define("VisaNotificationsSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ApproveMenuItemCaption: "Approve",
		RejectMenuItemCaption: "Reject",
		ChangeVizierCaption: "Change approver",
		VisaActionButton: "Actions",
		ShowOnlyMyApprovalsCaption: "Show only my approvals",
		ContextHelpCode: "",
		ContextHelpId: "1579",
		EmptyResultMessage: "Learn more about the approval procedure in the {0}Academy{1}.",
		EmptyResultTitle: "There are no records that require your approval",
		ObsoleteDecorateItemMethodMessage: "",
		ObsoleteRemoveColumnsMethodMessage: "extension methods addColumns or addFilters"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		EmptyResultImage: {
			source: 3,
			params: {
				schemaName: "VisaNotificationsSchema",
				resourceItemName: "EmptyResultImage",
				hash: "006b0c8c10baf3e1e8d69818201cb393",
				resourceItemExtension: ".svg"
			}
		},
		Approve: {
			source: 3,
			params: {
				schemaName: "VisaNotificationsSchema",
				resourceItemName: "Approve",
				hash: "68a244ea82056138e87f666fdc56c485",
				resourceItemExtension: ".svg"
			}
		},
		Reject: {
			source: 3,
			params: {
				schemaName: "VisaNotificationsSchema",
				resourceItemName: "Reject",
				hash: "4f5a23412b1a4485e20808acc81a265e",
				resourceItemExtension: ".svg"
			}
		},
		ChangeVizier: {
			source: 3,
			params: {
				schemaName: "VisaNotificationsSchema",
				resourceItemName: "ChangeVizier",
				hash: "df4c37b342bdc9330876e28c1ce214b4",
				resourceItemExtension: ".svg"
			}
		},
		DefaultImage: {
			source: 3,
			params: {
				schemaName: "VisaNotificationsSchema",
				resourceItemName: "DefaultImage",
				hash: "659eb84312153ec027f0ea1643b9b846",
				resourceItemExtension: ".svg"
			}
		},
		DefaultRemindingIcon: {
			source: 3,
			params: {
				schemaName: "VisaNotificationsSchema",
				resourceItemName: "DefaultRemindingIcon",
				hash: "fc25e15a25188b310d43e0d790d71956",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});