define("McpServer_ListPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PageTitle_caption: "Published MCP servers",
		AddButton_caption: "New",
		RefreshButton_caption: "Refresh",
		PDS_Name: "Name",
		PDS_Code: "Code",
		PDS_Online: "Online",
		PDS_Description: "Description"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Published MCP servers list page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});