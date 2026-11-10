define("EditDetailViewGeneratorResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddButtonCaption: "New",
		LoadButtonCaption: "Download more",
		RemoveButtonCaption: "Delete"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "EditDetailViewGenerator",
				resourceItemName: "DeleteIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});