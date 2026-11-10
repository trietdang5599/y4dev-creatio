Terrasoft.configuration.Structures["PivotTableUtilities"] = {innerHierarchyStack: ["PivotTableUtilities"]};
define("PivotTableUtilities", [], function() {
	Ext.define("Terrasoft.configuration.mixins.PivotTableUtilities", {
		alternateClassName: "Terrasoft.PivotTableUtilities",

		statics: {
			/**
			 * Validate pivot table config.
			 * @param {Object} config 
			 */
			validatePivotConfig: function(config) {
				if (!config) {
					return false;
				}
				const hasRows = !Terrasoft.isEmpty(config.rows);
				const hasAggregates = !Terrasoft.isEmpty(config.aggregates);
				return hasRows && hasAggregates;
			},

			/**
			 * Returns true when pivot table is enabled.
			 * Check features and browsers.
			 */
			isEnabledPivotTable: function() {
				const isAvailableBrowser = !Ext.isIEOrEdge;
				// TODO. CRM-52673 Oracle 12+
				const isEnabledOffsetFetch = Terrasoft.useOffsetFetchPaging;
				return isAvailableBrowser && isEnabledOffsetFetch;
			},

			/**
			 * Returns pivot table designer diff configuration.
			 */
			getPivotTableDesignerViewConfig: function() {
				const isEnabledPivotTable = Terrasoft.PivotTableUtilities.isEnabledPivotTable();
				return isEnabledPivotTable
					? {
						"itemType": Terrasoft.ViewItemType.COMPONENT,
						"className": "Terrasoft.PivotTableDesigner",
						"options": {"bindTo": "PivotTableDesignerOptions"},
						"optionsChanged": {"bindTo": "onPivotTableOptionsChanged"}
					}
					: {
						"itemType": Terrasoft.ViewItemType.CONTAINER,
						"items": []
					};
			}
		},

		/**
		 * Generates default pivot table configuration.
		 * @protected
		 * @returns {Object} Default pivot table config.
		 */
		getDefaultPivotTableConfig: function() {
			return {
				rows: [],
				columns: [],
				aggregates: []
			}
		},

		/**
		 * Returns pivot table view options.
		 * @protected
		 * @param {Object} gridConfig Dashboard widget grid config.
		 */
		getPivotViewOptions: function(gridConfig) {
			gridConfig = gridConfig || {};
			const gridColumnsConfigs = gridConfig.items || [];
			const fieldsOptions = this._getPivotFieldsOptions(gridColumnsConfigs);
			return {
				fieldsOptions: fieldsOptions
			};
		},

		/**
		 * @private
		 */
		_getPivotFieldsOptions: function(gridColumnsConfigs) {
			return Terrasoft.map(gridColumnsConfigs, function(columnConfig) {
				return { 
					fieldId: columnConfig.bindTo, 
					fieldCaption: columnConfig.caption,
					fieldType: columnConfig.dataValueType,
					fieldExpression: columnConfig.expression || this._getExpression(columnConfig),
				};
			}, this);
		},

		/**
		 * @private
		 */
		_getExpression: function(columnConfig) {
			return {
				definitionId: columnConfig.bindTo,
				type: Terrasoft.FormulaExpressionType.OPERAND,
				operandType: Terrasoft.OperandType.COLUMN,
				columnOperandType: columnConfig.aggregationType 
					? Terrasoft.ColumnOperandType.AGGREGATION
					: Terrasoft.ColumnOperandType.SCHEMACOLUMN,
				columnPath: columnConfig.metaPath || columnConfig.bindTo,
				subFilters: columnConfig.serializedFilter,
				aggregationType: columnConfig.aggregationType,
				dataType: columnConfig.dataValueType
			}
		}
	});
	return Ext.create("Terrasoft.PivotTableUtilities");
});


