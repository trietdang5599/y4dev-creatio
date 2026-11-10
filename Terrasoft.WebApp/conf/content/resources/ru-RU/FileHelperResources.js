define("FileHelperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		FileSizeMetrics: "\u041A\u0431",
		AddFileButtonCaption: "\u0414\u043E\u0431\u0430\u0432\u0438\u0442\u044C \u0444\u0430\u0439\u043B"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DocIcon: {
			source: 3,
			params: {
				schemaName: "FileHelper",
				resourceItemName: "DocIcon",
				hash: "6c4cae0c4adac43f19444117f67e168f",
				resourceItemExtension: ".png"
			}
		},
		PdfIcon: {
			source: 3,
			params: {
				schemaName: "FileHelper",
				resourceItemName: "PdfIcon",
				hash: "0b36f3abbf4cfc9ff584dd3fa74fe2da",
				resourceItemExtension: ".png"
			}
		},
		PptIcon: {
			source: 3,
			params: {
				schemaName: "FileHelper",
				resourceItemName: "PptIcon",
				hash: "e14ff42f45b3ae8716661bed6f52bb8f",
				resourceItemExtension: ".png"
			}
		},
		AllIcon: {
			source: 3,
			params: {
				schemaName: "FileHelper",
				resourceItemName: "AllIcon",
				hash: "436d90ab879c04dc5f92bfc11fcad587",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});