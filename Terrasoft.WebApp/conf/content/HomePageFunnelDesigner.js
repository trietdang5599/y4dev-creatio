Terrasoft.configuration.Structures["HomePageFunnelDesigner"] = {innerHierarchyStack: ["HomePageFunnelDesigner"], structureParent: "FullPipelineDesigner"};
define('HomePageFunnelDesignerStructure', ['HomePageFunnelDesignerResources'], function(resources) {return {schemaUId:'0e0bf8ba-520e-4879-b1aa-00cf592856c8',schemaCaption: "Funnel designer for home pages", parentSchemaName: "FullPipelineDesigner", packageName: "HomePage", schemaName:'HomePageFunnelDesigner',parentSchemaUId:'504466c2-5d07-4556-a96e-3c85abb04196',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("HomePageFunnelDesigner",
	["HomePageFunnelDesignerResources", "mf!SchemaViewComponent", "css-ltr!SchemaViewComponentStyles",
	 "FunnelWidgetComponent", "ExtWidgetConfigConverter",
	 "AngularWidgetConfigConverter", "css!HomePageDesignerCSS", "css!ConfigurationModuleV2", "WidgetEnums",
	 "HomePageWidgetDesignerMixin"],
 function(resources) {
	return {
		messages: {
			WidgetConfigChanged: {
				direction: Terrasoft.MessageDirectionType.PUBLISH,
				mode: Terrasoft.MessageMode.BROADCAST
			},
			PageLoaded: {
				direction: Terrasoft.MessageDirectionType.PUBLISH,
				mode: Terrasoft.MessageMode.BROADCAST
			},
			ModalOpening: {
				direction: Terrasoft.MessageDirectionType.PUBLISH,
				mode: Terrasoft.MessageMode.BROADCAST
			},
			ModalClosing: {
				direction: Terrasoft.MessageDirectionType.PUBLISH,
				mode: Terrasoft.MessageMode.BROADCAST
			},
		},
		attributes: {
			StyleColor: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["blue"]
			},
			WidgetColor: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["blue"]
			},
			WidgetTheme: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetTheme["full-fill"]
			},
			WidgetConfig: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			caption: {
				value: resources.localizableStrings.DefaultCaption
			},
			Border: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
		},
		mixins: {
			/**
			 * @class HomePageWidgetDesignerMixin provides the widgets adjustment functionality.
			 */
			HomePageWidgetDesignerMixin: "Terrasoft.HomePageWidgetDesignerMixin"
		},
		methods: {

			/**
			 * @private
			 */
			_getLocalizedConfig: function() {
				const { title } = this.currentWidgetConfig;
				const chartName = this.get("WidgetInitConfig").name;
				const titleSuffix = this.titleResourceKeySuffix;
				const titleKey = `${chartName}${titleSuffix}`;
				this.upsertResource(titleKey, title);
				return {
					...this.currentWidgetConfig,
					resources: this.get("Resources"),
					title: this.getPatternLocalizedString(titleKey),
				};
			},

			/**
			 * Fill style collection.
			 * @protected
			 * @virtual
			 * @param {String} filter Filtering string.
			 * @param {Terrasoft.Collection} list List.
			 */
			prepareStyleColorList: function(filter, list) {
				this.reloadList(list, this.getStyleColorDefaultConfig());
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getDesignWidgetConfig: function() {
				const config = this.callParent(arguments);
				config.widgetColor = this.$WidgetColor?.value;
				config.widgetTheme = this.$WidgetTheme?.value;
				config.border = this.$Border;
				return config;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getWidgetModulePropertiesTranslator: function() {
				let props = this.callParent(arguments);
				props.WidgetColor = "widgetColor";
				props.WidgetTheme = "widgetTheme";
				props.Border = "border";
				return props;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getStyleColorDefaultConfig: function() {
				return Terrasoft.WidgetEnums.WidgetColor;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			init: function(callback, scope) {
				this.initChartDesigner();
				this.callParent([function() {
					this.hideDesignerLoadingMask();
					Ext.callback(callback, scope);
				}, this]);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			setAttributeDisplayValue: function(propertyName, propertyValue) {
				switch (propertyName) {
					case "WidgetColor":
						propertyValue = this.getStyleColorDefaultConfig()[propertyValue];
						break;
					case "WidgetTheme":
						propertyValue = this.getWidgetThemeDefaultConfig()[propertyValue];
						break;
					case "sectionBindingColumn":
						break;
					default:
						this.callParent(arguments);
						return;
				}
				this.set(propertyName, propertyValue);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			initChartDesigner: function() {
				const widgetConfig = this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
				const { itemConfig: { config, name }, defaultConfig, resources } = widgetConfig;
				this.set("Resources", resources ?? {});
				this.set("dataSourceConfig", widgetConfig.dataSourceConfig);
				if (config) {
					const { title } = config;
					config.title = this.getResourceValue(title);
				}
				const widgetInitConfig = this.convertToExtWidgetConfig(config || defaultConfig || {});
				this.set("WidgetInitConfig", { ...widgetInitConfig, name: name.replace(/(-|\.)/g, '') });
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			save: Terrasoft.emptyFn,

			/**
			 * @inheritDoc
			 * @override
			 */
			cancel: Terrasoft.emptyFn,

			/**
			 * @inheritDoc
			 * @override
			 */
			refreshWidget: function() {
				this.callParent(arguments);
				const canRefresh = this.canRefreshWidget();
				const designWidgetConfig = this.getDesignWidgetConfig();
				const convertedWidgetConfig = this.convertToAngularWidgetConfig(designWidgetConfig);
				const isWidgetConfigChanged = JSON.stringify(convertedWidgetConfig) !== JSON.stringify(this.currentWidgetConfig);
				if (canRefresh && isWidgetConfigChanged) {
					this.currentWidgetConfig = Terrasoft.deepClone(convertedWidgetConfig);
					this.set("WidgetConfig", convertedWidgetConfig);
					const localizedConfig = this._getLocalizedConfig();
					this.sandbox.publish("WidgetConfigChanged", localizedConfig, [this.sandbox.id]);
				}
			},

			/**
			 * Converts a specified Angular funnel widget config to Ext.
			 * @protected
			 * @virtual
			 * @param {AngularFunnelWidgetConfig} widgetConfig The Angular funnel widget config.
			 * @returns {ExtFunnelWidgetConfig} The Ext funnel widget config based on the widgetConfig.
			 */
			convertToExtWidgetConfig: function(widgetConfig) {
				return Terrasoft.AngularWidgetConfigConverter.toExtFunnelWidgetConfig(widgetConfig);
			},

			/**
			 * Converts a specified Ext funnel widget config to Angular.
			 * @protected
			 * @virtual
			 * @param {ExtFunnelWidgetConfig} widgetConfig The Ext funnel widget config.
			 * @returns {AngularFunnelWidgetConfig} The Angular funnel widget config based on the widgetConfig.
			 */
			convertToAngularWidgetConfig: function(widgetConfig) {
				return Terrasoft.ExtWidgetConfigConverter.toAngularFunnelWidgetConfig(widgetConfig);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.sandbox.publish("PageLoaded", null, [this.sandbox.id]);
			},

			getWidgetThemeDefaultConfig: function () {
				const themes = this.mixins.HomePageWidgetDesignerMixin.getWidgetThemeDefaultConfig.call(this);
				delete themes['glassmorphism'];
				return themes;
			},
		},
		diff: [
			{
				"operation": "insert",
				"name": "HeaderStyleColor",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"bindTo": "WidgetColor",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.WidgetColorLabel"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleColorList"
						},
						"list": {
							"bindTo": "WidgetColorList"
						}
					}
				},
				"index": 1,
			},
			{
				"operation": "insert",
				"name": "WidgetTheme",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"bindTo": "WidgetTheme",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.WidgetThemeLabel"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareWidgetThemeList"
						},
						"list": {
							"bindTo": "WidgetThemeList"
						}
					}
				},
				"index": 2,
			},
			{
				"operation": "merge",
				"name": "WidgetProperties",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 10
					}
				}
			},
			{
				"operation": "move",
				"name": "Style",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FunnelWidgetPreview",
				"parentName": "FooterContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 11,
						"row": 0,
						"colSpan": 13,
						"rowSpan": 1
					},
					"itemType": Terrasoft.ViewItemType.COMPONENT,
					"className": "Terrasoft.FunnelWidgetComponent",
					"widgetConfig": { "bindTo": "WidgetConfig" }
				}
			},
			{
				"operation": "remove",
				"name": "WidgetModule"
			},
			{
				"operation": "remove",
				"name": "CancelButton"
			},
			{
				"operation": "remove",
				"name": "SaveButton"
			}
		]
	};
});


