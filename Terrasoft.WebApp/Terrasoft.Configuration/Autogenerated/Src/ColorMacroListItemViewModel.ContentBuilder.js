define("ColorMacroListItemViewModel", ["BaseMacroListItemViewModel"], function() {
	/**
	 * @class Terrasoft.configuration.ColorMacroListItemViewModel
	 */
	Ext.define("Terrasoft.configuration.ColorMacroListItemViewModel", {
		extend: "Terrasoft.BaseMacroListItemViewModel",
		alternateClassName: "Terrasoft.ColorMacroListItemViewModel",

		/**
		 * @override
		 */
		isEmailMacroButtonVisible: false,

		/**
		 * @inheritdoc BaseMacroListItemViewModel#getMacroInputConfig
		 * @override
		 */
		getMacroInputConfig: function() {
			return [this.getMacroLabelConfig(),
				{
					className: "Terrasoft.ColorButton",
					value: "$Value",
					markerValue: this.getControlMarkerValue(),
					classes: {
						"wrapClasses": ["macro-color-button"]
					},
					menuItemClassName: Terrasoft.MenuItemType.COLOR_PICKER
				}
			];
		}
	});
	return Terrasoft.ColorMacroListItemViewModel;
});
