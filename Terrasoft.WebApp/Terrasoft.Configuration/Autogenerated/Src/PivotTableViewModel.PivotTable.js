define("PivotTableViewModel", ["PivotTableViewModelResources", "GridUtilitiesV2",
		"DashboardGridViewModel", "PivotTableUtilities"],
	function(resources) {
		Ext.define("Terrasoft.PivotTableViewModel", {
			extend: "Terrasoft.DashboardGridViewModel",

			/**
			 * List of classes to mix into this class.
			 * @type {Object}.
			 */
			mixins: {
				/**
				 * @class GridUtilities.
				 */
				GridUtilities: "Terrasoft.GridUtilities",

				PivotTableUtilities: "Terrasoft.PivotTableUtilities"
			},

			messages: {
				/**
				 * @message GetFiltersCollection
				 */
				"GetFiltersCollection": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				}
			},

			columns: {
				Options: { 
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT
				},

				TableId: { 
					dataValueType: Terrasoft.DataValueType.TEXT,
				},
				
				DesignPivotRowCount: { 
					dataValueType: Terrasoft.DataValueType.INTEGER,
					value: 50
				}
			},

			/**
			 * @private
			 */
			_initEntitySchema: function(callback, scope) {
				Terrasoft.require([this.$entitySchemaName], function(entitySchema) {
					this.entitySchema = entitySchema;
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * @inheritdoc
			 * @override Terrasoft.DashboardGridViewModel#init
			 */
			init: function() {
				this.sandbox.registerMessages(this.messages);
				this.initResourcesValues(resources);
				var parentMethod = this.getParentMethod(this, arguments);
				this._initEntitySchema(parentMethod, this);
			},

			/**
			 * @inheritdoc
			 * @override Terrasoft.DashboardGridViewModel#initQueryOptions
			 */
			initQueryOptions: function(esq) {
				if (this.$isDesigned) {
					esq.rowCount = this.$DesignPivotRowCount;
				} else {
					esq.rowsOffset = -1;
					esq.rowCount = -1;
				}
			},

			/**
			 * @inheritdoc
			 * @override Terrasoft.DashboardGridViewModel#initQuerySorting
			 */
			initQuerySorting: Terrasoft.emptyFn,

			/**
			 * @inheritdoc
			 * @override Terrasoft.DashboardGridViewModel#addTypeColumns
			 */
			addTypeColumns: Terrasoft.emptyFn,

			/**
			 * @inheritdoc
			 * @override Terrasoft.DashboardGridViewModel#getProfileColumns
			 */
			getProfileColumns: function() {
				const columns = this.callParent(arguments);
				const pivotColumns = this._getPivotSettingsColumns();
				const args = [columns].concat(pivotColumns);
				return Terrasoft.pick.apply(this, args);
			},

			/**
			 * @private
			 */
			_getPivotSettingsColumns: function() {
				const aggregationOptions = this._getPivotAggregationOptions();
				if (!aggregationOptions) {
					return [];
				}
				const rows = aggregationOptions.rows || [];
				const columns = aggregationOptions.columns || [];
				const aggregates = aggregationOptions.aggregates || [];
				const aggregatesColumns = Terrasoft.map(aggregates, function(agg) {
					return agg.aggregationField;
				});
				return Ext.Array.merge(rows, columns, aggregatesColumns);
			},

			/**
			 * @inheritdoc
			 * @override Terrasoft.DashboardGridViewModel#loadGridData
			 */
			loadGridData: function() {
				this.$Options = {
					serializeEsq: this._getPivotEsq(),
					viewOptions: this.getPivotViewOptions(this.$gridConfig),
					aggregationOptions: this._getPivotAggregationOptions()
				};
			},

			/**
			 * @private
			 */
			_getPivotEsq: function() {
				const esq = this.getGridDataInitializedEsq();
				return esq.serialize();
			},

			/**
			 * @private
			 */
			_getPivotAggregationOptions: function() {
				return JSON.parse(this.$pivotTableConfig || {});
			},

			/**
			 * On full screen button event handler.
			 */
			onFullScreenBtnClick: function() {
				var moduleId =  arguments && arguments[3];
				const containerSelector = Ext.String.format("#{0}", moduleId);
				Terrasoft.toggleFullScreenMode(containerSelector);
			},

		});
		return {};
});
