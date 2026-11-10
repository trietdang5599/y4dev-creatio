/**
 * ProcessBaseEventPropertiesPage edit page schema.
 * Parent: ProcessBaseEventPropertiesPage => ProcessFlowElementPropertiesPage.
 */
define("ProcessStartEventPropertiesPage", ["ProcessStartEventPropertiesPageResources"], function(resources) {
	return {
			messages: {},
			attributes: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[{
				"operation": "insert",
				"name": "BackgroundProcessModeControlGroup",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "BackgroundProcessModeControlGroup",
				"propertyName": "items",
				"name": "useBackgroundMode",
				"values": {
					"hint": resources.localizableStrings.StartEventUseBackgroundModeHint,
					"wrapClass": ["t-checkbox-control"],
					"visible": {
						"bindTo": "canUseBackgroundProcessMode"
					},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "move",
				"name": "BackgroundModePriorityConfig",
				"parentName": "BackgroundProcessModeControlGroup",
				"propertyName": "items"
			},
			{
				"operation": "merge",
				"name": "BackgroundModePriorityConfig",
				"parentName": "BackgroundProcessModeControlGroup",
				"values": {
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
