define("SectionActionsDashboard", ["SspMiniPageUtilities", "SspActivityDashboardItemViewModel"],
	function() {
		return {
			mixins: {
				/**
				 * @class SspMiniPageUtilitiesMixin Provides methods for SSP users minipage usage.
				 */
				SspMiniPageUtilitiesMixin: "Terrasoft.SspMiniPageUtilities"
			},
			methods: {

				//region Methods: Private

				/**
				 * Checks is current user type SSP.
				 * @private
				 * @return {Boolean} True if current user type SSP. Returns false othervise.
				 */
				_isCurrentUserSSP: function() {
					return Terrasoft.isCurrentUserSsp();
				},

				//endregion

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.SectionActionsDashboard#getExtraActionDashboadTabVisible
				 * @overridden
				 */
				getExtraActionDashboadTabVisible: function() {
					return !this._isCurrentUserSSP();
				},

				/**
				 * @inheritdoc Terrasoft.SectionActionsDashboard#getEsnChannelVisible
				 * @overridden
				 */
				getEsnChannelVisible: function() {
					return this.getIsFeatureEnabled("ShowESNOnSSP") || this.callParent(arguments);
				},

				/**
				 * @inheritdoc Terrasoft.SectionActionsDashboard#initDashboardConfig
				 * @override
				 */
				initDashboardConfig: function() {
					this.callParent(arguments);
					const dashboardConfig = this.$DashboardConfig;
					const activityItemsConfig = {
						"Activity": {
							viewModelClassName: "Terrasoft.SspActivityDashboardItemViewModel"
						}
					};
					Ext.merge(dashboardConfig, activityItemsConfig);
					this.$DashboardConfig = dashboardConfig;
				},

				/**
				 * @inheritdoc Terrasoft.SectionActionsDashboard#getTaskEntityStructure
				 * @override
				 */
				getTaskEntityStructure: function() {
					var config = this.callParent(arguments) || {};
					config.hasAddMiniPage = config.hasAddMiniPage || this._isCurrentUserSSP();
					return config;
				},

				/**
				 * @inheritdoc Terrasoft.MiniPageUtilities#getMiniPages
				 * @override
				 */
				getMiniPages: function(entityName) {
					var result = this.callParent(arguments);
					if (Ext.isEmpty(result)) {
						const sspMiniPage = this.getSspMiniPageSchemaName(entityName);
						if (!Ext.isEmpty(sspMiniPage)) {
							result.push(sspMiniPage);
						}
					}
					return result;
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
 