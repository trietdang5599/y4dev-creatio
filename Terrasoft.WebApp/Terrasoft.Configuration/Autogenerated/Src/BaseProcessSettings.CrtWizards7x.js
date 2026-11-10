/**
 * Parent: BasePageV2
 */
define("BaseProcessSettings", ["BaseWizardStepSchemaMixin",	"css!BaseProcessSettingsCSS"], function() {
	return {
		entitySchemaName: "ProcessInModules",
		mixins: {
			BaseWizardStepSchemaMixin: "Terrasoft.BaseWizardStepSchemaMixin"
		},
		messages: {
			"getCardInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * PackageUId.
			 */
			"PackageUId": {
				dataValueType: Terrasoft.DataValueType.GUID,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.mixins.BaseWizardStepSchemaMixin.init.call(this, function() {
						this.hideBodyMask();
						Ext.callback(callback, scope);
					}, this);
				}, this]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseWizardStepSchemaMixin#onGetModuleConfigResult
			 * @override
			 */
			onGetModuleConfigResult: function(config, next, scope) {
				this.set("PackageUId", config.packageUId);
				Ext.callback(next, scope);
			},

			/**
			 * @inheritdoc Terrasoft.BaseWizardStepSchemaMixin#onValidate
			 * @override
			 */
			onValidate: function() {
				this.publishValidationResult(true);
			},

			/**
			 * @inheritdoc Terrasoft.BaseWizardStepSchemaMixin#onSave
			 * @override
			 */
			onSave: function() {
				this.publishSavingResult();
			}

			// endregion

		},
		diff: [
			{
				"operation": "remove",
				"name": "CardContentWrapper"
			},
			{
				"operation": "insert",
				"name": "BusinessProcessSettings",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["process-settings-container"]
					},
					"items": []
				}
			}
		]
	};
});
