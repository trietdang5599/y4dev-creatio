/**
 * @class Terrasoft.configuration.CardWidgetModuleViewConfig
 */
Ext.define("Terrasoft.configuration.CardWidgetModuleViewConfig", {
	extend: "Terrasoft.BaseObject",
	alternateClassName: "Terrasoft.CardWidgetModuleViewConfig",

	/**
	 * Generates view config.
	 * @param {String} id Root element id.
	 * @returns {Object} View config.
	 */
	generate: function(id) {
		var viewConfig = [];
		var diff = [
			{
				"operation": "insert",
				"name": "CardWidgetContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"id": id,
					"selectors": {"wrapEl": "#" + id},
					"items": []
				}
			}
		];
		return Terrasoft.JsonApplier.applyDiff(viewConfig, diff);
	}

});