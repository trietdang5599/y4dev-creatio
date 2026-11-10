/**
 * The client bundle schema request class.
 */
Ext.define("Terrasoft.data.queries.ClientUnitBundleSchemaRequest", {
	extend: "Terrasoft.BaseSchemaRequest",
	alternateClassName: "Terrasoft.ClientUnitBundleSchemaRequest",

	// region Properties: Protected

	/**
	 * The name of the contract object on the server.
	 * @type {String}
	 */
	contractName: "ClientUnitBundleSchemaRequest",

	/**
	 * @inheritdoc Terrasoft.BaseSchemaRequest#responseClassName.
	 * @protected
	 * @override
	 */
	responseClassName: "Terrasoft.ClientUnitSchemaResponse"

	//endregion

});
