/**
 * @class Terrasoft.services.ServiceNamespace
 */
Ext.define("Terrasoft.services.ServiceNamespace", {
	extend: "Terrasoft.ServiceMetaItem",
	alternateClassName: "Terrasoft.ServiceNamespace",

	//region Properties: Private

	//endregion

	//region Properties: Public

	/**
	 * Namespace prefix.
	 * @type {String}
	 */
	prefix: null,

	/**
	 * Use current namespace as default.
	 * @type {Boolean}
	 */
	isDefault: false,

	//endregion

	//region Methods: Private

	//endregion

	//region Methods: Protected

	/**
	 * @returns {Array}
	 */
	getSerializableProperties: function() {
		return ["uId", "name", "prefix", "isDefault"];
	},

	//endregion

	//region Methods: Public

	/**
	 * @inheritdoc Terrasoft.BaseObject#constructor.
	 * @overridden
	 */
	constructor: function(config) {
		this.callParent(arguments);
	}

	//endregion

});
