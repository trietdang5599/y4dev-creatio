define("ContentSmartHtmlEditPageResources", ["terrasoft"], function(Terrasoft) {
	var localizableStrings = {
		MacrosListCaption: "Right click in HTML editor allows to define macro field or reuse already created macro.",
		MacrosContainerCaption: "Macro constructor",
		EditPageCaption: "HTML element configuration",
		SaveButtonCaption: "Save",
		CancelButtonCaption: "Cancel",
		EditedMacroNameCaption: "Title",
		EditedMacroValueCaption: "Value",
		EditedMacroDescriptionCaption: "Description",
		BlankSlateLabel: "\u003Cp\u003EMacro fields were not set yet.\u003C/p\u003E\u003Cbr/\u003E\u003Cp class=\u0022info\u0022\u003EThis element allow to define fields for value insert into custom HTML code.\u003C/p\u003E\u003Cp class=\u0022info\u0022\u003ELearn more on \u003Ca href=\u0022{0}\u0022 data-context-help-code=\u0022ContentRawHtmlProperties\u0022 target=\u0022_blank\u0022\u003EAcademy\u003C/a\u003E\u003C/p\u003E",
		WrongNameMessage: "Invalid name",
		StringMacroMenuItemCaption: "New String",
		TextMacroMenuItemCaption: "New Text",
		PictureMacroMenuItemCaption: "New Picture",
		ColorMacroMenuItemCaption: "New Color",
		NewMacroDefaultName: "New macro",
		AnnotationsLabel: "HTML couldn\u0027t be saved. Errors: {0}",
		AnnotationsNextCaption: "Next",
		AnnotationsPreviousCaption: "Previous",
		AnnotationsTip: "HTML couldn\u0027t be saved with errors (\u003Cb class=\u0022ace_gutter-cell ace_error\u0022 style=\u0022padding:0;display:inline-block;width:19px;height:16px;vertical-align:middle;\u0022\u003E\u003C/b\u003E). Error details can be obtained by hovering over the error icon in the code editor.\nWarnings (\u003Cb class=\u0022ace_gutter-cell ace_warning\u0022 style=\u0022padding:0;display:inline-block;width:19px;height:16px;vertical-align:middle;\u0022\u003E\u003C/b\u003E) do not affect on save validation."
	};
	var parametersLocalizableStrings = {};
	var localizableImages = {
		MacrosCollectionBlankSlate: {
			source: 3,
			params: {
				schemaName: "ContentSmartHtmlEditPage",
				resourceItemName: "MacrosCollectionBlankSlate",
				hash: "c00c4bddfb9449b6b0a31f74f94c6b29",
				resourceItemExtension: ".svg"
			}
		},
		TextMacroImage: {
			source: 3,
			params: {
				schemaName: "ContentSmartHtmlEditPage",
				resourceItemName: "TextMacroImage",
				hash: "e5c2420b9c9528ecc00734f3b418f051",
				resourceItemExtension: ".svg"
			}
		},
		PictureMacroImage: {
			source: 3,
			params: {
				schemaName: "ContentSmartHtmlEditPage",
				resourceItemName: "PictureMacroImage",
				hash: "1d74e760f05e2c3c3d259a47b6020805",
				resourceItemExtension: ".svg"
			}
		}
	};
	return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});