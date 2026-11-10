define("ProcessRemindModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		OKCaption: "OK",
		CancelCaption: "Cancel",
		StepsCaption: "New steps created for the process"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		HideIcon: {
			source: 3,
			params: {
				schemaName: "ProcessRemindModule",
				resourceItemName: "HideIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		ArrowBlue: {
			source: 3,
			params: {
				schemaName: "ProcessRemindModule",
				resourceItemName: "ArrowBlue",
				hash: "3d86909d175e70a32dc0f8f1b3a7f9a3",
				resourceItemExtension: ".png"
			}
		},
		ArrowGray: {
			source: 3,
			params: {
				schemaName: "ProcessRemindModule",
				resourceItemName: "ArrowGray",
				hash: "41b59562bc80c1a2aa1ce6e257552f07",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});