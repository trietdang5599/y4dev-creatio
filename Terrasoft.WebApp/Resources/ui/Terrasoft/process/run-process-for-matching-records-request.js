/**
 * Class that represents request to run process for matching records.
 */
Ext.define("Terrasoft.process.RunProcessForMatchingRecordsRequest", {
	extend: "Terrasoft.BaseRunProcessForEachValueRequest",
	alternateClassName: "Terrasoft.RunProcessForMatchingRecordsRequest",

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "RunProcessForMatchingRecords",

	//endregion

	//region Properties: Public

	/**
	 * Schema name of section entity.
	 */
	entitySchemaName: null,

	/**
	 * Serialized ESQ filter.
	 */
	filterConfig: null,

	/**
	 * Data sorting information.
	 */
	sortingColumns: null,

	/**
	 * Collection of primary column UId values to exclude from selection.
	 */
	primaryColumnValuesToExclude: null,

	//endregion

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function() {
		const config = this.callParent(arguments);
		config.entitySchemaName = this.entitySchemaName;
		config.filterConfig = this.filterConfig;
		config.primaryColumnValuesToExclude = this.primaryColumnValuesToExclude;
		config.sortingColumns = this.sortingColumns;
		return config;
	}

	//endregion

});
