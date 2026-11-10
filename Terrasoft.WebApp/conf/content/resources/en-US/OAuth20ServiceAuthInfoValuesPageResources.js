define("OAuth20ServiceAuthInfoValuesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		ApplicationCaption: "Application",
		InvalidApplicationTip: "Please check the settings of the selected application to ensure the correct operation of the web service.\nAll required fields must be populated. A shared user must be added if shared access is used."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		SourceSysSettingImage: {
			source: 3,
			params: {
				schemaName: "OAuth20ServiceAuthInfoValuesPage",
				resourceItemName: "SourceSysSettingImage",
				hash: "9fc13768a28d33a7756447b65f73e9a2",
				resourceItemExtension: ".svg"
			}
		},
		OpenButtonImage: {
			source: 3,
			params: {
				schemaName: "OAuth20ServiceAuthInfoValuesPage",
				resourceItemName: "OpenButtonImage",
				hash: "dbe272c4aa382cf59c0b35a74280c79d",
				resourceItemExtension: ".png"
			}
		},
		AddButtonImage32: {
			source: 3,
			params: {
				schemaName: "OAuth20ServiceAuthInfoValuesPage",
				resourceItemName: "AddButtonImage32",
				hash: "d30933184bec2d3279aaeda342cc0943",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});