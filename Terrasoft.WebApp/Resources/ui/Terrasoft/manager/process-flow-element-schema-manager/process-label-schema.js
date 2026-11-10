Ext.define("Terrasoft.manager.ProcessLabelSchema", {
	extend: "Terrasoft.manager.MetaItem",
	alternateClassName: "Terrasoft.ProcessLabelSchema",

	/**
	 * Node type.
	 * @type {Terrasoft.diagram.UserHandlesConstraint}
	 */
	nodeType: Terrasoft.diagram.UserHandlesConstraint.Label,

	/**
	 * Parent identifier, which is an element of the process.
	 * @type {String}
	 */
	parentUId: null,

	/**
	 * Position by x.
	 * @type {Number}
	 */
	x: null,

	/**
	 * Position by y.
	 * @type {Number}
	 */
	y: null,

	/**
	 * Process label class name.
	 * @protected
	 * @type {String}
	 */
	typeName: "Terrasoft.Core.Process.ProcessSchemaLabel",

	/**
	 * @inheritdoc Terrasoft.manager.BaseSchema#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		const serializableProperties = ["uId", "parentUId", "x", "y", "name", "typeName", "createdInSchemaUId"];
		return serializableProperties;
	},

	/**
	 * Subscribes on changed event.
	 * @param {Function} handler Event handler.
	 * @param {Object} scope Execution context.
	 */
	subscribeOnChangedEvent: function(handler, scope) {
		this.on("changed", handler, scope);
	},

	/**
	 * Unsubscribes on changed event.
	 * @param {Function} handler Event handler.
	 * @param {Object} scope Execution context.
	 */
	unsubscribeOnChangedEvent: function(handler, scope) {
		this.un("changed", handler, scope);
	}

});
