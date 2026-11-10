/**
 * Represents data of the performer assignment options for schema element.
 */
Ext.define("Terrasoft.manager.ProcessSchemaPerformerAssignmentOptions", {
	extend: "Terrasoft.manager.MetaItem",
	alternateClassName: "Terrasoft.ProcessSchemaPerformerAssignmentOptions",

	//region Properties: Public

	/**
	 * Assignment type for process element.
	 * @type {Terrasoft.process.enums.AssignmentType}
	 */
	assignmentType: Terrasoft.process.enums.AssignmentType.USER,

	/**
	 * Unique identifier of the performer parameter.
	 * @type {String}
	 */
	performerParameterUId: null,

	/**
	 * Unique identifier of the role parameter.
	 * @type {String}
	 */
	roleParameterUId: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.manager.MetaItem#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		const baseSerializableProperties = this.callParent(arguments);
		return Ext.Array.push(baseSerializableProperties, ["assignmentType", "performerParameterUId",
			"roleParameterUId"]);
	}

	//endregion

});
