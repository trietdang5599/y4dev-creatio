define("ActivityParticipantGridViewModelResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		UnknownTip: "Unknown",
		DeclinedTip: "Declined",
		InDoubtTip: "In Doubt",
		AcceptedTip: "Accepted"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		InvitationDeclinedIcon: {
			source: 3,
			params: {
				schemaName: "ActivityParticipantGridViewModel",
				resourceItemName: "InvitationDeclinedIcon",
				hash: "242a93b071a7141042a2653f3edeca1a",
				resourceItemExtension: ".png"
			}
		},
		InDoubtIcon: {
			source: 3,
			params: {
				schemaName: "ActivityParticipantGridViewModel",
				resourceItemName: "InDoubtIcon",
				hash: "8186180931fd2316f538ae8b331c37bf",
				resourceItemExtension: ".png"
			}
		},
		InvitationAcceptedIcon: {
			source: 3,
			params: {
				schemaName: "ActivityParticipantGridViewModel",
				resourceItemName: "InvitationAcceptedIcon",
				hash: "b7fe8f76659fc7d09881d81d5fd32963",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});