define("ContextHelpSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ShowTips: "\u041F\u043E\u043A\u0430\u0437\u0430\u0442\u044C \u043F\u043E\u0434\u0441\u043A\u0430\u0437\u043A\u0438 \u043D\u0430 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435",
		GoToHelp: "\u041F\u0435\u0440\u0435\u0439\u0442\u0438 \u043A \u0441\u043F\u0440\u0430\u0432\u043A\u0435",
		AskSupport: "\u0417\u0430\u0434\u0430\u0442\u044C \u0432\u043E\u043F\u0440\u043E\u0441 \u0432 \u043F\u043E\u0434\u0434\u0435\u0440\u0436\u043A\u0443",
		HelpToImprove: "\u041F\u043E\u043C\u043E\u0447\u044C \u0443\u043B\u0443\u0447\u0448\u0438\u0442\u044C \u044D\u0442\u0443 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0443",
		SupportSubject: "\u0412\u043E\u043F\u0440\u043E\u0441 \u043F\u043E",
		SupportEmailBodyTemplate: "body=%0D%0A%0D%0A%0D%0A\u0421\u0430\u0439\u0442:  {0}%0D%0A\u0418\u0434\u0435\u043D\u0442\u0438\u0444\u0438\u043A\u0430\u0442\u043E\u0440 \u043A\u043B\u0438\u0435\u043D\u0442\u0430: {1}%0D%0A\u041F\u0440\u043E\u0434\u0443\u043A\u0442: {2}%0D%0A\u0412\u0435\u0440\u0441\u0438\u044F: {3}%0D%0A\u041B\u043E\u043A\u0430\u043B\u0438\u0437\u0430\u0446\u0438\u044F:  {4}%0D%0A\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430: {5}",
		FeedbackSubject: "\u0418\u0434\u0435\u0438 \u043F\u043E \u0443\u043B\u0443\u0447\u0448\u0435\u043D\u0438\u044E",
		FeedbackEmailBodyTemplate: "body=\u041C\u044B \u0441\u0442\u0440\u0435\u043C\u0438\u043C\u0441\u044F \u043A \u0441\u043E\u0432\u0435\u0440\u0448\u0435\u043D\u0441\u0442\u0432\u0443, \u043F\u043E\u044D\u0442\u043E\u043C\u0443 \u043E\u0447\u0435\u043D\u044C \u0445\u043E\u0442\u0438\u043C \u043F\u043E\u043B\u0443\u0447\u0438\u0442\u044C \u0432\u0430\u0448 \u043E\u0442\u0437\u044B\u0432 \u043E\u0431 \u044D\u0442\u043E\u0439 \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0435! \u0415\u0441\u0442\u044C \u0438\u0434\u0435\u0438, \u0447\u0442\u043E \u043C\u043E\u0436\u043D\u043E \u0431\u044B\u043B\u043E \u0431\u044B \u0443\u043B\u0443\u0447\u0448\u0438\u0442\u044C? \u041D\u0430\u043F\u0438\u0448\u0438\u0442\u0435 \u043D\u0430\u043C! \u0412\u0430\u0448\u0438 \u043F\u043E\u0436\u0435\u043B\u0430\u043D\u0438\u044F \u0438 \u043A\u043E\u043C\u043C\u0435\u043D\u0442\u0430\u0440\u0438\u0438 \u043D\u0435 \u043E\u0441\u0442\u0430\u043D\u0443\u0442\u0441\u044F \u043D\u0435\u0437\u0430\u043C\u0435\u0447\u0435\u043D\u043D\u044B\u043C\u0438.%0D%0A%0D%0A%0D%0A\u0421\u0430\u0439\u0442:  {0}%0D%0A\u0418\u0434\u0435\u043D\u0442\u0438\u0444\u0438\u043A\u0430\u0442\u043E\u0440 \u043A\u043B\u0438\u0435\u043D\u0442\u0430: {1}%0D%0A\u041F\u0440\u043E\u0434\u0443\u043A\u0442: {2}%0D%0A\u0412\u0435\u0440\u0441\u0438\u044F: {3}%0D%0A\u041B\u043E\u043A\u0430\u043B\u0438\u0437\u0430\u0446\u0438\u044F:  {4}%0D%0A\u0421\u0442\u0440\u0430\u043D\u0438\u0446\u0430: {5}",
		AddExternalAccess: "\u041F\u0440\u0435\u0434\u043E\u0441\u0442\u0430\u0432\u0438\u0442\u044C \u0434\u043E\u0441\u0442\u0443\u043F \u043F\u043E\u0434\u0434\u0435\u0440\u0436\u043A\u0435",
		ExternalAccessGrantedMessage: "\u0414\u043E\u0441\u0442\u0443\u043F \u043F\u0440\u0435\u0434\u043E\u0441\u0442\u0430\u0432\u043B\u0435\u043D"
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