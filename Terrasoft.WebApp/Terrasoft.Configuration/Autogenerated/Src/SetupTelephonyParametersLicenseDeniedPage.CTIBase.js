define("SetupTelephonyParametersLicenseDeniedPage", ["CtiConstants"], function(CtiConstants) {
	return {
		attributes: {
			"HeaderCaption": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": "Call center setup"
			},
			"LicenseWarningMessage": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": ""
			}
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BaseViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.set("LicenseWarningMessage", Ext.String.format(
						CtiConstants.LocalizableStrings.LicenseNotFoundMessage,
						CtiConstants.TelephonyIntegrationUseOperation));
					Ext.callback(callback, scope || this);
				}.bind(this), this]);
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "setupTelephonyParametersLicenseDeniedContainer",
				"propertyName": "items",
				"values": {
					"id": "setupTelephonyParametersLicenseDeniedContainer",
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["setup-call-centre-parameters-container"],
					"items": [
						{
							"id": "setupTelephonyParametersLicenseDeniedMessage",
							"itemType": Terrasoft.ViewItemType.LABEL,
							"caption": {"bindTo": "LicenseWarningMessage"},
							"classes": {
								"labelClass": ["t-label-is-text-selectable"]
							}
						}
					]
				}
			}
		]
	};
});
