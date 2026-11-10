define("CheckWSConnectionMixinResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		TitlePopup: "Websockets are not working correctly",
		BodyPopup: "Please check your Internet connection and websocket settings.\nFor more information, please see the websockets setup article on the Creatio academy.",
		MoreLinkPopup: "",
		AcademyHelpId: "1631"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		IconPopup: {
			source: 3,
			params: {
				schemaName: "CheckWSConnectionMixin",
				resourceItemName: "IconPopup",
				hash: "36817f513865860e673e4f2490be32ff",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});