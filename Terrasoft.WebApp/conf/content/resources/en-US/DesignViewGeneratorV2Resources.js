define("DesignViewGeneratorV2Resources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		Change: "Edit",
		Remove: "Delete",
		ChangeWidth: "Change width",
		ChangeHeight: "Change height",
		SortCurrentTab: "Organize current tab",
		CustomizeTab: "Set up tabs",
		ExistingColumn: "Existing column",
		NewColumn: "New column",
		ConfigurationButtonCaption: "Set",
		PlusButtonCaption: "\u002B",
		MinusButtonCaption: "-",
		String: "String",
		Integer: "Integer",
		Fractional: "Decimal",
		Date: "Date",
		Directory: "Lookup",
		Logical: "Boolean",
		Stretch: "Autofit width",
		Detail: "Detail:",
		ModuleCaption: "Module: ",
		ElementPrefix: "Element: "
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		Settings: {
			source: 3,
			params: {
				schemaName: "DesignViewGeneratorV2",
				resourceItemName: "Settings",
				hash: "a8bd9c465829019c84dc848375c6ce93",
				resourceItemExtension: ".png"
			}
		},
		RemoveIcon: {
			source: 3,
			params: {
				schemaName: "DesignViewGeneratorV2",
				resourceItemName: "RemoveIcon",
				hash: "dc8e7c70665657a9a6a6f9f66bcc72e7",
				resourceItemExtension: ".png"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});