define("SectionMenuModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		HomePageTitle: "\u0414\u043E\u043C\u0430\u0448\u043D\u044F\u044F \u0441\u0442\u0440\u0430\u043D\u0438\u0446\u0430"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "SectionMenuModule",
				resourceItemName: "DefaultIcon",
				hash: "c4f6691690d21d32c0fcaf2371cab621",
				resourceItemExtension: ".png"
			}
		},
		DefaultIconSvg: {
			source: 3,
			params: {
				schemaName: "SectionMenuModule",
				resourceItemName: "DefaultIconSvg",
				hash: "4c421e204b17018308c36c5d9105b121",
				resourceItemExtension: ".svg"
			}
		},
		HomePageSidebarImage: {
			source: 3,
			params: {
				schemaName: "SectionMenuModule",
				resourceItemName: "HomePageSidebarImage",
				hash: "e41ea0f3a405d0b9840b1e232d7a24f8",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});