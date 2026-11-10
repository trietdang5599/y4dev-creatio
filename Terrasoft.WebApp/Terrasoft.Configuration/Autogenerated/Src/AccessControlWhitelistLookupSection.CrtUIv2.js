 define("AccessControlWhitelistLookupSection", ["ConfigurationGridUtilities"],
	function() {
		return {
			entitySchemaName: "AccessControlWhitelist",
			mixins: {
				ConfigurationGridUtilites: "Terrasoft.ConfigurationGridUtilities"
			},
			attributes: {},
			methods: {
				/**
				 * @inheritdoc Terrasoft.ConfigurationGridUtilites#getCellControlsConfig
				 * @overridden
				 */
				getCellControlsConfig: function() {
					let controlsConfig =
						this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(this, arguments);
					let activeRow = this.getActiveRow();
					if (!(activeRow && activeRow.isNew)) {
						this.Ext.apply(controlsConfig, {
							enabled: false
						});
					}
					return controlsConfig;
				},

				/**
				 * @inheritDoc Terrasoft.BaseSection#isSeparateModeActionsButtonVisible
				 * @overridden
				 */
				isSeparateModeActionsButtonVisible: function () {
					return false;
				},
				/**
				 * @inheritdoc Terrasoft.ConfigurationGridUtilities#activeRowSaved
				 * @override
				 */
				activeRowSaved: function(row, callback, scope) {
					const savedRow = row;
					this.mixins.ConfigurationGridUtilities.activeRowSaved.apply(this, [row, function() {
						callback.call(scope);
						if (savedRow != null) {
							this.reloadGridData();
						}
					}, scope]);
				},
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "activeRowActionCopy"
				},
				{
					"operation": "remove",
					"name": "activeRowActionCard"
				}
			]/**SCHEMA_DIFF*/
		};
	});
