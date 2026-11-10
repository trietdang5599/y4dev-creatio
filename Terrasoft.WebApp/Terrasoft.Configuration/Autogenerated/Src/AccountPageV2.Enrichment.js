define("AccountPageV2", ["CompaniesListHelper", "EnrichmentDataModuleMixin", "css!BaseEnrichmentSchemaCSS"],
	function() {
	return {
		entitySchemaName: "Account",
		messages: {
			/**
			 * Hides enrichment data module.
			 * @message HideEnrichmentDataModule
			 */
			"HideEnrichmentDataModule": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * Returns detail id by name.
			 * @message GetDetailId
			 * @param {String} detailName Detail name.
			 */
			"GetDetailId": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * Shows enrichment data module.
			 * @message ShowEnrichmentDataModule
			 */
			"ShowEnrichmentDataModule": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			CompaniesListHelper: "Terrasoft.CompaniesListHelper",
			EnrichmentDataModuleMixin: "Terrasoft.EnrichmentDataModuleMixin"
		},
		methods: {
			/**
			 * @inheritdoc Terrasoft.BasePageV2#init
			 * @overridden
			 */
			init: function() {
				this.mixins.CompaniesListHelper.init.call(this);
				this.mixins.EnrichmentDataModuleMixin.init.call(this);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.getEnrichedDataCount(this.onGetEnrichedDataCount, this);
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onSaved
			 * @overridden
			 */
			onSaved: function() {
				this.callParent(arguments);
				this.getEnrichedDataCount(this.onGetEnrichedDataCount, this);
			},

			/**
			 * Handler of the getEnrichedDataCount.
			 * @private
			 * @param {Object} response Enrichment data count response.
			 */
			onGetEnrichedDataCount: function(response) {
				if (response.success) {
					var selectResult = response.collection.getByIndex(0);
					var rowsCount = selectResult.get("Count");
					this.set("EnrichedDataCount", rowsCount);
				}
			},

			/**
			 * Gets enrichment button icon.
			 * @protected
			 * @return {Object} Icon config.
			 */
			getEnrichmentButtonIcon: function() {
				var enrichedDataCount = this.get("EnrichedDataCount");
				var buttonIcon = this.get("Resources.Images.EnrichmentDefaultIcon");
				if (enrichedDataCount) {
					buttonIcon = this.get("Resources.Images.EnrichedDefaultIcon");
				}
				return buttonIcon;
			},

			/**
			 * Gets enrichment button caption.
			 * @protected
			 * @return {String} Button caption.
			 */
			getEnrichmentButtonCaption: function() {
				var enrichedDataCount = this.get("EnrichedDataCount");
				var buttonCaption = this.get("Resources.Strings.EnrichmentDefaultButtonCaption");
				if (enrichedDataCount) {
					var buttonCaptionTemplate = this.get("Resources.Strings.EnrichedDefaultButtonCaption");
					buttonCaption = this.Ext.String.format(buttonCaptionTemplate, enrichedDataCount);
				}
				return buttonCaption;
			},

			/**
			 * Gets enrichment button hint.
			 * @protected
			 * @return {String} Button hint
			 */
			getEnrichmentButtonHint: function() {
				var enrichedDataCount = this.get("EnrichedDataCount");
				var buttonHint = this.get("Resources.Strings.EnrichmentDefaultButtonHint");
				if (enrichedDataCount) {
					buttonHint = this.get("Resources.Strings.EnrichedDefaultButtonHint");
				}
				return buttonHint;
			},

			/**
			 * @inheritdoc Terrasoft.EnrichmentDataModuleMixin#getEnrichedDataCountEsq
			 * @overridden
			 */
			getEnrichedDataCountEsq: function() {
				var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "AccountEnrichedData"
				});
				esq.addAggregationSchemaColumn("Id",
						this.Terrasoft.AggregationType.COUNT, "Count");
				esq.filters.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
						"Account", this.get(this.primaryColumnName)));
				var notExistsFilter = this.Terrasoft.createNotExistsFilter(
						"[AccountCommunication:Number:Value].Id");
				var subFilter = esq.createFilter(Terrasoft.ComparisonType.EQUAL,
						"[AccountCommunication:Account:Account].Account", "Account");
				notExistsFilter.subFilters.addItem(subFilter);
				esq.filters.addItem(notExistsFilter);
				return esq;
			}
		},
		attributes: {
			"Name": {
				"contentType": this.Terrasoft.ContentType.SEARCHABLE_TEXT,
				"searchableTextConfig": {
					"listAttribute": "CompaniesList",
					"prepareListMethod": "prepareCompaniesExpandableList",
					"listViewItemRenderMethod": "onCompaniesListViewItemRender",
					"itemSelectedMethod": "onCompanyItemSelected"
				}
			},
			/**
			 * Enrichment data count.
			 * @type {Integer}
			 */
			"EnrichedDataCount": {
				dataValueType: this.Terrasoft.DataValueType.INTEGER,
				value: 0
			},
			/**
			 * Enrichment operation code.
			 * @type {String}
			 */
			"EnrichmentOperationCode": {
				dataValueType: this.Terrasoft.DataValueType.TEXT,
				value: "CanEnrichAccountData"
			}
		},
		modules: {
			"EnrichmentModule": {
				"config": {
					"schemaName": "AccountEnrichmentSchema",
					"isSchemaConfigInitialized": true,
					"useHistoryState": false,
					"parameters": {
						"viewModelConfig": {
							"AlignToElId": "EnrichmentButtonContainer",
							"PrimaryColumnName": "Id"
						}
					}
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "EnrichmentModuleContainer",
				"parentName": "AccountPhotoContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"visible": {
						"bindTo": "IsEnrichmentModuleVisible"
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentModule",
				"parentName": "EnrichmentModuleContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"name": "EnrichmentButtonContainer",
				"parentName": "AccountPhotoContainer",
				"propertyName": "items",
				"values": {
					"id": "EnrichmentButtonContainer",
					"selectors": {
						"wrapEl": "#EnrichmentButtonContainer"
					},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"wrapClass": ["enrichment-button-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "EnrichmentButtonContainer",
				"name": "EnrichmentActionButton",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"imageConfig": {"bindTo": "getEnrichmentButtonIcon"},
					"caption": {"bindTo": "getEnrichmentButtonCaption"},
					"hint": {"bindTo": "getEnrichmentButtonHint"},
					"classes": {
						"wrapperClass": ["enrichment-action-button"]
					},
					"click": {"bindTo": "loadEnrichmentModule"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
