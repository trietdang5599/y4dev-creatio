/**
 * Request class for GetDesignPackageUId service call.
 */
Ext.define("Terrasoft.core.manager.GetDesignPackageUIdRequest", {
	extend: "Terrasoft.BaseCoreRequest",
	alternateClassName: "Terrasoft.GetDesignPackageUIdRequest",

	//region Properties: Public

	/**
	 * @inheritdoc Terrasoft.core.BaseCoreRequest#serviceName
	 * @override
	 */
	serviceName: "ApplicationPackagesService.svc",

	/**
	 * @inheritdoc Terrasoft.core.BaseCoreRequest#serviceMethod
	 * @override
	 */
	serviceMethod: "GetDesignPackageUId",

	/**
	 * Schema unique identifier to get the package unique identifier for.
	 */
	schemaUId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.schemaUId = this.schemaUId;
		return serializableObject;
	},

	//endregion

	//region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseRequest#validate.
	 * @override
	 */
	validate: function() {
		this.callParent(arguments);
		if (!this.schemaUId || Terrasoft.isEmptyGUID(this.schemaUId)) {
			throw new Terrasoft.NullOrEmptyException({
				argumentName: "schemaUId"
			});
		}
		return true;
	}

	//endregion

});