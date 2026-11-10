define("CtiNotificationUtilitiesResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		IncomingCallCaption: "\u0412\u0445\u043E\u0434\u044F\u0449\u0438\u0439 \u0432\u044B\u0437\u043E\u0432",
		MissedCallCaption: "\u041F\u0440\u043E\u043F\u0443\u0449\u0435\u043D\u043D\u044B\u0439 \u0432\u044B\u0437\u043E\u0432",
		OutgoingCallCaption: "\u0418\u0441\u0445\u043E\u0434\u044F\u0449\u0438\u0439 \u0432\u044B\u0437\u043E\u0432",
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