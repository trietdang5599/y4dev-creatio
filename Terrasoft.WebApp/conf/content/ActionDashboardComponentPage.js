Terrasoft.configuration.Structures["ActionDashboardComponentPage"] = {innerHierarchyStack: ["ActionDashboardComponentPage"], structureParent: "BaseEntityPage"};
define('ActionDashboardComponentPageStructure', ['ActionDashboardComponentPageResources'], function(resources) {return {schemaUId:'16bb1994-4800-46b4-bd27-6aebec8119f3',schemaCaption: "ActionDashboardComponentPage", parentSchemaName: "BaseEntityPage", packageName: "ActionsDashboard", schemaName:'ActionDashboardComponentPage',parentSchemaUId:'81c2ebad-7f20-4e71-b0c6-941b1422ba62',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("ActionDashboardComponentPage", ["ActionDashboardComponentPageResources",
 		"ConfigurationEnums", "DcmPageMixin"],
	function(resources, ConfigurationEnums) {
		return {
			mixins: {
				DcmPageMixin: "Terrasoft.DcmPageMixin"
			},
			properties: {
				isActionDashboardLoaded: false
			},
			messages: {
				/**
				 * @message ReInitializeActionsDashboard
				 * Run ActionsDashboard reinitialization.
				 */
				"ReInitializeActionsDashboard": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message UpdateDcmActionsDashboardConfig
				 * Update DcmActionsDashboard config.
				 */
				"UpdateDcmActionsDashboardConfig": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ReloadDashboardItems
				 * Reloads dashboard items.
				 */
				"ReloadDashboardItems": {
					mode: Terrasoft.MessageMode.BROADCAST,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message ReloadDashboardItemsPTP
				 * Reloads dashboard items for current page.
				 */
				"ReloadDashboardItemsPTP": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message GetColumnsValues
				 * Returns entity column values.
				 */
				"GetColumnsValues": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message IsDcmFilterColumnChanged
				 * Returns true if DCM filtered columns changed.
				 */
				"IsDcmFilterColumnChanged": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.SUBSCRIBE
				},
				/**
				 * @message ValidateCard
				 * Run validate process and returns true if card valid.
				 */
				"ValidateCard": {
					mode: Terrasoft.MessageMode.PTP,
					direction: Terrasoft.MessageDirectionType.BIDIRECTIONAL
				},
				/**
				 * @message UpdateCardProperty
				 * Actualizes card state.
				 */
				"UpdateCardProperty": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.BIDIRECTIONAL
				},
				/**
				 * @message SaveRecord
				 * Provides save record action.
				 */
				"SaveRecord": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.BIDIRECTIONAL
				},
				/**
				 * @message GetEntityColumnChanges
				 * Sends entity column info when it is changed.
				 * @return {Object} changed
				 * @return {String} changed.columnName Column name.
				 * @return {Object} changed.columnValue Column value.
				 */
				"GetEntityColumnChanges": {
					mode: this.Terrasoft.MessageMode.BROADCAST,
					direction: this.Terrasoft.MessageDirectionType.PUBLISH
				},
				"Get7xAllowedActions": {
					mode: this.Terrasoft.MessageMode.PTP,
					direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				"CanUseDcm": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"HasAnyDcm": {
					dataValueType: Terrasoft.DataValueType.BOOLEAN,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"EntitySchemaName": {
					dataValueType: Terrasoft.DataValueType.TEXT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"DcmConfig": {
					dataValueType: Terrasoft.DataValueType.CUSTOM_OBJECT,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
					onChange: "onDcmConfigChanged"
				},
				"AllowedActions": {
					dataValueType: Terrasoft.DataValueType.COLLECTION,
					type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {
				/**
				 * @private
				 */
				_initHasAnyDcm(entitySchemaName, callback, scope) {
					Terrasoft.chain(
						function(next) {
							Terrasoft.DcmUtilities.checkAnyDcmSchema(this.entitySchema.uId, next, this);
						},
						function(next, hasAnyDcmSchema) {
							this.set("HasAnyDcm", hasAnyDcmSchema);
							callback.call(scope);
						}, this
					);
				},

				/**
				 * @private
				 */
				_tryFindDcmSchema: function(callback, scope) {
					this._initHasAnyDcm(this.$EntitySchemaName, function() {
						this.initDcmActionsDashboardVisibility();
						callback.call(scope);
					}, this);
				},

				/**
				 * @private
				 */
				_extendWithEntityColumns: function() {
					var entityColumns = {};
					Terrasoft.each(this.entitySchema.columns, function(entitySchemaColumn, columnName) {
						var column = Ext.apply(entitySchemaColumn, {
							"columnPath": entitySchemaColumn.name,
							"type": Terrasoft.ViewModelColumnType.ENTITY_COLUMN,
							"modelName": this.entitySchema.name
						});
						entityColumns[columnName] = column;
					}, this);
					this.columns = Ext.apply(this.columns, entityColumns);
				},

				/**
				 * @private
				 */
				_saveEntity: function(config) {
					config.actions = [{
						fn: function() {
							this.sandbox.publish("ReloadDashboardItemsPTP", null, [
								this.getActionDashboardModuleId()
							]);
						},
						scope: this
					}];
					this.sandbox.publish("SaveRecord", config, ["ActionDashboardComponentPage"])
				},

				/**
				 * @private
				 */
				_canApplyCardPropertyValues: function(currentPropertyValue, newPropertyValue) {
					return Ext.isObject(currentPropertyValue) && Ext.isObject(newPropertyValue)
						&& currentPropertyValue.value === newPropertyValue.value;
				},

				/**
				 * @private
				 */
				_actualizeCard: function(config) {
					if (config) {
						var currentValue = this.get(config.key);
						var newPropertyValue = config.value;
						if (this._canApplyCardPropertyValues(currentValue, newPropertyValue)) {
							config.value = Ext.apply(currentValue, newPropertyValue);
						}
						this.set(config.key, config.value, config.options);
						if (config?.options?.silent) {
							config.options.silent = false;
						} 
						this.sandbox.publish("UpdateCardProperty", config, ["ActionDashboardComponentPage"]);
					}
				},

				/**
				 * @protected
				 */
				isNewMode: function() {
					return this.$Operation === ConfigurationEnums.CardStateV2.ADD;
				},

				/**
				 * @protected
				 */
				entityColumnChanged: function(columnName, columnValue) {
					this.sandbox.publish("GetEntityColumnChanges", {
						columnName: columnName,
						columnValue: columnValue
					}, [this.getActionDashboardModuleId()]);
				},

				/**
				 * @protected
				 */
				subscribeMessages: function() {
					this.sandbox.subscribe("ValidateCard", this.onValidateCard, this,
						[this.getActionDashboardModuleId()]);
					this.sandbox.subscribe("UpdateCardProperty", this._actualizeCard, this,
						[this.getActionDashboardModuleId()]);
					this.sandbox.subscribe("SaveRecord", this._saveEntity, this,
						[this.getActionDashboardModuleId()]);
					this.sandbox.subscribe("Get7xAllowedActions", function() {
						return this.$AllowedActions;
					}, this,
						[this.getActionDashboardModuleId()]);
				},

				/**
				 * @inheritdoc Terrasoft.BasePage#init
				 * @override
				 */
				init: function(callback, scope) {
					this.entitySchemaName = this.$EntitySchemaName;
					this.entitySchema = { name: this.$EntitySchemaName };
					this.callParent([function() {
						this.subscribeMessages();
						Terrasoft.chain(
							function(next) {
								this.getEntitySchemaByName(this.entitySchemaName, next, this);
							},
							function(next, entitySchema) {
								this.entitySchema = entitySchema || {};
								this._extendWithEntityColumns();
								this.subscribeViewModelEvents();
								this.loadEntity(this.$PrimaryColumnValue, next, this);
							},
							function(next) {
								if (this.isNewMode()) {
									this.setDefaultValues(next, this, this.$PrimaryColumnValue);
									this.set("Id", this.$PrimaryColumnValue);
								} else {
									next();	
								}
							},
							function() {
								this.sandbox.subscribe("GetColumnsValues", (attributeNames) => {
									var values = {};
									Terrasoft.each(attributeNames, function(attrName) {
										values[attrName] = this.get(attrName);
									}, this);
									return values;
								}, null, [this.getActionDashboardModuleId()]);
								this._tryFindDcmSchema(callback, scope);
							}, this
						);
					}, this]);
				},

				/**
				 * @protected
				 */
				onValidateCard: async function() {
					return await this.sandbox.publish("ValidateCard", null, ["ActionDashboardComponentPage"]);
				},

				/**
				 * @protected
				 */
				onDcmConfigChanged: function(value) {
					if (!value) {
						return;
					}
					if (!this.isActionDashboardLoaded) {
						this.loadActionDashboard();
					}
				},

				/**
				 * @protected
				 */
				getActionDashboardModuleId: function() {
					return this.getModuleId("DcmActionsDashboardModule");
				},

				/**
				 * @protected
				 */
				loadActionDashboard: function() {
					this.sandbox.loadModule("BaseSchemaModuleV2", {
						id: this.getActionDashboardModuleId(),
						renderTo: "ActionDashboardModuleContainer",
						instanceConfig: {
							schemaName: "SectionActionsDashboard",
							isSchemaConfigInitialized: true,
							useHistoryState: false,
							showMask: true,
							parameters: {
								viewModelConfig: {
									Is7xComponent: true,
									entitySchemaName: this.$EntitySchemaName
								}
							},
						}
					});
					this.isActionDashboardLoaded = true;
				},

				/**
				 * @override
				 */
				createDcmConfig: function(config, callback, scope) {
					this.mixins.DcmPageMixin.createDcmConfig.call(this, config, function(newDcmConfig) {
						if (!newDcmConfig.dashboardConfig) {
							newDcmConfig.dashboardConfig = {
								"Activity": {
									"masterColumnName": this.entitySchema.primaryColumn?.columnPath || "Id",
									"referenceColumnSchemaName": this.$EntitySchemaName
								}
							};
						}
						callback.call(scope, newDcmConfig);
					}, this);
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "ComponentPageContainer",
					"values": {
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "ActionDashboardModuleContainer",
					"parentName": "ComponentPageContainer",
					"values": {
						"id": "ActionDashboardModuleContainer",
						"domAttributes": {
							"title": ""
						},
						"itemType": this.Terrasoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items"
				},
			]
		};
 });


