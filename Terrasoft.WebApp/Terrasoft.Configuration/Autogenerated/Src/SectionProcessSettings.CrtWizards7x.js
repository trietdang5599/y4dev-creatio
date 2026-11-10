/**
 * Parent: BaseProcessSettings
 */
define("SectionProcessSettings", ["SectionProcessExecutingDetail"], function() {
	return {
		entitySchemaName: "ProcessInModules",
		attributes: {
			"SysModuleEntityId": {
				dataValueType: Terrasoft.DataValueType.GUID,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseProcessSettings#onGetModuleConfigResult
			 * @override
			 */
			onGetModuleConfigResult: function(config) {
				var applicationStructureItem = config.applicationStructureItem;
				this.set("SysModuleEntityId", applicationStructureItem.id);
				this.callParent(arguments);
			}
		},
		details: {
			"ProcessExecutingDetail": {
				schemaName: "SectionProcessExecutingDetail",
				entitySchemaName: "ProcessInModules",
				filter: {
					masterColumn: "SysModuleEntityId",
					detailColumn: "SysModule"
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
