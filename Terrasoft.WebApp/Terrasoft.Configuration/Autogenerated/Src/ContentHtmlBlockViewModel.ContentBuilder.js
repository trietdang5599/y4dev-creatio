define("ContentHtmlBlockViewModel", ["ContentHtmlBlockViewModelResources", "ContentMjBlockViewModel",
		"ContentSmartHtmlElementViewModel", "ContentHtmlBlock"], function(resources) {
	/**
	 * @class Terrasoft.controls.ContentHtmlBlockViewModel
	 */
	Ext.define("Terrasoft.ContentHtmlBlockViewModel", {
		extend: "Terrasoft.ContentMjBlockViewModel",

		/**
		 * @inheritdoc Terrasoft.BaseContentBlockViewModel#className
		 * @override
		 */
		className: "Terrasoft.ContentHtmlBlock",

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#serializableSlicePropertiesCollection
		 * @override
		 */
		serializableSlicePropertiesCollection: ["ItemType"],

		/**
		 * @inheritdoc BaseContentSerializableViewModelMixin#childItemTypes
		 */
		childItemTypes: {
			mjraw: "Terrasoft.ContentSmartHtmlElementViewModel"
		},

		/**
		 * @inheritdoc Terrasoft.BaseViewModel#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * @inheritdoc Terrasoft.BaseContentBlockViewModel#getViewConfig
		 * @override
		 */
		getViewConfig: function() {
			var config = this.callParent(arguments);
			Ext.apply(config, {
				"elementSelectedChange": "$onElementSelected"
			});
			return config;
		},

		/**
		 * @inheritdoc Terrasoft.BaseContentBlockViewModel#getToolsConfig
		 * @override
		 */
		getToolsConfig: function() {
			return [];
		}
	});

	return Terrasoft.ContentHtmlBlockViewModel;
});
