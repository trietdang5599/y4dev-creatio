Terrasoft.configuration.Structures["TranslationSection"] = {innerHierarchyStack: ["TranslationSection"], structureParent: "BaseSectionV2"};
define('TranslationSectionStructure', ['TranslationSectionResources'], function(resources) {return {schemaUId:'4c58cb1b-b98e-4b2d-b856-9b1413b5326b',schemaCaption: "TranslationSection", parentSchemaName: "BaseSectionV2", packageName: "Translation", schemaName:'TranslationSection',parentSchemaUId:'7912fb69-4fee-429f-8b23-93943c35d66d',extendParent:false,type:Terrasoft.SchemaType.MODULE_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("TranslationSection",
		["terrasoft", "ProcessModuleUtilities", "ConfigurationGrid", "ConfigurationGridGenerator",
		"ConfigurationGridUtilities", "css!TranslationCSS", "UntranslatedFilterViewModel",
		"ConfigurationServiceRequest", "FileImportMixin","SysTranslationColumnsCaptionMixin"
		], function(Terrasoft, ProcessModuleUtilities) {
	return {
		entitySchemaName: "SysTranslation",
		messages: {
			/**
			 * @message GetModuleInfo
			 * Used to provide information for Terrasoft.ModalBoxSchemaModule about modal window.
			 */
			"GetModuleInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetOrderedGridColumns
			 * Returns paths of visible in section grid columns in their display order.
			 */
			"GetOrderedGridColumns": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message UpdateRecordInfo
			 * Updates active translation row after changes had been made through translation modal window.
			 */
			"UpdateRecordInfo": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetRowPositionDetails
			 * Sends previous and next objects ids and canLoadMore flag to be used for navigation in modal window.
			 */
			"GetRowPositionDetails": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ModalBoxClosing
			 * Fires when modal box is closing.
			 */
			"ModalBoxClosing": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GridDataUpdated
			 * Fires after loading more data to the grid.
			 */
			"GridDataUpdated": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},

			GetPredefinedFilters: {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetExtendedFilterConfig
			 * Extended filters settings message.
			 */
			"GetExtendedFilterConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		properties: {
			languageColumnName: "Language",
			languageColumnSuffix: "Short"
		},
		attributes: {
			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#IsEditable
			 * @overridden
			 */
			IsEditable: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},

			/**
			 * ViewButton visibility attribute.
			 */
			ViewOptionsButtonTipVisible: {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Contains primary column value of selected translation row.
			 */
			ModalBoxActiveRow: {
				dataValueType: Terrasoft.DataValueType.GUID,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#SecurityOperationName
			 * @overridden
			 */
			SecurityOperationName: {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: "CanManageTranslationSection"
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#UseFolderFilter
			 * @overridden
			 */
			UseFolderFilter: {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#UseStaticFolders
			 * @overridden
			 */
			"UseStaticFolders": {
				dataValueType: this.Terrasoft.DataValueType.BOOLEAN,
				value: true
			},
			TranslationActualizedOn : {
				dataValueType: Terrasoft.DataValueType.TEXT,
				value: ""
			}

		},
		mixins: {
			"ConfigurationGridUtilities": "Terrasoft.ConfigurationGridUtilities",
			"FileImport": "Terrasoft.FileImportMixin",
			"SysTranslationColumnsConfiguration": "Terrasoft.SysTranslationColumnsCaptionMixin"
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_getFilterLanguageShortColumnPath: function(filter) {
				var languageColumns = this.getTranslationColumns();
				var entityColumns = this.entitySchema.columns;
				var columnPath = filter.leftExpression.columnPath;
				if (this.isNotEmpty(languageColumns[columnPath])) {
					var shortColumnPath = columnPath + this.languageColumnSuffix;
					return entityColumns.hasOwnProperty(shortColumnPath) ? shortColumnPath : columnPath;
				} else {
					return columnPath;
				}
			},

			/**
			 * @private
			 */
			_processLanguageFilter: function(filter) {
				var filterType = filter.filterType;
				if (filterType === Terrasoft.FilterType.FILTER_GROUP) {
					filter.each(function(item) {
						this._processLanguageFilter(item);
					}, this);
				} else if (filterType === Terrasoft.FilterType.COMPARE || filterType === Terrasoft.FilterType.IS_NULL) {
					filter.leftExpression.columnPath = this._getFilterLanguageShortColumnPath(filter);
				} else {
					this.log("Not implemented");
				}
			},

			/**
			 * @private
			 */
			_processFolderFilters: function(filters) {
				var folderFilters = filters.find("FolderFilters");
				if (folderFilters) {
					this._processLanguageFilter(folderFilters);
				}
			},

			/**
			 * @private
			 */
			_processCustomFilters: function(filters) {
				var customFilters = filters.find("CustomFilters");
				if (customFilters) {
					this._processLanguageFilter(customFilters);
				}
			},

			/**
			 * Returns page configuration.
			 * @private
			 * @return {Object} Configuration object.
			 * @return {String} return.schemaName Schema name.
			 * @return {String} return.recordId Modal box active row id.
			 * @return {Object} return.modalBoxConfig Modal window configuration object.
			 * @return {String} return.modalBoxConfig.minWidth Minimal initial window width (percentage).
			 * @return {Array} return.modalBoxConfig.boxClasses CSS classes to be attached to the modal window.
			 */
			getPageConfig: function() {
				var activeRowId = this.get("ModalBoxActiveRow");
				if (activeRowId) {
					return {
						schemaName: "TranslationPage",
						recordId: activeRowId,
						modalBoxConfig: {
							minWidth: "45",
							boxClasses: ["translation-modal-box"]
						}
					};
				}
			},

			/**
			 * Returns an index counted from the end of grid array which points to the row that will trigger
			 * more data loading (if set as active).
			 * Should be any reasonable value between zero(including) and expected grid data array length.
			 * @private
			 * @return {Number}
			 */
			getPreloadOffset: function() {
				return 3;
			},

			/**
			 * Returns visible in grid columns sorted by its display order.
			 * @private
			 * @return {Array}
			 */
			getOrderedGridColumns: function() {
				var columns = this.getProfileColumns();
				var columnPaths = [];
				this.Terrasoft.each(columns, function(column) {
					columnPaths.push(column.path);
				}, this);
				return columnPaths;
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilities#onGetFiltersCollection
			 * @override
			 */
			onGetFiltersCollection: function() {
				var result = this.mixins.GridUtilities.onGetFiltersCollection.call(this);
				this.processLanguageColumnFilters(result);
				return result;
			},

			/**
			 * Refreshes record edited in modal window.
			 * @param {Object} updates Object containing data to find and update edited row.
			 * @param {Object} updates.recordId Id of the row that has to be updated.
			 * @param {Object} updates.changedColumnValues Columns to be replaced.
			 * @private
			 */
			onRecordChanged: function(updates) {
				updates = updates || {};
				if (!updates.recordId) {
					throw new Terrasoft.exceptions.ItemNotFoundException();
				}
				var rowId = updates.recordId;
				this.loadGridDataRecord(rowId);
			},

			/**
			 * Moves focus to the row last shown in the modal box (Makes it active).
			 * @param {Object} closingParameters Object, containing parameters set on modalbox closing.
			 * @param {String} closingParameters.recordId Id of the row last edited in modalbox (to set active).
			 * @private
			 */
			onModalBoxClosing: function(closingParameters) {
				closingParameters = closingParameters || {};
				if (closingParameters.recordId) {
					this.setActiveRow(closingParameters.recordId);
				}
			},

			/**
			 * Constructs an object for GetRowPositionDetails message, calls tryLoadGridData method.
			 * @param {String} rowId Id of the row to create details object for.
			 * @return {Object} Object containing information about surrounding rows and grid status.
			 * @return {String} return.previousId Id of the previous row in the grid.
			 * @return {String} return.nextId Id of the next row in the grid.
			 * @return {Boolean} return.canLoadMore Flag showing if more data could be loaded to the grid.
			 * @private
			 */
			getRowPositionDetails: function(rowId) {
				var keysArray = this.getGridData().getKeys();
				var currentRowIndex = keysArray.indexOf(rowId);
				var canLoadMoreData = this.get("CanLoadMoreData");
				this.tryLoadGridData(currentRowIndex, keysArray.length, canLoadMoreData);
				var rowPositionDetails = {
					previousId: keysArray[currentRowIndex - 1],
					nextId: keysArray[currentRowIndex + 1],
					canLoadMore: canLoadMoreData
				};
				return rowPositionDetails;
			},

			/**
			 * If the row has specific index in the grid array defined to trigger loading more data to the grid
			 * and more data can be loaded, calls a method to load more data. Will not start loading if previous
			 * request is still in progress.
			 * @param {Number} currentRowIndex Position of the current row in the grid.
			 * @param {Number} arrayLength Number of elements that are now in the grid.
			 * @param {Boolean} canLoadMore Flag showing if more data could be loaded to the grid.
			 * @private
			 */
			tryLoadGridData: function(currentRowIndex, arrayLength, canLoadMore) {
				var preloadOffset = this.getPreloadOffset();
				var isGridLoading = this.get("IsGridLoading");
				var needToLoad = (currentRowIndex + 1 + preloadOffset) === arrayLength;
				if (needToLoad && canLoadMore && !isGridLoading) {
					this.loadGridData();
				}
			},

			/**
			 * Loads translation edit modal window.
			 * @param {String} primaryColumnValue Active row primary column value.
			 * @private
			 */
			openTranslationWindow: function(primaryColumnValue) {
				this.set("ModalBoxActiveRow", primaryColumnValue);
				this.sandbox.loadModule("ModalBoxSchemaModule", {
					id: this.getModalBoxWindowId()
				});
			},

			/**
			 * Exports translation.
			 * @private
			 */
			exportTranslation: function() {
				// TODO: CRM-18829
			},
			
			/**
			 * Gets predefined filters module identifier.
			 * @private
			 * @return {String}
			 */
			getPredefinedFiltersModuleId: function() {
				return this.sandbox.id + "_PredefinedFiltersModule";
			},

			/**
			 * Get predefined filters.
			 * @private
			 * @return {Object}
			 */
			getPredefinedFilters: function() {
				return [
					{
						className: "Terrasoft.UntranslatedFilter",
						key: "Untranslated",
						caption: this.get("Resources.Strings.UntranslatedRecordsFilter"),
						imageConfig: this.get("Resources.Images.UntranslatedRecordsFilterImage"),
						columns: this.getTranslationColumns(),
						comparisonType: Terrasoft.ComparisonType.IS_NULL,
						primaryColumnPath: this.get("DefaultLanguageColumnName")
					}
				];
			},

			/**
			 * Gets translation columns.
			 * @private
			 * @return {Object}
			 */
			getTranslationColumns: function() {
				var translationColumns = {};
				this.Terrasoft.each(this.entitySchema.columns, function(column) {
					var columnName = column.name;
					var isTranslationColumn = (columnName.indexOf(this.languageColumnName) === 0);
					var isGeneralUsageTypeColumn = (column.usageType === Terrasoft.EntitySchemaColumnUsageType.General);
					if (isTranslationColumn && isGeneralUsageTypeColumn) {
						translationColumns[columnName] = column;
					}
				}, this);
				return translationColumns;
			},

			/**
			 * Checks if translations can be applied.
			 * @private
			 * @param {Function} [callback] Callback.
			 * @param {Object} [scope] Callback execution scope.
			 */
			checkTranslation: function(callback, scope) {
				var request = this.createTranslationServiceRequest("CheckTranslation");
				request.execute(function(response) {
					if (callback) {
						callback.call(scope || this, response);
					}
				}, this);
			},

			/**
			 * Creates translation service request.
			 * @private
			 * @param {String} contractName Contract name.
			 * @return {Terrasoft.ConfigurationServiceRequest}
			 */
			createTranslationServiceRequest: function(contractName) {
				return this.Ext.create(Terrasoft.ConfigurationServiceRequest, {
					serviceName: "TranslationService",
					contractName: contractName
				});
			},

			/**
			 * Applies translations.
			 * @private
			 * @param {Function} [callback] Callback.
			 * @param {Object} [scope] Callback execution scope.
			 */
			applyTranslation: function(callback, scope) {
				var translationApplyingMessage = this.get("Resources.Strings.TranslationApplying");
				this.showBodyMask({caption: translationApplyingMessage});
				ProcessModuleUtilities.executeProcess({
					sysProcessName: "ApplyTranslationProcess",
					scope: this,
					callback: function() {
						this.hideBodyMask();
					}
				});
			},

			/**
			 * @private
			 */
			setDefaultColumnPath: function(columnsConfig) {
				var defaultLanguageColumn = Terrasoft.find(columnsConfig, function(columnConfig) {
					return columnConfig.IsDefault;
				}, this);
				if(defaultLanguageColumn) {
					this.set("DefaultLanguageColumnName", defaultLanguageColumn.LanguageColumnPath);
				}
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#getGridRowViewModelClassName
			 * @overridden
			 * @protected
			 */
			getGridRowViewModelClassName: function() {
				return this.mixins.GridUtilities.getGridRowViewModelClassName.apply(this, arguments);
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#getModuleCaption
			 * @overridden
			 * @protected
			 */
			getModuleCaption: function() {
				return this.get("Resources.Strings.SectionCaption");
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#getSectionActions
			 * @protected
			 * @overridden
			 */
			getSectionActions: function() {
				var actionMenuItems = this.Ext.create(Terrasoft.BaseViewModelCollection);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "onValidateTranslationsButtonClick"},
					"Caption": {"bindTo": "Resources.Strings.ValidateTranslationsButtonCaption"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.SelectMultipleRecordsButtonCaption"},
					"Click": {"bindTo": "setMultiSelect"},
					"Visible": {"bindTo": "isMultiSelectVisible"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.SelectOneRecordButtonCaption"},
					"Click": {"bindTo": "unSetMultiSelect"},
					"Visible": {"bindTo": "isSingleSelectVisible"},
					"IsEnabledForSelectedAll": true
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.IncludeInFolderButtonCaption"},
					"Click": {"bindTo": "openStaticGroupLookup"},
					"Enabled": {"bindTo": "isAnySelected"},
					"Visible": {"bindTo": "UseStaticFolders"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": {"bindTo": "Resources.Strings.ExcludeFromFolderButtonCaption"},
					"Click": {"bindTo": "excludeFromFolder"},
					"Enabled": {"bindTo": "isAnySelected"},
					"Visible": {"bindTo": "UseStaticFolders"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "exportTranslation"},
					"Caption": {"bindTo": "Resources.Strings.ExportCaption"},
					"Tag": "Export",
					"Visible": false
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Click": {"bindTo": "exportCoreResources"},
					"Caption": {"bindTo": "Resources.Strings.ExportCoreResources"},
					"Visible":  Terrasoft.Features.getIsEnabled("EnableCoreResourcesExport")
				}));
				var exportToFileMenuItem = this.getExportToFileMenuItem();
				actionMenuItems.addItem(exportToFileMenuItem);
				var exportToExcelMenuItem = this.getExportToExcelFileMenuItem();
				actionMenuItems.addItem(exportToExcelMenuItem);
				var fileImportMenuItem = this.getDataImportMenuItem();
				if (fileImportMenuItem) {
					actionMenuItems.add("FileImportMenuItem", fileImportMenuItem);
				}
				return actionMenuItems;
			},

			/**
			 * Initializes entity schema query columns.
			 * @protected
			 * @virtual
			 * @param {Object} esq Entity schema query
			 */
			initSysCultureQueryColumns: function(esq) {
				esq.addColumn("Name");
				esq.addColumn("Active");
				esq.addColumn("Index");
				esq.addColumn("Language");
			},

			/**
			 * Initializes entity schema query filters.
			 * @protected
			 * @virtual
			 * @param {Object} esq Entity schema query
			 * @param {String} cultureId Culture identifier.
			 */
			initSysCulturePrimaryColumnFilter: function(esq, cultureId) {
				esq.filters.add("primaryColumnFilter", this.Terrasoft.createColumnFilterWithParameter(
						this.Terrasoft.ComparisonType.EQUAL, "Id", cultureId));
			},

			/**
			 * @inheritdoc Terrasoft.ConfigurationGridUtilities#initActiveRowKeyMap
			 * @overridden
			 * @protected
			 */
			initActiveRowKeyMap: function(keyMap) {
				this.mixins.ConfigurationGridUtilities.initActiveRowKeyMap.apply(this, arguments);
				keyMap.push({
					key: Ext.EventObject.S,
					ctrl: true,
					defaultEventAction: "preventDefault",
					fn: this.onCtrlSKeyPressed,
					scope: this
				});
			},

			/**
			 * Handles Ctrl + S combination press.
			 * @protected
			 * @virtual
			 * @param {Number} keyCode Key code.
			 * @param {Object} event Event.
			 */
			onCtrlSKeyPressed: function(keyCode, event) {
				event.preventDefault();
				this.onCtrlEnterKeyPressed();
			},

			/**
			 * Returns culture.
			 * @protected
			 * @param {Object} response Server response.
			 * @return {Object} Culture info.
			 */
			onCultureInfoLoaded: function(response) {
				var cultures = response.collection;
				return cultures.getByIndex(0);
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilities#initQueryFilters
			 * @override
			 */
			initQueryFilters: function(esq) {
				this.callParent(arguments);
				var filters = esq.filters.first();
				if (!filters) {
					return;
				}
				this.processLanguageColumnFilters(filters);
			},

			/**
			 * @protected
			 * @param {Terrasoft.FilterGroup} filters Group of filters to be processed.
			 */
			processLanguageColumnFilters: function(filters) {
				this._processFolderFilters(filters);
				this._processCustomFilters(filters);
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#getFilters
			 * @override
			 */
			getFilters: function() {
				var createFilter = Terrasoft.createColumnFilterWithParameter;
				var notEndWith = Terrasoft.ComparisonType.NOT_END_WITH;
				var endWith = Terrasoft.ComparisonType.END_WITH;
				var notContain = Terrasoft.ComparisonType.NOT_CONTAIN;
				var key = "Key";
				var filters = this.callParent(arguments);
				filters.addItem(createFilter(notEndWith, key, ".EntityFilters.Value"));
				filters.addItem(createFilter(notEndWith, key, ".DataSourceFilters.Value"));
				var baseElementFilter = this.Ext.create("Terrasoft.FilterGroup");
				baseElementFilter.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
				baseElementFilter.addItem(createFilter(notContain, key, "BaseElements."));
				baseElementFilter.addItem(createFilter(endWith, key, ".Caption"));
				baseElementFilter.addItem(createFilter(endWith, key, ".Recommendation.Value"));
				baseElementFilter.addItem(createFilter(endWith, key, ".Parameters.%.Value"));
				filters.addItem(baseElementFilter);
				var processSchemaFilter = this.Ext.create("Terrasoft.FilterGroup");
				processSchemaFilter.logicalOperation = this.Terrasoft.LogicalOperatorType.OR;
				processSchemaFilter.addItem(createFilter(notEndWith, key, ".Caption"));
				var processSchemaSubFilter = this.Ext.create("Terrasoft.FilterGroup");
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.BaseElements."));
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.Parameters."));
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.LaneSets."));
				processSchemaSubFilter.addItem(createFilter(notContain, key, "EventsProcessSchema.Methods."));
				processSchemaFilter.addItem(processSchemaSubFilter);
				filters.addItem(processSchemaFilter);
				filters.addItem(createFilter(notEndWith, key, ".Parameters.EntityColumnMetaPathes.Value"));
				filters.addItem(createFilter(notEndWith, key, ".Parameters.%.DisplayValue"));
				return filters;
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#loadFiltersModule
			 * @override
			 */
			loadFiltersModule: function() {
				this.callParent(arguments);
				this.sandbox.loadModule("PredefinedFiltersModule", {
					renderTo: "PredefinedFiltersContainer",
					id: this.getPredefinedFiltersModuleId()
				});
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#getFilterModulesIds
			 * @override
			 */
			getFilterModulesIds: function() {
				var ids = this.callParent(arguments);
				ids.push(this.getPredefinedFiltersModuleId());
				return ids;
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#subscribeFilterGetConfigMessages
			 * @override
			 */
			subscribeFilterGetConfigMessages: function() {
				this.callParent(arguments);
				var predefinedFiltersModuleId = this.getPredefinedFiltersModuleId();
				this.sandbox.subscribe("GetPredefinedFilters", this.getPredefinedFilters, this,
						[predefinedFiltersModuleId]);
			},

			/**
			 * Gets extended filter configuration.
			 * @protected
			 */
			onGetExtendedFilterConfig: function() {
				return {
					isFoldersHidden: true,
					hasExtendedMode: true
				};
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				var quickFilterModuleId = this.getQuickFilterModuleId();
				this.sandbox.subscribe("GetExtendedFilterConfig", this.onGetExtendedFilterConfig,
						this, [quickFilterModuleId]);
				this.subscribeModalBoxEvents();
			},

			/**
			 * Returns sandbox id for modal window.
			 * @protected
			 * @return {String} Sandbox id for modal window.
			 */
			getModalBoxWindowId: function() {
				return this.sandbox.id + "_TranslationEditModalBox";
			},

			/**
			 * Initializes subscription on messages used to communicate with modal window.
			 * @protected
			 */
			subscribeModalBoxEvents: function() {
				this.sandbox.subscribe("GetModuleInfo", this.getPageConfig, this, [this.getModalBoxWindowId()]);
				this.sandbox.subscribe("GetOrderedGridColumns", this.getOrderedGridColumns, this,
						[this.getModalBoxWindowId()]);
				this.sandbox.subscribe("UpdateRecordInfo", this.onRecordChanged, this,
						[this.getModalBoxWindowId()]);
				this.sandbox.subscribe("GetRowPositionDetails", this.getRowPositionDetails, this,
						[this.getModalBoxWindowId()]);
				this.sandbox.subscribe("ModalBoxClosing", this.onModalBoxClosing, this,
						[this.getModalBoxWindowId()]);
			},

			/**
			 * @inheritdoc Terrasoft.GridUtilities#afterLoadGridData
			 * @protected
			 * @override
			 */
			afterLoadGridData: function() {
				this.callParent(arguments);
				this.showViewButtonHint();
				this.sandbox.publish("GridDataUpdated", null, [this.getModalBoxWindowId()]);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#init
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					Terrasoft.chain(
						function(next) {
							var entityColumns = this.entitySchema.columns;
							this.initSysTranslationColumnsProperties(entityColumns, function(columnsConfig) {
								this.setDefaultColumnPath(columnsConfig);
								next();
							}, this);
						},
						function() {
							if(callback) {
								callback.call(scope);
							}
						},
						this
					);
				}, this]);
				Terrasoft.ServerChannel.on(Terrasoft.EventName.ON_MESSAGE, this.handleServerChannelMessage, this);
			},

			/**
			 * Channel message event handler.
			 * @param {Object} channel Channel.
			 * @param {Object} message Channel message.
			 */
			handleServerChannelMessage: function(channel, message) {
				var messageSenderName = message && Terrasoft.ServerChannel.getSenderName(message);
				if (messageSenderName === "ActualizeTranslationError") {
					var actualizedErrorMessage = this.get("Resources.Strings.ActualizedErrorMessage");
					var errorMessage = Ext.String.format("{0}\n{1}", actualizedErrorMessage, message.Body);
					this.reloadGridData();
					this.showInformationDialog(errorMessage);
				}
				if (messageSenderName === "ActualizeTranslationFinished") {
					this.reloadGridData();
				}
			},
			/**
			 * Handles "Close" button click.
			 */
			onCloseButtonClick: function() {
				this.sandbox.publish("BackHistoryState");
			},

			/**
			 * @inheritdoc Terrasoft.BaseSectionV2#onActiveRowAction
			 * @override
			 */
			onActiveRowAction: function(tag, primaryColumnValue) {
				if (tag === "card") {
					this.openTranslationWindow(primaryColumnValue);
				} else {
					this.mixins.ConfigurationGridUtilities.onActiveRowAction.apply(this, arguments);
					this.callParent(arguments);
				}
			},

			initializeTranslationActualizedOn: function () {
				Terrasoft.SysSettings.querySysSettings(["TranslationActualizedOn"], function(setting){
					const value = setting && setting.TranslationActualizedOn;
					if (value) {
						const actualizationDate = Terrasoft.toCultureDateTime(new Date(value));
						var actualizedOnText = this.get("Resources.Strings.TranslationActualizedOnLabel");
						this.set("TranslationActualizedOn", `${actualizedOnText}: ${actualizationDate}`);	
					} else {
						this.set("TranslationActualizedOn", "");	
					}
				}, this);
			},
			
			/**
			 * @inheritdoc Terrasoft.GridUtilitiesV2#loadGridData
			 * @override
			 */
			loadGridData: function() {
				this.initializeTranslationActualizedOn();
				this.callParent(arguments);
			},
			
			/**
			 * Saves row changes.
			 * @overrides Terrasoft.ConfigurationGridUtilities#saveDataRow
			 * @param {Object} row Row that will be saved.
			 * @param {Function} [callback] Callback after saving the row.
			 * @param {Object} [scope] Current scope.
			 */
			saveDataRow: function(row, callback, scope) {
				Terrasoft.chain(function(next) {
					this.mixins.ConfigurationGridUtilities.saveDataRow.apply(this, [row, next, scope]);
				}, function() {
					callback?.apply(scope);
					this.loadGridDataRecord(row.getPrimaryColumnValue());
				}, this);
			},

			/**
			 * Shows view options button hint if translation section is visited for the first time.
			 */
			showViewButtonHint: function() {
				var profile = this.getProfile();
				var key = this.getProfileKey();
				if (profile && key) {
					var isViewButtonTipShown = profile.isViewButtonTipShown;
					if (!isViewButtonTipShown) {
						this.set("ViewOptionsButtonTipVisible", true);
						profile.isViewButtonTipShown = true;
						this.Terrasoft.utils.saveUserProfile(key, profile, false);
					}
				}
			},

			/**
			 * Actualizes translation.
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Callback execution scope.
			 */
			actualizeTranslation: function(callback, scope) {
				var translationActualizationMessage = this.get("Resources.Strings.TranslationActualization");
				this.showBodyMask({caption: translationActualizationMessage});
				ProcessModuleUtilities.executeProcess({
					sysProcessName: "TranslationActualizationProcess",
					scope: this,
					callback: function() {
						this.hideBodyMask();
					}
				});
			},

			exportCoreResources: function() {
			    var baseUrl = this.Terrasoft.workspaceBaseUrl;
			    var url = baseUrl + "/rest/TranslationCoreResourceService/GetExcelCoreResources";

			    fetch(url, { method: 'GET', credentials: 'include' })
			        .then(response => {
			            if (response.status === 200) {
			                window.open(url, '_blank');
			            } else {
			                var errorMessage = this.get("Resources.Strings.ErrorMessageToGetExcelCoreResources");
			                this.showInformationDialog(errorMessage);
			            }
			        });
			},
			
			/**
			 * Applies translations.
			 */
			onApplyTranslationsButtonClick: function() {
				this.applyTranslation(function() {
					this.reloadGridData();
				});
			},

			/**
			 * Start validate translations business process.
			 */
			onValidateTranslationsButtonClick: function() {
				this.showBodyMask({caption: this.get("Resources.Strings.ValidatingTranslations")});
				ProcessModuleUtilities.executeProcess({
					sysProcessName: "VerifyTranslationsProcess",
					scope: this,
					callback: function() {
						this.showInformationDialog(this.get("Resources.Strings.ValidateTranslationsProcessStartedMessage"));
						this.hideBodyMask();
					},
				});
			},

			/**
			 * Gets "ApplyTranslationsButton" visibility.
			 * @return {Boolean}
			 */
			getIsApplyTranslationsButtonVisible: function() {
				//TODO CRM-21787
				return true;
			},

			/**
			 * Sets IsChanged columns as read only.
			 */
			getCellControlsConfig: function(entitySchemaColumn) {
				var config = this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(this, arguments);
				var columnName = entitySchemaColumn.name;
				if (columnName.startsWith("IsChanged")) {
					Ext.apply(config, {enabled: false});
				}
				return config;
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "SeparateModeAddRecordButton"
			},
			{
				"operation": "merge",
				"name": "SeparateModeViewOptionsButton",
				"values": {
					"tips": []
				}
			},
			{
				"operation": "insert",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"name": "PredefinedFiltersContainer",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"id": "PredefinedFiltersContainer",
					"selectors": {wrapEl: "#PredefinedFiltersContainer"},
					"wrapClass": ["predefined-filters-container-wrapClass"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "SeparateModeViewOptionsButton",
				"propertyName": "tips",
				"name": "TranslateViewOptionsButtonTip",
				"values": {
					"content": {"bindTo": "Resources.Strings.ViewButtonHint"},
					"visible": {"bindTo": "ViewOptionsButtonTipVisible"},
					"behaviour": {
						"displayEvent": this.Terrasoft.TipDisplayEvent.NONE
					}
				}
			},
			{
				"operation": "insert",
				"index": 0,
				"name": "CloseButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.BUTTON,
					"style": this.Terrasoft.controls.ButtonEnums.style.BLUE,
					"caption": {"bindTo": "Resources.Strings.CloseButtonCaption"},
					"click": {"bindTo": "onCloseButtonClick"},
					"classes": {
						"textClass": ["actions-button-margin-right"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ApplyTranslationButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.BUTTON,
					"style": this.Terrasoft.controls.ButtonEnums.style.GREEN,
					"caption": {"bindTo": "Resources.Strings.ApplyTranslationsButtonCaption"},
					"click": {"bindTo": "onApplyTranslationsButtonClick"},
					"visible": {"bindTo": "getIsApplyTranslationsButtonVisible"},
					"classes": {
						"textClass": ["actions-button-margin-right"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "UpdateTranslationButton",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.Terrasoft.ViewItemType.BUTTON,
					"style": this.Terrasoft.controls.ButtonEnums.style.DEFAULT,
					"caption": {"bindTo": "Resources.Strings.ActualizeTranslation"},
					"click": {"bindTo": "actualizeTranslation"},
					"visible": true,
					"classes": {
						"textClass": ["actions-button-margin-right"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "TranslationActualizedOnLabel",
				"parentName": "SeparateModeActionButtonsLeftContainer",
				"propertyName": "items",
				"values": {
					"labelClass": "label-in-header-container",
			        "itemType": Terrasoft.ViewItemType.LABEL,
			        "caption": {
			            "bindTo": "TranslationActualizedOn"
			        }
		    },
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowOpenAction"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowCopyAction"
			},
			{
				"operation": "remove",
				"name": "DataGridActiveRowDeleteAction"
			},
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "Terrasoft.ConfigurationGrid",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"type": "listed",
					"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
					"changeRow": {"bindTo": "changeRow"},
					"unSelectRow": {"bindTo": "unSelectRow"},
					"onGridClick": {"bindTo": "onGridClick"},
					"listedZebra": true,
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"activeRowAction": {"bindTo": "onActiveRowAction"},
					"rowDataItemMarkerColumnName": "Key",
					"allowScrollToActiveRow": "true"
				}
			},
			{
				"operation": "insert",
				"name": "activeRowActionCard",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "Terrasoft.Button",
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"tag": "card",
					"markerValue": "card",
					"imageConfig": {"bindTo": "Resources.Images.CardIcon"}
				}
			},
			{
				"operation": "insert",
				"name": "activeRowActionSave",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "Terrasoft.Button",
					"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"tag": "save",
					"markerValue": "save",
					"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
				}
			},
			{
				"operation": "insert",
				"name": "activeRowActionCancel",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "Terrasoft.Button",
					"style": this.Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"tag": "cancel",
					"markerValue": "cancel",
					"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});


