 define("MLColumnSelectionSchema", ["ColumnSettingsUtilities", "MLModelColumnViewModel", "EntityColumnLookupMixin",
		"EntityStructureHelperMixin", "css!MLColumnSelectionModule"], function(ColumnSettingsUtilities) {
 	return {
 		mixins: {
			EntityColumnLookupMixin: "Terrasoft.EntityColumnLookupMixin",
			EntityStructureHelperMixin: "Terrasoft.EntityStructureHelperMixin"
		},
 		messages: {
			/**
			 * @message SetColumnsLookupInfo
			 * Gets selected columns from lookup page.
			 */
			"SetColumnsLookupInfo": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message GetColumnsLookupInfo
			 * Puts parameters info to columns lookup page.
			 */
			"GetColumnsLookupInfo": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ColumnSettingsInfo
			 * Subscription for the column settings info.
			 */
			"ColumnSettingsInfo": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message SelectedModelColumnsChanged
			 * Triggered, when collection of selected columns has been changed.
			 */
			"SelectedModelColumnsChanged": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message MLModelSaved
			 * Triggered, when parent ML model has been saved.
			 */
			"MLModelSaved": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message GetSelectionSchemaInfo
			 * Query for information about column selection schema.
			 */
			"GetSelectionSchemaInfo": {
				"direction": Terrasoft.MessageDirectionType.PUBLISH,
				"mode": Terrasoft.MessageMode.PTP
			},

			/**
			 * @message ColumnSetuped
			 * Subscription for the column setup.
			 */
			"ColumnSetuped": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			/**
			 * Schema to select columns from.
			 */
			"SelectionRootSchema": {
				"dataValueType": Terrasoft.DataValueType.LOOKUP
			},

			/**
			 * Type of created columns.
			 */
			"MLColumnType": {
				"dataValueType": Terrasoft.DataValueType.GUID
			},

			/**
			 * Collection of selected columns.
			 */
			"ColumnCollection": {
				"dataValueType": Terrasoft.DataValueType.COLLECTION
			},

			/**
			 * Identifier of parent ML model.
			 */
			"MLModelId": {
				"dataValueType": Terrasoft.DataValueType.GUID
			},

			/**
			 * Title of module.
			 */
			"ModuleTitle": {
				"dataValueType": Terrasoft.DataValueType.TEXT
			},

			/**
			 * Help button text.
			 */
			"HelpText": {
				"dataValueType": Terrasoft.DataValueType.TEXT
			},

			/**
			 * Indicates that ColumnCollection is empty.
			 */
			"IsColumnCollectionEmpty": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": true
			},

			/**
			 * Card copy mode.
			 */
			"IsCardCopyMode": {
				"dataValueType": Terrasoft.DataValueType.BOOLEAN,
				"value": false
			}
		},
		methods: {

			/**
			 * @private
			 * @param {String} modelId Identifier of the model, columns of which should be loaded.
			 */
			_queryModelColumns: function(modelId) {
				const esq = this.Ext.create("Terrasoft.EntitySchemaQuery", {
					rootSchemaName: "MLModelColumn"
				});
				esq.addColumn("Id");
				esq.addColumn("ColumnUId");
				esq.addColumn("ColumnPath");
				esq.addColumn("AggregationType");
				esq.addColumn("SubFilters");
				esq.addColumn("Caption");
				esq.filters.addItem(Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "MLModel", modelId));
				esq.filters.addItem(Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "ColumnType", this.$MLColumnType));
				esq.getEntityCollection(function(response) {
					this._getExtendedColumnsInfoByPath(response.collection, this._loadColumnCollection, this);
				}, this);
			},

			/**
			 * @param {Terrasoft.BaseViewModelCollection} entities The collection of MLModel columns.
			 * @param {Function} callback The handler for columnsConfig created by entities.
			 * @param {Object} scope The callback scope.
			 * @private
			 */
			_getExtendedColumnsInfoByPath: function(entities, callback, scope) {
				const serviceParameters = [];
				if (Ext.isEmpty(this.$SelectionRootSchema)) {
					callback.call(scope, []);
					return;
				}
				const schemaName = this.$SelectionRootSchema.name;
				let columnsConfig;
				entities.each(function(entity) {
					const isSchemaColumn = !Ext.isEmpty(this._tryGetSelectionRootSchemaColumn(this.$ColumnCollection, {
						UId: entity.$UId,
						ColumnPath: entity.$ColumnPath
					}));
					if (!entity.$ColumnPath || isSchemaColumn) {
						return true;
					}
					serviceParameters.push({
						schemaName: schemaName,
						columnPath: entity.$ColumnPath,
						key: entity.$ColumnPath
					});
				}, this);
				if (serviceParameters.length === 0) {
					columnsConfig = this._getColumnsConfig(entities, []);
					callback.call(scope, columnsConfig);
					return;
				}
				this.getColumnPathCaption(this.Ext.JSON.encode(serviceParameters), function(extendedInfoArray) {
					columnsConfig = this._getColumnsConfig(entities, extendedInfoArray);
					callback.call(scope, columnsConfig);
				}, this);
			},

			/**
			 * @param {Terrasoft.BaseViewModelCollection} entities Collection of MLModelColumn.
			 * @param {Array} extendedInfoArray Array of linked column info (caption, data value types, etc.)
			 * @private
			 */
			_getColumnsConfig: function(entities, extendedInfoArray) {
				return entities.mapArray(function(entity) {
					const extendedInfo = Terrasoft.findItem(extendedInfoArray, {
						key: entity.$ColumnPath
					});
					let columnConfig;
					const id = !this.$IsCardCopyMode ? entity.$Id : Terrasoft.generateGUID();
					if (extendedInfo) {
						const itemInfo = extendedInfo.item;
						const isBackward = entity.$AggregationType !== Terrasoft.AggregationType.NONE;
						columnConfig = {
							Id: id,
							ColumnPath: entity.$ColumnPath,
							AggregationType: entity.$AggregationType,
							SubFilters: entity.$SubFilters,
							Name: entity.$ColumnPath,
							SchemaCaption: itemInfo.columnCaption,
							Caption: entity.$Caption || itemInfo.columnCaption,
							ReferenceSchemaName: itemInfo.referenceSchemaName || itemInfo.parentSchemaName,
							IsBackward: isBackward,
							DataValueType: itemInfo.dataValueType
						};
						if (entity.$AggregationType === Terrasoft.AggregationType.COUNT) {
							columnConfig.DataValueType = Terrasoft.DataValueType.INTEGER;
						}
					} else {
						columnConfig = {
							Id: id,
							UId: entity.$ColumnUId,
							ColumnPath: entity.$ColumnPath,
							Caption: entity.$Caption
						};
					}
					return columnConfig;
				}, this);
			},

			/**
			 * @private
			 */
			_startWatchingForColumnCollectionChanged: function() {
				const collection = this.$ColumnCollection;
				if (!collection) {
					return;
				}
				collection.on("add", this._onColumnCollectionChanged, this);
				collection.on("remove", this._onColumnCollectionChanged, this);
				collection.on("clear", this._onColumnCollectionChanged, this);
			},

			/**
			 * @private
			 */
			_stopWatchingForColumnCollectionChanged: function() {
				const collection = this.$ColumnCollection;
				if (!collection) {
					return;
				}
				collection.un("add", this._onColumnCollectionChanged, this);
				collection.un("remove", this._onColumnCollectionChanged, this);
				collection.un("clear", this._onColumnCollectionChanged, this);
			},

			/**
			 * @private
			 */
			_onColumnCollectionChanged: function() {
				this.$IsColumnCollectionChanged = true;
				this.$IsColumnCollectionEmpty = this.$ColumnCollection.isEmpty();
				this.sandbox.publish("SelectedModelColumnsChanged", null);
			},

			/**
			 * @private
			 */
			_loadColumnCollection: function(columnsConfig) {
				const columnCollection = this.$ColumnCollection;
				this._stopWatchingForColumnCollectionChanged();
				columnCollection.clear();
				for (const column of columnsConfig) {
					this._addModelColumn(column);
				}
				this.set("IsColumnCollectionChanged", this.$IsCardCopyMode);
				this.$IsColumnCollectionEmpty = this.$ColumnCollection.isEmpty();
				this._startWatchingForColumnCollectionChanged();
				if (this.$IsCardCopyMode) {
					this.initialColumnCollectionIdentifiers = [];
				} else {
					this._updateInitialColumnCollectionIdentifiers(columnCollection);
				}
			},

			/**
			 * Updates columns's collection identifiers.
			 * @param {Terrasoft.Collection} columnCollection Model columns collection.
			 * @private
			 */
			_updateInitialColumnCollectionIdentifiers: function(columnCollection) {
				this.initialColumnCollectionIdentifiers = [];
				if (!columnCollection) {
					return;
				}
				this.Terrasoft.each(columnCollection, function(column) {
					if (!column.$IsNew) {
						this.initialColumnCollectionIdentifiers.push(column.$Id);
					}
				}, this);
			},

			/**
			 * Handles selection of column.
			 * @private
			 * @param {Object} columnInfo Selected column information.
			 */
			_onColumnSelected: function(columnInfo) {
				if (columnInfo.isBackward) {
					columnInfo.hideFilter = false;
					ColumnSettingsUtilities.Open(this.sandbox, columnInfo, function(newConfig) {
						this._addModelColumnByLinkedColumnSettings(newConfig, columnInfo.leftExpressionCaption,
							newConfig.title);
					}.bind(this), "centerPanel", this);
				} else {
					this._addModelColumnByLinkedColumnSettings(columnInfo, columnInfo.leftExpressionCaption);
				}
			},

			/**
			 * @return {Array} Identifiers of model columns that were removed.
			 * @private
			 */
			_getRemovedColumnIds: function() {
				return Terrasoft.difference(this.initialColumnCollectionIdentifiers,
					this.$ColumnCollection.getKeys());
			},

			/**
			 * @return {Array} Identifiers of model columns that were added.
			 * @private
			 */
			_getNewColumnIds: function() {
				return Terrasoft.difference(this.$ColumnCollection.getKeys(),
					this.initialColumnCollectionIdentifiers);
			},

			/**
			 * @return {Array} Identifiers of model columns that were modified.
			 * @private
			 */
			_getChangedColumnIds: function() {
				const changedColumns = this.$ColumnCollection.filter(function(column) {
					return column.$IsChanged;
				});
				return Terrasoft.intersect(changedColumns.getKeys(), this.initialColumnCollectionIdentifiers);
			},

			_addModelColumnByLinkedColumnSettings: function(linkedColumnInfo, schemaCaption, caption) {
				const columnConfig = {
					ColumnPath: linkedColumnInfo.leftExpressionColumnPath,
					Name: linkedColumnInfo.leftExpressionColumnPath,
					SchemaCaption: schemaCaption,
					Caption: caption,
					DataValueType: linkedColumnInfo.dataValueType,
					AggregationType: linkedColumnInfo.aggregationType || Terrasoft.AggregationType.NONE,
					IsBackward: linkedColumnInfo.isBackward,
					SubFilters: linkedColumnInfo.serializedFilter || "",
					ReferenceSchemaName: linkedColumnInfo.referenceSchemaName,
					IsNew: true
				};
				this._addModelColumn(columnConfig);
			},

			/**
			 * @param {Object} columnConfig Column info descriptor.
			 * @param {Guid} [columnConfig.UId] Entity schema column unique Id.
			 * @param {Guid} [columnConfig.Id] MLModelColumn unique Id.
			 * @param {String} [columnConfig.ColumnPath] Column path relative to Root schema.
			 * @param {String} [columnConfig.Caption] Custom caption for column.
			 * @private
			 */
			_addModelColumn: function(columnConfig) {
				let targetColumnConfig = columnConfig;
				const column = this._tryGetSelectionRootSchemaColumn(columnConfig);
				if (column) {
					targetColumnConfig = {
						UId: column.uId,
						ColumnPath: column.name,
						SchemaCaption: column.caption,
						Caption: columnConfig.Caption || column.caption,
						DataValueType: column.dataValueType,
						IsBackward: false,
						IsNew: columnConfig.IsNew
					};
				}
				targetColumnConfig.Id = columnConfig.Id || Terrasoft.generateGUID();
				targetColumnConfig.Caption = targetColumnConfig.Caption || targetColumnConfig.SchemaCaption;
				targetColumnConfig.ColumnType = this.$MLColumnType;
				const columnViewModel = this._createMLModelColumnViewModel(targetColumnConfig);
				this.$ColumnCollection.add(targetColumnConfig.Id, columnViewModel);
			},

			/**
			 * @private
			 */
			_createMLModelColumnViewModel: function(column) {
				const columnViewModel = this.Ext.create("Terrasoft.MLModelColumnViewModel", {
					sandbox: this.sandbox,
					Ext: this.Ext,
					Terrasoft: this.Terrasoft,
					values: column
				});
				columnViewModel.model.on("change", function() {
					columnViewModel.set("IsChanged", true);
					this.sandbox.publish("SelectedModelColumnsChanged", null);
				}, this);
				return columnViewModel;
			},

			/**
			 * @private
			 */
			_getSaveCollectionFunction: function() {
				const batchQuery = this.Ext.create("Terrasoft.BatchQuery");
				this._addDeleteColumnsQuery(batchQuery);
				this._addInsertNewColumnsQuery(batchQuery);
				this._addUpdateChangedColumnsQuery(batchQuery);
				const uniqueMaskId = "ml-model-page-save-columns";
				this.showBodyMask({
					uniqueMaskId: uniqueMaskId,
					timeout: 0
				});
				return function (callback, scope) {
					batchQuery.execute(function () {
						this.$ColumnCollection.each(function(column) {
							column.set("IsNew", false, {silent: true});
						}, this);
						this._updateInitialColumnCollectionIdentifiers(this.$ColumnCollection);
						this.set("IsColumnCollectionChanged", false);
						this.hideBodyMask({
							uniqueMaskId: uniqueMaskId
						});
						Ext.callback(callback, scope);
					}, this);
				}.bind(this);
			},

			/**
			 * @private
			 */
			_addDeleteColumnsQuery: function(batchQuery) {
				const removedColumnIds = this._getRemovedColumnIds();
				if (removedColumnIds.length === 0) {
					return;
				}
				const deleteQuery = this.Ext.create("Terrasoft.DeleteQuery", {
					rootSchemaName: "MLModelColumn"
				});
				const filters = deleteQuery.filters;
				filters.addItem(Terrasoft.createColumnFilterWithParameter(
					Terrasoft.ComparisonType.EQUAL, "MLModel", this.$MLModelId));
				filters.addItem(Terrasoft.createColumnInFilterWithParameters("Id", removedColumnIds));
				batchQuery.add(deleteQuery);
			},

			/**
			 * @private
			 */
			_addInsertNewColumnsQuery: function(batchQuery) {
				const newColumnIds = this._getNewColumnIds();
				if (newColumnIds.length === 0) {
					return;
				}
				Terrasoft.each(newColumnIds, function(columnId) {
					const column = this.$ColumnCollection.get(columnId);
					const insertQuery = this.Ext.create("Terrasoft.InsertQuery", {
						rootSchemaName: "MLModelColumn"
					});
					insertQuery.setParameterValue("MLModel", this.$MLModelId, Terrasoft.DataValueType.GUID);
					insertQuery.setParameterValue("Id", column.$Id, Terrasoft.DataValueType.GUID);
					if (column.$UId) {
						insertQuery.setParameterValue("ColumnUId", column.$UId, Terrasoft.DataValueType.GUID);
					}
					insertQuery.setParameterValue("ColumnPath", column.$ColumnPath, Terrasoft.DataValueType.TEXT);
					if (column.$Caption !== column.$SchemaCaption) {
						insertQuery.setParameterValue("Caption", column.$Caption,
							Terrasoft.DataValueType.TEXT);
					}
					insertQuery.setParameterValue("AggregationType", column.$AggregationType,
						Terrasoft.DataValueType.INTEGER);
					insertQuery.setParameterValue("SubFilters", column.$SubFilters,
						Terrasoft.DataValueType.TEXT);
					insertQuery.setParameterValue("ColumnType", column.$ColumnType,
						Terrasoft.DataValueType.GUID);
					batchQuery.add(insertQuery);
				}, this);
			},

			/**
			 * @private
			 */
			_addUpdateChangedColumnsQuery: function(batchQuery) {
				const changedColumnIds = this._getChangedColumnIds();
				if (changedColumnIds.length === 0) {
					return;
				}
				Terrasoft.each(changedColumnIds, function(columnId) {
					const column = this.$ColumnCollection.get(columnId);
					const caption = column.$Caption !== column.$SchemaCaption ? column.$Caption : null;
					const updateQuery = this.Ext.create("Terrasoft.UpdateQuery", {
						rootSchemaName: "MLModelColumn"
					});
					updateQuery.filters.addItem(Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL, "Id", columnId));
					updateQuery.setParameterValue("Caption", caption, Terrasoft.DataValueType.TEXT);
					updateQuery.setParameterValue("AggregationType", column.$AggregationType,
						Terrasoft.DataValueType.INTEGER);
					updateQuery.setParameterValue("SubFilters", column.$SubFilters,
						Terrasoft.DataValueType.TEXT);
					updateQuery.setParameterValue("ColumnType", column.$ColumnType,
						Terrasoft.DataValueType.GUID);
					batchQuery.add(updateQuery);
				}, this);
			},

			/**
			 * Returns 'Remove column' icon.
			 * @return {String} 'Remove column' icon.
			 * @private
			 */
			_getRemoveColumnIcon: function() {
				const resourceImage = this.get("Resources.Images.ClearIcon");
				return Terrasoft.ImageUrlBuilder.getUrl(resourceImage);
			},

			/**
			 * Returns root schema column collection, excluding already appended to model column list.
			 * @private
			 */
			_getAvailableRootSchemaColumnCollection: function() {
				const entityColumns = this.Ext.create("Terrasoft.Collection");
				Terrasoft.each(this.$SelectionSchemaColumns, function(column) {
					const modelColumn = this.$ColumnCollection.findByFn(function(item) {
						return item.$UId === column.uId || item.$ColumnPath === column.name;
					}, this);
					if (!modelColumn && this.columnDataValueTypeFilter(column.dataValueType)) {
						entityColumns.add(column.uId, {
							"id": column.uId,
							"caption": column.caption,
							"icon": this.getColumnTypeIcon(column.dataValueType)
						});
					}
				}, this);
				return entityColumns;
			},

			/**
			 * @param {Object} columnConfig Column info descriptor.
			 * @param {Guid} columnConfig.UId Column unique Id.
			 * @param {String} columnConfig.ColumnPath Root schema column name.
			 * @private
			 */
			_tryGetSelectionRootSchemaColumn: function(columnConfig) {
				let column;
				const columnUId = columnConfig.UId;
				if (columnUId) {
					column = Terrasoft.findWhere(this.$SelectionSchemaColumns, {"uId": columnUId});
				} else {
					column = Terrasoft.findWhere(this.$SelectionSchemaColumns, {"name": columnConfig.ColumnPath});
				}
				return column;
			},

			_initColumnCollection: function(existingCollection) {
				this.set("ColumnCollection", existingCollection);
				this.$IsColumnCollectionEmpty = this.$ColumnCollection.isEmpty();
				this._startWatchingForColumnCollectionChanged();
				this._updateInitialColumnCollectionIdentifiers(this.$ColumnCollection);
			},

			_initColumnSelectionProperties: function(selectionSchemaInfo) {
				this.$SelectionRootSchema = selectionSchemaInfo.schema;
				this.$MLModelId = selectionSchemaInfo.modelId;
				this.$SelectionSchemaColumns = selectionSchemaInfo.schemaColumns;
				this.$ModuleTitle = selectionSchemaInfo.title;
				this.$HelpText = selectionSchemaInfo.helpText;
				this.$IsCardCopyMode = selectionSchemaInfo.isCardCopyMode;
				this.$SourceEntityId = selectionSchemaInfo.sourceEntityId;
				this.columnDataValueTypeFilter = selectionSchemaInfo.columnDataValueTypeFilter;
				this._initColumnCollection(selectionSchemaInfo.columnCollection);
			},

			_subscribeSandboxEvents: function() {
				this.sandbox.subscribe("MLModelSaved", function() {
					return this._getSaveCollectionFunction();
				}, this, [this.sandbox.id]);
			},

			init: function() {
				this.callParent(arguments);
				this._subscribeSandboxEvents();
				const selectionSchemaInfo = this.sandbox.publish("GetSelectionSchemaInfo", this.$SelectionRootSchemaAttributeName);
				if (!selectionSchemaInfo) {
					return;
				}
				this._initColumnSelectionProperties(selectionSchemaInfo);
				if (this.$ColumnCollection.isEmpty()) {
					this._queryModelColumns(this.$IsCardCopyMode ? this.$SourceEntityId : this.$MLModelId);
				}
			},

			/**
			 * Creates menu items for 'Add columns' button.
			 * @return {Terrasoft.BaseViewModelCollection} Menu with actions for adding columns.
			 */
			getAddColumnMenuItems: function() {
				const items = this.Ext.create("Terrasoft.BaseViewModelCollection");
				const addRootSchemaColumnsMenuItem = this.getButtonMenuItem({
					"Caption": "$Resources.Strings.AddRootSchemaMenuItemCaption",
					"Click": {"bindTo": "addSchemaColumnsClick"}
				});
				const addRootSchemaLinkedColumnMenuItem = this.getButtonMenuItem({
					"Caption": "$Resources.Strings.AddRootSchemaLinkedColumnCaption",
					"Click": {"bindTo": "openStructureExplorer"}
				});
				items.addItem(addRootSchemaColumnsMenuItem);
				items.addItem(addRootSchemaLinkedColumnMenuItem);
				return items;
			},

			/**
			 * Open entity structure explorer module for select column macros.
			 * @protected
			 * @virtual
			 */
			openStructureExplorer: function() {
				const schemaName = this.$SelectionRootSchema.name;
				const scope = this;
				Terrasoft.StructureExplorerUtilities.open({
					scope: scope,
					handlerMethod: this._onColumnSelected,
					moduleConfig: {
						useBackwards: true,
						schemaName: schemaName,
						columnsFiltrationMethod: scope.columnsFiltrationMethod.bind(scope),
						firstColumnsOnly: false
					}
				});
			},

			/**
			 * @param {Object} column Entity schema column config.
			 * @param {Object} config Structure explorer config.
			 * @private
			 */
			columnsFiltrationMethod: function(column, config) {
				const aggregatedDataValueTypes = [
					Terrasoft.DataValueType.DATE_TIME,
					Terrasoft.DataValueType.DATE,
					Terrasoft.DataValueType.TIME,
					Terrasoft.DataValueType.INTEGER,
					Terrasoft.DataValueType.MONEY,
					Terrasoft.DataValueType.FLOAT
				];
				if (!this.columnDataValueTypeFilter(column.dataValueType)) {
					return false;
				}
				if (config.schema.name !== this.$SelectionRootSchema.name) {
					if (config.hasBackwardElements) {
						return (Terrasoft.contains(aggregatedDataValueTypes, column.dataValueType));
					}
					return true;
				}
				const existingItem = this.$ColumnCollection.findByFn(function(item) {
					return item.$UId === column.uId || item.$ColumnPath === column.name;
				}, this);
				return Ext.isEmpty(existingItem);
			},

			addSchemaColumnsClick: function() {
				const schemaName = "EntityColumnLookupPage";
				const pageId = this.sandbox.id + schemaName;
				this.sandbox.subscribe("SetColumnsLookupInfo", function(lookupInfo) {
					if (lookupInfo) {
						Terrasoft.each(lookupInfo.selectedRows, function(item) {
							this._addModelColumn({UId: item, IsNew: true});
						}, this);
					}
					this.closeSchemaColumnSelectPage();
				}, this, [pageId]);
				const entityColumns = this._getAvailableRootSchemaColumnCollection();
				this.showEntitySchemaColumnSelectPage(entityColumns, {
					rootSchema: this.$SelectionRootSchema,
					isMultiSelect: true
				});
			},

			/**
			 * Returns column type icon.
			 * @param {Terrasoft.DataValueType} dataValueType Column data value type.
			 * @return {String} Column type icon.
			 */
			getColumnTypeIcon: function(dataValueType) {
				const imageName = Terrasoft.getImageNameByDataValueType(dataValueType);
				return Terrasoft.ImageUrlBuilder.getUrl({
					source: Terrasoft.ImageSources.RESOURCE_MANAGER,
					params: {
						resourceManagerName: "Terrasoft.Nui",
						resourceItemName: Ext.String.format("{0}{1}", "ProcessSchemaDesigner.", imageName)
					}
				});
			},

			/**
			 * Handler of the configuration row of the columns container list.
			 * @param {Object} itemConfig Config of the item.
			 * @param {Terrasoft.BaseViewModel} item ViewModel.
			 */
			onGetColumnItemConfig: function(itemConfig, item) {
				itemConfig.config = {
					"id": "MLColumn",
					"className": "Terrasoft.Container",
					"classes": {
						"wrapClassName": ["column-item-container"]
					},
					"markerValue": item.$ColumnPath + "-column",
					"items": [
						{
							"className": "Terrasoft.ImageView",
							"imageSrc": this.getColumnTypeIcon(item.$DataValueType),
							"classes": {"wrapClass": ["column-type-icon"]},
							"markerValue": item.$DataValueType + "-icon"
						},
						{
							"className": "Terrasoft.Hyperlink",
							"caption": {"bindTo": "Caption"},
							"classes": {
								"hyperlinkClass": ["column-link"]
							},
							"click": {"bindTo": "onColumnHyperlinkClick"},
							"markerValue": item.$ColumnPath + "-link"
						},
						{
							"className": "Terrasoft.Button",
							"click": {"bindTo": "onRemoveColumnClick"},
							"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
							"classes": {"wrapperClass": ["remove-column-icon"]},
							"styles": {
								"wrapperStyle": {
									"background":
										Ext.String.format("url({0}) 50% 50% no-repeat", this._getRemoveColumnIcon())
								}
							},
							"markerValue": item.$ColumnPath + "-clear"
						}
					]
				};
			},

			/**
			 * @inheritdoc BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				this._stopWatchingForColumnCollectionChanged();
				this.callParent(arguments);
			},

			getContainerListId: function() {
				return "ContainerList" + this.sandbox.id;
			},

			getTipId: function() {
				return "ColumnsSelectionGroupInfoButton" + this.sandbox.id;
			}
		},
		diff: [
			{
				"name": "ColumnsSelectionFieldsGroup",
				"parentName": "ModelSettingsTab",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"caption": {"bindTo": "ModuleTitle"},
					"classes": {
						"wrapContainerClass": ["column-selector"]
					},
					"controlConfig": {
						"classes": ["column-selector-fields-group"]
					},
					"tools": [],
					"items": [],
					"generateId": false
				}
			},
			{
				"name": "AddColumnMenuButton",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"index": 1,
				"propertyName": "tools",
				"values": {
					"itemType": Terrasoft.ViewItemType.BUTTON,
					"style": Terrasoft.controls.ButtonEnums.style.TRANSPARENT,
					"menu": {
						"items": {"bindTo": "getAddColumnMenuItems"}
					},
					"imageConfig": {"bindTo": "Resources.Images.AddColumnMenuIcon"},
					"classes": {
						"wrapperClass": "add-columns-menu-button"
					},
					"generateId": false
				}
			},
			{
				"name": "ColumnsSelectionGroupInfoButton",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"index": 1,
				"propertyName": "tools",
				"values": {
					"id": { "bindTo": "getTipId" },
					"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo":"HelpText"},
					"behaviour": {
						"displayEvent": Terrasoft.TipDisplayEvent.HOVER
					},
					"controlConfig": {
						"classes": {
							"wrapperClass": "column-selector-info-button-control-group"
						},
						"generateId": false
					},
					"generateId": false
				}
			},
			{
				"name": "ColumnsSelectionGroupNoDataLabel",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.LABEL,
					"caption": { "bindTo": "Resources.Strings.NoData" },
					"visible": {
						"bindTo": "IsColumnCollectionEmpty"
					},
					"labelConfig": {
						"classes": ["placeholder-label"]
					},
					"generateId": false
				}
			},
			{
				"name": "ColumnContainerList",
				"parentName": "ColumnsSelectionFieldsGroup",
				"operation": "insert",
				"propertyName": "items",
				"values": {
					"id": {"bindTo": "getContainerListId"},
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"className": "Terrasoft.ContainerList",
					"collection": {
						"bindTo": "ColumnCollection"
					},
					"idProperty": "Id",
					"wrapClass": ["columns-container-list"],
					"onGetItemConfig": {
						"bindTo": "onGetColumnItemConfig"
					},
					"itemPrefix": "MLColumnContainerList"
				}
			}
		]
	};
 });
