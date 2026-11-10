define("CtiNotificationUtilitiesResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		IncomingCallCaption: "Incoming call",
		MissedCallCaption: "Missed call",
		OutgoingCallCaption: "Outgoing call",
		DefaultCallCaption: ""
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		IncomingCall: {
			source: 3,
			params: {
				schemaName: "CtiNotificationUtilities",
				resourceItemName: "IncomingCall",
				hash: "a4157abbabf180f02bb793014218301c",
				resourceItemExtension: ".png"
			}
		},
		MissedCall: {
			source: 3,
			params: {
				schemaName: "CtiNotificationUtilities",
				resourceItemName: "MissedCall",
				hash: "6c03c33d471bc1f0f191e28ddd2a1841",
				resourceItemExtension: ".png"
			}
		},
		OutgoingCall: {
			source: 3,
			params: {
				schemaName: "CtiNotificationUtilities",
				resourceItemName: "OutgoingCall",
				hash: "2de06bfc2c1be4bfde488220f7548828",
				resourceItemExtension: ".png"
			}
		},
		DefaultCall: {
			source: 3,
			params: {
				schemaName: "CtiNotificationUtilities",
				resourceItemName: "DefaultCall",
				hash: "2de06bfc2c1be4bfde488220f7548828",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});