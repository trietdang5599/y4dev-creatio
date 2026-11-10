define("PortalMainPageBuilderResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Caption: "Main Page",
		ToolsCaption: "Actions",
		AddButtonCaption: "New",
		EditButtonCaption: "Edit",
		DeleteButtonCaption: "Delete",
		RightsButtonCaption: "Set up access rights",
		DeleteConfirmationMessage: "Are you sure that you want to delete the dashboard panel?",
		NotEnoughRightsMessage: "Insufficient rights to execute this operation",
		NoDashboardsAvailable: "No dashboards available",
		CopyButtonCaption: "Copy",
		ScreenshotButtonCaption: "Screenshot"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Settings: {
			source: 3,
			params: {
				schemaName: "PortalMainPageBuilder",
				resourceItemName: "Settings",
				hash: "a8bd9c465829019c84dc848375c6ce93",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});