/**
 * Class represents request that runs process.
 */
Ext.define("Terrasoft.process.ExecuteProcessElementRequest", {
	extend: "Terrasoft.BaseProcessRequest",
	alternateClassName: "Terrasoft.ExecuteProcessElementRequest",

	//region Properties: Protected

	/**
	 * Process element unique identifier.
	 * @protected
	 * @type {String}
	 */
	processElementUId: null,

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "ExecProcessElementByUId",

	//endregion

	//region Constructors: Public

	/**
	 * @inheritdoc Terrasoft.BaseProcessRequest#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		this.collectExecutionData = true;
		this.publishExecutionData = true;
	},

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.processElementUId = this.processElementUId;
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
		if (!this.processElementUId || Terrasoft.isEmptyGUID(this.processElementUId)) {
			throw new Terrasoft.NullOrEmptyException({
				argumentName: "processElementUId"
			});
		}
		return true;
	}

	//endregion

});
