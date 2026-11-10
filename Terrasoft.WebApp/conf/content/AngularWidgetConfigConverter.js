Terrasoft.configuration.Structures["AngularWidgetConfigConverter"] = {innerHierarchyStack: ["AngularWidgetConfigConverter"]};
define("AngularWidgetConfigConverter", ["DashboardEnums", "WidgetEnums", 
	"WidgetConfigConverter", "ESQMetadataConverter"], function() {

	Ext.define("Terrasoft.configuration.AngularWidgetConfigConverter", {
		extend: "Terrasoft.core.BaseObject",
		alternateClassName: "Terrasoft.AngularWidgetConfigConverter",

		statics: {

			/**
			 * @private
			 */
			_angularToExtSeriesTypeMapping: {
				'area': 'areaspline',
				'bar': 'column',
				'doughnut': 'pie',
				'horizontal-bar': 'bar',
				'line': 'line',
				'scatter': 'scatter',
				'spline': 'spline',
				'tsfunnel': 'funnel',
			},

			/**
			 * @param {String} angularSeriesType
			 * @return {String|undefined}
			 * @private
			 */
			_getExtSeriesType: function(angularSeriesType) {
				if (angularSeriesType === "waterfall"
						&& Terrasoft.Features.getIsEnabled("EnableAngularChartWidgetWaterfall")) {
					return "waterfall";
				}
				return this._angularToExtSeriesTypeMapping[angularSeriesType];
			},

			/**
			 * @param {AngularIndicatorWidgetConfig} angularConfig
			 * @return {ExtIndicatorWidgetConfig}
			 */
			toExtIndicatorWidgetConfig: function(angularConfig) {
				if (!angularConfig) {
					return {};
				}
				const textConfig = angularConfig.text || {};
				const dataProvidingConfig = angularConfig.data?.providing || {};
				return {
					...this._toExtIndicatorFiltersConfig(dataProvidingConfig.filters),
					...this._toExtIndicatorAggregationConfig(dataProvidingConfig.aggregation),
					dataProvidingAttribute: dataProvidingConfig.attribute,
					sectionBindingColumn: dataProvidingConfig?.sectionBindingColumn?.path,
					caption: angularConfig.title,
					style: angularConfig.layout?.color,
					icon: angularConfig.layout?.icon,
					border: angularConfig.layout?.border,
					indicatorTheme: angularConfig.theme,
					entitySchemaName: dataProvidingConfig.schemaName,
					format: this._toExtIndicatorFormat(angularConfig),
					fontStyle: textConfig.fontSizeMode,
					dataSourceConfig: angularConfig?.dataSourceConfig,
					dependencies: dataProvidingConfig.dependencies,
					hierarchyConfig: dataProvidingConfig.hierarchyConfig
				};
			},

			/**
			 * @private
			 */
			_toExtGaugeThresholdsConfig: function(angularConfig) {
				let middleFrom, middleTo, minColor, middleColor, maxColor;
				const thresholdsKeys = Object.keys(angularConfig?.thresholds || {}).sort((a, b) => a - b) || {};
				const widgetColors = Object.values(Terrasoft.WidgetEnums.WidgetColor);
				const swapColor = angularConfig?.orderDirection === Terrasoft.OrderDirection.DESC;
				middleFrom = Number(thresholdsKeys[1]) || undefined;
				middleTo = Number(thresholdsKeys[2]) || undefined;
				minColor = thresholdsKeys[0] && angularConfig?.thresholds[thresholdsKeys[0]]
					? widgetColors.find(e => e.code === angularConfig?.thresholds[thresholdsKeys[swapColor? 3: 0]]?.color)
					: undefined;
				middleColor = thresholdsKeys[1] && angularConfig?.thresholds[thresholdsKeys[1]]
					? widgetColors.find(e => e.code === angularConfig?.thresholds[thresholdsKeys[1]].color)
					: undefined;
				maxColor = thresholdsKeys[3] && angularConfig?.thresholds[thresholdsKeys[3]]
					? widgetColors.find(e => e.code === angularConfig?.thresholds[thresholdsKeys[swapColor? 0: 3]]?.color)
					: undefined;
				return {
					min: angularConfig.min,
					middleFrom: middleFrom,
					middleTo: middleTo,
					max: angularConfig.max,
					minColor: minColor,
					middleColor: middleColor,
					maxColor: maxColor,
				};
			},

			/**
			 * @param {AngularGaugeWidgetConfig} angularConfig
			 * @return {ExtGaugeWidgetConfig}
			 */
			toExtGaugeWidgetConfig: function(angularConfig) {
				if (!angularConfig) {
					return {};
				}
				const textConfig = angularConfig.text || {};
				const dataProvidingConfig = angularConfig.data?.providing || {};
				return {
					...this._toExtIndicatorFiltersConfig(dataProvidingConfig.filters),
					...this._toExtIndicatorAggregationConfig(dataProvidingConfig.aggregation),
					dataProvidingAttribute: dataProvidingConfig.attribute,
					sectionBindingColumn: dataProvidingConfig?.sectionBindingColumn?.path,
					caption: angularConfig.title,
					style: angularConfig.layout?.color,
					border: angularConfig.layout?.border,
					gaugeTheme: angularConfig.theme,
					entitySchemaName: dataProvidingConfig.schemaName,
					format: this._toExtIndicatorFormat(angularConfig),
					fontStyle: textConfig.fontSizeMode,
					dataSourceConfig: angularConfig?.dataSourceConfig,
					orderDirection: angularConfig.orderDirection,
					dependencies: dataProvidingConfig.dependencies,
					hierarchyConfig: dataProvidingConfig.hierarchyConfig,
					...this._toExtGaugeThresholdsConfig(angularConfig)
				};
			},

			/**
			 * @param {AngularWidgetConfig} angularWidgetConfig
			 * @return {ExtWidgetConfig}
			 */
			toExtChartWidgetConfig: function(angularWidgetConfig) {
				if (this._isEmpty(angularWidgetConfig)) {
					return {};
				}
				const angularSeries = angularWidgetConfig.series || [];
				const firstSeries = angularSeries[0] || {};
				const filterItems = Terrasoft
					.findValueByPath(firstSeries, "data.providing.filters.filter.items");
				const useEmptyValue = filterItems 
                    && Boolean(filterItems.columnIsNotNullFilter) === false
                    && Boolean(filterItems.initialFilterGroup?.items.columnIsNotNullFilter) === false;
				return {
					...this._toExtOrderConfig(angularWidgetConfig.seriesOrder),
					...this._toExtSeriesConfig(angularSeries.shift()),
					...this._toExtScalesConfig(angularWidgetConfig.scales),
					dataSourceConfig: angularWidgetConfig?.dataSourceConfig,
					caption: angularWidgetConfig.title,
					widgetColor: this._toExtStyleColor(angularWidgetConfig.color),
					widgetTheme: angularWidgetConfig?.theme,
					seriesConfig: angularSeries.map(series => this._toExtSeriesConfig(series)),
					useEmptyValue,
					dateTimeFormat: this._getDateTimeFormat(firstSeries),
					border: angularWidgetConfig.layout?.border
				};
			},

			/**
			 * @param {AngularFunnelWidgetConfig} angularConfig
			 * @return {ExtFunnelWidgetConfig}
			 */
			toExtFunnelWidgetConfig: function(angularConfig) {
				if (!angularConfig) {
					return {};
				}
				return {
					caption: angularConfig.title,
					widgetColor: this._toExtStyleColor(angularConfig?.color),
					widgetTheme: angularConfig?.theme,
					sectionBindingColumn: angularConfig?.sectionBindingColumn?.path,
					entities: angularConfig.entities?.map((entity) => {
						const filters = this._toExtSeriesFilters(entity.filters || {
							filterType: Terrasoft.FilterType.FILTER_GROUP,
							isEnabled: true,
							items: {},
							logicalOperation: Terrasoft.LogicalOperatorType.AND,
							rootSchemaName: entity.schemaName
						});
						return {
							dataSourceConfig: angularConfig?.dataSourceConfig,
							schemaName: entity.schemaName,
							calculatedOperations: entity.calculatedOperations,
							connectedWith: entity.connectedWith,
							filters: JSON.stringify(filters)
						}
					}),
					border: angularConfig.layout?.border
				};
			},

			/**
			 * @param {Object} angularFiltersConfig
			 * @private
			 */
			_toExtIndicatorFiltersConfig: function(angularFiltersConfig) {
				const filterGroup = angularFiltersConfig?.filter;
				const extFilterGroup = filterGroup && this._toExtSeriesFilters(filterGroup);
				return {
					filterData: JSON.stringify(extFilterGroup),
					filterAttributes: angularFiltersConfig?.filterAttributes,
				};
			},

			/**
			 * @param {Object}  angularAggregationConfig
			 * @private
			 */
			_toExtIndicatorAggregationConfig: function(angularAggregationConfig) {
				const aggregationExpression = angularAggregationConfig?.column?.expression || {};
				const aggregationType = aggregationExpression.aggregationType || Terrasoft.AggregationType.COUNT;
				const aggregationColumn = aggregationExpression.functionArgument?.columnPath;
				const aggregationConfig = {
					aggregationType: aggregationType
				};
				if(aggregationType !== Terrasoft.AggregationType.COUNT) {
					aggregationConfig.columnName = aggregationColumn;
					aggregationConfig.aggregationColumn = aggregationColumn;
				}
				return aggregationConfig;
			},

			/**
			 * @param {AngularIndicatorWidgetConfig} 
			 * @private
			 */
			 _toExtIndicatorFormat: function(angularConfig) {
				const textConfig = angularConfig.text || {};
				const textDecorator = textConfig.template || "{0}";
				const labelPosition = textConfig.labelPosition;
				const formattingConfig = angularConfig.data?.formatting || {};
				switch(formattingConfig.type) {
					case "number":
						return {
							textDecorator,
							decimalSeparator: formattingConfig.decimalSeparator,
							decimalPrecision: formattingConfig.decimalPrecision,
							thousandSeparator: formattingConfig.thousandSeparator,
							labelPosition

						};
					case "datetime":
						const dateTimeFromat = formattingConfig.format;
						let convertedDateTimeFormat = dateTimeFromat
							&& Terrasoft.WidgetConfigConverter.convertDateTimeFormat(dateTimeFromat, "moment", "ext");
						if (!dateTimeFromat) {
							let format = Terrasoft.Resources.CultureSettings.dateFormat;
							if (formattingConfig?.time?.display) {
								format += ' ' + Terrasoft.Resources.CultureSettings.timeFormat
							}
							convertedDateTimeFormat = format;
						}
						return {
							textDecorator,
							dateFormat: convertedDateTimeFormat || Terrasoft.Resources.CultureSettings.dateFormat,
							labelPosition
						};
					default:
						return { textDecorator, labelPosition };
				}
			},

			/**
			 * @param {SeriesConfig} angularScales
			 * @private
			 */
			_toExtScalesConfig: function(angularScales) {
				angularScales = angularScales || {};
				return {
					isStackedChart: angularScales.stacked,
					xAxisFormatting: angularScales.xAxis?.formatting,
					yAxisFormatting: angularScales.yAxis?.formatting,
					xAxisDefaultCaption: angularScales.xAxis?.name,
					yAxisDefaultCaption: angularScales.yAxis?.name,
				};
			},

			/**
			 * @param {SeriesConfig} firstSeries
			 * @private
			 */
			_getDateTimeFormat: function(firstSeries) {
				const datePartColumns = firstSeries?.data?.providing?.grouping?.column;
				if (Array.isArray(datePartColumns)) {
					return datePartColumns
						.map(column => {
							for (const [key, value] of Object.entries(Terrasoft.DatePartType)) {
								if (value === column.expression.datePartType) {
									const datePart = key.toLowerCase().split("");
									datePart[0] = datePart[0].toUpperCase();
									return datePart.join("");
								}
							}
						})
						.join(";");
				}
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
			 * @private
			 * @param {SeriesOrderConfig} seriesOrder
			 * @return {{orderBy: String, orderDirection: String}}
			 */
			_toExtOrderConfig: function(seriesOrder) {
				if (!seriesOrder) {
					return {};
				}
				const orderDirection = seriesOrder && seriesOrder.direction === 1
					? Terrasoft.DashboardEnums.ChartOrderDirection.ASCENDING
					: Terrasoft.DashboardEnums.ChartOrderDirection.DESCENDING;
				if (seriesOrder.type === "by-grouping-value") {
					return {
						orderBy: Terrasoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD,
						orderDirection,
					};
				}
				if (seriesOrder.type === "by-aggregation-value") {
					return {
						orderBy: `${Terrasoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN}:${seriesOrder.seriesIndex}`,
						orderDirection,
					};
				}
			},

			/**
			 * @private
			 * @param {SeriesConfig} angularSeries
			 * @return {ExtSeriesConfig}
			 */
			_toExtSeriesConfig: function(angularSeries) {
				if (!angularSeries) {
					return {};
				}
				const dataConfig = angularSeries?.data;
				const dataProvidingConfig = dataConfig?.providing ?? {};
				const aggregationExpression = dataProvidingConfig.aggregation?.column?.expression;
				const aggregationType = aggregationExpression?.aggregationType || Terrasoft.AggregationType.COUNT;
				const aggregationColumn = aggregationExpression?.functionArgument?.columnPath;
				const filterGroup = dataProvidingConfig.filters?.filter;
				const sectionBindingColumnPath = dataProvidingConfig.sectionBindingColumn?.path;
				const extSeries = {
					filterData: filterGroup && JSON.stringify(this._toExtSeriesFilters(filterGroup)),
					format: this._toExtFormat(dataConfig?.formatting),
					func: aggregationType,
					isLegendEnabled: Boolean(angularSeries?.legend?.enabled),
					primaryColumnName: "Id",
					schemaName: dataProvidingConfig.schemaName,
					styleColor: this._toExtStyleColor(angularSeries?.color),
					type: this._getExtSeriesType(angularSeries?.type),
					displayDataLabel: angularSeries?.dataLabel?.display,
					xAxisColumn: this._getXAxisColumn(dataProvidingConfig.grouping?.column),
					yAxisConfig: { position: 0 },
					YAxisCaption: angularSeries.label,
					sectionBindingColumn: sectionBindingColumnPath,
					dataProvidingAttribute: dataProvidingConfig.attribute,
					dependencies: dataProvidingConfig.dependencies,
					filterAttributes: dataProvidingConfig.filters?.filterAttributes,
					hierarchyConfig: dataProvidingConfig.hierarchyConfig,
				};
				if (aggregationType !== Terrasoft.AggregationType.COUNT) {
					extSeries.yAxisColumn = aggregationColumn;
				}
				return extSeries;
			},

			/**
			 * @private
			 * @param {Object} angularNumberFormat
			 * @return {Object}
			 */
			_toExtFormat: function(angularNumberFormat) {
				angularNumberFormat = angularNumberFormat || {};
				return {
					type: 4,
					decimalSeparator: angularNumberFormat.decimalSeparator,
					decimalPrecision: angularNumberFormat.decimalPrecision,
					thousandSeparator: angularNumberFormat.thousandSeparator,
				};
			},

			/**
			 * @param {Object} column
			 * @return {String}
			 * @private
			 */
			_getXAxisColumn: function(column) {
				if (Array.isArray(column)) {
					const firstColumn = [...column].shift();
					return firstColumn?.expression?.functionArgument?.columnPath;
				}
				return column?.expression?.columnPath;
			},

			/**
			 * @param {Object} filterGroup
			 * @return {Object}
			 * @private
			 */
			_toExtSeriesFilters: function(filterGroup) {
				if (this._isEmpty(filterGroup)) {
					return {};
				}
				delete filterGroup?.items?.columnIsNotNullFilter;
                if(filterGroup?.items?.initialFilterGroup){
                    return Terrasoft.ESQMetadataConverter.toExtFilters(filterGroup.items.initialFilterGroup);
                }
				return Terrasoft.ESQMetadataConverter.toExtFilters(filterGroup);
			},

			/**
			 * @param {String} angularStyleColor HEX color
			 * @private
			 */
			_toExtStyleColor: function(angularStyleColor) {
				const colors = Terrasoft.WidgetEnums.WidgetColorSet;
				const defaultColor = colors[0];
				const selectedColor = colors.find(color => color === angularStyleColor);
				return selectedColor || defaultColor;
			}
		},
	});
	return Terrasoft.AngularWidgetConfigConverter;
});


