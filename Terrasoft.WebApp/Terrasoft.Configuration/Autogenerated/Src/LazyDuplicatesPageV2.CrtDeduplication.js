 define("LazyDuplicatesPageV2", ["InformationButtonResources", "css!LazyDuplicatesPageCSS",
	 "LazyDuplicatesDetailViewConfig", "LazyDuplicatesDetailViewModel"], function(informationButtonResources) {
	return {
		entitySchemaName: "DuplicatesRule",
		mixins: {},
		attributes: {
			
			/**
			 * Count of default loaded duplicates per group.
			 * @protected
			 */
			"TopDuplicatesPerGroup": {
				"value": 5,
				"dataValueType": Terrasoft.DataValueType.INTEGER
			},
			/**
			 * Loaded groups count per page.
			 * @protected
			 */
			"DuplicatesPageRowCount": {
				"value": 10,
				"dataValueType": Terrasoft.DataValueType.INTEGER
			},
			/**
			 * Grid row columns configuration.
			 * @protected
			 */
			"RowConfig": {
				"value": null,
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT
			},
			/**
			 * Is success run of duplicates search.
			 * @protected
			 */
			"IsSuccess": {
				"value": true,
				"dataValueType": Terrasoft.DataValueType.BOOLEAN
			},
			/**
			 * Is first run of duplicates search.
			 * @protected
			 */
			"IsFirstRun": {
				"value": false,
				"dataValueType": Terrasoft.DataValueType.BOOLEAN
			},
			/**
			 * Is canceled run of duplicates search.
			 * @protected
			 */
			"IsCanceled": {
				"value": false,
				"dataValueType": Terrasoft.DataValueType.BOOLEAN
			},
			/**
			 * Duplicates search process label text.
			 * @protected
			 */
			"ProcessedPercentCaption": {
				"value": "",
				"dataValueType": Terrasoft.DataValueType.TEXT
			},
			/**
			 * Maximum duplicates row per record.
			 * @protected
			 */
			"MaxDuplicatesPerRecord": {
				"value": 0,
				"dataValueType": Terrasoft.DataValueType.INTEGER
			},
		},
		messages: {
			/**
			 * @message FetchGroupData
			 * Fetch group duplicates.
			 * @param {Object} config Load group data config.
			 * @param {String} config.groupId Group id.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Callback function scope.
			 */
			"FetchGroupData": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getDuplicatesDetailModuleRootContainerId: function () {
				return Ext.String.format("Lazy{0}", this.callParent(arguments));
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			loadDuplicatesDetailModule: function(id, rootItem, rows, group) {
				this.callParent(arguments);
				const detailId = this.getDuplicatesDetailModuleId(id);
				this.sandbox.subscribe("FetchGroupData", this.onFetchGroupData, this, [detailId]);
			},
			
			/**
			 * FetchGroupData message handler.
			 * @param {Object} config Load group data config.
			 * @param {String} config.groupId Group id.
			 * @param {Function} config.callback Callback function.
			 * @param {Object} config.scope Callback function scope.
			 */
			onFetchGroupData: function(config) {
				const filters = this.getCustomFiltersGroup();
				Terrasoft.DeduplicationStorage.fetchDuplicatesByGroup({
					"groupId": config.groupId,
					"entityName": this.getDuplicatesSchemaName(),
					"columns": this.getDuplicatesColumns(),
					"filters": filters.serialize()
				}, function (response) {
					const groupRows = this.groupOfDuplicatesToViewModelCollection(response.rows,
							this.$RowConfig);
					this.prepareResponseCollection(groupRows);
					Ext.callback(config.callback, config.scope, [groupRows]);
				}, this);
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getDuplicatesGroupDetailConfig: function(groupId, rootItem, group) {
				return Ext.apply(this.callParent(arguments), {
					topDuplicatesPerGroup: this.$TopDuplicatesPerGroup,
					maxDuplicatesPerRecord: this.$MaxDuplicatesPerRecord,
					count: group.duplicatesCount,
				});
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getBulkESDeduplicationResults: function() {
				if (this.$NextDuplicatesGroupOffset === -1) {
					return;
				}
				this.showBodyMask();
				const filters = this.getCustomFiltersGroup();
				var config = {
					"entityName": this.getDuplicatesSchemaName(),
					"columns": this.getDuplicatesColumns(),
					"offset": this.$NextDuplicatesGroupOffset,
					"count": this.$DuplicatesPageRowCount,
					"topDuplicatesPerGroup": this.$TopDuplicatesPerGroup,
					"filters": filters.serialize()
				};
				Terrasoft.DeduplicationStorage.fetchGroupOfDuplicates(config, function(result) {
					this.processDeduplicationResults(result);
				}, this);
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			processDeduplicationResults: function(result) {
				this.$RowConfig = result.rowConfig;
				this.callParent(arguments);
			},
			
			/**
			 * @inheritdoc
			 * @overridden
			 */
			getRootDuplicateViewModel: function(group) {
				var entityCollection = this.groupOfDuplicatesToViewModelCollection([group.sourceEntity], this.$RowConfig);
				return entityCollection.first();
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			bulkDeduplicationInfoCallbackHandler: function(deduplicationInfo) {
				this.$IsSuccess = deduplicationInfo.isSuccess;
				this.$IsFirstRun = deduplicationInfo.isFirstRun;
				this.$IsCanceled = deduplicationInfo.isCanceled;

				if(deduplicationInfo.isCanceled){
					this.$ProcessedPercentCaption = this.get("Resources.Strings.DuplicateSearchCanceledCaption");
				} else {
					const messageTemplate = deduplicationInfo.processedPercent >= 100
							? this.get("Resources.Strings.FinishedDuplcatesSearchMsgTpl")
							: this.get("Resources.Strings.ProcessedDuplcatesSearchMsgTpl");
					this.$ProcessedPercentCaption = Ext.String.format(messageTemplate, deduplicationInfo.processedPercent);
					this.$MaxDuplicatesPerRecord = deduplicationInfo.maxDuplicatesPerRecord;
				}

				this.callParent(arguments);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			hideItems: function() {
				this.callParent(arguments);
				this.$ProcessedPercentCaption = Terrasoft.emptyString;
				this.$IsSuccess = true;
			},
			
			/**
			 * Returns is duplicates search is not success.
			 * @returns {Boolean} Is duplicates search is not success.
			 */
			isUnsuccessDuplicatesSearch: function() {
				return !this.$IsSuccess && !this.$IsFirstRun && !this.$IsCanceled;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"wrapClass": ["card-content-container", "duplicates-content-wrap", "lazy-duplicates-page"]
				}
			},
			{
				"operation": "insert",
				"name": "DeduplicationProcessLabel",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["deduplication-process-label"]
					},
					"caption": { "bindTo": "ProcessedPercentCaption" },
					"visible": {
						"bindTo": "IsFirstRun",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "ErrorInfoButton",
				"parentName": "LeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo": "Resources.Strings.DuplicatesSearchErrorMsg"},
					"style": Terrasoft.TipStyle.RED,
					"controlConfig": {
						"imageConfig": informationButtonResources.localizableImages.WarningIcon,
						"visible": {
							"bindTo": "isUnsuccessDuplicatesSearch"
						}
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
