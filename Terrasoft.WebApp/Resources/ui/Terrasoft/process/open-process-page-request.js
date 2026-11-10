/**
 * Class represents request that runs process.
 */
Ext.define("Terrasoft.process.OpenProcessPageRequest", {
	extend: "Terrasoft.BaseProcessRequest",
	alternateClassName: "Terrasoft.OpenProcessPageRequest",

	//region Properties: Protected

	/**
	 * Process identifier.
	 * @protected
	 * @type {String}
	 */
	processId: null,

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "OpenProcessPage",

	//endregion

	//region Constructors: Public

	/**
	 * @inheritdoc Terrasoft.BaseProcessRequest#constructor
	 * @override
	 */
	constructor: function() {
		this.callParent(arguments);
		this.collectExecutionData = false;
		this.publishExecutionData = false;
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
		serializableObject.processId = this.processId;
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
		if (!this.processId || Terrasoft.isEmptyGUID(this.processId)) {
			throw new Terrasoft.NullOrEmptyException({
				argumentName: "processId"
			});
		}
		return true;
	}

	//endregion

});
