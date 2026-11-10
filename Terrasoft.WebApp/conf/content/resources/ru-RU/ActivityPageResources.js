define("ActivityPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		StatusGroupCaption: "\u0421\u043E\u0441\u0442\u043E\u044F\u043D\u0438\u0435",
		RemindingGroupCaption: "\u041D\u0430\u043F\u043E\u043C\u0438\u043D\u0430\u043D\u0438\u044F",
		BoundGroupCaption: "\u0421\u0432\u044F\u0437\u0438",
		StartDateGreaterDueDate: "\u0417\u043D\u0430\u0447\u0435\u043D\u0438\u0435 \u043F\u043E\u043B\u044F \u0022\u041D\u0430\u0447\u0430\u043B\u043E\u0022 \u043D\u0435 \u043C\u043E\u0436\u0435\u0442 \u0431\u044B\u0442\u044C \u0431\u043E\u043B\u044C\u0448\u0435 \u0437\u043D\u0430\u0447\u0435\u043D\u0438\u044F \u043F\u043E\u043B\u044F \u0022\u0417\u0430\u0432\u0435\u0440\u0448\u0435\u043D\u0438\u0435\u0022",
		RemindToOwnerCaption: "\u041E\u0442\u0432\u0435\u0442\u0441\u0442\u0432\u0435\u043D\u043D\u043E\u043C\u0443",
		RemindToAuthorCaption: "\u0410\u0432\u0442\u043E\u0440\u0443",
		ActivityParticipantDetailCaption: "\u0423\u0447\u0430\u0441\u0442\u043D\u0438\u043A\u0438",
		ResultGroupCaption: "\u0420\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442",
		OkResultButtonCaption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		CancelResultButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		DetailedResultCaption: "\u0420\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442 \u043F\u043E\u0434\u0440\u043E\u0431\u043D\u043E"
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