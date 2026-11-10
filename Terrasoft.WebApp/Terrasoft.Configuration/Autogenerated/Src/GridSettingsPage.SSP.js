define("GridSettingsPage", ["SSPGridMixin"], function () {
	return {

		mixins: {
			/**
			 * Provides methods for grid handling in ssp sections.
			 */
			"SSPGridMixin": "Terrasoft.SSPGridMixin"
		},

		methods: {

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.GridSettingsPage#initGridSettingsParams
			 * @overridden
			 */
			initGridSettingsParams: function () {
				this.callParent(arguments);
				if (this.Terrasoft.isCurrentUserSsp()) {
					let gridSettingsInfo = this.sandbox.publish("GetGridSettingsInfo", null, [this.sandbox.id]);
					if (!this.Ext.isEmpty(gridSettingsInfo) && this.getIsFeatureEnabled("PortalColumnConfig")
						&& this.getIsFeatureDisabled("UseColumnReadPermissionsForStructureExplorer7x")) {
						this.applyPortalGridSettingsInfo(gridSettingsInfo);
						this.useBackwards = gridSettingsInfo.useBackwards;
						this.firstColumnsOnly = gridSettingsInfo.firstColumnsOnly;
					}
				}
			}

			// endregion

		},
		diff: []
	};
});
