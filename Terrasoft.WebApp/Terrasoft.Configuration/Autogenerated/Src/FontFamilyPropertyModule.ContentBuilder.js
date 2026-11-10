define("FontFamilyPropertyModule", ["LookupUtilities"], function(LookupUtilities) {
	return {
		attributes: {
			/**
			 * Font family.
			 */
			FontFamily: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "save"
			}
		},
		properties: {
			/**
			 * Array of applicable style attributes.
			 */
			workStyles: ["font-family"]
		},
		methods: {
			/**
			 * @private
			 */
			_initFontFamily: function() {
				var styles = this.$Config[this.$PropertyName];
				this.$FontFamily = styles["font-family"];
			},

			/**
			 * Gets ContactFolder lookup config
			 * @protected
			 * @return {object}
			 */
			getFontLookupConfig: function() {
				var config = {
					entitySchemaName: "ContentBuilderFontSet",
					columns: ["Name", "Fonts"],
					hideActions: true,
					settingsButtonVisible: false,
					multiSelect: false
				};
				return config;
			},

			onSelectFontClick: function() {
				var config = this.getFontLookupConfig();
				LookupUtilities.Open(this.sandbox, config, function(args) {
					var collection = args.selectedRows;
					if (collection.getCount() > 0) {
						var selectedItem = collection.getItems()[0];
						this.$FontFamily = selectedItem.Fonts;
					}
				}, this, null, false, false);
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#getPropertyValue
			 * @override
			 */
			getPropertyValue: function() {
				var result = {};
				if (this.$FontFamily) {
					result["font-family"] = this.$FontFamily;
				}
				return result;

			},

			/**
			 * @inheritdoc BaseStylePropertyModule#init
			 * @override
			 */
			initProperty: function() {
				this.callParent();
				this._initFontFamily();
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "FontFamilyPropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "FontFamily",
				"parentName": "FontFamilyPropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.STRING,
					"markerValue": "FontFamily",
					"value": "$FontFamily",
					"labelConfig": {
						"visible": false
					},
					"enabled": false,
					"wrapClass": ["font-input", "style-input", "control-width-15"]
				}
			},
			{
				"operation": "insert",
				"name": "FontFamilyButton",
				"parentName": "FontFamilyPropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"imageConfig": "$Resources.Images.LookupIcon",
					"click": "$onSelectFontClick",
					"classes": {
						"wrapperClass": ["lookup-button"],
						"imageClass": ["lookup-image"]
					}

				}
			}
		]
	};
});
