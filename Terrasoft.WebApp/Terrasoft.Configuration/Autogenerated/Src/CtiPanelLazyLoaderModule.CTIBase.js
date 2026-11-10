define("CtiPanelLazyLoaderModule", ["BaseSchemaModuleV2", "CtiConstants"], function(BaseSchemaModuleV2,
		CtiConstants) {
	/**
	 * @class Terrasoft.configuration.CtiPanelLazyLoaderModule
	 * CTI panel page class to work with calls.
	 */
	Ext.define("Terrasoft.configuration.CtiPanelLazyLoaderModule", {
		alternateClassName: "Terrasoft.CtiPanelLazyLoaderModule",
		extend: "Terrasoft.BaseSchemaModule",
		mixins: {
			/**
			 * @class Terrasoft.mixins.CustomEventDomMixin Provides methods for publish message by websockets.
			 */
			CustomEvent: "Terrasoft.mixins.CustomEventDomMixin"
		},

		/**
		 * ########## ###### ## ####### ########## ######### ######## ############.
		 * @private
		 * @param {String} sysMsgLibId Identifier of message library.
		 * @return {Terrasoft.EntitySchemaQuery} Select query for User if it has telephony integration enabled.
		 */
		_getMsgUserSettingsSelect: function(sysMsgLibId) {
			var select = Ext.create("Terrasoft.EntitySchemaQuery", {
				rootSchemaName: "SysMsgUserSettings"
			});
			select.addColumn("ConnectionParams");
			select.filters.add("userFilter", Terrasoft.createColumnFilterWithParameter(
				Terrasoft.ComparisonType.EQUAL, "User", Terrasoft.SysValue.CURRENT_USER.value));
			select.filters.add("libFilter", Terrasoft.createColumnFilterWithParameter(
				Terrasoft.ComparisonType.EQUAL, "SysMsgLib", sysMsgLibId));
			return select;
		},

		/**
		 * Check if user has telephony integration enabled for particular library.
		 * @private
		 */
		_initTelephonyIntegrationCheck: function(callback) {
			Terrasoft.SysSettings.querySysSettings([
				"SysMsgLib",],
			function(settings) {
				var sysMsgLib = settings.SysMsgLib;
				if (!sysMsgLib || (sysMsgLib.value === Terrasoft.GUID_EMPTY)) {
					callback(false);
					return;
				}

				this._getMsgUserSettingsSelect(sysMsgLib.value)
					.getEntityCollection(function(response) {
						const collection = response.collection;
						if (response.success && collection && collection.getCount() > 0) {
							this.isTelephonyIntegrationEnabled = true;
							callback(true);
						} else {
							callback(false);
						}
					}, this);
			}, this);
		},

		/**
		 * Checks whether the current user has the explicit CTI operation license.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		_checkTelephonyIntegrationLicense: function(callback) {
			Terrasoft.CtiBaseHelper.GetUserHasExplicitOperationLicense(
				CtiConstants.TelephonyIntegrationUseOperation, callback, this);
		},

		/**
		 * Completes CTI availability resolution and flushes pending callbacks.
		 * @private
		 * @param {Boolean} isCtiAvailable Whether CTI is available for the current user.
		 */
		_completeCtiAvailabilityResolution: function(isCtiAvailable) {
			this.isCtiAvailable = isCtiAvailable;
			this._isCtiAvailabilityResolved = true;
			this._isResolvingCtiAvailability = false;
			var callbacks = this._ctiAvailabilityCallbacks || [];
			this._ctiAvailabilityCallbacks = [];
			Ext.Array.each(callbacks, function(callback) {
				callback(isCtiAvailable);
			});
		},

		/**
		 * Resolves whether CTI can be initialized for the current user.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		_resolveCtiAvailability: function(callback) {
			if (this._isCtiAvailabilityResolved) {
				callback(this.isCtiAvailable === true);
				return;
			}
			this._ctiAvailabilityCallbacks = this._ctiAvailabilityCallbacks || [];
			this._ctiAvailabilityCallbacks.push(callback);
			if (this._isResolvingCtiAvailability) {
				return;
			}
			this._isResolvingCtiAvailability = true;
			this._initTelephonyIntegrationCheck(function(isTelephonyIntegrationEnabled) {
				if (isTelephonyIntegrationEnabled !== true) {
					this._completeCtiAvailabilityResolution(false);
					return;
				}
				this._checkTelephonyIntegrationLicense(function(hasLicense) {
					this._completeCtiAvailabilityResolution(hasLicense === true);
				}.bind(this));
			}.bind(this));
		},

		/**
		 * Initializes CTI custom events once.
		 * @private
		 */
		_initCustomEventSubscription: function() {
			if (this._isCustomEventInitialized) {
				return;
			}
			this._isCustomEventInitialized = true;
			this.mixins.CustomEvent.init.call(this);
			this.mixins.CustomEvent.subscribe.call(this, "CtiLogoutAction")
				.subscribe((async () => {
					var ctiModel = Terrasoft.CtiModel;
					if (ctiModel) {
						await ctiModel.onLogoutActionAsync();
					}
					this.mixins.CustomEvent.publish("CtiLogoutAction");
				}));
		},

		/**
		 * Handles resolved CTI availability in init flow.
		 * @private
		 * @param {Boolean} isCtiAvailable Whether CTI is available for the current user.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		_onCtiAvailabilityResolved: function(isCtiAvailable, callback, scope) {
			this.isTelephonyIntegrationEnabled = isCtiAvailable;
			if (isCtiAvailable === true) {
				this.sandbox.loadModule("CtiPanelModule");
			}
			this._initCustomEventSubscription();
			Ext.callback(callback, scope);
		},

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function (callback, scope) {
			if (!Terrasoft.Features.getIsEnabled("PersistentCtiPanel")) {
				this.callParent([function() {
					this._resolveCtiAvailability(function(isCtiAvailable) {
						this._onCtiAvailabilityResolved(isCtiAvailable, callback, scope);
					}.bind(this));
				}, this]);
			} else {
				this.callParent([function() {
					this._resolveCtiAvailability(function(isCtiAvailable) {
						this._onCtiAvailabilityResolved(isCtiAvailable, callback, scope);
					}.bind(this));
				}, this]);
			}
		},
		

		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "CtiPanelLazyStub";
		},


		/**
		 * @inheritDoc Terrasoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			this._resolveCtiAvailability(function(isCtiAvailable) {
				if (isCtiAvailable === true) {
					this.sandbox.loadModule("CtiPanelModule", {renderTo: "CtiPanelLazyStubContainer"});
				}
			}.bind(this));
		},

		/**
		 * Replaces the last element in the chain of states, if the identifier module is different from the current.
		 * @protected
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn

	});
	return Terrasoft.CtiPanelLazyLoaderModule;
});
