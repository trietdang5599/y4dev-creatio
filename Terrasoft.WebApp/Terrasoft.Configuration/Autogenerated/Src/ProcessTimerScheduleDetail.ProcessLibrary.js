define("ProcessTimerScheduleDetail", ["ProcessTimerScheduleDetailResources", "SortableGridViewModelMixin"],
	function(resources) {
	return {
		mixins: {
			sortableGrid: "Terrasoft.SortableGridViewModelMixin"
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getRowViewModelColumns: function() {
				return {
					Caption: {
						dataValueType: Terrasoft.DataValueType.TEXT
					},
					State: {
						dataValueType: Terrasoft.DataValueType.TEXT
					},
					PreviousFireTime: {
						dataValueType: Terrasoft.DataValueType.DATE_TIME
					},
					NextFireTime: {
						dataValueType: Terrasoft.DataValueType.DATE_TIME
					}
				};
			},

			/**
			 * @private
			 */
			_getRowViewModelValues: function(rowObject) {
				return {
					Caption: rowObject.Caption,
					State: resources.localizableStrings["TimerState" + rowObject.State],
					PreviousFireTime: rowObject.PreviousFireTime && new Date(rowObject.PreviousFireTime),
					NextFireTime: rowObject.NextFireTime && new Date(rowObject.NextFireTime)
				};
			},

			/**
			 * @private
			 */
			_getRowViewModel: function(rowObject) {
				return this.Ext.create("Terrasoft.BaseViewModel", {
					columns: this._getRowViewModelColumns(),
					values: this._getRowViewModelValues(rowObject)
				});
			},

			/**
			 * @private
			 */
			_getRowViewModelId: function(rowObject) {
				return rowObject.UId;
			},

			/**
			 * Provides settings for sorting.
			 * @private
			 */
			_getSortSettingsConfig: function() {
				return {
					columnsToSort: ["Caption", "State", "PreviousFireTime", "NextFireTime"],
					profileKey: this.getProfileKey() + "SortColumns"
				};
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#prepareResponseCollectionItem
			 * @overriden
			 */
			prepareResponseCollectionItem: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#onGridDataLoaded
			 * @overriden
			 */
			onGridDataLoaded: function(timerEventsInfo) {
				const result = new Terrasoft.Collection();
				timerEventsInfo.forEach(function(timerEvent) {
					result.add(this._getRowViewModelId(timerEvent), this._getRowViewModel(timerEvent));
				}, this);
				this.callParent([{success: true, collection: result}]);
			},

			/**
			 * @inheritdoc Terrasoft.BaseGridDetailV2#editCurrentRecord
			 * @override
			 */
			editCurrentRecord: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#initCanLoadMoreData
			 * @override
			 */
			initCanLoadMoreData: Terrasoft.emptyFn,

			/**
			 * @inheritdoc Terrasoft.GridUtilities#sortColumn
			 * @override
			 */
			sortColumn: function(index) {
				this.sortByColumn(index);
			},

			/**
			 * @inheritdoc Terrasoft.SortableGridViewModelMixin#getDataCollection
			 * @override
			 */
			getDataCollection: function() {
				return this.$Collection;
			},

			//endregion

			// region Methods: Public

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#loadGridData
			 * @overriden
			 */
			loadGridData: function() {
				Terrasoft.AjaxProvider.request({
					url: "../ServiceModel/ProcessEngineService.svc/GetTimerEventsInfo",
					method: "POST",
					scope: this,
					jsonData: JSON.stringify(this.$MasterRecordId),
					callback: function(status, result, response) {
						if (result) {
							const json = JSON.parse(response.responseText);
							this.onGridDataLoaded(json.timerEventsInfo);
						}
					}
				});
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						this.initSortingSettings(this._getSortSettingsConfig(), callback, scope);
					}, this
				]);
			}

			// endregion

		},
		diff: [
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "Caption",
								"bindTo": "Caption",
								"caption": resources.localizableStrings.ColumnCaption,
								"position": {"column": 0, "colSpan": 6}
							},
							{
								"name": "State",
								"bindTo": "State",
								"caption": resources.localizableStrings.ColumnState,
								"position": {"column": 6, "colSpan": 6}
							},
							{
								"name": "PreviousFireTime",
								"bindTo": "PreviousFireTime",
								"caption": resources.localizableStrings.ColumnPreviousFireTime,
								"position": {"column": 12, "colSpan": 6}
							},
							{
								"name": "NextFireTime",
								"bindTo": "NextFireTime",
								"caption": resources.localizableStrings.ColumnNextFireTime,
								"position": {"column": 18, "colSpan": 6}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {},
						"items": []
					},
					"isEmptyCaption": resources.localizableStrings.EmptyGrid
				}
			},
			{
				"operation": "remove",
				"name": "ToolsButton"
			}
		]
	};
});