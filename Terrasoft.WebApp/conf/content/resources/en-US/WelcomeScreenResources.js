define("WelcomeScreenResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AcademyButtonCaption: "Go to Academy",
		WelcomeTextStartLabel: "Welcome to ",
		AcademyHintLabel: "Visit Creatio academy to learn more about the system features"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseButtonImage: {
			source: 3,
			params: {
				schemaName: "WelcomeScreen",
				resourceItemName: "CloseButtonImage",
				hash: "3b48759f21e4ab01436c80d1a2f0e793",
				resourceItemExtension: ".png"
			}
		},
		PlayButtonImage: {
			source: 3,
			params: {
				schemaName: "WelcomeScreen",
				resourceItemName: "PlayButtonImage",
				hash: "2bb8124fb358ee28e53464a873f5ff6c",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});