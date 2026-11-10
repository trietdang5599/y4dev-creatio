Terrasoft.configuration.Structures["ColorMacroListItemViewModel"] = {innerHierarchyStack: ["ColorMacroListItemViewModel"]};
define('ColorMacroListItemViewModelStructure', ['ColorMacroListItemViewModelResources'], function(resources) {return {schemaUId:'d7953f01-828a-4322-b346-f614d9f4077c',schemaCaption: "ColorMacroListItemViewModel", parentSchemaName: "", packageName: "ContentBuilder", schemaName:'ColorMacroListItemViewModel',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
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


