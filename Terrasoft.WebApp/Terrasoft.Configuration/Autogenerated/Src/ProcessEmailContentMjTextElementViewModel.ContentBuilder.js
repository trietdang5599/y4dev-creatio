define("ProcessEmailContentMjTextElementViewModel", ["InlineParameterTextEdit",
	"ContentMjTextElementViewModel", "MappingEditMixin"], function() {
		Ext.define("Terrasoft.ContentMjTextElementViewModel", {
			extend: "Terrasoft.ContentMjTextElementViewModel",
			mixins: {
				mappingEditMixin: "Terrasoft.MappingEditMixin"
			},

			/**
			 * User task invoker uid of the mapping page.
			 * @type {String}
			 */
			invokerUId: null,

			/**
			 * @inheritdoc Terrasoft.MappingEditMixin#getInvokerUId
			 * @override
			 */
			getInvokerUId: function() {
				return this.invokerUId;
			},

			/**
			 * @inheritdoc Terrasoft.BaseViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initDesignerType();
			},

			/**
			 * On parameter button click handler.
			 * @protected
			 */
			onParameterButtonClick: function() {
				this.openEmailMappingWindow(this.onModalBoxSave, this);
			},

			/**
			 * On modal box close handler.
			 * @param {Object} parameter Modal box result parameter.
			 * @param {String} parameter.displayValue Display value of the result parameter.
			 * @protected
			 */
			onModalBoxSave: function(parameter) {
				var htmlParameter = Ext.create("Terrasoft.InlineTextEditMacros", {
					value: parameter.value,
					displayValue: parameter.displayValue
				});
				this.set("SelectedText", htmlParameter.toHtml());
			},

			/**
			 * @inheritdoc Terrasoft.ContentElementBaseViewModel#getViewConfig
			 * @override
			 */
			getViewConfig: function() {
				var viewConfig = this.callParent();
				var editorItem = Ext.Array.findBy(viewConfig.items, function(item) {
					return item.className === "Terrasoft.InlineCodeTextEdit";
				}, this);
				Ext.apply(editorItem, {
					"className": "Terrasoft.InlineParameterTextEdit",
					"parameterclick": "$onParameterButtonClick"
				});
				return viewConfig;
			}
		});
	});
