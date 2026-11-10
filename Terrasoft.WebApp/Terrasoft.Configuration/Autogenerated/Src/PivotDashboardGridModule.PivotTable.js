define("PivotDashboardGridModule", ["DashboardGridModule", "css!DashboardGridModule",
		"PivotTableViewModel", "PivotTableUtilities"],
	function() {

		/**
		 * @class Terrasoft.configuration.PivotDashboardGridModule
		 * Class of dashboard grid module.
		 */
		Ext.define("Terrasoft.configuration.PivotDashboardGridModule", {
			extend: "Terrasoft.DashboardGridModule",
			alternateClassName: "Terrasoft.PivotDashboardGridModule",

			/**
			 * @inheritDoc Terrasoft.BaseModule#init
			 * @override
			 */
			init: function() {
				this.sandbox.registerMessages({
					"GetDashboardGridConfig": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.PUBLISH
					},
					"GenerateDashboardGrid": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},
					"UpdateFilter": {
						mode: Terrasoft.MessageMode.BROADCAST,
						direction: Terrasoft.MessageDirectionType.SUBSCRIBE
					},
					"GetFiltersCollection": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.PUBLISH
					},
					"GetSectionFilterModuleId": {
						mode: Terrasoft.MessageMode.PTP,
						direction: Terrasoft.MessageDirectionType.PUBLISH
					},
					"PushHistoryState": {
						"mode": Terrasoft.MessageMode.BROADCAST,
						"direction": Terrasoft.MessageDirectionType.PUBLISH
					}
				});
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			initConfig: function() {
				this.callParent(arguments);
				if (!this.canRenderPivotTable()) {
					return;
				}
				this.viewModelClassName = "Terrasoft.PivotTableViewModel";
				this.viewConfigClassName = "Terrasoft.PivotTableViewConfig";
			},

			/**
			 * Checks can render pivot table component.
			 * @protected
			 */
			canRenderPivotTable: function() {
				const pivotTableConfig = JSON.parse(this.moduleConfig.pivotTableConfig || "{}");
				const isValidPivotConfig = Terrasoft.PivotTableUtilities
						.validatePivotConfig(pivotTableConfig);
				const isEnabledPivotTable = Terrasoft.PivotTableUtilities.isEnabledPivotTable();
				return isValidPivotConfig && isEnabledPivotTable;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			initViewConfig: function() {
				if (!this.canRenderPivotTable()) {
					this.callParent(arguments);
					return;
				}
				const parentMethod = this.getParentMethod();
				const parentMethodArgs = arguments;
				this._requirePivotViewConfig(parentMethod, this, parentMethodArgs);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getViewModelConfig: function() {
				var config = this.callParent(arguments);
				config.values = config.values || {};
				config.values.TableId = this.renderToId;
				return config;
			},

			_requirePivotViewConfig: function(callback, scope, callbackArgs) {
				Terrasoft.require(["PivotTableViewConfig"], function() {
					Ext.callback(callback, scope || this, callbackArgs);
				}, this);
			}
		});

		return Terrasoft.PivotDashboardGridModule;
	});
