define("BasePageV2", ["css!DuplicatesWidgetModule"], function() {
	return {
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		attributes: {
			/**
			 * Is duplicates widget feature enabled.
			 */
			"DuplicatesWidgetFeatureEnabled": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": Terrasoft.Features.getIsEnabled("DuplicatesWidget")
			},
			/**
			 * Is elstic search deduplication feature enabled.
			 */
			"ESDeduplicationFeatureEnabled": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": Terrasoft.Features.getIsEnabled("ESDeduplication")
			},

			/**
			 * Is duplicates widget feature enabled.
			 */
			"IsDuplicationRuleExists": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Is duplicates widget module loaded.
			 */
			"IsDuplicatesWidgetLoaded": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Is duplicates data processing.
			 */
			"IsDuplicatesDataProcessing": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},
		},
		messages: {

			/**
			 * @message GetDuplicatesWidgetConfig
			 * Returns duplicates widget config.
			 */
			"GetDuplicatesWidgetConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message RefreshDuplicatesWidget
			 * Message for refresh duplicates widget data.
			 */
			"RefreshDuplicatesWidget": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
		},
		mixins: {},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_geDuplicatesWidgetModuleId: function() {
				return this.sandbox.id + "_DuplicatesWidgetModule";
			},

			/**
			 * @private
			 */
			_loadDuplicatesWidgetModule: function() {
				if (this.getIsDuplicatesWidgetVisible() && !this.$IsDuplicatesWidgetLoaded) {
					this.Terrasoft.require(["DuplicatesWidgetModule"], function() {
						this.sandbox.loadModule("DuplicatesWidgetModule", {
							renderTo: "DuplicatesWidgetContainer"
						});
						this.$IsDuplicatesWidgetLoaded = true;
					}, this);
				}
			},

			/**
			 * @private
			 */
			_getIsDuplicatesRulesExist: function(callback, scope) {
				if (this.$ESDeduplicationFeatureEnabled
					&& this.$DuplicatesWidgetFeatureEnabled
					&& !this.$IsDuplicatesWidgetLoaded) {
					var config = this.getDuplicatesRuleConfig();
					var data = this._getEntityDeduplicationRules(config);
					if (data && data.IsActive && data.DeduplicationColumns.length > 0) {
						this.$IsDuplicationRuleExists = true;
					}
				}
				this.Ext.callback(callback, scope);
			},

			/**
			 * @private
			 */
			_getIsShouldReloadDuplicatesWidget: function(message) {
				var result = JSON.parse(message && message.Body || Ext.emptyString) || {};
				const allDuplicateEntityIds = [this.$Id, ...this.$DuplicatesRecords];
				const allReceivedDuplicateEntityIds = [result.GoldRecordId, ...result.DuplicateEntityIds];
				return this.entitySchemaName === result.EntitySchemaName 
					&& allReceivedDuplicateEntityIds.some(item => allDuplicateEntityIds.includes(item))
			},

			/**
			 * @private
			 */
			_isDuplicatesDataProcessing: function(callback, scope) {
				if (!this.$ESDeduplicationFeatureEnabled) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "ESDuplicateEntity",
				});
				esq.addAggregationSchemaColumn("Id",
					this.Terrasoft.AggregationType.COUNT, "Count");
				esq.filters.addItem(this.Terrasoft.createColumnInFilterWithParameters(
					"EntityId", [this.$Id, ...this.$DuplicatesRecords]));
				esq.filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL,
					"HasErrors",
					false));
				esq.getEntityCollection(function(result) {
					if (result.success) {
						const entity = result.collection.first();
						this.set("IsDuplicatesDataProcessing", entity.get("Count") > 0);
					}
					this.Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * @private
			 */
			_isCurrentRecordExist: function(callback, scope) {
				if (!this.$ESDeduplicationFeatureEnabled) {
					this.Ext.callback(callback, scope || this);
					return;
				}
				var esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: this.entitySchemaName,
				});
				esq.addAggregationSchemaColumn("Id",
					this.Terrasoft.AggregationType.COUNT, "Count");
				esq.filters.addItem(this.Terrasoft.createColumnFilterWithParameter(
					this.Terrasoft.ComparisonType.EQUAL,
					"Id",
					this.$Id));
				esq.getEntityCollection(function(result) {
					let isRecordExist = false;
					if (result.success) {
						const entity = result.collection.first();
						isRecordExist = entity.get("Count") > 0;
					}
					this.Ext.callback(callback, scope || this, [isRecordExist]);
				}, this);
			},

			/**
			 * Returns get duplicates rules configuration.
			 * @protected
			 * @virtual
			 */
			getDuplicatesRuleConfig: function() {
				return {
					findByActiveRules: true,
					isGetCommunicationsFromDb: true,
					duplicationSettingsSchemaNamePrefix: "ActiveRules_",
					excludeUnique: true
				};
			},
			
			//endregion

			//region Methods: Protected

			/**
			 * Returns included pages for duplicates widget.
			 * @protected
			 */
			getIncludedDuplicatesWidgetPages: function() {
				return [
					"ContactPageV2",
					"AccountPageV2",
					"LeadPageV2"
				];
			},
			
			/**
			 * Returns is duplicates widget visible.
			 * @protected
			 */
			getIsDuplicatesWidgetVisible: function() {
				var includedPagesList = this.getIncludedDuplicatesWidgetPages();
				return this.$ESDeduplicationFeatureEnabled
					&& this.$DuplicatesWidgetFeatureEnabled
					&& this.$IsDuplicationRuleExists
					&& includedPagesList.includes(this.name)
					&& !this.isNewMode();
			},

			/**
			 * @inheritdoc Terrasoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.loadDuplicatesWidgetData();
			},

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#destroy
			 * @override
			 */
			destroy: function() {
				this.callParent(arguments);
				this.Terrasoft.ServerChannel.un(this.Terrasoft.EventName.ON_MESSAGE,
					this.onServerMessageReceived, this);
			},
			
			/**
			 * @inheritdoc Terrasoft.BasePageV2#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				this.Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this.onServerMessageReceived, this);
			},

			/**
			 * Handles web-socket message receiving.
			 * @param {Object} event
			 * @param {Object} message
			 */
			onServerMessageReceived: function(event, message) {
				const messageCode = message && message.Header.Sender;
				if (messageCode === "DuplicatesOperationExecuted"
					&& this.getIsDuplicatesWidgetVisible()
					&& this._getIsShouldReloadDuplicatesWidget(message)) {
					this._isCurrentRecordExist((isCurrentRecordExist) => {
						if (isCurrentRecordExist) {
							this.loadDuplicatesWidgetData();
						} else {
							this.$DuplicatesRecords = [];
							this.$IsDuplicatesDataProcessing = false;
							this.sandbox.publish("RefreshDuplicatesWidget", null, [this._geDuplicatesWidgetModuleId()]);
						}
					}, this);
				}
			},			
			
			/**
			 * Loads duplicates widget data.
			 * @protected
			 */
			loadDuplicatesWidgetData: function() {
				this.Terrasoft.chain(
					this._getIsDuplicatesRulesExist,
					this.findDuplicatesByActiveRules,
					function(next) {
						this._loadDuplicatesWidgetModule();
						this.Ext.callback(next, this);
					},
					this._isDuplicatesDataProcessing,
					function() {
						if (this.getIsDuplicatesWidgetVisible()) {
							this.sandbox.publish("RefreshDuplicatesWidget", null, [this._geDuplicatesWidgetModuleId()]);
						}
					}, this);
			},

			/**
			 * Calls service to find duplicates by active duplicates rules.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			findDuplicatesByActiveRules: function(callback, scope) {
				if (this.getIsFeatureEnabled("ESDeduplication")) {
					var config = this.getDuplicatesRuleConfig();
					this.findDuplicates(callback, scope || this, config);
				} else {
					this.Ext.callback(callback, scope || this);
				}
			},

			/**
			 * @overridden
			 */
			onSaved: function() {
				this.setDuplicates(this.Terrasoft.emptyFn);
				this.callParent(arguments);
				if (this.getIsDuplicatesWidgetVisible()) {
					this.loadDuplicatesWidgetData();
				}
			},
			
			/**
			 * @inheritDoc Terrasoft.BasePageV2#subscribeSandboxEvents
			 * @overriden
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				if (this.$DuplicatesWidgetFeatureEnabled) {
					this.sandbox.subscribe("GetDuplicatesWidgetConfig",
						this.getDuplicatesConfig, this, [this._geDuplicatesWidgetModuleId()]);
				}
			},

			/**
			 * Returns duplicates config.
			 * @return {Object} Duplicates config.
			 */
			getDuplicatesConfig: function() {
				return {
					entitySchemaName: this.entitySchemaName,
					entityId: this.$Id,
					duplicates: this.$DuplicatesRecords,
					isLoading: this.$IsDuplicatesDataProcessing
				};
			},

			//endregion
			
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "DuplicatesWidgetContainer",
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"values": {
					"id": "DuplicatesWidgetContainer",
					"selectors": {"wrapEl": "#DuplicatesWidgetContainer"},
					"itemType": Terrasoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["duplicates-widget-wrap-container"]
					},
					"items": [],
					"markerValue": "DuplicatesWidgetContainer",
					"collapseEmptyRow": true,
					"visible": { "bindTo": "getIsDuplicatesWidgetVisible"},
				},
			},
		]/**SCHEMA_DIFF*/
	};
});
