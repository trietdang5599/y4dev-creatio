/**
 * Class represents request that runs process.
 */
Ext.define("Terrasoft.process.RunProcessRequest", {
	extend: "Terrasoft.BaseRunProcessRequest",
	alternateClassName: "Terrasoft.RunProcessRequest",

	//region Properties: Protected

	/**
	 * Schema identifier.
	 * @protected
	 * @type {String}
	 */
	schemaUId: null,

	/**
	 * Schema name.
	 * @protected
	 * @type {String}
	 */
	schemaName: null,

	/**
	 * Result parameter names collection.
	 * @protected
	 * @type {Array}
	 */
	resultParameterNames: null,

	/**
	 * Response query class name.
	 * @protected
	 * @type {String}
	 */
	responseClassName: "Terrasoft.RunProcessResponse",

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.ParameterizedProcessRequest#constructor
	 * @override
	 */
	constructor: function(config) {
		this.callParent(arguments);
		this.resultParameterNames = [];
		if (config && config.resultParameterNames) {
			Terrasoft.each(config.resultParameterNames, function(name) {
				this.addResultParameter(name);
			}, this);
		}
	},

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function() {
		const config = this.callParent(arguments);
		config.schemaUId = this.schemaUId;
		config.schemaName = this.schemaName;
		config.resultParameterNames = this.resultParameterNames;
		return config;
	},

	//endregion

	//region Methods: Public

	/**
	 * Adds a result parameter.
	 * @param {String} name Result parameter name to add.
	 */
	addResultParameter: function(name) {
		this.resultParameterNames.push(name);
	},

	/**
	 * @inheritdoc Terrasoft.BaseRequest#validate.
	 * @override
	 */
	validate: function() {
		this.callParent(arguments);
		if (Ext.isEmpty(this.schemaUId) && Ext.isEmpty(this.schemaName)) {
			throw new Terrasoft.NullOrEmptyException({
				argumentName: "schemaName and schemaUId"
			});
		}
		if (Terrasoft.isEmptyGUID(this.schemaUId)) {
			throw new Terrasoft.NullOrEmptyException({
				argumentName: "schemaUId"
			});
		}
		return true;
	}

	//endregion

});
