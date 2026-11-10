Terrasoft.configuration.Structures["BR7xConditionDesigner"] = {innerHierarchyStack: ["BR7xConditionDesigner"]};
define('BR7xConditionDesignerStructure', ['BR7xConditionDesignerResources'], function(resources) {return {schemaUId:'daff8f9d-70c1-4095-ab8b-c1ac8de1670c',schemaCaption: "BR7xConditionDesigner", parentSchemaName: "", packageName: "BusinessRuleDesigner7x", schemaName:'BR7xConditionDesigner',parentSchemaUId:'',extendParent:false,type:Terrasoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
 define("BR7xConditionDesigner", ["css!BR7xSchemaDesignerCSS", "BR7xCaseDesignerViewModel",
	 "BR7xCaseDesignerCollectionContainer", "BR7xConverter",
], function() {
	return {
		mixins: {
			/**
			 * Mixin for view model, that contains reorderable logic.
			 */
			ReorderableContainerVMMixin: "Terrasoft.ReorderableContainerVMMixin"
		},
		attributes: {
			/**
			 * Business rule schema.
			 */
			"BusinessRuleSchema": {
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Entity schema identifier.
			 */
			"EntitySchemaUId": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Client unit schema identifier.
			 */
			"PageSchema": {
				"dataValueType": Terrasoft.DataValueType.CUSTOM_OBJECT,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Package identifier.
			 */
			"PackageUId": {
				"dataValueType": Terrasoft.DataValueType.TEXT,
				"type": Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
		},
		messages: {
			"GetModuleConfigDesigner": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},
			"GetModuleConfigResultDesigner": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.SUBSCRIBE
			},
			"DataChanged": {
				"mode": Terrasoft.MessageMode.PTP,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},
			"PageLoaded": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			},
			"ModalOpening": {
				"mode": Terrasoft.MessageMode.BROADCAST,
				"direction": Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		properties: {
			converter: null,
			dataChangeSubscription: null,
		},
		methods: {

			/**
			 * @inheritdoc Terrasoft.BaseSchemaViewModel#init
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.mixins.ReorderableContainerVMMixin.preInit.call(this);
					if (this.$ViewModelItems) {
						this.$ViewModelItems.clear();
					}
					this.$ViewModelItems = new Terrasoft.BaseViewModelCollection();
					this.sandbox.subscribe("GetModuleConfigResultDesigner", this.onGetModuleConfigResultDesigner,
						this, [this.sandbox.id]);
					this.sandbox.publish("ModalOpening", null, [this.sandbox.id]);
					callback.call(scope);
				}, this]);
			},

			/**
			 * Designer change handler.
			 * @protected
			 */
			onDesignerDataChange: function(callback, scope) {
				let isValid = true;
				Terrasoft.chain(
					function (next) {
						this.asyncValidate(next, this);
					},
					function (next, validateInfo) {
						isValid = !validateInfo || validateInfo.isValid;
						this.updateMetaItem(next, this);
					},
					function (next) {
						const rule = this.get("BusinessRuleSchema");
						this.converter.convertFromMetaItems(rule, next, this);
					},
					function(next, condition) {
						condition.isValid = isValid;
						this.sandbox.publish("DataChanged", condition, [this.sandbox.id]);
						Ext.callback(callback, scope);
					},
					this,
				);
			},

			/**
			 * Async validate cases.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback scope.
			 */
			asyncValidate: function(callback, scope) {
				var caseCollection = this.$ViewModelItems;
				var items = caseCollection.getItems();
				Terrasoft.eachAsync(
					items,
					function(item, next) {
						item.asyncValidate(next, this);
					},
					function(validateInfo) {
						callback.call(scope, validateInfo);
					}, this);
			},

			/**
			 * Update business rule schema properties.
			 * @protected
			 */
			updateMetaItem: function(callback, scope) {
				this.updateMetaItemChildCollection("ruleSwitch", "ViewModelItems", callback, scope);
			},

			/**
			 * Update meta item child.
			 * @protected
			 * @param {String} metaItemPropertyName Meta item property name.
			 * @param {String} childCollectionName View model collection attribute name.
			 * @param {Function} callback Callback method.
			 * @param {Object} scope Callback method context.
			 */
			updateMetaItemChildCollection: function(metaItemPropertyName, childCollectionName, callback, scope) {
				var schema = this.get("BusinessRuleSchema");
				var collection = this.get(childCollectionName);
				var metaItemElement = schema[metaItemPropertyName];
				var items = [];
				Terrasoft.eachAsync(
					collection.getItems(),
					function(item, next) {
						item.updateMetaItem(function() {
							items.push(item.getMetaItem());
							next();
						}, this);
					},
					function() {
						metaItemElement.cases = items;
						schema.fireEvent("changed");
						callback.call(scope);
					}, this);
			},

			/**
			 * @private
			 */
			_initBusinessRuleSchemaConverter: function(callback) {
				Terrasoft.chain(
					function(next){
						Terrasoft.EntitySchemaManager.initialize(next, this)
					},
					function(next) {
						const entitySchemaUId = this.get("EntitySchemaUId");
						if (!entitySchemaUId) {
							return next(null);
						}
						Terrasoft.EntitySchemaManager.getItemByUId(entitySchemaUId, function(entityItem) {
							Terrasoft.require([entityItem.name], next, this);
						}, this);
					},
					function(next, entitySchema) {
						const pageSchema = this.get("PageSchema")
						this.converter = new Terrasoft.BR7xConverter({ entitySchema, pageSchema });
						callback();
					},
					this,
				);
			},

			/**
			 * Processes getting grid configuration.
			 * @protected
			 * @param {Object} config
			 * @param {Object} config.data
			 * @param {String} config.entitySchemaUId
			 * @param {Object} config.pageSchema
			 * @param {String} config.packageUId
			 */
			onGetModuleConfigResultDesigner: async function(config) {
				this.un("change", this.onDesignerDataChange, this);
				let data = config?.data;
				this.set("EntitySchemaUId", config?.entitySchemaUId);
				this.set("PageSchema", config?.pageSchema);
				this.set("PackageUId", config?.packageUId);
				Terrasoft.chain(
					function (next) {
						this._initBusinessRuleSchemaConverter(next);
					},
					function (next) {
						if (!data) {
							const emptyRule = {
								ruleSwitch: {
									type: "BusinessRuleSwitch",
									cases: [],
								}
							};
							return next(emptyRule);
						}
						let caseConfig = {
							uId: data.uId,
							logicalOperation: data.logical,
							conditions: data.conditions,
						};
						this.converter.convertToMetaItemConfig(caseConfig, next, this);
					},
					function (next, metaItemConfig) {
						const businessRuleSchema = new Terrasoft.BusinessRuleSchema(metaItemConfig);
						this.set("BusinessRuleSchema", businessRuleSchema);
						this.initializeBusinessRuleSwitch(businessRuleSchema.ruleSwitch, next, this);
					},
					function () {
						this.on("change", this.onDesignerDataChange, this);
						this.sandbox.publish("PageLoaded", null, [this.sandbox.id]);
					},
					this,
				)
			},

			/**
			 * Initialize business rule designer view model from business rule switch.
			 * @protected
			 * @param {Terrasoft.BusinessRuleSwitch} ruleSwitch Business rule switch.
			 * @param callback
			 * @param scope
			 */
			initializeBusinessRuleSwitch: function(ruleSwitch, callback, scope) {
				const caseConfig = {
					Id: Terrasoft.generateGUID(),
				};
				if (ruleSwitch.cases?.length) {
					caseConfig.MetaItem = ruleSwitch.cases[0];
				}
				const caseCollection = this.$ViewModelItems;
				caseCollection.clear();
				var caseViewModel = this.createBusinessRuleCaseViewModel(caseConfig);
				caseCollection.add(caseViewModel.get("Id"), caseViewModel);
				caseViewModel.waitLoaded(callback, scope);
			},

			/**
			 * Create business rule case designer view model.
			 * @protected
			 * @param {Object} values Business View model values.
			 * @return {Terrasoft.BR7xCaseDesignerViewModel} Case designer view model.
			 */
			createBusinessRuleCaseViewModel: function(values) {
				const viewModel = new Terrasoft.BR7xCaseDesignerViewModel({
					Ext: this.Ext,
					Terrasoft: Terrasoft,
					sandbox: this.sandbox,
					entitySchemaUId: this.get("EntitySchemaUId"),
					pageSchema: this.get("PageSchema"),
					packageUId: this.get("PackageUId"),
					values: values
				});
				viewModel.on("change", this.onCaseViewModelChange, this);
				return viewModel;
			},

			onCaseViewModelChange: function() {
				this.fireEvent("change");
			},

			/**
			 * @private
			 */
			_onPullChanges: function(config) {
				if (config.actionType === "PullPageSchemaUId") {
					config.sourceElement.pageSchemaUId = this.$Page && this.$Page.value;
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "BusinessRuleSwitchContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"items": [],
					"classes": {
						"wrapClassName": ["business-rule-island-container"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "BusinessRuleCaseCollectionContainer",
				"parentName": "BusinessRuleSwitchContainer",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"className": "Terrasoft.BR7xCaseDesignerCollectionContainer",
					"items": [],
					"viewModelItems": {"bindTo": "ViewModelItems"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});


