define("LocalizableHelperResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Delete: "Delete",
		Hide: "Hide",
		DownButtonHint: "Move down",
		UpButtonHint: "Move up"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Up: {
			source: 3,
			params: {
				schemaName: "LocalizableHelper",
				resourceItemName: "Up",
				hash: "36466720e8e7f49acb2850d965333e52",
				resourceItemExtension: ".png"
			}
		},
		Down: {
			source: 3,
			params: {
				schemaName: "LocalizableHelper",
				resourceItemName: "Down",
				hash: "9db65746698e3689d2c7ea4b2a139cfa",
				resourceItemExtension: ".png"
			}
		},
		ButtonUp: {
			source: 3,
			params: {
				schemaName: "LocalizableHelper",
				resourceItemName: "ButtonUp",
				hash: "a5398570048158ec4f673c171d1bf21c",
				resourceItemExtension: ".png"
			}
		},
		ButtonDown: {
			source: 3,
			params: {
				schemaName: "LocalizableHelper",
				resourceItemName: "ButtonDown",
				hash: "d30c6ec17472ca6466c45bf8e2459512",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});