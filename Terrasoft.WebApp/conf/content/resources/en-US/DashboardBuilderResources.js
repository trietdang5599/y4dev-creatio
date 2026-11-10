define("DashboardBuilderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Caption: "Dashboards",
		ToolsCaption: "Actions",
		AddButtonCaption: "New",
		EditButtonCaption: "Edit",
		DeleteButtonCaption: "Delete",
		RightsButtonCaption: "Set up access rights",
		DeleteConfirmationMessage: "Are you sure that you want to delete the dashboard panel?",
		NotEnoughRightsMessage: "Insufficient rights to execute this operation",
		NoDashboardsAvailable: "No dashboards available",
		CopyButtonCaption: "Copy",
		SettingsButtonHint: "Actions",
		TabControlScrollLeftHint: "Scroll left",
		TabControlScrollRightHint: "Scroll right",
		ScreenshotButtonCaption: "Screenshot",
		SearchDashboardButtonHint: "Tab search"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Settings: {
			source: 3,
			params: {
				schemaName: "DashboardBuilder",
				resourceItemName: "Settings",
				hash: "a8bd9c465829019c84dc848375c6ce93",
				resourceItemExtension: ".png"
			}
		},
		SearchDashboard: {
			source: 3,
			params: {
				schemaName: "DashboardBuilder",
				resourceItemName: "SearchDashboard",
				hash: "0c97ee376ddf8f0a250b7df3d0788458",
				resourceItemExtension: ".svg"
			}
		},
		Favorite: {
			source: 3,
			params: {
				schemaName: "DashboardBuilder",
				resourceItemName: "Favorite",
				hash: "ff535b8ccd4680fcfddc4b0b2347a2b6",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});