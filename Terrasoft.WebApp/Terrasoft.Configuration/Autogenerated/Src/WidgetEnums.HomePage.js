  define("WidgetEnums", ["WidgetEnumsResources"], function(resources) {

	Ext.ns("Terrasoft.WidgetEnums");

	Terrasoft.WidgetEnums.WidgetColorSet = [
		'burnt-coral',
		'cadmium-red',
		'forest-green',
		'steel-blue',
		'vivid-purple',
		'rusty-orange',
		'dark-turquoise',
		'green',
		'light-blue',
		'celestial-blue',
		'bright-red',
		'orange-red',
		'orange',
		'light-green',
		'turquoise',
		'dark-green',
		'red',
		'coral',
		'purple',
		'violet',
		'blue',
		'navy-blue',
		'dark-blue',
	];

	Terrasoft.WidgetEnums.WidgetColor = {
		"burnt-coral": {
			value: "burnt-coral",
			code: "#BE1B5A",
			displayValue: resources.localizableStrings.StyleBurntCoral,
			imageConfig: resources.localizableImages.ImageBurntCoral
		},
		"cadmium-red": {
			value: "cadmium-red",
			code: "#E23911",
			displayValue: resources.localizableStrings.StyleCadmiumRed,
			imageConfig: resources.localizableImages.ImageCadmiumRed
		},
		"forest-green": {
			value: "forest-green",
			code: "#118F45",
			displayValue: resources.localizableStrings.StyleForestGreen,
			imageConfig: resources.localizableImages.ImageForestGreen
		},
		"steel-blue": {
			value: "steel-blue",
			code: "#057ADD",
			displayValue: resources.localizableStrings.StyleSteelBlue,
			imageConfig: resources.localizableImages.ImageSteelBlue
		},
		"vivid-purple": {
			value: "vivid-purple",
			code: "#A758C5",
			displayValue: resources.localizableStrings.StyleVividPurple,
			imageConfig: resources.localizableImages.ImageVividPurple
		},
		"rusty-orange": {
			value: "rusty-orange",
			code: "#DE5C14",
			displayValue: resources.localizableStrings.StyleRustyOrange,
			imageConfig: resources.localizableImages.ImageRustyOrange
		},
		"dark-turquoise": {
			value: "dark-turquoise",
			code: "#078A7E",
			displayValue: resources.localizableStrings.StyleDarkTurquoise,
			imageConfig: resources.localizableImages.ImageDarkTurquoise
		},
		"green": {
			value: "green",
			code: "#20A959",
			displayValue: resources.localizableStrings.StyleGreen,
			imageConfig: resources.localizableImages.ImageGreen
		},
		"light-blue": {
			value: "light-blue",
			code: "#03A9F4",
			displayValue: resources.localizableStrings.StyleLightBlue,
			imageConfig: resources.localizableImages.ImageLightBlue
		},
		"celestial-blue": {
			value: "celestial-blue",
			code: "#247EE5",
			displayValue: resources.localizableStrings.StyleCelestialBlue,
			imageConfig: resources.localizableImages.ImageCelestialBlue
		},
		"bright-red": {
			value: "bright-red",
			code: "#FF602E",
			displayValue: resources.localizableStrings.StyleBrightRed,
			imageConfig: resources.localizableImages.ImageBrightRed
		},
		"orange-red": {
			value: "orange-red",
			code: "#FF8800",
			displayValue: resources.localizableStrings.StyleOrangeRed,
			imageConfig: resources.localizableImages.ImageOrangeRed
		},
		"orange": {
			value: "orange",
			code: "#FFAC07",
			displayValue: resources.localizableStrings.StyleOrange,
			imageConfig: resources.localizableImages.ImageOrange
		},
		"light-green": {
			value: "light-green",
			code: "#A6DE00",
			displayValue: resources.localizableStrings.StyleLightGreen,
			imageConfig: resources.localizableImages.ImageLightGreen
		},
		"turquoise": {
			value: "turquoise",
			code: "#00BFA5",
			displayValue: resources.localizableStrings.StyleTurquoise,
			imageConfig: resources.localizableImages.ImageTurquoise
		},
		"dark-green": {
			value: "dark-green",
			code: "#22AC14",
			displayValue: resources.localizableStrings.StyleDarkGreen,
			imageConfig: resources.localizableImages.ImageDarkGreen
		},
		"red": {
			value: "red",
			code: "#FF4013",
			displayValue: resources.localizableStrings.StyleRed,
			imageConfig: resources.localizableImages.ImageRed
		},
		"coral": {
			value: "coral",
			code: "#F9307F",
			displayValue: resources.localizableStrings.StyleCoral,
			imageConfig: resources.localizableImages.ImageCoral
		},
		"purple": {
			value: "purple",
			code: "#B87CCF",
			displayValue: resources.localizableStrings.StylePurple,
			imageConfig: resources.localizableImages.ImagePurple
		},
		"violet": {
			value: "violet",
			code: "#7848EE",
			displayValue: resources.localizableStrings.StyleViolet,
			imageConfig: resources.localizableImages.ImageViolet
		},
		"blue": {
			value: "blue",
			code: "#0058EF",
			displayValue: resources.localizableStrings.StyleBlue,
			imageConfig: resources.localizableImages.ImageBlue
		},
		"navy-blue": {
			value: "navy-blue",
			code: "#4F43C2",
			displayValue: resources.localizableStrings.StyleNavyBlue,
			imageConfig: resources.localizableImages.ImageNavyBlue
		},
		"dark-blue": {
			value: "dark-blue",
			code: "#0D2E4E",
			displayValue: resources.localizableStrings.StyleDarkBlue,
			imageConfig: resources.localizableImages.ImageDarkBlue
		},
	};

	Terrasoft.WidgetEnums.WidgetTheme = {
		"full-fill": {
			value: "full-fill",
			displayValue: resources.localizableStrings.FullFillTheme
		},
		"without-fill": {
			value: "without-fill",
			displayValue: resources.localizableStrings.WithoutFillTheme
		},
		"partial-fill": {
			value: "partial-fill",
			displayValue: resources.localizableStrings.PartialFillTheme
		},
		"glassmorphism": {
			value: "glassmorphism",
			displayValue: resources.localizableStrings.GlassmorphismTheme
		},
	};

	Terrasoft.WidgetEnums.TransparentColor =  {
		value: "transparent",
		code: "transparent",
		displayValue: resources.localizableStrings.StyleTransparent,
		imageConfig: resources.localizableImages.ImageTransparent
	};

});
