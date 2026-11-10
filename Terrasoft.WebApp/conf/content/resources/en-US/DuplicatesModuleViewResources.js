define("DuplicatesModuleViewResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AccountCaption: "Account duplicates",
		ContactCaption: "Contact duplicates",
		GridTitleAccount: "Name",
		GridTitleContact: "Name",
		GridTitleAccountPhone: "Primary phone",
		GridTitleAccountAdditionalPhone: "Alternate phone",
		GridTitleAccountWeb: "Web",
		GridTitleContactMobilePhone: "Mobile phone",
		GridTitleContactHomePhone: "Home phone",
		GridTitleContactEmail: "Email",
		StartCaption: "Start searching",
		StopCaption: "Stop searching",
		ScheduleCaption: "Set up duplicates search parameters",
		MergeButtonCaption: "Merge duplicates",
		NotDuplicatesButtonCaption: "Not duplicates",
		SettingsButtonCaption: "View",
		CancelButtonCaption: "Cancel"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		ImageOpenButton: {
			source: 3,
			params: {
				schemaName: "DuplicatesModuleView",
				resourceItemName: "ImageOpenButton",
				hash: "de93213e4131c0b5b91f465fde41f75a",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});