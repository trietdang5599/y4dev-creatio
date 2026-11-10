 define("HtmlContentExporter", ["ContentBuilderConstants"],
	function() {
		/**
		 * @class Terrasoft.configuration.HtmlContentExporter
		 */
		Ext.define("Terrasoft.configuration.HtmlContentExporter", {
			extend: "Terrasoft.BaseContentExporter",
			alternateClassName: "Terrasoft.HtmlContentExporter",

			/** Type of exported item.
			 * @protected
			 * @type {Object}
			 */
			ExportedItemType: _.assign({}, Terrasoft.ExportedItemType, {
				HTML: Terrasoft.ContentBuilderBodyItemType.mjraw.value,
				BLOCK: "htmlblock"
			}),

			/**
			 * @private
			 */
			_findHtmlElement: function(config) {
				if (!config) {
					throw Ext.create("Terrasoft.NullOrEmptyException");
				}
				if (config.ItemType === this.ExportedItemType.HTML) {
					return config;
				}
				return this._findHtmlElement(config.Items && config.Items[0]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseContentExporter#exportData
			 * @override
			 */
			exportData: function(config) {
				var htmlElement = this._findHtmlElement(config);
				var sanitizedContent = Terrasoft.sanitizeHTML(htmlElement.Content, Terrasoft.sanitizationLevel.HTML);
				return sanitizedContent;
			}
		});
	}
);
