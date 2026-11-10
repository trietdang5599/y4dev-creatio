define("EmployeeProfileSchemaResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MobilePhoneCaption: "\u041C\u043E\u0431\u0438\u043B\u044C\u043D\u044B\u0439 \u0442\u0435\u043B\u0435\u0444\u043E\u043D",
		PhoneCaption: "\u0420\u0430\u0431\u043E\u0447\u0438\u0439 \u0442\u0435\u043B\u0435\u0444\u043E\u043D"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BlankSlateIcon: {
			source: 3,
			params: {
				schemaName: "EmployeeProfileSchema",
				resourceItemName: "BlankSlateIcon",
				hash: "ef9d41ccd0910f06a10d5d9674319faa",
				resourceItemExtension: ".svg"
			}
		},
		ClearButton: {
			source: 3,
			params: {
				schemaName: "EmployeeProfileSchema",
				resourceItemName: "ClearButton",
				hash: "d8fd671de0a34cf0dfde9e8f690078b9",
				resourceItemExtension: ".png"
			}
		},
		ProfileIcon: {
			source: 3,
			params: {
				schemaName: "EmployeeProfileSchema",
				resourceItemName: "ProfileIcon",
				hash: "6985edb87f777607967eed9d8070db42",
				resourceItemExtension: ".jpg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});