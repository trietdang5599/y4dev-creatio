define("CtiBaseHelperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SysMsgLibSettingsEmptyMessage: "The \u0022Message exchange library\u0022 system setting is not set up"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ReadyStatusIcon: {
			source: 3,
			params: {
				schemaName: "CtiBaseHelper",
				resourceItemName: "ReadyStatusIcon",
				hash: "d608e8bfd2605fd11a372e50187cafa9",
				resourceItemExtension: ".png"
			}
		},
		BusyStatusIcon: {
			source: 3,
			params: {
				schemaName: "CtiBaseHelper",
				resourceItemName: "BusyStatusIcon",
				hash: "5ded7fe45fcec0bfea14053d3cfe1301",
				resourceItemExtension: ".png"
			}
		},
		AwayStatusIcon: {
			source: 3,
			params: {
				schemaName: "CtiBaseHelper",
				resourceItemName: "AwayStatusIcon",
				hash: "c4481df272a73a72a532a1daf5414ff7",
				resourceItemExtension: ".png"
			}
		},
		ReadyStatusProfileMenuItemIcon: {
			source: 3,
			params: {
				schemaName: "CtiBaseHelper",
				resourceItemName: "ReadyStatusProfileMenuItemIcon",
				hash: "42c0e230f5a6054282499d08680fa1e3",
				resourceItemExtension: ".png"
			}
		},
		BusyStatusProfileMenuItemIcon: {
			source: 3,
			params: {
				schemaName: "CtiBaseHelper",
				resourceItemName: "BusyStatusProfileMenuItemIcon",
				hash: "b4aeb64a5c53e5f372e044aa14445bcb",
				resourceItemExtension: ".png"
			}
		},
		AwayStatusProfileMenuItemIcon: {
			source: 3,
			params: {
				schemaName: "CtiBaseHelper",
				resourceItemName: "AwayStatusProfileMenuItemIcon",
				hash: "005d89a1a2cc93bc83b620db030ebfd3",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});