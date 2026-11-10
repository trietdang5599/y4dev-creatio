  define("HomePageIndicatorDesigner",
	 ["HomePageIndicatorDesignerResources", "mf!SchemaViewComponent", "css-ltr!SchemaViewComponentStyles",
	 "IndicatorWidgetComponent", "ExtWidgetConfigConverter",
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
			caption: {
				isRequired: false,
			},
			style: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["green"],
				dependencies: [
					{
						columns: ["IndicatorTheme"],
						methodName: "onIndicatorThemeChanged"
					}
				]
			},
			fontStyle: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: {
					value: "medium",
					displayValue: resources.localizableStrings.FontStyleDefault
				}
			},
			IndicatorTheme: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: {
					value: "full-fill",
					displayValue: resources.localizableStrings.FullFillTheme
				}
			},
			WidgetConfig: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			LabelPosition: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: {
					value: "above-under",
					displayValue: resources.localizableStrings.AboveUnderLabelPosition
				}
			},
			Border: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			Icon: {
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

			hideAngularIndicatorTitle: false,

			onIndicatorThemeChanged: function() {
				const theme = this.$IndicatorTheme;
				const style = this.$style;
				if (theme?.value !== Terrasoft.WidgetEnums.WidgetTheme.glassmorphism?.value
					 && style?.value === Terrasoft.WidgetEnums.TransparentColor?.value) {
					this.$style = Terrasoft.WidgetEnums.WidgetColor["green"];
				}
				if (this.$Icon) {
					this.$Icon.color = undefined;
				}
			},

			/**
			 * @private
			 */
			_getLocalizedConfig: function() {
				const { title, text: { template } } = this.currentWidgetConfig;
				const indicatorId = this.get("IndicatorId")
				const titleSuffix = this.titleResourceKeySuffix;
				const titleKey = `${indicatorId}${titleSuffix}`;
				const templateKey = `${indicatorId}_template`;
				this.upsertResource(titleKey, title);
				const settedTemplate = this.upsertResource(templateKey, template);
				const localizedConfig = { 
					...this.currentWidgetConfig,
					resources: this.get("Resources"),
					title: settedTemplate ? this.getPatternLocalizedString(titleKey) : '',
				};
				localizedConfig.text.template = this.getPatternLocalizedString(templateKey);
				return localizedConfig;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.hideDesignerLoadingMask();
					Ext.callback(callback, scope);
				}, this]);
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
				this._processAggregationChange();
				const designWidgetConfig = this.getDesignWidgetConfig();
				const convertedWidgetConfig = this.convertToAngularWidgetConfig(designWidgetConfig);
				const isWidgetConfigChanged = JSON.stringify(convertedWidgetConfig) !== JSON.stringify(this.currentWidgetConfig);
				if (canRefresh && isWidgetConfigChanged) {
					this.currentWidgetConfig = Terrasoft.deepClone(convertedWidgetConfig);
					this.$WidgetConfig = convertedWidgetConfig;
					const localizedConfig = this._getLocalizedConfig();
					this.sandbox.publish("WidgetConfigChanged", localizedConfig, [this.sandbox.id]);
				}
			},

			/**
			 * @private
			 */
			_processAggregationChange: function() {
				if (this.$aggregationType?.value === Terrasoft.AggregationType.COUNT) {
					this.$aggregationColumn = null;
				}	
			},

			getWidgetInitConfig: function() {
				const initConfig = this.callParent(arguments);
				const { itemConfig: { config, name }, resources, defaultConfig} = Terrasoft.deepClone(initConfig);
				if (!config.dataSourceConfig) {
					config.dataSourceConfig = initConfig.dataSourceConfig;
				}
				if (initConfig.dataSourceConfig) {
					initConfig.sectionBindingColumnRecordId = "$Id";
				}
				this.hideAngularIndicatorTitle = config && !!config.hideTitle;
				this.set("IndicatorId", name.replace(/(-|\.)/g, ''));
				this.setResources(resources);
				if (config) {  // TODO Delete if statement after close CRM-62204
					const { title, text: { template = '' } = {} } = config || {};
					if (config.title === "undefined") {
						config.title = '';
					}
					if (config.text.template === "undefined") {
						config.text.template = '{0}';
					}
					config.title = this.getResourceValue(title);
					config.text.template = this.getResourceValue(template);
				}
				const convertedConfig = this.convertToExtWidgetConfig(config || defaultConfig || {});
				return convertedConfig;
			},
			
			/**
			 * Converts a specified Angular indicator widget config to Ext.
			 * @protected
			 * @virtual
			 * @param {AngularIndicatorWidgetConfig} widgetConfig The Angular indicator widget config.
			 * @returns {ExtIndicatorWidgetConfig} The Ext indicator widget config based on the widgetConfig.
			 */
			convertToExtWidgetConfig: function(widgetConfig) {
				return Terrasoft.AngularWidgetConfigConverter.toExtIndicatorWidgetConfig(widgetConfig);
			},

			/**
			 * Converts a specified Ext indicator widget config to Angular.
			 * @protected
			 * @virtual
			 * @param {ExtIndicatorWidgetConfig} widgetConfig The Ext indicator widget config.
			 * @returns {AngularIndicatorWidgetConfig} The Angular indicator widget config based on the widgetConfig.
			 */
			convertToAngularWidgetConfig: function(widgetConfig) {
				widgetConfig.format = widgetConfig.format || {};
				widgetConfig.format.type = this.getValueDataValueType();
				const angularConfig = Terrasoft.ExtWidgetConfigConverter.toAngularIndicatorWidgetConfig(widgetConfig);
				angularConfig.hideTitle = this.hideAngularIndicatorTitle;
				return angularConfig;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.sandbox.publish("PageLoaded", null, [this.sandbox.id]);
			},

			prepareStyleList: function (filter, list) {
				if (list === null) {
					return;
				}
				const stylesListConfig = this.getStyleDefaultConfig();
				const theme = this.$IndicatorTheme;
				if (theme?.value !== Terrasoft.WidgetEnums.WidgetTheme.glassmorphism?.value) {
					delete stylesListConfig.transparent;
				}
				list.clear();
				list.loadAll(stylesListConfig);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getStyleDefaultConfig: function () {
				let colorsConfig = {
					...Terrasoft.WidgetEnums.WidgetColor,
				};
				colorsConfig.transparent = Terrasoft.WidgetEnums.TransparentColor;
				return colorsConfig;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getFontStyleDefaultConfig: function() {
				if (Terrasoft.Features.getIsEnabled("DisableNewIndicatorSizes")) {
					return {
						"medium": {
							value: "medium",
							displayValue: this.get("Resources.Strings.FontStyleDefault")
						},
						"large": {
							value: "large",
							displayValue: this.get("Resources.Strings.FontStyleBig")
						}
					};
				}
				return {
					"extra-small": {
						value: "extra-small",
						displayValue: this.get("Resources.Strings.FontStyleExtraSmall")
					},
					"small": {
						value: "small",
						displayValue: this.get("Resources.Strings.FontStyleSmall")
					},
					"medium": {
						value: "medium",
						displayValue: this.get("Resources.Strings.FontStyleDefault")
					},
					"large": {
						value: "large",
						displayValue: this.get("Resources.Strings.FontStyleBig")
					},
					"extra-large": {
						value: "extra-large",
						displayValue: this.get("Resources.Strings.FontStyleExtraLarge")
					}
				};
			},

			getIndicatorThemeDefaultConfig: function() {
				return {
					"full-fill": {
						value: "full-fill",
						displayValue: this.get("Resources.Strings.FullFillTheme")
					},
					"without-fill": {
						value: "without-fill",
						displayValue: this.get("Resources.Strings.WithoutFillTheme")
					},
					"glassmorphism": Terrasoft.WidgetEnums.WidgetTheme.glassmorphism,
					"transparent": {
						value: "transparent",
						displayValue: this.get("Resources.Strings.TransparentTheme")
					},
				};
			},

			prepareIndicatorThemeList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getIndicatorThemeDefaultConfig());
			},
			

			/**
			 * @inheritDoc
			 * @override
			 */
			getWidgetModulePropertiesTranslator: function() {
				let props = this.callParent(arguments);
				props.IndicatorTheme = "indicatorTheme";
				props.Border = "border";
				props.Icon = "icon";
				return props;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getDesignWidgetConfig: function() {
				const config = this.callParent(arguments);
				config.indicatorTheme = this.$IndicatorTheme?.value;
				if (config.format) {
					config.format.labelPosition = this.$LabelPosition?.value;
				}
				config.border = this.$Border;
				config.icon = this.$Icon;
				return config;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			setAttributeDisplayValue: function(propertyName, propertyValue) {
				switch (propertyName) {
					case "IndicatorTheme":
						propertyValue = this.getIndicatorThemeDefaultConfig()[propertyValue];
						break;
					default:
						this.callParent(arguments);
						return;
				}
				this.set(propertyName, propertyValue);
			},

			widgetColorVisibilityConverter: function () {
				return true;
			},

			getTextdecoratorConfig: function() {
				const config = this.callParent(arguments);
				if (Terrasoft.Features.getIsEnabled("DisableNewIndicatorLabelPosition")) {
					return config;
				}
				return {
					...config,
					labelPosition: {					
						dataValueType: Terrasoft.DataValueType.ENUM,
						caption: this.get("Resources.Strings.LabelPositionCaption"),
						value: {
							"bindTo": "LabelPosition"
						},
						customConfig: {
							prepareList: {
								"bindTo": "prepareLabelPositionList"
							},
							list: {
								"bindTo": "LabelPositionList"
							},
						},
						useControlBinding: true
					}
				};
			},
			
			prepareLabelPositionList: function(_, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getLabelPositionDefaultConfig());
			},
			
			getLabelPositionDefaultConfig: function() {
				return {
					"above-under": {
						value: "above-under",
						displayValue: this.get("Resources.Strings.AboveUnderLabelPosition")
					},
					"before-after": {
						value: "before-after",
						displayValue: this.get("Resources.Strings.BeforeAfterLabelPosition")
					}
				};
			},
			
			setWidgetModuleProperties: function(widgetConfig) {
				const labelPositions = this.getLabelPositionDefaultConfig();
				this.$LabelPosition = labelPositions[widgetConfig?.format?.labelPosition] ?? labelPositions['above-under'];
				this.callParent(arguments);
			},
		},
		diff: [
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
				"name": "IndicatorTheme",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"bindTo": "IndicatorTheme",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.IndicatorThemeLabel"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareIndicatorThemeList"
						},
						"list": {
							"bindTo": "IndicatorThemeList"
						}
					}
				},
				"index": 2,
			},
			{
				"operation": "insert",
				"name": "IndicatorWidgetPreview",
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
					"className": "Terrasoft.IndicatorWidgetComponent",
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
