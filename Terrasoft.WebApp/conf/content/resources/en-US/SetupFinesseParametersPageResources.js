define("SetupFinesseParametersPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		HeaderCaption: "Finesse parameters setup",
		DomainCaption: "Finesse server address",
		AgentIdCaption: "Agent Id",
		PasswordCaption: "Password",
		ExtensionCaption: "Extension"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});