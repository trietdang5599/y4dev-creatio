 define("AccessControlWhitelistEditPage", [],
	function() {
		return {
			entitySchemaName: "AccessControlWhitelist",
			attributes: {
				"Page": {
					lookupListConfig: {
						filter: function() {
							return this.getSysSchemaFilter();
						}
					}
				}
			},
			methods: {
				getSysSchemaFilter: function () {
					const filters = this.Ext.create("Terrasoft.FilterGroup");
					filters.add("clientUnitSchemaManager", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL,
						"ManagerName",
						"ClientUnitSchemaManager"
					));
					filters.add("notExistingSysSchemaFilter",
						this.Terrasoft.createColumnIsNullFilter(
							">[AccessControlWhitelist:Page:Id].Page"));
					return filters;
				}
			},
			diff: []
		};
	});
