/**
 * Represents data of the multi instance schema element.
 */
Ext.define("Terrasoft.manager.ProcessSchemaMultiInstanceOptions", {
	extend: "Terrasoft.manager.MetaItem",
	alternateClassName: "Terrasoft.ProcessSchemaMultiInstanceOptions",

	//region Properties: Public

	/**
	 * Execution mode for multi-instance process element.
	 * @type {Terrasoft.process.enums.MultiInstanceExecutionMode}
	 */
	executionMode: Terrasoft.process.enums.MultiInstanceExecutionMode.SEQUENTIAL,

	/**
	 * Unique identifier of the input collection parameter.
	 * @type {String}
	 */
	inputCollectionParameterUId: null,

	/**
	 * Unique identifier of the output collection parameter.
	 * @type {String}
	 */
	outputCollectionParameterUId: null,

	/**
	 * The option to ignore errors while executing process element.
	 * @type {Boolean}
	 */
	ignoreErrors: false,

	/**
	 * Unique identifier of the completed iterations count parameter.
	 * @type {String}
	 */
	completedIterationsCountParameterUId: null,

	/**
	 * Unique identifier of the terminated iterations count parameter.
	 * @type {String}
	 */
	terminatedIterationsCountParameterUId: null,

	/**
	 * Unique identifier of the total iterations count parameter.
	 * @type {String}
	 */
	totalIterationsCountParameterUId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.manager.MetaItem#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function () {
		const baseSerializableProperties = this.callParent(arguments);
		return Ext.Array.push(baseSerializableProperties, ["executionMode", "ignoreErrors",
			"inputCollectionParameterUId", "outputCollectionParameterUId", "completedIterationsCountParameterUId",
			"terminatedIterationsCountParameterUId", "totalIterationsCountParameterUId"]);
	}

	//endregion

});
