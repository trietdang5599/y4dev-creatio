define("AddressDetailResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		AddressCaption: "Address",
		CountryCaption: "Country",
		RegionCaption: "State/province",
		CityCaption: "City",
		ZipCaption: "ZIP/postal code",
		ValidationFailedMessage: "Please, fill in either the \u0022Address\u0022, \u0022Country\u0022 or \u0022City\u0022 field"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		LocationIcon: {
			source: 3,
			params: {
				schemaName: "AddressDetail",
				resourceItemName: "LocationIcon",
				hash: "b41f9a918d64100b96a8618e769d43c5",
				resourceItemExtension: ".png"
			}
		},
		DeleteIcon: {
			source: 3,
			params: {
				schemaName: "AddressDetail",
				resourceItemName: "DeleteIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});