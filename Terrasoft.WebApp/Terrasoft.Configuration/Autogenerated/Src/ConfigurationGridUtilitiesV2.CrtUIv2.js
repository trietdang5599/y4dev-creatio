define("ConfigurationGridUtilitiesV2", ["ConfigurationGridUtilities"], function() {

	Ext.define("Terrasoft.configuration.mixins.ConfigurationGridUtilitiesV2", {
		extend: "Terrasoft.ConfigurationGridUtilities",
		alternateClassName: "Terrasoft.ConfigurationGridUtilitiesV2",

		/**
		 * @inheritdoc Terrasoft.ConfigurationGridUtilities#onActiveRowAction
		 * @override
		 */
		onActiveRowAction: function(buttonTag, primaryColumnValue) {
			if (buttonTag === "copy") {
				this.copyRow(primaryColumnValue);
			} else if (buttonTag === "card") {
				const gridData = this.getGridData();
				const row = gridData.get(primaryColumnValue);
				this.saveRowChanges(row, () => {
					this.editRecord(row);
				});
			} else {
				this.callParent(arguments);
			}
		}

	});

	return Ext.create("Terrasoft.ConfigurationGridUtilitiesV2");
});
