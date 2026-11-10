define("OsmMapsModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DataWithoutAddresses: "\u0414\u043B\u044F \u0432\u044B\u0431\u0440\u0430\u043D\u043D\u044B\u0445 \u0437\u0430\u043F\u0438\u0441\u0435\u0439 \u043D\u0435 \u0443\u043A\u0430\u0437\u0430\u043D\u044B \u0430\u0434\u0440\u0435\u0441\u0430",
		AddressesFoundPartially: "\u041F\u043E\u043A\u0430\u0437\u0430\u043D\u044B \u043D\u0435 \u0432\u0441\u0435 \u0430\u0434\u0440\u0435\u0441\u0430. \u041D\u0430\u0439\u0434\u0435\u043D\u043E {0} \u0438\u0437 {1}. \u0412\u043E\u0437\u043C\u043E\u0436\u043D\u043E \u0447\u0430\u0441\u0442\u044C \u0430\u0434\u0440\u0435\u0441\u043E\u0432 \u043D\u0435 \u0437\u0430\u043F\u043E\u043B\u043D\u0435\u043D\u0430.",
		AddressesFoundFull: "\u041F\u043E\u043A\u0430\u0437\u0430\u043D\u044B \u0432\u0441\u0435 \u0430\u0434\u0440\u0435\u0441\u0430",
		AddressesNotFound: "\u0412\u044B\u0431\u0440\u0430\u043D\u043D\u044B\u0435 \u0437\u0430\u043F\u0438\u0441\u0438 \u043D\u0435 \u0443\u0434\u0430\u043B\u043E\u0441\u044C \u043E\u0442\u043E\u0431\u0440\u0430\u0437\u0438\u0442\u044C \u0438\u0437-\u0437\u0430 \u043E\u0448\u0438\u0431\u043A\u0438 \u0441\u0435\u0440\u0432\u0438\u0441\u0430 \u043A\u0430\u0440\u0442"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "CloseIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		MarkerIcon: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "MarkerIcon",
				hash: "216f8d7af28b80ea039f0238d5ea57ba",
				resourceItemExtension: ".png"
			}
		},
		MarkerShadow: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "MarkerShadow",
				hash: "065b810729d987692da3136b893c09b0",
				resourceItemExtension: ".png"
			}
		},
		MarkerIcon2x: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "MarkerIcon2x",
				hash: "ee90bf03b7b9065cabcb9d5ecf61c9c6",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});