define("PortalKnowledgeBasePage", [],
		function() {
			return {
				entitySchemaName: "KnowledgeBase",
				details: /**SCHEMA_DETAILS*/{
					"FileDetailReadOnly": {
						"schemaName": "FileDetailReadOnly",
						"entitySchemaName": "KnowledgeBaseFile",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "KnowledgeBase"
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "RelationsTab"
					},
					{
						"operation": "merge",
						"name": "Name",
						"values": {
							"enabled": false
						}
					},
					{
						"operation": "merge",
						"name": "Type",
						"values": {
							"enabled": false
						}
					},
					{
						"operation": "merge",
						"name": "Notes",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24,
								"rowSpan": 1
							},
							"enabled": false
						}
					},
					{
						"operation": "remove",
						"name": "KnowledgeBasePageGeneralTegContainer"
					},
					{
						"operation": "merge",
						"name": "LikeContainer",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "remove",
						"name": "Files"
					},
					{
						"operation": "insert",
						"name": "FileDetailReadOnly",
						"values": {
							"itemType": this.Terrasoft.ViewItemType.DETAIL
						},
						"parentName": "FilesTab",
						"propertyName": "items",
						"index": 0
					}
				]/**SCHEMA_DIFF*/,
				methods: {
					/**
					 * @overriden
					 * ############## ######## ########
					 */
					initActionButtonMenu: function() {
						this.set("ActionsButtonVisible", false);
					}
				}
			};
		});
