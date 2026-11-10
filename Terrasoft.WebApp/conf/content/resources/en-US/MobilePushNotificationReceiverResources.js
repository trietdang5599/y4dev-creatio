define("MobilePushNotificationReceiverResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		PushNotificationReceiver.RecordNotFound: "Cannot display record. It was either deleted or the access rights were changed",
		PushNotificationReceiver.ModuleIsNotAvailable: "Please use the main Creatio application to work with this section",
		PushNotificationReceiver.RecordNotLoaded: "The record is missing. Please synchronize the data with the main Creatio application"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});