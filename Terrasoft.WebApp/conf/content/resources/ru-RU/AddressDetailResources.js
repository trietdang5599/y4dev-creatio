define("AddressDetailResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddressCaption: "\u0410\u0434\u0440\u0435\u0441",
		CountryCaption: "\u0421\u0442\u0440\u0430\u043D\u0430",
		RegionCaption: "\u041E\u0431\u043B\u0430\u0441\u0442\u044C",
		CityCaption: "\u0413\u043E\u0440\u043E\u0434",
		ZipCaption: "\u0418\u043D\u0434\u0435\u043A\u0441",
		ValidationFailedMessage: "\u0417\u0430\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u0435 \u043E\u0434\u043D\u043E\u0433\u043E \u0438\u0437 \u043F\u043E\u043B\u0435\u0439 \u0022\u0410\u0434\u0440\u0435\u0441\u0022, \u0022\u0421\u0442\u0440\u0430\u043D\u0430\u0022 \u0438\u043B\u0438 \u0022\u0413\u043E\u0440\u043E\u0434\u0022 \u044F\u0432\u043B\u044F\u0435\u0442\u0441\u044F \u043E\u0431\u044F\u0437\u0430\u0442\u0435\u043B\u044C\u043D\u044B\u043C"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		LocationIcon: {
			source: 3,
			params: {
				schemaName: "AddressDetail",
				resourceItemName: "LocationIcon",
				hash: "b41f9a918d64100b96a8618e769d43c5",
				resourceItemExtension: ".png"
			}
		},
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "AddressDetail",
				resourceItemName: "DeleteIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});