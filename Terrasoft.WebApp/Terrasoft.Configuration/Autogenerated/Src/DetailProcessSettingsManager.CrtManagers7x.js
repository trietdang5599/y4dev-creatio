define("DetailProcessSettingsManager", ["BaseProcessSettingsManager", "DetailProcessSettingsManagerItem"],
		function() {
	Ext.define("Terrasoft.DetailProcessSettingsManager", {
		extend: "Terrasoft.BaseProcessSettingsManager",
		alternateClassName: "Terrasoft.DetailProcessSettingsManager",
		singleton: true,

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#itemClassName
		 * @overridden
		 */
		itemClassName: "Terrasoft.DetailProcessSettingsManagerItem",

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "ProcessInDetails",

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#additionalColumnNames
		 * @overridden
		 */
		additionalColumnNames : {
			detailId: "SysDetailId"
		},

		/**
		 * @inheritdoc Terrasoft.BaseProcessSettingsManager#getSchemaDataName
		 * @overridden
		 */
		getSchemaDataName: function() {
			return "RunProcessFromDetails";
		}
	});
	return Terrasoft.DetailProcessSettingsManager;
});
