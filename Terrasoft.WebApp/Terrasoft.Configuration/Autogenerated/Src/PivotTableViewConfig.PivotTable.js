define("PivotTableViewConfig", ["DashboardListedGridViewConfig", "PivotTable"], function() {
	Ext.define("Terrasoft.PivotTableViewConfig", {
		extend: "Terrasoft.DashboardListedGridViewConfig",		

		/**
		 * @inheritDoc
		 * @override
		 */
		getGridToolsViewConfig: function() {
			return null;
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDashboardGridHeaderItems: function() {
			const gridHeaderItems = this.callParent(arguments);
			return Terrasoft.filter(gridHeaderItems, function(item) {
				return !Ext.isEmpty(item);
			});
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDashboardGridViewConfig: function(moduleId) {
			return {
				"id": Ext.String.format("grid-{0}", moduleId),
				"name": "PivotTable",	
				"className": "Terrasoft.PivotTable",
				"options": {"bindTo": "Options"},
				"itemType": Terrasoft.ViewItemType.COMPONENT,
				"tableId": {"bindTo": "TableId"},
			};
		},
		
	});
	return {};
});
