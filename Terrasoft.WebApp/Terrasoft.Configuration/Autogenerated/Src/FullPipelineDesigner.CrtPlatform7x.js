define("FullPipelineDesigner", ["DashboardEnums", "ColumnEditMixin", "SectionBindingColumnMixin"], function() {
	return {
		messages: {

			/**
			 * @message GetChartConfig
			 * Message of parameter preparing for widget module.
			 */
			"GetChartConfig": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message PostItemConfig
			 * Message of parameters changes.
			 */
			"PostItemConfig": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message RefreshFullPipelineWidget
			 * Message of refresh pipe line widget.
			 */
			"RefreshFullPipelineWidget": {
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetSectionEntitySchema 
			 * Message of getting section schema.
			 */
			"GetSectionEntitySchema": {
				mode: Terrasoft.MessageMode.PTP,
				direction: Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		mixins: {
			ColumnEditMixin: "Terrasoft.ColumnEditMixin",
			SectionBindingColumnMixin: "Terrasoft.SectionBindingColumnMixin"
		},
		attributes: {
			/**
			 * Style color of full pipeline widget.
			 */
			"StyleColor": {
				"value": Terrasoft.DashboardEnums.WidgetColor["widget-blue"],
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Entities for widget.
			 */
			"entities": {
				"dataValueType": this.Terrasoft.DataValueType.CUSTOM_OBJECT,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Collection of entities configuration.
			 */
			"EntityCollection": {
				"dataValueType": this.Terrasoft.DataValueType.COLLECTION,
				"type": this.Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			
			/**
			 * Schema name.
			 */
			entitySchemaName: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				isLookup: true,
				lookupListConfig: {
					columns: ["Name", "Caption"],
					filter: "getSchemasFilter"
				},
				referenceSchema: {
					name: Terrasoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
						"VwWorkspaceObjects" :
						"VwSysSchemaInfo",
					primaryColumnName: "Name",
					primaryDisplayColumnName: "Caption"
				},
				referenceSchemaName: Terrasoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
					"VwWorkspaceObjects" :
					"VwSysSchemaInfo"
			},

			/**
			 * Section binding column.
			 */
			sectionBindingColumn: {
				dataValueType: Terrasoft.DataValueType.LOOKUP,
				type: Terrasoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				entityStructureConfig: {
					useBackwards: false,
					displayId: true,
					lookupsColumnsOnly: true,
					allowedReferenceSchemas: "getAllowedReferenceSchemas",
					schemaColumnName: "entitySchemaName"
				}
			},
		},
		methods: {
			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#getWidgetRefreshMessage
			 * @override
			 */
			getWidgetRefreshMessage: function() {
				return "RefreshFullPipelineWidget";
			},

			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#getWidgetModuleName
			 * @override
			 */
			getWidgetModuleName: function() {
				return "FullPipelineModule";
			},

			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#getWidgetConfigMessage
			 * @override
			 */
			getWidgetConfigMessage: function() {
				return "GetChartConfig";
			},

			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#getWidgetModulePropertiesTranslator
			 * @override
			 */
			getWidgetModulePropertiesTranslator: function() {
				var properties = this.callParent(arguments);
				this.Ext.apply(properties, {
					"StyleColor": "styleColor",
					"entities": "entities",
					"entitySchemaName": "entitySchemaName",
					"sectionBindingColumn": "sectionBindingColumn"
				});
				return properties;
			},

			/**
			 * Initializes model values.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			 init: function(callback, scope) {
				this.callParent([function() {
					const schemaName = this._getDefaultEntities()[1].schemaName;
					const entitySchemaNameConfig = {
						value: schemaName,
						displayValue: schemaName,
						Name: schemaName
					};
					this.set("entitySchemaName", entitySchemaNameConfig);
					this.initSectionBindingColumn();
					callback.call(this);
				}, this]);
			},

			/**
			 * Returns custom filter for columns.
			 * @param {Object} columnName Column name.
			 * @return {Function} Custom column filtration method.
			 */
			getColumnsFiltrationMethod: function(columnName) {
				if (columnName === "sectionBindingColumn") {
					return this.columnsFiltrationMethod;
				}
			},

			/**
			 * @inheritDoc Terrasoft.BaseWidgetPreviewDesigner#setWidgetModuleProperties
			 * @override
			 */
			setWidgetModuleProperties: function(widgetConfig, callback, scope) {
				this.callParent([widgetConfig, function() {
					Terrasoft.chain(function(next) {
						var widgetModulePropertiesTranslator = this.getWidgetModulePropertiesTranslator();
						var widgetPropertyName = widgetModulePropertiesTranslator.entitySchemaName;
						var entitySchemaName = widgetConfig[widgetPropertyName];
						if (entitySchemaName) {
							this.getEntitySchemaCaption(entitySchemaName, function(entitySchemaCaption) {
								this.set("entitySchemaName", {
									value: entitySchemaName,
									Name: entitySchemaName,
									displayValue: entitySchemaCaption
								});
							}, this);
						}
						if (widgetConfig.sectionBindingColumn) {
							this.$sectionBindingColumn = {
								displayValue: widgetConfig.sectionBindingColumn,
								value: widgetConfig.sectionBindingColumn
							};
						}
						if (this.Ext.isEmpty(this.$entities)) {
							this.$entities = this._getDefaultEntities();
						}
						this.fillEntityCollection();
						next();
					},
					function(next) {
						this.mixins.ColumnEditMixin.init.call(this, function() {
							next();
						}, this);
					},
					function() {
						this.set("moduleLoaded", true);
						this.Ext.callback(callback, scope || this);
					}, this);
					}, scope || this
				]);
			},

			/**
			 * Fills the entity collection.
			 * @protected
			 */
			fillEntityCollection: function() {
				this.$EntityCollection = this.Ext.create("Terrasoft.BaseViewModelCollection");
				this.Terrasoft.each(this.$entities, function(item) {
					const schemaName = item.schemaName;
					const id = "FullPipelinePropertiesItemModule" + schemaName;
					const model = this.Ext.create("Terrasoft.BaseViewModel", {
						values: item
					});
					model.Ext = this.Ext;
					model.Terrasoft = this.Terrasoft;
					model.sandbox = this.sandbox;
					model.id = id;
					model.renderPropertiesItem = this.renderPropertiesItem;
					this.$EntityCollection.add(schemaName, model);
					this.subscribePostItemConfigItems([id]);
				}, this);
			},

			/**
			 * Subscribes on item parameters changes message.
			 * @param {String[]} tags Tags for filtering messages
			 */
			subscribePostItemConfigItems: function(tags) {
				this.sandbox.subscribe("PostItemConfig", function(config) {
					this._applyItemFilters(config);
				}, this, tags);
			},

			/**
			 * Applies item filters.
			 * @param {Object} config Changed config.
			 * @private
			 */
			_applyItemFilters: function(config) {
				const entities = this.Terrasoft.deepClone(this.$entities);
				const findResult = this.Terrasoft.findItem(entities, {
					schemaName: config.schemaName
				});
				const foundItem = findResult && findResult.item;
				foundItem.filters = config.serializedFilter;
				this.set("entities", entities);
			},

			/**
			 * @private
			 */
			_getDefaultEntities: function() {
				return [
					{
						"schemaName": "Lead",
						"connectedWith": null,
						"calculatedOperations": [{"operation": "Amount", "targetColumnName": "Budget"}],
						"filters": null
					},
					{
						"schemaName": "Opportunity",
						"calculatedOperations": [{"operation": "Amount", "targetColumnName": "Budget"}],
						"connectedWith": {
							"type": 0,
							"schemaName": "Lead",
							"connectionSchemaName": "Lead",
							"parentSchemaColumnName": "Opportunity",
							"childSchemaColumnName": "Id"
						},
						"filters": null
					}
				];
			},

			/**
			 * Returns item view config.
			 * @param {Object} itemConfig Item config.
			 * @return {Object} Item view config.
			 */
			getItemViewConfig: function(itemConfig) {
				itemConfig.config = {
					id: "Item",
					className: "Terrasoft.Container",
					items: [],
					afterrender: {bindTo: "renderPropertiesItem"}
				};
				return itemConfig;
			},

			/**
			 * Renders properties item.
			 */
			renderPropertiesItem: function() {
				var schemaName = this.$schemaName;
				var renderTo =  this.Ext.String.format("Item-{0}-{1}", schemaName, this.sandbox.id);
				this.sandbox.loadModule("FullPipelinePropertiesItemModule", {
					renderTo: renderTo,
					id: this.id,
					instanceConfig: {
						parameters: {
							viewModelConfig: {
								SchemaName: schemaName,
								Filters: this.$filters
							}
						}
					}
				});
			},

			/**
			 * Returns visibility of section binding column.
			 * @return {Boolean} Visibility of section binding column.
			 */
			getSectionBindingColumnVisible: function() {
				const dataSourceSchemaName = this.$dataSourceConfig?.entitySchemaName;
				if (dataSourceSchemaName) {
					var moduleInfo = Terrasoft.configuration.ModuleStructure[dataSourceSchemaName];
					if (!moduleInfo) {
						return false;
					}
				}
				return true;
			},
			
			getSectionBindingGroupVisible: function() {
				const res = !!this.$dataSourceConfig || !!this.get("sectionId");
				const isAngularPage = this.isAngularPage();
				if(isAngularPage) {
					const hasIdAttributeInSchema = this.hasIdAttributeInSchema();
					return res && hasIdAttributeInSchema;
				}
				return res;
			},
		},
		diff: [
			{
				"operation": "insert",
				"name": "EntitiesContainer",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["widget-properties-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EntitiesList",
				"parentName": "EntitiesContainer",
				"propertyName": "items",
				"values": {
					"visible": Terrasoft.Features.getIsEnabled("FullPipelineDesigner"),
					"idProperty": "schemaName",
					"dataItemIdPrefix": "schema-properties",
					"generator": "ConfigurationItemGenerator.generateContainerList",
					"collection": "EntityCollection",
					"onGetItemConfig": "getItemViewConfig"
				}
			},
			{
				"operation": "insert",
				"name": "SectionBindingGroup",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.CONTROL_GROUP,
					"visible": {"bindTo": "getSectionBindingGroupVisible"},
					"controlConfig": {
						"collapsed": false,
						"caption": {"bindTo": "Resources.Strings.SectionBindingGroupCaption"}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "sectionBindingColumn",
				"parentName": "SectionBindingGroup",
				"propertyName": "items",
				"values": {
					"itemType": Terrasoft.ViewItemType.MODEL_ITEM,
					"generator": "ColumnEditGenerator.generatePartial",
					"labelConfig": {"caption": {"bindTo": "getSectionBindingColumnCaption"}},
					"visible": {"bindTo": "getSectionBindingColumnVisible"},
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.SectionBindingColumnCaption"},
						"classes": ["placeholderOpacity"]
					}
				}
			},
		]
	};
});
