define("EmailMessagePublisherModule", ["BaseMessagePublisherModule"],
		function() {
			Ext.define("Terrasoft.configuration.EmailMessagePublisherModule", {
				extend: "Terrasoft.BaseMessagePublisherModule",
				alternateClassName: "Terrasoft.EmailMessagePublisherModule",

				/**
				 * @inheritdoc Terrasoft.BaseMessagePublisherModule#initSchemaName
				 * @overridden
				 */
				initSchemaName: function() {
					this.schemaName = "EmailMessagePublisherPage";
				},

				/**
				 * @inheritdoc Terrasoft.BaseSchemaModuleV2#render
				 * @overridden
				 */
				render: function (renderTo) {
					if (Ext.isObject(renderTo) && Ext.isEmpty(renderTo.dom) && !Ext.isEmpty(renderTo.el)) {
						var domEl = Ext.getElementById(renderTo.el.id);
						renderTo.dom = domEl;
					}
					this.callParent(arguments);
				}
			});
			return this.Terrasoft.EmailMessagePublisherModule;
		});
