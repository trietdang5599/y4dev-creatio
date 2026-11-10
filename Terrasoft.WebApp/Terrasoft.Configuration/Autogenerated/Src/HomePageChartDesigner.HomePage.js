 define("HomePageChartDesigner",
	 ["HomePageChartDesignerResources", "mf!SchemaViewComponent", "css-ltr!SchemaViewComponentStyles",
	 "ChartWidgetComponent", "ExtWidgetConfigConverter", "AngularWidgetConfigConverter",  "css!HomePageDesignerCSS",
	 "css!ConfigurationModuleV2", "WidgetEnums", "HomePageWidgetDesignerMixin"],
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
				value: Terrasoft.WidgetEnums.WidgetColor["green"]
			},
			WidgetColor: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["green"]
			},
			WidgetTheme: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetTheme["full-fill"]
			},
			ChartWidgetConfig: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			DisplayDataLabel: {
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true,
				dependencies: [
					{
						columns: ["ChartType"],
						methodName: "onChartTypeChanged",
					},
				],
			},
			RowCount: {
				dataValueType: Terrasoft.DataValueType.INTEGER,
				value: 50
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
			_initialWidgetSeriesConfig: null,

			/**
		 	* @private
		 	*/
			_getLocalizedSeries: function() {
				const chartName = this.get("WidgetInitConfig").name;
				return this.currentWidgetConfig.series.map((series, index) => {
					const labelKey = `${chartName}_series_${index}`;
					this.upsertResource(labelKey, series.label);
					series.label = this.getPatternLocalizedString(labelKey);
					return series;
				});
			},

			/**
		 	* @private
		 	*/
			_getLocalizedAxis: function(axis, axisName) {
				const chartName = this.get("WidgetInitConfig").name;
				const axisKey = `${chartName}_${axis}`;
				const settedAxisName = this.upsertResource(axisKey, axisName);
				return settedAxisName ? this.getPatternLocalizedString(axisKey) : '';
			},

			/**
		 	* @private
		 	*/
			_getLocalizedConfig: function() {
				const resources = this.get("Resources");
				const chartName = this.get("WidgetInitConfig").name;
				const titleSuffix = this.titleResourceKeySuffix;
				const titleKey = `${chartName}${titleSuffix}`;
				this.upsertResource(titleKey, this.currentWidgetConfig.title)
				const localizedSeries = this._getLocalizedSeries();
				const localizedConfig = {
					...this.currentWidgetConfig,
					series: localizedSeries,
					title: this.getPatternLocalizedString(titleKey),
					resources,
				};
				const { xAxis = {}, yAxis = {} } = Terrasoft.deepClone(this.currentWidgetConfig.scales);
				localizedConfig.scales.xAxis.name = this._getLocalizedAxis('xAxis', xAxis.name);
				localizedConfig.scales.yAxis.name = this._getLocalizedAxis('yAxis', yAxis.name);
				return localizedConfig;
			},

			/**
			 * @private
			 */
			_getInitialWidgetSeriesConfig: function(index) {
				return this._initialWidgetSeriesConfig && this._initialWidgetSeriesConfig[index];
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
			init: function(callback, scope) {
				this.seriesProperties.DataProvidingAttribute = 'dataProvidingAttribute';
				this.seriesProperties.Dependencies = 'dependencies';
				this.seriesProperties.FilterAttributes = 'filterAttributes';
				this.seriesProperties.DisplayDataLabel = 'displayDataLabel';
				this.seriesProperties.HierarchyConfig = 'hierarchyConfig';
				this.callParent([function() {
					this.hideDesignerLoadingMask();
					Terrasoft.SysSettings.querySysSettingsItem("ChartQueryDataLimit", function(value) {
						this.$RowCount = value;
						Ext.callback(callback, scope);
					}, this);
				}, this]);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getChartTypeDefaultConfig: function() {
				const baseTypes = this.callParent(arguments);
				Ext.merge(baseTypes.pie, {
					displayValue: resources.localizableStrings.DoughnutChartCaption
				});
				if (Terrasoft.Features.getIsEnabled("EnableAngularChartWidgetWaterfall")) {
					baseTypes.waterfall = {
						value: "waterfall",
						displayValue: resources.localizableStrings.WaterfallChartCaption,
						imageConfig: baseTypes.column?.imageConfig
					};
				}
				return baseTypes;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			initChartDesigner: function() {
				const widgetConfig = this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
				const { itemConfig: { config, name }, defaultConfig, resources } = widgetConfig;
				config.dataSourceConfig = widgetConfig.dataSourceConfig;
				this.setResources(resources);
				if (config) {
					const { title, scales } = config;
					if (scales) {
						const { xAxis = {}, yAxis = {} } = scales;
						config.scales.xAxis.name = this.getResourceValue(xAxis.name);
						config.scales.yAxis.name = this.getResourceValue(yAxis.name);
					}
					config.title = this.getResourceValue(title);
					this._initialWidgetSeriesConfig = Terrasoft.deepClone(config.series);
					config.series.forEach(series => series.label = this.getResourceValue(series.label));
				}
				const widgetInitConfig = this.convertToExtWidgetConfig(config || defaultConfig || {});
				this.set("WidgetInitConfig", { ...widgetInitConfig, name: name.replace(/(-|\.)/g, '') });
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getSeriesConfigItem: function(viewModel, index) {
				const itemConfig = this.callParent(arguments);
				const selectedEntitySchema = viewModel && viewModel.$entitySchemaName || {};
				const seriesConfig = this._getInitialWidgetSeriesConfig(index);
				const seriesRowCount = seriesConfig && seriesConfig.data && seriesConfig.data.providing
					&& seriesConfig.data.providing.rowCount;
				itemConfig.schemaCaption = selectedEntitySchema.displayValue || '';
				itemConfig.rowCount = seriesRowCount ?? this.$RowCount;
				itemConfig.dataProvidingAttribute = viewModel.$DataProvidingAttribute;
				itemConfig.dependencies = viewModel.$Dependencies;
				itemConfig.filterAttributes = viewModel.$FilterAttributes;
				itemConfig.displayDataLabel = viewModel.$DisplayDataLabel;
				itemConfig.hierarchyConfig = viewModel.$HierarchyConfig;
				return itemConfig;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			convertChartConfig: function(chartConfig) {
				const convertedConfig = this.callParent(arguments);
				const rootSeriesDisplayDataValue = chartConfig.displayDataLabel === undefined
					? this.isDisplayDataLabelAvailableConverter({
						value: chartConfig.type
					}) : chartConfig.displayDataLabel;
				convertedConfig.displayDataLabel = rootSeriesDisplayDataValue;
				convertedConfig.seriesConfig[0].dataProvidingAttribute = chartConfig.dataProvidingAttribute;
				convertedConfig.seriesConfig[0].dependencies = chartConfig.dependencies;
				convertedConfig.seriesConfig[0].hierarchyConfig = chartConfig.hierarchyConfig;
				convertedConfig.seriesConfig[0].filterAttributes = chartConfig.filterAttributes;
				convertedConfig.seriesConfig[0].displayDataLabel = rootSeriesDisplayDataValue;
				Terrasoft.each(chartConfig.seriesConfig, function(seriesConfigItem, index) {
					const serieDisplayDataValue = seriesConfigItem.displayDataLabel === undefined
						? this.isDisplayDataLabelAvailableConverter({
							value: seriesConfigItem.type
						}) : seriesConfigItem.displayDataLabel;
					convertedConfig.seriesConfig[index + 1].dataProvidingAttribute = seriesConfigItem.dataProvidingAttribute;
					convertedConfig.seriesConfig[index + 1].dependencies = seriesConfigItem.dependencies;
					convertedConfig.seriesConfig[index + 1].hierarchyConfig = seriesConfigItem.hierarchyConfig;
					convertedConfig.seriesConfig[index + 1].filterAttributes = seriesConfigItem.filterAttributes;
					convertedConfig.seriesConfig[index + 1].displayDataLabel = serieDisplayDataValue;
				}, this);
				return convertedConfig;
			},

			loadSeriesCollection: function() {
				this.callParent(arguments);
				const seriesCollection = this.get("SeriesCollection");
				const convertedChartConfig = this.get("ConvertedChartConfig");
				Terrasoft.each(seriesCollection, function(seriesItem, index) {
					const seriesConfig = convertedChartConfig.seriesConfig[index];
					seriesItem.$DataProvidingAttribute = seriesConfig.dataProvidingAttribute;
					seriesItem.$Dependencies = seriesConfig.dependencies;
					seriesItem.$HierarchyConfig = seriesConfig.hierarchyConfig;
					seriesItem.$FilterAttributes = seriesConfig.filterAttributes;
					seriesItem.$DisplayDataLabel = seriesConfig.displayDataLabel;
				}, this);
			},

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
				if (canRefresh && isWidgetConfigChanged && !this.$IsUnsupportedTypes) {
					this.currentWidgetConfig = Terrasoft.deepClone(convertedWidgetConfig);
					this.$ChartWidgetConfig = convertedWidgetConfig;
					const localizedConfig = this._getLocalizedConfig();
					this.sandbox.publish("WidgetConfigChanged", localizedConfig, [this.sandbox.id]);
				}
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			copyActiveSeries: function() {
				this.callParent(arguments);
				const activeSeries = this.$SeriesCollection.get(this.$ActiveSeriesName);
				activeSeries.$FilterAttributes = undefined;
				activeSeries.$DataProvidingAttribute = undefined;
				this.refreshWidget();
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			deleteActiveSeries: function() {
				const deletingSeriesIndex = this.$SeriesCollection.indexOfKey(this.$ActiveSeriesName);
				this.callParent(arguments);
				const chartName = this.get("WidgetInitConfig").name;
				const keyBase = `${chartName}_series`;
				const key = `${keyBase}_${deletingSeriesIndex}`;
				const resources = this.get("Resources");
				delete resources.strings[key];
				Object.keys(resources.strings).forEach((key) => {
					let serialNumber = Number(key.split('series_')[1]);
					const needPositionRecalculation = key.startsWith(keyBase) && serialNumber > deletingSeriesIndex;
					if (needPositionRecalculation) {
						const brokenOrderSeriesKey = `${keyBase}_${serialNumber}`;
						resources.strings[`${keyBase}_${serialNumber-1}`] = resources.strings[brokenOrderSeriesKey]
						delete resources.strings[brokenOrderSeriesKey];
					};
				});
				this.setResources(resources);
				this.refreshWidget();
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
			getDesignWidgetConfig: function() {
				const config = this.callParent(arguments);
				config.widgetColor = this.$WidgetColor?.value;
				config.widgetTheme = this.$WidgetTheme?.value;
				const xColumnDataValueType = this.$XAxisColumn?.dataValueType;
				const isAggregativeXColumn = this.$XAxisColumn?.isAggregative;
				config.xAxisFormatting = Terrasoft.isNumberDataValueType(xColumnDataValueType) && !isAggregativeXColumn ? {
						type: 'number',
						thousandAbbreviation: { enabled: true }
					} : undefined;
				config.border = this.$Border;
				return config;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onColumnLoaded: function(selectedColumnInfo) {
				var structureExplorerConfig = this.structureExplorerConfig;
				var selectedObject = {
					value: selectedColumnInfo.leftExpressionColumnPath,
					dataValueType: selectedColumnInfo.dataValueType,
					displayValue: selectedColumnInfo.leftExpressionCaption,
					referenceSchemaName: selectedColumnInfo.referenceSchemaName,
					isAggregative: selectedColumnInfo.isAggregative,
				};
				this.set(structureExplorerConfig.tag, selectedObject);
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
					default:
						this.callParent(arguments);
						return;
				}
				this.set(propertyName, propertyValue);
			},

			convertToExtWidgetConfig: function(widgetConfig) {
				return Terrasoft.AngularWidgetConfigConverter.toExtChartWidgetConfig(widgetConfig);
			},

			convertToAngularWidgetConfig: function(widgetConfig) {
				return Terrasoft.ExtWidgetConfigConverter.toAngularChartWidgetConfig(widgetConfig);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.sandbox.publish("PageLoaded", null, [this.sandbox.id]);
			},

			onChartTypeChanged: function() {
				const isDisplayDataLabelAvailable = this.isDisplayDataLabelAvailableConverter(this.$ChartType);
				if (!isDisplayDataLabelAvailable) {
					this.$DisplayDataLabel = undefined;
					return;
				}
				const activeSeriesIndex = this.$SeriesCollection.indexOfKey(this.$ActiveSeriesName);
				const activeSeries = this.$ChartWidgetConfig.series[activeSeriesIndex];
				const initialDisplayDataLabel = activeSeries?.dataLabel?.display;
				this.$DisplayDataLabel = initialDisplayDataLabel == null || initialDisplayDataLabel;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getStyleColorDefaultConfig: function() {
				return Terrasoft.WidgetEnums.WidgetColor;
			},

			yAxisCaptionLabelConverter: function() {
				return this.get("Resources.Strings.YAxisCaption2");
			},

			axisCaptionVisibilityConverter: function(value) {
				const chartTypesWithoutAxis = ["pie", "funnel"];
				return Boolean(value && !Terrasoft.contains(chartTypesWithoutAxis, value.value));
			},

			styleColorVisibilityConverter: function(value) {
				const chartTypesWithoutColorsSettings = ["pie", "funnel"];
				return Boolean(value && !Terrasoft.contains(chartTypesWithoutColorsSettings, value.value));
			},

			isDisplayDataLabelAvailableConverter: function (chartTypeAttribute) {
				const chartTypesWithDataLabels = ["bar", "column"];
				if (Terrasoft.Features.getIsEnabled("EnableAngularChartWidgetWaterfall")) {
					chartTypesWithDataLabels.push("waterfall");
				}
				return chartTypesWithDataLabels.includes(chartTypeAttribute?.value);
			},

			getSectionBindingGroupVisible: function() {
				return this.callParent(arguments);
			},

			showEmptyGroupingValueWarnig: function() {
				const parentMethod = this.getParentMethod();
				setTimeout(() => {
					parentMethod.call(this);
				});
			}
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
					"visible": {
						"bindTo": "WidgetTheme",
						"bindConfig": {
							"converter": "widgetColorVisibilityConverter"
						}
					},
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
				"name": "XAxisDefaultCaption",
				"values": {
					"bindTo": "XAxisDefaultCaption",
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "axisCaptionVisibilityConverter"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "StyleColor",
				"values": {
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "styleColorVisibilityConverter"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "YAxisDefaultCaption",
				"values": {
					"bindTo": "YAxisDefaultCaption",
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "axisCaptionVisibilityConverter"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "DisplayDataLabel",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.BOOLEAN,
					"bindTo": "DisplayDataLabel",
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "isDisplayDataLabelAvailableConverter"
						},
					},
					"labelConfig": {
						"visible": true,
						"caption": {"bindTo": "Resources.Strings.DisplayDataLabelCaption"}
					},
					"controlConfig": {
						"className": "Terrasoft.CheckBoxEdit"
					}
				},
			},
			{
				"operation": "merge",
				"name": "XAxisCaption",
				"values": {
					"visible": false,
				}
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
				"operation": "insert",
				"name": "ChartWidgetPreview",
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
					"className": "Terrasoft.ChartWidgetComponent",
					"widgetConfig": { "bindTo": "ChartWidgetConfig" }
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
