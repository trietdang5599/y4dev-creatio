define("SspEntitySchemaAccessListEditPage", [],
	function() {
		return {
			entitySchemaName: "VwSysSSPEntitySchemaAccessList",
			attributes: {
				"SysSchema": {
					lookupListConfig: {
						filter: function() {
							return this.getSysSchemaFilter();
						}
					}
				},
				"Name": {
					isRequired: false
				}
			},
			methods: {

				/**
				 * Returns filter for SysSchema column.
				 * @returns {Terrasoft.FilterGroup} SysSchema column filter.
				 */
				getSysSchemaFilter: function () {
					const filters = this.Ext.create("Terrasoft.FilterGroup");
					filters.add("notExtendParent", this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL,
						"ExtendParent",
						0
					));
					filters.add("entitySchemaManager", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL,
						"ManagerName",
						"EntitySchemaManager"
					));
					filters.add("notExistingSysSchemaFilter",
						this.Terrasoft.createColumnIsNullFilter(
							">[VwSysSSPEntitySchemaAccessList:EntitySchemaUId:UId].EntitySchemaUId"));
					return filters;
				}
			},
			diff: []
		};
	});
