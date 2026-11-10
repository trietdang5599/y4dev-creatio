Ext.ns("Terrasoft.data.queries");

/**
 * Request for data localization changes
 */
Ext.define("Terrasoft.data.queries.UpdateLocalizationQuery", {
	extend: "Terrasoft.UpdateQuery",
	alternateClassName: "Terrasoft.UpdateLocalizationQuery",
	/**
	 * Query type.
	 * @type {Terrasoft.QueryOperationType}
	 */
	operationType: Terrasoft.QueryOperationType.UPDATE_LOCALIZATION,
});