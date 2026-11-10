/**
 * Parent: ProcessFlowElementPropertiesPage
 */
define("IntermediateCatchTimerPropertiesPage", ["terrasoft", "IntermediateCatchTimerPropertiesPageResources"],
	function(Terrasoft) {
		return {
			messages: {},
			mixins: {},
			attributes: {
				/**
				 * Start offset parameter.
				 */
				"StartOffset": {
					"dataValueType": this.Terrasoft.DataValueType.MAPPING,
					"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true,
					"doAutoSave": true,
					"initMethod": "initProperty"
				}
			},
			methods: {},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"name": "UserTaskContainer",
					"propertyName": "items",
					"parentName": "EditorsContainer",
					"className": "Terrasoft.GridLayoutEdit",
					"values": {
						"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "TitleTaskContainer",
					"propertyName": "items",
					"parentName": "UserTaskContainer",
					"className": "Terrasoft.GridLayoutEdit",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.Terrasoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "RecommendationLabel",
					"parentName": "TitleTaskContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"itemType": this.Terrasoft.ViewItemType.LABEL,
						"caption": {
							"bindTo": "Resources.Strings.RecommendationCaption"
						},
						"classes": {
							"labelClass": ["t-title-label-proc"]
						},
						"styles": {
							"labelStyle": {
								"color": "#F79552"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "StartOffset",
					"parentName": "TitleTaskContainer",
					"propertyName": "items",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": false
						},
						"wrapClass": ["no-caption-control"]
					}
				},
				{
					"operation": "insert",
					"parentName": "TitleTaskContainer",
					"propertyName": "items",
					"name": "useBackgroundMode",
					"values": {
						"wrapClass": ["t-checkbox-control"],
						"visible": true,
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "move",
					"name": "BackgroundModePriorityConfig",
					"parentName": "TitleTaskContainer",
					"propertyName": "items"
				},
				{
					"operation": "merge",
					"name": "BackgroundModePriorityConfig",
					"parentName": "TitleTaskContainer",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						},
					}
				}
			] /**SCHEMA_DIFF*/
		};
	}
);
