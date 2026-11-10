define("ProcessSchemaParameterEditModule", ["ProcessMiniEditPageModule"], function() {

	Ext.define("Terrasoft.configuration.ProcessSchemaParameterEditModule", {
		alternateClassName: "Terrasoft.ProcessSchemaParameterEditModule",
		extend: "Terrasoft.ProcessMiniEditPageModule",

		/**
		 * {Object} Current process parameter config.
		 * {Object} parameterEditInfo.parameters Parameter config.
		 * {Object} parameterEditInfo.methods Parameter methods.
		 * @protected
		 */
		parameterEditInfo: null,

		parameterEditConfigs: null,

		/**
		 * @inheritDoc BaseSchemaModule#initHistoryState.
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#isSchemaConfigInitialized
		 * @overridden
		 */
		isSchemaConfigInitialized: false,

		/**
		 * The field allows for the configuration of additional properties for UI controls.
		 * @type {Object|null}
		 */
		options: null,

		/**
		 * @inheritDoc BaseSchemaModule#init.
		 * @overridden
		 */
		init: function() {
			this.onSandboxInitialized();
			this.parameterEditInfo = this.sandbox.publish("GetParameterEditInfo", null, [this.sandbox.id]) || {};
			const result = {};
			this.sandbox.publish("GetProcessSchemaDesignerSettings", result, []);
			this.options = Object.assign({}, result.settings?.processSchemaParameterOptions);
			if(!!result.settings?.newParameterDirection && !!this.parameterEditInfo?.parameters?.IsNew
					&& !this.parameterEditInfo?.parameters?.ParentUId ) {
				this.options.DirectionConfig =
					{ value: result.settings?.newParameterDirection.value };
			}
			this.callParent(arguments);
		},

		onSandboxInitialized: function() {
			const sandbox = this.sandbox;
			sandbox.registerMessages({
				"GetProcessSchemaDesignerSettings": {
					direction: Terrasoft.MessageDirectionType.PUBLISH,
					mode: Terrasoft.MessageMode.BROADCAST
				}
			});
		},

		/**
		 * @inheritDoc BaseSchemaModule#initSchemaName.
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessSchemaParameterEditPage";
		},

		/**
		 * @inheritDoc BaseSchemaModule#getViewModelConfig.
		 * @overridden
		 */
		getViewModelConfig: function() {
			const viewModelConfig = this.callParent(arguments);
			Ext.apply(viewModelConfig, {
				values: {
					...this.parameterEditInfo.parameters,
					...this.options
				},
				methods: this.parameterEditInfo.methods
			});
			return viewModelConfig;
		},

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#getSchemaBuilderConfig
		 * @protected
		 * @overridden
		 */
		getSchemaBuilderConfig: function() {
			const result = this.callParent(arguments);
			return Ext.apply(result, {
				useCache: false
			});
		},

		/**
		 * @inheritDoc BaseSchemaModule#generateSchemaStructure.
		 * @overridden
		 */
		generateSchemaStructure: function(callback, scope) {
			const config = this.getSchemaBuilderConfig();
			this.schemaBuilder.build(config, function(viewModelClass, viewConfig) {
				callback.call(scope, viewModelClass, viewConfig);
			}, this);
		}
	});

	return Terrasoft.ProcessSchemaParameterEditModule;
});
