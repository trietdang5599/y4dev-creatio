/**
 */
Ext.define("Terrasoft.manager.ClientUnitSchemaManagerItem", {
	extend: "Terrasoft.manager.BaseSchemaManagerItem",
	alternateClassName: "Terrasoft.ClientUnitSchemaManagerItem",

	// region Properties: Protected

	/**
	 * The name of the schema instance class.
	 * @protected
	 * @property {String} instanceClassName
	 */
	instanceClassName: "Terrasoft.ClientUnitSchema",

	/**
	 * The class name for the schema selection.
	 * @protected
	 * @property {String} requestClassName
	 */
	requestClassName: "Terrasoft.ClientUnitSchemaRequest",

	/**
	 * Name of the Schema selection class for deletion.
	 * @protected
	 * @type {String}
	 */
	removeRequestClassName: "Terrasoft.ClientUnitSchemaRemoveRequest",

	/**
	 * The name of the schema save request class.
	 * @protected
	 * @type {String}
	 */
	updateRequestClassName: "Terrasoft.ClientUnitSchemaUpdateRequest",

	/**
	 * Unique identifier of base schema.
	 * @protected
	 * @type {String}
	 */
	parentSchemaUId: null,

	/**
	 * Client schema type.
	 * @protected
	 * @type {Terrasoft.SchemaType}
	 */
	schemaType: null,

	//endregion

	//region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManagerItem#save
	 * @override
	 */
	save: function() {
		if (this.isModified() && this.status !== Terrasoft.ModificationStatus.REMOVED) {
			this.checkInstance();
			var instance = this.instance;
			instance.body = Terrasoft.convertEolToUnix(instance.body);
		}
		this.callParent(arguments);
	},

	/**
	 * Logs to console instance body.
	 */
	logInstanceBody: function() {
		if (this.instance) {
			this.warning(this.instance.body);
		}
	},

	//endregion

	// region Methods: Protected

	/**
	 * @inheritdoc Terrasoft.BaseSchemaManagerItem#onAfterSave
	 * @override
	 */
	onAfterSave: function(response) {
		if (response && response.success) {
			this._setNewParametersUpdatedStatus();
		}
		this.callParent(arguments);
	},

	//endregion

	//region Methods: Private

	/**
	 * @private
	 */
	_setNewParametersUpdatedStatus() {
		this.instance.parameters.each((parameter) => {
			if (parameter.status === Terrasoft.ModificationStatus.NEW) {
				parameter.status = Terrasoft.ModificationStatus.UPDATED;
			}
		});
	}

	// endregion

});
