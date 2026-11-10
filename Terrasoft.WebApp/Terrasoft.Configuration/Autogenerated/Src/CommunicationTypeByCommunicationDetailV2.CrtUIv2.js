define("CommunicationTypeByCommunicationDetailV2", [],
	function() {
		return {
			entitySchemaName: "ComTypebyCommunication",

			attributes: {
				"MasterDetailColumnName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "CommunicationType"
				},
				
				"RelatedDetailColumnName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "Communication"
				},
				
				"LookupEntityName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					value: "Communication"
				}
			},

			messages: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
