/**
 * Aggregated entity schema request class.
 */
Ext.define("Terrasoft.data.queries.AggregatedEntitySchemaRequest", {
	extend: "Terrasoft.BaseSchemaRequest",
	alternateClassName: "Terrasoft.AggregatedEntitySchemaRequest",

	/**
	* The name of the contract object on the server.
	* @type {String}
	*/
	contractName: "AggregatedEntitySchemaRequest",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaRequest#responseClassName.
	 * @protected
	 * @override
	 */
	responseClassName: "Terrasoft.EntitySchemaResponse"

});