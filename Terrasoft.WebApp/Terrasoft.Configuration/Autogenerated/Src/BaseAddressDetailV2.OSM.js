define("BaseAddressDetailV2", ["AddressHelperV2"], function() {
	return {
		mixins: {
			AddressHelperV2: "Terrasoft.AddressHelperV2"
		},
		methods: {
			/**
			 * Show on map action handler.
			 */
			openShowOnMap: function() {
				var gridData = this.getGridData();
				var selectedRows = this.getSelectedItems();
				var selectedAddresses = [];
				Terrasoft.each(selectedRows, function(rowId) {
					selectedAddresses.push(gridData.get(rowId));
				}, this);
				this.showOnMapAddressesFromDetail(selectedAddresses);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
