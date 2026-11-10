Terrasoft.configuration.Structures["ContentSmartHtmlElementViewModel"] = {innerHierarchyStack: ["ContentSmartHtmlElementViewModel"]};
define("ContentSmartHtmlElementViewModel", ["ContentSmartHtmlElementViewModelResources",
		"ContentElementBaseViewModel"], function(resources) {
	/**
	 * @class Terrasoft.ContentBuilder.ContentSmartHtmlElementViewModel
	 * Smart HTML element view model class.
	 */
	Ext.define("Terrasoft.ContentBuilder.ContentSmartHtmlElementViewModel", {
		extend: "Terrasoft.ContentElementBaseViewModel",
		alternateClassName: "Terrasoft.ContentSmartHtmlElementViewModel",

		/**
		 * Name of view class.
		 * @protected
		 * @type {String}
		 */
		className: "Terrasoft.ContentMjRawElement",

		/**
		 * @inheritdoc Terrasoft.ContentElementBaseViewModel#sanitizedProperties
		 * @overridde
		 */
		 sanitizedProperties: ["HtmlSrc", "Content"],

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType", "Content", "HtmlSrc", "Macros"],

		_onMacrosChanged: function() {
			var macros = Ext.JSON.decode(this.$Macros, true);
			if (macros) {
				this.set("Macros", macros, { silent: true });
				this.replaceMacrosWithValues(macros);
			}
		},

		_prepareHtmlContent: function(sourceHtml) {
			return Terrasoft.sanitizeHTML(sourceHtml);
		},

		/**
		 * Replaces macros in html source.
		 * @protected
		 */
		replaceMacrosWithValues: function(macros) {
			var result = this.$HtmlSrc;
			Terrasoft.each(macros, function(macro) {
				var regex = new RegExp("{{#" + macro.Id + "::.*?#}}", "gm");
				result = result.replace(regex, macro.Value);
			}, this);
			this.$Content = this._prepareHtmlContent(result);
		},

		/**
		 * @inheritdoc Terrasoft.BaseViewModel#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
			this.on("change:Macros", this._onMacrosChanged, this);
		},

		/**
		 * @inheritdoc BaseContentItemViewModel#getPreparedConfigBeforeCreate
		 */
		getPreparedConfigBeforeCreate: function(config) {
			var changedConfig = this.callParent(arguments);
			changedConfig.Macros = config.Macros || [];
			changedConfig.HtmlSrc = config.HtmlSrc || config.Content || "";
			return changedConfig;
		},

		/**
		 * @inheritdoc Terrasoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.un("change:Macros", this._onMacrosChanged, this);
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc Terrasoft.ContentElementBaseViewModel#getViewConfig
		 * @overridden
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"content": "$Content",
				"placeholder": "$Resources.Strings.Placeholder"
			});
			return config;
		},

		/**
		 * Returns config object for element edit page.
		 * @protected
		 * @returns {Object} Element edit page config.
		 */
		getEditConfig: function() {
			var config = {
				ItemType: this.$ItemType,
				HtmlSrc: this.$HtmlSrc,
				Macros: this.$Macros,
				ElementInfo: {
					Type: this.ItemType,
					DesignTimeConfig: {
						Caption: resources.localizableStrings.PropertiesPageCaption
					},
					Settings: {
						schemaName: "ContentSmartHtmlPropertiesPage",
						panelIcon: resources.localizableImages.PropertiesPageIcon,
						contextHelpText: resources.localizableStrings.PropertiesPageContextHelp
					}
				}
			};
			return config;
		}
	});
});


