define("ActivityCategoryResultEntryDetailV2", [],
	function() {
		return {
			entitySchemaName: "ActivityCategoryResultEntry",

			attributes: {
				"MasterDetailColumnName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "ActivityResult"
				},
				
				"RelatedDetailColumnName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "ActivityCategory"
				},
				
				"LookupEntityName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "ActivityCategory"
				}
			},

			messages: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
