Terrasoft.configuration.Structures["SetupTelephonyParametersPageModule"] = {innerHierarchyStack: ["SetupTelephonyParametersPageModule"]};
define("SetupTelephonyParametersPageModule", ["BaseSchemaModuleV2", "CtiConstants", "CtiBaseHelper"],
		function(BaseSchemaModuleV2, CtiConstants, CtiBaseHelper) {
	/**
	 * @class Terrasoft.configuration.SetupTelephonyParametersPageModule
	 * ##### ######## ######## ########## #########.
	 */
	Ext.define("Terrasoft.configuration.SetupTelephonyParametersPageModule", {
		alternateClassName: "Terrasoft.SetupTelephonyParametersPageModule",
		extend: "Terrasoft.BaseSchemaModule",

		/**
		 * Fallback schema shown when the user has no telephony setup access.
		 * @private
		 * @type {String}
		 */
		licenseDeniedSchemaName: "SetupTelephonyParametersLicenseDeniedPage",

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			callback = callback || function() {};
			if (this.viewModel) {
				this.viewModel.set("Restored", true);
				callback.call(scope);
				return;
			}
			this.schemaBuilder = this.Ext.create("Terrasoft.SchemaBuilder");
			this.initHistoryState();
			Terrasoft.SysSettings.querySysSettingsItem("SysMsgLib", function(sysSettingsValue) {
				var currentSysMsgLibId = sysSettingsValue.value.toLowerCase();
				if (Terrasoft.SysValue.CTI && Terrasoft.SysValue.CTI.sysMsgLibId !== currentSysMsgLibId) {
					Terrasoft.SysValue.CTI.isInitialized = false;
				}
				CtiBaseHelper.queryCtiSettings(function(ctiSettings) {
					CtiBaseHelper.GetUserHasExplicitOperationLicense(
						CtiConstants.TelephonyIntegrationUseOperation, function(hasExplicitLicense) {
							this.schemaName = hasExplicitLicense === true
								? ctiSettings.setupPageSchemaName
								: this.licenseDeniedSchemaName;
							this.generateSchemaStructure(function(viewModelClass, viewConfig) {
								if (this.destroyed) {
									return;
								}
								this.viewModelClass = viewModelClass;
								this.viewConfig = viewConfig;
								var viewModel = this.viewModel = this.createViewModel(viewModelClass);
								if (hasExplicitLicense === true) {
									viewModel.set("sysMsgLibId", ctiSettings.sysMsgLibId);
								}
								viewModel.init(function() {
									if (!this.destroyed) {
										callback.call(scope);
									}
								}, this);
							}, this);
						}, this);
				}.bind(this));
			}, this);
		},

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#render
		 * @overridden
		 */
		render: function() {
			this.callParent(arguments);
			var headerCaption = this.viewModel.get("Resources.Strings.HeaderCaption") ||
				this.viewModel.get("HeaderCaption");
			this.sandbox.publish("ChangeHeaderCaption", {
				caption: headerCaption,
				dataViews: new Terrasoft.Collection()
			});
			this.sandbox.subscribe("NeedHeaderCaption", function() {
				this.sandbox.publish("InitDataViews", {
					caption: headerCaption
				});
			}, this);
		},

		/**
		 * @inheritdoc Terrasoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: function() {
			var sandbox = this.sandbox;
			var state = sandbox.publish("GetHistoryState");
			var currentHash = state.hash;
			var currentState = state.state || {};
			if (currentState.moduleId === sandbox.id) {
				return;
			}
			var newState = Terrasoft.deepClone(currentState);
			newState.moduleId = sandbox.id;
			sandbox.publish("ReplaceHistoryState", {
				stateObj: newState,
				hash: currentHash.historyState,
				silent: true
			});
		}

	});
	return Terrasoft.SetupTelephonyParametersPageModule;
});


