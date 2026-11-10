define("BaseLookupPageV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		SelectButtonCaption: "Select",
		CancelButtonCaption: "Cancel",
		ActionButtonCaption: "Actions",
		AddButtonCaption: "New",
		DeleteButtonCaption: "Delete",
		EditButtonCaption: "Edit",
		CopyButtonCaption: "Copy",
		SelectedRecordsLabelCaption: "Records selected",
		SearchButtonCaption: "Search",
		CountSelectedRecord: "Records selected:",
		CaptionLookupPage: "Select: ",
		ViewButtonCaption: "View",
		SortMenuCaption: "Sort by",
		SetupGridMenuCaption: "Columns setup",
		DeleteConfirmationMessage: "Are you sure that you want to delete the selected items?"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "BaseLookupPageV2",
				resourceItemName: "CloseIcon",
				hash: "ade6c37866c12ab6b1044a8de25de514",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});