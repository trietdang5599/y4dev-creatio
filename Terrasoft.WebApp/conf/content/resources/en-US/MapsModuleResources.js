define("MapsModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Close: "Close",
		DataWithoutAddresses: "Addresses are not specified for the selected records",
		RouteNotFound: "Unable to create a route",
		RouteFound: "Route found",
		AddressesNotFound: "Selected addresses cannot be found due to the web mapping service error",
		AddressesFoundPartially: "{0} out of {1} addresses found. Some addresses could be missing.",
		BrowserRejectGeolocation: "Your browser does not support geolocation",
		GeolocationServiceFailed: "The Geolocation service failed",
		AddressesFoundFull: "All addresses found"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "MapsModule",
				resourceItemName: "CloseIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});