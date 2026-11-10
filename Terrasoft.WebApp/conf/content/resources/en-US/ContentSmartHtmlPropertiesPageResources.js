define("ContentSmartHtmlPropertiesPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MacrosListLabelCaption: "Macro properties",
		BlankSlateLabel: "\u003Cp\u003EThis element has no macros yet.\u003C/p\u003E\u003Cp\u003ESet up macros to enable modifying the \u0022HTML\u0022 element settings (text, color, etc.) without having to edit HTML code.\u003C/p\u003E\u003Cp\u003ELearn more on the \u003Ca href=\u0022{0}\u0022 data-context-help-code=\u0022ContentRawHtmlProperties\u0022 target=\u0022_blank\u0022\u003EAcademy\u003C/a\u003E\u003C/p\u003E",
		EditButtonCaption: "Edit HTML"
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		BlankSlateImage: {
			source: 3,
			params: {
				schemaName: "ContentSmartHtmlPropertiesPage",
				resourceItemName: "BlankSlateImage",
				hash: "c00c4bddfb9449b6b0a31f74f94c6b29",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});