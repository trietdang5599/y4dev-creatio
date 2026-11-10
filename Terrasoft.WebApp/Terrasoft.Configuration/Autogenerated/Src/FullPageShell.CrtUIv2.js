define("FullPageShell", /**SCHEMA_DEPS*/["css!CardSchemaViewModule", "css!FullPageShellCSS"]/**SCHEMA_DEPS*/, function/**SCHEMA_ARGS*/()/**SCHEMA_ARGS*/ {
	return {
		viewConfigDiff: /**SCHEMA_VIEW_CONFIG_DIFF*/[
			{
				"operation": "insert",
				"name": "ShellContainer",
				"values": {
					"type": "crt.FlexContainer",
					"direction": "row",
					"wrap": "nowrap",
					"classes": [
						"content-schema"
					],
					"stretch": true,
					"items": []
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "MainCenterContainer",
				"values": {
					"layoutConfig": {
						"column": 1,
						"row": 1,
						"colSpan": 1,
						"rowSpan": 1
					},
					"type": "crt.FlexContainer",
					"direction": "column",
					"classes": [
						"center-container"
					],
					"items": [],
					"borderRadius": "none",
					"padding": "none",
					"justifyContent": "start",
					"alignItems": "stretch",
					"gap": "none",
					"stretch": true
				},
				"alias": {
					"name": "CenterContainer"
				},
				"parentName": "ShellContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RouterOutlet",
				"values": {
					"type": "crt.RouterOutlet",
				},
				"parentName": "MainCenterContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AngularAdapterModule",
				"values": {
					"type": "crt.ModuleLoader",
					"module": "AngularAdapterModule"
				},
				"index": 1
			}
		]/**SCHEMA_VIEW_CONFIG_DIFF*/,
		viewModelConfig: /**SCHEMA_VIEW_MODEL_CONFIG*/{}/**SCHEMA_VIEW_MODEL_CONFIG*/,
		modelConfig: /**SCHEMA_MODEL_CONFIG*/{}/**SCHEMA_MODEL_CONFIG*/,
		handlers: /**SCHEMA_HANDLERS*/[]/**SCHEMA_HANDLERS*/,
		converters: /**SCHEMA_CONVERTERS*/{}/**SCHEMA_CONVERTERS*/,
		validators: /**SCHEMA_VALIDATORS*/{}/**SCHEMA_VALIDATORS*/
	};
});
