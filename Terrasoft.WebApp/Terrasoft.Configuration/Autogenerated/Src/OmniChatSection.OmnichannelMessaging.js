define("OmniChatSection", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "OmniChat",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "SeparateModeAddRecordButton",
				"values": {
					"visible": false
				}
			},

			{
				"operation": "merge",
				"name": "CombinedModeAddRecordButton",
				"values": {
					"visible": false
				}
			}
		]/**SCHEMA_DIFF*/,
		methods: {

			/**
			 * @inheritdoc BaseSectionV2#initFixedFiltersConfig
			 * @overridden
			 */
			initFixedFiltersConfig: function() {
				var fixedFilterConfig = {
					entitySchema: this.entitySchema,
					filters: [{
						name: "PeriodFilter",
						caption: this.get("Resources.Strings.PeriodFilterCaption"),
						dataValueType: this.Terrasoft.DataValueType.DATE,
						columnName: "CreatedOn",
						startDate: {
							defValue: this.Terrasoft.startOfWeek(new Date())
						},
						dueDate: {
							defValue: this.Terrasoft.endOfWeek(new Date())
						}
					}, {
						name: "Owner",
						caption: this.get("Resources.Strings.OwnerFilterCaption"),
						dataValueType: this.Terrasoft.DataValueType.LOOKUP,
						appendCurrentContactMenuItem: false,
						columnName: "Operator",
						filter: function() {
							var filters = Ext.create("Terrasoft.FilterGroup");
							const employeesFilter = Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
									"SysAdminUnitTypeValue",
									ConfigurationConstants.SysAdminUnit.Type.User);
							filters.addItem(employeesFilter);
							return filters;
						}
					}]
				};
				this.set("FixedFilterConfig", fixedFilterConfig);
			}
		}
	};
});
