define("RightsResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		RightsCaption: "Access rights: ",
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		ReadLabel: "Read",
		EditLabel: "Edit",
		DeleteLabel: "Delete",
		AccessLevelButtonCaption: "Access level",
		AllowRightCaption: "Granted",
		AllowAndGrantRightCaption: "Granted/delegation permitted",
		DenyRightCaption: "Denied",
		DeleteButtonCaption: "Delete",
		UpButtonCaption: "Up",
		DownButtonCaption: "Down",
		GridEmptyCaption: "Rights are not specified",
		AddButtonCaption: "New",
		AddReadRightCaption: "Read access right",
		AddEditRightCaption: "Edit access right",
		AddDeleteRightCaption: "Delete access right",
		NoRightsMessage: "Insufficient rights to execute this operation",
		SaveError: "Unable to save permission settings. Please try again or contact the system administrator to resolve the problem."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		AddIcon: {
			source: 3,
			params: {
				schemaName: "Rights",
				resourceItemName: "AddIcon",
				hash: "f4caaf4a89ab5ba3f05118702505eab9",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});