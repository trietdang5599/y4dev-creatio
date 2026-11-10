Terrasoft.configuration.Structures["SimpleIntro"] = {innerHierarchyStack: ["SimpleIntroCrtUIv2", "SimpleIntro"], structureParent: "BaseIntroPageSchema"};
define('SimpleIntroCrtUIv2Structure', ['SimpleIntroCrtUIv2Resources'], function(resources) {return {schemaUId:'bb057159-e980-45c5-9e98-e93dc287e20a',schemaCaption: "Simple intro page", parentSchemaName: "BaseIntroPageSchema", packageName: "UIv2", schemaName:'SimpleIntroCrtUIv2',parentSchemaUId:'965b3e29-c42b-456f-90e0-8733809d280d',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('SimpleIntroStructure', ['SimpleIntroResources'], function(resources) {return {schemaUId:'f94d6881-4225-42c1-9cc3-8cfce11bd4e3',schemaCaption: "Simple intro page", parentSchemaName: "SimpleIntroCrtUIv2", packageName: "UIv2", schemaName:'SimpleIntro',parentSchemaUId:'bb057159-e980-45c5-9e98-e93dc287e20a',extendParent:true,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:"SimpleIntroCrtUIv2",schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define('SimpleIntroCrtUIv2Resources', ['terrasoft'], function(Terrasoft) {
var localizableStrings={

};
var parametersLocalizableStrings={};
var localizableImages={

};
return {localizableStrings: localizableStrings, localizableImages: localizableImages, parametersLocalizableStrings: parametersLocalizableStrings};
});
define("SimpleIntroCrtUIv2", ["SimpleIntroResources", "ConfigurationConstants"], function(resources, ConfigurationConstants) {
		return {
			attributes: {
				"SystemDesignerVisible": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			methods: {

				//region Methods: Protected

				/**
				 * @inheritdoc Terrasoft.BaseIntroPageSchema#init
				 * @overridden
				 * @protected
				 */
				init: function() {
					this.callParent(arguments);
					this.isSystemDesignerVisible();
				},

				//endregion

				//region Methods: Public

				/**
				 * Sets visibility for "System designer" menu item.
				 */
				isSystemDesignerVisible: function() {
					Terrasoft.SysSettings.querySysSettings(["BuildType"], function(sysSettings) {
						var buildType = sysSettings.BuildType;
						if (buildType && (buildType.value === ConfigurationConstants.BuildType.Public)) {
							this.set("SystemDesignerVisible", false);
						} else {
							this.set("SystemDesignerVisible", true);
						}
					}, this);
				}

				//endregion

			},
			diff: [
				{
					"operation": "merge",
					"name": "MainContainer",
					"values": {
						"markerValue": "main-menu"
					}
				},
				
				{
					"operation": "insert",
					"name": "SettingsTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"values": {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.SettingsCaption"},
						"cls": "settings",
						"icon": resources.localizableImages.SettingsIcon,
						"items": []
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "SettingsTile",
					"name": "SystemDesigner",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.SectionDesignerCaption"},
						"tag": "IntroPage/SystemDesigner",
						"click": {"bindTo": "onNavigateTo"},
						"visible": {"bindTo": "SystemDesignerVisible"},
						"maskVisible": true
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "SettingsTile",
					"name": "UserProfile",
					"values": {
						"itemType": Terrasoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ProfileCaption"},
						"tag": "UserProfile",
						"click": {"bindTo": "onNavigateTo"}
					}
				}
			]
		};
	});

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


