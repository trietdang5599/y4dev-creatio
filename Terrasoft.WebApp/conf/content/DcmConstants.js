Terrasoft.configuration.Structures["DcmConstants"] = {innerHierarchyStack: ["DcmConstants"]};
define("DcmConstants", ["ext-base", "terrasoft", "DcmConstantsResources"], function(Ext, Terrasoft, resources) {
	/**
	 * @class Terrasoft.configuration.DcmConstants
	 * Class DcmConstants contains constants for dcm processes.
	 */
	Ext.define("Terrasoft.configuration.DcmConstants", {
		alternateClassName: "Terrasoft.DcmConstants",
		singleton: true,

		/**
		 * Dcm schema element required type.
		 * @enum
		 */
		ElementRequiredType: {
			NOT_REQUIRED: {
				value: 0,
				displayValue: resources.localizableStrings.NotRequiredTypeCaption
			},
			REQUIRED: {
				value: 1,
				displayValue: resources.localizableStrings.RequiredTypeCaption
			}
		},

		/**
		 * Dcm schema stage transition type.
		 * @enum
		 */
		StageTransitionType: {
			NONE: {
				value: 0,
				displayValue: resources.localizableStrings.NoneStageTransitionTypeCaption
			},
			AFTER_REQUIRED: {
				value: 1,
				displayValue: resources.localizableStrings.AfterRequiredStageTransitionTypeCaption
			},
			AFTER_ALL: {
				value: 2,
				displayValue: resources.localizableStrings.AfterAllStageTransitionTypeCaption
			}
		},

		/**
		 * Dcm schema stage colors.
		 * @enum
		 * @obsolete
		 */
		 StageColors: ["#181818", "#757575", "#FFFFFF", "#D6D6D6",
			"#E00022", "#B41406", "#E67860", "#840D01",
			"#0C8701", "#066800", "#54AA4E", "#073F05",
			"#4D84E2", "#004FD6", "#80A7EB", "#0026BC",
			"#9641A9", "#7848EE", "#B97CD1", "#4F43C2",
			"#02C2A8", "#08857E", "#95DBD8", "#0E5F53",
			"#FFAC07", "#FF8800", "#F9D68D", "#F86700",
			"#FF602E", "#FF4013", "#FFA089", "#D31E0D",
			"#566D83", "#0D2E4E", "#8697A7", "#031225"
		],

		/**
		 * Dcm schema stage colors mapping.
		 * @enum
		 */
		StageColorsMap: [
			{ oldColor: '#000000', newColor: '#181818' },
			{ oldColor: '#999999', newColor: '#757575' },
			{ oldColor: '#DFDFDF', newColor: '#D6D6D6' },
			{ oldColor: '#EF7E63', newColor: '#E00022' },
			{ oldColor: '#C73920', newColor: '#B41406' },
			{ oldColor: '#D2310D', newColor: '#B41406' },
			{ oldColor: '#E06F56', newColor: '#E00022' },
			{ oldColor: '#EBA793', newColor: '#E67860' },
			{ oldColor: '#E99886', newColor: '#E67860' },
			{ oldColor: '#7F2910', newColor: '#840D01' },
			{ oldColor: '#B61303', newColor: '#840D01' },
			{ oldColor: '#85C280', newColor: '#54AA4E' },
			{ oldColor: '#D1E9BD', newColor: '#54AA4E' },
			{ oldColor: '#54AA4D', newColor: '#0C8701' },
			{ oldColor: '#2C6018', newColor: '#073F05' },
			{ oldColor: '#035500', newColor: '#073F05' },
			{ oldColor: '#64B8DF', newColor: '#4D84E2' },
			{ oldColor: '#D4EBF6', newColor: '#80A7EB' },
			{ oldColor: '#286581', newColor: '#0026BC' },
			{ oldColor: '#6483C3', newColor: '#9641A9' },
			{ oldColor: '#B87CCF', newColor: '#9641A9' },
			{ oldColor: '#46639F', newColor: '#7848EE' },
			{ oldColor: '#D1DCF0', newColor: '#B97CD1' },
			{ oldColor: '#D6BEE3', newColor: '#B97CD1' },
			{ oldColor: '#2B467E', newColor: '#4F43C2' },
			{ oldColor: '#5BC8C4', newColor: '#02C2A8' },
			{ oldColor: '#95DBD1', newColor: '#02C2A8' },
			{ oldColor: '#4CA6A3', newColor: '#08857E' },
			{ oldColor: '#00BFA5', newColor: '#08857E' },
			{ oldColor: '#BFE8E7', newColor: '#95DBD8' },
			{ oldColor: '#D3F1ED', newColor: '#95DBD8' },
			{ oldColor: '#327B78', newColor: '#0E5F53' },
			{ oldColor: '#009688', newColor: '#0E5F53' },
			{ oldColor: '#F8D162', newColor: '#FFAC07' },
			{ oldColor: '#D3AE46', newColor: '#FF8800' },
			{ oldColor: '#FBE8B2', newColor: '#F9D68D' },
			{ oldColor: '#A8882E', newColor: '#F86700' },
			{ oldColor: '#FF6534', newColor: '#F86700' },
			{ oldColor: '#FBAD43', newColor: '#FF602E' },
			{ oldColor: '#FF795A', newColor: '#FF602E' },
			{ oldColor: '#CC8930', newColor: '#FF4013' },
			{ oldColor: '#FDD6A1', newColor: '#FFA089' },
			{ oldColor: '#A16A1F', newColor: '#D31E0D' },
			{ oldColor: '#FF1C06', newColor: '#D31E0D' },
			{ oldColor: '#8E8EB7', newColor: '#566D83' },
			{ oldColor: '#5E5684', newColor: '#0D2E4E' },
			{ oldColor: '#E1DEED', newColor: '#8697A7' },
			{ oldColor: '#3C365B', newColor: '#031225' },
			{ oldColor: '#0B8500', newColor: '#066800' },
			{ oldColor: '#309726', newColor: '#066800' },
			{ oldColor: '#589928', newColor: '#066800' },
			{ oldColor: '#8ECB60', newColor: '#0C8701' },
			{ oldColor: '#8A8A8A', newColor: '#757575' },
			{ oldColor: '#2669DC', newColor: '#004FD6' },
			{ oldColor: '#3A8BB1', newColor: '#004FD6' },
			{ oldColor: '#0058EF', newColor: '#004FD6' },
			{ oldColor: '#314D69', newColor: '#0D2E4E' },
		]
	});

	return Terrasoft.DcmConstants;
});


