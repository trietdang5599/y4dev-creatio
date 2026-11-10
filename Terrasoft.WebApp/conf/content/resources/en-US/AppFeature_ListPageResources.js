define("AppFeature_ListPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		RefreshButtonCaption: "\u0421lear cache",
		Label_u3t55vq_caption: "We recommend changing the status only if Creatio support advises it or you want to test a new feature.",
		Label_4s6loja_caption: "WARNING: changes to feature status can lead to app operation issues.",
		SearchFilter_11or0eq_placeholder: "Search",
		DeleteFeatureFromDbActionCaption: "Delete from DB",
		OpenFeatureActionCaption: "Open",
		Button_ggsjw93_caption: "Refresh",
		RefreshButton_caption: "\u0421lear cache",
		InvalidCode: "Use symbols: a-z, A-Z, 0-9, dot, underscore or dash. Only letters can be first.",
		EmptySectionPlaceholderSubHead: "Add a new record to make it look prettier",
		EmptySectionPlaceholderTitle: "The section has no records",
		FilteredEmptySectionPlaceholderSubHead: "Clear the filter or change its conditions",
		FilteredEmptySectionPlaceholderTitle: "There are no records matching the filter criteria"
	};
	var parametersLocalizableStrings = {};
	var propertiesLocalizableStrings = {
		Caption: "Feature toggling list page"
	};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings, propertiesLocalizableStrings: propertiesLocalizableStrings};
});