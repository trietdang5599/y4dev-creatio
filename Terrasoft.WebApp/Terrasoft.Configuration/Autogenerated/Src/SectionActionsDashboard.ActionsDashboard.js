/*
 * Parent: BaseActionsDashboard
 */
define("SectionActionsDashboard", ["ConfigurationConstants", "SectionActionsDashboardResources", "Activity",
	"VwProcessDashboard", "BaseStageControl", "ActivityDashboardItemViewModel", "ProcessDashboardItemViewModel",
	"DcmSectionActionsDashboardMixin", "DcmExecutionDataRequest", "DcmConstants", "SysModuleVisaManager",
	"ApprovalDashboardItemViewModel", "ApprovalDashboardItemViewConfig", "ActionsDashboardUtils",
	"QueryCancellationMixin", "SectionManager", "BaseAsyncStageControl"
], function(ConfigurationConstants, resources) {
	return {
		attributes: {
			/**
			 * EntitySchema of the ViewModel.
			 */
			"EntitySchema": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Entity schema name.
			 */
			"EntitySchemaName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.ENTITY_COLUMN
			},
			/**
			 * Name of actions entity schema.
			 */
			"ActionsSchemaName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Name of column of entitySchema column that references to entity schema of actions.
			 */
			"ActionsColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Name of the primary column of actions
			 */
			"ActionsPrimaryColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Primary display column of action entity schema.
			 */
			"ActionsPrimaryDisplayColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Config of action decoupling table.
			 */
			"DecouplingConfig": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Name of color column of actions.
			 */
			"ActionsColorColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Name of column for action filtering.
			 */
			"ActionsFilterColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Name of column for action ordering.
			 */
			"ActionsOrderColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Name of column for inner action ordering in menu.
			 */
			"ActionsInnerOrderColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Identifier of current action.
			 */
			"ActiveActionId": {
				dataValueType: Terrasoft.DataValueType.GUID,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},
			/**
			 * Is master entity initialized flag.
			 */
			"IsMasterEntityInitialized": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},
			/**
			 * DcmSchema.
			 */
			"DcmSchema": {
				dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Flag that indicates whether current dcm schema is actual or not.
			 */
			"IsActualDcmSchema": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Section actions dashboard initialized flag.
			 */
			"IsSectionActionsDashboardInitialized": {
				dataValueType: Terrasoft.DataValueType.BOOLEAN
			},
			/**
			 * Name of approval schema.
			 */
			"ApprovalSchemaName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Name of approval reference column.
			 */
			"ApprovalReferenceColumnName": {
				dataValueType: Terrasoft.DataValueType.TEXT,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Dashboard items query batch size.
			 */
			"QueryItemsBatchSize": {
				dataValueType: Terrasoft.DataValueType.Number,
				value: 100
			}
		},
		messages: {
			/**
			 * @message ReloadCard
			 * Notify about the card is reload.
			 */
			"ReloadCard": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message DashboardRealoaded
			 * Notify about the dashboard is reload.
			 */
			"DashboardRealoaded": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message ProcessExecDataChanged
			 * Specifies that you have to transfer the data of a process.
			 */
			"ProcessExecDataChanged": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message ProcessExecDataChanged
			 * Specifies that you have to transfer the data of a process.
			 */
			"SaveRecord": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message PushHistoryState
			 * Notify about changes in the chain.
			 */
			"PushHistoryState": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetColumnsValues
			 * Returns requested column values.
			 */
			"GetColumnsValues": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message UpdateCardProperty
			 * Changes the value of the card model.
			 */
			"UpdateCardProperty": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetEntityColumnChanges
			 * Processes changes of entity column.
			 */
			"GetEntityColumnChanges": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message EntityInitialized
			 * Master's entity initialized event.
			 */
			"EntityInitialized": {
				mode: Terrasoft.MessageMode.BROADCAST,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message RerenderPublisherModule
			 * Informs publisher its need to be rendered
			 */
			"RerenderPublisherModule": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetPropertiesByName
			 * Returns values of target columns.
			 */
			"GetPropertiesByName": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message ReInitializeActionsDashboard
			 * Process reinitialize actions dashboard.
			 */
			"ReInitializeActionsDashboard": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * @message UpdateDcmActionsDashboardConfig
			 * Update DcmActionsDashboard config.
			 */
			"UpdateDcmActionsDashboardConfig": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message IsEntityChanged
			 * Returns is entity changed.
			 */
			"IsEntityChanged": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message IsDcmFilterColumnChanged
			 * Returns true if DCM filtered columns changed.
			 */
			"IsDcmFilterColumnChanged": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message GetPublisherPageState
			 * Returns publisher page state.
			 */
			"GetPublisherPageState": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message ValidateCard
			 * Returns is master entity card valid.
			 */
			"ValidateCard": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			DcmSectionActionsDashboardMixin: "Terrasoft.DcmSectionActionsDashboardMixin",
			QueryCancellationMixin: "Terrasoft.QueryCancellationMixin"
		},
		methods: {

			/**
			 * Returns additional action dashboard tabs visibility.
			 * @protected
			 * @return {Boolean} Additional action dashboard tabs visibility.
			 */
			getExtraActionDashboadTabVisible: function() {
				return true;
			},

			/**
			 * Returns extended config for tabs.
			 * @return {Object} config Extended tab config
			 */
			getExtendedConfig: function() {
				const config = {};
				config.DashboardTab = {
					"Align": Terrasoft.Align.LEFT
				};
				return config;
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#getAllowedTabs7x
			 * @override
			 */
			getAllowedTabs7x: function() {
				var result = this.callParent(arguments);
				result.push("DashboardTab");
				return result;
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#initTabsConfig
			 * @override
			 */
			initTabsConfig: function() {
				this.callParent(arguments);
				const tabsConfig = this.get("TabsConfig");
				const extendedConfig = this.getExtendedConfig();
				Ext.merge(tabsConfig, extendedConfig);
				this.set("TabsConfig", tabsConfig);
			},

			/**
			 * @inheritdoc BaseSchemaViewModel#getProfileKey
			 * @override
			 */
			getProfileKey: function() {
				const entitySchemaName = this.get("EntitySchemaName");
				return Terrasoft.ActionsDashboardUtils.getProfileKeyByEntity(entitySchemaName);
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#getPropertiesTranslator
			 * @override
			 */
			getPropertiesTranslator: function() {
				const properties = this.callParent(arguments);
				properties.EntitySchemaName = "entitySchemaName";
				return properties;
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#initDashboardConfig
			 * @override
			 */
			initDashboardConfig: function() {
				this.callParent(arguments);
				const dashboardConfig = this.get("DashboardConfig");
				const processItemsConfig = {
					"VwProcessDashboard": {
						masterColumnName: "Id",
						referenceColumnName: "EntityId",
						viewModelClassName: "Terrasoft.ProcessDashboardItemViewModel",
						viewConfigClassName: "Terrasoft.BaseDashboardItemViewConfig"
					}
				};
				const activityItemsConfig = {
					"Activity": {
						viewModelClassName: "Terrasoft.ActivityDashboardItemViewModel",
						viewConfigClassName: "Terrasoft.BaseDashboardItemViewConfig"
					}
				};
				const approvalItemsConfig = this._getApprovalItemsConfig();
				const extendedConfig = this.values.dashboardConfig || {};
				Ext.merge(dashboardConfig, processItemsConfig);
				Ext.merge(dashboardConfig, activityItemsConfig);
				Ext.merge(dashboardConfig, extendedConfig);
				Ext.merge(dashboardConfig, approvalItemsConfig);
				this.set("DashboardConfig", dashboardConfig);
			},

			/**
			 * Init approval dashboard.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initApprovalActionsDashboard: function(callback, scope) {
				Terrasoft.chain(
					function(next) {
						const managers = [
							Terrasoft.SectionManager,
							Terrasoft.SysModuleVisaManager,
							Terrasoft.EntitySchemaManager
						];
						Terrasoft.eachAsyncAll(managers, function(manager, nextAsync) {
							manager.initialize(nextAsync, this);
						}, next, this);
					},
					function(next) {
						const visaManagerItem = this._findVisaManagerItem();
						if (visaManagerItem) {
							const visaEntityItem = this._findVisaEntityItem(visaManagerItem);
							const approvalSchemaName = visaEntityItem.getName();
							this.set("ApprovalSchemaName", approvalSchemaName);
							this._findVisaReferenceColumnName(visaManagerItem, next, this);
						} else {
							callback.call(scope);
						}
					},
					function(next, approvalReferenceColumnName) {
						this.set("ApprovalReferenceColumnName", approvalReferenceColumnName);
						callback.call(scope);
					},
					this
				);
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#init
			 * @override
			 */
			init: function(callback, scope) {
				const parentMethod = this.getParentMethod();
				Terrasoft.chain(
					function(next) {
						this.Terrasoft.EntitySchemaManager.initialize(next, this);
					},
					function(next) {
						this.initDcmConfig();
						this.initEntitySchema();
						this.initDcmActionsDashboard(next, this);
					},
					function(next) {
						const entitySchemaName = this.values.entitySchemaName;
						if (entitySchemaName && !this.get("EntitySchema")) {
							const schema = Terrasoft.EntitySchemaManager.findItemByName(entitySchemaName);
							Terrasoft.EntitySchemaManager.getPackageSchemaInstanceBySchemaName(
								entitySchemaName, schema.packageUId, function(instance) {
									this.set("EntitySchema", instance);
									next();
								}, this
							);
						} else {
							next();
						}
					},
					function(next) {
						this.initDefaultValues(next, this);
					},
					function(next) {
						this.onDefaultValuesInitialized(next, this);
					},

					function(next) {
						this.initApprovalActionsDashboard(next, this);
					},
					function(next) {
						parentMethod.call(this, next, this);
					},
					function(next) {
						Ext.callback(callback, scope);
						if (this.get("DcmSchema")) {
							this.initDcmActionsAndPermissions(function() {
								this.set("HeaderVisible", true);
							}, this);
						} else {
							next();
						}
					},
					function(next) {
						const hasAnyDcm = this.getMasterEntityParameterValue("HasAnyDcm");
						if (hasAnyDcm) {
							this.set("HeaderVisible", false);
						} else {
							this.initActionsSchema(next, this);
						}
					},
					function(next) {
						this.initActionsControl(next, this);
					},
					function() {
						this.setActionsDashboardInitialized();
					}, this
				);
			},
			
			/**
			 * Sets IsSectionActionsDashboardInitialized property.
			 * @protected
			 */
			setActionsDashboardInitialized: function () {
				this.set("IsSectionActionsDashboardInitialized", true);
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#initProperties
			 * @override
			 */
			initProperties: function() {
				this.callParent(arguments);
				this.initIsMasterEntityInitialized();
			},

			/**
			 * Returns section id by EntitySchema Name parameter.
			 * @protected
			 * @return {GUID} section id.
			 */
			getSectionId: function() {
				const entitySchema = this.get("EntitySchema");
				if (!entitySchema) {
					return;
				}
				const sectionInfo = Terrasoft.configuration.ModuleStructure[entitySchema.name];
				return sectionInfo ? sectionInfo.moduleId : null;
			},

			/**
			 * Reloads module.
			 */
			reload: function() {
				this.setActiveActionId();
				this.handleActiveActionChange();
				const hasAnyDcm = this.getMasterEntityParameterValue("HasAnyDcm");
				if (!hasAnyDcm) {
					this.initActionsControl();
				}
				this.initDashboard();
				this.sandbox.publish("DashboardRealoaded", null);
			},

			/**
			 * Returns name of the primary column of EntitySchema.
			 * @return {String} Name of the column.
			 */
			getEntitySchemaPrimaryColumnName: function() {
				const entitySchema = this.get("EntitySchema");
				return entitySchema.primaryColumnName || entitySchema.primaryColumn.name;
			},

			/**
			 * Returns value of primary column of EntitySchema.
			 * @return {Object} Value of columns,
			 */
			getEntitySchemaPrimaryColumnValue: function() {
				const primaryColumnName = this.getEntitySchemaPrimaryColumnName();
				return this.getMasterEntityParameterValue(primaryColumnName);
			},

			/**
			 * Gets actual action value of ActionColumn from DB and reloads ActionsControl.
			 * @protected
			 */
			reloadActionControl: function() {
				const esq = this.getActionsColumnValueQuery();
				const primaryColumnValue = this.getEntitySchemaPrimaryColumnValue();
				Terrasoft.chain(
					function(next) {
						esq.getEntity(primaryColumnValue, next, this);
					},
					function(next, response) {
						this.getActionsColumnValueCallback(response);
					}, this
				);
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#onReloadDashboardItems
			 * @override
			 */
			onReloadDashboardItems: function() {
				this.callParent(arguments);
				this.reloadActionControl();
			},

			/**
			 * Master's entity initialized event.
			 * @protected
			 */
			onEntityInitialized: function() {
				this.set("IsMasterEntityInitialized", true);
				this.reload();
			},

			/**
			 * Master's entity column change event.
			 * @protected
			 * @param {Object} changedColumn Master's changed column.
			 * @param {String} changedColumn.columnValue Column value.
			 * @param {String} changedColumn.columnName Column name.
			 */
			onCardColumnChanged: function(changedColumn) {
				if (this.get("ActionsColumnName") === changedColumn.columnName) {
					this.setActiveActionId();
					this.handleActiveActionChange();
				}
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#subscribeSandboxEvents
			 * @override
			 */
			subscribeSandboxEvents: function() {
				this.callParent(arguments);
				const sandbox = this.sandbox;
				const tags = [sandbox.id];
				sandbox.subscribe("EntityInitialized", this.onEntityInitialized, this, tags);
				sandbox.subscribe("GetEntityColumnChanges", this.onCardColumnChanged, this, tags);
				sandbox.subscribe("ReInitializeActionsDashboard", this.reInitializeActionsDashboard, this, tags);
				this.sandbox.subscribe("CanBeDestroyed", this.onCanBeDestroyedQuery, this);
			},

			/**
			 * Adds columns to actions entitySchemaQuery.
			 * @protected
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq Actions entitySchemaQuery.
			 */
			addActionsColumns: function(esq) {
				const primaryColumnName = this.get("ActionsPrimaryColumnName");
				const primaryDisplayColumnName = this.get("ActionsPrimaryDisplayColumnName");
				const colorColumn = this.get("ActionsColorColumnName");
				esq.addColumn(primaryColumnName, "PrimaryColumn");
				esq.addColumn(primaryDisplayColumnName, "PrimaryDisplayColumn");
				if (colorColumn) {
					esq.addColumn(colorColumn, "Color");
				}
			},

			/**
			 * Adds sorting to actions entitySchemaQuery.
			 * @protected
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq Actions entitySchemaQuery.
			 */
			addActionsSorting: function(esq) {
				let orderColumn = this.get("ActionsOrderColumnName");
				if (orderColumn) {
					orderColumn = esq.addColumn(orderColumn, "SortColumn");
					orderColumn.orderDirection = Terrasoft.OrderDirection.ASC;
				} else {
					const columns = esq.columns;
					const primaryDisplayColumn = columns.get("PrimaryDisplayColumn");
					primaryDisplayColumn.orderDirection = Terrasoft.OrderDirection.ASC;
				}
				const innerOrderColumnName = this.get("ActionsInnerOrderColumnName");
				if (innerOrderColumnName) {
					const innerOrderColumn = esq.addColumn(innerOrderColumnName, "InnerSortColumn");
					innerOrderColumn.orderDirection = Terrasoft.OrderDirection.ASC;
				}
			},

			/**
			 * Adds filters to actions entitySchemaQuery.
			 * @protected
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq Actions entitySchemaQuery.
			 */
			addActionsFilters: function(esq) {
				const filterColumn = this.get("ActionsFilterColumnName");
				if (filterColumn) {
					esq.filters.add("displayFilter", Terrasoft.createColumnFilterWithParameter(
						Terrasoft.ComparisonType.EQUAL, filterColumn, true));
				}
			},

			/**
			 * Creates entitySchemaQuery that selects actions.
			 * @protected
			 * @return {Terrasoft.data.queries.EntitySchemaQuery} Query to EntitySchema of actions.
			 */
			getActionsQuery: function() {
				const schemaName = this.get("ActionsSchemaName");
				if (!schemaName) {
					return null;
				}
				const esq = this.createEntitySchemaQuery(schemaName);
				this.addActionsColumns(esq);
				this.addActionsSorting(esq);
				this.addActionsFilters(esq);
				return esq;
			},

			/**
			 * Returns entitySchemaQuery that selects decoupling items for actions.
			 * @protected
			 * @return {Terrasoft.EntitySchemaQuery|*} Decoupling items select query.
			 */
			getDecouplingQuery: function() {
				let esq = null;
				const config = this.get("DecouplingConfig");
				if (config && config.name && config.masterColumnName && config.referenceColumnName) {
					esq = this.createEntitySchemaQuery(config.name);
					esq.addColumn(config.masterColumnName, "Master");
					esq.addColumn(config.referenceColumnName, "Reference");
				}
				return esq;
			},

			/**
			 * Initializes actionControl.
			 * @protected
			 * @param {Function} [callback] Callback function.
			 * @param {Object} [scope] Execution context.
			 */
			initActionsControl: function(callback, scope) {
				const actionEsq = this.getActionsQuery();
				if (!actionEsq) {
					Ext.callback(callback, scope || this);
					return;
				}
				const batchQuery = Ext.create("Terrasoft.BatchQuery");
				batchQuery.add(actionEsq);
				const decouplingEsq = this.getDecouplingQuery();
				if (decouplingEsq) {
					batchQuery.add(decouplingEsq);
				}
				batchQuery.execute(function(response) {
					this.initActions(response);
					Ext.callback(callback, scope || this);
				}, this);
				const key = this.sandbox.id + "initActionsControl";
				this.mixins.QueryCancellationMixin.registerSentQuery.call(this, key, batchQuery);
			},

			/**
			 * Sets availableStages property for action object.
			 * @protected
			 * @param {Object} action Action object.
			 */
			setAvailableActions: function(action) {
				const decouplingItems = this.get("DecouplingItems");
				if (decouplingItems) {
					const availableStages = Ext.Array.filter(decouplingItems, function(item) {
						const master = item.Master;
						return master.value === action.get("Id");
					});
					const availableStagesReferences = [];
					Terrasoft.each(availableStages, function(availableAction) {
						const reference = availableAction.Reference;
						availableStagesReferences.push(reference.value);
					}, this);
					action.set("AvailableStages", availableStagesReferences);
				}
			},

			/**
			 * Creates item for actions collection.
			 * @protected
			 * @virtual
			 * @param {Object} itemData Data for single item, contains values for columns defined in
			 * {@link #getActionsQuery} query.
			 */
			createActionsItem: function(itemData) {
				const id = itemData.PrimaryColumn;
				const caption = itemData.PrimaryDisplayColumn;
				const item = this.createActionItemModel();
				item.set("Id", id);
				item.set("Caption", caption);
				let color = itemData.Color;
				if (this.isEmpty(color)) {
					const defaultColor = this.get("DefaultActionsDashboardStageItemColor");
					if (!this.isEmpty(defaultColor)) {
						color = defaultColor;
					}
				}
				item.set("Color", color);
				item.set("Order", itemData.SortColumn);
				item.set("InnerOrder", itemData.InnerSortColumn);
				this.setAvailableActions(item);
				return item;
			},

			/**
			 * Sets DecouplingItems property.
			 * @protected
			 * @param {Object} decouplingQueryResults Results of entity schema query to decoupling table.
			 */
			setDecouplingItems: function(decouplingQueryResults) {
				if (decouplingQueryResults) {
					this.set("DecouplingItems", decouplingQueryResults.rows);
				}
			},

			/**
			 * Iterates collection through actions and theirs menu items.
			 * @protected
			 * @param {Terrasoft.data.model.BaseViewModelCollection} actions Actions collection.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Callback scope.
			 */
			iterateActions: function(actions, callback, scope) {
				if (!actions) {
					return;
				}
				let index = 0;
				actions.each(function(item) {
					Ext.callback(callback, scope, [item, index++]);
					const menu = item.get("Menu");
					if (menu) {
						menu.each(function(menuItem) {
							Ext.callback(callback, scope, [menuItem, index++]);
						}, this);
					}
				}, this);
			},

			/**
			 * Sets displayColor and hoverColor properties for all actions.
			 * @protected
			 * @param {Terrasoft.data.model.BaseViewModelCollection} actions Collection of stage control items.
			 */
			setActionsColor: function(actions) {
				const currentAction = this.get("ActiveAction");
				if (this.isEmpty(currentAction)) {
					return;
				}
				const currentActionColor = currentAction.get("Color");
				const currentActionIndex = this.getActionIndex(currentAction, actions);
				this.iterateActions(actions, function(item, index) {
					if (index <= currentActionIndex) {
						item.set("DisplayColor", currentActionColor);
					} else {
						item.set("DisplayColor", "");
					}
					const hoverColor = Terrasoft.shadeColor(currentActionColor, 0.5);
					item.set("HoverColor", hoverColor);
				}, this);
			},

			/**
			 * Loads actions collection.
			 * @param {Terrasoft.BaseViewModelCollection} actions Actions collection.
			 */
			loadActionsCollection: function(actions) {
				const collection = this.get("ActionsCollection");
				collection.clear();
				collection.loadAll(actions);
			},

			/**
			 * Returns array of stages available for transition.
			 * @protected
			 * @param {Terrasoft.data.model.BaseViewModelCollection} actions Actions collection.
			 * @return {Array} Array of stages available for transition.
			 */
			getAvailableStages: function(actions) {
				actions = actions || this.get("ActionsCollection");
				const currentAction = this.get("ActiveAction");
				const isActiveActionExists = this.checkIfActiveActionExists(actions);
				let availableStages = [];
				if (!isActiveActionExists) {
					this.iterateActions(actions, function(action) {
						availableStages.push(action.get("Id"));
					}, this);
				} else if (currentAction) {
					availableStages = currentAction.get("AvailableStages");
				} else {
					return null;
				}
				return availableStages;
			},

			/**
			 * Sets isEnabled property for all actions.
			 * @param {Terrasoft.BaseViewModelCollection} actions Actions collection.
			 * @protected
			 */
			setActionsEnabled: function(actions) {
				const availableStages = this.getAvailableStages(actions);
				if (!availableStages) {
					return;
				}
				this.iterateActions(actions, function(action) {
					const id = action.get("Id");
					const isEnabled = this.getCanUseAction(action) && Terrasoft.contains(availableStages, id);
					action.set("Enabled", isEnabled);
					const parentAction = action.parentAction;
					if (parentAction) {
						parentAction.set("Enabled", parentAction.get("Enabled") || isEnabled);
					}
				}, this);
			},

			/**
			 * Sets isActive property for all actions.
			 * @protected
			 * @param {Terrasoft.BaseViewModelCollection} actions Collection of stage control items.
			 */
			setActionsIsActive: function(actions) {
				const currentAction = this.get("ActiveAction");
				if (this.isEmpty(currentAction)) {
					return;
				}
				const currentActionIndex = this.getActionIndex(currentAction, actions);
				this.iterateActions(actions, function(action, index) {
					action.set("IsActive", index === currentActionIndex);
					action.set("IsPassed", index <= currentActionIndex);
					const parentAction = action.parentAction;
					if (parentAction) {
						parentAction.set("IsActive", parentAction.get("IsActive") || action.get("IsActive"));
					}
				}, this);
			},

			/**
			 * Performs change of ActiveAction, actions color and isEnabled properties.
			 * @protected
			 * @param {Terrasoft.data.model.BaseViewModelCollection} [actions] Collection of stage control items.
			 */
			handleActiveActionChange: function(actions) {
				actions = actions || this.get("ActionsCollection");
				if (!actions) {
					return;
				}
				this.setActiveAction(actions);
				this.setActionsColor(actions);
				this.setActionsEnabled(actions);
				this.setActionsIsActive(actions);
				this.loadActionsCollection(actions.clone());
			},

			/**
			 * Sets ActionsCollection property.
			 * @protected
			 * @param {Object} response EntitySchemaQuery response.
			 */
			initActions: function(response) {
				if (!response.success) {
					return;
				}
				const queryResults = response.queryResults;
				const items = queryResults[0].rows;
				const decouplingQueryResults = queryResults[1];
				this.setDecouplingItems(decouplingQueryResults);
				let innerCollection = this.createActionsCollection(items);
				innerCollection = this.createActionsMenu(innerCollection);
				this.handleActiveActionChange(innerCollection);
			},

			/**
			 * Creates collection of actions.
			 * @protected
			 * @param {Array} items Array of items from which action collection is created.
			 * @return {Terrasoft.BaseViewModelCollection} Collection of actions.
			 */
			createActionsCollection: function(items) {
				const innerCollection = Ext.create("Terrasoft.BaseViewModelCollection");
				Terrasoft.each(items, function(itemData) {
					const actionsItem = this.createActionsItem(itemData);
					innerCollection.add(itemData.PrimaryColumn, actionsItem);
				}, this);
				return innerCollection;
			},

			/**
			 * Creates menus for actions.
			 * @protected
			 * @param {Terrasoft.data.model.BaseViewModelCollection} items Actions.
			 * @return {Terrasoft.data.model.BaseViewModelCollection} Collection of items with formed menus.
			 */
			createActionsMenu: function(items) {
				let previousItem;
				const sourceCollection = items.clone();
				items.clear();
				sourceCollection.each(function(item) {
					if (this.isMenuItem(item, previousItem)) {
						this.addMenuItem(previousItem, item);
						item.parentAction = previousItem;
					} else {
						previousItem = item;
						items.addItem(item);
					}
				}, this);
				return items;
			},

			/**
			 * Determines whether the item is the menu item to the previous item.
			 * @protected
			 * @virtual
			 * @param {Terrasoft.model.BaseViewModel} item
			 * @param {Terrasoft.model.BaseViewModel} previousItem
			 * @return {Boolean} The check result.
			 */
			isMenuItem: function(item, previousItem) {
				if (this.get("DcmSchema")) {
					return this.isDcmMenuItem(item, previousItem);
				} else {
					const order = previousItem && previousItem.get("Order");
					return item.get("Order") === order;
				}
			},

			/**
			 * Adds menu item to root action item.
			 * @param {Terrasoft.model.BaseViewModel} item Root action item.
			 * @param {Terrasoft.model.BaseViewModel} menuItem Action menu item.
			 */
			addMenuItem: function(item, menuItem) {
				let menu = item.get("Menu");
				if (!menu) {
					menu = Ext.create("Terrasoft.BaseViewModelCollection");
					item.set("Menu", menu);
				}
				if (menu.getCount() === 0) {
					const clone = this.createActionItemModel(item.changedValues);
					menu.add(clone.get("Id"), clone);
					clone.parentAction = item;
				}
				menu.add(menuItem.get("Id"), menuItem);
			},

			/**
			 * Created view model object.
			 * @protected
			 * @param {Object} [values] View model values.
			 * @return {Terrasoft.BaseViewModel} Created object.
			 */
			createActionItemModel: function(values) {
				values = values || {};
				return Ext.create("Terrasoft.BaseViewModel", {
					values: values
				});
			},

			/**
			 * Set process execution data for every collection item.
			 * @protected
			 * @param {Terrasoft.data.model.BaseViewModelCollection} collection Items collection.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			loadExecutionData: function(collection, callback, scope) {
				if (collection.isEmpty()) {
					callback.call(scope);
					return;
				}
				const elementUIds = this.getElementUIds(collection);
				const request = Ext.create("Terrasoft.DcmExecutionDataRequest", {elementUIds: elementUIds});
				request.execute(function(response) {
					if (response.success) {
						Terrasoft.each(response.batch, function(responseItem) {
							if (responseItem.success) {
								this.setItemExecutionData(responseItem, collection);
								this.setItemRequiredType(responseItem, collection);
							} else {
								this.error(responseItem.errorInfo.message);
							}
						}, this);
					} else {
						this.error(response.errorInfo.toString());
					}
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#loadDashboardItems
			 * @override
			 */
			loadDashboardItems: function(callback, scope) {
				if (!this.get("IsMasterEntityInitialized")) {
					this.clearDashboardItems();
					Terrasoft.ActionsDashboardUtils.hideMask();
					this.set("IsDashboardItemsLoading", false);
					Ext.callback(callback, scope);
					return;
				}
				const dashboardItems = this.get("DashboardItems");
				const collection = Ext.create("Terrasoft.BaseViewModelCollection");
				const batchQuery = this.getItemsQuery();
				const activityQuery = batchQuery.queries[0].query;
				activityQuery.on("createviewmodel", this.createDashboardItemViewModel, this);
				const useFastLoadDashboard = this._getCanUseFastLoadDcmActionDashboard();
				const useProcessDashboardRequest = Terrasoft.Features.getIsEnabled("ProcessDashboardRequest");
				Terrasoft.chain(
					function(next) {
						batchQuery.execute(next, this);
						const key = this.sandbox.id + "loadDashboardItems";
						this.mixins.QueryCancellationMixin.registerSentQuery.call(this, key, batchQuery);
					},
					function(next, batchQueryResult) {
						Terrasoft.each(batchQueryResult.queryResults, function(result) {
							this.addDashBoardItemViewModel(result, collection, activityQuery);
						}, this);
						next();
					},
					function(next) {
						if (useProcessDashboardRequest) {
							if (useFastLoadDashboard) {
								this._processActionDashboardRequest("ProcessActionDashboardRequest", collection, next, this);
							} else {
								this._processDashboardRequest(next, this);
							}
						} else {
							next();
						}
					},
					function(next, result) {
						if (useProcessDashboardRequest) {
							if (useFastLoadDashboard) {
								this._addActionDashboardItemViewModel(result, collection, activityQuery);
							} else {
								this.addDashBoardItemViewModel(result, collection, activityQuery);
							}
						}
						next();
					},
					function(next) {
						collection.sortByFn(this.sortItemsByDateAsc);
						dashboardItems.clear();
						dashboardItems.loadAll(collection);
						next();
					},
					function(next) {
						if (useFastLoadDashboard) {
							next();
						} else {
							this.loadExecutionData(dashboardItems, next, this);
						}
					},
					function() {
						Terrasoft.ActionsDashboardUtils.hideMask();
						this.set("IsDashboardItemsLoading", false);
						Ext.callback(callback, scope);
					},
					this
				);
			},

			/**
			 * Create ViewModel for item of dashboard.
			 * @return {Terrasoft.BaseDashboardItemViewModel} Instance of ViewModel.
			 */
			createDashboardItemViewModel: function(config) {
				const values = config.rawData;
				const viewModelClassName = this.getDashboardItemViewModelClassName(values.EntitySchemaName);
				const viewModel = Ext.create(viewModelClassName, {
					Ext: Ext,
					sandbox: this.sandbox,
					Terrasoft: Terrasoft
				});
				Terrasoft.each(values, function(column, columnName) {
					viewModel.setColumnValue(columnName, column);
				}, this);
				viewModel.init();
				config.viewModel = viewModel;
				return viewModel;
			},

			/**
			 * Returns name of the ViewModel class for items of dashboard.
			 * @protected
			 * @param {String} entitySchemaName Name of the EntitySchema.
			 * @return {String} Name of the ViewModel class.
			 */
			getDashboardItemViewModelClassName: function(entitySchemaName) {
				const config = this.getDashboardItemsConfig(entitySchemaName);
				return config && config.viewModelClassName;
			},

			/**
			 * Function for sorting items of dashboard by date.
			 * @param {Terrasoft.model.BaseViewModel} itemA Comparable item.
			 * @param {Terrasoft.model.BaseViewModel} itemB Comparable item.
			 * @return {Number} Result.
			 */
			sortItemsByDateAsc: function(itemA, itemB) {
				let dateA = itemA && itemA.get("Date");
				let dateB = itemB && itemB.get("Date");
				dateA = new Date(dateA).getTime();
				dateB = new Date(dateB).getTime();
				if (dateA === dateB) {
					return 0;
				}
				return (dateA < dateB) ? -1 : 1;
			},

			/**
			 * Sets ActionsPrimaryColumnName and ActionsPrimaryDisplayColumnName
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Executions context.
			 */
			setActionsPrimaryColumnNames: function(callback, scope) {
				const actionsSchemaName = this.get("ActionsSchemaName");
				Terrasoft.require([actionsSchemaName], function(response) {
					if (response) {
						this.set("ActionsPrimaryColumnName", response.primaryColumnName);
						this.set("ActionsPrimaryDisplayColumnName", response.primaryDisplayColumnName);
					}
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Sets names of action columns.
			 * @protected
			 * @param {Object} actionsConfig Configuration object containing names of columns.
			 */
			setActionsColumns: function(actionsConfig) {
				if (!actionsConfig) {
					return;
				}
				const actionsSchemaName = actionsConfig.schemaName;
				this.set("ActionsSchemaName", actionsSchemaName);
				const actionColumnName = actionsConfig.columnName;
				this.set("ActionsColumnName", actionColumnName);
				const colorColumnName = actionsConfig.colorColumnName;
				this.set("ActionsColorColumnName", colorColumnName);
				const filterColumnName = actionsConfig.filterColumnName;
				this.set("ActionsFilterColumnName", filterColumnName);
				const orderColumnName = actionsConfig.orderColumnName;
				this.set("ActionsOrderColumnName", orderColumnName);
				const innerOrderColumnName = actionsConfig.innerOrderColumnName;
				this.set("ActionsInnerOrderColumnName", innerOrderColumnName);
				const decouplingConfig = actionsConfig.decouplingConfig;
				this.set("DecouplingConfig", decouplingConfig);
				this.setActiveActionId(actionsSchemaName);
			},

			/**
			 * Sets identifier of active action.
			 * @protected
			 */
			setActiveActionId: function() {
				const columnName = this.get("ActionsColumnName");
				const currentAction = this.getMasterEntityParameterValue(columnName);
				const activeActionId = currentAction ? currentAction.value : null;
				this.set("ActiveActionId", activeActionId);
			},

			/**
			 * Initializes default values.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			initDefaultValues: function(callback, scope) {
				const sysSettingsNames = this.getSysSettingsCodes();
				Terrasoft.SysSettings.querySysSettings(sysSettingsNames, function(values) {
					Terrasoft.each(values, function(settingValue, settingName) {
						this.set(settingName, settingValue);
					}, this);
					callback.call(scope);
				}, this);
			},

			/**
			 * Default values initialized handler.
			 * @param callback Callback function.
			 * @param scope scope applied to callback.
			 */
			onDefaultValuesInitialized: function(callback, scope) {
				Ext.callback(callback, scope);
			},

			/**
			 * Returns codes for system settings which values are need to be initialized.
			 * @protected
			 */
			getSysSettingsCodes: function() {
				return ["DefaultActionsDashboardStageItemColor", "ShowChangeStageConfirmDialog"];
			},

			/**
			 * Sets actionsSchema properties.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			initActionsSchema: function(callback, scope) {
				const actionsConfig = this.values.actionsConfig;
				this.set("HeaderVisible", !Ext.isEmpty(actionsConfig));
				this.setActionsColumns(actionsConfig);
				this.setActionsPrimaryColumnNames(callback, scope);
			},

			/**
			 * @inheritdoc Terrasoft.BaseActionsDashboard#getDashboardTabCaption
			 * @override
			 */
			getDashboardTabCaption: function(value) {
				value = value || 0;
				const captionPattern = this.get("Resources.Strings.DashboardTabCaptionPattern");
				const queryItemsBatchSize = this.get("QueryItemsBatchSize");
				if (value >= queryItemsBatchSize) {
					value = Ext.String.format("{0}+", queryItemsBatchSize);
				}
				const caption = Ext.String.format(captionPattern, value);
				return caption;
			},

			/**
			 * Returns set of the queries for loading of dashboard.
			 * @protected
			 * @return {Terrasoft.BatchQuery} Set of the queries.
			 */
			getItemsQuery: function() {
				const bq = Ext.create("Terrasoft.BatchQuery");
				const activityItemsQuery = this.getActivityItemsQuery();
				const processItemsQuery = this.getProcessItemsQuery();
				const visaItemsQuery = this._getVisaItemsQuery();
				const queryItemsBatchSize = this.get("QueryItemsBatchSize");
				processItemsQuery.rowCount = queryItemsBatchSize;
				if (visaItemsQuery) {
					bq.add(visaItemsQuery);
					visaItemsQuery.rowCount = queryItemsBatchSize;
				}
				bq.add(activityItemsQuery);
				if (!Terrasoft.Features.getIsEnabled("ProcessDashboardRequest")) {
					bq.add(processItemsQuery);
				}
				return bq;
			},

			/**
			 * Returns name of the ViewConfig class for items of dashboard.
			 * @protected
			 * @param {String} entitySchemaName Name of the EntitySchema.
			 * @return {String} Name of the ViewConfig class.
			 */
			getDashboardItemViewConfigClassName: function(entitySchemaName) {
				const config = this.getDashboardItemsConfig(entitySchemaName);
				return config && config.viewConfigClassName;
			},

			/**
			 * Action change event handler.
			 * @protected
			 * @param {*} value New action value.
			 */
			onActionChanged: function(value) {
				const activeActionId = value.value;
				this.set("ActiveActionId", activeActionId);
				const key = this.get("ActionsColumnName");
				this.setMasterEntityParameterValue(key, value);
				this._setIsInActionChangedMode(true);
				this.saveMasterEntity({
					callback: this._setIsInActionChangedMode.bind(this, false),
					scope: this
				}, this);
			},

			/**
			 * @private
			 */
			_setIsInActionChangedMode: function(value) {
				this.set("IsInActionChangedMode", value);
			},

			/**
			 * Publishes the SaveRecord message.
			 * @protected
			 * @param {Object} config for SaveRecord message.
			 * @param {Object} scope Execution context.
			 */
			saveMasterEntity: function(config, scope) {
				const sandbox = this.sandbox;
				let callback = Ext.emptyFn;
				let contextForCallback = scope;
				if (config) {
					callback = config.callback || callback;
					contextForCallback = config.scope || contextForCallback;
					delete config.callback;
					delete config.scope;
				}
				const saveMasterEntityConfig = this.getSaveMasterEntityConfig(callback, contextForCallback);
				Ext.apply(saveMasterEntityConfig, config);
				this._updateStateObject();
				sandbox.publish("SaveRecord", saveMasterEntityConfig, [sandbox.id]);
			},

			/**
			 * Returns config for the "SaveRecord" message.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 * @return {Object} Config.
			 */
			getSaveMasterEntityConfig: function(callback, scope) {
				return {
					isSilent: true,
					callback: this.onMasterEntitySaved.bind(this, callback, scope),
					callBaseSilentSavedActions: true,
					scope: this
				};
			},

			/**
			 * The callback function of the SaveRecord message.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			onMasterEntitySaved: function(callback, scope) {
				this.set("IsMasterEntityInitialized", true);
				Ext.callback(callback, scope || this);
				this.reloadMasterEntityCard();
			},

			/**
			 * Reloads master entity record from database.
			 * @protected
			 */
			reloadMasterEntityCard: function() {
				const sandbox = this.sandbox;
				const operation = this.getMasterEntityParameterValue("Operation");
				if (operation === Terrasoft.ConfigurationEnums.CardOperation.EDIT) {
					sandbox.publish("ReloadCard", null, [sandbox.id]);
				} else {
					this.loadDashboardItems();
				}
			},

			/**
			 * Returns message type of module to be loaded to the tab container
			 * @return {String} Message type
			 */
			getMessageType: function() {
				const activeTabName = this.get("ActiveTabName");
				const tab = this.getTabByName(activeTabName);
				return tab.get("Tag");
			},

			/**
			 * Renders the message module.
			 */
			onMessageModuleRendered: function() {
				const messageType = this.getMessageType();
				if (!messageType) {
					return;
				}
				const messagePublisherModule = messageType + "MessagePublisherModule";
				const moduleId = this.sandbox.id + "_" + messagePublisherModule;
				const moduleContainerId = messageType + "MessageModule";
				const rendered = this.sandbox.publish("RerenderPublisherModule", {
					renderTo: moduleContainerId
				}, [moduleId]);
				if (!rendered) {
					this.subscribePublisher(moduleId);
					const messagePublishersModuleConfig = {
						renderTo: moduleContainerId
					};
					this.sandbox.loadModule(messagePublisherModule, messagePublishersModuleConfig);
				}
			},

			/**
			 * Execute subscribe for messages for all publishers.
			 * @protected
			 * @param {String} moduleId Id of module.
			 */
			subscribePublisher: function(moduleId) {
				this.sandbox.subscribe("GetPropertiesByName", this.onGetPropertiesByName, this, [moduleId]);
			},

			/**
			 * Handler event GetPropertiesByName. Returns columns value of object.
			 * @param {String[]} columnNames Array identifiers columns.
			 * @protected
			 * @return {Object} Column value.
			 */
			onGetPropertiesByName: function(columnNames) {
				const columnValues = {};
				Terrasoft.each(columnNames, function(columnName) {
					columnValues[columnName] = this.get(columnName);
				}, this);
				return columnValues;
			},

			/**
			 * @private
			 */
			_checkStageChangeDialog: function(value) {
				if (!this.get("ShowChangeStageConfirmDialog")) {
					return true;
				}
				this.showStageChangeDialog(function() {
					this.onActionChanged({
						value: value
					});
				}, this);
				return false;
			},

			/**
			 * Handles active stage click event.
			 * @protected
			 * @param {GUID} oldValue Old action stage id.
			 * @param {GUID} value New action stage id.
			 * @return {Boolean} Event result.
			 */
			onActiveStageClick: function(oldValue, value) {
				if (!this._isMasterEntityValid()) {
					return false;
				}
				return this._checkStageChangeDialog(value);
			},

			/**
			 * Handles active stage click async event.
			 * @protected
			 * @param {GUID} oldValue Old action stage id.
			 * @param {GUID} value New action stage id.
			 * @return {Boolean} Event result.
			 */
			onActiveStageClickAsync: async function(oldValue, value, displayValue) {
				const isValid = await this._isMasterEntityValidAsync();
				if (isValid && this._checkStageChangeDialog(value)) {
					this.onActionChanged({
						value: value,
						displayValue: displayValue
					});
				}
			},

			/**
			 * Set module destroying ability dependent on child modules.
			 * @param {String} cacheKey Identifier of the current cache.
			 */
			onCanBeDestroyedQuery: function(cacheKey) {
				this.sandbox.publish("GetPublisherPageState", cacheKey);
				const cacheItem = Terrasoft.ClientPageSessionCache.getItem(cacheKey);
				Ext.Array.each(cacheItem.childModules, function(module) {
					if (module.canBeDestroyed === false) {
						cacheItem.canBeDestroyed = false;
						cacheItem.errorInfo = {message: module.message};
					}
				});
			},

			/**
			 * Shows stage change confirmation dialog window.
			 * @protected
			 * @param {Function} callback Callback.
			 * @param {Object} scope Scope.
			 */
			showStageChangeDialog: function(callback, scope) {
				Terrasoft.chain(
					function(next) {
						this.showConfirmationDialog(
							this.get("Resources.Strings.StageChangeDialogText"),
							next,
							[Terrasoft.MessageBoxButtons.YES.returnCode, Terrasoft.MessageBoxButtons.NO.returnCode],
							null
						);
					},
					function(next, returnCode) {
						if (returnCode === Terrasoft.MessageBoxButtons.YES.returnCode) {
							Ext.callback(callback, scope);
						}
					}, this
				);
			},

			/**
			 * @inheritdoc Terrasoft.BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				this.mixins.QueryCancellationMixin.abortRegisteredQueries.call(this);
				this.callParent(arguments);
			},

			// region Methods: Private

			/**
			 * Returns task page entity structure.
			 * @private
			 * @return {Object|null} Task page entity structure.
			 */
			getTaskEntityStructure: function(operation) {
				const taskTypeUId = ConfigurationConstants.Activity.Type.Task;
				const activityEntityStructure = this.Terrasoft.configuration.EntityStructure.Activity;
				var pages = activityEntityStructure && activityEntityStructure.pages;
				if (!pages) {
					return null;
				}
				if (operation) {
					pages = pages.filter(p => p.actions && p.actions[operation]);
				}
				return this.Terrasoft.findWhere(pages, {UId: taskTypeUId});
			},

			/**
			 * Initialize IsMasterEntityInitialized attribute.
			 * @private
			 */
			initIsMasterEntityInitialized: function() {
				const masterColumnValue = this.getEntitySchemaPrimaryColumnValue();
				const isEntityInitialized = !Ext.isEmpty(masterColumnValue);
				this.set("IsMasterEntityInitialized", isEntityInitialized);
			},

			/**
			 * Generates ViewModel and sets ActiveAction property.
			 * @private
			 * @param {Terrasoft.BaseViewModelCollection} actions Collection of stage control items.
			 */
			setActiveAction: function(actions) {
				const activeActionId = this.get("ActiveActionId");
				actions = actions || this.get("ActionsCollection");
				let activeAction = {};
				this.iterateActions(actions, function(item) {
					if (item.get("Id") === activeActionId) {
						activeAction = item;
					}
				}, this);
				const actionParent = activeAction && activeAction.parentAction;
				if (actionParent) {
					actionParent.set("Caption", activeAction.get("Caption"));
				}
				this.set("ActiveAction", activeAction);
			},

			/**
			 * Returns action index including actions in menus.
			 * @private
			 * @param {Terrasoft.model.BaseViewModel} action Action item.
			 * @param {Terrasoft.data.model.BaseViewModelCollection} actions Collection of stage control items.
			 * @return {number} Action index.
			 */
			getActionIndex: function(action, actions) {
				actions = actions || this.get("ActionsCollection");
				let index = -1;
				this.iterateActions(actions, function(item, itemIndex) {
					if (item.get("Id") === action.get("Id")) {
						index = itemIndex;
					}
				}, this);
				return index;
			},

			/**
			 * Checks whether actions collection contains element with key that is equal to active action id.
			 * @private
			 * @param {Terrasoft.data.model.BaseViewModelCollection} actions Collection of stage control items.
			 * @return {Boolean} Returns true if actions collection contains activeAction.
			 */
			checkIfActiveActionExists: function(actions) {
				actions = actions || this.get("ActionsCollection");
				const activeActionId = this.get("ActiveActionId");
				let exist = false;
				this.iterateActions(actions, function(action) {
					exist = exist || action.get("Id") === activeActionId;
				}, this);
				return exist;
			},

			/**
			 * Clears dashboard items.
			 * @private
			 */
			clearDashboardItems: function() {
				const dashboardItems = this.get("DashboardItems");
				dashboardItems.clear();
				dashboardItems.loadAll();
			},

			/**
			 * Set process execution data for collection item by server response data item.
			 * @private
			 * @param {Object} responseItem Server response data item.
			 * @param {Terrasoft.data.model.BaseViewModelCollection} collection Items collection.
			 */
			setItemExecutionData: function(responseItem, collection) {
				const elementUId = responseItem.elementUId;
				const executionData = Ext.decode(responseItem.message);
				const firstItem = this._findDashboardItem(collection, elementUId);
				firstItem.setExecutionData(executionData);
			},

			/**
			 * Set process element required type for collection item by server response data item.
			 * @private
			 * @param {Object} responseItem Server response data item.
			 * @param {Terrasoft.BaseViewModelCollection} collection Items collection.
			 */
			setItemRequiredType: function(responseItem, collection) {
				const elementUId = responseItem.elementUId;
				const firstItem = this._findDashboardItem(collection, elementUId);
				const isRequired = responseItem.requiredType ===
					Terrasoft.DcmConstants.ElementRequiredType.REQUIRED.value;
				firstItem.set("IsRequired", isRequired);
			},

			/**
			 * Returns process element uIds array from view model collection items.
			 * @private
			 * @param {Terrasoft.data.model.BaseViewModelCollection} collection Items collection.
			 * @return {String[]}
			 */
			getElementUIds: function(collection) {
				const elementUIds = [];
				collection.each(function(item) {
					const elementUId = item.getProcessElementUId();
					if (elementUId) {
						elementUIds.push(elementUId);
					}
				});
				return elementUIds;
			},

			/**
			 * Adds dashboard item view model from esq result.
			 * @private
			 * @param {Object} result Query result.
			 * @param {Terrasoft.core.collections.Collection} collection Dashboard items collection.
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq Esq.
			 */
			addDashBoardItemViewModel: function(result, collection, esq) {
				Terrasoft.each(result.rows, function(row) {
					const id = row.Id = this.getDashboardItemId(row);
					row.EntitySchemaName = this.getDashboardItemEntitySchemaName(row);
					if (!collection.contains(id)) {
						const item = esq.getViewModelByQueryResult(row, result.rowConfig);
						collection.add(id, item);
					}
				}, this);
			},

			/**
			 * Returns found dashboard item by process element identifier.
			 * @private
			 * @param {Terrasoft.core.collections.Collection} collection Dashboard items collection.
			 * @param {String} elementId Identifier of the process element.
			 */
			_findDashboardItem: function(collection, elementId) {
				const filteredCollection = collection.filterByFn(function(item) {
					return item.getProcessElementUId() === elementId;
				});
				return filteredCollection.first();
			},

			/**
			 * @private
			 */
			_getRowData: function(id, row) {
				const rowData = Terrasoft.deepClone(row);
				rowData["EntitySchemaName"] = "VwProcessDashboard";
				rowData["ViewConfigClassName"] = "Terrasoft.BaseDashboardItemViewConfig";
				rowData["ProcessElement"] = {
					"value": row.ProcessElementId,
					"displayValue": "",
					"primaryImageValue": ""
				};
				rowData.EntitySchemaName = this.getDashboardItemEntitySchemaName(row);
				rowData.Id = id;
				return rowData;
			},

			/**
			 * Returns found dashboard item by process element identifier.
			 * @private
			 * @param {Terrasoft.core.collections.Collection} collection Dashboard items collection.
			 * @param {Object} row Data of the dashboard item.
			 * @param {Object} rowConfig Element column configuration, used to instantiate elements.
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq ESQ.
			 */
			_forceGetDashboardItem: function(collection, row, rowConfig, esq) {
				const id = this.getDashboardItemId(row);
				let item = collection.find(id);
				if (!item) {
					const rowData = this._getRowData(id, row);
					item = esq.getViewModelByQueryResult(rowData, rowConfig);
					collection.add(id, item);
				}
				return item;
			},

			/**
			 * Adds dashboard item view model from esq result.
			 * @private
			 * @param {Object} result Query result.
			 * @param {Terrasoft.core.collections.Collection} collection Dashboard items collection.
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq ESQ.
			 */
			_addActionDashboardItemViewModel: function(result, collection, esq) {
				Terrasoft.each(result.rows, function(row) {
					let item = this._findDashboardItem(collection, row.Id);
					if (!item) {
						item = this._forceGetDashboardItem(collection, row, result.rowConfig, esq);
					}
					item.set("IsRequired", row.IsRequired);
					this._assignCaption(item, row);
					this._assignOwner(item, row);
					this._setExecutionData(item, row);
				}, this);
			},

			/**
			 * @private
			 */
			_assignCaption: function(viewModel, row) {

				// TODO #CRM-63879
				const caption = viewModel.get("Caption");
				if (!caption) {
					const elementCaption = row.ElementCaption;
					viewModel.set("Caption", elementCaption);
				}
			},

			/**
			 * @private
			 */
			_assignOwner: function(viewModel, row) {
				const owner = viewModel.get("Owner");
				if (!owner) {
					const roleName = row.RoleName;
					const ownerName = row.Owner;
					viewModel.set("Owner", ownerName || roleName);
				}
			},

			/**
			 * @private
			 */
			_setExecutionData: function(viewModel, row) {
				viewModel.set("ExecutionData", {
					entitySchemaName: row["UserTaskEntitySchemaName"]
				});
			},

			/**
			 * Returns identifier value of the item.
			 * @private
			 * @param {Object} item Item of the dashboard.
			 */
			getDashboardItemId: function(item) {
				return item.EntityId || (item.ProcessElement && item.ProcessElement.value) || item.Id;
			},

			/**
			 * Returns name of the EntitySchema of the item.
			 * @private
			 * @param {Object} item Item of the dashboard.
			 */
			getDashboardItemEntitySchemaName: function(item) {
				const entitySchemaUId = item.EntitySchemaUId;
				const entitySchema = entitySchemaUId && Terrasoft.EntitySchemaManager.getItem(entitySchemaUId);
				return entitySchema ? entitySchema.name : item.EntitySchemaName;
			},

			/**
			 * Initialize "EntitySchema" parameter.
			 * @private
			 */
			initEntitySchema: function() {
				const entitySchemaName = this.values.entitySchemaName;
				const entitySchema = Terrasoft[entitySchemaName];
				this.set("EntitySchema", entitySchema);
			},

			/**
			 * Adds filter by master column to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			addMasterColumnFilter: function(esq) {
				const config = this.getDashboardItemsConfig(esq.rootSchemaName);
				if (config?.referenceColumnName) {
					const masterColumnValue = this.getMasterEntityParameterValue(config.masterColumnName);
					const masterColumnExpression = new Terrasoft.ColumnExpression({columnPath: config.referenceColumnName});
					if (masterColumnValue) {
						esq.filters.add("MasterColumnEqualFilter", Terrasoft.createColumnFilterWithParameter(
							Terrasoft.ComparisonType.EQUAL, config.referenceColumnName, masterColumnValue));
					} else {
						esq.filters.add("MasterColumnIsNullFilter", Terrasoft.createIsNullFilter(masterColumnExpression));
					}
					esq.filters.add("MasterColumnNotNullFilter", Terrasoft.createIsNotNullFilter(masterColumnExpression));
				}
			},

			/**
			 * Creates query to EntitySchema.
			 * @private
			 * @param {String} schemaName Name of the EntitySchema.
			 * @return {Terrasoft.data.queries.EntitySchemaQuery} The Query to EntitySchema.
			 */
			createEntitySchemaQuery: function(schemaName) {
				return new Terrasoft.EntitySchemaQuery(schemaName);
			},

			/**
			 * Sets value of the  ViewModel parameter.
			 * @private
			 * @param {String} parameterName Name of the ViewModel parameter.
			 * @param {Object} parameterValue Value of the ViewModel parameter.
			 * @param {Object} [options] Options.
			 */
			setMasterEntityParameterValue: function(parameterName, parameterValue, options) {
				const sandbox = this.sandbox;
				const config = {
					key: parameterName,
					value: parameterValue,
					options: options
				};
				if (!this.destroyed || this.getIsFeatureEnabled("EnableUpdateCardPropertyInDestroyedModule")) {
					sandbox.publish("UpdateCardProperty", config, [sandbox.id]);
				}
			},

			/**
			 * Returns config for items of dashboard.
			 * @private
			 * @param {String} itemsSchemaName Name of the EntitySchema.
			 * @return {Object|null} Config.
			 */
			getDashboardItemsConfig: function(itemsSchemaName) {
				if (this.isEmpty(this.$DashboardConfig)) {
					this.initDashboardConfig();
				}
				const config = this.$DashboardConfig[itemsSchemaName];
				return config || this.$DashboardConfig["VwProcessDashboard"];
			},

			/**
			 * Returns the query to the "Activity" items of dashboard.
			 * @private
			 * @return {Terrasoft.data.queries.EntitySchemaQuery} The Query to EntitySchema.
			 */
			getActivityItemsQuery: function() {
				const esq = this.createEntitySchemaQuery("Activity");
				this.addActivityColumns(esq);
				this.addActivityFilters(esq);
				this._addActivityRowCount(esq);
				return esq;
			},

			/**
			 * @private
			 */
			_addActivityRowCount: function(esq) {
				const queryItemsBatchSize = this.get("QueryItemsBatchSize");
				const dashboardItemsConfig = this.getDashboardItemsConfig("Activity");
				const referenceColumnName = dashboardItemsConfig?.referenceColumnName;
				esq.rowCount = !referenceColumnName && Terrasoft.Features.getIsDisabled("DisableActivityItemsQueryIfReferenceColumnNameIsEmpty")
					? 0
					: queryItemsBatchSize;
			},

			/**
			 * Returns the query to the "Approval" items of dashboard.
			 * @private
			 * @return {Terrasoft.EntitySchemaQuery|null} The Query to EntitySchema.
			 */
			_getVisaItemsQuery: function() {
				let esq = null;
				const approvalSchemaName = this.get("ApprovalSchemaName");
				if (approvalSchemaName) {
					esq = this.createEntitySchemaQuery(approvalSchemaName);
					this._addVisaColumns(esq);
					this._addVisaFilters(esq);
				}
				return esq;
			},

			/**
			 * Returns the query to the "Process" items of dashboard.
			 * @private
			 * @return {Terrasoft.data.queries.EntitySchemaQuery} The Query to EntitySchema.
			 */
			getProcessItemsQuery: function() {
				const esq = this.createEntitySchemaQuery("VwProcessDashboard");
				this.addProcessColumns(esq);
				this.addProcessFilters(esq);
				return esq;
			},

			/**
			 * @private
			 */
			_processDashboardRequest: function(next, scope) {
				this._processActionDashboardRequest("ProcessDashboardRequest", null, next, scope);
			},

			/**
			 * @private
			 */
			_processActionDashboardRequest: function(contractName, collection, next, scope) {
				const dashboardItemsConfig = this.getDashboardItemsConfig("VwProcessDashboard");
				const request = new Terrasoft.ParametrizedRequest({
					contractName: contractName,
					config: {
						entitySchemaUId: this.get("EntitySchema").uId,
						rowCount: this.get("QueryItemsBatchSize")
					}
				});
				if (collection) {
					request.config.elementIds = this.getElementUIds(collection);
				}
				if (dashboardItemsConfig) {
					request.config.entityId = this.getMasterEntityParameterValue(dashboardItemsConfig.masterColumnName);
				}
				request.execute(next, scope);
			},

			/**
			 * Adds columns of "Activity" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			addActivityColumns: function(esq) {
				esq.addColumn("Id");
				esq.addColumn("Title", "Caption");
				esq.addColumn("Type");
				esq.addColumn("ProcessElementId");
				esq.addColumn("StartDate", "Date");
				esq.addColumn("Owner.Name", "Owner");
				if (this._getCanUseFastLoadDcmActionDashboard()) {
					esq.addColumn("OwnerRole.Name", "RoleName");
				}
				esq.addParameterColumn("Activity", Terrasoft.DataValueType.TEXT, "EntitySchemaName");
				const dashboardItemViewConfigClassName = this.getDashboardItemViewConfigClassName(esq.rootSchemaName);
				esq.addParameterColumn(dashboardItemViewConfigClassName, Terrasoft.DataValueType.TEXT,
					"ViewConfigClassName");
				esq.addParameterColumn(true, Terrasoft.DataValueType.BOOLEAN, "EntityInitialized");
				esq.addParameterColumn(false, Terrasoft.DataValueType.BOOLEAN, "IsRequired");
			},

			/**
			 * Adds columns of "SysModuleVisa" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			_addVisaColumns: function(esq) {
				esq.addColumn("Id");
				esq.addColumn("Objective", "Caption");
				esq.addColumn("CreatedOn", "Date");
				esq.addColumn("VisaOwner.Name", "Owner");
				esq.addColumn("IsAllowedToDelegate", "IsAllowedToDelegate");
				const approvalSchemaName = this.get("ApprovalSchemaName");
				esq.addParameterColumn(approvalSchemaName, Terrasoft.DataValueType.TEXT, "EntitySchemaName");
				esq.addParameterColumn(this.getDashboardItemViewConfigClassName(esq.rootSchemaName),
					Terrasoft.DataValueType.TEXT, "ViewConfigClassName");
			},

			/**
			 * Adds columns of "Process" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			addProcessColumns: function(esq) {
				esq.addColumn("Id");
				esq.addColumn("ProcessElementEntityId", "EntityId");
				esq.addColumn("ProcessElementEntitySchemaUId", "EntitySchemaUId");
				esq.addColumn("ProcessElement");
				esq.addColumn("ProcessElement.Id", "ProcessElementId");
				esq.addColumn("ProcessData");
				esq.addColumn("ProcessName", "Description");
				esq.addColumn("ElementCaption");
				esq.addColumn("CreatedOn", "Date");
				esq.addColumn("Owner.Name", "Owner");
				esq.addParameterColumn("VwProcessDashboard", Terrasoft.DataValueType.TEXT, "EntitySchemaName");
				esq.addParameterColumn(this.getDashboardItemViewConfigClassName(esq.rootSchemaName),
					Terrasoft.DataValueType.TEXT, "ViewConfigClassName");
			},

			/**
			 * Adds filters of "Activity" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			addActivityFilters: function(esq) {
				esq.filters = Terrasoft.createFilterGroup();
				this.addMasterColumnFilter(esq);
				this.addActivityDefaultFilters(esq);
			},

			/**
			 * Adds filters of "Approval" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			_addVisaFilters: function(esq) {
				esq.filters = Terrasoft.createFilterGroup();
				this.addMasterColumnFilter(esq);
				const filters = esq.filters;
				filters.addItem(Terrasoft.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"[SysAdminUnitInRole:SysAdminUnitRoleId:VisaOwner].SysAdminUnit",
					Terrasoft.SysValue.CURRENT_USER.value));
				filters.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"IsCanceled", false));
				const filterGroup = esq.createFilterGroup();
				filterGroup.logicalOperation = Terrasoft.LogicalOperatorType.OR;
				const isNullFilterExpression = Ext.create("Terrasoft.ColumnExpression", {
					columnPath: "Status"
				});
				filterGroup.addItem(esq.createIsNullFilter(isNullFilterExpression));
				filterGroup.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"Status.IsFinal", false));
				filters.addItem(filterGroup);
			},

			/**
			 * Adds filters of "Process" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			addProcessFilters: function(esq) {
				esq.filters = Terrasoft.createFilterGroup();
				this.addMasterColumnFilter(esq);
				this.addProcessDefaultFilters(esq);
			},

			/**
			 * Adds default filters of "Activity" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			addActivityDefaultFilters: function(esq) {
				const filters = esq.filters;
				filters.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"Status.Finish", false));
				const activityConstants = ConfigurationConstants.Activity;
				const emailActivityTypeId = activityConstants.Type.Email;
				const emailSendStatusId = activityConstants.EmailSendStatus.NotSended;
				const incomingMessageTypeId = activityConstants.MessageType.Incoming;
				const isNullFilterExpression = Ext.create("Terrasoft.ColumnExpression", {
					columnPath: "MessageType"
				});
				const filterGroup = esq.createFilterGroup();
				filterGroup.logicalOperation = Terrasoft.LogicalOperatorType.OR;
				filterGroup.addItem(esq.createIsNullFilter(isNullFilterExpression));
				filterGroup.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"MessageType", incomingMessageTypeId));
				const emailFilterGroup = esq.createFilterGroup();
				emailFilterGroup.logicalOperation = Terrasoft.LogicalOperatorType.AND;
				emailFilterGroup.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"Type", emailActivityTypeId));
				emailFilterGroup.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"EmailSendStatus", emailSendStatusId));
				filterGroup.add(emailFilterGroup);
				filters.addItem(filterGroup);
			},

			/**
			 * Adds default filters of "Process" items of dashboard to the query.
			 * @private
			 * @param {Terrasoft.data.queries.EntitySchemaQuery} esq The Query to EntitySchema.
			 */
			addProcessDefaultFilters: function(esq) {
				const filters = esq.filters;
				const entitySchema = this.get("EntitySchema");
				filters.addItem(esq.createColumnFilterWithParameter(Terrasoft.ComparisonType.EQUAL,
					"EntitySchemaUId", entitySchema.uId));
			},

			/**
			 * Returns query that obtains actual value of ActionsColumn property from DB.
			 * @private
			 * @return {Terrasoft.data.queries.EntitySchemaQuery} ActionsColumn query.
			 */
			getActionsColumnValueQuery: function() {
				const entitySchemaName = this.get("EntitySchemaName");
				const esq = this.createEntitySchemaQuery(entitySchemaName);
				const actionsColumnName = this.get("ActionsColumnName");
				esq.addColumn(actionsColumnName, "ActionsColumn");
				return esq;
			},

			/**
			 * ActionsColumn query execution callback.
			 * @private
			 * @param {Object} response ActionsColumn query response.
			 */
			getActionsColumnValueCallback: function(response) {
				if (response && response.success) {
					const entity = response.entity;
					const actionsColumn = entity && entity.get("ActionsColumn");
					if (actionsColumn && actionsColumn.value) {
						const columnValue = actionsColumn.value;
						const columnName = this.get("ActionsColumnName");
						this.set("ActiveActionId", columnValue);
						this.setMasterEntityParameterValue(columnName, {value: columnValue}, {silent: true});
						this.handleActiveActionChange();
					}
				}
			},

			/**
			 * Returns whether the page is opened in append mode.
			 * @private
			 * @return {Boolean} Returns whether the page is opened in append mode.
			 */
			isAddMode: function() {
				const operation = this.getMasterEntityParameterValue("Operation");
				return operation === Terrasoft.ConfigurationEnums.CardOperation.ADD;
			},

			/**
			 * Returns whether the page is opened in edit mode.
			 * @private
			 * @return {Boolean} Returns whether the page is opened in edit mode.
			 */
			isEditMode: function() {
				const operation = this.getMasterEntityParameterValue("Operation");
				return operation === Terrasoft.ConfigurationEnums.CardOperation.EDIT;
			},

			/**
			 * Returns whether the page is opened in copy mode.
			 * @private
			 * @return {Boolean} Returns whether the page is opened in copy mode.
			 */
			isCopyMode: function() {
				const operation = this.getMasterEntityParameterValue("Operation");
				return operation === Terrasoft.ConfigurationEnums.CardOperation.COPY;
			},

			/**
			 * Returns whether the page is opened in append or copy mode.
			 * @private
			 * @return {Boolean} Returns whether the page is opened in append or copy mode.
			 */
			isNewMode: function() {
				return this.isAddMode() || this.isCopyMode();
			},

			/**
			 * Finds approval reference column name.
			 * @private
			 * @param {Terrasoft.SysModuleVisaManagerItem} visaManagerItem Visa Manager Item.
			 * @return {Terrasoft.EntitySchemaManagerItem|null}
			 */
			_findVisaEntityItem: function(visaManagerItem) {
				const visaSchemaUId = visaManagerItem.getVisaSchemaUId();
				return Terrasoft.EntitySchemaManager.findItem(visaSchemaUId);
			},

			/**
			 * Finds visa manager item.
			 * @private
			 * @return {Terrasoft.SysModuleVisaManagerItem|null}
			 */
			_findVisaManagerItem: function() {
				const schemaName = this.values.entitySchemaName;
				let entitySchema = this.get("EntitySchema");
				if (!entitySchema) {
					entitySchema = Terrasoft.EntitySchemaManager.findItemByName(schemaName);
					this.set("EntitySchema", entitySchema);
					this.set("EntitySchemaName", schemaName);
				}
				const moduleStructure = Terrasoft.ModuleUtils.getModuleStructureByName(entitySchema.name);
				const sectionItem = Terrasoft.SectionManager.findItem(moduleStructure?.moduleId);
				const sysModuleVisaId = sectionItem?.getSysModuleVisaId();
				return Terrasoft.SysModuleVisaManager.findItem(sysModuleVisaId);
			},

			/**
			 * Finds approval reference column name.
			 * @private
			 * @param {Terrasoft.SysModuleVisaManagerItem} visaManagerItem Visa Manager Item.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			_findVisaReferenceColumnName: function(visaManagerItem, callback, scope) {
				const masterColumnUId = visaManagerItem.getMasterColumnUId();
				const entitySchemaManagerItem = this._findVisaEntityItem(visaManagerItem);
				Terrasoft.chain(
					function(next) {
						entitySchemaManagerItem.getInstance(next, this);
					},
					function(next, instance) {
						const column = instance.findColumnByUId(masterColumnUId);
						callback.call(scope, column.name);
					}, this
				);
			},

			/**
			 * Returns approval items config.
			 * @private
			 * @return {Object}
			 */
			_getApprovalItemsConfig: function() {
				const config = {};
				const approvalSchemaName = this.get("ApprovalSchemaName");
				if (approvalSchemaName) {
					config[approvalSchemaName] = {
						masterColumnName: "Id",
						referenceColumnName: this.get("ApprovalReferenceColumnName"),
						viewModelClassName: "Terrasoft.ApprovalDashboardItemViewModel",
						viewConfigClassName: "Terrasoft.ApprovalDashboardItemViewConfig"
					};
				}
				return config;
			},

			/**
			 * @private
			 */
			_updateStateObject: function() {
				const currentState = this.sandbox.publish("GetHistoryState");
				const state = currentState && currentState.state;
				if (state && state.operation === "add") {
					state.primaryColumnValue = this.getEntitySchemaPrimaryColumnValue();
					state.entitySchemaName = this.get("EntitySchemaName");
					this.sandbox.publish("ReplaceHistoryState", {
						stateObj: state,
						pageTitle: null,
						hash: currentState.hash.historyState,
						silent: true
					});
				}
			},

			/**
			 * Validates master entity.
			 * @return {Boolean}
			 * @private
			 */
			_isMasterEntityValid: function() {
				return this.sandbox.publish("ValidateCard", null, [this.sandbox.id]);
			},

			/**
			 * @private
			 */
			_isMasterEntityValidAsync: async function() {
				return await this.sandbox.publish("ValidateCard", null, [this.sandbox.id]);
			},

			/**
			 * @private
			 */
			_getActualDcmSchemaInformationButtonContent: function() {
				const dcmConfig = this.getMasterEntityParameterValue("DcmConfig");
				const localizableStrings = resources.localizableStrings;
				return dcmConfig.isAnotherVersionActual
					? localizableStrings.ActualDcmSchemaVersionInformationButtonCaption
					: localizableStrings.ActualDcmSchemaInformationButtonCaption;
			},
			/**
			 * Gets value that indicates whether the feature UseFastLoadDcmActionDashboard is enabled.
			 * @return {Boolean}
			 * @private
			 */
			_getCanUseFastLoadDcmActionDashboard: function() {
				return Terrasoft.Features.getIsEnabled("UseFastLoadDcmActionDashboard");
			}

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ActionsControl",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"className": "Terrasoft.BaseStageControl",
					"activeStageId": {
						"bindTo": "ActiveActionId"
					},
					"stages": {
						"bindTo": "ActionsCollection"
					},
					"activeStageChanged": {
						"bindTo": "onActionChanged"
					},
					"activeStageClick": {
						"bindTo": "onActiveStageClick"
					},
					"visible": {
						"bindTo": "Is7xComponent",
						"bindConfig": { converter: "invertBooleanValue" }
					}
				}
			},
			{
				"operation": "insert",
				"name": "ActionsAsyncControl",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"className": "Terrasoft.BaseAsyncStageControl",
					"activeStageId": {
						"bindTo": "ActiveActionId"
					},
					"stages": {
						"bindTo": "ActionsCollection"
					},
					"activeStageChanged": {
						"bindTo": "onActionChanged"
					},
					"activeStageClick": {
						"bindTo": "onActiveStageClickAsync"
					},
					"visible": "$Is7xComponent"
				}
			},
			{
				"operation": "insert",
				"name": "RightHeaderActionContainer",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": { "wrapClassName": ["right-header-action-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "RightHeaderActionContainer",
				"propertyName": "items",
				"name": "ActualDcmSchemaInformationButton",
				"values": {
					"itemType": Terrasoft.ViewItemType.INFORMATION_BUTTON,
					"controlConfig": {
						"classes": {
							"wrapperClass": ["new-dcm-schema-available-info-btn"]
						},
						"visible": {
							"bindTo": "IsActualDcmSchema"
						},
						"caption": {
							"bindTo": "Resources.Strings.ChangeCaseButtonCaption"
						}
					},
					"linkClicked": {
						"bindTo": "onActualDcmSchemaInformationButtonLinkClick"
					},
					"content": {
						"bindTo": "_getActualDcmSchemaInformationButtonContent"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
