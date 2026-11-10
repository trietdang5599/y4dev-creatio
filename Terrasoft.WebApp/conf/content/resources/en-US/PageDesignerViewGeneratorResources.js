define("PageDesignerViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DeleteDetail: "Delete",
		InheritedVisibilityDetailMessage: "Detail visibility is controlled by page logic. For more information, please contact your system administrator."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Edit: {
			source: 3,
			params: {
				schemaName: "PageDesignerViewGenerator",
				resourceItemName: "Edit",
				hash: "504c53444bc9269b355b7d0b8ddc31aa",
				resourceItemExtension: ".png"
			}
		},
		Delete: {
			source: 3,
			params: {
				schemaName: "PageDesignerViewGenerator",
				resourceItemName: "Delete",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		Add: {
			source: 3,
			params: {
				schemaName: "PageDesignerViewGenerator",
				resourceItemName: "Add",
				hash: "6a1a82a3614d2620ae44e09a94b752ec",
				resourceItemExtension: ".png"
			}
		},
		RelatedModuleImage: {
			source: 3,
			params: {
				schemaName: "PageDesignerViewGenerator",
				resourceItemName: "RelatedModuleImage",
				hash: "aec782e1efa10099507b3bad6aed132d",
				resourceItemExtension: ".svg"
			}
		},
		ActionDashboardImage: {
			source: 3,
			params: {
				schemaName: "PageDesignerViewGenerator",
				resourceItemName: "ActionDashboardImage",
				hash: "5cb74bffc9be77d1335f21457b0c4dde",
				resourceItemExtension: ".svg"
			}
		},
		Remove: {
			source: 3,
			params: {
				schemaName: "PageDesignerViewGenerator",
				resourceItemName: "Remove",
				hash: "7ee86697632396f12e22dc2a170d7c0f",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});