define("SimpleIntro", ["SimpleIntroResources", "ConfigurationConstants"], function(resources, ConfigurationConstants) {
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
