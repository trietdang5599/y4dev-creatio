Terrasoft.configuration.Structures["ExtWidgetConfigConverter"] = {innerHierarchyStack: ["ExtWidgetConfigConverter"]};
define("ExtWidgetConfigConverter", ["DashboardEnums", "WidgetEnums", 
	"WidgetConfigConverter", "ESQMetadataConverter"], function() {

	//#region: Types AngularWidgetConfig

	/**
	 * @typedef ThousandAbbreviation
	 * @type {Object}
	 * @property {Boolean} enabled
	 */

	/**
	 * @typedef NumberFormat
	 * @type {Object}
	 * @property {String} decimalSeparator
	 * @property {Number} decimalPrecision
	 * @property {String} thousandSeparator
	 * @property {ThousandAbbreviation} thousandAbbreviation
	 */

	/**
	 * @typedef StringFormat
	 * @type {Object}
	 * @property {Number} maxLineLength
	 * @property {Number} maxLinesCount
	 * @property {String | RegExp} wordSeparator
	 * @property {String} wordConnector
	 */

	/**
	 * @typedef DateFormat
	 * @type {Object}
	 * @property {String} format
	 */
	 
	 /**
	 * @typedef WidgetDataProvidingConfig
	 * @type {Object}
	 * @property {String} schemaName
	 * @property {Object} aggregation
	 * @property {Object} [filters]
	 * @property {Object} [filters.filter]
	 */
	 
	 /**
	 * @typedef WidgetDataConfig
	 * @type {Object}
	 * @property {WidgetDataProvidingConfig} providing
	 * @property {NumberFormat} formatting
	 */

	/**
	 * @typedef SeriesDataProvidingConfig
	 * @type {Object}
	 * @property {String} schemaName
	 * @property {Number} rowCount
	 * @property {Object} grouping
	 * @property {Object} aggregation
	 * @property {Object} [filters]
	 * @property {Object} [filters.filter]
	 */

	/**
	 * @typedef SeriesDataConfig
	 * @type {Object}
	 * @property {SeriesDataProvidingConfig} providing
	 * @property {NumberFormat} formatting
	 */

	/**
	 * @typedef SeriesConfig
	 * @type {Object}
	 * @property {String} type - area | bar | line | etc.
	 * @property {String} label
	 * @property {Boolean} isLegendEnabled
	 * @property {SeriesDataConfig} data
	 */

	/**
	 * @typedef SeriesOrderConfig
	 * @type {Object}
	 * @property {String} type - AggregationColumn | GroupByColumn
	 * @property {Number} direction - None:0, Asc:1, Desc: 2
	 * @property {Number} [seriesIndex]
	 */

	/**
	 * @typedef Axis
	 * @type {Object}
	 * @property {String} name
	 * @property {NumberFormat | StringFormat} formatting
	 */

	/**
	 * @typedef Scale
	 * @type {Object}
	 * @property {Boolean} stacked
	 * @property {Axis} xAxis
	 * @property {Axis} yAxis
	 */

	/**
	 * @typedef AngularChartWidgetConfig
	 * @type {Object}
	 * @property {String} title
	 * @property {Array<SeriesConfig>} series
	 * @property {SeriesOrderConfig} seriesOrder
	 * @property {Scale} scales
	 */

	/**
	 * @typedef AngularIndicatorWidgetConfig
	 * @type {Object}
	 * @property {String} title
	 * @property {WidgetDataConfig} data
	 * @property {IndicatorText} text
	 * @property {IndicatorLayout} layout
	 * @property {Boolean} hideTitle
	 */

	/**
	 * @typedef AngularGaugeWidgetConfig
	 * @type {Object}
	 * @property {String} title
	 * @property {WidgetDataConfig} data
	 * @property {IndicatorText} text
	 * @property {IndicatorLayout} layout
	 * @property {Number} min
	 * @property {Number} max
	 * @property {Number} orderDirection
	 * @property {String} theme
	 */

	/**
	 * @typedef AngularFunnelWidgetConfig
	 * @type {Object}
	 * @property {String} title
	 * @property {String} color
	 * @property {Object} entities
	 */

	/**
	 * @typedef IndicatorText
	 * @type {Object}
	 * @property {String} color
	 * @property {String} template
	 * @property {String} metricMacros
	 * @property {String} fontSizeMode - 'medium' | 'large'
	 */

	/**
	 * @typedef IndicatorLayout
	 * @type {Object}
	 * @property {String} color
	 */

	//#endregion

	//#region: Types ExtWidgetConfig

	/**
	 * @typedef ExtSeriesConfig
	 * @type {Object}
	 * @property {String} filterData
	 * @property {Object} format
	 * @property {Number} func
	 * @property {Boolean} isLegendEnabled
	 * @property {String} primaryColumnName - example: Id
	 * @property {String} schemaName
	 * @property {String} styleColor - example: widget-green
	 * @property {String} type - line | bar | etc.
	 * @property {String} xAxisColumn - example: Account
	 * @property {String} [yAxisColumn] - example: Age (if SUM function)
	 * @property {Object} yAxisConfig
	 * @property {String} [XAxisCaption]
	 * @property {String} [YAxisCaption]
	 */

	/**
	 * @typedef ExtChartWidgetConfig
	 * @type {Object}
	 * @property {String} caption
	 * @property {String} orderBy - GroupByField | ChartEntityColumn:[seriesIndex]
	 * @property {String} orderDirection - Ascending | Descending
	 * @property {Boolean} useEmptyValue
	 * @property {Boolean} isStackedChart
	 * @property {String} yAxisDefaultCaption
	 * @property {String} xAxisDefaultCaption
	 * @property {Array<ExtSeriesConfig>} seriesConfig
	 * @property {String} filterData
	 * @property {Object} format
	 * @property {Number} func
	 * @property {Boolean} isLegendEnabled
	 * @property {String|null} dateTimeFormat - example: Day;Month;Year
	 * @property {String} primaryColumnName - example: Id
	 * @property {String} schemaName
	 * @property {String} styleColor - example: widget-green
	 * @property {String} type - line | bar | etc.
	 * @property {String} xAxisColumn - example: Account
	 * @property {String} [yAxisColumn] - example: Age (if SUM function)
	 * @property {Object} yAxisConfig
	 * @property {String} [XAxisCaption]
	 * @property {String} [YAxisCaption]
	 */

	/**
	 * @typedef ExtIndicatorWidgetConfig
	 * @type {Object}
	 * @property {String} caption
	 * @property {String} filterData
	 * @property {String} columnName
	 * @property {Number} aggregationType
	 * @property {String} entitySchemaName
	 * @property {Object} format
	 * @property {String} style
	 * @property {String} fontStyle
	 */	
	
	/**
	 * @typedef ExtGaugeWidgetConfig
	 * @type {Object}
	 * @property {String} caption
	 * @property {String} filterData
	 * @property {String} columnName
	 * @property {Number} aggregationType
	 * @property {String} entitySchemaName
	 * @property {Object} format
	 * @property {String} style
	 * @property {String} fontStyle
	 */

	/**
	 * @typedef ExtFunnelWidgetConfig
	 * @type {Object}
	 * @property {String} caption
	 * @property {String} styleColor
	 * @property {Object} entities
	 */

	//#endregion

	Ext.define("Terrasoft.configuration.ExtWidgetConfigConverter", {
		extend: "Terrasoft.core.BaseObject",
		alternateClassName: "Terrasoft.ExtWidgetConfigConverter",

		statics: {

			/**
			 * private
			 */
			_extToAngularSeriesTypeMapping: {
				'areaspline': 'area',
				'column': 'bar',
				'pie': 'doughnut',
				'bar': 'horizontal-bar',
				'line': 'line',
				'scatter': 'scatter',
				'spline': 'spline',
				'funnel': 'tsfunnel',
			},

			/**
			 * @param {String} extSeriesType
			 * @return {String|undefined}
			 * @private
			 */
			_getAngularSeriesType: function(extSeriesType) {
				if (extSeriesType === "waterfall"
						&& Terrasoft.Features.getIsEnabled("EnableAngularChartWidgetWaterfall")) {
					return "waterfall";
				}
				return this._extToAngularSeriesTypeMapping[extSeriesType];
			},

			/**
			 * @param {ExtIndicatorWidgetConfig} extWidgetConfig
			 * @return {AngularIndicatorWidgetConfig}
			 */
			toAngularIndicatorWidgetConfig: function(extWidgetConfig) {
				return {
					title: extWidgetConfig.caption,
					data: {
						providing: {
							attribute: extWidgetConfig.dataProvidingAttribute,
							dependencies: extWidgetConfig.dependencies,
							schemaName: extWidgetConfig.entitySchemaName,
							...this._toAngularAggregation({
								aggregationType: extWidgetConfig.aggregationType,
								columnPath: extWidgetConfig.columnName || "Id"
							}),
							...this._toAngularFilters({
								schemaName: extWidgetConfig.entitySchemaName,
								filterData: extWidgetConfig.filterData,
								filterAttributes: extWidgetConfig.filterAttributes,
							}),
							sectionBindingColumn: {path: extWidgetConfig?.sectionBindingColumn},
							hierarchyConfig: extWidgetConfig.hierarchyConfig
						},
						formatting: this._toAngularFormat(extWidgetConfig.format),
					},
					dataSourceConfig: extWidgetConfig?.dataSourceConfig,
					text: {
						template: extWidgetConfig.format?.textDecorator || '{0}',
						metricMacros: '{0}',
						fontSizeMode: extWidgetConfig.fontStyle,
						labelPosition: extWidgetConfig.format?.labelPosition
					},
					layout: {
						color: extWidgetConfig.style,
						icon: extWidgetConfig.icon,
						border: extWidgetConfig.border
					},
					theme: extWidgetConfig.indicatorTheme
				};
			},			
			
			/**
			 * @param {ExtGaugeWidgetConfig} extWidgetConfig
			 * @return {AngularGaugeWidgetConfig}
			 */
			toAngularGaugeWidgetConfig: function(extWidgetConfig) {
				return {
					title: extWidgetConfig.caption,
					data: {
						providing: {
							attribute: extWidgetConfig.dataProvidingAttribute,
							dependencies: extWidgetConfig.dependencies,
							schemaName: extWidgetConfig.entitySchemaName,
							...this._toAngularAggregation({
								aggregationType: extWidgetConfig.aggregationType,
								columnPath: extWidgetConfig.aggregationColumn || "Id"
							}),
							...this._toAngularFilters({
								schemaName: extWidgetConfig.entitySchemaName,
								filterData: extWidgetConfig.filterData,
								filterAttributes: extWidgetConfig.filterAttributes,
							}),
							sectionBindingColumn: {path: extWidgetConfig?.sectionBindingColumn},
							hierarchyConfig: extWidgetConfig.hierarchyConfig
						},
						formatting: this._toAngularFormat(extWidgetConfig.format),
					},
					dataSourceConfig: extWidgetConfig?.dataSourceConfig,
					text: {
						template: extWidgetConfig.format?.textDecorator || '{0}',
						metricMacros: '{0}',
						fontSizeMode: extWidgetConfig.fontStyle
					},
					layout: {
						color: extWidgetConfig.style,
						border: extWidgetConfig.border
					},
					theme: extWidgetConfig.gaugeTheme,
					thresholds: extWidgetConfig.thresholds,
					min: extWidgetConfig.min,
					max: extWidgetConfig.max,
					orderDirection: extWidgetConfig.orderDirection
				};
			},

			/**
			 * @param {ExtChartWidgetConfig} extWidgetConfig
			 * @return {AngularChartWidgetConfig}
			 */
			toAngularChartWidgetConfig: function(extWidgetConfig) {
				if (this._isEmpty(extWidgetConfig)) {
					return {};
				}
				const dateTimeFormat = extWidgetConfig.dateTimeFormat;
				const useEmptyValue = extWidgetConfig.useEmptyValue;
				return {
					title: extWidgetConfig.caption,
					color: extWidgetConfig.widgetColor,
					theme: extWidgetConfig.widgetTheme,
					scales: this._toAngularScales(extWidgetConfig),
					series: [
						this._toAngularSeries(extWidgetConfig, { dateTimeFormat, useEmptyValue }), // for first (in root) series
						...extWidgetConfig.seriesConfig.map(
							extSeries => this._toAngularSeries(extSeries, { dateTimeFormat, useEmptyValue }),
						),
					],
					seriesOrder: this._toAngularSeriesOrder(extWidgetConfig),
					layout: {
						border: extWidgetConfig.border
					}
				};
			},

			/**
			 * @param {ExtFunnelWidgetConfig} extWidgetConfig
			 * @return {AngularFunnelWidgetConfig}
			 */
			toAngularFunnelWidgetConfig: function(extWidgetConfig) {
				if (this._isEmpty(extWidgetConfig)) {
					return {};
				}
				return {
					title: extWidgetConfig.caption,
					color: extWidgetConfig.widgetColor,
					theme: extWidgetConfig.widgetTheme,
					sectionBindingColumn: {path: extWidgetConfig?.sectionBindingColumn},
					entities: extWidgetConfig.entities?.map((entity) => {
						const wrappedFilter = this._toAngularFilters({
							schemaName: entity.schemaName,
							filterData: entity.filters
						});
						return {
							schemaName: entity.schemaName,
							calculatedOperations: entity.calculatedOperations,
							connectedWith: entity.connectedWith,
							filters: wrappedFilter.filters.filter
						}
					}),
					layout: {
						border: extWidgetConfig.border
					}
				};
			},

			/**
			 * @param {Object|null|undefined} val
			 * @return {boolean}
			 * @private
			 */
			_isEmpty: function(val) {
				return Boolean(val) === false || JSON.stringify(val) === JSON.stringify({});
			},

			/**
			 * @param {ExtChartWidgetConfig} extWidgetConfig
			 * @return {Scale}
			 * @private
			 */
			_toAngularScales: function(extWidgetConfig) {
				const defaultNumberFormat = {
					type: 'number',
					thousandAbbreviation: { enabled: true }
				};
				const defaultStringFormat = {
					type: 'string',
					maxLinesCount: 2,
					maxLineLength: 10,
				};
				return {
					stacked: extWidgetConfig.isStackedChart,
					xAxis: {
						name: extWidgetConfig.xAxisDefaultCaption || '',
						formatting: extWidgetConfig.xAxisFormatting || defaultStringFormat
					},
					yAxis: {
						name: extWidgetConfig.yAxisDefaultCaption || '',
						formatting: extWidgetConfig.yAxisFormatting || defaultNumberFormat
					}
				};
			},

			/**
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {Object} options
			 * @param {String|null} options.dateTimeFormat
			 * @param {Boolean} options.useEmptyValue
			 * @return {SeriesConfig}
			 * @private
			 */
			_toAngularSeries: function(seriesConfig, options) {
				const seriesColor = seriesConfig.styleColor;
				const defaultSeriesOptions = this._getDefaultAngularSeriesOptions(seriesConfig, options);
				switch(defaultSeriesOptions.type) {
					case 'area':
					case 'scatter':
					case 'line':
					case 'spline':
					case 'bar':
					case 'waterfall':
					case 'horizontal-bar':
						return {
							color: seriesColor,
							...defaultSeriesOptions,
						};
					case 'pie':
					case 'tsfunnel':
					case 'doughnut':
						return defaultSeriesOptions;
				};
			},

			/**
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {Object} options
			 * @param {String|null} options.dateTimeFormat
			 * @param {Boolean} options.useEmptyValue
			 * @return {SeriesConfig}
			 * @private
			 */
			_getDefaultAngularSeriesOptions: function(seriesConfig, options) {
				return {
					type: this._getAngularSeriesType(seriesConfig.type),
					label: seriesConfig.YAxisCaption || seriesConfig.schemaCaption || seriesConfig.schemaName,
					legend: {
						enabled: Boolean(seriesConfig.isLegendEnabled)
					},
					data: {
						providing: {
							attribute: seriesConfig.dataProvidingAttribute,
							schemaName: seriesConfig.schemaName,
							rowCount: seriesConfig.rowCount || 50,
							dependencies: seriesConfig.dependencies,
							sectionBindingColumn: {path: seriesConfig.sectionBindingColumn},
							hierarchyConfig: seriesConfig.hierarchyConfig,
							...this._toAngularSeriesGrouping(seriesConfig, options.dateTimeFormat),
							...this._toAngularSeriesAggregation(seriesConfig),
							...this._toAngularSeriesFilters(seriesConfig, options.useEmptyValue),
						},
						formatting: seriesConfig.format && this._toAngularNumberFormat(seriesConfig.format),
					},
					dataLabel: {
						display: seriesConfig.displayDataLabel,
					},
				};
			},

			/**
			 * @param {Object} extFormat
			 * @return {Object}
			 * @private
			 */
			 _toAngularFormat(extFormat) {
				switch (extFormat.type) {
					case Terrasoft.DataValueType.INTEGER:
					case Terrasoft.DataValueType.FLOAT:
					case Terrasoft.DataValueType.MONEY:
						return this._toAngularNumberFormat(extFormat);
					case Terrasoft.DataValueType.TIME:
					case Terrasoft.DataValueType.DATE_TIME:
					case Terrasoft.DataValueType.DATE:
						return this._toAngularDateTimeFormat(extFormat);
				}
			},

			/**
			 * @param {Object} extFormat
			 * @return {NumberFormat}
			 * @private
			 */
			_toAngularNumberFormat: function(extFormat) {
				const cultureSettings = Terrasoft.Resources.CultureSettings;
				let decimalPrecision = extFormat.decimalPrecision;
				if(!decimalPrecision && decimalPrecision !== 0) {
					const hasDigits = extFormat.type === Terrasoft.DataValueType.FLOAT 
						|| extFormat.type === Terrasoft.DataValueType.MONEY;

					decimalPrecision = hasDigits ? 2 : 0;
				}
				return {
					type: "number",
					decimalSeparator: extFormat.decimalSeparator || cultureSettings.decimalSeparator,
					decimalPrecision: decimalPrecision,
					thousandSeparator: extFormat.thousandSeparator || cultureSettings.thousandSeparator,
				};
			},

			/**
			 * @param {Object} extFormat
			 * @return {DateFormat}
			 * @private
			 */
			 _toAngularDateTimeFormat: function(extFormat) {
				const extDateTimeFormat = extFormat.dateFormat || Terrasoft.Resources.CultureSettings.dateFormat;
				const isTimeDisplayEnabled = extDateTimeFormat.includes(Terrasoft.Resources.CultureSettings.timeFormat);
				const angularDateTimeFormat = {
					type: "datetime",
					date: {
						display: true,
					},
					time: {
						display: isTimeDisplayEnabled,
					},
				};
				return angularDateTimeFormat;
			},

			/**
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {String|null} dateTimeFormat
			 * @return {Object}
			 * @private
			 */
			_toAngularSeriesGrouping(seriesConfig, dateTimeFormat) {
				if (dateTimeFormat) {
					const dateFunctions = dateTimeFormat.split(";");
					return {
						grouping: {
							column: dateFunctions.map(dateFunction => {
								return {
									isVisible: true,
									expression: {
										functionType: Terrasoft.FunctionType.DATE_PART,
										datePartType: Terrasoft.DatePartType[dateFunction.toUpperCase()],
										expressionType: Terrasoft.ExpressionType.FUNCTION,
										functionArgument: {
											columnPath: seriesConfig.xAxisColumn,
											expressionType: Terrasoft.ExpressionType.SCHEMA_COLUMN,
										},
									},
								};
							}),
							type: "by-date-part",
						},
					};
				}
				return {
					grouping: {
						column: {
							expression: {
								expressionType: Terrasoft.ExpressionType.SCHEMA_COLUMN,
								columnPath: seriesConfig.xAxisColumn,
							},
						},
						type: "by-value",
					},
				};
			},

			/**
			 * @private
			 * @param {ExtChartWidgetConfig} extWidgetConfig
			 * @return {SeriesOrderConfig}
			 */
			_toAngularSeriesOrder: function(extWidgetConfig) {
				const direction =
					extWidgetConfig.orderDirection === Terrasoft.DashboardEnums.ChartOrderDirection.ASCENDING ? 1 : 2;
				if (extWidgetConfig.orderBy === Terrasoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD) {
					return {
						type: "by-grouping-value",
						direction: direction,
					};
				}
				const seriesIndex = extWidgetConfig.orderBy.split(":").pop();
				return {
					type: "by-aggregation-value",
					direction: direction,
					seriesIndex: parseInt(seriesIndex, 10),
				};
			},

			/**
			 * @private
			 * @param {ExtSeriesConfig} seriesConfig
			 * @return {Object}
			 */
			_toAngularSeriesAggregation: function(seriesConfig) {
				return this._toAngularAggregation({
					aggregationType: seriesConfig.func,
					columnPath: seriesConfig.yAxisColumn || seriesConfig.primaryColumnName
				});
			},

			/**
			 * @private
			 * @param {Object} config
			 * @param {Terrasoft.AggregationType} config.aggregationType
			 * @param {String} config.columnPath
			 * @return {Object}
			 */
			_toAngularAggregation: function(config) {
				return {
					aggregation: {
						column: {
							expression: {
								expressionType: Terrasoft.ExpressionType.FUNCTION,
								functionType: Terrasoft.FunctionType.AGGREGATION,
								aggregationType: config.aggregationType,
								aggregationEvalType: this._getAggregationEvalType(config.aggregationType),
								functionArgument: {
									expressionType: Terrasoft.ExpressionType.SCHEMA_COLUMN,
									columnPath: config.columnPath,
								},
							},
						},
					},
				};
			},

			/**
			 * @private
			 * @param {ExtSeriesConfig} seriesConfig
			 * @param {Boolean} useEmptyValue
			 * @return {Object}
			 */
			_toAngularSeriesFilters: function(seriesConfig, useEmptyValue) {
				let filters = this._toAngularFilters(seriesConfig);
				if (!useEmptyValue) {
                    const isNotNullFilter = this._getAngularColumnIsNotNullFilter(seriesConfig.xAxisColumn);
                    if(filters.filters.filter.logicalOperation===Terrasoft.LogicalOperatorType.OR){
                        const config = {
                            schemaName: seriesConfig.schemaName,
                        }
                        const wrapperGroup =  Terrasoft.ESQMetadataConverter.toAngularFilters(config);
                        Object.assign(wrapperGroup.items, {'initialFilterGroup':filters.filters.filter});
                        Object.assign(wrapperGroup.items, isNotNullFilter);
                        filters.filters.filter = wrapperGroup;
                    } else {
                        Object.assign(filters.filters.filter.items, isNotNullFilter);
                    }
				}
				return filters;
			},

			/**
			 * @private
			 * @param {Object} config
			 * @param {String} config.schemaName
			 * @param {String} config.filterData
			 * @param {Array<Object>} config.filterAttributes
			 * @return {Object}
			 */
			_toAngularFilters: function(config) {
				return {
					filters: {
						filter: Terrasoft.ESQMetadataConverter.toAngularFilters(config),
						filterAttributes: config.filterAttributes
					},
				};
			},

			/**
			 * Use empty value filter.
			 * @param {String} columnPath
			 * @return {Object}
			 * @private
			 */
			_getAngularColumnIsNotNullFilter: function(columnPath) {
				return {
					columnIsNotNullFilter: {
						comparisonType: Terrasoft.ComparisonType.IS_NOT_NULL,
						filterType: Terrasoft.FilterType.IS_NULL,
						isEnabled: true,
						isNull: false,
						trimDateTimeParameterToDate: false,
						leftExpression: {
							expressionType: Terrasoft.ExpressionType.SCHEMA_COLUMN,
							columnPath: columnPath,
						},
					},
				};
			},

			/**
			 * @private
			 * @param {Number} aggregationType
			 * @return {Terrasoft.AggregationEvalType}
			 */
			_getAggregationEvalType: function(aggregationType) {
				return aggregationType === Terrasoft.AggregationType.COUNT
					? Terrasoft.AggregationEvalType.DISTINCT
					: Terrasoft.AggregationEvalType.NONE;
			},
		},
	});
	return Terrasoft.ExtWidgetConfigConverter;
});


