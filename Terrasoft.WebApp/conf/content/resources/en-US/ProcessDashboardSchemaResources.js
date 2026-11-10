define("ProcessDashboardSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FutureTaskFilter: "Show future tasks",
		DisplayMode_Group_Caption: "Group",
		DisplayMode_Personal_Caption: "Personal",
		DisplayMode_All_Caption: "All",
		OwnerActionsButtonCaption: "Actions",
		OwnerActionAssignCaption: "Assign",
		OwnerActionAssignToMeCaption: "Assign to me",
		OwnerActionExecuteCaption: "Execute",
		OwnerLookupCaption: "Select: Contact",
		ContextHelpCode: "",
		ContextHelpId: "1839",
		EmptyResultMessage: "Learn more about the business processes in the {0}Academy{1}.",
		EmptyResultTitle: "There are no business process tasks for now",
		ObsoleteDecorateItemMethodMessage: "",
		ObsoleteRemoveColumnsMethodMessage: "extension methods addColumns or addFilters"
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