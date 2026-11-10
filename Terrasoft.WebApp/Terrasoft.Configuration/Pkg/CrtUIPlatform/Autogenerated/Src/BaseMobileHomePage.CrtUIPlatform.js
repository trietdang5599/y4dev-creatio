{
	"viewConfigDiff": [
		{
			"operation": "insert",
			"name": "Scaffold",
			"values": {
				"type": "crt.Scaffold",
				"showAppBar": false,
				"items": []
			},
			"index": 0
		},
		{
			"operation": "insert",
			"name": "MainContainer",
			"values": {
				"type": "crt.GridContainer",
				"columns": [
					"1fr"
				],
				"rows": "minmax(32px, max-content)",
				"gap": {
					"columnGap": "small",
					"rowGap": "small"
				},
				"items": [],
				"fitContent": true,
				"visible": true,
				"alignItems": "stretch",
				"color": "transparent",
				"borderRadius": "none",
				"padding": {
					"top": "none",
					"right": "small",
					"bottom": "none",
					"left": "small"
				},
				"adaptive": {
					"small": {
						"columns": [
							"1fr"
						]
					},
					"medium": {
						"columns": [
							"1fr",
							"1fr"
						]
					},
					"large": {
						"columns": [
							"1fr",
							"1fr"
						]
					}
				}
			},
			"parentName": "Scaffold",
			"propertyName": "items",
			"index": 0
		}
	],
	"viewModelConfigDiff": [
		{
			"operation": "merge",
			"path": [],
			"values": {
				"attributes": {}
			}
		}
	],
	"modelConfigDiff": [
		{
			"operation": "merge",
			"path": [],
			"values": {
				"dataSources": {}
			}
		}
	]
}