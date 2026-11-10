define("EntityColumnLookupPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		NameCaption: "Name",
		SearchButtonCaption: "Search",
		TotalSelectedItemsCounterCaption: "Records selected:",
		SelectAllButtonCaption: "Select all",
		DeselectAllButtonCaption: "Select none"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "EntityColumnLookupPage",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});