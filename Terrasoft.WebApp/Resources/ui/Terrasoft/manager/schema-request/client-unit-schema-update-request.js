/**
 */
Ext.define("Terrasoft.data.queries.ClientUnitSchemaUpdateRequest", {
	extend: "Terrasoft.BaseSchemaUpdateRequest",
	alternateClassName: "Terrasoft.ClientUnitSchemaUpdateRequest",

	// region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.SaveBaseSchemaRequest#contractName.
	 * @protected
	 * @override
	 */
	contractName: "ClientUnitSchema",

	//endregion

	/**
	 * @override
	 */
	getData: function() {
		const schema = this.callParent(arguments);
		schema.resources = {};
		schema.getParametersLocalizableValues(schema.resources);
		return schema;
	}

	//endregion

});