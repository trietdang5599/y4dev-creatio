 define("SimpleIntro", ["SimpleIntroResources", "ConfigurationConstants"], function(resources, ConfigurationConstants) {
		return {
			diff: [
				{
					"operation": "insert",
					"name": "BasicTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.BasisCaption"},
						"cls": "basis",
						"icon": resources.localizableImages.BasisIcon,
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "ESNFeedSectionV2",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"moduleName": "ESNFeed",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "AccountSectionV2",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"moduleName": "Account",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "ContactSectionV2",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"moduleName": "Contact",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "EmployeeSection",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"moduleName": "Employee",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "ActivitySectionV2",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"moduleName": "Activity",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "BasicTile",
					"name": "KnowledgeBaseSectionV2",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.KnowlegebaseSectionCaption"},
						"tag": "SectionModuleV2/KnowledgeBaseSectionV2/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"name": "AnalyticsTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.AnalyticsCaption"},
						"cls": "analytics",
						"icon": resources.localizableImages.AnalyticsIcon,
						"items": []
					},
					"index": 1
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "AnalyticsTile",
					"name": "DashboardsModule",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"moduleName": "Dashboard",
						"click": {"bindTo": "onNavigateTo"}
					}
				}
			]
		};
	});
