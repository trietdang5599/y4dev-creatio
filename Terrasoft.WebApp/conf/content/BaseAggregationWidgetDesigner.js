Terrasoft.configuration.Structures["BaseAggregationWidgetDesigner"] = {innerHierarchyStack: ["BaseAggregationWidgetDesigner"], structureParent: "BaseWidgetDesigner"};
define('BaseAggregationWidgetDesignerStructure', ['BaseAggregationWidgetDesignerResources'], function(resources) {return {schemaUId:'546df09a-8caa-4348-8b0d-ecbbc99f3e1e',schemaCaption: "Base designer of widgets with aggregation", parentSchemaName: "BaseWidgetDesigner", packageName: "CrtPlatform7x", schemaName:'BaseAggregationWidgetDesigner',parentSchemaUId:'8c9456fa-46da-4100-94f9-8653274ab717',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("BaseAggregationWidgetDesigner", ["terrasoft"],
function(Terrasoft) {
	return {
		messages: {
			/**
			 * ######## ## ######### StructureExplorer.
			 */
			"StructureExplorerInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * ######## ## ######### ###### ####### # StructureExplorer.
			 */
			"ColumnSelected": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {

			/**
			 * ####### #### #########.
			 */
			aggregationType: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: {
					value: Terrasoft.AggregationType.COUNT,
					displayValue: Terrasoft.Resources.AggregationType.COUNT
				}
			},

			/**
			 * ####### # ######## #########.
			 */
			aggregationColumn: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				entityStructureConfig: {
					useBackwards: false,
					summaryColumnsOnly: true,
					schemaColumnName: "entitySchemaName",
					aggregationTypeParameterName: "aggregationType"
				},
				dependencies: [
					{
						columns: ["aggregationType"],
						methodName: "onAggregationTypeChange"
					}
				]
			},
			
			/**
			 * Format value control visibility.
			 * @protected
			 */
			FormatValueSettingsVisible: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: false
			},
			
			/**
			 * Widget format data value configuration.
			 * @protected
			 */
			format: {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: false,
				value: {
					"thousandSeparator": Terrasoft.Resources.CultureSettings.thousandSeparator,
					"type": Terrasoft.DataValueType.INTEGER,
					"dateFormat": Terrasoft.Resources.CultureSettings.dateFormat
				}
			}
		},
		methods: {

			/**
			 * ########## ###### ########### ####### ###### ####### # ###### ######### #######.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ###### ########### ####### ###### ####### # ###### ######### #######.
			 */
			getWidgetModulePropertiesTranslator: function() {
				var aggregationProperties = {
					aggregationType: "aggregationType",
					aggregationColumn: "aggregationColumn",
					format: "format"
				};
				return Ext.apply(this.callParent(arguments), aggregationProperties);
			},

			/**
			 * ##### ####### ######### ############ #######.
			 * @protected
			 * @virtual
			 */
			clearColumn: function() {
				this.set("aggregationColumn", null);
			},

			/**
			 * ##### ######### ####### ######### ######## #####.
			 * @protected
			 * @virtual
			 */
			onEntitySchemaNameChange: function() {
				if (this.get("moduleLoaded")) {
					this.clearColumn();
				}
				this.callParent(arguments);
			},

			/**
			 * ##### ######### ####### ######### ####### #########.
			 * @protected
			 * @virtual
			 */
			onAggregationTypeChange: function() {
				if (this.get("moduleLoaded")) {
					this.clearColumn();
				}
			},

			/**
			 * ##### ########### ######### ############ #######.
			 * @private
			 * @param {Object} value ########.
			 * @return {Boolean} ####### ######### ############ #######.
			 */
			aggregationColumnVisibilityConverter: function(value) {
				var entitySchema = this.get("entitySchemaName");
				var allowedAggregationTypes = [
					Terrasoft.AggregationType.SUM,
					Terrasoft.AggregationType.MAX,
					Terrasoft.AggregationType.MIN,
					Terrasoft.AggregationType.AVG
				];
				return entitySchema && value && value.value &&
					Terrasoft.contains(allowedAggregationTypes, value.value);
			},

			/**
			 * ##### ######### ######## #########.
			 * @protected
			 * @virtual
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("aggregationColumn", function(value) {
					var invalidMessage = "";
					var isVisible = this.aggregationColumnVisibilityConverter(this.get("aggregationType"));
					if (isVisible && !value) {
						invalidMessage = Terrasoft.Resources.BaseViewModel.columnRequiredValidationMessage;
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				});
			},

			/**
			 * ########## ###### ##### #########.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ###### ##### #########.
			 */
			getAggregationTypeDefaultConfig: function() {
				var aggregationTypeDefaultConfig = {};
				Terrasoft.each(Terrasoft.AggregationType, function(typeValue, typeName) {
					if (typeValue === Terrasoft.AggregationType.NONE) {
						return;
					}
					aggregationTypeDefaultConfig[typeValue] = {
						value: typeValue,
						displayValue: Terrasoft.Resources.AggregationType[typeName]
					};
				}, this);
				return aggregationTypeDefaultConfig;
			},

			/**
			 * ######### ######### ##### ####### #########.
			 * @protected
			 * @virtual
			 * @param {String} filter ###### ##########.
			 * @param {Terrasoft.Collection} list ######.
			 */
			prepareAggregationTypesList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getAggregationTypeDefaultConfig());
			},

			/**
			 * ########## ###### ######## ####### #########.
			 * @protected
			 * @virtual
			 * @param {Number} aggregationTypeValue ### #########.
			 * @return {Object} ########## ###### ######## ####### #########.
			 */
			getAggregationTypeLookupValue: function(aggregationTypeValue) {
				var aggregationTypeDefaultConfig = this.getAggregationTypeDefaultConfig();
				aggregationTypeValue = (Ext.isNumber(aggregationTypeValue) || aggregationTypeValue.match(/\d+/g))
					? aggregationTypeValue
					: Terrasoft.AggregationType[aggregationTypeValue.toUpperCase()];
				return aggregationTypeDefaultConfig[aggregationTypeValue];
			},

			/**
			 * @inheritdoc Terrasoft.BaseWidgetDesigner#setAttributeDisplayValue
			 * ############ ######## ### ####### #### #########.
			 * @protected
			 * @overridden
			 */
			setAttributeDisplayValue: function(propertyName, propertyValue) {
				if (propertyName === "aggregationType") {
					var aggregationTypeLookupValue =
						this.getAggregationTypeLookupValue(propertyValue);
					this.set(propertyName, aggregationTypeLookupValue);
				} else {
					this.callParent(arguments);
				}
			},
			
			/**
			 * ########## ### ###### ######## ##########.
			 * @protected
			 * @virtual
			 * @return {Terrasoft.DataValueType} ########## ### ###### ######## ##########.
			 */
			getValueDataValueType: function() {
				var result = Terrasoft.DataValueType.TEXT;
				var aggregationType = this.get("aggregationType");
				var columnDataValueType = this.get("aggregationColumn");
				var format = this.get("format");
				if (aggregationType && (aggregationType.value === Terrasoft.AggregationType.COUNT)) {
					result = format && format.decimalPrecision > 0 ? Terrasoft.DataValueType.FLOAT : Terrasoft.DataValueType.INTEGER;
				} else if (!this.Ext.isEmpty(columnDataValueType)) {
					result = columnDataValueType.dataValueType;
				}
				return result;
			},
			
			/**
			 * ########## ###### ######## ### ########## ##############.
			 * @protected
			 * @virtual
			 * @return {String} ########## ###### ######## ### ########## ##############.
			 */
			getFormatValueTemplate: function() {
				var result;
				var format = this.get("format");
				var dataValueType = this.getValueDataValueType();
				if (format) {
					format.type = dataValueType;
				}
				switch (dataValueType) {
					case Terrasoft.DataValueType.INTEGER:
					case Terrasoft.DataValueType.FLOAT:
					case Terrasoft.DataValueType.MONEY:
						var numberTemplate = 1000000.00;
						result = Terrasoft.getFormattedNumberValue(numberTemplate, format || {
							type: Terrasoft.DataValueType.INTEGER
						});
						break;
					case Terrasoft.DataValueType.TIME:
					case Terrasoft.DataValueType.DATE_TIME:
					case Terrasoft.DataValueType.DATE:
						var dateTemplate = new Date();
						var dateFormat = format.dateFormat || Terrasoft.Resources.CultureSettings.dateFormat;
						result = this.Ext.Date.format(dateTemplate, dateFormat);
						break;
				}
				return result;
			},
			
			/**
			 * ##### ######## ########### #### ######### #######.
			 * @protected
			 * @virtual
			 */
			openFormatSettings: function() {
				var dataValueType = this.getValueDataValueType();
				var formatSettingConfig = this.getFormatSettingsConfig(dataValueType);
				Terrasoft.utils.inputBox(
						this.get("Resources.Strings.FormatLabel"),
						this.onFormatSettingsClose,
						["yes", "cancel"],
						this,
						formatSettingConfig,
						{ defaultButton: 0 }
				);
			},
			
			/**
			 * Returns text decoration control configuration.
			 * @protected
			 * @returns {Object} Text decoration control configuration.
			 */
			getTextdecoratorConfig: function() {
				return {};
			},
			
			/**
			 * ########## ###### ######### ########### #### ######### #######.
			 * @protected
			 * @virtual
			 * @param {Terrasoft.DataValueType} dataValueType ### ###### ##########.
			 * @return {Object} ########## ###### ######### ########### #### ######### #######.
			 */
			getFormatSettingsConfig: function(dataValueType) {
				var format = this.get("format") || {};
				var config = this.getTextdecoratorConfig();
				var decimalPrecision = format.decimalPrecision;
				if(!decimalPrecision && decimalPrecision !== 0) {
					decimalPrecision = this.getDefaultDecimalPrecisionValue(format.type);
				}
				switch (dataValueType) {
					case Terrasoft.DataValueType.INTEGER:
					case Terrasoft.DataValueType.FLOAT:
					case Terrasoft.DataValueType.MONEY:
						var numberFormatConfig = {
							decimalPrecision: {
								dataValueType: Terrasoft.DataValueType.INTEGER,
								caption: this.get("Resources.Strings.FormatDecimalPrecision"),
								value: decimalPrecision,
								description: this.get("Resources.Strings.FormatDecimalPrecisionDescription")
							}
						};
						this.Ext.apply(config, numberFormatConfig);
						break;
					case Terrasoft.DataValueType.TIME:
					case Terrasoft.DataValueType.DATE_TIME:
					case Terrasoft.DataValueType.DATE:
						var dateFormat = format.dateFormat;
						var dateFormatConfig = {
							dateFormatWithTime: {
								dataValueType: Terrasoft.DataValueType.BOOLEAN,
								caption: this.get("Resources.Strings.FormatDateTime"),
								value: dateFormat && (dateFormat !== Terrasoft.Resources.CultureSettings.dateFormat),
								description: this.get("Resources.Strings.FormatDateTimeDescription")
								
							}
						};
						this.Ext.apply(config, dateFormatConfig);
						break;
				}
				return config;
			},

			/**
			 * Returns default decimal precision value.
			 * @protected
			 * @param {Terrasoft.DataValueType} type Formatting column type.
			 * @returns {Number} Default decimal precision value.
			 */
			getDefaultDecimalPrecisionValue: function(type) {
				const hasDigits = type === Terrasoft.DataValueType.FLOAT 
				|| type === Terrasoft.DataValueType.MONEY;

				return hasDigits ? 2 : 0;
			},
			
			/**
			 * ##### ######### ######## ########### #### ######### #######.
			 * @protected
			 * @virtual
			 * @param {String} returnCode ### ######## ####.
			 * @param {Object} controlData ###### ######### ######### ##########.
			 */
			onFormatSettingsClose: function(returnCode, controlData) {
				if (returnCode === Terrasoft.MessageBoxButtons.YES.returnCode) {
					var format = {};
					Terrasoft.each(controlData, function(property, propertyName) {
						var propertyValue = property.value;
						if (propertyName === "textDecorator") {
							format[propertyName] = propertyValue || "{0}";
						} else if (propertyName === "dateFormatWithTime") {
							var dateFormatPropertyName = "dateFormat";
							if (propertyValue) {
								var dateFormat = this.Ext.String.format(
										"{0} {1}",
										Terrasoft.Resources.CultureSettings.dateFormat,
										Terrasoft.Resources.CultureSettings.timeFormat
								);
								format[dateFormatPropertyName] = dateFormat;
							} else {
								format[dateFormatPropertyName] = Terrasoft.Resources.CultureSettings.dateFormat;
							}
						} else if (propertyName === "decimalPrecision") {
							var dataValueTypePropertyName = "type";
							format[dataValueTypePropertyName] = (propertyValue)
									? Terrasoft.DataValueType.FLOAT
									: Terrasoft.DataValueType.INTEGER;
							format[propertyName] = propertyValue;
						} else {
							format[propertyName] = propertyValue;
						}
					}, this);
					this.set("format", format);
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "AggregationType",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.ENUM,
					"bindTo": "aggregationType",
					"labelConfig": {
						"caption": { "bindTo": "Resources.Strings.AggregationTypeLabel" }
					},
					"controlConfig": {
						"className": "Terrasoft.ComboBoxEdit",
						"prepareList": { "bindTo": "prepareAggregationTypesList" },
						"list": { "bindTo": "aggregationTypeList" }
					}
				}
			},
			{
				"operation": "insert",
				"name": "aggregationColumn",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODEL_ITEM,
					"generator": "ColumnEditGenerator.generatePartial",
					"labelConfig": {
						"caption": { "bindTo": "Resources.Strings.AggregationColumnLabel" },
						"isRequired": true
					},
					"visible": {
						"bindTo": "aggregationType",
						"bindConfig": { "converter": "aggregationColumnVisibilityConverter"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "FormatValue",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": Terrasoft.DataValueType.TEXT,
					"bindTo": "getFormatValueTemplate",
					"visible": {
						"bindTo": "FormatValueSettingsVisible"
					},
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.FormatLabel"
						}
					},
					"classes": { "wrapClass": ["lookup-only-editable"] },
					"controlConfig": {
						"className": "Terrasoft.TextEdit",
						"readonly": true,
						"rightIconClick": {
							"bindTo": "openFormatSettings"
						},
						"rightIconClasses": ["lookup-edit-right-icon"]
					}
				}
			}
		]
	};
});


