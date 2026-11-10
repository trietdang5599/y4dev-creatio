define("TabPropertiesPageModule", [
		"TabPropertiesPageModuleResources",
		"PageItemPropertiesPageModule"
	],
	function(resources) {
		Ext.define("Terrasoft.TabPropertiesPageModule", {
			extend: "Terrasoft.PageItemPropertiesPageModule",

			messages: {
				/**
				 * @message GetTabConfig
				 */
				"GetTabConfig": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message SaveTabConfig
				 */
				"SaveTabConfig": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				}
			},

			/**
			 * @inheritdoc PageItemPropertiesPageModule#getItemConfigMessageName
			 * @override
			 */
			getItemConfigMessageName: "GetTabConfig",

			/**
			 * @inheritdoc PageItemPropertiesPageModule#saveItemConfigMessageName
			 * @override
			 */
			saveItemConfigMessageName: "SaveTabConfig",

			/**
			 * @inheritdoc BasePropertiesPageModule#getPageItemType
			 * @override
			 */
			getPageItemType: function() {
				return "tab";
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#getPropertiesPageTranslation
			 * @override
			 */
			getPropertiesPageTranslation: function() {
				const baseConfig = this.callParent(arguments);
				const config = {
					"caption": this.resources.localizableStrings.TabModalBoxHeader,
				};
				return Object.assign({}, baseConfig, config);
			},

			/**
			 * @inheritdoc BasePropertiesPageModule#init
			 * @override
			 */
			init: function() {
				this.initResources(resources);
				this.callParent(arguments);
			}

		});
		return Terrasoft.TabPropertiesPageModule;
	});
