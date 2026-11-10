define("HistoryMessageFilesDetail", ["HistoryMessageFilesDetailResources",
	"css!HistoryMessageFilesDetailCSS"], function() {
	return {
		properties: {
			/**
			 * VanillaBox options config.
			 * @protected
			 */
			vanillaboxDefaultConfig: {
				closeButton: false,
				loop: true,
				repositionOnScroll: true
			}
		},
		messages: {
			/**
			 * @message SwitchFilesDetailVisibility
			 * Informs detail with files is need to collapse.
			 */
			"SwitchFilesDetailVisibility": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#getSchemaViewModelContainerId
			 * override
			 */
			getSchemaViewModelContainerId: function() {
				return Ext.String.format("{0}_{1}", this.get("SchemaName"), this.sandbox.id);
			},

			/**
			 * @inheritdoc Terrasoft.FileDetailV2#onRender
			 * override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.setTiledMode();
			},

			/**
			 * @inheritdoc Terrasoft.BaseDetailV2#init
			 * @overridden
			 */
			init: function() {
				this.callParent(arguments);
				var detailInfo = arguments[1] && arguments[1].detailInfo;
				if (detailInfo && detailInfo.additionalFileFilters) {
					this.$AdditionalFileFilters = detailInfo.additionalFileFilters;
				}
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilities#initQueryFilters
			 * @overridden
			 */
			initQueryFilters: function (esq) {
				this.callParent(arguments);
				if (this.$AdditionalFileFilters) {
					this.Terrasoft.each(this.$AdditionalFileFilters, function(filter) {
						esq.filters.add(filter.filterColumnName + "Filter", esq.createColumnFilterWithParameter(
							filter.comparisonType, filter.filterColumnName, filter.filterColumnValue));
					}, this);
				}
			}
		},

		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "DragAndDrop Container"
			},
			{
				"operation": "remove",
				"name": "AddRecordButton"
			},
			{
				"operation": "remove",
				"name": "SetListedModeButton"
			},
			{
				"operation": "remove",
				"name": "SetTiledModeButton"
			},
			{
				"operation": "remove",
				"name": "ToolsButton"
			},
			{
				"operation": "merge",
				"name": "Detail",
				"values": {
					"wrapClass": ["messageHistory-files-detail"],
					"isHeaderVisible": false,
					"controlConfig": {
						"collapsed": false
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
