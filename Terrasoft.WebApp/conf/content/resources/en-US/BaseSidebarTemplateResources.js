define("BaseSidebarTemplateResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DefaultSidebarTitle: "Title",
		CloseButton_caption: "Close",
		ResizeButton_caption: "Sidebar mode",
		MenuItem_FullscreenMode_caption: "Fullscreen",
		MenuItem_StandardMode_caption: "Default",
		MenuItem_ExpandedMode_caption: "Expanded",
		MenuItem_title_caption: "Sidebar mode"
	};
	var parametersLocalizableStrings = {
		SidebarTitle: "Sidebar title",
		AllowSizeAdjustment: "AllowSizeAdjustment",
		SidebarCode: "SidebarCode"
	};
	var propertiesLocalizableStrings = {
		Caption: "Sidebar page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});