  define("ModuleSectionEnums", ["ModuleSectionEnumsResources"], function(resources) {

	Ext.ns("Terrasoft.ModuleSectionEnums");
	 
	/** @enum
	 * Enumeration of background colors of icons with their titles and images.
	 */
	Terrasoft.ModuleSectionEnums.IconBackgroundColors = {		
		"light-green": {
			value: "#71CD1A",
			displayValue: resources.localizableStrings.ColorLightGreen,
			imageConfig: resources.localizableImages.ImageLightGreen
		},
		"green": {
			value: "#00C853",
			displayValue: resources.localizableStrings.ColorGreen,
			imageConfig: resources.localizableImages.ImageGreen
		},
		"dark-green": {
			value: "#22AC14",
			displayValue: resources.localizableStrings.ColorDarkGreen,
			imageConfig: resources.localizableImages.ImageDarkGreen
		},
		"orange": {
			value: "#FFAC07",
			displayValue: resources.localizableStrings.ColorOrange,
			imageConfig: resources.localizableImages.ImageOrange
		},
		"orange-red": {
			value: "#FF8800",
			displayValue: resources.localizableStrings.ColorOrangeRed,
			imageConfig: resources.localizableImages.ImageOrangeRed
		},
		"coral": {
			value: "#F9307F",
			displayValue: resources.localizableStrings.ColorCoral,
			imageConfig: resources.localizableImages.ImageCoral
		},
		"bright-red": {
			value: "#D32F2F",
			displayValue: resources.localizableStrings.ColorBrightRed,
			imageConfig: resources.localizableImages.ImageBrightRed
		},	 
		"red": {
			value: "#FF4013",
			displayValue: resources.localizableStrings.ColorRed,
			imageConfig: resources.localizableImages.ImageRed
		},
		"purple": {
			value: "#B87CCF",
			displayValue: resources.localizableStrings.ColorPurple,
			imageConfig: resources.localizableImages.ImagePurple
		},
		"violet": {
			value: "#7848EE",
			displayValue: resources.localizableStrings.ColorViolet,
			imageConfig: resources.localizableImages.ImageViolet
		},
		"celestial-blue": {
			value: "#0091EA",
			displayValue: resources.localizableStrings.ColorCelestialBlue,
			imageConfig: resources.localizableImages.ImageCelestialBlue
		},
		"blue": {
			value: "#0058EF",
			displayValue: resources.localizableStrings.ColorBlue,
			imageConfig: resources.localizableImages.ImageBlue
		},
		"light-blue": {
			value: "#1F97DB",
			displayValue: resources.localizableStrings.ColorLightBlue,
			imageConfig: resources.localizableImages.ImageLightBlue
		},
		"navy-blue": {
			value: "#4F43C2",
			displayValue: resources.localizableStrings.ColorNavyBlue,
			imageConfig: resources.localizableImages.ImageNavyBlue
		},
		"dark-turquoise": {
			value: "#009688",
			displayValue: resources.localizableStrings.ColorDarkTurquoise,
			imageConfig: resources.localizableImages.ImageDarkTurquoise
		},
		"turquoise": {
			value: "#00BFA5",
			displayValue: resources.localizableStrings.ColorTurquoise,
			imageConfig: resources.localizableImages.ImageTurquoise
		},
	};
	 
	/** @enum
	 * The object of the relationship between hex color and background colors of the series.
	 */
	Terrasoft.ModuleSectionEnums.BackgroundColors = {
		"#71CD1A": Terrasoft.ModuleSectionEnums.IconBackgroundColors["light-green"],	
		"#00C853": Terrasoft.ModuleSectionEnums.IconBackgroundColors["green"],
		"#22AC14": Terrasoft.ModuleSectionEnums.IconBackgroundColors["dark-green"],		
		"#FFAC07": Terrasoft.ModuleSectionEnums.IconBackgroundColors["orange"],		
		"#FF8800": Terrasoft.ModuleSectionEnums.IconBackgroundColors["orange-red"],	
		"#F9307F": Terrasoft.ModuleSectionEnums.IconBackgroundColors["coral"],		
		"#D32F2F": Terrasoft.ModuleSectionEnums.IconBackgroundColors["bright-red"],		
		"#FF4013": Terrasoft.ModuleSectionEnums.IconBackgroundColors["red"],		
		"#B87CCF": Terrasoft.ModuleSectionEnums.IconBackgroundColors["purple"],
		"#7848EE": Terrasoft.ModuleSectionEnums.IconBackgroundColors["violet"],
		"#0091EA": Terrasoft.ModuleSectionEnums.IconBackgroundColors["celestial-blue"],		
		"#0058EF": Terrasoft.ModuleSectionEnums.IconBackgroundColors["blue"],		
		"#1F97DB": Terrasoft.ModuleSectionEnums.IconBackgroundColors["light-blue"],		
		"#4F43C2": Terrasoft.ModuleSectionEnums.IconBackgroundColors["navy-blue"],		
		"#009688": Terrasoft.ModuleSectionEnums.IconBackgroundColors["dark-turquoise"],
		"#00BFA5": Terrasoft.ModuleSectionEnums.IconBackgroundColors["turquoise"],
	};
});
