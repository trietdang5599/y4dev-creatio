Terrasoft.configuration.Structures["MobileDesignerEnums"] = {innerHierarchyStack: ["MobileDesignerEnums"]};
define('MobileDesignerEnumsStructure', ['MobileDesignerEnumsResources'], function(resources) {return {schemaUId:'f086312e-236d-415e-a921-ca6fc35a61ef',schemaCaption: "Enumerations - Mobile application designers", parentSchemaName: "", packageName: "CrtMobileDesignerTools7x", schemaName:'MobileDesignerEnums',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("MobileDesignerEnums", ["MobileDesignerEnumsResources"], function() {

	Ext.ns("Terrasoft.MobileDesignerEnums");

	/**
	 * Mobile page settings types.
	 * @enum
	 */
	Terrasoft.MobileDesignerEnums.SettingsType = {
		GridPage: "GridPage",
		RecordPage: "RecordPage",
		Actions: "Actions"
	};

	/**
	 * Embedded detail types.
	 * @enum
	 */
	Terrasoft.MobileDesignerEnums.EmbeddedDetailType = {
		File: "File",
		Visa: "Visa"
	};

	/**
	 * Column view types.
	 * @enum
	 */
	Terrasoft.MobileDesignerEnums.ColumnViewType = {
		Preview: "preview",
		Map: "map",
		Url: "url",
		Phone: "phone",
		Email: "email",
		File: "file",
		Normal: "normal"
	};

	/**
	 * Business rule types.
	 */
	Terrasoft.MobileDesignerEnums.BusinessRuleTypes = {
		Requirement: "Terrasoft.RequirementRule",
		Activation: "Terrasoft.ActivationRule",
		Visibility: "Terrasoft.VisibilityRule",
		MutualFiltration: "Terrasoft.MutualFiltrationRule",
		Filtration: "Terrasoft.FiltrationRule",
		Comparison: "Terrasoft.ComparisonRule",
		RegExp: "Terrasoft.RegExpRule",
		Custom: "Terrasoft.CustomRule",
		FileAndLinksBusinessRule: "Terrasoft.FileAndLinksBusinessRule"
	};

	/**
	 * Business rule events.
	 */
	Terrasoft.MobileDesignerEnums.BusinessRuleEvents = {
		Save: "save",
		ValueChanged: "valuechanged",
		Load: "load"
	};

	/**
	 * Mobile workplace types.
	 */
	Terrasoft.MobileDesignerEnums.WorkplaceType = {
		Portal: "111c7ff1-8224-45b0-a24e-fcc983fc0c70",
		General: "000A9225-728B-4778-A951-C42439FFE024"
	};

});


