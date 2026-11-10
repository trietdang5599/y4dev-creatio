define("ContextHelpSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowTips: "Show tips",
		GoToHelp: "Online help",
		AskSupport: "Need help",
		HelpToImprove: "Help improve this page",
		SupportSubject: "Question about",
		SupportEmailBodyTemplate: "body=%0D%0A%0D%0ASite:  {0}%0D%0ACustomer ID: {1}%0D%0AProduct: {2}%0D%0AVersion:  {3}%0D%0ALocalization: {4}%0D%0APage: {5}",
		FeedbackSubject: "Help us improve",
		FeedbackEmailBodyTemplate: "body=We strive for excellence and we would love to receive your feedback about this page! Do you have any ideas on how we can improve it? Please email us! Your comments and feedback are highly desired!%0D%0A%0D%0A%0D%0ASite: {0}%0D%0ACustomer ID: {1}%0D%0AProduct: {2}%0D%0AVersion: {3}%0D%0ALocalization: {4}%0D%0APage: {5}",
		AddExternalAccess: "Grant access to support",
		ExternalAccessGrantedMessage: "Access granted"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		HelpIcon: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "HelpIcon",
				hash: "bc130028e74a17b9035d74db521153b0",
				resourceItemExtension: ".svg"
			}
		},
		Support: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "Support",
				hash: "2c1d5db4924fa6f623c44fb8327462e9",
				resourceItemExtension: ".png"
			}
		},
		Tips: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "Tips",
				hash: "621d135be3ba71cbba2500c612826a80",
				resourceItemExtension: ".png"
			}
		},
		Help: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "Help",
				hash: "f4f6ab78c5bb9e9d6bfb45d14e022c41",
				resourceItemExtension: ".png"
			}
		},
		Corner: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "Corner",
				hash: "727fcf253a4f65bb94be72f9e28b17e4",
				resourceItemExtension: ".png"
			}
		},
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "CloseIcon",
				hash: "d5c1f59e51567119abdffccbfbf233db",
				resourceItemExtension: ".png"
			}
		},
		Feedback: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "Feedback",
				hash: "16552ac292a67601a322a23757a95df1",
				resourceItemExtension: ".png"
			}
		},
		ExternalAccess: {
			source: 3,
			params: {
				schemaName: "ContextHelpSchema",
				resourceItemName: "ExternalAccess",
				hash: "bf22ce850f1aabb90f65e001f000a96b",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});