define("OsmMapsModuleResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		DataWithoutAddresses: "Addresses are not specified for the selected records",
		AddressesFoundPartially: "{0} out of {1} addresses found. Some addresses could be missing.",
		AddressesFoundFull: "All addresses found",
		AddressesNotFound: "Selected addresses cannot be found due to the web mapping service error"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		CloseIcon: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "CloseIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		},
		MarkerIcon: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "MarkerIcon",
				hash: "216f8d7af28b80ea039f0238d5ea57ba",
				resourceItemExtension: ".png"
			}
		},
		MarkerShadow: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "MarkerShadow",
				hash: "065b810729d987692da3136b893c09b0",
				resourceItemExtension: ".png"
			}
		},
		MarkerIcon2x: {
			source: 3,
			params: {
				schemaName: "OsmMapsModule",
				resourceItemName: "MarkerIcon2x",
				hash: "ee90bf03b7b9065cabcb9d5ecf61c9c6",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});