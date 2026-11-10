define("ContactSyncSettingsEditResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DefaultIcon: {
			source: 3,
			params: {
				schemaName: "ContactSyncSettingsEdit",
				resourceItemName: "DefaultIcon",
				hash: "e9154c61cddcacd9f3ec93c9e0368425",
				resourceItemExtension: ".png"
			}
		},
		CloseModal: {
			source: 3,
			params: {
				schemaName: "ContactSyncSettingsEdit",
				resourceItemName: "CloseModal",
				hash: "dcb550bb3c4c971235e7bc76e3c4d64d",
				resourceItemExtension: ".png"
			}
		},
		ErrorIcon: {
			source: 3,
			params: {
				schemaName: "ContactSyncSettingsEdit",
				resourceItemName: "ErrorIcon",
				hash: "04a5c38f6c374acc1d1620a916062fbe",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});