/**
 * Aggregated client unit schema request class.
 */
Ext.define("Terrasoft.data.queries.AggregatedClientUnitSchemaRequest", {
	extend: "Terrasoft.BaseSchemaRequest",
	alternateClassName: "Terrasoft.AggregatedClientUnitSchemaRequest",

	/**
  * The name of the contract object on the server.
  * @type {String}
  */
	contractName: "AggregatedClientUnitSchemaRequest",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaRequest#responseClassName.
	 * @protected
	 * @override
	 */
	responseClassName: "Terrasoft.ClientUnitSchemaResponse"

});