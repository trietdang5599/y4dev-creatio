define("UserProfilePage", ["CtiConstants"],
	function(CtiConstants) {
		return {
			attributes: {
				"CanUseTelephonyIntegration": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				}
			},
			methods: {
				//region Methods: Public

				/**
				 * @inheritdoc Terrasoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initTelephonyIntegrationLicense();
				},

				/**
				 * Resolves explicit telephony integration access for current user.
				 */
				initTelephonyIntegrationLicense: function() {
					Terrasoft.CtiBaseHelper.GetUserHasExplicitOperationLicense(
						CtiConstants.TelephonyIntegrationUseOperation, function(hasLicense) {
							this.set("CanUseTelephonyIntegration", hasLicense === true);
						}, this);
				},

				/**
				 * Opens setup call centre parameters page.
				 */
				setupCallCentreParameters: function() {
					var callCentreParametersModule = "SetupTelephonyParametersPageModule";
					this.sandbox.publish("PushHistoryState", {hash: callCentreParametersModule});
				},

				/**
				 * Determines if call centre settings button is visible.
				 * @return {Boolean}
				 */
				isCallCentreSettingsVisible: function() {
					return !this.get("IsSSP") && this.get("CanUseTelephonyIntegration");
				}

				//endregion
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "callCentreSetup",
					"parentName": "leftTopGroupContainer",
					"propertyName": "items",
					"values": {
						"itemType": Terrasoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.SetupCallCentreParameters"},
						"click": {"bindTo": "setupCallCentreParameters"},
						"classes": {"textClass": "profile-button"},
						"tag": "callCentreSetup",
						"visible": {"bindTo": "isCallCentreSettingsVisible"},
						"markerValue": "callCentreSetup"
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
