Terrasoft.configuration.Structures["WidgetDuplicatesPage"] = {innerHierarchyStack: ["WidgetDuplicatesPage"], structureParent: "DuplicatesPageV2"};
define('WidgetDuplicatesPageStructure', ['WidgetDuplicatesPageResources'], function(resources) {return {schemaUId:'d15c0e02-fedb-4904-b94b-37e761b2f784',schemaCaption: "WidgetDuplicatesPage", parentSchemaName: "DuplicatesPageV2", packageName: "CrtDeduplication", schemaName:'WidgetDuplicatesPage',parentSchemaUId:'3bb66e30-50a3-4707-bbeb-5b9b13316887',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("WidgetDuplicatesPage", [
		"ChatContactDuplicatesDetailViewConfig", 
		"WidgetDuplicatesDetailViewModel",
		"css!LazyDuplicatesPageCSS"], function() {
	return {
		columns: {
			"IsRecordsMerged": { 
				"dataValueType": Terrasoft.DataValueType.BOOLEAN
		 	}
		},
		attributes: {
			"IsInfoContentContainerVisible": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Minimum duplicate records count for display.
			 */
			"MinDuplicatesCountForDisplay": {
				"dataValueType": Terrasoft.DataValueType.INTEGER,
				"value": 2
			},
		},
		mixins: {
			QueryCancellationMixin: "Terrasoft.QueryCancellationMixin",
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_addQueryColumns: function(esq) {
				const columns = this.getDuplicatesColumns();
				this.Terrasoft.each(columns, function(column) {
					esq.addColumn(column);
				}, this);
			},

			/**
			 * @private
			 */
			_getDuplicatesData: function(duplicatesContacts, duplicatesCount) {
				let rows = [];
				const items = duplicatesContacts.getItems();
				if (duplicatesCount >= this.$MinDuplicatesCountForDisplay) {
					this.Terrasoft.each(items, function(item) {
						rows.push(item.values);
					}, this);
				}
				return {
					"groups": [
						{
							"groupId": 1,
							"rows": rows
						}
					],
					"rowConfig": duplicatesContacts.rowConfig
				};
			},
			
			/**
			 * Merge entities handler
			 * @protected
			 */
			onMergeEntityDuplicatesExecuted: function (mergedRecordsIds) {
				this.callParent(arguments);
				const state = this.sandbox.publish("GetHistoryState").state;
				if (mergedRecordsIds.includes(state.CurrentEntityId)) {
					this.$IsRecordsMerged = true;
				}
			},

			/**
			 * @private
			 */
			 _redirectToEntitySection: function() {
				const state = this.sandbox.publish("GetHistoryState").state;
				const moduleStructure = this.getModuleStructure(state.EntitySchemaName);
				this.sandbox.publish("PushHistoryState", {hash: moduleStructure.sectionModule + "/" + moduleStructure.sectionSchema});
			},

			// endregion

			// region Methods: Protected
			
			/**
			 * @inheritDoc Terrasoft.DuplicatesPageV2#onLoadNext
			 * @overriden
			 */
			 onLoadNext: Terrasoft.emptyFn,

			/**
			 * @inheritDoc Terrasoft.BasePageV2#onCloseClick
			 * @overriden
			 */
			onCloseClick: function() {
				if (this.$IsRecordsMerged) {
					this._redirectToEntitySection();
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Returns query to duplicates entity.
			 * @protected
			 * @param {Array} duplicateEntitiesIds Identifiers of duplicate entities.
			 * @returns {Object} Query to entity.
			 */
			getDuplicatesEntitiesEsq: function(schemaName, duplicateEntitiesIds) {
				const esq = this.getBaseDuplicatesEsq(schemaName, duplicateEntitiesIds)
				this._addQueryColumns(esq);
				if (this.getIsFeatureEnabled("DuplicatesPageFilters")) {
					this.applyCustomFilters(esq);
				}
				return esq;
			},

			/**
			 * Returns base duplicates esq.
			 * @protected
			 * @param {Array} duplicateEntitiesIds Identifiers of duplicate entities.
			 * @returns {Object} Query to entity.
			 */
			getBaseDuplicatesEsq: function(schemaName, duplicateEntitiesIds) {
				const esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: schemaName
				});
				esq.filters.addItem(this.Terrasoft.createColumnInFilterWithParameters("Id", duplicateEntitiesIds));
				var entitySchemaUId = this.Terrasoft.EntitySchemaManager.findItemByName(schemaName).uId;
				var schemaColumnFilter = Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"SysSchemaUId", entitySchemaUId);
				var existsFilter = Terrasoft.createNotExistsFilter("[ESDuplicateEntity:EntityId].Id",
					schemaColumnFilter);
				existsFilter.Name = "existsFilter";
				esq.filters.add(existsFilter);
				return esq;
			},

			/**
			 * Returns duplicates count esq.
			 * @protected
			 * @param {Array} duplicateEntitiesIds Identifiers of duplicate entities.
			 * @returns {Object} Query to entity.
			 */
			getDuplicatesCount: function(schemaName, duplicateEntitiesIds) {
				const esq = this.getBaseDuplicatesEsq(schemaName, duplicateEntitiesIds)
				esq.addAggregationSchemaColumn("Id", Terrasoft.AggregationType.COUNT, "Count");
				return esq;
			},

			/**
			 * Applies user's custom filters to query.
			 * @protected
			 * @param {Terrasoft.EntitySchemaQuery} esq EntitySchemaQuery instance. 
			 */
			applyCustomFilters: function(esq) {
				const filters = this.getCustomFiltersGroup();
				esq.filters.addItem(filters);
			},

			/**
			 * Forms duplicates entities identifiers collection from history state.
			 * @protected
			 * @param {Object} state History State.
			 * @param {Array} state.DuplicateEntitiesIds Duplicates entities identifiers.
			 * @param {Array} state.CurrentEntityId Current entity identifier.
			 * @returns {Array} Formed duplicates entities identifiers collection.
			 */
			formDuplicatesCollection: function(state) {
				let duplicateEntitiesIds = state.DuplicateEntitiesIds || [];
				duplicateEntitiesIds = duplicateEntitiesIds.slice();
				duplicateEntitiesIds.push(state.CurrentEntityId);
				return duplicateEntitiesIds;
			},

			/**
			 * @inheritDoc DuplicatesPageV2#getDeduplicationResults
			 * @overridden
			 */
			getDeduplicationResults: function() {
				const state = this.sandbox.publish("GetHistoryState").state;
				let duplicateEntitiesIds = this.formDuplicatesCollection(state);
				const esq =  this.getDuplicatesEntitiesEsq(state.EntitySchemaName, duplicateEntitiesIds);
				var duplicatesCountEsq = this.getDuplicatesCount(state.EntitySchemaName, duplicateEntitiesIds);
				duplicatesCountEsq.getEntityCollection(function(response) {
					const duplicatesCount = response.collection.first().get("Count");
					esq.getEntityCollection(function(result) {
						if (result.success) {
							const collection = result.collection;
							this._setSourceEntityInCollection(collection);
							const data = this._getDuplicatesData(collection, duplicatesCount);
							this.processDeduplicationResults(data);
						}
					}, this);
				}, this);
				const key = "getDeduplicationResults";
				const countKey = "getDeduplicatesCount";
				this.registerSentQuery(key, esq);
				this.registerSentQuery(countKey, duplicatesCountEsq);
			},

			/**
			 * Registers sent queries in a module-wide object by their keys.
			 * Cancels previously sent query with the same key.
			 * @protected
			 * @param {String} key A string to uniquely identify the query.
			 * @param {Terrasoft.BaseQuery} esq A Query to be registered.
			 **/
			registerSentQuery: function(key, esq) {
				this.mixins.QueryCancellationMixin.registerSentQuery.call(this, key, esq);
			},

			/**
			 * Finds root entity and sets IsSourceEntity attribute.
			 * @private
			 * @param {Terrasoft.Collection} collection Duplicates entities collection.
			 */
			_setSourceEntityInCollection: function(collection) {
				const state = this.sandbox.publish("GetHistoryState").state;
				const rootEntity = collection.find(state.CurrentEntityId);
				if (rootEntity) {
					rootEntity.values.IsSourceEntity = true;
				}
			},

			/**
			 * @inheritDoc DuplicatesPageV2#getDuplicatesDetailModuleRootContainerId
			 * @overridden
			 */
			getDuplicatesDetailModuleRootContainerId: function (id) {
				return Ext.String.format("WidgetDuplicatesPageDuplicateContainerContainer-{0}-listItem",
					id);
			},

			/**
			 * @inheritDoc DuplicatesPageV2#getDuplicatesGroupDetailConfig
			 * @overridden
			 */
			getDuplicatesGroupDetailConfig: function() {
				const config = this.callParent(arguments);
				const state = this.sandbox.publish("GetHistoryState").state;
				config.viewConfigClassName = this.getDuplicatesDetailViewConfigClassName();
				config.viewModelClassName = this.getDuplicatesDetailViewModelClassName();
				config.currentContactId = state.CurrentEntityId;
				return config;
			},

			/**
			 * Returns name of detail viewConfig class.
			 * @protected
			 * @returns {String} Name of detail viewConfig class.
			 */
			getDuplicatesDetailViewConfigClassName: function() {
				return "Terrasoft.ChatContactDuplicatesDetailViewConfig";
			},

			/**
			 * Returns name of detail viewModel class.
			 * @protected
			 * @returns {String} Name of detail viewModel class.
			 */
			getDuplicatesDetailViewModelClassName: function() {
				return "Terrasoft.WidgetDuplicatesDetailViewModel";
			},

			/**
			 * @inheritDoc DuplicatesPageV2#getInfoTitleLabelLocalizableStringName
			 * @overridden
			 */
			getInfoTitleLabelLocalizableStringName: function() {
				return "Resources.Strings.WidgetPageInfoTitleLabelCaption";
			},

			/**
			 * @inheritDoc DuplicatesPageV2#processEmptyResultsWithFilters
			 * @overridden
			 */
			processEmptyResultsWithFilters: function() {
				this.callParent(arguments);
				this.set("IsInfoContentContainerVisible", true);
			},

			/**
			 * @inheritDoc DuplicatesPageV2#initInfoLabelCaption
			 * @overridden
			 */
			initInfoLabelCaption: function() {
				this.set("IsInfoContentContainerVisible", false);
				this.callParent(arguments);
			}

			// endregion

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
				"operation": "merge",
				"name": "InfoDescriptionLabelContainer",
				"parentName": "InfoContentContainer",
				"propertyName": "items",
				"values": {
					"visible": { "bindTo": "IsInfoContentContainerVisible" }
				}
			},			
			{
				"operation": "merge",
				"name": "InfoDescriptionRunBtn",
				"parentName": "InfoDescriptionLabelContainer",
				"propertyName": "items",
				"values": {
					"visible": false
				}
			},
		]
	};
 });

