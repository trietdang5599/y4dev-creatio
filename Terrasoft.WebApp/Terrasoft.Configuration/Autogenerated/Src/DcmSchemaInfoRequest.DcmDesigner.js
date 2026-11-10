define("DcmSchemaInfoRequest", ["ext-base", "terrasoft"], function(Ext, Terrasoft) {
	/**
	 * @class Terrasoft.data.queries.DcmSchemaInfoRequest
	 * Dcm schema info request class.
	 */
	Ext.define("Terrasoft.data.queries.DcmSchemaInfoRequest", {
		extend: "Terrasoft.BaseRequest",
		alternateClassName: "Terrasoft.DcmSchemaInfoRequest",

		//region Properties: Protected

		/**
		 * @inheritdoc Terrasoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "DcmSchemaInfoRequest",

		/**
		 * @inheritdoc Terrasoft.BaseSchemaRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "Terrasoft.BaseResponse",

		/**
		 * Schema identifier.
		 * @type {String}
		 */
		uId: null,

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
		 * @protected
		 * @override
		 */
		getSerializableObject: function(serializableObject) {
			serializableObject.uId = this.uId;
		}

		//endregion

	});

	return Terrasoft.data.queries.DcmSchemaInfoRequest;
});
