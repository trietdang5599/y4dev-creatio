define("DetailProcessSettings", ["DetailProcessExecutingDetail"], function() {
	return {
		entitySchemaName: "ProcessInDetails",

		attributes: {
			/**
			 * SysModuleEntityId.
			 */
			"SysDetailEntityId": {
				dataValueType: Terrasoft.DataValueType.GUID,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseProcessSettings#onGetModuleConfigResult
			 * @overridden
			 */
			onGetModuleConfigResult: function(config) {
				var applicationStructureItem = config.applicationStructureItem;
				this.set("SysDetailEntityId", applicationStructureItem.id);
				this.callParent(arguments);
			}
		},
		details: {
			"ProcessExecutingDetail": {
				schemaName: "DetailProcessExecutingDetail",
				entitySchemaName: "ProcessInDetails",
				filter: {
					masterColumn: "SysDetailEntityId",
					detailColumn: "SysDetail"
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"parentName": "BusinessProcessSettings",
				"propertyName": "items",
				"name": "ProcessExecutingDetail",
				"values": {
					"itemType": Terrasoft.ViewItemType.DETAIL
				}
			}
		]
	};
});
