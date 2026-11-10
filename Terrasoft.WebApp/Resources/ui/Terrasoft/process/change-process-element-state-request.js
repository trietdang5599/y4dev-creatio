/**
 * Class represents request that changes state of the running process element.
 */
Ext.define("Terrasoft.process.ChangeProcessElementStateRequest", {
	extend: "Terrasoft.BaseProcessRequest",
	alternateClassName: "Terrasoft.ChangeProcessElementStateRequest",

	statics: {
		assignPerformer: function(elementUId, contactId, callback, scope) {
			const request = Ext.create("Terrasoft.ChangeProcessElementStateRequest", {
				elementUId: elementUId,
				performer: {
					contactId: contactId
				},
				technicalActivityValues: {
					Owner: contactId
				}
			});
			request.execute(callback, scope);
		}
	},

	//region Properties: Protected

	/**
	 * @inheritdoc Terrasoft.BaseRequest#contractName
	 * @protected
	 * @override
	 */
	contractName: "ChangeProcessElementState",

	//endregion

	//region Properties: Public

	/**
	 * Identifier of the process element.
	 */
	elementUId: null,

	/**
	 * Represents changes to the process element's performer assignment. Inner properties are:
	 * performer.contactId - Id of new performer contact.
	 * performer.adminRoleId - Id of the administration role to assign user task to.
	 */
	performer: null,

	/**
	 * Represents changed values of the process element's technical activity in key:value format.
	 * @type {Object}
	 */
	technicalActivityValues: null,

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.Serializable#getSerializableObject.
	 * @protected
	 * @override
	 */
	getSerializableObject: function(serializableObject) {
		this.callParent(arguments);
		serializableObject.elementUId = this.elementUId;
		serializableObject.performer = this.performer;
		if (!Terrasoft.isEmptyObject(this.technicalActivityValues)) {
			const valuesArray = [];
			Terrasoft.each(this.technicalActivityValues, function(value, key) {
				valuesArray.push({
					name: key,
					value: value
				});
			}, this);
			serializableObject.technicalActivityValues = valuesArray;
		}
	}

	//endregion

});