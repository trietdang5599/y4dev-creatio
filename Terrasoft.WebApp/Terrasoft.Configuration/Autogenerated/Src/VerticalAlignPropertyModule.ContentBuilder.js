 define("VerticalAlignPropertyModule", function() {
	return {
		attributes: {
			/**
			 * Vertical align value.
			 */
			VerticalAlign: {
				dataValueType: Terrasoft.core.enums.DataValueType.STRING,
				type: Terrasoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "save"
			}
		},
		properties: {
			/**
			 * Array of applicable style attributes.
			 */
			workStyles: ["vertical-align"]
		},
		methods: {
			/**
			 * @private
			 */
			_initVerticalAlign: function() {
				var propertyValue = this.$Config[this.$PropertyName];
				var value = Ext.isObject(propertyValue) ? propertyValue["vertical-align"] : propertyValue;
				this.$VerticalAlign = value || Terrasoft.Valign.TOP;
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#getPropertyValue
			 * @override
			 */
			getPropertyValue: function() {
				return Ext.isObject(this.$Config[this.$PropertyName])
					? { "vertical-align": this.$VerticalAlign }
					: this.$VerticalAlign;
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#init
			 * @override
			 */
			initProperty: function() {
				this.callParent();
				this._initVerticalAlign();
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "VerticalAlign",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": Terrasoft.ViewItemType.RADIO_GROUP,
					"value": "$VerticalAlign",
					"wrapClass": ["sheet-position-control-group-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "TopAlign",
				"parentName": "VerticalAlign",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"labelConfig": {"visible": false},
					"markerValue": "TopAlign",
					"value": Terrasoft.Valign.TOP,
					"classes": {
						"wrapClass": ["block-valign block-valign-top"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "MiddleAlign",
				"parentName": "VerticalAlign",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"labelConfig": {"visible": false},
					"markerValue": "MiddleAlign",
					"value": Terrasoft.Valign.MIDDLE,
					"classes": {
						"wrapClass": ["block-valign block-valign-middle"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "BottomAlign",
				"parentName": "VerticalAlign",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"labelConfig": {"visible": false},
					"markerValue": "BottomAlign",
					"value": Terrasoft.Valign.BOTTOM,
					"classes": {
						"wrapClass": ["block-valign block-valign-bottom"]
					}
				}
			}
		]
	};
});
