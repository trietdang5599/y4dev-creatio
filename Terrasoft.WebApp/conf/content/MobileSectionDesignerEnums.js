Terrasoft.configuration.Structures["MobileSectionDesignerEnums"] = {innerHierarchyStack: ["MobileSectionDesignerEnums"]};
define("MobileSectionDesignerEnums", ["MobileSectionDesignerEnumsResources"], function() {

	Ext.ns("Terrasoft.MobileSectionDesignerEnums");

	/**
	 * Mobile base grid settings schema UId.
	 * @enum
	 */
	Terrasoft.MobileSectionDesignerEnums.BaseMobileGridPageSettingsUId = "d95270f5-6b67-444d-83ac-5a1555857650";

	/**
	 * Default modules for new workplace.
	 * @Array
	 */
	Terrasoft.MobileSectionDesignerEnums.DefaultManifestModules = [];

	/**
	 * List of modules that are not configurable.
	 * @Array
	 */
	Terrasoft.MobileSectionDesignerEnums.ModulesCustomizationConfig = {
		SocialMessage: {
			isGridEditable: false,
			isPageEditable: false,
			isDetailEditable: false,
			isFUIEditable: false
		},
		SysDashboard: {
			isGridEditable: false,
			isPageEditable: false,
			isDetailEditable: false,
			isFUIEditable: false
		},
		Approval: {
			isGridEditable: false,
			isPageEditable: false,
			isDetailEditable: false,
			isFUIEditable: false
		},
		Calendar: {
			isGridEditable: false,
			isDetailEditable: false,
			isFUIEditable: false
		}
	};

	/**
	 * List of details that are not configurable.
	 * @Array
	 */
	Terrasoft.MobileSectionDesignerEnums.NotConfigurableDetails = ["SocialMessage", "SysFile"];

	/**
	 * List of non-standard modules.
	 * @enum
	 * Key: module name
	 * Value: module code (from SysModule table)
	 */
	Terrasoft.MobileSectionDesignerEnums.ModuleWithoutSysModuleEntity = {
		SysDashboard: "Dashboard",
		Approval: "Approval"
	};

});


