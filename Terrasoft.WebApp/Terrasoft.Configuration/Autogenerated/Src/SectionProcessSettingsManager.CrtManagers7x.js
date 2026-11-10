define("SectionProcessSettingsManager", ["BaseProcessSettingsManager", "SectionProcessSettingsManagerItem"],
		function() {
	Ext.define("Terrasoft.SectionProcessSettingsManager", {
		extend: "Terrasoft.BaseProcessSettingsManager",
		alternateClassName: "Terrasoft.SectionProcessSettingsManager",
		singleton: true,

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#itemClassName
		 * @overridden
		 */
		itemClassName: "Terrasoft.SectionProcessSettingsManagerItem",

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "ProcessInModules",

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#additionalColumnNames
		 * @overridden
		 */
		additionalColumnNames : {
			moduleId: "SysModuleId"
		},

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#getSchemaDataName
		 * @overridden
		 */
		getSchemaDataName: function() {
			return "RunProcessFromSections";
		}
	});
	return Terrasoft.SectionProcessSettingsManager;
});
