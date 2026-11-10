define("DetailProcessSettingsManagerItem", ["BaseProcessSettingsManagerItem"], function() {
	Ext.define("Terrasoft.DetailProcessSettingsManagerItem", {
		extend: "Terrasoft.BaseProcessSettingsManagerItem",
		alternateClassName: "Terrasoft.DetailProcessSettingsManagerItem",

		/**
		 * Section.
		 * @private
		 * @type {Object}
		 */
		detailId: null,

		/**
		 * @inheritdoc BaseProcessSettingsManagerItem#getProcessRunnerId
		 * @overridden
		 */
		getProcessRunnerId: function() {
			var result = this.getPropertyValue("detailId");
			if (Ext.isEmpty(result) && this.dataManagerItem) {
				var lookup = this.dataManagerItem.getColumnValue("SysDetail");
				result = lookup.value;
			}
			return result;
		},

		/**
		 * @inheritdoc BaseProcessSettingsManagerItem#setProcessRunnerId
		 * @overridden
		 */
		setProcessRunnerId: function(value) {
			this.setPropertyValue("detailId", value);
			this.dataManagerItem.setColumnValue("SysDetail", {
				value: value
			});
		}
	});
	return Terrasoft.DetailProcessSettingsManagerItem;
});
