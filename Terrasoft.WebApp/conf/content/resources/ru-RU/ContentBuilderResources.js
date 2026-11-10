define("ContentBuilderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PreviewBlockCaption: "\u0411\u0438\u0431\u043B\u0438\u043E\u0442\u0435\u043A\u0430 \u0431\u043B\u043E\u043A\u043E\u0432",
		SaveButtonCaption: "\u0421\u043E\u0445\u0440\u0430\u043D\u0438\u0442\u044C",
		CancelButtonCaption: "\u041E\u0442\u043C\u0435\u043D\u0430",
		ContentSheetPlaceholder: "\u041F\u0435\u0440\u0435\u0442\u0430\u0449\u0438\u0442\u0435 \u0431\u043B\u043E\u043A \u0441\u044E\u0434\u0430",
		PreviewButtonCaption: "\u041F\u0440\u0435\u0434\u043F\u0440\u043E\u0441\u043C\u043E\u0442\u0440",
		CancelMessage: "\u041E\u0442\u043C\u0435\u043D\u0438\u0442\u044C \u0438\u0437\u043C\u0435\u043D\u0435\u043D\u0438\u044F",
		WidthIncorrectMinValueValidationMessage: "\u041C\u0438\u043D\u0438\u043C\u0443\u043C {0} px",
		DefaultCaption: "\u0414\u0438\u0437\u0430\u0439\u043D\u0435\u0440 \u043A\u043E\u043D\u0442\u0435\u043D\u0442\u0430",
		PxLabelCaption: "px",
		WidthIncorrectMaxValueValidationMessage: "\u041C\u0430\u043A\u0441\u0438\u043C\u0443\u043C {0} px",
		MacroTemplate: "[#{0}#]",
		EmptyMacrosEntityMessage: "\u041D\u0435\u0442 \u043E\u0431\u044C\u0435\u043A\u0442\u0430 \u0434\u043B\u044F \u0432\u044B\u0431\u043E\u0440\u0430 \u043A\u043E\u043B\u043E\u043D\u043A\u0438.",
		SheetPositionCaption: "\u041F\u043E\u043B\u043E\u0436\u0435\u043D\u0438\u0435",
		SheetWidthCaption: "\u0428\u0438\u0440\u0438\u043D\u0430",
		SearchPlaceholder: "\u041F\u043E\u0438\u0441\u043A",
		ElementsGroupCaption: "\u042D\u043B\u0435\u043C\u0435\u043D\u0442\u044B",
		GridElementsLabelCaption: "\u042D\u043B\u0435\u043C\u0435\u043D\u0442\u044B \u0440\u0430\u0437\u043C\u0435\u0442\u043A\u0438",
		UserBlocksGroupCaption: "\u0411\u043B\u043E\u043A\u0438",
		MigrateButtonCaption: "\u041C\u0438\u0433\u0440\u0438\u0440\u043E\u0432\u0430\u0442\u044C",
		ContentBuilderStateErrorMessage: "\u0428\u0430\u0431\u043B\u043E\u043D \u043D\u0435 \u043C\u043E\u0436\u0435\u0442 \u0431\u044B\u0442\u044C \u0441\u043E\u0445\u0440\u0430\u043D\u0435\u043D. \u0412\u043A\u043B\u044E\u0447\u0435\u043D\u0438\u0435 \u0444\u0438\u0447\u0438 \u0022{0}\u0022 \u0432\u043E\u0437\u043E\u0431\u043D\u043E\u0432\u0438\u0442 \u0440\u0435\u0434\u0430\u043A\u0442\u0438\u0440\u043E\u0432\u0430\u043D\u0438\u0435",
		Caption: "\u0428\u0430\u0431\u043B\u043E\u043D",
		SearchUserBlockPlaceholder: "\u0412\u0432\u0435\u0434\u0438\u0442\u0435 \u0438\u043C\u044F \u0431\u043B\u043E\u043A\u0430",
		DeleteUserBlockQuestion: "\u0412\u044B \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u0445\u043E\u0442\u0438\u0442\u0435 \u0443\u0434\u0430\u043B\u0438\u0442\u044C \u0431\u043B\u043E\u043A \u0022{0}\u0022 \u0438\u0437 \u0411\u0438\u0431\u043B\u0438\u043E\u0442\u0435\u043A\u0438 \u0431\u043B\u043E\u043A\u043E\u0432?",
		PropertiesPageCaption: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0430 \u0448\u0430\u0431\u043B\u043E\u043D\u0430",
		PropertiesPageContextHelp: "\u041D\u0430\u0441\u0442\u0440\u043E\u0439\u043A\u0438 \u043F\u043E\u0437\u0432\u043E\u043B\u044F\u044E\u0442 \u0443\u043A\u0430\u0437\u0430\u0442\u044C \u043E\u0431\u0449\u0438\u0435 \u0441\u0442\u0438\u043B\u0438 \u0434\u043B\u044F \u0448\u0430\u0431\u043B\u043E\u043D\u0430. \u003Ca href=\u0022{0}\u0022 data-context-help-code=\u0022ContentTemplateProperties\u0022 target=\u0022_blank\u0022\u003E\u041F\u043E\u0434\u0440\u043E\u0431\u043D\u0435\u0435\u003C/a\u003E"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultBlockImage: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "DefaultBlockImage",
				hash: "a7c2fa85d3678fea73d83d75a3fe5778",
				resourceItemExtension: ".png"
			}
		},
		SheetSettingsButton: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SheetSettingsButton",
				hash: "54b2b0a5d74696111ea5737ffcd6fdb3",
				resourceItemExtension: ".png"
			}
		},
		SettingsButtonIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SettingsButtonIcon",
				hash: "60d54200d901c207568e8f6154229252",
				resourceItemExtension: ".png"
			}
		},
		SearchIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SearchIcon",
				hash: "c0960e5d98faf61a2a5532aba9a8ccd0",
				resourceItemExtension: ".svg"
			}
		},
		SearchUserBlockIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "SearchUserBlockIcon",
				hash: "ef96400dd632c3b0ed257d5c577f05b2",
				resourceItemExtension: ".svg"
			}
		},
		PropertiesPageIcon: {
			source: 3,
			params: {
				schemaName: "ContentBuilder",
				resourceItemName: "PropertiesPageIcon",
				hash: "738d5d03e8b8231882e0338b44d66fbc",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});