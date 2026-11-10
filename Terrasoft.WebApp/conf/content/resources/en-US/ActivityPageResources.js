define("ActivityPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		StatusGroupCaption: "Status",
		RemindingGroupCaption: "Reminders",
		BoundGroupCaption: "Connected to",
		StartDateGreaterDueDate: "The value in the \u0022Due\u0022 field should be greater than the value in the \u0022Start\u0022 field",
		RemindToOwnerCaption: "Remind owner",
		RemindToAuthorCaption: "Remind author",
		ActivityParticipantDetailCaption: "Participants",
		ResultGroupCaption: "Result",
		OkResultButtonCaption: "Save",
		CancelResultButtonCaption: "Cancel",
		DetailedResultCaption: "Result details"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		greenResultIcon: {
			source: 3,
			params: {
				schemaName: "ActivityPage",
				resourceItemName: "greenResultIcon",
				hash: "bf1e1dd86f7e996c5d3f609619279231",
				resourceItemExtension: ".png"
			}
		},
		greyResultIcon: {
			source: 3,
			params: {
				schemaName: "ActivityPage",
				resourceItemName: "greyResultIcon",
				hash: "51587299689e6221ec963e30b8ba37f2",
				resourceItemExtension: ".png"
			}
		},
		redResultIcon: {
			source: 3,
			params: {
				schemaName: "ActivityPage",
				resourceItemName: "redResultIcon",
				hash: "84e0d956001c5c948ab5273033dfe1f7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});