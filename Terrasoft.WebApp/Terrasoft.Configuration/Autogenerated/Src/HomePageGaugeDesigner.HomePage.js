   define("HomePageGaugeDesigner",
	 ["HomePageGaugeDesignerResources", "mf!SchemaViewComponent", "css-ltr!SchemaViewComponentStyles",
	 "GaugeWidgetComponent", "ExtWidgetConfigConverter",
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
			style: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["green"]
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
			GaugeTheme: {
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
			PaletteColorMin: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["green"]
			},
			PaletteColorMiddle: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["blue"]
			},
			PaletteColorMax: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: Terrasoft.WidgetEnums.WidgetColor["red"]
			},
			minStyleList: {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true
			},
			middleStyleList: {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true
			},
			maxStyleList: {
				dataValueType: Terrasoft.DataValueType.COLLECTION,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isCollection: true
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
				const { title, text: { template } } = Terrasoft.deepClone(this.currentWidgetConfig);
				const gaugeId = this.get("GaugeId");
				const titleSuffix = this.titleResourceKeySuffix;
				const titleKey = `${gaugeId}${titleSuffix}`;
				const templateKey = `${gaugeId}_template`;
				this.upsertResource(titleKey, title);
				const settledTemplate = this.upsertResource(templateKey, template);
				const localizedConfig = { 
					...Terrasoft.deepClone(this.currentWidgetConfig),
					resources: this.get("Resources"),
					title: settledTemplate ? this.getPatternLocalizedString(titleKey) : '',
				};
				localizedConfig.text.template = this.getPatternLocalizedString(templateKey);
				return localizedConfig;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			init: function(callback, scope) {
				this.$minStyleList = new Terrasoft.Collection;
				this.$minStyleList.loadAll(this.getStyleDefaultConfig());
				this.$middleStyleList = new Terrasoft.Collection;
				this.$middleStyleList.loadAll(this.getStyleDefaultConfig());
				this.$maxStyleList = new Terrasoft.Collection;
				this.$maxStyleList.loadAll(this.getStyleDefaultConfig());
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

			/**
			 * @private
			 */
			_isDefined(value) {
				return value !== undefined;
			},

			/**
			 * @private
			 */
			_sortThresholds() {
				if (this._isDefined(this.$min) && this._isDefined(this.$middleFrom)
					&& this._isDefined(this.$middleTo) && this._isDefined(this.$max)) {
					const data = [this.$min, this.$middleFrom, this.$middleTo, this.$max].sort((a, b) => a - b);
					this.$min = data[0];
					this.$middleFrom = data[1];
					this.$middleTo = data[2];
					this.$max = data[3];
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseWidgetDesigner#getWidgetInitConfig
			 * @overridden
			 */
			getWidgetInitConfig: function() {
				const initConfig = this.callParent(arguments);
				const { itemConfig: { config, name }, resources, defaultConfig} = Terrasoft.deepClone(initConfig);
				config.dataSourceConfig = initConfig.dataSourceConfig;
				this.set("GaugeId", name.replace(/(-|\.)/g, ''));
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
				return this.convertToExtWidgetConfig(config || defaultConfig || {});
			},
			
			/**
			 * Converts a specified Angular gauge widget config to Ext.
			 * @protected
			 * @virtual
			 * @param {AngularGaugeWidgetConfig} widgetConfig The Angular gauge widget config.
			 * @returns {ExtGaugeWidgetConfig} The Ext gauge widget config based on the widgetConfig.
			 */
			convertToExtWidgetConfig: function(widgetConfig) {
				return Terrasoft.AngularWidgetConfigConverter.toExtGaugeWidgetConfig(widgetConfig);
			},

			/**
			 * Converts a specified Ext gauge widget config to Angular.
			 * @protected
			 * @virtual
			 * @param {ExtGaugeWidgetConfig} widgetConfig The Ext gauge widget config.
			 * @returns {AngularGaugeWidgetConfig} The Angular gauge widget config based on the widgetConfig.
			 */
			convertToAngularWidgetConfig: function(widgetConfig) {
				widgetConfig.format = widgetConfig.format || {};
				widgetConfig.format.type = this.getValueDataValueType();
				return Terrasoft.ExtWidgetConfigConverter.toAngularGaugeWidgetConfig(widgetConfig);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.sandbox.publish("PageLoaded", null, [this.sandbox.id]);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getStyleDefaultConfig: function() {
				return Terrasoft.WidgetEnums.WidgetColor;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getFontStyleDefaultConfig: function() {
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
			},

			/**
			 * Returns themes configuration.
			 * @returns {Object} Themes configuration.
			 */
			getGaugeThemeDefaultConfig: function() {
				return Terrasoft.WidgetEnums.WidgetTheme;
			},

			/**
			 * Loads themes collection to list.
			 * @param {Object} filter Filter. 
			 * @param {Terrasoft.BaseViewModelCollection} list Lookup list.
			 */
			prepareGaugeThemeList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getGaugeThemeDefaultConfig());
			},
			

			/**
			 * @inheritDoc
			 * @override
			 */
			getWidgetModulePropertiesTranslator: function() {
				let props = this.callParent(arguments);
				props.GaugeTheme = "gaugeTheme";
				props.PaletteColorMin = this.swapPaletteOrder("maxColor", "minColor");
				props.PaletteColorMiddle = "middleColor";
				props.PaletteColorMax = this.swapPaletteOrder("minColor", "maxColor");
				props.Border = "border";
				return props;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getDesignWidgetConfig: function() {
				const config = this.callParent(arguments);
				config.gaugeTheme = this.$GaugeTheme?.value;
				this._sortThresholds();
				config.thresholds = {};
				config.thresholds[this.$middleFrom] = {color: this.$PaletteColorMiddle?.code};
				if (this.$orderDirection?.value === Terrasoft.OrderDirection.ASC) {
					config.thresholds[this.$min] = {color: this.$PaletteColorMax?.code};
					config.thresholds[this.$middleTo] = {color: this.$PaletteColorMin?.code};
					config.thresholds[this.$max] = {color: this.$PaletteColorMin?.code};
				} else {
					config.thresholds[this.$min] = {color: this.$PaletteColorMin?.code};					
					config.thresholds[this.$middleTo] = {color: this.$PaletteColorMax?.code};
					config.thresholds[this.$max] = {color: this.$PaletteColorMax?.code};
				}
				config.min = this.$min;
				config.max = this.$max;
				config.orderDirection = this.$orderDirection?.value;
				config.border = this.$Border;
				return config;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			setAttributeDisplayValue: function(propertyName, propertyValue) {
				switch (propertyName) {
					case "GaugeTheme":
						propertyValue = this.getGaugeThemeDefaultConfig()[propertyValue];
						break;
					default:
						this.callParent(arguments);
						return;
				}
				this.set(propertyName, propertyValue);
			},

			/**
			 * Swap palette MIN/MAX values according to Display Order
			 * @param {String} valueA Swap value A.
			 * @param {String} valueB Swap value B.
			 * @returns {Object} Image configuration.
			 */
			swapPaletteOrder: function(valueA, valueB) {
				const orderDirection = this.get("orderDirection");
				if (!orderDirection) {
					return null;
				}
				return orderDirection.value === Terrasoft.OrderDirection.DESC
					? valueA
					: valueB;
			},

			/**
			 * Get color preview image for MIN value
			 * @returns {Object} Image configuration.
			 */
			getMinPreviewImageConfig: function() {
				return this.swapPaletteOrder(this.$PaletteColorMin?.imageConfig, this.$PaletteColorMax?.imageConfig);
			},

			/**
			 * Get color preview image for MIDDLE value
			 * @returns {Object} Image configuration.
			 */
			getMiddlePreviewImageConfig: function() {
				return this.$PaletteColorMiddle?.imageConfig;
			},

			/**
			 * Get color preview image for MAX value
			 * @returns {Object} Image configuration.
			 */
			getMaxPreviewImageConfig: function() {
				return this.swapPaletteOrder(this.$PaletteColorMax?.imageConfig, this.$PaletteColorMin?.imageConfig)
			},

			/**
			 * Get color preview value for MIN value
			 * @returns {Object} Widget color configuration.
			 */
			getPaletteMin: function() {
				return this.swapPaletteOrder(this.$PaletteColorMin, this.$PaletteColorMax);
			},

			/**
			 * Get color preview value for MAX value
			 * @returns {Object} Widget color configuration.
			 */
			getPaletteMax: function() {
				return this.swapPaletteOrder(this.$PaletteColorMax, this.$PaletteColorMin);
			},

			/**
			 * Palette inverted visibility converter
			 * @param orderDirection Display order
			 * @returns {boolean} Visible value
			 */
			invertColor: function(orderDirection) {
				return orderDirection.value === Terrasoft.OrderDirection.ASC
			},

			/**
			 * Palette direct visibility converter
			 * @param orderDirection Display order
			 * @returns {boolean} Visible value
			 */
			revertColor: function(orderDirection) {
				return orderDirection.value === Terrasoft.OrderDirection.DESC
			}
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
				"operation": "merge",
				"name": "Style",
				"parentName": "WidgetProperties",
				"values": {
					"visible": {
						"bindTo": "GaugeTheme",
						"bindConfig": {
							"converter": "widgetColorVisibilityConverter"
						}
					},
				}
			},		
			{
				"operation": "insert",
				"name": "GaugeTheme",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"bindTo": "GaugeTheme",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.GaugeThemeLabel"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareGaugeThemeList"
						},
						"list": {
							"bindTo": "GaugeThemeList"
						}
					}
				},
				"index": 2,
			},
			{
				"operation": "insert",
				"name": "GaugeWidgetPreview",
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
					"className": "Terrasoft.GaugeWidgetComponent",
					"widgetConfig": { "bindTo": "WidgetConfig" },
				}
			},
			{
				"operation": "merge",
				"name": "ScaleIndicatorContainer",
				"parentName": "ScaleControlContainer",
				"values": {
					"id": "ScaleIndicatorContainer",
					"selectors": {"wrapEl": "#ScaleIndicatorContainer"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["gauge-scale-container"],
					"markerValue": "ScaleIndicatorContainer"
				}
			},
			{
				"operation": "insert",
				"name": "ColorPickerContainer",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"index": 2,
				"values": {
					"id": "ColorPickerContainer",
					"selectors": {"wrapEl": "#ColorPickerContainer"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["scale-container", "control-width-15"],
					"markerValue": "ColorPickerContainer",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ColorLabelContainer",
				"parentName": "ColorPickerContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"id": "ColorLabelContainer",
					"selectors": {"wrapEl": "#ColorLabelContainer"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["label-wrap"],
					"markerValue": "ColorLabelContainer",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ColorLabel",
				"parentName": "ColorLabelContainer",
				"propertyName": "items",
				"values": {
					classes: {
						"labelClass": ["scale-caption", "t-label-is-required"]
					},
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.ColorCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "ColorContainer",
				"parentName": "ColorPickerContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"id": "ColorContainer",
					"selectors": {"wrapEl": "#ColorContainer"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["gauge-scale-container"],
					"markerValue": "ColorContainer",
					"items": []
				}
			},

			{
				"operation": "insert",
				"name": "ColorPreviewContainer",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"index": 2,
				"values": {
					"id": "ColorPreviewContainer",
					"selectors": {"wrapEl": "#ColorPreviewContainer"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["scale-container", "control-width-15"],
					"markerValue": "ColorPreviewContainer",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PreviewLabelContainer",
				"parentName": "ColorPreviewContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"id": "PreviewLabelContainer",
					"selectors": {"wrapEl": "#PreviewLabelContainer"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["label-wrap"],
					"markerValue": "PreviewLabelContainer",
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "PreviewContainer",
				"parentName": "ColorPreviewContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"id": "PreviewContainer",
					"selectors": {"wrapEl": "#PreviewContainer"},
					"itemType": this.Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["gauge-scale-container"],
					"markerValue": "PreviewContainer",
					"items": []
				}
			},
			{
				"operation": "insert",
				"index": 1,
				"name": "MinPreviewIcon",
				"parentName": "PreviewContainer",
				"propertyName": "items",
				"values": {
					"id": "MinPreviewIcon",
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"imageConfig": {"bindTo": "getMinPreviewImageConfig"},
					"classes": {"wrapperClass": ["color-preview-icon"]},
					"markerValue": "MinPreviewIcon",
					"selectors": {"wrapEl": "#MinPreviewIcon"},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
				}
			},
			{
				"operation": "insert",
				"index": 2,
				"name": "MiddlePreviewIcon",
				"parentName": "PreviewContainer",
				"propertyName": "items",
				"values": {
					"id": "MiddlePreviewIcon",
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"imageConfig": {"bindTo": "getMiddlePreviewImageConfig"},
					"classes": {"wrapperClass": ["color-preview-icon"]},
					"markerValue": "MiddlePreviewIcon",
					"selectors": {"wrapEl": "#MiddlePreviewIcon"},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
				}
			},
			{
				"operation": "insert",
				"index": 3,
				"name": "MaxPreviewIcon",
				"parentName": "PreviewContainer",
				"propertyName": "items",
				"values": {
					"id": "MaxPreviewIcon",
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"imageConfig": {"bindTo": "getMaxPreviewImageConfig"},
					"classes": {"wrapperClass": ["color-preview-icon"]},
					"markerValue": "MaxPreviewIcon",
					"selectors": {"wrapEl": "#MaxPreviewIcon"},
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT
				}
			},
			{
				"operation": "insert",
				"name": "PaletteColorMinInv",
				"parentName": "ColorContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"wrapClass": ["color-select-enum"],
					"bindTo": "PaletteColorMax",
					"labelConfig": {
						"visible": false
					},
					"visible": {
						"bindTo": "orderDirection",
						"bindConfig": {
							"converter": "invertColor"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleList"
						},
						"list": {
							"bindTo": "minStyleList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "PaletteColorMin",
				"parentName": "ColorContainer",
				"propertyName": "items",
				"index": 1,
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"wrapClass": ["color-select-enum"],
					"bindTo": "PaletteColorMin",
					"labelConfig": {
						"visible": false
					},
					"visible": {
						"bindTo": "orderDirection",
						"bindConfig": {
							"converter": "revertColor"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleList"
						},
						"list": {
							"bindTo": "minStyleList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "PaletteColorMiddle",
				"parentName": "ColorContainer",
				"propertyName": "items",
				"index": 2,
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"wrapClass": ["color-select-enum"],
					"bindTo": "PaletteColorMiddle",
					"labelConfig": {
						"visible": false
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleList"
						},
						"list": {
							"bindTo": "middleStyleList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "PaletteColorMaxInv",
				"parentName": "ColorContainer",
				"propertyName": "items",
				"index": 3,
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"wrapClass": ["color-select-enum"],
					"bindTo": "PaletteColorMin",
					"labelConfig": {
						"visible": false
					},
					"visible": {
						"bindTo": "orderDirection",
						"bindConfig": {
							"converter": "invertColor"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleList"
						},
						"list": {
							"bindTo": "maxStyleList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "PaletteColorMax",
				"parentName": "ColorContainer",
				"propertyName": "items",
				"index": 3,
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"wrapClass": ["color-select-enum"],
					"bindTo": "PaletteColorMax",
					"labelConfig": {
						"visible": false
					},
					"visible": {
						"bindTo": "orderDirection",
						"bindConfig": {
							"converter": "revertColor"
						}
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleList"
						},
						"list": {
							"bindTo": "maxStyleList"
						}
					}
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
			},
			{
				"operation": "remove",
				"name": "ScaleOrderDirectionIcon",
			}
		]
	};
});
